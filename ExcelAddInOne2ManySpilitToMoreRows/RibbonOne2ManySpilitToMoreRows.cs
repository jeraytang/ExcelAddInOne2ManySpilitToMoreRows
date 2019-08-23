using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcelAddInOne2ManySpilitToMoreRows.CustomWorkspace;
using Microsoft.Office.Tools.Ribbon;

namespace ExcelAddInOne2ManySpilitToMoreRows
{
    public partial class RibbonOne2ManySpilitToMoreRows
    {
        private void RibbonOne2ManySpilitToMoreRows_Load(object sender, RibbonUIEventArgs e)
        {

        }

        /// <summary>
        /// 一列转多行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_split_Click(object sender, RibbonControlEventArgs e)
        {
            var form = new One2ManyToolForm();
            form.ShowDialog();
        }

        /// <summary>
        /// 指定列，随机获取指定条数（定制化）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_random_Click(object sender, RibbonControlEventArgs e)
        {
            var form = new RandomForm();
            form.ShowDialog();
        }
    }
}
