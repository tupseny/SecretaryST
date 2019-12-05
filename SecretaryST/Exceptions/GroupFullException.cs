using SecretaryST.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretaryST.Exceptions
{
    public class GroupFullException : Exception
    {
        private readonly Structs.GroupIndexAmountStruct groupIndexAmount;

        public GroupFullException()
        {
        }

        public GroupFullException(string message) : base(message)
        {
        }

        public GroupFullException(SecretaryST.Structs.GroupIndexAmountStruct groupIndexAmount) : base(ModifyMessage(groupIndexAmount))
        {
            this.groupIndexAmount = groupIndexAmount;
        }

        public GroupFullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public GroupIndexAmountStruct GroupIndexAmount => groupIndexAmount;

        private static string ModifyMessage(SecretaryST.Structs.GroupIndexAmountStruct groupIndexAmount)
        {
            string msg = "Group is already full. Group type - '" + groupIndexAmount.Amnt + "', Group nr - '" + groupIndexAmount.GroupIndex + "'";
            return msg;
        }
    }
}
