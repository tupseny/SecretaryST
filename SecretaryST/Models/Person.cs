using SecretaryST.Enums;
using System;

namespace SecretaryST.Models
{
    class Person
    {
        private int _Nr;
        private string _Name;
        private DateTime _Birth;
        private string _Region;
        private string _Delegation;
        private Rangs _Rang;
        private Sex _Sex;

        public Person(string name, DateTime birth, string region, string delegation, Rangs rang, Sex sex)
        {
            _Name = name;
            _Birth = birth;
            _Region = region;
            _Delegation = delegation;
            _Rang = rang;
            _Sex = sex;

            _Nr = Globals.Counters.IPerson;
        }

        public string Name { get => _Name; set => _Name = value; }
        public DateTime Birth { get => _Birth; set => _Birth = value; }
        public string Region { get => _Region; set => _Region = value; }
        public string Delegation { get => _Delegation; set => _Delegation = value; }
        public int Nr { get => _Nr; }
        internal Rangs Rang { get => _Rang; set => _Rang = value; }
        internal Sex Sex { get => _Sex; set => _Sex = value; }

        public override bool Equals(object obj)
        {
            return obj is Person person &&
                   _Name == person._Name &&
                   _Birth == person._Birth &&
                   _Rang == person._Rang &&
                   _Sex == person._Sex;
        }

        internal string BirthYear()
        {
            return Birth.Year.ToString();
        }


    }
}
