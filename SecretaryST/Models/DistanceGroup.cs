using SecretaryST.Enums;
using System;
using System.Collections.Generic;

namespace SecretaryST.Models
{
    class DistanceGroup
    {
        private DistanceGroupAmount _Amount;
        private DistanceGroupType _Type;
        private int _ChipNumber;
        private readonly List<Person> _Members;

        public DistanceGroup(DistanceGroupAmount amount, int chipNumber = 0)
        {
            _Amount = amount;
            _ChipNumber = chipNumber;
            _Members = new List<Person>();
        }

        public int ChipNumber { get => _ChipNumber; set => _ChipNumber = value; }
        internal DistanceGroupAmount Amount { get => _Amount; set => _Amount = value; }
        internal DistanceGroupType Type
        {
            get => _Type; set => _Type = value;
        }
        internal List<Person> Members => _Members;

        internal void addMember(Person p)
        {
            int max = EnumCasters.fromDistanceGroupAmount(this.Amount);
            if (this.Members.Count >= max)
            {
                throw new Exceptions.GroupFullException();
            }
            else
            {
                this.Members.Add(p);
                if (this.Members.Count == max)
                {
                    Sex tempSex = Sex.Undefined;
                    this.Members.ForEach(m =>
                    {
                        if (tempSex == Sex.Undefined) { tempSex = p.Sex; }
                        if (p.Sex != tempSex) { Type = DistanceGroupType.Both; }

                    });
                    if (Type != DistanceGroupType.Both) Type = EnumCasters.sexToGroupType(tempSex);
                }
            }




        }
    }
}
