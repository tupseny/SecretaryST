using SecretaryST.Enums;
using SecretaryST.Models;
using SecretaryST.Structs;
using System.Collections.Generic;
using Excel = Microsoft.Office.Tools.Excel;

namespace SecretaryST
{
    public partial class База
    {
        private const string sDataStartCell = "A2";

        //realative indexes of cols from start cell
        private const int iDelegationNumber = 1;
        private const int iDelegationName = 2;
        private const int iRegion = 3;
        private const int iOwner = 4;
        private const int iTechNumber = 4;
        private const int iNumInTeam = 5;
        private const int iTechNumber2 = 6;
        private const int iName = 7;
        private const int iBirth = 8;
        private const int iRang = 9;
        private const int iSex = 10;
        private const int iIsRecord = 11;
        private const int iChip = 12;
        private const int iIsPersonalGroup = 13;
        private const int iIsDoubleGroup = 14;
        private const int iIsFullGroup = 15;

        //current worksheet reference
        private static Excel.Worksheet oSheet;
        //list of all distances
        private static List<Distance> dbDict;
        //last row of data in DB
        private static int lastRow;

        //Getters and Settters
        public static int LastRow { get => lastRow; }
        internal static List<Distance> DbList { get => dbDict; }
        internal static void AddMany(IEnumerable<Distance> collection)
        {
            DbList.AddRange(collection);
        }
        internal static void AddOne(Distance item)
        {
            DbList.Add(item);
        }


        //Event methods
        private void Лист3_Startup(object sender, System.EventArgs e)
        {
            oSheet = this.Base;

            LoadDB();

            lastRow = oSheet.Range[sDataStartCell].Row;
        }

        private void Лист3_Shutdown(object sender, System.EventArgs e)
        {
        }


        #region Код, созданный конструктором VSTO

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(Лист3_Startup);
            this.Shutdown += new System.EventHandler(Лист3_Shutdown);
        }

        #endregion

        //PRIVATE methods
        private void LoadDB()
        {
            //todo: load all current entries from db into memory
            dbDict = new List<Distance>();
        }

        //INTERNAL methods
        internal static Distance GetOneDistance(DistanceGroupAmount amnt, DistanceLevels lvl, DistanceGroupType type)
        {
            Distance resultDist = new Distance(lvl);

            foreach (Distance d in DbList)
            {
                if (d.Level == lvl)
                {
                    GroupIndexAmountStruct[] aKeysTmp = new GroupIndexAmountStruct[d.Groups.Keys.Count];

                    int i = 0;
                    foreach (KeyValuePair<GroupIndexAmountStruct, DistanceGroup> kvItem in d.Groups)
                    {
                        if (kvItem.Key.Amnt == amnt && kvItem.Value.Type == type)
                        {
                            resultDist.AddGroup(kvItem.Key, kvItem.Value);
                        }
                        i++;
                    }
                }
            }

            return resultDist;
        }

        //public static void InsertAsModel(Dictionary<string, Distance> lModels)
        //{
        //    if (lModels is null)
        //    {
        //        throw new ArgumentNullException(nameof(lModels));
        //    }

        //    Dictionary<string, string> dItems = new Dictionary<string, string>();

        //    int iRow = 1;
        //    foreach (Distance oDistance in lModels.)
        //    {
        //        foreach (KeyValuePair<string, string> kvPair in Globals.Strings.StartProtocolHeaders)
        //        {
        //        //    { "nr", "№ п/п" },
        //        //{ "name", "Участник" },
        //        //{ "person-nr", "Номер участника" },
        //        //{ "rang", "Разряд" },
        //        //{ "birth", "Год" },
        //        //{ "sex", "Пол" },
        //        //{ "compeete_name", "Зачет" },
        //        //{ "delegation", "Делегация" },
        //        //{ "region", "Территория" },
        //        //{ "chip-nr", "Номер чипа" },
        //        //{ "distance-rang", "Ранг" },
        //        //{ "start-time", "Время старта" },

        //            string newKey = kvPair.Key;
        //            string newVal = "";

        //            switch (newKey)
        //            {
        //                case "nr":
        //                    newVal = iRow.ToString();
        //                    break;
        //                case "name":
        //                    newVal = oDistance.
        //            }
        //        }

        //        iRow++;
        //    }
        //}
    }
}
