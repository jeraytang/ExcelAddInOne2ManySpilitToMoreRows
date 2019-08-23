namespace ExcelAddInOne2ManySpilitToMoreRows
{
    partial class RibbonOne2ManySpilitToMoreRows : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonOne2ManySpilitToMoreRows()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.btn_split = this.Factory.CreateRibbonButton();
            this.btn_random = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.btn_split);
            this.group1.Items.Add(this.btn_random);
            this.group1.Label = "Jeray通用";
            this.group1.Name = "group1";
            // 
            // btn_split
            // 
            this.btn_split.Label = "一列转多行";
            this.btn_split.Name = "btn_split";
            this.btn_split.SuperTip = "根据指定列，指定分隔符，进行切分。转换成多行。";
            this.btn_split.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_split_Click);
            // 
            // btn_random
            // 
            this.btn_random.Label = "取随机数据";
            this.btn_random.Name = "btn_random";
            this.btn_random.SuperTip = "指定列每一样值，随机取几条";
            this.btn_random.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_random_Click);
            // 
            // RibbonOne2ManySpilitToMoreRows
            // 
            this.Name = "RibbonOne2ManySpilitToMoreRows";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RibbonOne2ManySpilitToMoreRows_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_split;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_random;
    }

    partial class ThisRibbonCollection
    {
        internal RibbonOne2ManySpilitToMoreRows RibbonOne2ManySpilitToMoreRows
        {
            get { return this.GetRibbon<RibbonOne2ManySpilitToMoreRows>(); }
        }
    }
}
