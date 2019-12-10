using SecretaryST.Models;
using System;
using ExcelInter = Microsoft.Office.Interop.Excel;

namespace SecretaryST.SheetGenerators
{
    abstract class GeneratorAbstract
    {
        private readonly Microsoft.Office.Tools.Excel.Workbook oWorkbook;
        private readonly ExcelInter._Application app;

        private string sheetName;
        private ExcelInter.Worksheet oSheet;

        protected GeneratorAbstract()
        {
            this.oWorkbook = Globals.ThisWorkbook.Base;
            this.app = oWorkbook.Application;
        }

        //Getter & Setters
        protected ExcelInter.Worksheet OSheet { get => oSheet; set => oSheet = value; }
        protected ExcelInter._Application App { get => app; }
        protected Microsoft.Office.Tools.Excel.Workbook OWorkbook { get => oWorkbook; }
        protected string SheetName { get => sheetName; set => sheetName = value; }

        //Protected Methods
        protected void PerformanceMode(bool activate)
        {
            this.App.ScreenUpdating = Globals.Options.enableVisualEffects ? true : !activate;
            this.App.Calculation = activate ? ExcelInter.XlCalculation.xlCalculationManual : ExcelInter.XlCalculation.xlCalculationAutomatic;
            this.App.EnableEvents = !activate;
            this.App.StatusBar = !activate;
        }

        protected void AddSheet(string suffix = "")
        {
            Globals.ThisWorkbook.Worksheets.Add(After: Globals.ThisWorkbook.Worksheets[Globals.ThisWorkbook.Worksheets.Count]);
            ExcelInter.Worksheet sh = (ExcelInter.Worksheet)Globals.ThisWorkbook.Worksheets[Globals.ThisWorkbook.Worksheets.Count];

            if (SheetName is null)
            {
                throw new InvalidOperationException("Sheet name not initialized");
            }

            string name = SheetName + "_" + suffix;

            if (SheetExists(name, out ExcelInter.Worksheet sheet))
            {
                sheet.Delete();
            }

            sh.Name = name;
            oSheet = sh;
        }

        protected bool SheetExists(string sheetName, out ExcelInter.Worksheet sheet)
        {
            foreach (ExcelInter.Worksheet item in Globals.ThisWorkbook.Worksheets)
            {
                if (item.Name == sheetName)
                {
                    sheet = item;
                    return true;
                }
            }
            sheet = null;
            return false;
        }

        //Abstract Methods
        abstract public void Create(Distance distance, string suffix = "");
    }
}
