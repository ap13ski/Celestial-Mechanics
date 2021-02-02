using System;
using VectorLibrary;

namespace ParticleLibrary
{
    public class Particle // Point particle
    {
        private string name;
        private double m; // Mass
        private Vector r; // Radius vector
        private Vector v; // Velocity

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double M
        {
            get { return m; }
            set { m = value; }
        }

        public Vector R
        {
            get { return r; }
            set { r = value; }
        }

        public Vector V
        {
            get { return v; }
            set { v = value; }
        }

        public Particle(Vector r, Vector v, double m)
        {
            SetParticle(r, v, m);
        }

        public void SetParticle(Vector r, Vector v, double m)
        {
            R = r;
            V = v;
            M = m;
        }

    }
}
