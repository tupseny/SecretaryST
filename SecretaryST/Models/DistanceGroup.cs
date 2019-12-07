using SecretaryST.Enums;
using System.Collections.Generic;

namespace SecretaryST.Models
{
    class DistanceGroup
    {
        private int _ChipNumber;
        private DistanceGroupType _Type;

        private readonly DistanceGroupAmount _Amount;
        private readonly List<Person> _Members;
        private readonly int _MaxMembers;

        public DistanceGroup(DistanceGroupAmount amount, int chipNumber = 0)
        {
            _Amount = amount;
            _ChipNumber = chipNumber;
            _Members = new List<Person>();
            _MaxMembers = EnumCasters.FromDistanceGroupAmount(Amount);
        }

        public int ChipNumber { get => _ChipNumber; set => _ChipNumber = value; }
        internal DistanceGroupAmount Amount { get => _Amount; }
        internal DistanceGroupType Type
        {
            get => _Type;
        }
        internal List<Person> Members => _Members;

        public int MaxMembers => _MaxMembers;

        internal void AddMember(Person p)
        {
            if (IsFull())
            {
                throw new Exceptions.GroupFullException();
            }
            else
            {
                this.Members.Add(p);
                if (IsFull()) { SetGroupSex(); }
            }
        }

        private void SetGroupSex()
        {
            Sex tempSex = Sex.Undefined;
            this.Members.ForEach(m =>
            {
                if (tempSex == Sex.Undefined) { tempSex = m.Sex; }
                if (m.Sex != tempSex) { this._Type = DistanceGroupType.Both; }
            });
            if (Type != DistanceGroupType.Both) this._Type = EnumCasters.SexToGroupType(tempSex);
        }

        public bool IsFull()
        {
            if (this.Members.Count >= this.MaxMembers)
            {
                return true;
            }

            return false;
        }


    }
}
