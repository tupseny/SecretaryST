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
#pragma warning disable IDE0051 // Удалите неиспользуемые закрытые члены
        private const int iAgent = 2;
#pragma warning restore IDE0051 // Удалите неиспользуемые закрытые члены
        private const int iName = 3;
        private const int iBirth = 4;
        private const int iRang = 5;
        private const int iSex = 6;
#pragma warning disable IDE0051 // Удалите неиспользуемые закрытые члены
        private const int iGroup = 7;
#pragma warning restore IDE0051 // Удалите неиспользуемые закрытые члены
        private const int iDistanceLevel = 8;
#pragma warning disable IDE0051 // Удалите неиспользуемые закрытые члены
        private const int iChipNum = 9;
#pragma warning restore IDE0051 // Удалите неиспользуемые закрытые члены
#pragma warning disable IDE0051 // Удалите неиспользуемые закрытые члены
        private const int iDistancePerson = 10;
#pragma warning restore IDE0051 // Удалите неиспользуемые закрытые члены
#pragma warning disable IDE0051 // Удалите неиспользуемые закрытые члены
        private const int iDistanceDouble = 11;
#pragma warning restore IDE0051 // Удалите неиспользуемые закрытые члены
        private const int iGroupDoubleIndex = 12;
        private const int iGroupFourIndex = 13;

        private const string sDataCellStart = "B2";
        private const int iDataRowStart = 2;

        private const int nDataCols = 14;
        private const int nDataRows = 100;

#pragma warning disable IDE0052 // Удалить непрочитанные закрытые члены
        private static int nPeople;
#pragma warning restore IDE0052 // Удалить непрочитанные закрытые члены
        private static List<List<object>> lData;
        private static List<Distance> lDistances;

        private static bool inProgress = false;

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
            // If the proccess already started then just exit
            if (inProgress)
            {
                return;
            }

            InWork(true);

            // List of distances. All new created distances and their link swill be added here
            lDistances = new List<Distance>();

            //try-catch. Get data from list. If there is some error then show alert msg to user
            try
            {
                GetData();
            }
            catch (Exception)
            {
                throw;
            }

            //convert gotten data to models. If there is some error then show alert msg to user
            try
            {
                ConvertDataToModels();

                //methods finished successfuly
                AlertBoxes.AlertMsg("ГОТОВО!");
            }
            catch (GroupFullException e)
            //If group is already full but user wants add new person
            {
                AlertBoxes.GroupFullAlert(e.GroupIndexAmount);
            }
            catch (InvalidFieldTypeException e)
            //If field type is incorrect. For example, in the field "group index" is written not numbers
            {
                //get the cell where the field is incorrect
                ExcelInterop.Range rng = oSheet.Range[sDataCellStart].Offset[e.IRow, e.ICol];

                //select this cell
                rng.Activate();

                //show alert message to user
                string cellName = "[строка - " + rng.Row + ", столбец - " + rng.Column + "]";
                AlertBoxes.FieldTypeAlert(requiredType: e.RequiredType, cell: cellName);
            }
            catch (GroupNotFullException e)
            //If some group is not full
            {
                AlertBoxes.GroupNotFullalert(e.StructGroupIndex.GroupIndex, e.StructGroupIndex.Amnt);
            }

            InWork(false);

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
            //Check if data got
            if (lData is null)
            {
#pragma warning disable CA1303 // Не передавать литералы в качестве локализованных параметров
                throw new InvalidOperationException("Data is not set");
#pragma warning restore CA1303 // Не передавать литералы в качестве локализованных параметров
            }

            // Dictionary contains groups. Keys are group's index entered by user
            Dictionary<GroupIndexAmountStruct, DistanceGroup> DictGroups = new Dictionary<GroupIndexAmountStruct, DistanceGroup>();

            int iRow = 0;
            lData.ForEach((row) =>
            {
                try
                {
                    Person person = new Person(
                        name: Utils.ReadStringValue(row, iName),
                        birth: Utils.ReadDateTimeValue(row, iBirth),
                        region: Utils.ReadStringValue(row, iRegion),
                        delegation: Utils.ReadStringValue(row, iDelegation),
                        rang: EnumCasters.CastToRangs(Utils.ReadStringValue(row, iRang)),
                        sex: EnumCasters.CastToSex(Utils.ReadStringValue(row, iSex))
                    );

                    int i2 = Utils.ReadIntValue(row, iGroupDoubleIndex);
                    int i4 = Utils.ReadIntValue(row, iGroupFourIndex);

                    DistanceLevels level = EnumCasters.NumberToDistanceLevelType(Utils.ReadIntValue(row, iDistanceLevel));

                    if (i2 != 0)
                    {
                        linkPersonWithDistances(person, new GroupIndexAmountStruct(i2, DistanceGroupAmount.Two), level);
                    }

                    if (i4 != 0)
                    {
                        linkPersonWithDistances(person, new GroupIndexAmountStruct(i4, DistanceGroupAmount.Four), level);
                    }

                }
                catch (InvalidFieldTypeException e)
                {
                    e.IRow = iRow;
#pragma warning disable CA2200 // Повторно порождайте исключения для сохранения сведений стека.
                    throw e;
#pragma warning restore CA2200 // Повторно порождайте исключения для сохранения сведений стека.
                }

                iRow++;
            });

            checkIfEachGroupIsFull();

            //add persons in groups and then to distance entity
            void linkPersonWithDistances(Person prsn, GroupIndexAmountStruct groupIndexAmountData, DistanceLevels level)
            {
                try
                {
                    if (existDistance(level, out Distance distance))
                    {
                        linkPerson(distance);
                    }
                    else
                    {
                        Distance tmpDistance = new Distance(level);
                        linkPerson(tmpDistance);

                        lDistances.Add(tmpDistance);
                    }
                }
                catch (Exceptions.GroupFullException)
                {
                    throw new Exceptions.GroupFullException(groupIndexAmountData);
                }

                void linkPerson(Distance dist)
                {
                    // If group already exists then just add to it new member. Else create new group
                    if (dist.Groups.TryGetValue(key: groupIndexAmountData, value: out DistanceGroup foundGroup))
                    {
                        foundGroup.AddMember(prsn);
                    }
                    else
                    {
                        DistanceGroup grp = new DistanceGroup(amount: groupIndexAmountData.Amnt);
                        grp.AddMember(prsn);
                        dist.AddGroup(groupIndexAmount: groupIndexAmountData, grp: grp);
                    }
                }

                bool existDistance(DistanceLevels lvl, out Distance distance)
                {
                    foreach (Distance d in lDistances)
                    {
                        if (d.Level == lvl)
                        {
                            distance = d;
                            return true;
                        }
                    }

                    distance = null;
                    return false;
                }
            }

            void checkIfEachGroupIsFull()
            {
                foreach (Distance d in lDistances)
                {
                    foreach (KeyValuePair<GroupIndexAmountStruct, DistanceGroup> kvGroups in d.Groups)
                    {
                        DistanceGroup gr = kvGroups.Value;
                        if (!gr.IsFull())
                        {
                            throw new GroupNotFullException(kvGroups.Key);
                        }
                    }
                }
            }
        }

        //Change inWork status
        private static void InWork(bool status)
        {
            inProgress = status;
        }

    }
}
