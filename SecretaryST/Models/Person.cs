using SecretaryST.Enums;
using System;

namespace SecretaryST.Models
{
    class Person
    {
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
        }

        public string Name { get => _Name; set => _Name = value; }
        public DateTime Birth { get => _Birth; set => _Birth = value; }
        public string Region { get => _Region; set => _Region = value; }
        public string Delegation { get => _Delegation; set => _Delegation = value; }
        internal Rangs Rang { get => _Rang; set => _Rang = value; }
        internal Sex Sex { get => _Sex; set => _Sex = value; }
    }
}
