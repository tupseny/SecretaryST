using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using SecretaryST.Models;
using Excel = Microsoft.Office.Tools.Excel;
using ExcelInterop = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

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
        //all DB entries
        private static List<DatabaseEntry> dbList;
        //last row of data in DB
        private static int lastRow;

        public static int LastRow { get => lastRow; }

        private void LoadDB()
        {
            //todo: load all current entries from db into memory
            dbList = new List<DatabaseEntry>();
        }

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

    }
}
