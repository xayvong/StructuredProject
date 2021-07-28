using CKK.Logic.Exceptions;
using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using CKK.Persistance.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CKK.Persistance.Models
{
    public class FileStore : IStore, ILoadable, ISavable
    {
        private List<Product> Items;
        private readonly string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "Persistance" + Path.DirectorySeparatorChar + "StoreItems.dat";
        private int IdCounter = 0;

        public FileStore()
        {
            CreatePath();
            Items = new();
            Load();
        }


        public Product AddStoreItem(Product product, int quantity)
        {
            if (quantity < 0)
            {
                throw new InventoryItemStockTooLowException();
            }
            if (product.ProductId == 0)
            {
                product.ProductId = (++IdCounter);
            }
            var existingItem = FindStoreItemById(product.ProductId);
            if (existingItem == null)
            {
                product.Quantity = quantity;
                Items.Add(product);
                Save();
                return product;
            }
            else
            {
                existingItem.Quantity = (existingItem.Quantity + quantity);
                Save();
                return existingItem;
            }
        }

        public Product DeleteStoreItem(int id)
        {
            var existingItem = FindStoreItemById(id);
            if (existingItem != null)
            {
                Items.Remove(existingItem);
            }
            Save();
            return existingItem;
        }

        public Product FindStoreItemById(int id)
        {
            if (id < 0)
            {
                throw new InvalidIdException();
            }
            return Items.FirstOrDefault(p => p.ProductId == id);
        }

        public List<Product> GetStoreItems()
        {
            return Items;
        }

        public void Load()
        {
            FileStream stream = new(FilePath, FileMode.OpenOrCreate, FileAccess.Read);

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Items = (List<Product>)formatter.Deserialize(stream);
                IdCounter = Items.Count + 1;
                foreach (var item in Items)
                {
                    if (item.ProductId == 0)
                    {
                        item.ProductId = (++IdCounter);
                    }
                }

            }
            catch (IOException e)
            {
                throw new IOException("There has been an error opening the file to load data", e);
            }
            catch (SerializationException)
            {
                Items = new();
                //throw new SerializationException("There was a problem deserializing the data: " + ex.Message, ex);
            }
            finally
            {
                stream?.Dispose();
            }


        }

        public Product RemoveStoreItem(int id, int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            var existingItem = FindStoreItemById(id);
            if (existingItem != null)
            {
                if (existingItem.Quantity - quantity < 0)
                {
                    existingItem.Quantity = (0);
                }
                else
                {
                    existingItem.Quantity = (existingItem.Quantity - quantity);
                }
                Save();
                return existingItem;
            }
            else
            {
                throw new ProductDoesNotExistException();
            }
        }

        public void Save()
        {
            FileStream stream = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.Write);

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, Items);
            }catch (IOException e)
            {
                throw new IOException("There was a problem writing to the file", e);
            }
            catch (SerializationException ex)
            {
                throw new SerializationException("There was a problem serializing the data: " + ex.Message, ex);
            }
            finally
            {
                stream?.Dispose();
            }
        }

        private void CreatePath()
        {
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "Persistance");
        }
        public List<Product> GetProductsByQuantity()
        {
            return new List<Product>(Items.OrderByDescending(t => t.Quantity));
        }

        public List<Product> GetProductsByPrice()
        {
            return new List<Product>(Items.OrderByDescending(t => t.Price));
        }

        public List<Product> GetProductsByName(string name)
        {
            return new List<Product>(Items.Where(i => i.Name.ToLower().Contains(name.ToLower())));
        }
    }
}
