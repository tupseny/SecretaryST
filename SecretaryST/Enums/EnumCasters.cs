using System;

namespace SecretaryST.Enums
{
    class EnumCasters
    {
        public static DistanceGroupType sexToGroupType(Sex s)
        {
            switch (s)
            {
                case Sex.Female:
                    return DistanceGroupType.Female;
                case Sex.Male:
                    return DistanceGroupType.Male;
                default:
                    throw new ArgumentException("invalid sex", nameof(s));
            }
        }

        public static int fromDistanceGroupAmount(DistanceGroupAmount am)
        {
            switch (am)
            {
                case DistanceGroupAmount.One:
                    return 1;
                case DistanceGroupAmount.Two:
                    return 2;
                case DistanceGroupAmount.Four:
                    return 4;
                case DistanceGroupAmount.Six:
                    return 6;
                default:
                    return 0;
            }
        }

        public static Rangs castToRangs(string s)
        {
            switch (s.ToLower())
            {
                case "1":
                    return Rangs.I;
                case "2":
                    return Rangs.II;
                case "3":
                    return Rangs.III;
                case "kms":
                    return Rangs.KMS;
                case "ms":
                    return Rangs.MS;
                case "кмс":
                    return Rangs.KMS;
                case "мс":
                    return Rangs.MS;
                default:
                    throw new ArgumentException("Not valid argument", nameof(s));
            }
        }

        public static Sex castToSex(string s)
        {
            switch (s.ToLower())
            {
                case "m":
                    return Sex.Male;
                case "male":
                    return Sex.Male;
                case "м":
                    return Sex.Male;
                case "f":
                    return Sex.Female;
                case "female":
                    return Sex.Female;
                case "ж":
                    return Sex.Female;
                default:
                    throw new ArgumentException("Not valid argument", nameof(s));
            }
        }
    }
}
