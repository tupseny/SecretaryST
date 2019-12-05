namespace SecretaryST
{
    partial class SecretaryRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public SecretaryRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecretaryRibbon));
            this.secretary_tab = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.button1 = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.importBut = this.Factory.CreateRibbonButton();
            this.box1 = this.Factory.CreateRibbonBox();
            this.secretary_tab.SuspendLayout();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            this.box1.SuspendLayout();
            this.SuspendLayout();
            // 
            // secretary_tab
            // 
            this.secretary_tab.Groups.Add(this.group1);
            this.secretary_tab.Groups.Add(this.group2);
            resources.ApplyResources(this.secretary_tab, "secretary_tab");
            this.secretary_tab.Name = "secretary_tab";
            this.secretary_tab.Position = this.Factory.RibbonPosition.AfterOfficeId("TabInsert");
            // 
            // group1
            // 
            this.group1.Items.Add(this.button1);
            resources.ApplyResources(this.group1, "group1");
            this.group1.Name = "group1";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            // 
            // group2
            // 
            this.group2.Items.Add(this.box1);
            resources.ApplyResources(this.group2, "group2");
            this.group2.Name = "group2";
            // 
            // importBut
            // 
            resources.ApplyResources(this.importBut, "importBut");
            this.importBut.Name = "importBut";
            // 
            // box1
            // 
            this.box1.Items.Add(this.importBut);
            this.box1.Name = "box1";
            // 
            // SecretaryRibbon
            // 
            this.Name = "SecretaryRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.secretary_tab);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.secretary_tab.ResumeLayout(false);
            this.secretary_tab.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.box1.ResumeLayout(false);
            this.box1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab secretary_tab;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton importBut;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box1;
    }

    partial class ThisRibbonCollection
    {
        internal SecretaryRibbon Ribbon1
        {
            get { return this.GetRibbon<SecretaryRibbon>(); }
        }
    }
}
