using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelAddInOne2ManySpilitToMoreRows.CustomWorkspace.Service;
using ExcelAddInOne2ManySpilitToMoreRows.Util;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ExcelAddInOne2ManySpilitToMoreRows.CustomWorkspace
{
    public partial class RandomForm : MaterialForm
    {
        public RandomForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

        }
        private static void ShowStep(string msg)
        {
            MessageBox.Show(msg);
        }
        private void btn_start_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                var columnName = this.edt_column.Text.Trim();
                var num = Helper.GetObjInteger(this.edt_num.Text.Trim());
                if (string.IsNullOrWhiteSpace(columnName))
                {
                    ShowStep("请输入需要提取随机数据的列！");
                    return;
                }
                if (num <= 0)
                {
                    ShowStep("请输入每个数值随机提取条数！");
                    return;
                }
                var service = new RandomService(columnName, num);
                var result = service.RunAsync().Result;
            }
            catch (Exception ms)
            {
                ShowStep(ms.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
                ShowStep($"处理完成！");
                this.Close();
            }
        }
    }
}
