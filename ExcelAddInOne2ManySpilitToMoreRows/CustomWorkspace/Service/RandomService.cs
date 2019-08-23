using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelAddInOne2ManySpilitToMoreRows.Util;
using Microsoft.Office.Interop.Excel;

namespace ExcelAddInOne2ManySpilitToMoreRows.CustomWorkspace.Service
{
    public class RandomService
    {
        class RowRange
        {
            public object Value { get; set; }

            public string StrRange { get; set; }
        }
        private string _columnName;
        private int _number;
        public RandomService(string columnName, int num)
        {
            this._columnName = columnName;
            this._number = num;
        }
        public async Task<bool> RunAsync()
        {
            var list = await ReadFromExcelAync().ConfigureAwait(false);
            var result = await SaveAsNewSheet(list).ConfigureAwait(false);
            return result;
        }
        private async Task<object[,]> ReadFromExcelAync()
        {
            try
            {

                var sheet = Globals.ThisAddIn.Application.ActiveWorkbook
                    .ActiveSheet;
                if (sheet == null)
                {
                    return null;
                }
                var splitColumnNameIndex = Helper.ExcelNameToIndex(this._columnName);
                var rowTotal = sheet.UsedRange.SpecialCells(XlCellType.xlCellTypeLastCell).Row;
                var colTotal = sheet.UsedRange.SpecialCells(XlCellType.xlCellTypeLastCell).Column;

                var listArray = new List<object[]>();
                var needs = new List<string>();
                var dic = new Dictionary<string, List<string>>();
                for (var i = 0; i < rowTotal; i++)
                {
                    var rowIndex = i + 1;
                    var needColumnValue = Helper.GetObjString(sheet.Cells[rowIndex, splitColumnNameIndex + 1].Value2);
                    var strRange = $"A{rowIndex}:{Helper.ExcelIndexToName(colTotal - 1)}{rowIndex}";
                    if (dic.ContainsKey(needColumnValue))
                    {
                        var list = dic[needColumnValue];
                        list.Add(strRange);
                    }
                    else
                    {
                        var list = new List<string> { strRange };
                        dic.Add(needColumnValue, list);
                    }
                }

                foreach (var key in dic.Keys)
                {
                    var subList = GetRandomList(dic[key], this._number);
                    needs.AddRange(subList);
                }
                var twoArray = new object[needs.Count, colTotal];
                var i_row = -1;
                foreach (var strRange in needs)
                {
                    i_row++;
                    var array = sheet.Range[strRange].Value2;
                    var rowLength = array.GetLength(0);
                    var colLength = array.GetLength(1);
                    for (int i = 1; i <= rowLength; i++)
                    {
                        for (var j = 1; j <= colLength; j++)
                        {
                            twoArray[i_row, j - 1] = array[i, j];
                        }
                    }
                }

                return twoArray;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private async Task<bool> SaveAsNewSheet(object[,] array)
        {
            try
            {
                Workbook wb = Globals.ThisAddIn.Application.ActiveWorkbook;
                Worksheet sheet = wb.Sheets.Add();

                var rowCount = array.GetLength(0);
                var colCount = array.GetLength(1);

                var strRange = $"A1:{Helper.ExcelIndexToName(colCount - 1)}{rowCount}";
                sheet.Range[strRange].Value2 = array;

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private List<T> GetRandomList<T>(List<T> list, int numCount)
        {
            var listIndex = new List<int>();
            var rand = new Random();
            if (list.Count() <= numCount)
            {
                return list.ToList();
            }

            var rs = new List<T>();
            var total = list.Count();
            var i = 0;
            while (true)
            {
                i++;
                if (i != 1)
                {
                    rand = new Random(i * ((int)DateTime.Now.Ticks));
                }
                var r = rand.Next(total);
                if (listIndex.Contains(r))
                {
                    continue;
                }
                listIndex.Add(r);
                rs.Add(list[r]);
                if (listIndex.Count == numCount)
                {
                    break;
                }
            }
            return rs;
        }
    }
}
