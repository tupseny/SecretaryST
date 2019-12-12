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
            this.removeOtherSheets = this.Factory.CreateRibbonButton();
            this.visualEffectsToggle = this.Factory.CreateRibbonToggleButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.box1 = this.Factory.CreateRibbonBox();
            this.box3 = this.Factory.CreateRibbonBox();
            this.importBut = this.Factory.CreateRibbonButton();
            this.box2 = this.Factory.CreateRibbonBox();
            this.box4 = this.Factory.CreateRibbonBox();
            this.numOfPersons = this.Factory.CreateRibbonLabel();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.startBox = this.Factory.CreateRibbonBox();
            this.startProt1 = this.Factory.CreateRibbonButton();
            this.startProt2 = this.Factory.CreateRibbonButton();
            this.startProt4 = this.Factory.CreateRibbonButton();
            this.butOptions = this.Factory.CreateRibbonButton();
            this.secretary_tab.SuspendLayout();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            this.box1.SuspendLayout();
            this.box3.SuspendLayout();
            this.box4.SuspendLayout();
            this.group3.SuspendLayout();
            this.startBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // secretary_tab
            // 
            this.secretary_tab.Groups.Add(this.group1);
            this.secretary_tab.Groups.Add(this.group2);
            this.secretary_tab.Groups.Add(this.group3);
            resources.ApplyResources(this.secretary_tab, "secretary_tab");
            this.secretary_tab.Name = "secretary_tab";
            this.secretary_tab.Position = this.Factory.RibbonPosition.AfterOfficeId("TabInsert");
            // 
            // group1
            // 
            this.group1.Items.Add(this.removeOtherSheets);
            this.group1.Items.Add(this.visualEffectsToggle);
            this.group1.Items.Add(this.butOptions);
            resources.ApplyResources(this.group1, "group1");
            this.group1.Name = "group1";
            // 
            // removeOtherSheets
            // 
            this.removeOtherSheets.Image = global::SecretaryST.Properties.Resources.delete_small;
            resources.ApplyResources(this.removeOtherSheets, "removeOtherSheets");
            this.removeOtherSheets.Name = "removeOtherSheets";
            this.removeOtherSheets.ShowImage = true;
            // 
            // visualEffectsToggle
            // 
            this.visualEffectsToggle.Image = global::SecretaryST.Properties.Resources.Fx_small;
            resources.ApplyResources(this.visualEffectsToggle, "visualEffectsToggle");
            this.visualEffectsToggle.Name = "visualEffectsToggle";
            this.visualEffectsToggle.ShowImage = true;
            // 
            // group2
            // 
            this.group2.Items.Add(this.box1);
            resources.ApplyResources(this.group2, "group2");
            this.group2.Name = "group2";
            // 
            // box1
            // 
            this.box1.BoxStyle = Microsoft.Office.Tools.Ribbon.RibbonBoxStyle.Vertical;
            this.box1.Items.Add(this.box3);
            this.box1.Items.Add(this.box2);
            this.box1.Items.Add(this.box4);
            this.box1.Name = "box1";
            // 
            // box3
            // 
            this.box3.Items.Add(this.importBut);
            this.box3.Name = "box3";
            // 
            // importBut
            // 
            resources.ApplyResources(this.importBut, "importBut");
            this.importBut.Image = global::SecretaryST.Properties.Resources.importImage_small;
            this.importBut.Name = "importBut";
            this.importBut.ShowImage = true;
            // 
            // box2
            // 
            this.box2.Name = "box2";
            // 
            // box4
            // 
            this.box4.Items.Add(this.numOfPersons);
            this.box4.Name = "box4";
            // 
            // numOfPersons
            // 
            resources.ApplyResources(this.numOfPersons, "numOfPersons");
            this.numOfPersons.Name = "numOfPersons";
            // 
            // group3
            // 
            this.group3.Items.Add(this.startBox);
            resources.ApplyResources(this.group3, "group3");
            this.group3.Name = "group3";
            // 
            // startBox
            // 
            this.startBox.BoxStyle = Microsoft.Office.Tools.Ribbon.RibbonBoxStyle.Vertical;
            this.startBox.Items.Add(this.startProt1);
            this.startBox.Items.Add(this.startProt2);
            this.startBox.Items.Add(this.startProt4);
            this.startBox.Name = "startBox";
            // 
            // startProt1
            // 
            this.startProt1.Image = global::SecretaryST.Properties.Resources.person1_small;
            resources.ApplyResources(this.startProt1, "startProt1");
            this.startProt1.Name = "startProt1";
            this.startProt1.ShowImage = true;
            // 
            // startProt2
            // 
            this.startProt2.Image = global::SecretaryST.Properties.Resources.pair1_small;
            resources.ApplyResources(this.startProt2, "startProt2");
            this.startProt2.Name = "startProt2";
            this.startProt2.ShowImage = true;
            // 
            // startProt4
            // 
            this.startProt4.Image = global::SecretaryST.Properties.Resources.group_small;
            resources.ApplyResources(this.startProt4, "startProt4");
            this.startProt4.Name = "startProt4";
            this.startProt4.ShowImage = true;
            // 
            // butOptions
            // 
            this.butOptions.Image = global::SecretaryST.Properties.Resources.options;
            resources.ApplyResources(this.butOptions, "butOptions");
            this.butOptions.Name = "butOptions";
            this.butOptions.ShowImage = true;
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
            this.box3.ResumeLayout(false);
            this.box3.PerformLayout();
            this.box4.ResumeLayout(false);
            this.box4.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.startBox.ResumeLayout(false);
            this.startBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab secretary_tab;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton removeOtherSheets;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton importBut;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox startBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton startProt1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton startProt2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton startProt4;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel numOfPersons;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box3;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box2;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box4;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton visualEffectsToggle;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton butOptions;
    }

    partial class ThisRibbonCollection
    {
        internal SecretaryRibbon Ribbon1
        {
            get { return this.GetRibbon<SecretaryRibbon>(); }
        }
    }
}
