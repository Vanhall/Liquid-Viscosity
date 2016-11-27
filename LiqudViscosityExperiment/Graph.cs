using System.Windows.Forms;

namespace LiquidViscosity
{
    public partial class Graph : Form
    {
        public Graph(Experiment Exp)
        {
            InitializeComponent();

            chart1.Titles[0].Text =
                "Радиус шарика: " + (Exp.R * 1000).ToString("F1") + " мм"
                + "     Плотность шарика: " + Exp.BDens.ToString("F1") + " кг/м3"
                + "     Плотность жидкости: " + Exp.LDens.ToString("F1") + " кг/м3";

            chart1.ChartAreas[0].AxisX.Minimum = 0.0f;
            chart1.ChartAreas[0].AxisY.Minimum = 0.0f;
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 0.2f;
            
            chart1.Series[0].Points.DataBindXY(Exp.GetT(), Exp.GetV());

            chart1.Series[1].Points.AddXY(Exp.FirstRingTime, 0.0f);
            chart1.Series[1].Points.AddXY(Exp.FirstRingTime, Exp.V(Exp.FirstRingTime));
            chart1.Series[1].Name = "1е кольцо ("
                + Exp.FirstRingTime.ToString("F2") + " с)";

            chart1.Series[2].Points.AddXY(Exp.SecondRingTime, 0.0f);
            chart1.Series[2].Points.AddXY(Exp.SecondRingTime, Exp.V(Exp.SecondRingTime));
            chart1.Series[2].Name = "2е кольцо ("
                + Exp.SecondRingTime.ToString("F2") + " с)";
        }

        private void Graph_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }
    }
}
