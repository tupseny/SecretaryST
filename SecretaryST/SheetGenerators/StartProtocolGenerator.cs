using Microsoft.Office.Tools.Excel;
using ExcelI = Microsoft.Office.Interop.Excel;
using SecretaryST.Enums;
using System.Collections.Generic;

namespace SecretaryST.SheetGenerators
{
    class StartProtocolGenerator : GeneratorAbstract
    {
        //class variables
        private readonly DistanceGroupAmount grAmount;

        //class consts
        private const string sOwnerOrganisation = "A1";
        private const string sCompeeteName = "A2";
        private const string sCompeeteDatePrompt = "A3";
        private const string sProtocolTitle = "A4";
        private const string sDistanceName = "A5";
        private const string sTableHeader = "A6";
        private const string sTableDataFirst = "A7";

        private const int nOffsetAfterTable = 1;

        //constructors
        public StartProtocolGenerator(DistanceGroupAmount type)
        {
            this.grAmount = type;

            string typeRepresent = EnumCasters.GroupAmountStringRepresent(GrAmount);
            SheetName = Globals.SheetNames.StartProtocol + " (" + typeRepresent + ")";
        }

        //Getters & Setters
        public DistanceGroupAmount GrAmount { get => grAmount; }

        //Public methods
        public override void Create(List<Dictionary<string, object>> data)
        {
            //enable permormance mode.
            PerformanceMode(true);

            //Create new sheet with name and save reference into variable
            AddSheet();

            //build start protocol structure and formation
            BuildStructure();

            //insert data into sheet
            InsertData();

            //disable permormance mode
            PerformanceMode(false);
        }

        //private methods
        private void BuildStructure()
        {
            List<string> headers = Globals.Options.startProtocolHeaders;
            Worksheet_RangeType shRange = base.OSheet.Range;

            switch (grAmount)
            {
                case DistanceGroupAmount.One:
                    GenHead(headers.Count);
                    break;
            }

            void GenHead(int width)
            {
                //owner organisation
                RangeFormatter fRange = new RangeFormatter(shRange[sOwnerOrganisation].Resize[ColumnSize: width]);
                fRange.Merge();
                fRange.HorizontalCenterAlignment();
                fRange.VerticalCenterAlignment();
                fRange.TextH3();
                fRange.Range.Value = Globals.Options.OwnerOrganisation;
                
                //
            }
        }

        private void InsertData()
        {

        }
    }
}
