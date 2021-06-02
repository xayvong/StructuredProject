using CKK.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class Product : Entity
    {
        private decimal Price;

        public decimal GetPrice()
        {
            return Price;
        }
        public void SetPrice(decimal price)
        {
            if (price > 0)
            {
                Price = price;
            }else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
