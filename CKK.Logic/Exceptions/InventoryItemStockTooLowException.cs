using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Exceptions
{
    [Serializable]
    public class InventoryItemStockTooLowException : Exception
    {
        public InventoryItemStockTooLowException()
            :base("The inventory Item stock is too low")
        {

        }

        public InventoryItemStockTooLowException(string msg, Exception innerException) 
            :base(msg, innerException)
        {

        }
    }
}
