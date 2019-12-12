using System.Collections.Generic;
using static SecretaryST.Settings.StartProtOptions.StartProt;
using Excel = Microsoft.Office.Interop.Excel;

namespace SecretaryST
{
    public partial class OptionsSheet
    {
        private static Microsoft.Office.Tools.Excel.Worksheet sheet;

        private const string allHeadersCellName = "startProtAllHeaders";
        private const string headersGroup1CellName = "startProtHeaders1";
        private const string headersGroup2CellName = "startProtHeaders2";
        private const string headersGroup4CellName = "startProtHeaders4";

        private void Лист2_Startup(object sender, System.EventArgs e)
        {
            sheet = this.Base;

            loadOptions();
        }

        private void Лист2_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region Код, созданный конструктором VSTO

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(Лист2_Startup);
            this.Shutdown += new System.EventHandler(Лист2_Shutdown);
        }

        #endregion

        private static void loadOptions()
        {
            loadStartProtocolHeaders();

            void loadStartProtocolHeaders()
            {
                Excel.Range allHeadersRng = sheet.Range[allHeadersCellName];
                Excel.Range group1HeadersRng = sheet.Range[headersGroup1CellName];
                Excel.Range group2HeadersRng = sheet.Range[headersGroup2CellName];
                Excel.Range group4HeadersRng = sheet.Range[headersGroup4CellName];

                ReadOption(allHeadersRng, out List<object> data);
                loadHeaders(data, out List<Header> lHeaders);
                Settings.StartProtOptions.StartProtMain.Headers = lHeaders;

                ReadOption(group1HeadersRng, out data);
                loadHeaders(data, out lHeaders);
                Settings.StartProtOptions.StartProtGroup1.Headers = lHeaders;

                ReadOption(group2HeadersRng, out data);
                loadHeaders(data, out lHeaders);
                Settings.StartProtOptions.StartProtGroup2.Headers = lHeaders;

                ReadOption(group4HeadersRng, out data);
                loadHeaders(data, out lHeaders);
                Settings.StartProtOptions.StartProtGroup4.Headers = lHeaders;

                void loadHeaders(List<object> lData, out List<Header> dest)
                {

                    dest = new List<Header>();

                    if (lData is null)
                    {
                        return;
                    }

                    foreach (object[] row in lData)
                    {
                        Header h = new Header(row[0].ToString(), row[1].ToString(), row[2].ToString(), double.Parse(row[3].ToString()));
                        dest.Add(h);
                    }
                }
            }

        }

        public static void SaveHeaders()
        {
            Excel.Range group1HeadersRng = sheet.Range[headersGroup1CellName];
            Excel.Range group2HeadersRng = sheet.Range[headersGroup2CellName];
            Excel.Range group4HeadersRng = sheet.Range[headersGroup4CellName];

            HeadersToList(Settings.StartProtOptions.StartProtGroup1.Headers, out List<string> sHeaders);
            WriteOption(group1HeadersRng, sHeaders);

            HeadersToList(Settings.StartProtOptions.StartProtGroup2.Headers, out sHeaders);
            WriteOption(group2HeadersRng, sHeaders);

            HeadersToList(Settings.StartProtOptions.StartProtGroup4.Headers, out sHeaders);
            WriteOption(group4HeadersRng, sHeaders);

            void HeadersToList(List<Header> headers, out List<string> dest)
            {
                dest = new List<string>();

                foreach  (Header h in headers)
                {
                    dest.Add(h.ShortName);
                }
            }
        }


        private static void ReadOption(Excel.Range firstCell, out List<object> result)
        {
            result = new List<object>();

            if (firstCell is null)
            {
                throw new System.ArgumentNullException(nameof(firstCell));
            }

            double count;

            if (firstCell.Value.GetType().IsArray)
            {
                count = firstCell.Value2[1, 1] ?? 0;
            }
            else
            {
                count = firstCell.Value2 ?? 0;
            }


            if (count == 0)
            {
                result = null;
                return;
            }
            else if (count < 0)
            {
                throw new System.InvalidOperationException("first cell of options should be positive");
            }

            Excel.Range dataRange = firstCell.Offset[RowOffset: 1].Resize[RowSize: count - 1];

            object[,] aData = dataRange.Value2;
            for (int row = 1; row < aData.GetUpperBound(0) + 1; row++)
            {
                int colCount = aData.GetUpperBound(1);
                object[] aData2 = new object[colCount];
                for (int col = 1; col < colCount + 1; col++)
                {
                    aData2[col - 1] = aData[row, col];
                }

                result.Add(aData2);
            }
        }

        public static void ReadOption(Excel.Range firstCell, out string result)
        {
            ReadOption(firstCell, out List<object> tempList);

            result = tempList[0].ToString();
        }

        public static void ReadOption(Excel.Range firstCell, out bool result)
        {
            ReadOption(firstCell, out string temp);

            if (!bool.TryParse(temp, out result))
            {
                throw new Exceptions.InvalidFieldTypeException("Should be boolean frendly type");
            }
        }

        public static void ReadOption(Excel.Range firstCell, out double result)
        {
            ReadOption(firstCell, out string temp);

            if (!double.TryParse(temp, out result))
            {
                throw new Exceptions.InvalidFieldTypeException("Should be double frendly type");
            }
        }

        private static void WriteOption(Excel.Range firstCell, List<object> lData)
        {
            if (firstCell is null)
            {
                throw new System.ArgumentNullException(nameof(firstCell));
            }

            int count = lData.Count;

            if (count <= 0)
            {
                return;
            }

            firstCell.Value2 = count;

            Excel.Range dataRange = firstCell.Offset[RowOffset: 1].Resize[RowSize: count - 1];
            object[] aData = new object[count];

            lData.CopyTo(aData, 0);

            dataRange.Value = aData;
        }

        public static void WriteOption(Excel.Range firstCell, List<string> lData)
        {
            List<object> lObjects = lData.ConvertAll(s => (object)s);
            WriteOption(firstCell, lObjects);
        }

        public static void WriteOption(Excel.Range firstCell, string sValue)
        {
            WriteOption(firstCell, new List<object>
            {
                sValue
            });
        }

        public static void WriteOption(Excel.Range firstCell, bool bValue)
        {
            WriteOption(firstCell, new List<object>
            {
                bValue
            });
        }
    }
}
