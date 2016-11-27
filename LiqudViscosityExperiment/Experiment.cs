using System;
using System.Collections.Generic;

namespace LiquidViscosity
{
    public class Experiment
    {
        public float R, BDens, LDens;
        private float Nu, Lambda, d;
        private const float g = 9.8f;
        
        public List<float> Vt;
        public List<float> T;

        public bool FirstRingPassed, SecondRingPassed;
        public float FirstRingTime, SecondRingTime;

        public Experiment(float Radius, float BallDensity, float LiquidDensity, float Viscosity)
        {
            R = Radius; BDens = BallDensity; LDens = LiquidDensity; Nu = Viscosity;
            Lambda = (6.0f * Nu) / ((4.0f / 3.0f) * R * R * BDens);
            d = g * (1.0f - (LDens / BDens));

            Vt = new List<float>(); Vt.Add(0.0f);
            T = new List<float>(); T.Add(0.0f);

            FirstRingPassed = false; SecondRingPassed = false;
        }

        public float H(float t)
        {
            float H = (d / Lambda) * t + (d / (Lambda * Lambda)) * ((1.0f / (float)Math.Pow(Math.E, Lambda * t)) - 1.0f);
            return H * 10;
        }

        public float V(float t)
        {
            float V = (d / Lambda) * (1.0f - 1.0f / ((float)Math.Pow(Math.E, Lambda * t)));
            return V;
        }

        public float[] GetV()
        {
            float[] VArray = Vt.ToArray();
            return VArray;
        }

        public float[] GetT()
        {
            float[] TArray = T.ToArray();
            return TArray;
        }
    }
}
