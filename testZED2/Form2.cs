using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;//подключаем ZedGraph

namespace testZED2
{
    public partial class Form2 : BorderLessForm
    {
        ZedGraphControl zedGrapgControl1 = new ZedGraphControl();
        protected override void OnLoad(EventArgs e)
        {
            zedGrapgControl1.Location = new Point(10, 50);
            zedGrapgControl1.Name = "text";
            zedGrapgControl1.Size = new Size(400, 400);
            Controls.Add(zedGrapgControl1);
            GraphPane my_Pane = zedGrapgControl1.GraphPane;
            my_Pane.Title.Text = "Solution's result";
            my_Pane.XAxis.Title.Text = "My X";
            my_Pane.YAxis.Title.Text = "My Y";
        }
        private void GetSize()
        {
            zedGrapgControl1.Location = new Point(10, 10);
            zedGrapgControl1.Size = new Size(ClientRectangle.Width - 20, ClientRectangle.Height - 20);
        }
        public Form2()
        {
            InitializeComponent();
            //BorderColor = Color.White;
            HeaderBackColor = Color.Black;
            HeaderHeight = 30;
            this.BackColor = Color.FromArgb(15, 107, 90);
            this.Focus();
        }
        static double f1(double x, double y)
        {
            return 2 * Math.Pow(x, 3) * Math.Pow(y, 3) - 2 * x * y;
        }
        static double realF1(double x)
        {
            return 1 / (Math.Sqrt(Math.Pow(x, 2) + 0.5));
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Tilt(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear(ZedGraphControl Zed_GraphControl)
        {
            //GraphPane pane = Zed_GraphControl.GraphPane;
            zedGrapgControl1.GraphPane.CurveList.Clear();
            zedGrapgControl1.GraphPane.GraphObjList.Clear();
            zedGrapgControl1.GraphPane.XAxis.Type = AxisType.Linear;
            zedGrapgControl1.GraphPane.XAxis.Scale.TextLabels = null;
            zedGrapgControl1.GraphPane.XAxis.MajorGrid.IsVisible = false;
            zedGrapgControl1.GraphPane.YAxis.MajorGrid.IsVisible = false;
            zedGrapgControl1.GraphPane.YAxis.MinorGrid.IsVisible = false;
            zedGrapgControl1.GraphPane.XAxis.MinorGrid.IsVisible = false;
            zedGrapgControl1.RestoreScale(zedGrapgControl1.GraphPane);
            zedGrapgControl1.AxisChange();
            zedGrapgControl1.Invalidate();
        }
        private void Scale(GraphPane pane)
        {
            pane.XAxis.Scale.MinAuto = true;
            pane.XAxis.Scale.MaxAuto = true;
            pane.YAxis.Scale.MinAuto = true;
            pane.YAxis.Scale.MaxAuto = true;
            zedGrapgControl1.AxisChange();
            zedGrapgControl1.Invalidate();
        }
        private void GriddenOn(GraphPane my_Pane)
        {
            my_Pane.XAxis.MajorGrid.IsVisible = true;
            my_Pane.YAxis.MajorGrid.IsVisible = true;
            my_Pane.YAxis.MinorGrid.IsVisible = true;
            my_Pane.XAxis.MinorGrid.IsVisible = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Tilt(sender, e);
        }

        private void AllInOne(ZedGraphControl Zed_GraphControl)
        {
            GraphPane my_Pane = Zed_GraphControl.GraphPane;
            double n = double.Parse(N_Box.Text);
            double a = 0, b = 1;
            double h = (b - a) / n;
            List<double> EilerX = new List<double> { };
            List<double> EilerY = new List<double> { };
            PointPairList listEiler = new PointPairList();
            double xE = 0;
            double yE = Math.Sqrt(2);
            string nameE = "N = " + n.ToString();
            while (xE < b)
            {
                EilerX.Add(xE);
                EilerY.Add(yE);
                listEiler.Add(xE, yE);
                yE = yE + h * f1(xE, yE); //делаем шаг
                xE += h;
            }
            my_Pane.AddCurve(nameE + "/Eiler", listEiler, Color.Red, SymbolType.None);
            ////////
            PointPairList listReal = new PointPairList();
            List<double> realX = new List<double> { };
            List<double> realY = new List<double> { };
            //double a = 0;
            //double yR = Math.Sqrt(2);
            string nameR = "N = " + n.ToString();
            for (int i = 0; i < n; i++)
            {
                realX.Add(i * h);
                realY.Add(realF1(realX[i]));
                listReal.Add(realX[i], realY[i]);
            }
            my_Pane.AddCurve(nameR + "/Real", listReal, Color.Blue, SymbolType.None);
            zedGrapgControl1.AxisChange();
            zedGrapgControl1.Invalidate();

            double maxNevyaz = 0, currentNevyaz;
            for (int i = 0; i < n; i++)
            {
                currentNevyaz = Math.Abs(EilerX[i] - realX[i]);
                if (currentNevyaz > maxNevyaz)
                    maxNevyaz = currentNevyaz;
            }
            NevyazLabel.Text = maxNevyaz.ToString();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            GriddenOn(zedGrapgControl1.GraphPane);
            AllInOne(zedGrapgControl1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clear(zedGrapgControl1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Scale(zedGrapgControl1.GraphPane);
        }
    }
}
