namespace SecretaryST.Forms
{
    partial class StartProtocolOptions
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.tabGroup1 = new System.Windows.Forms.TabPage();
            this.HeadersCheckedList = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabGroup2 = new System.Windows.Forms.TabPage();
            this.tabGroup4 = new System.Windows.Forms.TabPage();
            this.butSave = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabGroup1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMain);
            this.tabControl1.Controls.Add(this.tabGroup1);
            this.tabControl1.Controls.Add(this.tabGroup2);
            this.tabControl1.Controls.Add(this.tabGroup4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(680, 378);
            this.tabControl1.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(672, 352);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Общие";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // tabGroup1
            // 
            this.tabGroup1.Controls.Add(this.HeadersCheckedList);
            this.tabGroup1.Controls.Add(this.label1);
            this.tabGroup1.Location = new System.Drawing.Point(4, 22);
            this.tabGroup1.Name = "tabGroup1";
            this.tabGroup1.Padding = new System.Windows.Forms.Padding(3);
            this.tabGroup1.Size = new System.Drawing.Size(672, 352);
            this.tabGroup1.TabIndex = 1;
            this.tabGroup1.Text = "Личка";
            this.tabGroup1.UseVisualStyleBackColor = true;
            // 
            // HeadersCheckedList
            // 
            this.HeadersCheckedList.FormattingEnabled = true;
            this.HeadersCheckedList.Location = new System.Drawing.Point(19, 30);
            this.HeadersCheckedList.Name = "HeadersCheckedList";
            this.HeadersCheckedList.Size = new System.Drawing.Size(170, 304);
            this.HeadersCheckedList.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Заголовки протокола";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabGroup2
            // 
            this.tabGroup2.Location = new System.Drawing.Point(4, 22);
            this.tabGroup2.Name = "tabGroup2";
            this.tabGroup2.Padding = new System.Windows.Forms.Padding(3);
            this.tabGroup2.Size = new System.Drawing.Size(672, 352);
            this.tabGroup2.TabIndex = 2;
            this.tabGroup2.Text = "Связка";
            this.tabGroup2.UseVisualStyleBackColor = true;
            // 
            // tabGroup4
            // 
            this.tabGroup4.Location = new System.Drawing.Point(4, 22);
            this.tabGroup4.Name = "tabGroup4";
            this.tabGroup4.Padding = new System.Windows.Forms.Padding(3);
            this.tabGroup4.Size = new System.Drawing.Size(672, 352);
            this.tabGroup4.TabIndex = 3;
            this.tabGroup4.Text = "Группа";
            this.tabGroup4.UseVisualStyleBackColor = true;
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(713, 415);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(75, 23);
            this.butSave.TabIndex = 1;
            this.butSave.Text = "Сохранить";
            this.butSave.UseVisualStyleBackColor = true;
            // 
            // StartProtocolOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.tabControl1);
            this.Name = "StartProtocolOptions";
            this.Text = "Настройка стартовых протоколов";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.tabControl1.ResumeLayout(false);
            this.tabGroup1.ResumeLayout(false);
            this.tabGroup1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabGroup1;
        private System.Windows.Forms.TabPage tabGroup2;
        private System.Windows.Forms.TabPage tabGroup4;
        private System.Windows.Forms.CheckedListBox HeadersCheckedList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butSave;
    }
}