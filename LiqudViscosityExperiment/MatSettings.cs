using System;
using System.Windows.Forms;

namespace LiquidViscosity
{
    public partial class MatSettings : Form
    {
        private scene scene;
        private material matSelector;
        private string MatComp = "ambient";

        public MatSettings(Main sender)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
            scene = sender.scene;
            matSelector = scene.tube.mat;
            setSliders(MatComp);
        }

        private void setSliders(string attrib)
        {
            float[] values = matSelector.getAttrib(attrib);
            float[] DifAttrib = matSelector.getAttrib("diffuse");

            RSlider.Value = (int)(values[0] * 100);
            GSlider.Value = (int)(values[1] * 100);
            BSlider.Value = (int)(values[2] * 100);
            AlphaSlider.Value = (int)(DifAttrib[3] * 100);

            RIndicator.Text = values[0].ToString("F2");
            GIndicator.Text = values[1].ToString("F2");
            BIndicator.Text = values[2].ToString("F2");
            AlphaIndicator.Text = DifAttrib[3].ToString("F2");
        }

        #region Выбор элемента установки
        private void tubeSelector_CheckedChanged(object sender, EventArgs e)
        {
            if (tubeSelector.Checked)
            {
                matSelector = scene.tube.mat;
                setSliders(MatComp);
            }
        }

        private void liquidSelector_CheckedChanged(object sender, EventArgs e)
        {
            if (liquidSelector.Checked)
            {
                matSelector = scene.liquid.mat;
                setSliders(MatComp);
            }
        }

        private void bottomSelector_CheckedChanged(object sender, EventArgs e)
        {
            if (bottomSelector.Checked)
            {
                matSelector = scene.bottom.mat;
                setSliders(MatComp);
            }
        }

        private void ballSelector_CheckedChanged(object sender, EventArgs e)
        {
            if (ballSelector.Checked)
            {
                matSelector = scene.ball.mat;
                setSliders(MatComp);
            }
        }

        private void tableSelector_CheckedChanged(object sender, EventArgs e)
        {
            if (tableSelector.Checked)
            {
                matSelector = scene.table.mat;
                setSliders(MatComp);
            }
        }
        #endregion

        private void ComponentSlider_Scroll(object sender, EventArgs e)
        {
            switch (ComponentSlider.Value)
            {
                case 0:
                    {
                        MatComp = "ambient";
                        matComp.Text = "Ambient";
                        setSliders("ambient");
                    }
                    break;
                case 1:
                    {
                        MatComp = "diffuse";
                        matComp.Text = "Diffuse";
                        setSliders("diffuse");
                    }
                    break;
                case 2:
                    {
                        MatComp = "specular";
                        matComp.Text = "Specular";
                        setSliders("specular");
                    }
                    break;
                case 3:
                    {
                        MatComp = "shininess";
                        matComp.Text = "Shininess";
                        setSliders("shininess");
                    }
                    break;
                case 4:
                    {
                        MatComp = "emission";
                        matComp.Text = "Emission";
                        setSliders("emission");
                    }
                    break;
            }
        }

        #region Ползунки цвета
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
        #endregion

        private void AlphaSlider_Scroll(object sender, EventArgs e)
        {
            AlphaIndicator.Text = (AlphaSlider.Value / 100.0f).ToString("F2");
        }

        #region Кнопки
        private void saveMaterial_Click(object sender, EventArgs e)
        {
            matSelector.saveMaterial();
            if (matSelector == scene.tube.mat) scene.tube_inside.mat.saveMaterial();
        }

        private void Set_Click(object sender, EventArgs e)
        {
            if (MatComp == "diffuse")
            {
                matSelector.setAttrib(MatComp,
                    RSlider.Value / 100.0f,
                    GSlider.Value / 100.0f,
                    BSlider.Value / 100.0f,
                    AlphaSlider.Value / 100.0f);
                if (matSelector == scene.tube.mat)
                {
                    scene.tube_inside.mat.setAttrib(MatComp,
                    RSlider.Value / 100.0f,
                    GSlider.Value / 100.0f,
                    BSlider.Value / 100.0f,
                    AlphaSlider.Value / 100.0f);
                }
            }
            else
            {
                float[] DifAttrib = matSelector.getAttrib("diffuse");
                matSelector.setAttrib(MatComp,
                    RSlider.Value / 100.0f,
                    GSlider.Value / 100.0f,
                    BSlider.Value / 100.0f,
                    1.0f);
                matSelector.setAttrib("diffuse",
                    DifAttrib[0],
                    DifAttrib[1],
                    DifAttrib[2],
                    AlphaSlider.Value / 100.0f);
                if (matSelector == scene.tube.mat)
                {
                    scene.tube_inside.mat.setAttrib(MatComp,
                    RSlider.Value / 100.0f,
                    GSlider.Value / 100.0f,
                    BSlider.Value / 100.0f,
                    1.0f);
                    scene.tube_inside.mat.setAttrib("diffuse",
                    DifAttrib[0],
                    DifAttrib[1],
                    DifAttrib[2],
                    AlphaSlider.Value / 100.0f);
                }
            }
            scene.render();
        }

        private void SetDefault_Click(object sender, EventArgs e)
        {
            scene.blackPlastic.setAttrib("ambient", 0.08f, 0.08f, 0.08f, 1.0f);
            scene.blackPlastic.setAttrib("diffuse", 0.1f, 0.1f, 0.1f, 1.0f);
            scene.blackPlastic.setAttrib("specular", 0.34f, 0.34f, 0.34f, 1.0f);
            scene.blackPlastic.setAttrib("shininess", 0.54f, 0.54f, 0.54f, 1.0f);
            scene.blackPlastic.setAttrib("emission", 0.0f, 0.03f, 0.07f, 1.0f);
            scene.blackPlastic.saveMaterial();

            scene.brass.setAttrib("ambient", 0.0f, 0.0f, 0.0f, 1.0f);
            scene.brass.setAttrib("diffuse", 0.73f, 0.4f, 0.0f, 1.0f);
            scene.brass.setAttrib("specular", 1.0f, 1.0f, 0.0f, 1.0f);
            scene.brass.setAttrib("shininess", 0.17f, 0.17f, 0.17f, 1.0f);
            scene.brass.setAttrib("emission", 0.38f, 0.15f, 0.0f, 1.0f);
            scene.brass.saveMaterial();

            scene.glass.setAttrib("ambient", 0.08f, 0.08f, 0.08f, 1.0f);
            scene.glass.setAttrib("diffuse", 0.67f, 0.67f, 0.67f, 0.27f);
            scene.glass.setAttrib("specular", 1.0f, 1.0f, 1.0f, 1.0f);
            scene.glass.setAttrib("shininess", 0.73f, 0.73f, 0.73f, 1.0f);
            scene.glass.setAttrib("emission", 0.0f, 0.1f, 0.2f, 1.0f);
            scene.glass.saveMaterial();

            scene.glicerene.setAttrib("ambient", 0.13f, 0.26f, 0.06f, 1.0f);
            scene.glicerene.setAttrib("diffuse", 0.83f, 0.83f, 0.83f, 0.28f);
            scene.glicerene.setAttrib("specular", 1.0f, 1.0f, 1.0f, 1.0f);
            scene.glicerene.setAttrib("shininess", 0.15f, 0.15f, 0.15f, 1.0f);
            scene.glicerene.setAttrib("emission", 0.18f, 0.18f, 0.18f, 1.0f);
            scene.glicerene.saveMaterial();

            scene.lead.setAttrib("ambient", 0.07f, 0.07f, 0.07f, 1.0f);
            scene.lead.setAttrib("diffuse", 0.49f, 0.49f, 0.49f, 1.0f);
            scene.lead.setAttrib("specular", 0.16f, 0.16f, 0.16f, 1.0f);
            scene.lead.setAttrib("shininess", 0.07f, 0.07f, 0.07f, 1.0f);
            scene.lead.setAttrib("emission", 0.0f, 0.0f, 0.0f, 1.0f);
            scene.lead.saveMaterial();

            scene.oil.setAttrib("ambient", 0.0f, 0.0f, 0.0f, 1.0f);
            scene.oil.setAttrib("diffuse", 0.89f, 0.88f, 0.46f, 0.35f);
            scene.oil.setAttrib("specular", 1.0f, 1.0f, 1.0f, 1.0f);
            scene.oil.setAttrib("shininess", 0.35f, 0.35f, 0.35f, 1.0f);
            scene.oil.setAttrib("emission", 0.4f, 0.23f, 0.0f, 1.0f);
            scene.oil.saveMaterial();

            scene.steel.setAttrib("ambient", 0.17f, 0.17f, 0.17f, 1.0f);
            scene.steel.setAttrib("diffuse", 0.6f, 0.6f, 0.6f, 1.0f);
            scene.steel.setAttrib("specular", 1.0f, 1.0f, 1.0f, 1.0f);
            scene.steel.setAttrib("shininess", 0.43f, 0.43f, 0.43f, 1.0f);
            scene.steel.setAttrib("emission", 0.0f, 0.0f, 0.0f, 1.0f);
            scene.steel.saveMaterial();

            scene.water.setAttrib("ambient", 0.0f, 0.0f, 0.0f, 1.0f);
            scene.water.setAttrib("diffuse", 0.07f, 0.28f, 0.49f, 0.15f);
            scene.water.setAttrib("specular", 1.0f, 1.0f, 1.0f, 1.0f);
            scene.water.setAttrib("shininess", 0.73f, 0.73f, 0.73f, 1.0f);
            scene.water.setAttrib("emission", 0.0f, 0.59f, 0.76f, 1.0f);
            scene.water.saveMaterial();

            scene.wood.setAttrib("ambient", 0.22f, 0.17f, 0.07f, 1.0f);
            scene.wood.setAttrib("diffuse", 0.63f, 0.47f, 0.2f, 1.0f);
            scene.wood.setAttrib("specular", 0.2f, 0.15f, 0.03f, 1.0f);
            scene.wood.setAttrib("shininess", 0.24f, 0.24f, 0.24f, 1.0f);
            scene.wood.setAttrib("emission", 0.0f, 0.0f, 0.0f, 1.0f);
            scene.wood.saveMaterial();

            scene.render();
        }
        #endregion
    }
}
