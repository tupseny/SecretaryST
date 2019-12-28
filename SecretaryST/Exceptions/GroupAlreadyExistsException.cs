using SecretaryST.Models;
using SecretaryST.Structs;
using System;

namespace SecretaryST.Exceptions
{
    public class GroupAlreadyExistsException : Exception
    {
        private DistanceGroup group;
        private GroupIndexAmountStruct struc;

        internal DistanceGroup Group { get => group; set => group = value; }
        public GroupIndexAmountStruct Struc { get => struc; set => struc = value; }

        internal GroupAlreadyExistsException(GroupIndexAmountStruct struc, DistanceGroup group)
        {
            this.Group = group;
            this.Struc = struc;
        }

        public GroupAlreadyExistsException(string message) : base(message)
        {
        }

        public GroupAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
