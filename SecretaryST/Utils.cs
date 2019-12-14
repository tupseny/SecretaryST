using Microsoft.Office.Interop.Excel;
using SecretaryST.Exceptions;
using System;
using System.Collections.Generic;

namespace SecretaryST
{
    class Utils
    {
        public static int writeValue(object[] aData, Range range)
        {
            //if range is null
            if (range is null)
            {
                throw new ArgumentNullException(nameof(range));
            }

            int addedRows = 0;

            int rows = aData.GetUpperBound(0) - aData.GetLowerBound(0) + 1;

            //if no cells to be added
            if (rows == 0)
            {
                return addedRows;
            }

            object[,] tmpArray = new object[rows, 1];

            for (int row = 0; row < rows; row++)
            {
                tmpArray[row, 0] = aData[row];
                addedRows++;
            }

            range.Value2 = tmpArray;

            return addedRows;
        }

        //public static int writeValue(object[] aData, Range range)
        //{
        //    object[][] tmpArray = new object[aData.GetUpperBound(0) - aData.GetLowerBound(0) + 1][];

        //    int i = 0;
        //    foreach (object[] item in tmpArray)
        //    {
        //        item = new object[] { aData[i] };
        //        i++;
        //    }

        //    return writeValue(tmpArray, range);
        //}

        public static List<List<object>> GetValues(Microsoft.Office.Interop.Excel.Range range)
        {
            object dataVal = range.Value;

            if (dataVal.GetType().IsArray)
            {
                return RemoveNullOrEmptyRows((object[,])dataVal);
            }
            else
            {
#pragma warning disable CA1303 // Не передавать литералы в качестве локализованных параметров
                throw new InvalidOperationException("There is no cells in range");
#pragma warning restore CA1303 // Не передавать литералы в качестве локализованных параметров
            }
        }

#pragma warning disable CA1814 // Используйте массивы массивов вместо многомерных массивов
        private static List<List<object>> RemoveNullOrEmptyRows(object[,] arr)
#pragma warning restore CA1814 // Используйте массивы массивов вместо многомерных массивов
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

        public static string ReadStringValue(List<object> list, int i)
        {
            object obj = list[i];
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

        public static bool ReadBoolValue(List<object> list, int i)
        {
            object obj = list[i];
            bool res;

            if (obj is string)
            {
                string sObj = (string)obj;
                switch (sObj.ToUpper())
                {
                    case "ДА":
                    case "TRUE":
                    case "YES":
                        res = true;
                        break;
                    case "НЕТ":
                    case "NO":
                    case "FALSE":
                        res = false;
                        break;
                    default:
                        throw new InvalidFieldTypeException("BOOL", obj, iCol: i);
                }
            }
            else if (obj is bool)
            {
                res = (bool)obj;
            }
            else
            {
                throw new InvalidFieldTypeException("BOOL", obj, iCol: i);
            }

            return res;
        }

        public static DateTime ReadDateTimeValue(List<object> list, int i)
        {
            object obj = list[i];
            DateTime res;

            if (obj is DateTime)
            {
                res = (DateTime)obj;
            }
            else
            {
                try
                {
                    string s = ReadStringValue(list, i);

                    if (int.TryParse(s, out int year))
                    {
                        res = new DateTime(year: year, 1, 1);
                    }
                    else
                    {
                        throw new InvalidFieldTypeException("YEAR", obj, iCol: i);
                    }
                }
                catch (ArgumentException)
                {
                    throw new InvalidFieldTypeException("DATE", obj, iCol: i);
                }
            }

            return res;
        }

        public static int ReadIntValue(List<object> list, int i)
        {
            object obj = list[i];
            int res;

            if (obj is string)
            {
                if (!int.TryParse((string)obj, out res))
                {
                    throw new InvalidFieldTypeException("NUMBER", obj, iCol: i);
                }
            }
            else if (obj is double)
            {
#pragma warning disable CA1305 // Укажите IFormatProvider
                res = Convert.ToInt32(obj);
#pragma warning restore CA1305 // Укажите IFormatProvider
            }
            else if (obj is int)
            {
                res = (int)obj;
            }
            else if (obj is null)
            {
                res = 0;
            }
            else
            {
                throw new InvalidFieldTypeException("NUMBER", obj, iCol: i);
            }

            return res;
        }
    }
}
;