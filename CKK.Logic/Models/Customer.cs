﻿using CKK.Logic.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace CKK.Logic.Models
{
    [Serializable]
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int ShoppingCartId { get; set; }
    }
}
