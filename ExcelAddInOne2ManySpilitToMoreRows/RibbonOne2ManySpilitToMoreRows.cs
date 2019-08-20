using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace ExcelAddInOne2ManySpilitToMoreRows
{
    public partial class RibbonOne2ManySpilitToMoreRows
    {
        private void RibbonOne2ManySpilitToMoreRows_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btn_split_Click(object sender, RibbonControlEventArgs e)
        {
          var aa=  Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet;

            var form = new One2ManyToolForm();
            form.ShowDialog();
        }
    }
}
