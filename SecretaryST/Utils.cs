using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SecretaryST.Exceptions;

namespace SecretaryST
{
    class Utils
    {
        public static List<List<object>> GetValues(Microsoft.Office.Interop.Excel.Range range)
        {
            object dataVal = range.Value;

            if (dataVal.GetType().IsArray)
            {
                return RemoveNullOrEmptyRows((object[,])dataVal);
            }
            else
            {
                throw new InvalidOperationException("There is no cells in range");
            }
        }

        private static List<List<object>> RemoveNullOrEmptyRows(object[,] arr)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }

            List<List<object>> lResult = new List<List<object>>();

            for (int row = 1; row < arr.GetUpperBound(0) + 1; row++)
            {
                List<object> cTemp = new List<object>();
                int nCols = arr.GetUpperBound(1);
                int nEmpty = 0;

                for (int col = 1; col < nCols + 1; col++)
                {
                    object oEl = arr[row, col];
                    cTemp.Add(oEl);
                    if (oEl is null)
                    {
                        nEmpty += 1;
                    }
                }

                if (nEmpty < nCols)
                {
                    lResult.Add(new List<object>(cTemp));
                }
            }

            return lResult;
        }

        public static string ReadStringValue(object obj)
        {
            string res;

            if (obj is string)
            {
                res = (string)obj;
            }
            else
            {
                res = obj.ToString();
            }

            return res;
        }

        public static DateTime ReadDateTimeValue(object obj)
        {
            DateTime res;

            if (obj is DateTime)
            {
                res = (DateTime)obj;
            }
            else
            {
                try
                {
                    string s = ReadStringValue(obj);

                    if (int.TryParse(s, out int year))
                    {
                        res = new DateTime(year: year, 1, 1);
                    }
                    else
                    {
                        throw new InvalidFieldTypeException("YEAR", obj);
                    }
                } catch (ArgumentException)
                {
                    throw new InvalidFieldTypeException("DATE", obj);
                }
            }

            return res;
        }

        public static int ReadIntValue(object obj)
        {
            int res;

            if (obj is string)
            {
                if (!int.TryParse((string)obj, out res))
                {
                    throw new InvalidFieldTypeException("NUMBER", obj);
                }
            }
            else if (obj is double)
            {
                res = Convert.ToInt32(obj);
            }
            else if (obj is int)
            {
                res = (int)obj;
            }
            else
            {
                throw new InvalidFieldTypeException("NUMBER", obj);
            }

            return res;
        }

        public static void AlertMsg(string title, string msg)
        {
            MessageBox.Show(msg, title);
        }
    }
}
;