using Microsoft.Office.Interop.Excel;
using ExcelI = Microsoft.Office.Interop.Excel;

namespace SecretaryST
{
    class RangeFormatter
    {
        private const int h1Size = 16;
        private const int h2Size = 12;
        private const int h3Size = 10;

        private readonly ExcelI.Range range;

        public Range Range => range;

        public RangeFormatter(ExcelI.Range range)
        {
            this.range = range;
        }

        public void Merge()
        {
            Range.Merge();
        }

        public void HorizontalCenterAlignment()
        {
            Range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
        }

        public void HorizontalLeftAlignment()
        {
            Range.HorizontalAlignment = XlHAlign.xlHAlignLeft;
        }

        public void HorizontalRightAlignment()
        {
            Range.HorizontalAlignment = XlHAlign.xlHAlignRight;
        }

        public void VerticalCenterAlignment()
        {
            Range.VerticalAlignment = XlVAlign.xlVAlignCenter;
        }

        public void VerticalBottomAlignment()
        {
            Range.VerticalAlignment = XlVAlign.xlVAlignBottom;
        }

        public void Bold(bool setBold)
        {
            Range.Font.Bold = setBold;
        }

        public void Cursive(bool setCursive)
        {
            Range.Font.Italic = setCursive;
        }

        public void Underline(bool setUndeline)
        {
            Range.Font.Underline = setUndeline;
        }

        public void TextH1()
        {
            Range.Font.Size = h1Size;
        }

        public void TextH2()
        {
            Range.Font.Size = h2Size;
        }

        public void TextH3()
        {
            Range.Font.Size = h3Size;
        }

        public void WrapText()
        {
            Range.WrapText = true;
        }

        public void Border(bool doubleLine = false, bool bot = false, bool left = false, bool top = false, bool right = false)
        {
            Range.Borders.LineStyle = doubleLine ? XlLineStyle.xlDouble : XlLineStyle.xlContinuous;
            Range.Borders.Weight = XlBorderWeight.xlThin;
            if (bot) { Range.Borders[XlBordersIndex.xlEdgeBottom].Color = XlColorIndex.xlColorIndexAutomatic; }
            if (left) { Range.Borders[XlBordersIndex.xlEdgeLeft].Color = XlColorIndex.xlColorIndexAutomatic; }
            if (top) { Range.Borders[XlBordersIndex.xlEdgeTop].Color = XlColorIndex.xlColorIndexAutomatic; }
            if (right) { Range.Borders[XlBordersIndex.xlEdgeRight].Color = XlColorIndex.xlColorIndexAutomatic; }
        }

        public void FillColor()
        {
            Range.Interior.Pattern = XlPattern.xlPatternSolid;
            Range.Interior.ColorIndex = 15;
        }
    }
}
