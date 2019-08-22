using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ExcelAddInOne2ManySpilitToMoreRows
{
    public partial class One2ManyToolForm : MaterialForm
    {
        public One2ManyToolForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.panel_top.BorderStyle = BorderStyle.FixedSingle;
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

                var splitColumnName = this.edt_column.Text.Trim();
                var splitChar = this.edt_splitChar.Text.Trim();
                if (string.IsNullOrWhiteSpace(splitColumnName))
                {
                    ShowStep("请输入需要切割数据所在的列！");
                    return;
                }

                if (string.IsNullOrWhiteSpace(splitChar))
                {
                    ShowStep("请输入分隔符");
                    return;
                }

                var service = new Service(splitColumnName, splitChar);
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
