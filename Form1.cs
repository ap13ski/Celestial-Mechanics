using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using VectorLibrary;
using ParticleLibrary;

namespace Celestial
{
    public partial class Form1 : Form
    {
        NumberFormatInfo separator = new NumberFormatInfo() { NumberDecimalSeparator = "." };

        Random rnd = new Random();
        Graphics graphics_main;
        
        ulong global_time = 0UL;

        static int particles_number = 5; // Number of particles
        static int trace_points_number = 500; // Starting number of points per particle trace
        static int trace_points_size = 1; // Starting size of the particle's trace points

        bool is_labeled = true;
        bool is_traced = true;
        bool is_logged = false;
        bool is_grid_size_auto = true;

        bool is_form_settings_opened = false;
        bool is_form_presets_opened = false;
        bool is_final_iteration = false;
        static int final_iteration = 0;

        Vector[] r = new Vector[particles_number];
        Vector[] v = new Vector[particles_number];
        double[] m = new double[particles_number];
        Particle[] p = new Particle[particles_number]; // Global array of the paticles (Jupiter, Io, Europa, Ganymede, Callisto)
        bool is_particles_array_loaded = false; // Variable to control the state of Patricle[] array.

        double[,] R = new double[particles_number, particles_number];
        double[,] A = new double[particles_number, particles_number];
        Vector[,] dv = new Vector[particles_number, particles_number];

        double[,] C = new double[1, particles_number * 2];
        double[,] D = new double[1, particles_number * 2];
        double[] c = new double[particles_number];
        double[] d = new double[particles_number];


        bool is_mouse_down = false;
        int old_x, old_y;

        static VectorLibrary.Point point = new VectorLibrary.Point(0, 0);
        static double dt = 200;
        static double global_scale_factor = 1;
        static double grid_size = 0.5 * Math.Pow(10, 9);
        static int iteration_counter = 0;                      // Number of iterations
        static string count_speed;

        const double G = 6.6743E-11;          // Gravitational constant

        public Form1()
        {
            InitializeComponent();
            InitializeElements();
            InitializeParticles();

            point.SetPoint(pictureBoxMain.Width / 2, pictureBoxMain.Height / 2);

            // Mouse event handler in this_MouseWheel() method
            MouseWheel += new MouseEventHandler(this_MouseWheel);

            // Jupiter
            p[0].R.SetVectorByPoints(0, 0, 0, 0);
            p[0].V.SetVectorByAngle(0, 0, 0, 0);
            p[0].M = 1.8982 * Math.Pow(10, 27);
            p[0].Name = "Jupiter";
            // Io 
            p[1].R.SetVectorByPoints(0, 0, -4.217 * Math.Pow(10, 8), 0);
            p[1].V.SetVectorByAngle(0, 0, 17334, 270);
            p[1].M = 8.931938 * Math.Pow(10, 22);
            p[1].Name = "Io";
            //Europa
            p[2].R.SetVectorByPoints(0, 0, 6.709 * Math.Pow(10, 8), 0);
            p[2].V.SetVectorByAngle(0, 0, 13740, 90);
            p[2].M = 4.799844 * Math.Pow(10, 22);
            p[2].Name = "Europa";
            //Ganymede
            p[3].R.SetVectorByPoints(0, 0, 1.0704 * Math.Pow(10, 9), 0);
            p[3].V.SetVectorByAngle(0, 0, 10880, 90);
            p[3].M = 1.4819 * Math.Pow(10, 23);
            p[3].Name = "Ganymede";
            //Callisto
            p[4].R.SetVectorByPoints(0, 0, -1.8827 * Math.Pow(10, 9), 0);
            p[4].V.SetVectorByAngle(0, 0, 8204, 270);
            p[4].M = 1.075938 * Math.Pow(10, 23);
            p[4].Name = "Callisto";

            // // Earth
            // p[0].R.SetVectorByPoints(0, 0, 0, 0);
            // p[0].V.SetVectorByAngle(0, 0, 0, 0);
            // p[0].M = 5.97237 * Math.Pow(10, 24);
            // p[0].Name = "Earth";
            // // Moon
            // p[1].R.SetVectorByPoints(0, 0, 3.84399 * Math.Pow(10, 8), 0);
            // p[1].V.SetVectorByAngle(0, 0, 1022, 90);
            // p[1].M = 7.342 * Math.Pow(10, 22);
            // p[1].Name = "Moon";

            is_particles_array_loaded = true;

            SetGridSizeHard();

            LogStart();
            LogNext();

            CreateResults(iteration_counter);

            SetKoef();

            LoadScreen();
            DrawVectors();
            
            pictureBoxMain.Refresh();
        }

        private void DrawEllipces()
        {
            // particles_number = 5; -->> class Form1 : Form {}
            DrawEllipse(p[0].R, Brushes.DarkKhaki, 18, is_labeled, p[0].Name);
            DrawEllipse(p[1].R, Brushes.DarkOrange, 8, is_labeled, p[1].Name);
            DrawEllipse(p[2].R, Brushes.WhiteSmoke, 8, is_labeled, p[2].Name);
            DrawEllipse(p[3].R, Brushes.Gray, 12, is_labeled, p[3].Name);
            DrawEllipse(p[4].R, Brushes.DarkViolet, 12, is_labeled, p[4].Name);
            
            // particles_number = 2; -->> class Form1 : Form {}
            // DrawEllipse(p[0].R, Brushes.DarkGreen, 18, is_labeled, p[0].Name);
            // DrawEllipse(p[1].R, Brushes.DarkGray, 10, is_labeled, p[1].Name);
        }

        private void LogStart()
        {
            string str_log = string.Format("Iteration;Time(step={0}s);", dt);
            
            for (int i = 0; i < p.Length; i++)
            {
                string str_add = string.Format("[{0}]{1}_X;[{2}]{3}_Y;", i, p[i].Name, i, p[i].Name);
                str_log += str_add;
            }
            listBoxMain.Items.Add(str_log);
        }

        private void LogNext()
        {
            string str_log = string.Format("{0};{1};", iteration_counter, iteration_counter * dt);

            for (int i = 0; i < p.Length; i++)
            {
                string str_add = string.Format("{0};{1};", p[i].R.X2, p[i].R.Y2);
                str_log += str_add;
            }
            listBoxMain.Items.Add(str_log);
            //listBoxMain.TopIndex = listBoxMain.Items.Count - 1;
        }

        private void SetGridSizeHard()
        {
            double value_max = GetValues().Max();
            double power = Math.Truncate(Math.Log10(value_max));
            grid_size = Math.Pow(10, power);
        }

        private void SetGridSizeManual()
        {
            if (is_grid_size_auto == false) { SetGridSizeHard(); }
        }

        private void SetGridSizeAuto()
        {
            double scale_factor = 2.5;
            if (is_grid_size_auto == true)
            {
                int w = pictureBoxMain.Width;
                int h = pictureBoxMain.Height;
                int m = GetMin(w, h);

                double power = Math.Truncate(Math.Log10(m * global_scale_factor / scale_factor));
                grid_size = Math.Pow(10, power);
            }
        }

        private int GetMax(int a1, int a2)
        {
            if (a1 >= a2)
                { return a1; }
            else
                { return a2; }
        }

        private int GetMin(int a1, int a2)
        {
            if (a1 <= a2)
                { return a1; }
            else
                { return a2; }
        }

        private double[] GetValues()
        {
            double[] values = new double[p.Length];
            for (int i = 0; i < p.Length; i++)
            {
                double abs_x2 = Math.Abs(p[i].R.X2);
                double abs_y2 = Math.Abs(p[i].R.Y2);
                if (abs_x2 >= abs_y2)
                    { values[i] = abs_x2; }
                else
                    { values[i] = abs_y2; }
            }
            return values;
        }

        private void SetKoef()
        {
            int scale_grid_factor = 200;
            global_scale_factor = GetValues().Max() / scale_grid_factor;
        }

        private void DrawVectors()
        {
            UpdateGrid();
            DrawTraces();
            DrawEllipces();
            DrawCalculationinfo();
            if (is_logged == true)
                { LogNext(); }
        }

        private void DrawTraces()
        {
            if (is_traced == true)
            {
                int h;
                int scale = 2;

                if (iteration_counter < trace_points_number)
                    { h = 1; }
                else
                    { h = iteration_counter / trace_points_number; }

                for (int i = 0; i < C.GetLength(0); i = i + h)
                {
                    for (int j = 0; j < particles_number; j++)
                    {
                        double c_x = C[i, j * scale];
                        double c_y = C[i, j * scale + 1];
                        graphics_main.FillRectangle(
                            Brushes.DimGray,
                            Convert.ToSingle(ConX(c_x, global_scale_factor)),
                            Convert.ToSingle(ConY(c_y, global_scale_factor)),
                            trace_points_size, trace_points_size);
                    }
                }
            }
        }

        private void UpdateGrid()
        {
            int grid_scale_factor = 2;
            graphics_main.Clear(Color.FromArgb(255, 0, 0, 0));
            Pen pen_gray_dark = new Pen(Color.FromArgb(255, 40, 40, 40));
            Pen pen_gray_light = new Pen(Color.FromArgb(255, 80, 80, 80));

            int w = pictureBoxMain.Width;
            int h = pictureBoxMain.Height;

            double step_x = (w / grid_scale_factor) * global_scale_factor / grid_size;
            double step_y = (h / grid_scale_factor) * global_scale_factor / grid_size;

            for (int i = 1; i <= Math.Truncate(step_y) * grid_scale_factor; i++)
            {
                float new_up = Convert.ToSingle((point.Y) + i * grid_size / global_scale_factor);
                float new_down = Convert.ToSingle((point.Y) - i * grid_size / global_scale_factor);
                graphics_main.DrawLine(pen_gray_dark, 0, new_up, w, new_up);
                graphics_main.DrawLine(pen_gray_dark, 0, new_down, w, new_down);
            }

            for (int i = 1; i <= Math.Truncate(step_x) * grid_scale_factor; i++)
            {
                float new_left = Convert.ToSingle((point.X) + i * grid_size / global_scale_factor);
                float new_right = Convert.ToSingle((point.X) - i * grid_size / global_scale_factor);
                graphics_main.DrawLine(pen_gray_dark, new_left, 0, new_left, h);
                graphics_main.DrawLine(pen_gray_dark, new_right, 0, new_right, h);
            }

            graphics_main.DrawLine(pen_gray_light, point.X, 0, point.X, h);
            graphics_main.DrawLine(pen_gray_light, 0, point.Y, w, point.Y);
        }

        private void UpdateVectors()
        {
            double power = 2;
            for (int i = 0; i < p.Length; i++)
            {
                for (int j = 0; j < p.Length; j++)
                {
                    R[i, j] = Vector.GetMagnitude(p[i].R.X2, p[i].R.Y2, p[j].R.X2, p[j].R.Y2);
                    A[i, j] = Vector.GetAngleByPoints(p[i].R.X2, p[i].R.Y2, p[j].R.X2, p[j].R.Y2);
                    if (i != j)
                    {
                        dv[i, j].SetVectorByAngle(0, 0, G * p[j].M * dt / Math.Pow(R[i, j], power), A[i, j]);
                    }
                }
            }

            for (int i = 0; i < p.Length; i++)
            {
                for (int j = 0; j < p.Length; j++)
                {
                    p[i].V.SetVectorByPoints(p[i].V + dv[i, j]);
                }
            }

            for (int i = 0; i < p.Length; i++)
            {
                p[i].R.SetVectorByPoints(p[i].R + p[i].V * dt);
            }
        }
        private void InitializeParticles()
        {
            for (int i = 0; i < p.Length; i++)
            {
                r[i] = new Vector(0, 0, 0, 0);
                v[i] = new Vector(0, 0, 0, 0);
                m[i] = 0;
                p[i] = new Particle(r[i], v[i], m[i]);

                for (int j = 0; j < p.Length; j++)
                {
                    dv[i, j] = new Vector(0, 0, 0, 0);
                }
            }
        }

        private void LoadScreen()
        {
            pictureBoxMain.Image = new Bitmap(pictureBoxMain.Width, pictureBoxMain.Height);
            graphics_main = Graphics.FromImage(pictureBoxMain.Image);
            UpdateGrid();
        }

        private int ConX(int x, double scale_factor)
        {
            try
            {
                // The unsafe type conversion requires exception processing.
                x = Convert.ToInt32(Math.Truncate(x / scale_factor + point.X));
                return x;
            }
            catch (Exception) { return 0; }
        }
        
        private int ConY(int y, double scale_factor)
        {
            try
            {
                // The unsafe type conversion requires exception processing.
                y = Convert.ToInt32(Math.Truncate(-y / scale_factor + point.Y));
                return y;
            }
            catch (Exception) { return 0; }
        }
        
        private int ConX(double x, double scale_factor)
        {
            try
            {
                // The unsafe type conversion requires exception processing.
                int output = Convert.ToInt32(Math.Truncate(x / scale_factor + point.X));
                return output;
            }
            catch (Exception) { return 0; }
        }
        
        private int ConY(double y, double scale_factor)
        {
            try
            {
                // The unsafe type conversion requires exception processing.
                int output = Convert.ToInt32(Math.Truncate(-y / scale_factor + point.Y));
                return output;
            }
            catch (Exception) { return 0; }
        }

        private void DrawVector(Vector vector, Pen pen)
        {
            DrawArrow(vector.X1, vector.Y1, vector.X2, vector.Y2, pen);
        }

        private void DrawVector(Vector vector, Pen pen, double k)
        {
            DrawArrow(vector.X1, vector.Y1, vector.X2 * k, vector.Y2 * k, pen);
        }

        private void DrawArrow(double x1, double y1, double x2, double y2, Pen pen)
        {
            graphics_main.DrawLine(pen,
                Convert.ToSingle(ConX(x1, global_scale_factor)),
                Convert.ToSingle(ConY(y1, global_scale_factor)),
                Convert.ToSingle(ConX(x2, global_scale_factor)),
                Convert.ToSingle(ConY(y2, global_scale_factor)));
        }
        
        private void DrawEllipse(Vector vector, Brush brush, int size, bool isLabeled, string name)
        {
            int scale = 2;
            if (isLabeled == true)
            {
                string str_name = string.Format("{0}", name);
                graphics_main.FillEllipse(brush,
                    Convert.ToSingle(ConX(vector.X2, global_scale_factor) - size / scale),
                    Convert.ToSingle(ConY(vector.Y2, global_scale_factor) - size / scale),
                    size, size);
                graphics_main.DrawString(str_name, new Font("Arial", 10f), brush,
                    Convert.ToSingle(ConX(vector.X2, global_scale_factor)),
                    Convert.ToSingle(ConY(vector.Y2, global_scale_factor)));
            }
            else
            {
                graphics_main.FillEllipse(brush,
                    Convert.ToSingle(ConX(vector.X2, global_scale_factor) - size / scale),
                    Convert.ToSingle(ConY(vector.Y2, global_scale_factor) - size / scale),
                    size, size);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (is_final_iteration == true && iteration_counter >= final_iteration)
            {
                StopTimers();
            }
            else
            {
                iteration_counter++;
                UpdateVectors();
                DrawVectors();
                pictureBoxMain.Refresh();
                UpdateResults();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string dirpath = Application.StartupPath;
            string date =
                  DateTime.Now.Year.ToString() + "-"
                + DateTime.Now.Month.ToString() + "-"
                + DateTime.Now.Day.ToString() + "-"
                + DateTime.Now.Hour.ToString() + "-"
                + DateTime.Now.Minute.ToString() + "-"
                + DateTime.Now.Second.ToString() + "-"
                + DateTime.Now.Millisecond.ToString();
            
            string str_fullpath = string.Format("{0}\\{1}.csv", dirpath, date);
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(str_fullpath))
            {
                for (int i = 0; i < listBoxMain.Items.Count; i++)
                    sw.WriteLine(listBoxMain.Items[i].ToString());
            }

        }

        private void checkBoxIsLabeled_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIsLabeled.Checked == true)
                { is_labeled = true; }
            else
                { is_labeled = false; }
            
            UpdateGrid();
            DrawTraces();
            DrawEllipces();
            DrawCalculationinfo();
            pictureBoxMain.Refresh();
        }

        private void DrawCalculationinfo()
        {
            int shift = 20;
            string str_gridsize_format_normal = String.Format("{0:N0}", grid_size);
            string str_gridsize_format_scientific = String.Format("{0:E0}", grid_size);
            
            string str_information = String.Format("Iteration: {0} Time: {1} s Speed: {2} Elapsed: {3} s", iteration_counter, iteration_counter * dt, count_speed, global_time);
            string str_gridsize = String.Format("Grid size: {0} m ({1} m)", str_gridsize_format_normal, str_gridsize_format_scientific);
            
            graphics_main.DrawString(str_information, new Font("Arial", 10f), Brushes.DarkGray, 0, 0);
            graphics_main.DrawString(str_gridsize, new Font("Arial", 10f), Brushes.DarkGray, 0, pictureBoxMain.Height - shift);
        }

        private void UpdateScale()
        {
            SetGridSizeAuto();
            UpdateGrid();
            DrawTraces();
            DrawEllipces();
            DrawCalculationinfo();
            pictureBoxMain.Refresh();
        }

        private void checkBoxStartPause_Click(object sender, EventArgs e)
        {
            if (is_form_settings_opened == false && is_form_presets_opened == false)
            {
                if (timer1.Enabled == false)
                    { StartTimers(); }
                else
                    { StopTimers(); }
            }
        }

        private void StopCalculation()
        {
            checkBoxStartPause.Checked = false;
            StopTimers();
        }

        private void StartTimers()
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
            checkBoxStartPause.Image = imageListIcons.Images[1];
            checkBoxStartPause.Checked = true;
        }

        private void StopTimers()
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            checkBoxStartPause.Image = imageListIcons.Images[0];
            checkBoxStartPause.Checked = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            const int const1 = 40;
            const int const2 = 16;
            const int const3 = 33;
            try
            {
                if (is_particles_array_loaded == true)
                {
                    pictureBoxMain.Size = new System.Drawing.Size(Size.Width - const1 - const2, Size.Height - const3);
                    LoadScreen();
                    DrawTraces();
                    DrawEllipces();
                    DrawCalculationinfo();
                }
            }
            catch (Exception)
            {
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                is_mouse_down = false;
                pictureBoxMain.Cursor = System.Windows.Forms.Cursors.Default;
            }

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                is_mouse_down = true;
                pictureBoxMain.Cursor = System.Windows.Forms.Cursors.Hand;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (is_mouse_down == true)
            {
                int delta_x = e.X - old_x;
                int delta_y = e.Y - old_y;
                point.SetPoint(point.X + delta_x, point.Y + delta_y);
                DrawVectors();
                pictureBoxMain.Refresh();
            }
            old_x = e.X;
            old_y = e.Y;
        }

        // The mouse wheel scrolling event handler changes the opacity
        // of the form.
        private void this_MouseWheel(object sender, MouseEventArgs e)
        {
            double scale_down = 0.9;
            double scale_up = 1.1;
            int scale_max = 10;

            if (e.Delta > 0 && global_scale_factor > scale_max)
            {
                global_scale_factor = global_scale_factor * scale_down;
                UpdateScale();
            }
            if (e.Delta < 0)
            {
                global_scale_factor = global_scale_factor * scale_up;
                UpdateScale();
            }
        }

        static double[,] CloneArray(double[,] input)
        {
            double[,] output = new double[input.GetLength(0), input.GetLength(1)];
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    output[i, j] = input[i, j];
                }
            }
            return output;
        }

        static void CloneArrayData(double[,] input, double[,] output)
        {
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    output[i, j] = input[i, j];
                }
            }
        }

        static double[,] IncreaseArray(double[,] input)
        {
            double[,] output = new double[input.GetLength(0) + 1, input.GetLength(1)];
            CloneArrayData(input, output);
            return output;
        }

        private void CreateResults(int iteration_number)
        {
            int results_per_particle = 2;
            for (int i = 0; i < particles_number; i++)
            {
                c[i] = p[i].R.X2;
                d[i] = p[i].R.Y2;
            }

            for (int i = 0; i < particles_number; i++)
            {
                C[iteration_number, i * results_per_particle] = c[i];
                C[iteration_number, i * results_per_particle + 1] = d[i];
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            global_time++;
            count_speed = string.Format("{0} i/s", Math.Round(iteration_counter * 1.0 / global_time, 1));
        }

        private void checkBoxLog_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLog.Checked == true)
            {
                is_logged = true;
                checkBoxLog.ImageIndex = 6;
            }
            else
            {
                is_logged = false;
                checkBoxLog.ImageIndex = 7;
            }
        }

        private void checkBoxTraces_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTraces.Checked == true)
                { is_traced = true; }
            else
                { is_traced = false; }
            UpdateGrid();
            DrawTraces();
            DrawEllipces();
            DrawCalculationinfo();
            pictureBoxMain.Refresh();
        }

        private void checkBoxSettings_Click(object sender, EventArgs e)
        {
            if (checkBoxSettings.Checked == false)
            {
                if (is_form_settings_opened == false)
                {
                    StopTimers();
                    checkBoxSettings.Checked = true;
                    is_form_settings_opened = true;
                    Form2 FormSettings = new Form2(is_grid_size_auto, grid_size, trace_points_number, trace_points_size, dt, is_final_iteration, final_iteration);
                    FormSettings.Owner = this;
                    FormSettings.Show();
                }
            }
        }

        private void UpdateResults()
        {
            C = IncreaseArray(C);
            D = CloneArray(C);
            CreateResults(iteration_counter);
        }

        public void CheckBoxSettingsUncheck()
        {
            checkBoxSettings.Checked = false;
            checkBoxSettings.CheckState = 0;
            is_form_settings_opened = false;
        }

        public void SetGridAuto()
        {
            is_grid_size_auto = true;
            checkBoxGridAuto.Checked = true;
            checkBoxGridAuto.ImageIndex = 8;
            UpdateScale();
        }

        public void SetGridSize(double value)
        {
            if (value >= 1000 && value <= Math.Pow(10, 20))
            {
                is_grid_size_auto = false;
                checkBoxGridAuto.Checked = false;
                checkBoxGridAuto.ImageIndex = 9;
                grid_size = value;
                UpdateScale();
            }
        }

        public void SetPointSize(int value)
        {
            trace_points_size = value;
            UpdateVisibleObjects();
        }

        public void SetNumberOfPoints(int value)
        {
            int min_number_of_points = 500;
            int max_number_of_points = 10000;
            if (value >= min_number_of_points && value <= max_number_of_points)
            {
                trace_points_number = value;
                UpdateVisibleObjects();
            }
        }

        public void UpdateVisibleObjects()
        {
            UpdateGrid();
            DrawTraces();
            DrawEllipces();
            DrawCalculationinfo();
            pictureBoxMain.Refresh();
        }

        public void SetDt(double value)
        {
            double integration_step_min = 0.01;
            double integration_step_max = 3600;
            if (value >= integration_step_min && value <= integration_step_max)
                { dt = value; }
        }

        public void SetIsFinalIteration(bool value)
        {
            is_final_iteration = value;
        }

        private void checkBoxGridAuto_Click(object sender, EventArgs e)
        {
            if (is_form_settings_opened == false)
            {
                if (checkBoxGridAuto.Checked == true)
                {
                    is_grid_size_auto = false;
                    checkBoxGridAuto.Checked = false;
                    checkBoxGridAuto.ImageIndex = 9;
                }
                else
                {
                    is_grid_size_auto = true;
                    checkBoxGridAuto.Checked = true;
                    checkBoxGridAuto.ImageIndex = 8;
                    UpdateScale();
                }
            }
        }

        public void SetFinalIteration(int value)
        {
            if (value >= 0)
                { final_iteration = value; }
        }

        /*
        To avoid incorrect scaling of components on the form 
        by the operating system (100%, 125%, 150%) their sizes
        and positions are set hard in the form constructor.     
        */
        private void InitializeElements()
        {
            pictureBoxMain.Location = new System.Drawing.Point(48, 0);
            pictureBoxMain.Size = new System.Drawing.Size(500, 500);

            Size = new System.Drawing.Size(pictureBoxMain.Size.Width + 40 + 16, pictureBoxMain.Size.Height + 33);

            checkBoxStartPause.Location = new System.Drawing.Point(3, 4);
            checkBoxStartPause.Size = new System.Drawing.Size(40, 40);

            checkBoxIsLabeled.Location = new System.Drawing.Point(3, 48);
            checkBoxIsLabeled.Size = new System.Drawing.Size(40, 40);

            checkBoxTraces.Location = new System.Drawing.Point(3, 92);
            checkBoxTraces.Size = new System.Drawing.Size(40, 40);

            checkBoxGridAuto.Location = new System.Drawing.Point(3, 136);
            checkBoxGridAuto.Size = new System.Drawing.Size(40, 40);

            checkBoxSettings.Location = new System.Drawing.Point(3, 180);
            checkBoxSettings.Size = new System.Drawing.Size(40, 40);
            checkBoxSettings.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));

            checkBoxLog.Location = new System.Drawing.Point(3, 224);
            checkBoxLog.Size = new System.Drawing.Size(40, 40);
            checkBoxLog.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));

            buttonSave.Location = new System.Drawing.Point(3, 268);
            buttonSave.Size = new System.Drawing.Size(40, 40);
            buttonSave.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));

        }
    }
}
