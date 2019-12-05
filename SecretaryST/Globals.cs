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
    }
}
