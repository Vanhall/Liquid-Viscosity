using Tao.OpenGl;
using System.IO;
using Tao.Platform.Windows;

namespace LiquidViscosity
{
    public class scene
    {
        private SimpleOpenGlControl OGLVP;
        public camera camera;
        public model tube, tube_inside, bottom, table, ball, liquid;
        public material glass, blackPlastic, wood,
            lead, steel, brass,
            water, glicerene, oil;

        private readonly float[] light0Pos = { 0.0f, -10.0f, 20.0f, 0.0f };
        private readonly float[] light1Pos = { 10.0f, 10.0f, 5.0f, 1.0f };

        public float H0 = 7.25f;
        public float dH = 0;
        public float Scale = 1.0f;

        // конструктор сцены
        public scene(SimpleOpenGlControl _OGLVP)
        {
            OGLVP = _OGLVP;

            Gl.glViewport(0, 0, OGLVP.Width, OGLVP.Height);
            Gl.glClearColor(0.7f, 0.7f, 0.8f, 1.0f);
            initLights();
          
            camera = new camera(OGLVP);

            string path = Directory.GetCurrentDirectory() + "/Models/";

            glass = new material(path, "glass");
            blackPlastic = new material(path, "blackPlastic");
            wood = new material(path, "wood");
            lead = new material(path, "grayMetal");
            steel = new material(path, "steel");
            brass = new material(path, "brass");
            water = new material(path, "water");
            glicerene = new material(path, "glicerene");
            oil = new material(path, "oil");

            tube = new model(path, "tube");
            tube_inside = new model(path, "tube_inside");
            tube.setMaterial(glass);
            tube_inside.setMaterial(glass);

            bottom = new model(path, "base");
            bottom.setMaterial(blackPlastic);

            table = new model(path, "table");
            table.setMaterial(wood);

            ball = new model(path, "ball");
            ball.setMaterial(lead);

            liquid = new model(path, "liquid");
            liquid.setMaterial(water);

            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_NORMALIZE);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glEnable(Gl.GL_CULL_FACE);

            Gl.glEnable(Gl.GL_LINE_SMOOTH);
            Gl.glHint(Gl.GL_LINE_SMOOTH_HINT, Gl.GL_NICEST);
        }

        #region Освещение

        private void initLights()
        {
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0Pos);
            float[] light0Amb = new float[] { 0.3f, 0.3f, 0.3f, 1.0f };
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, light0Amb);
            float[] light0Dif = new float[] { 1.0f, 1.0f, 1.0f, 0.5f };
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, light0Dif);
            float[] light0Spec = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPECULAR, light0Spec);

            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_POSITION, light1Pos);
            float[] light1Amb = new float[] { 0.0f, 0.0f, 0.0f, 1.0f };
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_AMBIENT, light1Amb);
            float[] light1Dif = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_DIFFUSE, light1Dif);
            float[] light1Spec = new float[] { 0.3f, 0.3f, 0.3f, 1.0f };
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPECULAR, light1Spec);

            Gl.glLightf(Gl.GL_LIGHT1, Gl.GL_SPOT_CUTOFF, 100.0f);
            float[] light1Dir = new float[] { 0.0f, 0.0f, 0.0f };
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPOT_DIRECTION, light1Dir);
            Gl.glLightf(Gl.GL_LIGHT1, Gl.GL_SPOT_EXPONENT, 3.0f);

            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_LIGHT1);
        }
        #endregion
        
        // рисование шкалы
        private void DrawScale()
        {
            Gl.glColor3f(0.0f, 0.0f, 0.0f);

            Gl.glLineWidth(1.5f);
            for (float h = 1.25f; h <= 7.25; h += 1.0f)
            {
                Gl.glBegin(Gl.GL_LINE_STRIP);
                Gl.glVertex3f(0.5f, 0.866f, h);
                Gl.glVertex3f(0.707f, 0.707f, h);
                Gl.glVertex3f(0.866f, 0.5f, h);
                Gl.glEnd();
            }
            Gl.glLineWidth(1.0f);
            for (float h = 0.35f; h <= 7.25; h += 0.1f)
            {
                Gl.glBegin(Gl.GL_LINES);
                Gl.glVertex3f(0.707f, 0.707f, h);
                Gl.glVertex3f(0.866f, 0.5f, h);
                Gl.glEnd();
            }

        }

        public void render()
        {
            // очищаем экран и z-буфер
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            // ставим свет (нужно вызывать каждый раз, иначе будет двигаться вместе с камерой)
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0Pos);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_POSITION, light1Pos);
            
            // рисуем модельки
            table.render();
            bottom.render();
            DrawScale();

            Gl.glPushMatrix();
            Gl.glTranslatef(0.0f, 0.0f, H0 - dH);
            Gl.glScalef(Scale, Scale, Scale);
            ball.render();
            Gl.glPopMatrix();

            liquid.render();
            tube.render();
            tube_inside.render();
            
            // сообщаем OpenGL что закончили все дела и можно рисовать кадр
            Gl.glFlush();
            OGLVP.Invalidate();
        }
    }
}
