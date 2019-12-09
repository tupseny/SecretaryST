using SecretaryST.Enums;
using System;
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
        private const string sFooter = "A8";

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
            //PerformanceMode(true);

            //Create new sheet with name and save reference into variable
            AddSheet();

            //build start protocol structure, formate and insert data
            BuildStructure();

            //disable permormance mode
            //PerformanceMode(false);
        }

        //private methods
        private void BuildStructure()
        {
            List<string> headers = Globals.Options.startProtocolHeaders;
            //Microsoft.Office.Interop.Excel.Range shRange = base.OSheet.Range;

            GenHead(headers.Count);
            int n = GenBody(headers);
            GenFooter(n);

            void GenHead(int width)
            {
                //owner organisation
                HeadTitle(sOwnerOrganisation, 3, Globals.Options.OwnerOrganisation);

                //compeete name
                RangeFormatter fTmp = HeadTitle(sCompeeteName, 2, Globals.Options.CompeeteName, bold: true);
                fTmp.Border(doubleLine: true, bot: true);

                //protocol title
                HeadTitle(sProtocolTitle, 1, Globals.Strings.StartProtocol, bold: true);

                //distance name
                HeadTitle(sDistanceName, 2, Globals.Strings.Dist1Name, bold: true, underline: true);

                //date prompt
                string sDate = Globals.Options.CompeeteDateStart + " - " + Globals.Options.CompeeteDateEnd;
                HeadPrompt(sCompeeteDatePrompt, sDate);

                //place prompt
                string sPlace = Globals.Options.CompeetePlace;
                HeadPrompt(sCompeeteDatePrompt, sPlace, end: true);


                RangeFormatter HeadTitle(string startCell, int headerLvl, string val, bool bold = false, bool underline = false)
                {
                    RangeFormatter fRange = new RangeFormatter(base.OSheet.Range[startCell].Resize[ColumnSize: width]);

                    fRange.Merge();
                    fRange.HorizontalCenterAlignment();
                    fRange.VerticalCenterAlignment();
                    fRange.Bold(bold);
                    fRange.Underline(underline);

                    switch (headerLvl)
                    {
                        case 1:
                            fRange.TextH1();
                            break;
                        case 2:
                            fRange.TextH2();
                            break;
                        case 3:
                            fRange.TextH3();
                            break;
                        default:
                            throw new ArgumentException("Not valid header level", nameof(headerLvl));
                    }

                    fRange.Range.Value = val.ToUpper(System.Globalization.CultureInfo.CurrentCulture);
                    return fRange;
                }

                RangeFormatter HeadPrompt(string startCell, string val, bool end = false)
                {
                    int cellOffset = end ? width - 1 : 0;

                    RangeFormatter fRange = new RangeFormatter(base.OSheet.Range[sCompeeteDatePrompt].Offset[ColumnOffset: cellOffset]);

                    if (end) { fRange.HorizontalRightAlignment(); }
                    else { fRange.HorizontalLeftAlignment(); }

                    fRange.Cursive(true);
                    fRange.TextH3();

                    fRange.Range.Value = val;
                    return fRange;
                }
            }
            int GenBody(List<string> lHeaders)
            {
                Header();

                return 0;

                void Header()
                {
                    int i = 1;
                    foreach (string key in lHeaders)
                    {
                        HeaderItem(i, Globals.Strings.StartProtocolHeaders[key]);

                        i++;
                    }

                    void HeaderItem(int iCol, string val)
                    {
                        RangeFormatter fRange = new RangeFormatter(base.OSheet.Range[sTableHeader].Offset[ColumnOffset: iCol - 1]);

                        fRange.Bold(true);
                        fRange.HorizontalCenterAlignment();
                        fRange.VerticalBottomAlignment();
                        fRange.TextH3();
                        fRange.WrapText();
                        fRange.Border(top: true, bot: true, left: true, right: true);
                        fRange.FillColor();

                        fRange.Range.Value = val;
                    }
                }
            }
            void GenFooter(int dataSize)
            {
                RangeFormatter fRange = new RangeFormatter(base.OSheet.Range[sFooter].Offset[RowOffset: dataSize]);

                fRange.TextH2();
                fRange.HorizontalLeftAlignment();
                fRange.VerticalCenterAlignment();

                fRange.Range.Value = "Главный секретарь _____________________ /И. И. Иванова, СС1К, г. Урюпинск/";
            }

            //todo: resize column width
        }
    }
}
