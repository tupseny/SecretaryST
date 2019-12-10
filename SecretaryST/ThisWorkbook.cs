using SecretaryST.Enums;
using SecretaryST.Models;
using SecretaryST.SheetGenerators;
using System.Collections.Generic;
using ExcelInter = Microsoft.Office.Interop.Excel;

namespace SecretaryST
{
    public partial class ThisWorkbook
    {
        private void ThisWorkbook_Startup(object sender, System.EventArgs e)
        {
        }

        private void ThisWorkbook_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region Код, созданный конструктором VSTO

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisWorkbook_Startup);
            this.Shutdown += new System.EventHandler(ThisWorkbook_Shutdown);
        }

        #endregion

        public static void StartProtocol1Generate()
        {
            DistanceGroupAmount amnt = DistanceGroupAmount.One;

            //all distances
            List<Distance> lDistances = База.DbList;

            //get all protocol variants
            Dictionary<DistanceLevels, List<DistanceGroupType>> lVariants = new Dictionary<DistanceLevels, List<DistanceGroupType>>();
            foreach (Distance d in lDistances)
            {
                DistanceLevels level = d.Level;
                if (!lVariants.ContainsKey(level))
                {
                    lVariants.Add(level, new List<DistanceGroupType>());
                }

                foreach (KeyValuePair<Structs.GroupIndexAmountStruct, DistanceGroup> kvPair in d.Groups)
                {
                    if (!lVariants[level].Contains(kvPair.Value.Type))
                    {
                        lVariants[level].Add(kvPair.Value.Type);
                    }
                }
            }

            //generate protocol for each distance type
            foreach (KeyValuePair<DistanceLevels, List<DistanceGroupType>> kvPair in lVariants)
            {
                foreach (DistanceGroupType type in kvPair.Value)
                {
                    Distance distance = База.GetOneDistance(amnt, kvPair.Key, type);

                    if (distance.Groups.Count > 0)
                    {
                        string nameSuffix = kvPair.Key.ToString() + "_" + EnumCasters.GroupTypeStringRepresent(type);

                        StartProtocolGenerator generator = new StartProtocolGenerator(amnt);
                        generator.Create(distance, suffix: nameSuffix);
                    }
                }
            }
        }

        public static void RemoveOtherSheets()
        {
            List<ExcelInter.Worksheet> toDelete = new List<ExcelInter.Worksheet>();

            foreach (ExcelInter.Worksheet sh in Globals.ThisWorkbook.Worksheets)
            {
                if (!Globals.SheetNames.OriginalSheetNames.Contains(sh.Name))
                {
                    toDelete.Add(sh);
                }
            }


            if (AlertBoxes.SureDeleteAllSheetAlert() == System.Windows.Forms.DialogResult.Yes)
            {
                Globals.ThisWorkbook.Application.DisplayAlerts = false;
                toDelete.ForEach(sh => sh.Delete());
                Globals.ThisWorkbook.Application.DisplayAlerts = true;
            }
        }
    }
}
