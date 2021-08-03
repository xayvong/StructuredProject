using CKK.Logic.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace CKK.Logic.Models
{
    [Serializable]
    public class Customer : Entity
    {
        public int CustomerId { get; set; }
        public string Address { get; set; }
        public int ShoppingCartId { get; set; }
        public ShoppingCart Cart { get; set; }
    }
}
