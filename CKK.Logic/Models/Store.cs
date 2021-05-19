using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class Store
    {
        private int Id;
        private string Name;
        private Product Product1;
        private Product Product2;
        private Product Product3;

        public int GetId()
        {
            return Id;
        }
        public void SetId(int id)
        {
            Id = id;
        }
        public string GetName()
        {
            return Name;
        }
        public void SetName(string name)
        {
            Name = name;
        }
        public void AddStoreItem(Product product)
        {
            if (Product1 == null)
            {
                Product1 = product;
            }
            else if (Product2 == null)
            {
                Product2 = product;
            }
            else if (Product3 == null)
            {
                Product3 = product;
            }
        }

        public void RemoveStoreItem(int productNumber)
        {
            if (productNumber == 1)
            {
                Product1 = null;
            }
            if (productNumber == 2)
            {
                Product2 = null;
            }
            if (productNumber == 3)
            {
                Product3 = null;
            }
        }

        public Product GetStoreItem(int productNumber)
        {
            if (productNumber == 1)
            {
                return Product1;
            }
            if (productNumber == 2)
            {
                return Product2;
            }
            if (productNumber == 3)
            {
                return Product3;
            }
            else
            {
                return null;
            }
        }
        public Product FindStoreItemById(int id)
        {
            if (Product1.GetId() == id)
            {
                return Product1;
            }
            else if (Product2.GetId() == id)
            {
                return Product2;
            }
            else if (Product3.GetId() == id)
            {
                return Product3;
            }
            else
            {
                return null;
            }
        }
    }
}
