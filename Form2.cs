using System;
using System.Windows.Forms;
using System.Globalization;

namespace Celestial
{
    public partial class Form2 : Form
    {
        NumberFormatInfo separator = new NumberFormatInfo() { NumberDecimalSeparator = "." };
        bool is_grid_auto_output;
        double grid_size_output;
        int points_number_output;
        int points_size_output;
        double dt_output;
        bool is_final_iteration_output;
        int final_iteration_output;

        public Form2(
            bool is_grid_auto,
            double grid_size,
            int points_number,
            int points_size,
            double dt,
            bool is_final_iteration,
            int final_iteration
            )
        {
            InitializeComponent();
            InitializeElements();

            checkBoxIsGridAuto.Checked = is_grid_auto;
            textBoxGridSize.Text = Convert.ToString(grid_size);
            textBoxNumberOfPoints.Text = Convert.ToString(points_number);
            trackBarPointSize.Value = Convert.ToInt32(points_size);
            textBoxIntegrationStep.Text = Convert.ToString(dt);
            checkBoxFinalIteration.Checked = is_final_iteration;
            textBoxFinalIteration.Text = Convert.ToString(final_iteration);
        }

        private void ApplyChanges()
        {
            Form1 FormMain = this.Owner as Form1;
            FormMain.CheckBoxSettingsUncheck();

            is_grid_auto_output = checkBoxIsGridAuto.Checked;
            points_size_output = Convert.ToInt32(trackBarPointSize.Value);
            is_final_iteration_output = checkBoxFinalIteration.Checked;

            try
            {
                grid_size_output = double.Parse(textBoxGridSize.Text);
                points_number_output = int.Parse(textBoxNumberOfPoints.Text);
                dt_output = double.Parse(textBoxIntegrationStep.Text);
                final_iteration_output = int.Parse(textBoxFinalIteration.Text);
            }
            catch (Exception) {}

            if (is_grid_auto_output == false)
            {
                FormMain.SetGridSize(grid_size_output);
            }
            else
            {
                FormMain.SetGridAuto();
            }

            FormMain.SetNumberOfPoints(points_number_output);
            FormMain.SetPointSize(points_size_output);
            FormMain.SetDt(dt_output);
            FormMain.SetIsFinalIteration(is_final_iteration_output);
            FormMain.SetFinalIteration(final_iteration_output);
        }

        private void checkBoxFinalIteration_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFinalIteration.Checked == true)
            {
                textBoxFinalIteration.Enabled = true;
            }
            else
            {
                textBoxFinalIteration.Enabled = false;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            ApplyChanges();
            this.Close();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 FormMain = this.Owner as Form1;
            FormMain.CheckBoxSettingsUncheck();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxIsGridAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIsGridAuto.Checked == true) { textBoxGridSize.Enabled = false; }
            else { textBoxGridSize.Enabled = true; }
        }

        /*
        To avoid incorrect scaling of components on the form 
        by the operating system (100%, 125%, 150%) their sizes
        and positions are set hard in the form constructor.     
        */
        private void InitializeElements()
        {

            this.labelIntegrationStep.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelIntegrationStep.Location = new System.Drawing.Point(168, 160);
            this.labelIntegrationStep.Size = new System.Drawing.Size(222, 18);

            this.labelNumberOfPoints.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNumberOfPoints.Location = new System.Drawing.Point(168, 70);
            this.labelNumberOfPoints.Size = new System.Drawing.Size(186, 18);

            this.textBoxIntegrationStep.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxIntegrationStep.Location = new System.Drawing.Point(12, 157);
            this.textBoxIntegrationStep.Size = new System.Drawing.Size(150, 26);

            this.textBoxNumberOfPoints.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNumberOfPoints.Location = new System.Drawing.Point(12, 67);
            this.textBoxNumberOfPoints.Size = new System.Drawing.Size(150, 26);
            
            this.textBoxGridSize.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxGridSize.Location = new System.Drawing.Point(12, 39);
            this.textBoxGridSize.Size = new System.Drawing.Size(150, 26);

            this.labelGridSize.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGridSize.Location = new System.Drawing.Point(168, 42);
            this.labelGridSize.Size = new System.Drawing.Size(176, 18);

            this.checkBoxFinalIteration.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxFinalIteration.Location = new System.Drawing.Point(12, 185);
            this.checkBoxFinalIteration.Size = new System.Drawing.Size(203, 22);

            this.textBoxFinalIteration.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFinalIteration.Location = new System.Drawing.Point(12, 212);
            this.textBoxFinalIteration.Size = new System.Drawing.Size(150, 26);
 
            this.labelFinalIteration.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFinalIteration.Location = new System.Drawing.Point(169, 215);
            this.labelFinalIteration.Size = new System.Drawing.Size(92, 18);

            this.buttonOk.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOk.Location = new System.Drawing.Point(188, 276);
            this.buttonOk.Size = new System.Drawing.Size(90, 30);

            this.buttonCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(287, 276);
            this.buttonCancel.Size = new System.Drawing.Size(90, 30);

            this.checkBoxIsGridAuto.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxIsGridAuto.Location = new System.Drawing.Point(12, 12);
            this.checkBoxIsGridAuto.Size = new System.Drawing.Size(152, 22);

            this.trackBarPointSize.Location = new System.Drawing.Point(3, 95);
            this.trackBarPointSize.Size = new System.Drawing.Size(168, 53);

            this.labelPointSize.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPointSize.Location = new System.Drawing.Point(168, 98);
            this.labelPointSize.Size = new System.Drawing.Size(116, 18);

            this.ClientSize = new System.Drawing.Size(387, 315);       
        }


    }
}
