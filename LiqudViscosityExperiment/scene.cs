using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace LiquidViscosity
{
    class scene
    {
        // ------------ | Тут пока что творческий беспорядок | ----------------
        //              V                                    V
        private SimpleOpenGlControl OGLVP;
        public camera camera;
        public model monkey;
        private readonly float[] light0Pos = { 1.0f, 1.0f, 1.0f, 0.0f };
        private readonly float[] light1Pos = { 0.0f, -15.0f, 10.0f, 1.0f };
        public bool anim = false;
        public float rot = 0.0f;
        //public int error = 0;

        // конструктор сцены
        public scene(SimpleOpenGlControl _OGLVP)
        {
            OGLVP = _OGLVP;

            Gl.glViewport(0, 0, OGLVP.Width, OGLVP.Height);
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            initLights();
          
            camera = new camera(OGLVP);
            monkey = new model("sphere.obj");

            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            render();
        }

        #region ДА БУДЕТ СВЕТ!
        // сказал монтёр и перерезал провода

        private void initLights()
        {
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0Pos);
            float[] light0Amb = new float[] { 0.3f, 0.3f, 0.3f, 1.0f };
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, light0Amb);
            float[] light0Dif = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, light0Dif);
            float[] light0Spec = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPECULAR, light0Spec);
            
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_POSITION, light1Pos);
            float[] light1Amb = new float[] { 0.0f, 0.0f, 0.0f, 1.0f };
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_AMBIENT, light1Amb);
            float[] light1Dif = new float[] { 0.5f, 0.5f, 0.7f, 1.0f };
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_DIFFUSE, light1Dif);
            float[] light1Spec = new float[] { 0.1f, 0.2f, 0.1f, 1.0f };
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPECULAR, light1Spec);

            Gl.glLightf(Gl.GL_LIGHT1, Gl.GL_SPOT_CUTOFF, 100.0f);
            float[] light1Dir = new float[] { 0.0f, 0.0f, 0.0f };
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPOT_DIRECTION, light1Dir);
            Gl.glLightf(Gl.GL_LIGHT1, Gl.GL_SPOT_EXPONENT, 3.0f);

            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_LIGHT1);
        }
        #endregion
        
        public void render()
        {
            // очищаем экран и z-буфер
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            // ставим свет (нужно вызывать каждый раз, иначе будет двигаться вместе с камерой)
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0Pos);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_POSITION, light1Pos);

            // отключаем свет чтобы оси рисовались сплошными и яркими
            Gl.glDisable(Gl.GL_LIGHTING);
            Gl.glDisable(Gl.GL_CULL_FACE);

            #region оси и плоскость
            // рисуем оси -----------------------------------------------------------
            Gl.glBegin(Gl.GL_LINES);
            Gl.glColor3f(0.0f, 1.0f, 0.0f);                // Green for x axis
            Gl.glVertex3f(0f, 0f, 0f);
            Gl.glVertex3f(10f, 0f, 0f);
            Gl.glColor3f(1.0f, 0.0f, 0.0f);                // Red for y axis
            Gl.glVertex3f(0f, 0f, 0f);
            Gl.glVertex3f(0f, 10f, 0f);
            Gl.glColor3f(0.0f, 0.0f, 1.0f);                // Blue for z axis
            Gl.glVertex3f(0f, 0f, 0f);
            Gl.glVertex3f(0f, 0f, 10f);
            Gl.glEnd();

            // Dotted lines for the negative sides of x,y,z coordinates
            Gl.glEnable(Gl.GL_LINE_STIPPLE); // Enable line stipple to use a 
                                             // dotted pattern for the lines
            Gl.glLineStipple(1, 0x0101);     // Dotted stipple pattern for the lines
            Gl.glBegin(Gl.GL_LINES);
            Gl.glColor3f(0.0f, 1.0f, 0.0f);                    // Green for x axis
            Gl.glVertex3f(-10f, 0f, 0f);
            Gl.glVertex3f(0f, 0f, 0f);
            Gl.glColor3f(1.0f, 0.0f, 0.0f);                    // Red for y axis
            Gl.glVertex3f(0f, 0f, 0f);
            Gl.glVertex3f(0f, -10f, 0f);
            Gl.glColor3f(0.0f, 0.0f, 1.0f);                    // Blue for z axis
            Gl.glVertex3f(0f, 0f, 0f);
            Gl.glVertex3f(0f, 0f, -10f);
            Gl.glEnd();
            Gl.glDisable(Gl.GL_LINE_STIPPLE);

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glColor3f(0.6f, 0.6f, 0.6f);
            Gl.glVertex3f(10f, 10f, -2f);
            Gl.glVertex3f(10f, -10f, -2f);
            Gl.glVertex3f(-10f, -10f, -2f);
            Gl.glVertex3f(-10f, 10f, -2f);
            Gl.glEnd();
            #endregion

            // включаем свет обратно
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glEnable(Gl.GL_CULL_FACE);

            // рисуем модельку---------------------------------------------------
            if (anim)
            {
                Gl.glPushMatrix();
                Gl.glTranslatef(0.0f, 0.0f, rot * 0.02f);
                Gl.glRotatef(rot, 0.0f, 0.0f, 1.0f);

                monkey.render();

                Gl.glPopMatrix();
            }
            else
            {
                monkey.render();
            }
            //error = Gl.glGetError();
            // сообщаем OpenGL что закончили все дела и можно рисовать кадр
            Gl.glFlush();
            OGLVP.Invalidate();
        }
    }
}
