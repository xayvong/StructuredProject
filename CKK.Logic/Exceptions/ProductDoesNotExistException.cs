using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Exceptions
{
    [Serializable]
    public class ProductDoesNotExistException : Exception
    {
        public ProductDoesNotExistException()
            :base("The product you tried to get does not exist")
        {

        }

        public ProductDoesNotExistException(string msg, Exception innerException)
            :base(msg, innerException)
        {

        }
    }
}
