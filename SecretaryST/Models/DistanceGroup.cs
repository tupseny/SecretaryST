using SecretaryST.Enums;
using System.Collections.Generic;

namespace SecretaryST.Models
{
    class DistanceGroup
    {
        private int _ChipNumber;
        private int _iGroup;
        private DistanceGroupType _Type;
        private string _Delegation;
        private string _Region;
        private string _Manager;

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

        public string Delegation { get => _Delegation; set { _Delegation = value; _iGroup = Amount == DistanceGroupAmount.Two ? Globals.Counters.IGroup2 : Amount == DistanceGroupAmount.Four ? Globals.Counters.IGroup4 : 0; } }
        public string Region { get => _Region; set => _Region = value; }
        public string Manager { get => _Manager; set => _Manager = value; }

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

        private static void IfSepNullReplaceWithNewline(string sep, out string result)
        {
            if (sep is null)
            {
                result = System.Environment.NewLine;
            }
            else
            {
                result = sep;
            }
        }

        public bool IsFull()
        {
            if (this.Members.Count >= this.MaxMembers)
            {
                return true;
            }

            return false;
        }

        public string GetNames(string sep = null, bool joinRang = false)
        {
            IfSepNullReplaceWithNewline(sep, out sep);

            string[] aNames = new string[Members.Count];
            for (int i = 0; i < Members.Count; i++)
            {
                aNames[i] = joinRang ? Members[i].Name + " (" + EnumCasters.RangStringRepresent(Members[i].Rang) + ")" : Members[i].Name;
            }

            return string.Join(sep, aNames);
        }

        public string GetRangs(string sep = null)
        {
            IfSepNullReplaceWithNewline(sep, out sep);

            string[] aRangs = new string[Members.Count];
            for (int i = 0; i < Members.Count; i++)
            {
                aRangs[i] = EnumCasters.RangStringRepresent(Members[i].Rang);
            }

            return string.Join(sep, aRangs);
        }

        public string GetBirths(string sep = null)
        {
            IfSepNullReplaceWithNewline(sep, out sep);

            string[] aValues = new string[Members.Count];
            for (int i = 0; i < Members.Count; i++)
            {
                aValues[i] = Members[i].BirthYear();
            }

            return string.Join(sep, aValues);
        }

        public string GetSexs(string sep = null)
        {
            IfSepNullReplaceWithNewline(sep, out sep);

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

        public string GenGroupNr(string sep = null)
        {
            IfSepNullReplaceWithNewline(sep, out sep);

            switch (Amount)
            {
                case DistanceGroupAmount.One:
                    if (Globals.Options.ComputePersonNrFor1)
                    {
                        return GetMemberNr();
                    }
                    else
                    {
                        return "";
                    }

                case DistanceGroupAmount.Two:
                    if (Globals.Options.ComputePersonNrFor2)
                    {
                        return Globals.Options.SeperateNumerationInsideGroups2 ? ConcatDelegationNrAndGroupNr() : GetMemberNr();
                    }
                    else
                    {
                        return "";
                    }

                case DistanceGroupAmount.Four:
                    if (Globals.Options.ComputePersonNrFor4)
                    {
                        return Globals.Options.SeperateNumerationInsideGroups4 ? ConcatDelegationNrAndGroupNr() : GetMemberNr();
                    }
                    else
                    {
                        return "";
                    }
            }

            return "unknown";

            string ConcatDelegationNrAndGroupNr(string sep2 = ".")
            {
                string[] aValues = new string[Members.Count];
                int iPerson = 1;
                for (int i = 0; i < Members.Count; i++)
                {
                    aValues[i] = this._iGroup + sep2 + iPerson;

                    iPerson++;
                }

                return string.Join(sep, aValues);
            }

            string GetMemberNr()
            {
                string[] aValues = new string[Members.Count];
                for (int i = 0; i < Members.Count; i++)
                {
                    aValues[i] = Members[i].Nr.ToString();
                }

                return string.Join(sep, aValues);
            }
        }
    }
}
