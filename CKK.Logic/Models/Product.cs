﻿using CKK.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    [Serializable]
    public class Product : Entity
    {
        private decimal price;
        public decimal Price {
            get
            {
                return price;
            }
            set
            {
                if (value >= 0)
                {
                    price = value;
                } else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
