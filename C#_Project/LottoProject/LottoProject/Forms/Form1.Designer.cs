namespace LottoProject
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tmnFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tnmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tnmAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.customPanel2 = new LottoProject.CustomPanel();
            this.lvwDataList = new System.Windows.Forms.ListView();
            this.customPanel3 = new LottoProject.CustomPanel();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAddList = new System.Windows.Forms.Button();
            this.btnRemoveListitem = new System.Windows.Forms.Button();
            this.btnRemoveListall = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.customPanel1 = new LottoProject.CustomPanel();
            this.btnClearNum = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.txt3 = new System.Windows.Forms.TextBox();
            this.txt4 = new System.Windows.Forms.TextBox();
            this.chk1 = new System.Windows.Forms.CheckBox();
            this.txt5 = new System.Windows.Forms.TextBox();
            this.chk6 = new System.Windows.Forms.CheckBox();
            this.txt6 = new System.Windows.Forms.TextBox();
            this.chk5 = new System.Windows.Forms.CheckBox();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.chk4 = new System.Windows.Forms.CheckBox();
            this.chk2 = new System.Windows.Forms.CheckBox();
            this.chk3 = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.customPanel2.SuspendLayout();
            this.customPanel3.SuspendLayout();
            this.customPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmnFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1074, 33);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tmnFile
            // 
            this.tmnFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tnmExit,
            this.tnmAbout});
            this.tmnFile.Name = "tmnFile";
            this.tmnFile.Size = new System.Drawing.Size(55, 29);
            this.tmnFile.Text = "File";
            // 
            // tnmExit
            // 
            this.tnmExit.Name = "tnmExit";
            this.tnmExit.Size = new System.Drawing.Size(294, 34);
            this.tnmExit.Text = "Exit                 Ctri+X";
            this.tnmExit.Click += new System.EventHandler(this.tnmExit_Click);
            // 
            // tnmAbout
            // 
            this.tnmAbout.Name = "tnmAbout";
            this.tnmAbout.Size = new System.Drawing.Size(294, 34);
            this.tnmAbout.Text = "About             Ctrl+A";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.ClickEvent);
            // 
            // customPanel2
            // 
            this.customPanel2.Controls.Add(this.lvwDataList);
            this.customPanel2.Controls.Add(this.customPanel3);
            this.customPanel2.Controls.Add(this.btnAddList);
            this.customPanel2.Controls.Add(this.btnRemoveListitem);
            this.customPanel2.Controls.Add(this.btnRemoveListall);
            this.customPanel2.Controls.Add(this.btnExport);
            this.customPanel2.Controls.Add(this.btnCopy);
            this.customPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customPanel2.Location = new System.Drawing.Point(0, 175);
            this.customPanel2.Name = "customPanel2";
            this.customPanel2.Size = new System.Drawing.Size(1074, 762);
            this.customPanel2.TabIndex = 71;
            // 
            // lvwDataList
            // 
            this.lvwDataList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwDataList.HideSelection = false;
            this.lvwDataList.LabelEdit = true;
            this.lvwDataList.Location = new System.Drawing.Point(131, 193);
            this.lvwDataList.Name = "lvwDataList";
            this.lvwDataList.Size = new System.Drawing.Size(767, 331);
            this.lvwDataList.TabIndex = 60;
            this.lvwDataList.UseCompatibleStateImageBehavior = false;
            this.lvwDataList.Resize += new System.EventHandler(this.lvwDataList_Resize);
            // 
            // customPanel3
            // 
            this.customPanel3.Controls.Add(this.lblDateTime);
            this.customPanel3.Controls.Add(this.lblTime);
            this.customPanel3.Controls.Add(this.btnExit);
            this.customPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.customPanel3.Location = new System.Drawing.Point(0, 662);
            this.customPanel3.Name = "customPanel3";
            this.customPanel3.Size = new System.Drawing.Size(1074, 100);
            this.customPanel3.TabIndex = 57;
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Location = new System.Drawing.Point(62, 31);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(88, 18);
            this.lblDateTime.TabIndex = 56;
            this.lblDateTime.Text = "DataTime:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(156, 31);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 18);
            this.lblTime.TabIndex = 55;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(902, 8);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(123, 41);
            this.btnExit.TabIndex = 51;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAddList
            // 
            this.btnAddList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddList.Location = new System.Drawing.Point(755, 83);
            this.btnAddList.Name = "btnAddList";
            this.btnAddList.Size = new System.Drawing.Size(123, 41);
            this.btnAddList.TabIndex = 59;
            this.btnAddList.Text = "Add";
            this.btnAddList.UseVisualStyleBackColor = true;
            this.btnAddList.Click += new System.EventHandler(this.btnAddList_Click);
            // 
            // btnRemoveListitem
            // 
            this.btnRemoveListitem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveListitem.Location = new System.Drawing.Point(621, 80);
            this.btnRemoveListitem.Name = "btnRemoveListitem";
            this.btnRemoveListitem.Size = new System.Drawing.Size(128, 41);
            this.btnRemoveListitem.TabIndex = 58;
            this.btnRemoveListitem.Text = "Remove";
            this.btnRemoveListitem.UseVisualStyleBackColor = true;
            this.btnRemoveListitem.Click += new System.EventHandler(this.btnRemoveListitem_Click);
            // 
            // btnRemoveListall
            // 
            this.btnRemoveListall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveListall.Location = new System.Drawing.Point(491, 80);
            this.btnRemoveListall.Name = "btnRemoveListall";
            this.btnRemoveListall.Size = new System.Drawing.Size(124, 41);
            this.btnRemoveListall.TabIndex = 57;
            this.btnRemoveListall.Text = "Remove All";
            this.btnRemoveListall.UseVisualStyleBackColor = true;
            this.btnRemoveListall.Click += new System.EventHandler(this.btnRemoveListall_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(263, 80);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(118, 41);
            this.btnExport.TabIndex = 56;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(141, 80);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(116, 41);
            this.btnCopy.TabIndex = 55;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // customPanel1
            // 
            this.customPanel1.Controls.Add(this.btnClearNum);
            this.customPanel1.Controls.Add(this.btnRun);
            this.customPanel1.Controls.Add(this.txt2);
            this.customPanel1.Controls.Add(this.txt3);
            this.customPanel1.Controls.Add(this.txt4);
            this.customPanel1.Controls.Add(this.chk1);
            this.customPanel1.Controls.Add(this.txt5);
            this.customPanel1.Controls.Add(this.chk6);
            this.customPanel1.Controls.Add(this.txt6);
            this.customPanel1.Controls.Add(this.chk5);
            this.customPanel1.Controls.Add(this.txt1);
            this.customPanel1.Controls.Add(this.chk4);
            this.customPanel1.Controls.Add(this.chk2);
            this.customPanel1.Controls.Add(this.chk3);
            this.customPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.customPanel1.Location = new System.Drawing.Point(0, 33);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Size = new System.Drawing.Size(1074, 142);
            this.customPanel1.TabIndex = 56;
            // 
            // btnClearNum
            // 
            this.btnClearNum.Location = new System.Drawing.Point(788, 61);
            this.btnClearNum.Name = "btnClearNum";
            this.btnClearNum.Size = new System.Drawing.Size(90, 41);
            this.btnClearNum.TabIndex = 70;
            this.btnClearNum.Text = "Clear All";
            this.btnClearNum.UseVisualStyleBackColor = true;
            this.btnClearNum.Click += new System.EventHandler(this.btnClearNum_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(692, 61);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(90, 41);
            this.btnRun.TabIndex = 69;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(238, 74);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(56, 28);
            this.txt2.TabIndex = 68;
            this.txt2.Text = "1~45";
            // 
            // txt3
            // 
            this.txt3.Location = new System.Drawing.Point(321, 74);
            this.txt3.Name = "txt3";
            this.txt3.Size = new System.Drawing.Size(56, 28);
            this.txt3.TabIndex = 67;
            this.txt3.Text = "1~45";
            // 
            // txt4
            // 
            this.txt4.Location = new System.Drawing.Point(405, 74);
            this.txt4.Name = "txt4";
            this.txt4.Size = new System.Drawing.Size(56, 28);
            this.txt4.TabIndex = 66;
            this.txt4.Text = "1~45";
            // 
            // chk1
            // 
            this.chk1.AutoSize = true;
            this.chk1.Location = new System.Drawing.Point(159, 46);
            this.chk1.Name = "chk1";
            this.chk1.Size = new System.Drawing.Size(56, 22);
            this.chk1.TabIndex = 57;
            this.chk1.Text = "Fix";
            this.chk1.UseVisualStyleBackColor = true;
            this.chk1.CheckedChanged += new System.EventHandler(this.chk1_CheckedChanged_1);
            // 
            // txt5
            // 
            this.txt5.Location = new System.Drawing.Point(491, 74);
            this.txt5.Name = "txt5";
            this.txt5.Size = new System.Drawing.Size(56, 28);
            this.txt5.TabIndex = 65;
            this.txt5.Text = "1~45";
            // 
            // chk6
            // 
            this.chk6.AutoSize = true;
            this.chk6.Location = new System.Drawing.Point(572, 46);
            this.chk6.Name = "chk6";
            this.chk6.Size = new System.Drawing.Size(56, 22);
            this.chk6.TabIndex = 58;
            this.chk6.Text = "Fix";
            this.chk6.UseVisualStyleBackColor = true;
            this.chk6.CheckedChanged += new System.EventHandler(this.chk6_CheckedChanged);
            // 
            // txt6
            // 
            this.txt6.Location = new System.Drawing.Point(572, 74);
            this.txt6.Name = "txt6";
            this.txt6.Size = new System.Drawing.Size(56, 28);
            this.txt6.TabIndex = 64;
            this.txt6.Text = "1~45";
            // 
            // chk5
            // 
            this.chk5.AutoSize = true;
            this.chk5.Location = new System.Drawing.Point(491, 46);
            this.chk5.Name = "chk5";
            this.chk5.Size = new System.Drawing.Size(56, 22);
            this.chk5.TabIndex = 59;
            this.chk5.Text = "Fix";
            this.chk5.UseVisualStyleBackColor = true;
            this.chk5.CheckedChanged += new System.EventHandler(this.chk5_CheckedChanged);
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(159, 74);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(56, 28);
            this.txt1.TabIndex = 63;
            this.txt1.Text = "1~45";
            // 
            // chk4
            // 
            this.chk4.AutoSize = true;
            this.chk4.Location = new System.Drawing.Point(405, 46);
            this.chk4.Name = "chk4";
            this.chk4.Size = new System.Drawing.Size(56, 22);
            this.chk4.TabIndex = 60;
            this.chk4.Text = "Fix";
            this.chk4.UseVisualStyleBackColor = true;
            this.chk4.CheckedChanged += new System.EventHandler(this.chk4_CheckedChanged);
            // 
            // chk2
            // 
            this.chk2.AutoSize = true;
            this.chk2.Location = new System.Drawing.Point(238, 46);
            this.chk2.Name = "chk2";
            this.chk2.Size = new System.Drawing.Size(56, 22);
            this.chk2.TabIndex = 62;
            this.chk2.Text = "Fix";
            this.chk2.UseVisualStyleBackColor = true;
            this.chk2.CheckedChanged += new System.EventHandler(this.chk2_CheckedChanged);
            // 
            // chk3
            // 
            this.chk3.AutoSize = true;
            this.chk3.Location = new System.Drawing.Point(321, 46);
            this.chk3.Name = "chk3";
            this.chk3.Size = new System.Drawing.Size(56, 22);
            this.chk3.TabIndex = 61;
            this.chk3.Text = "Fix";
            this.chk3.UseVisualStyleBackColor = true;
            this.chk3.CheckedChanged += new System.EventHandler(this.chk3_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1074, 937);
            this.Controls.Add(this.customPanel2);
            this.Controls.Add(this.customPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.From1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.customPanel2.ResumeLayout(false);
            this.customPanel3.ResumeLayout(false);
            this.customPanel3.PerformLayout();
            this.customPanel1.ResumeLayout(false);
            this.customPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private CustomPanel customPanel3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timer1;
        private CustomPanel customPanel2;
        private System.Windows.Forms.Button btnRemoveListitem;
        private System.Windows.Forms.Button btnRemoveListall;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnCopy;
        private CustomPanel customPanel1;
        private System.Windows.Forms.Button btnClearNum;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.TextBox txt3;
        private System.Windows.Forms.TextBox txt4;
        private System.Windows.Forms.CheckBox chk1;
        private System.Windows.Forms.TextBox txt5;
        private System.Windows.Forms.CheckBox chk6;
        private System.Windows.Forms.TextBox txt6;
        private System.Windows.Forms.CheckBox chk5;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.CheckBox chk4;
        private System.Windows.Forms.CheckBox chk2;
        private System.Windows.Forms.CheckBox chk3;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.ListView lvwDataList;
        private System.Windows.Forms.ToolStripMenuItem tmnFile;
        private System.Windows.Forms.ToolStripMenuItem tnmExit;
        private System.Windows.Forms.ToolStripMenuItem tnmAbout;
        public System.Windows.Forms.Button btnAddList;
    }
}

