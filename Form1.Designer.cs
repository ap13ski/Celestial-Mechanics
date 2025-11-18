namespace Celestial
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.imageListIcons = new System.Windows.Forms.ImageList(this.components);
            this.listBoxMain = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonSave = new System.Windows.Forms.Button();
            this.checkBoxIsLabeled = new System.Windows.Forms.CheckBox();
            this.checkBoxStartPause = new System.Windows.Forms.CheckBox();
            this.checkBoxSettings = new System.Windows.Forms.CheckBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.checkBoxTraces = new System.Windows.Forms.CheckBox();
            this.checkBoxLog = new System.Windows.Forms.CheckBox();
            this.checkBoxGridAuto = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBoxMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBoxMain.InitialImage = null;
            this.pictureBoxMain.Location = new System.Drawing.Point(47, 1);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(299, 258);
            this.pictureBoxMain.TabIndex = 0;
            this.pictureBoxMain.TabStop = false;
            this.pictureBoxMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBoxMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBoxMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // imageListIcons
            // 
            this.imageListIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer) (resources.GetObject("imageListIcons.ImageStream")));
            this.imageListIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListIcons.Images.SetKeyName(0, "start.png");
            this.imageListIcons.Images.SetKeyName(1, "stop.png");
            this.imageListIcons.Images.SetKeyName(2, "labels.png");
            this.imageListIcons.Images.SetKeyName(3, "presets.png");
            this.imageListIcons.Images.SetKeyName(4, "save.png");
            this.imageListIcons.Images.SetKeyName(5, "traces.png");
            this.imageListIcons.Images.SetKeyName(6, "log_ok.png");
            this.imageListIcons.Images.SetKeyName(7, "log_no.png");
            this.imageListIcons.Images.SetKeyName(8, "grid_a.png");
            this.imageListIcons.Images.SetKeyName(9, "grid_m.png");
            this.imageListIcons.Images.SetKeyName(10, "planets.png");
            // 
            // listBox1
            // 
            this.listBoxMain.Enabled = false;
            this.listBoxMain.ItemHeight = 16;
            this.listBoxMain.Location = new System.Drawing.Point(10, 366);
            this.listBoxMain.Name = "listBoxMain";
            this.listBoxMain.Size = new System.Drawing.Size(31, 20);
            this.listBoxMain.TabIndex = 5;
            this.listBoxMain.TabStop = false;
            this.listBoxMain.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonSave
            // 
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.ImageIndex = 4;
            this.buttonSave.ImageList = this.imageListIcons;
            this.buttonSave.Location = new System.Drawing.Point(-4, 307);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(45, 41);
            this.buttonSave.TabIndex = 6;
            this.toolTip1.SetToolTip(this.buttonSave, "Save the log to the program directory (csv)");
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // checkBoxIsLabeled
            // 
            this.checkBoxIsLabeled.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxIsLabeled.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.checkBoxIsLabeled.Checked = true;
            this.checkBoxIsLabeled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIsLabeled.FlatAppearance.BorderSize = 0;
            this.checkBoxIsLabeled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxIsLabeled.ImageIndex = 2;
            this.checkBoxIsLabeled.ImageList = this.imageListIcons;
            this.checkBoxIsLabeled.Location = new System.Drawing.Point(-4, 52);
            this.checkBoxIsLabeled.Name = "checkBoxIsLabeled";
            this.checkBoxIsLabeled.Size = new System.Drawing.Size(45, 45);
            this.checkBoxIsLabeled.TabIndex = 1;
            this.checkBoxIsLabeled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.checkBoxIsLabeled, "Show / Hide the captions");
            this.checkBoxIsLabeled.UseVisualStyleBackColor = true;
            this.checkBoxIsLabeled.CheckedChanged += new System.EventHandler(this.checkBoxIsLabeled_CheckedChanged);
            // 
            // checkBoxStartPause
            // 
            this.checkBoxStartPause.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxStartPause.AutoCheck = false;
            this.checkBoxStartPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.checkBoxStartPause.FlatAppearance.BorderSize = 0;
            this.checkBoxStartPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxStartPause.ImageIndex = 0;
            this.checkBoxStartPause.ImageList = this.imageListIcons;
            this.checkBoxStartPause.Location = new System.Drawing.Point(-4, 1);
            this.checkBoxStartPause.Name = "checkBoxStartPause";
            this.checkBoxStartPause.Size = new System.Drawing.Size(45, 45);
            this.checkBoxStartPause.TabIndex = 0;
            this.checkBoxStartPause.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.checkBoxStartPause, "Start / Stop");
            this.checkBoxStartPause.UseVisualStyleBackColor = true;
            this.checkBoxStartPause.Click += new System.EventHandler(this.checkBoxStartPause_Click);
            // 
            // checkBoxSettings
            // 
            this.checkBoxSettings.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxSettings.AutoCheck = false;
            this.checkBoxSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.checkBoxSettings.FlatAppearance.BorderSize = 0;
            this.checkBoxSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxSettings.ImageIndex = 3;
            this.checkBoxSettings.ImageList = this.imageListIcons;
            this.checkBoxSettings.Location = new System.Drawing.Point(-4, 205);
            this.checkBoxSettings.Name = "checkBoxSettings";
            this.checkBoxSettings.Size = new System.Drawing.Size(45, 45);
            this.checkBoxSettings.TabIndex = 4;
            this.checkBoxSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.checkBoxSettings, "Settings");
            this.checkBoxSettings.UseVisualStyleBackColor = true;
            this.checkBoxSettings.Click += new System.EventHandler(this.checkBoxSettings_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // checkBoxTraces
            // 
            this.checkBoxTraces.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxTraces.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.checkBoxTraces.Checked = true;
            this.checkBoxTraces.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTraces.FlatAppearance.BorderSize = 0;
            this.checkBoxTraces.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxTraces.ImageIndex = 5;
            this.checkBoxTraces.ImageList = this.imageListIcons;
            this.checkBoxTraces.Location = new System.Drawing.Point(-4, 103);
            this.checkBoxTraces.Name = "checkBoxTraces";
            this.checkBoxTraces.Size = new System.Drawing.Size(45, 45);
            this.checkBoxTraces.TabIndex = 2;
            this.checkBoxTraces.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.checkBoxTraces, "Show / Hide the traces");
            this.checkBoxTraces.UseVisualStyleBackColor = true;
            this.checkBoxTraces.CheckedChanged += new System.EventHandler(this.checkBoxTraces_CheckedChanged);
            // 
            // checkBoxLog
            // 
            this.checkBoxLog.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.checkBoxLog.FlatAppearance.BorderSize = 0;
            this.checkBoxLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxLog.ImageIndex = 7;
            this.checkBoxLog.ImageList = this.imageListIcons;
            this.checkBoxLog.Location = new System.Drawing.Point(-4, 256);
            this.checkBoxLog.Name = "checkBoxLog";
            this.checkBoxLog.Size = new System.Drawing.Size(45, 45);
            this.checkBoxLog.TabIndex = 5;
            this.checkBoxLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.checkBoxLog, "Enable / Disable logging");
            this.checkBoxLog.UseVisualStyleBackColor = true;
            this.checkBoxLog.CheckedChanged += new System.EventHandler(this.checkBoxLog_CheckedChanged);
            // 
            // checkBoxGridAuto
            // 
            this.checkBoxGridAuto.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxGridAuto.AutoCheck = false;
            this.checkBoxGridAuto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.checkBoxGridAuto.Checked = true;
            this.checkBoxGridAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGridAuto.FlatAppearance.BorderSize = 0;
            this.checkBoxGridAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxGridAuto.ImageIndex = 8;
            this.checkBoxGridAuto.ImageList = this.imageListIcons;
            this.checkBoxGridAuto.Location = new System.Drawing.Point(-4, 154);
            this.checkBoxGridAuto.Name = "checkBoxGridAuto";
            this.checkBoxGridAuto.Size = new System.Drawing.Size(45, 45);
            this.checkBoxGridAuto.TabIndex = 3;
            this.checkBoxGridAuto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.checkBoxGridAuto, "Automaic / Manual grid size");
            this.checkBoxGridAuto.UseVisualStyleBackColor = true;
            this.checkBoxGridAuto.Click += new System.EventHandler(this.checkBoxGridAuto_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 10;
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 10;
            this.toolTip1.ReshowDelay = 0;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(492, 467);
            this.Controls.Add(this.checkBoxGridAuto);
            this.Controls.Add(this.checkBoxLog);
            this.Controls.Add(this.checkBoxTraces);
            this.Controls.Add(this.checkBoxStartPause);
            this.Controls.Add(this.checkBoxSettings);
            this.Controls.Add(this.checkBoxIsLabeled);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.listBoxMain);
            this.Controls.Add(this.pictureBoxMain);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Celestial Mechanics";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBoxMain)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckBox checkBoxGridAuto;
        private System.Windows.Forms.CheckBox checkBoxIsLabeled;
        private System.Windows.Forms.CheckBox checkBoxLog;
        private System.Windows.Forms.CheckBox checkBoxSettings;
        private System.Windows.Forms.CheckBox checkBoxStartPause;
        private System.Windows.Forms.CheckBox checkBoxTraces;
        private System.Windows.Forms.ImageList imageListIcons;
        private System.Windows.Forms.ListBox listBoxMain;
        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolTip toolTip1;

        //Size = new System.Drawing.Size(pictureBox1.Size.Width + 40 + 16, pictureBox1.Size.Height + 33);
        #endregion
    }
}

