using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretaryST.Exceptions
{
    class InvalidFieldTypeException : Exception
    {
        private string requiredType;
        private int iRow;
        private int iCol;

        public string RequiredType { get => requiredType; set => requiredType = value; }
        public int IRow { get => iRow; set => iRow = value; }
        public int ICol { get => iCol; set => iCol = value; }

        public InvalidFieldTypeException(string message) : base(message)
        {
        }

        public InvalidFieldTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public InvalidFieldTypeException(string requiredType, object obj, int iRow = 0, int iCol = 0) : base(ModifyMessage(requiredType, obj))
        {
            this.iRow = iRow;
            this.iCol = iCol;
            this.requiredType = requiredType;
        }

        private static string ModifyMessage(string requiredType, object o)
        {
            string t = o is null ? "empty" : o.GetType().ToString();

            string msg = "Type should be '" + requiredType + "' but got '" + t + "'";
            return msg;
        }

        public InvalidFieldTypeException()
        {
        }
    }
}
