using SecretaryST.Enums;
using SecretaryST.Models;
using System;
using System.Collections.Generic;
using ExcelInter = Microsoft.Office.Interop.Excel;

namespace SecretaryST.SheetGenerators
{
    class StartProtocolGenerator : GeneratorAbstract
    {
        //class variables
        private readonly DistanceGroupAmount grAmount;
        private List<string> lHeaders;
        private StartTimer timer;

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

        private const double dHeaderRowHeight = 26;
        private const double dDataRowHeight = 12;

        //constructors
        public StartProtocolGenerator(DistanceGroupAmount type, StartTimer timer)
        {
            this.grAmount = type;
            this.LHeaders = Globals.Options.startProtocolHeaders1;
            this.timer = timer;

            string typeRepresent = EnumCasters.GroupAmountStringRepresent(GrAmount);
            SheetName = Globals.SheetNames.StartProtocol + " (" + typeRepresent + ")";
        }


        //Getters & Setters
        public DistanceGroupAmount GrAmount { get => grAmount; }
        public List<string> LHeaders { get => lHeaders; set => lHeaders = value; }


        //Public methods
        public override void Create(Distance distance, string suffix = "")
        {
            //enable permormance mode.
            PerformanceMode(true);

            //Create new sheet with name and save reference into variable
            AddSheet(suffix: suffix);

            //build start protocol structure, formate and insert data
            BuildStructure(distance);

            //disable permormance mode
            PerformanceMode(false);
        }

        //private methods
        private void BuildStructure(Distance distance)
        {
            List<string> headers = this.LHeaders;
            //Microsoft.Office.Interop.Excel.Range shRange = base.OSheet.Range;

            PageSetup();

            GenHead(headers.Count);
            int n = GenBody(headers);
            GenFooter(n);

            void PageSetup()
            {
                OSheet.PageSetup.Orientation = ExcelInter.XlPageOrientation.xlLandscape;
                OSheet.PageSetup.Zoom = false;
                OSheet.PageSetup.FitToPagesWide = 1;
                OSheet.PageSetup.FitToPagesTall = 2;
            }
            void GenHead(int width)
            {
                //owner organisation
                HeadTitle(sOwnerOrganisation, 3, Globals.Options.OwnerOrganisation, cellHeight: 42);

                //compeete name
                RangeFormatter fTmp = HeadTitle(sCompeeteName, 2, Globals.Options.CompeeteName, bold: true, cellHeight: 39);
                fTmp.Border(doubleLine: true, bot: true);

                //protocol title
                HeadTitle(sProtocolTitle, 1, Globals.Strings.StartProtocol, bold: true, cellHeight: 25);

                //distance name
                HeadTitle(sDistanceName, 2, Globals.Strings.Dist1Name, bold: true, underline: true, cellHeight: 40);

                //date prompt
                string sDate = Globals.Options.CompeeteDateStart + " - " + Globals.Options.CompeeteDateEnd;
                HeadPrompt(sDate);

                //place prompt
                string sPlace = Globals.Options.CompeetePlace;
                HeadPrompt(sPlace, end: true);


                RangeFormatter HeadTitle(string startCell, int headerLvl, string val, double cellHeight, bool bold = false, bool underline = false)
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

                    fRange.SetRowHeight(cellHeight);

                    return fRange;
                }

                RangeFormatter HeadPrompt(string val, bool end = false)
                {
                    const double cellHeight = 13.5;
                    int cellOffset = end ? width - 1 : 0;

                    RangeFormatter fRange = new RangeFormatter(base.OSheet.Range[sCompeeteDatePrompt].Offset[ColumnOffset: cellOffset]);

                    if (end) { fRange.HorizontalRightAlignment(); }
                    else { fRange.HorizontalLeftAlignment(); }

                    fRange.Cursive(true);
                    fRange.TextH3();

                    fRange.SetRowHeight(cellHeight);

                    fRange.Range.Value = val;
                    return fRange;
                }
            }
            int GenBody(List<string> lHeaders)
            {
                Header();

                //return number of data inserted
                return Data(distance);

                int Data(Distance data)
                {
                    int nInserted = 0;

                    List<Dictionary<string, string>> lData = data.GetStringRepresentList(timer);
                    ExcelInter.Range rn = OSheet.Range[sTableDataFirst];

                    int iRow = 0;
                    foreach (Dictionary<string, string> dictRow in lData)
                    {
                        new RangeFormatter(rn.Offset[RowOffset: iRow]).SetRowHeightAsContent();

                        int iCol = 0;
                        foreach (string key in this.LHeaders)
                        {
                            DataFormatInsert();

                            iCol++;

                            void DataFormatInsert()
                            {
                                RangeFormatter fRange = new RangeFormatter(rn.Offset[RowOffset: iRow, ColumnOffset: iCol]);
                            
                                fRange.HorizontalCenterAlignment();
                                fRange.VerticalCenterAlignment();
                                fRange.TextH3();
                                fRange.Border(top: true, bot: true, left: true, right: true);
                                
                                fRange.Range.Value = dictRow[key];
                            }
                        }

                        iRow++;
                        nInserted++;
                    }

                    return nInserted;
                }
                void Header()
                {
                    new RangeFormatter(OSheet.Range[sTableHeader]).SetRowHeight(dHeaderRowHeight);

                    int i = 1;
                    foreach (string key in lHeaders)
                    {
                        HeaderItem(i, Globals.Strings.StartProtocolHeaders[key][0], double.Parse(Globals.Strings.StartProtocolHeaders[key][1]));

                        i++;
                    }

                    void HeaderItem(int iCol, string val, double colWidth)
                    {
                        RangeFormatter fRange = new RangeFormatter(base.OSheet.Range[sTableHeader].Offset[ColumnOffset: iCol - 1]);

                        fRange.SetColWidth(colWidth);

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
            void GenFooter(int dataCount)
            {
                RangeFormatter fRange = new RangeFormatter(base.OSheet.Range[sFooter].Offset[RowOffset: dataCount]);

                fRange.TextH2();
                fRange.HorizontalLeftAlignment();
                fRange.VerticalCenterAlignment();

                fRange.Range.Value = "Главный секретарь _____________________ /И. И. Иванова, СС1К, г. Урюпинск/";
            }

            //todo: resize column width
        }
    }
}
