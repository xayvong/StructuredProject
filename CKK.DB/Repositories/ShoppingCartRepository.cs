using CKK.Logic.Models;
using CKK.DB.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.DB.Repositories;

namespace CKK.DB.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        
        private readonly string _shopcart = "ShoppingCartItems";
        


        public ShoppingCartRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            
        }
        
        public ShoppingCartItem AddtoCart(int ShoppingCardId, int ProductId, int quantity)
        {
            using(var conn = _connectionFactory.GetConnection) 
            {
                ProductRepository _productRepository = new ProductRepository(_connectionFactory);
                var item = _productRepository.GetByIdAsync(ProductId).Result;
                var ProductItems = GetProducts(ShoppingCardId).Find(x => x.ProductId == ProductId);

                var shopitem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCardId,
                    ProductId = ProductId,
                    Quantity = quantity
                };

                
                if (item.Quantity >= quantity) 
                {
                    if (ProductItems != null)
                    {
                        //Product already in cart so update quantity
                        var test = UpdateAsync(shopitem);
                    }
                    else
                    {
                        //New product for the cart so add it
                        var test = AddAsync(shopitem);
                    }


                    //string sql = @"INSERT INTO ShoppingCartItems (ShoppingCartId,ProductId,Quantity) VALUES (@ShoppingCartId,@ProductId,@Quantity)";
                    //SqlMapper.Execute(conn, sql, shopitem);// new { ShoppingCartId = shopitem.ShoppingCartId, ProductId = shopitem.ProductId, Quantity = shopitem.Quantity});
                }
                
                return shopitem;
            }
            
        }
        public int AddAsync(ShoppingCartItem entity)
        {
            var sql = "Insert into ShoppingCartItems (ShoppingCartId,ProductId,Quantity) VALUES (@ShoppingCartId,@ProductId,@Quantity)";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Execute(sql, entity);
                return result;
            }
        }
        public int UpdateAsync(ShoppingCartItem entity)
        {
            var sql = "UPDATE ShoppingCartItems SET ShoppingCartId = @ShoppingCartId, ProductId = @ProductId, Quantity = @Quantity WHERE ShoppingCartId = @ShoppingCartId AND ProductId = @ProductId";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result =  connection.Execute(sql, entity);
                return result;
            }
        }

        public int GetCustomerId(int shoppingCartId)
        {
            using (var conn = _connectionFactory.GetConnection)
            {
                var result = SqlMapper.QuerySingleOrDefault<ShoppingCartItem>(conn,$"dbo.ShoppingCarts_shoppingcartid @ShoppingCartId", new {ShoppingCartId = shoppingCartId});
                if (result == null)
                    throw new KeyNotFoundException($"{_shopcart} with id [{shoppingCartId}] could not be found.");
                return result.CustomerId;
            }
        }

        public List<ShoppingCartItem> GetProducts(int shoppingCartId)
        {
            using (var conn = _connectionFactory.GetConnection) 
            {
                string sql = @"SELECT * FROM ShoppingCartItems WHERE ShoppingCartId = @ShoppingCartId";
                var result = SqlMapper.Query<ShoppingCartItem>(conn, sql, new { ShoppingCartId = shoppingCartId }).ToList();
                return result;
            }
        }

        public async Task<Product> GetById(int id)
        {
            var sql = "SELECT * FROM ShoppingCartItems WHERE Id = @Id";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Product>(sql, new { Id = id });
                return result;
            }
        }

        public decimal GetTotal(int shoppingCartId)
        {
            using (var conn = _connectionFactory.GetConnection)
            {
                var items = SqlMapper.Query<ShoppingCartItem>(conn, @"SELECT * FROM ShoppingCartItems WHERE dbo.ShoppingCartItems.ShoppingCartId = @ShoppingCartId", new { ShoppingCartId = shoppingCartId }).ToList();
                List<decimal> total = new List<decimal>();
                ProductRepository _productRepository = new ProductRepository(_connectionFactory);

                foreach (var item in items)
                {
                    var product = _productRepository.GetByIdAsync(item.ProductId).Result;
                    total.Add(product.Price * (decimal)item.Quantity);
                }
               return total.Sum();
               
            }
        }

        public ShoppingCartItem RemoveFromCart(int shoppingCartId, int itemId, int quantity = 1)
        {
            using (var conn = _connectionFactory.GetConnection)
            {
                ProductRepository _productRepository = new ProductRepository(_connectionFactory);
                var items = SqlMapper.Query<ShoppingCartItem>(conn, $"dbo.ShoppingCarts_shoppingcartid @ShoppingCartId", new { ShoppingCartId = shoppingCartId }).ToList();
                var shopitem = from item in items
                               where item.ProductId==itemId
                               select item;
                var product = shopitem.FirstOrDefault();
                                          

                if (product != null) 
                {

                    
                    if (product.Quantity - quantity > 0) 
                    {
                        product.Quantity = product.Quantity - quantity;
                        SqlMapper.Query<ShoppingCartItem>(conn, $"dbo.ShoppingCarts_removeitem @ShoppingCartId, @Quantity, @ProductId", product);
                        
                    }
                    else 
                    {
                        SqlMapper.Execute(conn, $"DELETE FROM {_shopcart} WHERE ProductId=@ProductId", new { ProductId = itemId });

                    }
                }

                
                return product;

            }
        }
        public void Ordered(int shoppingCartId)
        {
            using (var conn = _connectionFactory.GetConnection)
            {
                SqlMapper.Execute(conn, $"DELETE FROM {_shopcart} WHERE ShoppingCartId=ShoppingCartId", new { ShoppingCartId = shoppingCartId });
            }
        }
        public void Delete()
        {
            using (var conn = _connectionFactory.GetConnection)
            {
                SqlMapper.Execute(conn, $"DELETE FROM {_shopcart} WHERE ShoppingCartId=ShoppingCartId", new { ShoppingCartId = 1 });
            }
        }

    }
}
