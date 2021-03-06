﻿using System;

namespace VectorLibrary
{
    /*
    Summary:
        Provides methods (including static) to perform basic and
        support operations on vectors in two-dimensional space.
    */
     

    public class Point
    {
        private int x;
        private int y;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Point(int x, int y)
        {
            SetPoint(x, y);
        }

        public Point(double x, double y)
        {
            SetPoint(x, y);
        }

        public void SetPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void SetPoint(double x, double y)
        {
            X = Convert.ToInt32(Math.Truncate(x));
            Y = Convert.ToInt32(Math.Truncate(y));
        }

        static void SetPoint(Point point, int x, int y)
        {
            point.X = x;
            point.Y = y;
        }

        static void SetPoint(Point point, double x, double y)
        {
            point.X = Convert.ToInt32(Math.Truncate(x));
            point.Y = Convert.ToInt32(Math.Truncate(y));
        }
    }

    public class Vector
    {
        //
        //     Fields definition
        //

        private double x1;  // Initial point on the X-axis
        private double y1;  // Initial point on the Y-axis
        private double x2;  // Terminal point on the X-axis
        private double y2;  // Terminal point on the Y-axis
        private double m;   // Magnitude of a vector
        private double a;   // Angle to the X-axis [degrees]
        private double cosa;// Cosine of the "a" angle
        private double vx;  // Vector projection on the X-axis
        private double vy;  // Vector projection on the Y-axis

        //
        //     Properties definition
        //

        // Initial point on the X-axis property
        public double X1
        {
            get { return x1; }
            private set { x1 = value; }
        }

        // Initial point on the Y-axis property
        public double Y1
        {
            get { return y1; }
            private set { y1 = value; }
        }

        // Terminal point on the X-axis property
        public double X2
        {
            get { return x2; }
            private set { x2 = value; }
        }

        // Terminal point on the Y-axis property
        public double Y2
        {
            get { return y2; }
            private set { y2 = value; }
        }

        // Magnitude of a vector property
        public double M
        {
            get { return m; }
            private set
            {
                if (value < 0) { m = 0; }
                else { m = value; }
            }
        }

        // Angle to the X-axis [degrees] property
        public double A
        {
            get { return a; }
            private set { a = value; }
        }

        // Cosine of the "a" angle property
        public double CosA
        {
            get { return cosa; }
            private set { cosa = value; }
        }

        // Vector projection on the X-axis property
        public double Vx
        {
            get { return vx; }
            private set { vx = value; }
        }

        // Vector projection on the Y-axis property
        public double Vy
        {
            get { return vy; }
            private set { vy = value; }
        }

        //
        // Summary:
        //     Constructor. Creates an instance of the Vector class
        //     using coordinates of initial and terminal points as
        //     parameters.
        //
        // Parameters:
        //   x1:
        //     Initial point on the X-axis.
        //   y1:
        //     Initial point on the Y-axis.
        //   x2:
        //     Terminal point on the X-axis.
        //   y2:
        //     Terminal point on the X-axis.
        public Vector(double x1, double y1, double x2, double y2)
        {
            SetVectorByPoints(x1, y1, x2, y2);
        }

        //
        // Summary:
        //     Constructor. Creates an instance of the Vector class
        //     using coordinates of initial point, magnitude and angle
        //     to the X-axis as parameters.
        //
        // Parameters:
        //   x1:
        //     Initial point on the X-axis.
        //   y1:
        //     Initial point on the Y-axis.
        //   m:
        //     Magnitude of a vector.
        //   a:
        //     Angle to the X-axis [degrees].
        //   f:
        //     Any integer value. It is required only to change
        //     the constructor's signature.
        public Vector(double x1, double y1, double m, double a, int f)
        {
            SetVectorByAngle(x1, y1, m, a);
        }

        //
        // Summary:
        //     Updates vector fields using coordinates of initial
        //     and terminal points as parameters.
        //
        // Parameters:
        //   x1:
        //     Initial point on the X-axis.
        //   y1:
        //     Initial point on the Y-axis.
        //   x2:
        //     Terminal point on the X-axis.
        //   y2:
        //     Terminal point on the X-axis.
        public void SetVectorByPoints(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            Vx = X2 - X1;
            Vy = Y2 - Y1;
            if (x1 == x2 && y1 == y2) // M == 0
            {
                M = 0;
                A = 0;
                CosA = 1; // to avoid division by zero in (X2 - X1) / M;
            }
            else
            {
                M = GetMagnitude(x1, y1, x2, y2);
                A = GetAngleByPoints(x1, y1, x2, y2);
                CosA = (X2 - X1) / M;
            }
        }

        public void SetVectorByPoints(Vector vector)
        {
            SetVectorByPoints(vector.X1, vector.Y1, vector.X2, vector.Y2);
        }
        public void SetVectorByAngle(Vector vector)
        {
            SetVectorByAngle(vector.X1, vector.Y1, vector.M, vector.A);
        }
        //
        // Summary:
        //     Updates vector fields using coordinates of initial
        //     point, magnitude and angle to the X-axis as parameters.
        //
        // Parameters:
        //   x1:
        //     Initial point on the X-axis.
        //   y1:
        //     Initial point on the Y-axis.
        //   m:
        //     Magnitude of a vector.
        //   a:
        //     Angle to the X-axis [degrees].
        public void SetVectorByAngle(double x1, double y1, double m, double a)
        {
            X1 = x1;
            Y1 = y1;
            if (m == 0)
            {
                M = 0;
                A = 0;
                Vx = 0;
                Vy = 0;
                X2 = X1;
                Y2 = Y1;
            }
            else
            {
                M = m;
                A = a;
                Vx = M * Math.Cos(A * Math.PI / 180);
                Vy = M * Math.Sin(A * Math.PI / 180);
                X2 = X1 + Vx;
                Y2 = Y1 + Vy;
            }
            CosA = Math.Cos(A * Math.PI / 180);
        }

        //
        // Summary:
        //     Returns a hypotenuse of a rectangular triangle formed
        //     by projections of a line segment on coordinate axes.
        //
        // Parameters:
        //   x1:
        //     Initial point on the X-axis.
        //   y1:
        //     Initial point on the Y-axis.
        //   x2:
        //     Terminal point on the X-axis.
        //   y2:
        //     Terminal point on the X-axis.
        //
        // Returns:
        //     A hypotenuse as a double-precision floating-point number.
        public static double GetMagnitude(double x1, double y1, double x2, double y2)
        {
            return Math.Pow(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2), 0.5);
        }

        //
        // Summary:
        //     Calculates vector angle by coordinates of initial
        //     and terminal points.
        //
        // Parameters:
        //   x1:
        //     Initial point on the X-axis.
        //   y1:
        //     Initial point on the Y-axis.
        //   x2:
        //     Terminal point on the X-axis.
        //   y2:
        //     Terminal point on the X-axis.
        //
        // Returns:
        //     An angle as a double-precision floating-point number.
        public static double GetAngleByPoints(double x1, double y1, double x2, double y2)
        {
            return Vector.Acos(x1, y1, x2, y2);
        }

        //
        // Summary:
        //     Moves the initial point of a vector to the origin
        //     of coordinates (parallel shift).
        public void MoveToCenter()
        {
            SetVectorByPoints(0, 0, X2 - X1, Y2 - Y1);
        }

        //
        // Summary:
        //     Moves the initial point of a vector by horizonal
        //     and vertical increments (parallel shift).
        // Parameters:
        //   dx:
        //     Horizonal increment.
        //   dy:
        //     Vertical increment.
        public void Move(double dx, double dy)
        {
            SetVectorByPoints(X1 + dx, Y1 + dy, X2 + dx, Y2 + dy);
        }

        //
        // Summary:
        //     Moves the initial point of a vector to the specified
        //     point (parallel shift).
        // Parameters:
        //   x:
        //     New initial point on the X-axis.
        //   y:
        //     New initial point on the Y-axis.
        public void MoveToPoint(double x, double y)
        {
            SetVectorByPoints(x, y, X2 + x - X1, Y2 + y - Y1);
        }

        //
        // Summary:
        //     Creates a source vector copy and moves it to the
        //     specified point.
        //
        // Parameters:
        //   v:
        //     Source vector.
        //   newX:
        //     Initial point on the X-axis of a new vector.
        //   newY:
        //     Initial point on the Y-axis of a new vector.
        //
        // Returns:
        //     A source vector copy as an instance of the Vector class.
        public static Vector CopyAndPasteAtPoint(Vector v, double newX, double newY)
        {
            Vector vector = new Vector(newX, newY, newX + v.X2 - v.X1, newY + v.Y2 - v.Y1);
            return vector;
        }
        //c
        public Vector CopyAndRotate(double delta)
        {
            Vector vector = new Vector(X1, Y1, X2, Y2);
            vector.SetVectorByAngle(vector.X1, vector.Y1, vector.M, vector.A + delta);
            return vector;
        }

        //
        // Summary:
        //     Returns the result of addition of vectors v1 and v2
        //     as a vector.
        //
        // Parameters:
        //   v1:
        //     First vector.
        //   v2:
        //     Second vector.
        //
        // Returns:
        //     The result of addition as an instance of the Vector class.
        public static Vector operator +(Vector v1, Vector v2)
        {
            Vector vector = CopyAndPasteAtPoint(v2, v1.X2, v1.Y2);
            vector.SetVectorByPoints(v1.X1, v1.Y1, vector.X2, vector.Y2);
            return vector;
        }

        //
        // Summary:
        //     Returns the result of subtraction of vectors v1 and v2
        //     as a vector.
        //
        // Parameters:
        //   v1:
        //     First vector.
        //   v2:
        //     Second vector.
        //
        // Returns:
        //     The result of subtraction as an instance of the Vector class.
        public static Vector operator -(Vector v1, Vector v2)
        {
            Vector vector = CopyAndPasteAtPoint(v2, v1.X1, v1.Y1);
            vector.SetVectorByPoints(vector.X2, vector.Y2, v1.X2, v1.Y2);
            return vector;
        }

        //
        // Summary:
        //     Returns the result of multiplying a source 
        //     vector v by a scalar k.
        //
        // Parameters:
        //   v1:
        //     Source vector.
        //   k:
        //     Double-precision floating-point number.
        //
        // Returns:
        //     The result of multiplying by a scalaras an instance
        //     of the Vector class.
        public static Vector operator *(Vector v, double k)
        {
            Vector v3 = new Vector(v.X1, v.Y1, v.X2, v.Y2);
            if (k < 0) { v3.SetVectorByAngle(v3.X1, v3.Y1, v3.M * Math.Abs(k), v3.A + 180); }
            else { v3.SetVectorByAngle(v3.X1, v3.Y1, v3.M * k, v3.A); }
            return v3;
        }

        //
        // Summary:
        //     Returns the result of multiplying a scalar k
        //     by a source vector v.
        //
        // Parameters:
        //   v1:
        //     Source vector.
        //   k:
        //     Double-precision floating-point number.
        //
        // Returns:
        //     The result of multiplying by a scalaras an instance
        //     of the Vector class.
        public static Vector operator *(double k, Vector v)
        {
            Vector v3 = new Vector(v.X1, v.Y1, v.X2, v.Y2);
            if (k < 0) { v3.SetVectorByAngle(v3.X1, v3.Y1, v3.M * Math.Abs(k), v3.A + 180); }
            else { v3.SetVectorByAngle(v3.X1, v3.Y1, v3.M * k, v3.A); }
            return v3;
        }
        //c
        public static double ScalarProduct(Vector v1, Vector v2)
        {
            return VectorProjection(v1, v2) * v2.M;
        }
        //c
        public static double VectorProjection(Vector v1, Vector v2)
        {
            Vector v1r = v1.CopyAndRotate(-v2.A);

            if (v1.M == 0 || v2.M == 0)
            {
                return 0;
            }
            else
            {
                return v1r.M * v1r.CosA;
            }
        }

        //
        // Summary:
        //     Returns the arccosine of the angle of the rectangular
        //     triangle formed by hypotenuse given by a line segment
        //     with a initial and terminal points and cathetus given
        //     by a projection of the line segment on the X-axis.
        //
        // Parameters:
        //   x1:
        //     Initial point on the X-axis.
        //   y1:
        //     Initial point on the Y-axis.
        //   x2:
        //     Terminal point on the X-axis.
        //   y2:
        //     Terminal point on the X-axis.
        //
        // Returns:
        //     A value of arccosine as a double-precision floating-point number.
        public static double Acos(double x1, double y1, double x2, double y2)
        {
            double acos;
            double m = Math.Pow(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2), 0.5);

            if (x2 >= x1 && y2 >= y1)           // I
            {
                acos = Math.Acos((x2 - x1) / m) * 180 / Math.PI;
            }
            else if (x2 < x1 && y2 >= y1)       // II
            {
                acos = Math.Acos((x2 - x1) / m) * 180 / Math.PI;
            }
            else if (x2 < x1 && y2 < y1)        // III
            {
                acos = Math.Acos((x1 - x2) / m) * 180 / Math.PI + 180;
            }
            else //(x2 >= x1 && y2 < y1)        // IV
            {
                acos = Math.Acos((x1 - x2) / m) * 180 / Math.PI + 180;
            }
            return acos;
        }

        public static double Acos(Vector v)
        {
            return Acos(v.X1, v.Y1, v.X2, v.Y2);
        }

        public static double Asin(double x1, double y1, double x2, double y2)
        {
            double asin;
            double m = Math.Pow(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2), 0.5);

            if (x2 >= x1 && y2 >= y1)           // I
            {
                if (y2 == y1) { return 0; }
                else
                {
                    asin = Math.Asin((y2 - y1) / m) * 180 / Math.PI;
                    return asin;
                }
            }
            else if (x2 < x1 && y2 >= y1)       // II
            {
                if (y2 == y1) { return 180; }
                else
                {
                    asin = 180 - Math.Asin((y2 - y1) / m) * 180 / Math.PI;
                    return asin;
                }
            }
            else if (x2 < x1 && y2 < y1)        // III
            {
                asin = 180 - Math.Asin((y2 - y1) / m) * 180 / Math.PI;
                return asin;
            }
            else //(x2 >= x1 && y2 < y1)        // IV
            {
                asin = 360 - Math.Asin((y1 - y2) / m) * 180 / Math.PI;
                return asin;
            }
        }

        public static double Asin(Vector v)
        {
            return Asin(v.X1, v.Y1, v.X2, v.Y2);
        }

        /*DELETE*/
        //public void GetInfo()
        //{
        //    Console.WriteLine($"(X1, Y1) --> (X2, Y2)");
        //    Console.WriteLine($"({Math.Round(X1, 2)}, {Math.Round(Y1, 2)}) --> ({Math.Round(X2, 2)}, {Math.Round(Y2, 2)})");
        //    Console.WriteLine($"Vx: {Math.Round(Vx, 2)}, Vy: {Math.Round(Vy, 2)}");
        //    Console.WriteLine($"CosA = {Math.Round(CosA, 3)}");
        //    Console.WriteLine($"Magnitude: {Math.Round(M, 2)}, Angle: {Math.Round(A, 2)}");
        //    Console.WriteLine("===");
        //}

        public string GetInfoString()
        {
            string result = $"({X1}; {Y1}) --> ({X2}; {Y2}), Magnitude: {M}; Angle: {A}";
            return result;
        }


    }
}
