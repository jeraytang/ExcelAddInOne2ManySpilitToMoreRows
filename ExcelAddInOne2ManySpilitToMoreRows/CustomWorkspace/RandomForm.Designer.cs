namespace ExcelAddInOne2ManySpilitToMoreRows.CustomWorkspace
{
    partial class RandomForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.btn_start = new MaterialSkin.Controls.MaterialFlatButton();
            this.edt_column = new System.Windows.Forms.TextBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.edt_num = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(12, 91);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(173, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "随机值数据列(例：A)：";
            // 
            // btn_start
            // 
            this.btn_start.AutoSize = true;
            this.btn_start.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_start.Depth = 0;
            this.btn_start.Location = new System.Drawing.Point(317, 112);
            this.btn_start.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_start.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_start.Name = "btn_start";
            this.btn_start.Primary = false;
            this.btn_start.Size = new System.Drawing.Size(42, 36);
            this.btn_start.TabIndex = 1;
            this.btn_start.Text = "开始";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // edt_column
            // 
            this.edt_column.Location = new System.Drawing.Point(176, 93);
            this.edt_column.Name = "edt_column";
            this.edt_column.Size = new System.Drawing.Size(100, 21);
            this.edt_column.TabIndex = 2;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(33, 136);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(137, 19);
            this.materialLabel2.TabIndex = 0;
            this.materialLabel2.Text = "每个值随机条数：";
            // 
            // edt_num
            // 
            this.edt_num.Location = new System.Drawing.Point(176, 134);
            this.edt_num.Name = "edt_num";
            this.edt_num.Size = new System.Drawing.Size(100, 21);
            this.edt_num.TabIndex = 2;
            // 
            // RandomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 189);
            this.Controls.Add(this.edt_num);
            this.Controls.Add(this.edt_column);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.materialLabel1);
            this.Name = "RandomForm";
            this.Text = "指定列取随机数据";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialFlatButton btn_start;
        private System.Windows.Forms.TextBox edt_column;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.TextBox edt_num;
    }
}