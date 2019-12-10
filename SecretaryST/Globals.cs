﻿using System;
using System.Collections.Generic;
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

            public const string StartProtocol = "Старт";

            public static readonly List<string> OriginalSheetNames = new List<string>()
            {
                Application, Options, Manager, Base, TechApplication, Extraction, Finish, Score, Protocol1, Protocol2, Protocol4
            };
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
            public const bool IsRandomStartOrder = true;
            public const bool ComputePersonNr = true;

            public const string OwnerOrganisation = "Какая-то проводящая организация";
            public const string CompeeteName = "Название соревнований";
            public static readonly string CompeeteDateStart = new DateTime().ToString(Globals.Strings.dateFormatString, Globals.Strings.dateFormatProvider);
            public static readonly string CompeeteDateEnd = new DateTime(year: new DateTime().Year, month: new DateTime().Month, day: new DateTime().Day + 3)
                .ToString(Globals.Strings.dateFormatString, Globals.Strings.dateFormatProvider);
            public const string CompeetePlace = "Санкт-Петербург";

            public static readonly DateTime Now = new DateTime();
            public static readonly DateTime FirstStartTime = new DateTime(Now.Year, Now.Month, Now.Day, hour: 10, minute: 0, second: 0);
            public static readonly DateTime StartInterval = new DateTime(Now.Year, Now.Month, Now.Day, hour: 0, minute: 2, second: 0);

            public static readonly List<String> startProtocolHeaders = new List<string>()
            {
                "nr", "name", "person-nr", "rang", "birth", "sex", "compeete_name", "delegation", "region", "chip-nr", "distance-rang", "start-time"
            };

            public static bool enableVisualEffects = false;
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

            public const string StartProtocol = "стартовый протокол";

            public static readonly Dictionary<string, string[]> StartProtocolHeaders = new Dictionary<string, string[]>()
            {
                { "nr", new string[2]{"№ п/п", "3,15"} },
                { "name", new string[2]{"Участник", "25"} },
                { "name-coop", new string[2]{"Состав", "25" } },
                { "person-nr", new string[2]{"Номер участника", "10" } },
                { "both-nr", new string[2]{"Связка", "10" } },
                { "group-nr", new string[2]{"Группа", "10" } },
                { "rang", new string[2]{"Разряд", "7" } },
                { "birth", new string[2]{"Год", "5" } },
                { "sex", new string[2]{"Пол", "5" } },
                { "compeete_name", new string[2]{"Зачет", "14" } },
                { "delegation", new string[2]{"Делегация", "30" } },
                { "region", new string[2]{"Территория", "20" } },
                { "chip-nr", new string[2]{"Номер чипа", "9" } },
                { "distance-rang",new string[2]{"Ранг", "6" } },
                { "start-time", new string[2]{"Время старта", "9" } },
            };

            public static readonly IFormatProvider dateFormatProvider = System.Globalization.CultureInfo.CreateSpecificCulture("ru-RU");
            public const string dateFormatString = "d MMM";
        }
    }
}
