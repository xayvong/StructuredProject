﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public int ShoppingCartId { get; set; }
    }
}
