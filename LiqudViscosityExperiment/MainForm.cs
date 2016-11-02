using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace LiquidViscosity
{
    public partial class Main : Form
    {
        double D, R;
        scene scene;
        model modelSelector;
        string tempMatComp = "ambient";

        public Main()
        {
            // Инициализация формы и контекста OpenGL
            InitializeComponent();  
            OGLVP.InitializeContexts();
            OGLVP.MouseWheel += new MouseEventHandler(OGLVP_MouseWheel);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Загрузка формы
            matName.Left = (int)(contolPanelGroup.Size.Width - matName.Size.Width) / 2;
            D = 2700; R = 2;
            radiusLabel.Text = R.ToString("F1") + " мм";
            radiusLabel.Left = (int)(contolPanelGroup.Size.Width - radiusLabel.Size.Width) / 2;
            scene = new scene(OGLVP);   // Создаем новую "сцену" см. scene.cs
            modelSelector = scene.tube;
            setSliders(tempMatComp);
        }

        private void start_Click_1(object sender, EventArgs e)
        {
            // ------------нажат "ПУСК"----------------
            // отключаем интерфейс
            BallRadius.Enabled = false;
            BallDensity.Enabled = false;
            liqudChoice.Enabled = false;
            start.Enabled = false;
            stop.Enabled = true;
            // запускаем таймер по которому будем перерисовывать сцену
            AnimationTimer.Start();
            scene.anim = true;
        }

        private void stop_Click(object sender, EventArgs e)
        {
            // ------------нажат "СТОП"----------------
            // то же что при пуске, но наоборот
            BallRadius.Enabled = true;
            BallDensity.Enabled = true;
            liqudChoice.Enabled = true;
            start.Enabled = true;
            stop.Enabled = false;
            AnimationTimer.Stop();
            scene.anim = false;
            scene.rot = 0.0f;
            scene.render();
        }

        private void BallDensity_Scroll(object sender, EventArgs e)
        {
            // ползунок выбора материала шарика (пока почти ничего не делает)
            switch(BallDensity.Value)
            {
                case 0:
                    {
                        D = 2700;
                        matName.Text = "Аллюминий (2700 кг/м3)";
                        matName.Left = (int)(contolPanelGroup.Size.Width - matName.Size.Width) / 2;
                    } break;
                case 1:
                    {
                        D = 7000;
                        matName.Text = "Чугун (7000 кг/м3)";
                        matName.Left = (int)(contolPanelGroup.Size.Width - matName.Size.Width) / 2;
                    } break;
                case 2:
                    {
                        D = 7300;
                        matName.Text = "Олово (7300 кг/м3)";
                        matName.Left = (int)(contolPanelGroup.Size.Width - matName.Size.Width) / 2;
                    } break;
                case 3:
                    {
                        D = 7800;
                        matName.Text = "Сталь (7800 кг/м3)";
                        matName.Left = (int)(contolPanelGroup.Size.Width - matName.Size.Width) / 2;
                    } break;
                case 4:
                    {
                        D = 8500;
                        matName.Text = "Латунь (8500 кг/м3)";
                        matName.Left = (int)(contolPanelGroup.Size.Width - matName.Size.Width) / 2;
                    } break;
                case 5:
                    {
                        D = 8900;
                        matName.Text = "Медь (8900 кг/м3)";
                        matName.Left = (int)(contolPanelGroup.Size.Width - matName.Size.Width) / 2;
                    } break;
            }
        }

        private void FileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // выход по клику в меню
            Application.Exit();
        }

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
            camera cam = scene.camera; // чтоб не писать каждый раз scene.camera.бла-бла-бла
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

        private void setSliders(string attrib)
        {
            float[] values = modelSelector.getMatAttrib(attrib);
            RSlider.Value = (int)(values[0] * 100);
            GSlider.Value = (int)(values[1] * 100);
            BSlider.Value = (int)(values[2] * 100);
            AlphaSlider.Value = (int)(values[3] * 100);

            RIndicator.Text = values[0].ToString("F2");
            GIndicator.Text = values[1].ToString("F2");
            BIndicator.Text = values[2].ToString("F2");
            AlphaIndicator.Text = values[3].ToString("F2");
        }

        private void ComponentSlider_Scroll(object sender, EventArgs e)
        {
            switch(ComponentSlider.Value)
            {
                case 0:
                    {
                        tempMatComp = "ambient";
                        matComp.Text = "Ambient";
                        setSliders("ambient");
                    } break;
                case 1:
                    {
                        tempMatComp = "diffuse";
                        matComp.Text = "Diffuse";
                        setSliders("diffuse");
                    }
                    break;
                case 2:
                    {
                        tempMatComp = "specular";
                        matComp.Text = "Specular";
                        setSliders("specular");
                    }
                    break;
                case 3:
                    {
                        tempMatComp = "shininess";
                        matComp.Text = "Shininess";
                        setSliders("shininess");
                    }
                    break;
                case 4:
                    {
                        tempMatComp = "emission";
                        matComp.Text = "Emission";
                        setSliders("emission");
                    }
                    break;
            }
        }
        

        private void SET_Click(object sender, EventArgs e)
        {
            modelSelector.setMatAttrib(tempMatComp,
                RSlider.Value / 100.0f,
                GSlider.Value / 100.0f,
                BSlider.Value / 100.0f,
                AlphaSlider.Value / 100.0f);
            if(modelSelector == scene.tube)
            {
                scene.tube_inside.setMatAttrib(tempMatComp,
                RSlider.Value / 100.0f,
                GSlider.Value / 100.0f,
                BSlider.Value / 100.0f,
                AlphaSlider.Value / 100.0f);
            }
            scene.render();
        }

        private void AllSlider_Scroll(object sender, EventArgs e)
        {
            RSlider.Value = AllSlider.Value;
            GSlider.Value = AllSlider.Value;
            BSlider.Value = AllSlider.Value;

            AllIndicator.Text = (AllSlider.Value / 100.0f).ToString("F2");
            RIndicator.Text = (AllSlider.Value / 100.0f).ToString("F2");
            GIndicator.Text = (AllSlider.Value / 100.0f).ToString("F2");
            BIndicator.Text = (AllSlider.Value / 100.0f).ToString("F2");
        }

        private void RSlider_Scroll(object sender, EventArgs e)
        {
            RIndicator.Text = (RSlider.Value / 100.0f).ToString("F2");
        }

        private void GSlider_Scroll(object sender, EventArgs e)
        {
            GIndicator.Text = (GSlider.Value / 100.0f).ToString("F2");
        }

        private void BSlider_Scroll(object sender, EventArgs e)
        {
            BIndicator.Text = (BSlider.Value / 100.0f).ToString("F2");
        }

        private void AlphaSlider_Scroll(object sender, EventArgs e)
        {
            AlphaIndicator.Text = (AlphaSlider.Value / 100.0f).ToString("F2");
        }

        private void OGLVP_MouseWheel(object sender, MouseEventArgs e)
        {
            //------------------крутят колесико------------------------
            // отдаляем / приближаем
            scene.camera.zoom(scene.camera.R - e.Delta / 120);
            scene.render();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            // по тику таймера перерисовываем сцену и крутим + поднимаем кубик
            // см. scene.cs -> render()
            scene.render();
            scene.rot += 1.5f;
        }

        private void tubeSelector_CheckedChanged(object sender, EventArgs e)
        {
            if (tubeSelector.Checked) modelSelector = scene.tube;
        }

        private void tubeiSelector_CheckedChanged(object sender, EventArgs e)
        {
            if (liquidSelector.Checked) modelSelector = scene.liquid;
        }

        private void bottomSelector_CheckedChanged(object sender, EventArgs e)
        {
            if (bottomSelector.Checked) modelSelector = scene.bottom;
        }

        private void ballSelector_CheckedChanged(object sender, EventArgs e)
        {
            if (ballSelector.Checked) modelSelector = scene.ball;
        }

        private void saveMaterial_Click(object sender, EventArgs e)
        {
            modelSelector.saveMaterial();
            if (modelSelector == scene.tube) scene.tube_inside.saveMaterial();
        }

        private void BallRadius_Scroll(object sender, EventArgs e)
        {
            // ползунок выбора радиуса (пока почти ничего не делает)
            R = 2 +  0.1 * BallRadius.Value;
            radiusLabel.Text = R.ToString("F1") + " мм";
        }
    }
}
