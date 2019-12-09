using Microsoft.Office.Tools.Excel;
using ExcelInter = Microsoft.Office.Interop.Excel;
using System;
using SecretaryST.Enums;
using System.Collections.Generic;

namespace SecretaryST.SheetGenerators
{
    abstract class GeneratorAbstract
    {
        private readonly Microsoft.Office.Tools.Excel.Workbook oWorkbook;
        private readonly ExcelInter._Application app;

        private string sheetName;
        private Worksheet oSheet;
        

        protected GeneratorAbstract()
        {
            this.oWorkbook = Globals.ThisWorkbook.Base;
            this.app = oWorkbook.Application;
        }

        //Getter & Setters
        protected Worksheet OSheet { get => oSheet; set => oSheet = value; }
        protected ExcelInter._Application App { get => app; }
        protected Microsoft.Office.Tools.Excel.Workbook OWorkbook { get => oWorkbook; }
        protected string SheetName { get => sheetName; set => sheetName = value; }

        //Protected Methods
        protected void PerformanceMode(bool activate)
        {
            this.App.ScreenUpdating = !activate;
            this.App.Calculation = activate ? ExcelInter.XlCalculation.xlCalculationManual : ExcelInter.XlCalculation.xlCalculationAutomatic;
            this.App.EnableEvents = !activate;
            this.App.StatusBar = !activate;
        }

        protected void AddSheet()
        {
            Worksheet sh = OWorkbook.Worksheets.Add(After: oWorkbook.Worksheets[oWorkbook.Worksheets.Count]);

            if (SheetName is null)
            {
                throw new InvalidOperationException("Sheet name not initialized");
            }

            sh.Name = SheetName;

            oSheet = sh;
        }

        //Abstract Methods
        abstract public void Create(List<Dictionary<string, object>> data);
    }
}
