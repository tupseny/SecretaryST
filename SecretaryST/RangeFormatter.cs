using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Excel;
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

        public void VerticalCenterAlignment()
        {
            Range.VerticalAlignment = XlVAlign.xlVAlignCenter;
        }

        public void Bold()
        {
            Range.Font.Bold = true;
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
    }
}
