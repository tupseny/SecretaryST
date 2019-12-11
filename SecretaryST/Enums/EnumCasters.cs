using System;

namespace SecretaryST.Enums
{
    class EnumCasters
    {

        public static DistanceLevels NumberToDistanceLevelType(int lvl)
        {
            switch (lvl)
            {
                case 1:
                    return DistanceLevels.I;
                case 2:
                    return DistanceLevels.II;
                case 3:
                    return DistanceLevels.III;
                case 4:
                    return DistanceLevels.IV;
                case 5:
                    return DistanceLevels.V;
                default:
                    throw new ArgumentException("invalid distance level", nameof(lvl));
            }
        }
        public static DistanceGroupType SexToGroupType(Sex s)
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

        public static int FromDistanceGroupAmount(DistanceGroupAmount am)
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


        public static Rangs CastToRangs(string s)
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

        public static Sex CastToSex(string s)
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

        public static string GroupAmountStringRepresent(DistanceGroupAmount amnt)
        {
            switch (amnt)
            {
                case DistanceGroupAmount.Four:
                    return "Группа (4)";
                case DistanceGroupAmount.One:
                    return "Личка";
                case DistanceGroupAmount.Six:
                    return "Группа (6)";
                case DistanceGroupAmount.Two:
                    return "Связка";
                default:
                    throw new ArgumentException("Not valid argument", nameof(amnt));
            }
        }

        public static string RangStringRepresent(Rangs rangs)
        {
            switch (rangs)
            {
                case Rangs.I:
                    return "1";
                case Rangs.II:
                    return "2";
                case Rangs.III:
                    return "3";
                case Rangs.KMS:
                    return "КМС";
                case Rangs.MS:
                    return "МС";
                default:
                    throw new ArgumentException("Not valid argument", nameof(rangs));
            }
        }

        public static string SexStringRepresent(Sex sexs)
        {
            switch (sexs)
            {
                case Sex.Female:
                    return "Ж";
                case Sex.Male:
                    return "М";
                case Sex.Undefined:
                    return "";
                default:
                    throw new ArgumentException("Not valid argument", nameof(sexs));
            }
        }

        public static string GroupTypeStringRepresent(DistanceGroupType val)
        {
            switch (val)
            {
                case DistanceGroupType.Both:
                    return "МЖ";
                case DistanceGroupType.Female:
                    return "Ж";
                case DistanceGroupType.Male:
                    return "М";
                default:
                    throw new ArgumentException("Not valid argument", nameof(val));
            }
        }
    }
}
