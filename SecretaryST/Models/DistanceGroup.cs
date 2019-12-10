using SecretaryST.Enums;
using System.Collections.Generic;

namespace SecretaryST.Models
{
    class DistanceGroup
    {
        private int _ChipNumber;
        private DistanceGroupType _Type;
        private string _Delegation;
        private string _Region;

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

        public string Delegation { get => _Delegation; set => _Delegation = value; }
        public string Region { get => _Region; set => _Region = value; }

        internal void AddMember(Person p)
        {
            if (string.IsNullOrEmpty(Delegation)) { Delegation = p.Delegation; }
            if (string.IsNullOrEmpty(Region)) { Region = p.Region; }

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

        public string GetNames(string sep = ",<br>", bool joinRang = false)
        {
            string[] aNames = new string[Members.Count];
            for (int i = 0; i < Members.Count; i++)
            {
                aNames[i] = joinRang ? Members[i].Name + " (" + Members[i].Rang + ")" : Members[i].Name;
            }

            return string.Join(sep, aNames);
        }

        public string GetRangs(string sep = ",<br>")
        {
            string[] aRangs = new string[Members.Count];
            for (int i = 0; i < Members.Count; i++)
            {
                aRangs[i] = EnumCasters.RangStringRepresent(Members[i].Rang);
            }

            return string.Join(sep, aRangs);
        }

        public string GetBirths(string sep = ",<br>")
        {
            string[] aValues = new string[Members.Count];
            for (int i = 0; i < Members.Count; i++)
            {
                aValues[i] = Members[i].BirthYear();
            }

            return string.Join(sep, aValues);
        }

        public string GetSexs(string sep = ",<br>")
        {
            string[] aValues = new string[Members.Count];
            for (int i = 0; i < Members.Count; i++)
            {
                aValues[i] = EnumCasters.SexStringRepresent(Members[i].Sex);
            }

            return string.Join(sep, aValues);
        }

        public int GetDistanceRangSum()
        {
            int rang = 0;

            foreach (Person p in Members)
            {
                rang += (int)p.Rang * 4 / (int)Amount;
            }

            return rang;
        }

        public string GetTypeRepresnet()
        {
            return EnumCasters.GroupTypeStringRepresent(Type);
        }

        public string GenGroupNr()
        {
            return "unknown";
        }
    }
}
