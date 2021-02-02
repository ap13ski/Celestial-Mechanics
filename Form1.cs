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
        Graphics graphics;

        static int globalTime = 0;

        static int n = 5; // Number of particles
        static int numberOfPoints = 500; // Starting number of points per particle trace
        static byte pointSize = 1; // Starting size of the particle's trace points

        bool isLabeled = true;
        bool isTraced = true;
        bool isLogged = false;
        bool isGridAuto = true;

        bool isFormSettingsOpened = false;
        bool isFormPresetsOpened = false;
        bool isFinalIteration = false;
        static int finalIteration = 0;

        Vector[] r = new Vector[n];
        Vector[] v = new Vector[n];
        double[] m = new double[n];
        Particle[] p = new Particle[n]; // Global array of the paticles (Jupiter, Io, Europa, Ganymede, Callisto)
        bool isParticlesArrayLoaded = false; // Variable to control the state of Patricle[] array.

        double[,] R = new double[n, n];
        double[,] A = new double[n, n];
        Vector[,] dv = new Vector[n, n];

        double[,] C = new double[1, n * 2];
        double[,] D = new double[1, n * 2];
        double[] c = new double[n];
        double[] d = new double[n];


        bool isMouseDown = false;
        int oldX, oldY;

        static VectorLibrary.Point point = new VectorLibrary.Point(0, 0);
        static double dt = 200;
        static double koef = 1;
        static double gridsize = 0.5 * Math.Pow(10, 9);
        static int iterations = 0;                      // Number of iterations
        static string countSpeed;

        double G = 6.6743 * Math.Pow(10, -11);          // Gravitational constant
        static string log;


        /// <summary>
        /// PRESETS BLOCK
        /// </summary>
        /// 

        /* Jupiter preset
        INFO:
        Set n = 5
        Copy to Form1()

        // Jupiter
        p[0].R.SetVectorByPoints(0, 0, 0, 0);
        p[0].V.SetVectorByAngle(0, 0, 0, 0);
        p[0].M = 1.8982 * Math.Pow(10, 27);
        p[0].Name = "Jupiter";
        // Io 
        p[1].R.SetVectorByPoints(0, 0, 4.217 * Math.Pow(10, 8), 0);
        p[1].V.SetVectorByAngle(0, 0, 17334, 90);
        p[1].M = 8.931938 * Math.Pow(10, 22);
        p[1].Name = "Io";
        //Europa
        p[2].R.SetVectorByPoints(0, 0, 6.709 * Math.Pow(10, 8), 0);
        p[2].V.SetVectorByAngle(0, 0, 13740, 90);
        p[2].M = 4.799844 * Math.Pow(10, 22);
        p[2].Name = "Europa";
        //Ganymede
        p[3].R.SetVectorByPoints(0, 0, -1.0704 * Math.Pow(10, 9), 0);
        p[3].V.SetVectorByAngle(0, 0, 10880, 270);
        p[3].M = 1.4819 * Math.Pow(10, 23);
        p[3].Name = "Ganymede";
        //Callisto
        p[4].R.SetVectorByPoints(0, 0, -1.8827 * Math.Pow(10, 9), 0);
        p[4].V.SetVectorByAngle(0, 0, 8204, 270);
        p[4].M = 1.075938 * Math.Pow(10, 23);
        p[4].Name = "Callisto";

        // Copy to DrawEllipces()
        DrawEllipse(p[0].R, Brushes.DarkKhaki, 18, isLabeled, p[0].Name);
        DrawEllipse(p[1].R, Brushes.DarkOrange, 8, isLabeled, p[1].Name);
        DrawEllipse(p[2].R, Brushes.WhiteSmoke, 8, isLabeled, p[2].Name);
        DrawEllipse(p[3].R, Brushes.Gray, 12, isLabeled, p[3].Name);
        DrawEllipse(p[4].R, Brushes.DarkViolet, 12, isLabeled, p[4].Name);
        */

        /*Earth preset
        INFO:
        Set n = 2
        Copy to Form1()

        // Earth
        p[0].R.SetVectorByPoints(0, 0, 0, 0);
        p[0].V.SetVectorByAngle(0, 0, 0, 0);
        p[0].M = 5.97237 * Math.Pow(10, 24);
        p[0].Name = "Earth";
        // Moon
        p[1].R.SetVectorByPoints(0, 0, 3.84399 * Math.Pow(10, 8), 0);
        p[1].V.SetVectorByAngle(0, 0, 1022, 90);
        p[1].M = 7.342 * Math.Pow(10, 22);
        p[1].Name = "Moon";


        // Copy to DrawEllipces()
        DrawEllipse(p[0].R, Brushes.DarkGreen, 18, isLabeled, p[0].Name);
        DrawEllipse(p[1].R, Brushes.DarkGray, 10, isLabeled, p[1].Name);
        */

        public Form1()
        {
            InitializeComponent();
            InitializeElements();
            InitializeParticles();

            point.SetPoint(pictureBox1.Width / 2, pictureBox1.Height / 2);

            // Mouse event handler in this_MouseWheel() method
            MouseWheel += new MouseEventHandler(this_MouseWheel);

            // Jupiter
            p[0].R.SetVectorByPoints(0, 0, 0, 0);
            p[0].V.SetVectorByAngle(0, 0, 0, 0);
            p[0].M = 1.8982 * Math.Pow(10, 27);
            p[0].Name = "Jupiter";
            // Io 
            p[1].R.SetVectorByPoints(0, 0, 4.217 * Math.Pow(10, 8), 0);
            p[1].V.SetVectorByAngle(0, 0, 17334, 90);
            p[1].M = 8.931938 * Math.Pow(10, 22);
            p[1].Name = "Io";
            //Europa
            p[2].R.SetVectorByPoints(0, 0, 6.709 * Math.Pow(10, 8), 0);
            p[2].V.SetVectorByAngle(0, 0, 13740, 90);
            p[2].M = 4.799844 * Math.Pow(10, 22);
            p[2].Name = "Europa";
            //Ganymede
            p[3].R.SetVectorByPoints(0, 0, -1.0704 * Math.Pow(10, 9), 0);
            p[3].V.SetVectorByAngle(0, 0, 10880, 270);
            p[3].M = 1.4819 * Math.Pow(10, 23);
            p[3].Name = "Ganymede";
            //Callisto
            p[4].R.SetVectorByPoints(0, 0, -1.8827 * Math.Pow(10, 9), 0);
            p[4].V.SetVectorByAngle(0, 0, 8204, 270);
            p[4].M = 1.075938 * Math.Pow(10, 23);
            p[4].Name = "Callisto";

            isParticlesArrayLoaded = true;

            SetGridSizeHard();

            LogStart();
            LogNext();

            CreateResults(iterations);

            SetKoef();

            LoadScreen();
            DrawVectors();
            
            pictureBox1.Refresh();
        }

        private void DrawEllipces()
        {
            DrawEllipse(p[0].R, Brushes.DarkKhaki, 18, isLabeled, p[0].Name);
            DrawEllipse(p[1].R, Brushes.DarkOrange, 8, isLabeled, p[1].Name);
            DrawEllipse(p[2].R, Brushes.WhiteSmoke, 8, isLabeled, p[2].Name);
            DrawEllipse(p[3].R, Brushes.Gray, 12, isLabeled, p[3].Name);
            DrawEllipse(p[4].R, Brushes.DarkViolet, 12, isLabeled, p[4].Name);
        }

        private void LogStart()
        {
            log = $"Iteration;Time(step={dt}s);";
            for (int i = 0; i < p.Length; i++)
            {
                log += $"[{i}]{p[i].Name}_X;[{i}]{p[i].Name}_Y;";
            }
            listBox1.Items.Add(log);
        }

        private void LogNext()
        {
            log = $"{iterations};{iterations * dt};";
            for (int i = 0; i < p.Length; i++)
            {
                log += $"{p[i].R.X2};{p[i].R.Y2};";
            }
            listBox1.Items.Add(log);
            //listBox1.TopIndex = listBox1.Items.Count - 1;
        }

        private void SetGridSizeHard()
        {
            double maxvalue = GetValues().Max();
            double order = Math.Truncate(Math.Log10(maxvalue));
            gridsize = Math.Pow(10, order);
        }

        private void SetGridSizeManual()
        {
            if (isGridAuto == false) { SetGridSizeHard(); }
        }

        private void SetGridSizeAuto()
        {
            double scale = 2.5;
            if (isGridAuto == true)
            {
                int w = pictureBox1.Width;
                int h = pictureBox1.Height;
                int m = GetMin(w, h);

                double order = Math.Truncate(Math.Log10(m * koef / scale));
                gridsize = Math.Pow(10, order);
            }
        }

        private int GetMax(int a1, int a2)
        {
            if (a1 >= a2) { return a1; }
            else { return a2; }
        }

        private int GetMin(int a1, int a2)
        {
            if (a1 <= a2) { return a1; }
            else { return a2; }
        }

        private double[] GetValues()
        {
            double[] values = new double[p.Length];
            for (int i = 0; i < p.Length; i++)
            {
                if (Math.Abs(p[i].R.X2) >= Math.Abs(p[i].R.Y2)) { values[i] = Math.Abs(p[i].R.X2); }
                else { values[i] = Math.Abs(p[i].R.Y2); }
            }
            return values;
        }

        private void SetKoef()
        {
            int scalegrid = 200;
            koef = GetValues().Max() / scalegrid;
        }

        private void DrawVectors()
        {
            UpdateGrid();
            DrawTraces();
            DrawEllipces();
            DrawCalculationinfo();
            if (isLogged == true) { LogNext(); }
        }

        private void DrawTraces()
        {
            if (isTraced == true)
            {
                int h;
                int scale = 2;

                if (iterations < numberOfPoints) { h = 1; }
                else { h = iterations / numberOfPoints; }

                for (int i = 0; i < C.GetLength(0); i = i + h)
                {
                    for (int j = 0; j < n; j++)
                    {
                        double cX = C[i, j * scale];
                        double cY = C[i, j * scale + 1];
                        graphics.FillRectangle(
                            Brushes.DimGray,
                            Convert.ToSingle(ConX(cX, koef)),
                            Convert.ToSingle(ConY(cY, koef)),
                            pointSize, pointSize);
                    }
                }
            }
        }

        private void UpdateGrid()
        {
            int scalegrid = 2;
            graphics.Clear(Color.FromArgb(255, 0, 0, 0));
            Pen penGray = new Pen(Color.FromArgb(255, 40, 40, 40));
            Pen penGray2 = new Pen(Color.FromArgb(255, 80, 80, 80));

            int w = pictureBox1.Width;
            int h = pictureBox1.Height;

            double stepY = (h / scalegrid) * koef / gridsize;
            double stepX = (w / scalegrid) * koef / gridsize;

            for (int i = 1; i <= Math.Truncate(stepY) * scalegrid; i++)
            {
                float newUp = Convert.ToSingle((point.Y) + i * gridsize / koef);
                float newDown = Convert.ToSingle((point.Y) - i * gridsize / koef);
                graphics.DrawLine(penGray, 0, newUp, w, newUp);
                graphics.DrawLine(penGray, 0, newDown, w, newDown);
            }

            for (int i = 1; i <= Math.Truncate(stepX) * scalegrid; i++)
            {
                float newLeft = Convert.ToSingle((point.X) + i * gridsize / koef);
                float newRight = Convert.ToSingle((point.X) - i * gridsize / koef);
                graphics.DrawLine(penGray, newLeft, 0, newLeft, h);
                graphics.DrawLine(penGray, newRight, 0, newRight, h);
            }

            graphics.DrawLine(penGray2, point.X, 0, point.X, h);
            graphics.DrawLine(penGray2, 0, point.Y, w, point.Y);
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
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            UpdateGrid();
        }

        private int ConX(int x, double koef)
        {
            try
            {
                // The unsafe type conversion requires exception processing.
                x = Convert.ToInt32(Math.Truncate(x / koef + point.X));
                return x;
            }
            catch (Exception) { return 0; }
        }
        private int ConY(int y, double koef)
        {
            try
            {
                // The unsafe type conversion requires exception processing.
                y = Convert.ToInt32(Math.Truncate(-y / koef + point.Y));
                return y;
            }
            catch (Exception) { return 0; }
        }
        private int ConX(double x, double koef)
        {
            try
            {
                // The unsafe type conversion requires exception processing.
                int output = Convert.ToInt32(Math.Truncate(x / koef + point.X));
                return output;
            }
            catch (Exception) { return 0; }
        }
        private int ConY(double y, double koef)
        {
            try
            {
                // The unsafe type conversion requires exception processing.
                int output = Convert.ToInt32(Math.Truncate(-y / koef + point.Y));
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
            graphics.DrawLine(pen,
                Convert.ToSingle(ConX(x1, koef)),
                Convert.ToSingle(ConY(y1, koef)),
                Convert.ToSingle(ConX(x2, koef)),
                Convert.ToSingle(ConY(y2, koef)));
        }
        private void DrawEllipse(Vector vector, Brush brush, int size, bool isLabeled, string name)
        {
            int scale = 2;
            if (isLabeled == true)
            {
                graphics.FillEllipse(brush,
                    Convert.ToSingle(ConX(vector.X2, koef) - size / scale),
                    Convert.ToSingle(ConY(vector.Y2, koef) - size / scale),
                    size, size);
                graphics.DrawString($"{name}", new Font("Arial", 10f), brush,
                    Convert.ToSingle(ConX(vector.X2, koef)),
                    Convert.ToSingle(ConY(vector.Y2, koef)));
            }
            else
            {
                graphics.FillEllipse(brush,
                    Convert.ToSingle(ConX(vector.X2, koef) - size / scale),
                    Convert.ToSingle(ConY(vector.Y2, koef) - size / scale),
                    size, size);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isFinalIteration == true && iterations >= finalIteration)
            {
                StopTimers();
            }
            else
            {
                iterations++;
                UpdateVectors();
                DrawVectors();
                pictureBox1.Refresh();
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
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter($"{dirpath}\\{date}.csv"))
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                    sw.WriteLine(listBox1.Items[i].ToString());
            }

        }

        private void checkBoxIsLabeled_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIsLabeled.Checked == true)
            { isLabeled = true; }
            else { isLabeled = false; }
            UpdateGrid();
            DrawTraces();
            DrawEllipces();
            DrawCalculationinfo();
            pictureBox1.Refresh();
        }

        private void DrawCalculationinfo()
        {
            int shift = 20;
            string gs = String.Format("{0:N0}", gridsize);
            string gs2 = String.Format("{0:E0}", gridsize);

            graphics.DrawString($"Iteration: {iterations} Time: {iterations * dt} s Speed: {countSpeed} Elapsed: {globalTime} s", new Font("Arial", 10f), Brushes.DarkGray, 0, 0);
            graphics.DrawString($"Grid size: {gs} m ({gs2} m)", new Font("Arial", 10f), Brushes.DarkGray, 0, pictureBox1.Height - shift);
        }

        // The mouse wheel scrolling event handler changes the opacity
        // of the form.
        private void this_MouseWheel(object sender, MouseEventArgs e)
        {
            double scaleDown = 0.9;
            double scaleUp = 1.1;
            int scaleMax = 10;

            if (e.Delta > 0 && koef > scaleMax)
            {
                koef = koef * scaleDown;
                UpdateScale();
            }
            if (e.Delta < 0)
            {
                koef = koef * scaleUp;
                UpdateScale();
            }
        }

        private void UpdateScale()
        {
            SetGridSizeAuto();
            UpdateGrid();
            DrawTraces();
            DrawEllipces();
            DrawCalculationinfo();
            pictureBox1.Refresh();
        }

        private void checkBoxStartPause_Click(object sender, EventArgs e)
        {
            if (isFormSettingsOpened == false && isFormPresetsOpened == false)
            {
                if (timer1.Enabled == false) { StartTimers(); }
                else { StopTimers(); }
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
            int const1 = 40;
            int const2 = 16;
            int const3 = 33;
            try
            {
                if (isParticlesArrayLoaded == true)
                {
                    pictureBox1.Size = new System.Drawing.Size(Size.Width - const1 - const2, Size.Height - const3);
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
                isMouseDown = false;
                pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            }

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                int deltaX = e.X - oldX;
                int deltaY = e.Y - oldY;
                point.SetPoint(point.X + deltaX, point.Y + deltaY);
                DrawVectors();
                pictureBox1.Refresh();
            }
            oldX = e.X;
            oldY = e.Y;
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

        private void CreateResults(int iteration)
        {
            int resultsPerParticle = 2;
            for (int i = 0; i < n; i++)
            {
                c[i] = p[i].R.X2;
                d[i] = p[i].R.Y2;
            }

            for (int i = 0; i < n; i++)
            {
                C[iteration, i * resultsPerParticle] = c[i];
                C[iteration, i * resultsPerParticle + 1] = d[i];
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            globalTime += 1;
            countSpeed = Math.Round(iterations * 1.0 / globalTime, 1) + " i/s";
        }

        private void checkBoxLog_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLog.Checked)
            {
                isLogged = true;
                checkBoxLog.ImageIndex = 6;
            }
            else
            {
                isLogged = false;
                checkBoxLog.ImageIndex = 7;
            }
        }

        private void checkBoxTraces_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTraces.Checked) { isTraced = true; }
            else { isTraced = false; }
            UpdateGrid();
            DrawTraces();
            DrawEllipces();
            DrawCalculationinfo();
            pictureBox1.Refresh();
        }

        private void checkBoxSettings_Click(object sender, EventArgs e)
        {
            if (checkBoxSettings.Checked == false)
            {
                if (isFormSettingsOpened == false)
                {
                    StopTimers();
                    checkBoxSettings.Checked = true;
                    isFormSettingsOpened = true;
                    Form2 FormSettings = new Form2(isGridAuto, gridsize, numberOfPoints, pointSize, dt, isFinalIteration, finalIteration);
                    FormSettings.Owner = this;
                    FormSettings.Show();
                }
            }
        }

        private void UpdateResults()
        {
            C = IncreaseArray(C);
            D = CloneArray(C);
            CreateResults(iterations);
        }

        public void CheckBoxSettingsUncheck()
        {
            checkBoxSettings.Checked = false;
            checkBoxSettings.CheckState = 0;
            isFormSettingsOpened = false;
        }

        public void SetGridAuto()
        {
            isGridAuto = true;
            checkBoxGridAuto.Checked = true;
            checkBoxGridAuto.ImageIndex = 8;
            UpdateScale();
        }

        public void SetGridSize(double newgridsize)
        {
            if (newgridsize >= 1000 && newgridsize <= Math.Pow(10, 20))
            {
                isGridAuto = false;
                checkBoxGridAuto.Checked = false;
                checkBoxGridAuto.ImageIndex = 9;
                gridsize = newgridsize;
                UpdateScale();
            }
        }

        public void SetPointSize(byte newpointsize)
        {
            pointSize = newpointsize;
            UpdateVisibleObjects();
        }

        public void SetNumberOfPoints(int number)
        {
            int minNumberOfPoints = 500;
            int maxNumberOfPoints = 10000;
            if (number >= minNumberOfPoints && number <= maxNumberOfPoints)
            {
                numberOfPoints = number;
                UpdateVisibleObjects();
            }
        }

        public void UpdateVisibleObjects()
        {
            UpdateGrid();
            DrawTraces();
            DrawEllipces();
            DrawCalculationinfo();
            pictureBox1.Refresh();
        }

        public void SetDt(double newdt)
        {
            double minIntegrationStep = 0.01;
            double maxIntegrationStep = 3600;
            if (newdt >= minIntegrationStep && newdt <= maxIntegrationStep) { dt = newdt; }
        }

        public void SetIsFinalIteration(bool newisfinaliteration)
        {
            isFinalIteration = newisfinaliteration;
        }

        private void checkBoxGridAuto_Click(object sender, EventArgs e)
        {
            if (isFormSettingsOpened == false)
            {
                if (checkBoxGridAuto.Checked)
                {
                    isGridAuto = false;
                    checkBoxGridAuto.Checked = false;
                    checkBoxGridAuto.ImageIndex = 9;
                }
                else
                {
                    isGridAuto = true;
                    checkBoxGridAuto.Checked = true;
                    checkBoxGridAuto.ImageIndex = 8;
                    UpdateScale();
                }
            }
        }

        public void SetFinalIteration(int newfinaliteration)
        {
            if (newfinaliteration >= 0) { finalIteration = newfinaliteration; }
        }

        /*
        To avoid incorrect scaling of components on the form 
        by the operating system (100%, 125%, 150%) their sizes
        and positions are set hard in the form constructor.     
        */
        private void InitializeElements()
        {
            pictureBox1.Location = new System.Drawing.Point(48, 0);
            pictureBox1.Size = new System.Drawing.Size(500, 500);

            Size = new System.Drawing.Size(pictureBox1.Size.Width + 40 + 16, pictureBox1.Size.Height + 33);

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
