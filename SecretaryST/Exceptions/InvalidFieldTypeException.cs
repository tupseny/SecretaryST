using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretaryST.Exceptions
{
    class InvalidFieldTypeException : Exception
    {
        public InvalidFieldTypeException(string message) : base(message)
        {
        }

        public InvalidFieldTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public InvalidFieldTypeException(string requiredType, object obj) : base(ModifyMessage(requiredType, obj))
        {
        }

        private static string ModifyMessage(string requiredType, object o)
        {
            string msg = "Type should be '" + requiredType + "' but got '" + o.GetType().ToString() + "'";
            return msg;
        }

        public InvalidFieldTypeException()
        {
        }
    }
}
