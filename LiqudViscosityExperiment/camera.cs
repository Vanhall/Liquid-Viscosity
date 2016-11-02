using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace LiquidViscosity
{
    class camera
    {
        #region Вспомогательные функции
        private double ToRad(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        private double ToDeg(double radians)
        {
            return radians * 180.0 / Math.PI;
        }
        #endregion

        #region Константы
        private const double FOV = 45, zNear = 0.1, zFar = 200;

        private const double phiMax = 360, phiMin = 0;
        private const double psiMax = 70, psiMin = -70;
        private const double RMax = 50, RMin = 5;
        #endregion

        private double[] eye = new double[3];
        private double[] pivot = new double[3] { 0, 0, 0 };
        private double[] up = new double[3] { 0, 0, 1 };

        #region МАТАН
        public bool moving = false;
        public int mouseDX = 0;
        public int mouseDY = 0;

        private double _height = 7.0;
        public double height
        {
            get { return _height; }
            set { _height = value; }
        }
        // -------------сферические координаты (для камеры)-------------
        private double _phi = Math.PI / 4;
        public double phi
        {
            get { return ToDeg(_phi); }
            set
            {
                if (value >= phiMax) _phi = ToRad(value - 360);
                else if (value < phiMin) _phi = ToRad(value + 360);
                else _phi = ToRad(value);
            }
        }

        private double _psi = Math.PI / 4;
        public double psi
        {
            get { return ToDeg(_psi); }
            set
            {
                if (value >= psiMax) _psi = ToRad(psiMax);
                else if (value <= psiMin) _psi = ToRad(psiMin);
                else _psi = ToRad(value);
            }
        }

        private double _R = 20.0;
        public double R
        {
            get { return _R; }
            set
            {
                if (value <= RMin) _R = RMin;
                else if (value >= RMax) _R = RMax;
                else _R = value;
            }
        }
        #endregion

        // конструктор камеры
        public camera(SimpleOpenGlControl OGLVP)
        {
            eye[0] = R * Math.Cos(_phi) * Math.Cos(_psi);
            eye[1] = R * Math.Sin(_phi) * Math.Cos(_psi);
            eye[2] = R * Math.Sin(_psi);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(FOV, OGLVP.Width / OGLVP.Height, zNear, zFar);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(
                eye[0], eye[1], eye[2] + _height,
                pivot[0], pivot[1], pivot[2] + _height,
                up[0], up[1], up[2]);
        }

        #region Перемещение камеры
        public void rotate(double new_phi, double new_psi)
        {
            phi = new_phi; psi = new_psi;

            eye[0] = R * Math.Cos(_phi) * Math.Cos(_psi);
            eye[1] = R * Math.Sin(_phi) * Math.Cos(_psi);
            eye[2] = R * Math.Sin(_psi);
            
            Gl.glLoadIdentity();
            Glu.gluLookAt(
                eye[0], eye[1], eye[2] + _height,
                pivot[0], pivot[1], pivot[2] + _height,
                up[0], up[1], up[2]);
        }

        public void zoom(double new_R)
        {
            R = new_R;

            eye[0] = R * Math.Cos(_phi) * Math.Cos(_psi);
            eye[1] = R * Math.Sin(_phi) * Math.Cos(_psi);
            eye[2] = R * Math.Sin(_psi);
            
            Gl.glLoadIdentity();
            Glu.gluLookAt(
                eye[0], eye[1], eye[2] + _height,
                pivot[0], pivot[1], pivot[2] + _height,
                up[0], up[1], up[2]);
        }

        public void translate(double new_h)
        {
            height = new_h;
            
            Gl.glLoadIdentity();
            Glu.gluLookAt(
                eye[0], eye[1], eye[2] + _height,
                pivot[0], pivot[1], pivot[2] + _height,
                up[0], up[1], up[2]);
        }

        public void reset()
        {
            phi = 45.0; psi = 45.0; R = 20.0; height = 7.0;

            eye[0] = R * Math.Cos(_phi) * Math.Cos(_psi);
            eye[1] = R * Math.Sin(_phi) * Math.Cos(_psi);
            eye[2] = R * Math.Sin(_psi);
            
            Gl.glLoadIdentity();
            Glu.gluLookAt(
                eye[0], eye[1], eye[2] + _height,
                pivot[0], pivot[1], pivot[2] + _height,
                up[0], up[1], up[2]);
        }
        #endregion
    }
}
