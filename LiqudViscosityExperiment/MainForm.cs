using System;
using System.IO;
using System.Windows.Forms;

namespace LiquidViscosity
{
    public partial class Main : Form
    {
        private MatSettings MatSettings;
        public Experiment Experiment;
        public Graph Chart;
        public scene scene;

        private int ticks = 1;
        private float TimeFactor = 1.0f;

        private float LiquidDensity = 1000.0f;
        private float BallDensity = 11500.0f;
        private float R = 0.003f;
        private float Viscosity = 1.004f;
        
        #region инициализация
        public Main()
        {
            // Инициализация формы и контекста OpenGL
            InitializeComponent();
            OGLVP.InitializeContexts();
            OGLVP.MouseWheel += new MouseEventHandler(OGLVP_MouseWheel);
            
            matName.Text = "Свинец";
            radiusLabel.Text = (R * 1000).ToString("F1") + " мм";
            Graph.Enabled = false;

            TimeFactorSlider.Value = 3;
            TimeFactorLabel.Text = "X 1,00";
            TimerLabel.Text = "0,00 с";

            scene = new scene(OGLVP);   // Создаем новую "сцену" см. scene.cs
            liqudChoice.SelectedIndex = 0;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            scene.render();
        }
        #endregion

        #region Элементы управления экспериментом

        // меню выбора жидкости
        private void liqudChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (liqudChoice.SelectedIndex)
            {
                case 0:
                    {
                        scene.liquid.setMaterial(scene.water);
                        LiquidDensity = 1000.0f;
                        Viscosity = 1.004f;
                    }
                    break;
                case 1:
                    {
                        scene.liquid.setMaterial(scene.glicerene);
                        LiquidDensity = 1260.0f;
                        Viscosity = 1.48f;
                    }
                    break;
                case 2:
                    {
                        scene.liquid.setMaterial(scene.oil);
                        LiquidDensity = 930.0f;
                        Viscosity = 0.987f;
                    }
                    break;
            }
            scene.render();
        }

        // ползунок выбора радиуса
        private void BallRadius_Scroll(object sender, EventArgs e)
        {
            R = 0.003f + 0.0001f * BallRadius.Value;
            radiusLabel.Text = (R * 1000).ToString("F1") + " мм";
            scene.Scale = 1.0f + 0.0333f * BallRadius.Value;
            scene.render();
        }

        // ползунок выбора материала шарика
        private void BallMaterial_Scroll(object sender, EventArgs e)
        {
            switch (BallMaterial.Value)
            {
                case 0:
                    {
                        matName.Text = "Свинец";
                        BallDensity = 11500.0f;
                        scene.ball.setMaterial(scene.lead);
                    }
                    break;
                case 1:
                    {
                        matName.Text = "Сталь";
                        BallDensity = 7800.0f;
                        scene.ball.setMaterial(scene.steel);
                    }
                    break;
                case 2:
                    {
                        matName.Text = "Латунь";
                        BallDensity = 8500.0f;
                        scene.ball.setMaterial(scene.brass);
                    }
                    break;
            }
            scene.render();
        }

        // ползунок скорости эксперимента
        private void TimeFactorSlider_Scroll(object sender, EventArgs e)
        {
            TimeFactor = 4.0f - TimeFactorSlider.Value;
            TimeFactorLabel.Text = "X " + (1.0f / TimeFactor).ToString("F2");
        }
        #endregion

        private void LockInterface()
        {
            BallRadius.Enabled = false;
            BallMaterial.Enabled = false;
            liqudChoice.Enabled = false;
            TimeFactorSlider.Enabled = false;
            start.Enabled = false;
            stop.Enabled = true;
            Graph.Enabled = false;
        }

        private void UnlockInterface()
        {
            BallRadius.Enabled = true;
            BallMaterial.Enabled = true;
            liqudChoice.Enabled = true;
            TimeFactorSlider.Enabled = true;
            start.Enabled = true;
            stop.Enabled = false;
        }

        #region Кнопки

        // ------------нажат "ПУСК"----------------
        private void start_Click_1(object sender, EventArgs e)
        {
            // отключаем интерфейс
            LockInterface();
            // запускаем таймер по которому будем перерисовывать сцену
            
            AnimationTimer.Start();
            Experiment = new Experiment(R, BallDensity, LiquidDensity, Viscosity);
        }

        // ------------нажат "СТОП"----------------
        private void stop_Click(object sender, EventArgs e)
        {
            // то же что при пуске, но наоборот
            UnlockInterface();
            AnimationTimer.Stop();
            TimerLabel.Text = "0,00 с";

            scene.dH = 0.0f;
            ticks = 1;
            scene.render();
        }

        // кнопка графика
        private void Graph_Click(object sender, EventArgs e)
        {
            Chart = new Graph(Experiment);
            Chart.ShowDialog();
        }
        #endregion

        #region Меню

        // выход по клику в меню
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        // настройки внешнего вида
        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MatSettings = new MatSettings(this);
            MatSettings.ShowDialog(this);
        }

        private void ExpHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + "/Help/ExpHelp.pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + "/Help/ProgHelp.pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Обработка мыши
        private void OGLVP_MouseDown(object sender, MouseEventArgs e)
        {
            // -----------------нажата мышь----------------------
            // если нажато колесико, сбрасываем позицию камеры
            if (e.Button.Equals(MouseButtons.Middle))
            {
                scene.camera.reset();
                scene.render();
            }
            else scene.camera.moving = true; // иначе отмечаем что камера "движется"
        }

        private void OGLVP_MouseUp(object sender, MouseEventArgs e)
        {
            // -----------------отпущена мышь----------------------
            scene.camera.moving = false;
            scene.camera.mouseDX = e.X;
            scene.camera.mouseDY = e.Y;
        }

        private void OGLVP_MouseMove(object sender, MouseEventArgs e)
        {
            // ----------------мышь нажата и движется-----------------
            camera cam = scene.camera;
            if(cam.moving)
            {
                // Если левая кнопка - вращаем камеру
                if (e.Button.Equals(MouseButtons.Left))
                {
                    cam.rotate(
                            cam.phi - (e.X - cam.mouseDX) / 3.0,
                            cam.psi - (e.Y - cam.mouseDY) / 3.0);
                    scene.render();
                }
                // Если правая - перемещаем вдоль Z
                else if(e.Button.Equals(MouseButtons.Right))
                {
                    cam.translate(cam.height + (e.Y - cam.mouseDY) / 6.0);
                    scene.render();
                }
            }
            cam.mouseDX = e.X;
            cam.mouseDY = e.Y;
        }
        
        private void OGLVP_MouseWheel(object sender, MouseEventArgs e)
        {
            //------------------крутят колесико------------------------
            // отдаляем / приближаем
            scene.camera.zoom(scene.camera.R - e.Delta / 120);
            scene.render();
        }
        #endregion
        
        // таймер анимации
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            float time = AnimationTimer.Interval * ticks / (1000.0f * TimeFactor);
            TimerLabel.Text = time.ToString("F2") + " с";

            Experiment.T.Add(time);
            Experiment.Vt.Add(Experiment.V(time));

            scene.dH = Experiment.H(time);

            if(scene.H0 - scene.dH <= 5.25f && !Experiment.FirstRingPassed)
            {
                Experiment.FirstRingPassed = true;
                Experiment.FirstRingTime = time;
            }

            if (scene.H0 - scene.dH <= 1.25f && !Experiment.SecondRingPassed)
            {
                Experiment.SecondRingPassed = true;
                Experiment.SecondRingTime = time;
            }

            if (scene.H0 - 0.1f <= scene.dH + R)
            {
                AnimationTimer.Stop();
                scene.dH = scene.H0 - 0.1f - R * 10;
                
                UnlockInterface();
                Graph.Enabled = true;
                ticks = 1;
            }
            else ticks++;
            scene.render();
        }
        
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void emailLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("mailto:baranovav@ngs.ru");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
