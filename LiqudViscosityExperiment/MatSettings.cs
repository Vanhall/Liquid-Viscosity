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
            scene.blackPlastic.SetDefault();
            scene.brass.SetDefault();
            scene.glass.SetDefault();
            scene.glicerene.SetDefault();
            scene.lead.SetDefault();
            scene.oil.SetDefault();
            scene.steel.SetDefault();
            scene.water.SetDefault();
            scene.wood.SetDefault();
            
            scene.render();
        }
        #endregion
    }
}
