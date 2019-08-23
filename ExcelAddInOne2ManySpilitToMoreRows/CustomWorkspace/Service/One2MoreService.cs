using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelAddInOne2ManySpilitToMoreRows.Util;
using Microsoft.Office.Interop.Excel;

namespace ExcelAddInOne2ManySpilitToMoreRows.CustomWorkspace.Service
{
    public class One2MoreService
    {
        private string _splitColumnName;
        private string _splitChar;

        public One2MoreService(string splitColumnName, string splitChar)
        {
            _splitColumnName = splitColumnName;
            _splitChar = splitChar;
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


                Microsoft.Office.Interop.Excel.Worksheet sheet = Globals.ThisAddIn.Application.ActiveWorkbook
                    .ActiveSheet;
                if (sheet == null)
                {
                    return null;
                }

                var splitColumnNameIndex = Helper.ExcelNameToIndex(this._splitColumnName);
                var rowTotal = sheet.UsedRange.SpecialCells(XlCellType.xlCellTypeLastCell).Row;
                var colTotal = sheet.UsedRange.SpecialCells(XlCellType.xlCellTypeLastCell).Column;

                var list = new List<object[]>();
                var i_row = -1;
                for (var i = 0; i < rowTotal; i++)
                {
                    var splitColumnValue = sheet.Cells[i + 1, splitColumnNameIndex + 1].Value2;
                    var array = splitColumnValue.Split(new string[] { this._splitChar },
                        StringSplitOptions.RemoveEmptyEntries);
                    foreach (var value in array)
                    {
                        i_row++;
                        var objArray = new object[colTotal];
                        for (var j = 0; j < colTotal; j++)
                        {
                            if (j == splitColumnNameIndex)
                            {
                                objArray[j] = value;
                                continue;
                            }

                            objArray[j] = Helper.GetObjString(sheet.Cells[i + 1, j + 1].Value2);
                        }
                        list.Add(objArray);
                    }
                }
                var twoArray = new object[list.Count, colTotal];
                for (var i = 0; i < list.Count; i++)
                {
                    var array = list[i];
                    for (var j = 0; j < array.Length; j++)
                    {
                        twoArray[i, j] = array[j];
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


    }
}
