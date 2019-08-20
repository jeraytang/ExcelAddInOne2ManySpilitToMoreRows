using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace ExcelAddInOne2ManySpilitToMoreRows
{
    public class Helper
    {
        public static int GetObjInteger(object obj)
        {
            if (obj == null)
            {
                return 0;
            }

            int rs;
            if (Int32.TryParse(obj.ToString().Trim(), out rs))
            {
                return rs;
            }
            else
            {
                return 0;
            }

        }

        public static double GetObjDouble(object obj)
        {
            if (obj == null)
            {
                return 0.0;
            }

            double rs;
            if (Double.TryParse(obj.ToString().Trim(), out rs))
            {
                return rs;
            }
            else
            {
                return 0.0;
            }

        }

        public static string GetObjString(object obj)
        {
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }

        }

        public static int ExcelNameToIndex(string columnName)
        {
            if (!Regex.IsMatch(columnName.ToUpper(), @"[A-Z]+"))
            {
                throw new Exception("invalid parameter");
            }

            int index = 0;
            char[] chars = columnName.ToUpper().ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                index += ((int) chars[i] - (int) 'A' + 1) * (int) Math.Pow(26, chars.Length - i - 1);
            }

            return index - 1;
        }


        public static string ExcelIndexToName(int index)
        {
            if (index < 0)
            {
                throw new Exception("invalid parameter");
            }

            List<string> chars = new List<string>();
            do
            {
                if (chars.Count > 0) index--;
                chars.Insert(0, ((char) (index % 26 + (int) 'A')).ToString());
                index = (int) ((index - index % 26) / 26);
            } while (index > 0);

            return String.Join(string.Empty, chars.ToArray());
        }

        /// <summary>
        /// 获取Excel对象，如果不存在则打开
        /// </summary>
        /// <returns>返回一个Excel对象</returns>
        public static Application GetExcelApplication()
        {
            Application _application;
            try
            {
                _application = (Application) Marshal.GetActiveObject("Excel.Application"); //尝试取得正在运行的Excel对象
                Debug.WriteLine("Get Running Excel");
            }
            //没有打开Excel则会报错
            catch (COMException)
            {
                _application = CreateExcelApplication(); //打开Excel
                Debug.WriteLine("Create new Excel");
            }

            Debug.WriteLine(_application.Version); //打印Excel版本
            return _application;
        }

        /// <summary>
        /// 创建一个Excel对象
        /// </summary>
        /// <param name="visible">是否显示Excel，默认为True</param>
        /// <param name="caption">标题栏</param>
        /// <returns>返回创建好的Excel对象</returns>
        public static Application CreateExcelApplication(bool visible = true, string caption = "New Application")
        {
            var application = new Application
            {
                Visible = visible,
                Caption = caption
            };
            return application;
        }
    }
}
