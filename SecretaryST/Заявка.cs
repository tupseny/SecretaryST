using SecretaryST.Enums;
using SecretaryST.Exceptions;
using SecretaryST.Models;
using SecretaryST.Structs;
using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Tools.Excel;
using ExcelInterop = Microsoft.Office.Interop.Excel;

namespace SecretaryST
{
    public partial class Заявка
    {
        private const int iDelegation = 0;
        private const int iRegion = 1;
        private const int iAgent = 2;
        private const int iName = 3;
        private const int iBirth = 4;
        private const int iRang = 5;
        private const int iSex = 6;
        private const int iGroup = 7;
        private const int iDistanceLevel = 8;
        private const int iChipNum = 9;
        private const int iDistancePerson = 10;
        private const int iDistanceDouble = 11;
        private const int iGroupDoubleIndex = 12;
        private const int iGroupFourIndex = 13;

        private const string sDataCellStart = "B2";
        private const int iDataRowStart = 2;

        private const int nDataCols = 14;

        private static int nDataRows = 100;
        private static int nPeople;
        private static List<List<object>> lData;


        static Excel.Worksheet oSheet;


        private void Лист1_Startup(object sender, System.EventArgs e)
        {
            oSheet = this.Base;
            Globals.Sheets.Application = this.Base;
        }

        private void Лист1_Shutdown(object sender, System.EventArgs e)
        {
        }



        #region Код, созданный конструктором VSTO

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(Лист1_Startup);
            this.Shutdown += new System.EventHandler(Лист1_Shutdown);
        }

        #endregion

        internal static void ImportToBase()
        {
            try
            {
                GetData();
            }
            catch (Exception)
            {
                throw;
            }

            try
            {
                ConvertDataToModels();
            }
            catch (GroupFullException e)
            {
                Utils.AlertMsg("Ошибка", "Группа (кол-во членов - '" + e.GroupIndexAmount.Amnt + "') номер - '" + e.GroupIndexAmount.GroupIndex + "' уже полная");
            }

        }

        private static void GetData()
        {
            int nRows = iDataRowStart + nDataRows;
            ExcelInterop.Range dataRng = oSheet.Range[sDataCellStart].Resize[nRows, nDataCols];

            lData = Utils.GetValues(dataRng);
            nPeople = lData.Count;
        }

        private static void ConvertDataToModels()
        {
            //Check if lData is null
            if (lData is null)
            {
                throw new InvalidOperationException("Data is not set");
            }

            // Dictionary contains groups. Keys are group's index entered by user
            Dictionary<GroupIndexAmountStruct, DistanceGroup> DictGroups = new Dictionary<GroupIndexAmountStruct, DistanceGroup>();

            lData.ForEach(row =>
            {
                Person person = new Person(
                    name: Utils.ReadStringValue(row[iName]),
                    birth: Utils.ReadDateTimeValue(row[iBirth]),
                    region: Utils.ReadStringValue(row[iRegion]),
                    delegation: Utils.ReadStringValue(row[iDelegation]),
                    rang: EnumCasters.castToRangs(Utils.ReadStringValue(row[iRang])),
                    sex: EnumCasters.castToSex(Utils.ReadStringValue(row[iSex]))
                );

                int i2 = Utils.ReadIntValue(row[iGroupDoubleIndex]);
                int i4 = Utils.ReadIntValue(row[iGroupFourIndex]);

                if (i2 != null)
                {
                    linkPersonWithDistances(person, new GroupIndexAmountStruct(i2, DistanceGroupAmount.Two));
                }

                if (i4 != null)
                {
                    linkPersonWithDistances(person, new GroupIndexAmountStruct(i4, DistanceGroupAmount.Four));
                }

            });

            // todo: Check if each player has friend

            void linkPersonWithDistances(Person prsn, GroupIndexAmountStruct groupIndexAmountData)
            {
                try
                {
                    // If group already exists then just add to it new member. Else create new group
                    if (DictGroups.TryGetValue(key: groupIndexAmountData, value: out DistanceGroup foundGroup))
                    {
                        foundGroup.addMember(prsn);
                    }
                    else
                    {
                        DistanceGroup grp = new DistanceGroup(amount: groupIndexAmountData.Amnt);
                        grp.addMember(prsn);
                        DictGroups.Add(key: groupIndexAmountData, value: grp);
                    }
                }
                catch (Exceptions.GroupFullException)
                {
                    throw new Exceptions.GroupFullException(groupIndexAmountData);
                }
            }



        }

    }
}
