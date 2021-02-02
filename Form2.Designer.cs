namespace Celestial
{
    partial class Form2
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
            this.labelIntegrationStep = new System.Windows.Forms.Label();
            this.labelNumberOfPoints = new System.Windows.Forms.Label();
            this.textBoxIntegrationStep = new System.Windows.Forms.TextBox();
            this.textBoxNumberOfPoints = new System.Windows.Forms.TextBox();
            this.textBoxGridSize = new System.Windows.Forms.TextBox();
            this.labelGridSize = new System.Windows.Forms.Label();
            this.checkBoxFinalIteration = new System.Windows.Forms.CheckBox();
            this.textBoxFinalIteration = new System.Windows.Forms.TextBox();
            this.labelFinalIteration = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkBoxIsGridAuto = new System.Windows.Forms.CheckBox();
            this.trackBarPointSize = new System.Windows.Forms.TrackBar();
            this.labelPointSize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPointSize)).BeginInit();
            this.SuspendLayout();
            // 
            // labelIntegrationStep
            // 
            this.labelIntegrationStep.AutoSize = true;
            this.labelIntegrationStep.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelIntegrationStep.Location = new System.Drawing.Point(168, 160);
            this.labelIntegrationStep.Name = "labelIntegrationStep";
            this.labelIntegrationStep.Size = new System.Drawing.Size(222, 18);
            this.labelIntegrationStep.TabIndex = 0;
            this.labelIntegrationStep.Text = "Integration step, s [0.01 - 3600]";
            // 
            // labelNumberOfPoints
            // 
            this.labelNumberOfPoints.AutoSize = true;
            this.labelNumberOfPoints.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNumberOfPoints.Location = new System.Drawing.Point(168, 70);
            this.labelNumberOfPoints.Name = "labelNumberOfPoints";
            this.labelNumberOfPoints.Size = new System.Drawing.Size(206, 18);
            this.labelNumberOfPoints.TabIndex = 1;
            this.labelNumberOfPoints.Text = "Points per trace [500 - 10000]";
            // 
            // textBoxIntegrationStep
            // 
            this.textBoxIntegrationStep.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxIntegrationStep.Location = new System.Drawing.Point(12, 157);
            this.textBoxIntegrationStep.Name = "textBoxIntegrationStep";
            this.textBoxIntegrationStep.Size = new System.Drawing.Size(150, 26);
            this.textBoxIntegrationStep.TabIndex = 4;
            this.textBoxIntegrationStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxNumberOfPoints
            // 
            this.textBoxNumberOfPoints.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNumberOfPoints.Location = new System.Drawing.Point(12, 67);
            this.textBoxNumberOfPoints.Name = "textBoxNumberOfPoints";
            this.textBoxNumberOfPoints.Size = new System.Drawing.Size(150, 26);
            this.textBoxNumberOfPoints.TabIndex = 2;
            this.textBoxNumberOfPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxGridSize
            // 
            this.textBoxGridSize.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxGridSize.Location = new System.Drawing.Point(12, 39);
            this.textBoxGridSize.Name = "textBoxGridSize";
            this.textBoxGridSize.Size = new System.Drawing.Size(150, 26);
            this.textBoxGridSize.TabIndex = 1;
            this.textBoxGridSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelGridSize
            // 
            this.labelGridSize.AutoSize = true;
            this.labelGridSize.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGridSize.Location = new System.Drawing.Point(168, 42);
            this.labelGridSize.Name = "labelGridSize";
            this.labelGridSize.Size = new System.Drawing.Size(189, 18);
            this.labelGridSize.TabIndex = 4;
            this.labelGridSize.Text = "Grid size, m [1000 - 10E20]";
            // 
            // checkBoxFinalIteration
            // 
            this.checkBoxFinalIteration.AutoSize = true;
            this.checkBoxFinalIteration.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxFinalIteration.Location = new System.Drawing.Point(12, 185);
            this.checkBoxFinalIteration.Name = "checkBoxFinalIteration";
            this.checkBoxFinalIteration.Size = new System.Drawing.Size(203, 22);
            this.checkBoxFinalIteration.TabIndex = 5;
            this.checkBoxFinalIteration.Text = "Stop calculation at iteration";
            this.checkBoxFinalIteration.UseVisualStyleBackColor = true;
            this.checkBoxFinalIteration.CheckedChanged += new System.EventHandler(this.checkBoxFinalIteration_CheckedChanged);
            // 
            // textBoxFinalIteration
            // 
            this.textBoxFinalIteration.Enabled = false;
            this.textBoxFinalIteration.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFinalIteration.Location = new System.Drawing.Point(12, 212);
            this.textBoxFinalIteration.Name = "textBoxFinalIteration";
            this.textBoxFinalIteration.Size = new System.Drawing.Size(150, 26);
            this.textBoxFinalIteration.TabIndex = 6;
            this.textBoxFinalIteration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelFinalIteration
            // 
            this.labelFinalIteration.AutoSize = true;
            this.labelFinalIteration.Enabled = false;
            this.labelFinalIteration.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFinalIteration.Location = new System.Drawing.Point(169, 215);
            this.labelFinalIteration.Name = "labelFinalIteration";
            this.labelFinalIteration.Size = new System.Drawing.Size(92, 18);
            this.labelFinalIteration.TabIndex = 7;
            this.labelFinalIteration.Text = "Final iteration";
            // 
            // buttonOk
            // 
            this.buttonOk.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOk.Location = new System.Drawing.Point(188, 276);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(90, 30);
            this.buttonOk.TabIndex = 7;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(287, 276);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(90, 30);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // checkBoxIsGridAuto
            // 
            this.checkBoxIsGridAuto.AutoSize = true;
            this.checkBoxIsGridAuto.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxIsGridAuto.Location = new System.Drawing.Point(12, 12);
            this.checkBoxIsGridAuto.Name = "checkBoxIsGridAuto";
            this.checkBoxIsGridAuto.Size = new System.Drawing.Size(152, 22);
            this.checkBoxIsGridAuto.TabIndex = 0;
            this.checkBoxIsGridAuto.Text = "Automatic grid size";
            this.checkBoxIsGridAuto.UseVisualStyleBackColor = true;
            this.checkBoxIsGridAuto.CheckedChanged += new System.EventHandler(this.checkBoxIsGridAuto_CheckedChanged);
            // 
            // trackBarPointSize
            // 
            this.trackBarPointSize.AutoSize = false;
            this.trackBarPointSize.LargeChange = 1;
            this.trackBarPointSize.Location = new System.Drawing.Point(3, 95);
            this.trackBarPointSize.Maximum = 5;
            this.trackBarPointSize.Minimum = 1;
            this.trackBarPointSize.Name = "trackBarPointSize";
            this.trackBarPointSize.Size = new System.Drawing.Size(168, 53);
            this.trackBarPointSize.TabIndex = 3;
            this.trackBarPointSize.Tag = "";
            this.trackBarPointSize.Value = 1;
            // 
            // labelPointSize
            // 
            this.labelPointSize.AutoSize = true;
            this.labelPointSize.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPointSize.Location = new System.Drawing.Point(168, 98);
            this.labelPointSize.Name = "labelPointSize";
            this.labelPointSize.Size = new System.Drawing.Size(116, 18);
            this.labelPointSize.TabIndex = 13;
            this.labelPointSize.Text = "Point size [1 - 5]";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 315);
            this.Controls.Add(this.labelPointSize);
            this.Controls.Add(this.trackBarPointSize);
            this.Controls.Add(this.checkBoxIsGridAuto);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBoxFinalIteration);
            this.Controls.Add(this.labelFinalIteration);
            this.Controls.Add(this.checkBoxFinalIteration);
            this.Controls.Add(this.textBoxGridSize);
            this.Controls.Add(this.labelGridSize);
            this.Controls.Add(this.textBoxNumberOfPoints);
            this.Controls.Add(this.textBoxIntegrationStep);
            this.Controls.Add(this.labelNumberOfPoints);
            this.Controls.Add(this.labelIntegrationStep);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPointSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelIntegrationStep;
        private System.Windows.Forms.Label labelNumberOfPoints;
        private System.Windows.Forms.TextBox textBoxIntegrationStep;
        private System.Windows.Forms.TextBox textBoxNumberOfPoints;
        private System.Windows.Forms.TextBox textBoxGridSize;
        private System.Windows.Forms.Label labelGridSize;
        private System.Windows.Forms.CheckBox checkBoxFinalIteration;
        private System.Windows.Forms.TextBox textBoxFinalIteration;
        private System.Windows.Forms.Label labelFinalIteration;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxIsGridAuto;
        private System.Windows.Forms.TrackBar trackBarPointSize;
        private System.Windows.Forms.Label labelPointSize;
    }
}