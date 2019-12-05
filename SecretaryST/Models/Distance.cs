using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecretaryST.Enums;

namespace SecretaryST.Models
{
    class Distance
    {
        private DistanceGroup _Group;
        private DistanceLevels _Level;

        public Distance(DistanceGroup group, DistanceLevels level)
        {
            _Group = group;
            _Level = level;
        }

        internal DistanceGroup Group { get => _Group; set => _Group = value; }
        internal DistanceLevels Level { get => _Level; set => _Level = value; }
    }
}
