using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecretaryST.Enums;
using SecretaryST.Structs;

namespace SecretaryST.Models
{
    class Distance
    {
        private readonly Dictionary<GroupIndexAmountStruct, DistanceGroup> _Groups;
        private DistanceLevels _Level;

        public Distance(DistanceLevels level)
        {
            _Groups = new Dictionary<GroupIndexAmountStruct, DistanceGroup>();
            _Level = level;
        }

        internal Dictionary<GroupIndexAmountStruct, DistanceGroup> Groups { get => _Groups; }
        internal DistanceLevels Level { get => _Level; set => _Level = value; }
        internal void AddGroup(GroupIndexAmountStruct groupIndexAmount, DistanceGroup grp)
        {
            this.Groups.Add(key: groupIndexAmount, value: grp);
        }
    }
}
