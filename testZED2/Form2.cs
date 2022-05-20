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

        private void button1_Click(object sender, EventArgs e)
        {
            Tilt(sender, e);
        }
        private void Eiler(ZedGraphControl Zed_GraphControl)
        {
            GraphPane my_Pane = Zed_GraphControl.GraphPane;
            PointPairList list = new PointPairList();
            double n = double.Parse(N_Box.Text);
            double h = 1 / n;
            double x = 0;
            double y = Math.Sqrt(2);
            string name = "N = " + n.ToString();
            while (x <= 1)
            {
                list.Add(x, y);
                y = y + h * f1(x, y); //делаем шаг
                x += h;
            }
            LineItem myCircle = my_Pane.AddCurve(name, list, Color.Red, SymbolType.None);
            zedGrapgControl1.AxisChange();
            zedGrapgControl1.Invalidate();
        }
        private void Tochno(ZedGraphControl Zed_GraphControl)
        {
            GraphPane my_Pane = Zed_GraphControl.GraphPane;
            PointPairList list = new PointPairList();


            double n = double.Parse(N_Box.Text);
            List<double> realX = new List<double> { };
            List<double> realY = new List<double> { };
            double a = 0;

            double h = 1 / n;
            double x = 0;
            double y = Math.Sqrt(2);
            string name = "N = " + n.ToString();
            for (int i = 0; i < n; i++)
            {
                realX.Add(a + i * h);
                realY.Add(realF1(realX[i]));
                list.Add(realX[i], realY[i]);
            }


            LineItem myCircle = my_Pane.AddCurve(name + "/", list, Color.Blue, SymbolType.None);
            zedGrapgControl1.AxisChange();
            zedGrapgControl1.Invalidate();
        }

        private void AllInOne(ZedGraphControl Zed_GraphControl)
        {
            GraphPane my_Pane = Zed_GraphControl.GraphPane;
            double n = double.Parse(N_Box.Text);
            double h = 1 / n;

            PointPairList listEiler = new PointPairList();

            double xE = 0;
            double yE = Math.Sqrt(2);
            string nameE = "N = " + n.ToString();
            while (xE <= 1)
            {
                listEiler.Add(xE, yE);
                yE = yE + h * f1(xE, yE); //делаем шаг
                xE += h;
            }
            my_Pane.AddCurve(nameE, listEiler, Color.Red, SymbolType.None);


            PointPairList listReal = new PointPairList();
            List<double> realX = new List<double> { };
            List<double> realY = new List<double> { };
            double a = 0;


            double xR = 0;
            double yR = Math.Sqrt(2);
            string name = "N = " + n.ToString();
            for (int i = 0; i < n; i++)
            {
                realX.Add(a + i * h);
                realY.Add(realF1(realX[i]));
                listReal.Add(realX[i], realY[i]);
            }


            my_Pane.AddCurve(name + "/", listReal, Color.Blue, SymbolType.None);
            zedGrapgControl1.AxisChange();
            zedGrapgControl1.Invalidate();


        }


        private void button2_Click(object sender, EventArgs e)
        {
            AllInOne(zedGrapgControl1);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
