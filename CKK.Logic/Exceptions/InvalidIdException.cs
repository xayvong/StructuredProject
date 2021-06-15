using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Exceptions
{
    [Serializable]
    public class InvalidIdException : Exception
    {
        public InvalidIdException() 
            :base("The Id entered was invalid") 
        {

        }

        public InvalidIdException(string msg, Exception innerException)
            :base(msg,innerException)
        {

        }


    }
}
