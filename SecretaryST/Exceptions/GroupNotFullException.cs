using SecretaryST.Enums;
using SecretaryST.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretaryST.Exceptions
{
    public class GroupNotFullException : Exception
    {
        private readonly GroupIndexAmountStruct structGroupIndex;

        public GroupIndexAmountStruct StructGroupIndex => structGroupIndex;

        public GroupNotFullException(GroupIndexAmountStruct structGroupIndex) : base(GenMsg(structGroupIndex.GroupIndex, structGroupIndex.Amnt))
        {
            this.structGroupIndex = structGroupIndex;
        }

        public GroupNotFullException(string message) : base(message)
        {
        }

        public GroupNotFullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public GroupNotFullException()
        {
        }

        private static string GenMsg(int groupIndex, SecretaryST.Enums.DistanceGroupAmount groupAmount)
        {
            string msg = "Group nr. " + groupIndex + " is not full! Amount  - " + groupAmount;
            return msg;
        }
    }
}
