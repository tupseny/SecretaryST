using System;
using Ex = Microsoft.Office.Tools.Excel;

namespace SecretaryST
{
    internal sealed partial class Globals
    {


        //_______________________________________________
        //            |                     |
        //   >--------|     SHEET NAMES     |--------<
        //____________|_____________________|____________
#pragma warning disable CA1034 // Вложенные типы не должны быть видимыми
        public static class SheetNames
#pragma warning restore CA1034 // Вложенные типы не должны быть видимыми
        {
            public const string Application = "Заявка";
            public const string Options = "Настройка";
            public const string Manager = "Управление";
            public const string Base = "База";
            public const string TechApplication = "Тех.заявка";
            public const string Extraction = "Выписка";
            public const string Protocol1 = "Протокол_личка";
            public const string Protocol2 = "Протокол_связки";
            public const string Protocol4 = "Протокол_группа";
            public const string Finish = "Финишнка";
            public const string Score = "Очки";

            public const string StartProtocol = "Старт.протокол";
        }

        //_________________________________________________
        //            |                       |
        //   >--------|     SHEET OBJECTS     |--------<
        //____________|_______________________|____________
#pragma warning disable CA1034 // Вложенные типы не должны быть видимыми
        public static class Sheets
#pragma warning restore CA1034 // Вложенные типы не должны быть видимыми
        {
            public static Ex.Worksheet Application { get; set; }
            public static Ex.Worksheet Options { get; set; }
            public static Ex.Worksheet Manager { get; set; }
            public static Ex.Worksheet Base { get; set; }
            public static Ex.Worksheet TechApplication { get; set; }
            public static Ex.Worksheet Extraction { get; set; }
            public static Ex.Worksheet Protocol1 { get; set; }
            public static Ex.Worksheet Protocol2 { get; set; }
            public static Ex.Worksheet Protocol4 { get; set; }
            public static Ex.Worksheet Finish { get; set; }
            public static Ex.Worksheet Score { get; set; }
        }

        //_________________________________________________
        //            |                       |
        //   >--------|        OPTIONS        |--------<
        //____________|_______________________|____________
        public static class Options
        {
            public const bool ShowStartTime = true;
            public const bool IsRandomStartOrder = true;

            public static readonly DateTime Now = new DateTime();
            public static readonly DateTime FirstStartTime = new DateTime(Now.Year, Now.Month, Now.Day, hour: 10, minute: 0, second: 0);
            public static readonly DateTime StartInterval = new DateTime(Now.Year, Now.Month, Now.Day, hour: 0, minute: 2, second: 0);

        }


        //_________________________________________________
        //            |                       |
        //   >--------|        STRINGS        |--------<
        //____________|_______________________|____________
        public static class Strings
        {
            public const string Dist1Name = "дистанция - пешеходная";
            public const string Dist1NameShort = "ЛИЧКА";

            public const string Dist2Name = "дистанция - пешеходная - связка";
            public const string Dist2NameShort = "СВЯЗКИ";

            public const string Dist3Name = "дистанция - пешеходная - группа";
            public const string Dist3NameShort = "ГРУППА";

            
        }
    }
}
