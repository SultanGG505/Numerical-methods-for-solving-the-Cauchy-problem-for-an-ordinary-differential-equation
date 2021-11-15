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
    public partial class Form1 : Form
    {
        public static int n = 80;
        public static double h = 0.001;
        public double[] X = new double[n + 4];
        public double[] Y = new double[n + 4];
        ZedGraphControl zedGrapgControl1 = new ZedGraphControl();
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            zedGrapgControl1.Location = new Point(10, 30);
            zedGrapgControl1.Name = "text";
            zedGrapgControl1.Size = new Size(700, 700);
            Controls.Add(zedGrapgControl1);
        }
        private void GetSize()
        {
            zedGrapgControl1.Location = new Point(10, 10);
            zedGrapgControl1.Size = new Size(ClientRectangle.Width - 20, ClientRectangle.Height - 20);

        }
        protected override void OnSizeChanged(EventArgs e)
        {
            GetSize();
        }
        static double f(double x, double y)
        {
            return x * x - 2 * y;
        }

        private void Eiler(ZedGraphControl Zed_GraphControl)
        {
            GraphPane my_Pane = Zed_GraphControl.GraphPane;
            my_Pane.Title.Text = "Ex";
            my_Pane.XAxis.Title.Text = "Мое значение по X";
            my_Pane.YAxis.Title.Text = "Мое значение по Y";

            my_Pane.XAxis.MajorGrid.IsVisible = true;
            my_Pane.YAxis.MajorGrid.IsVisible = true;
            my_Pane.YAxis.MinorGrid.IsVisible = true;
            my_Pane.XAxis.MinorGrid.IsVisible = true;

            PointPairList list = new PointPairList();

            double a = 0, y0 = 1, x0 = a, x = x0, y = y0;


            for (int i = 0; i < n + 1; i++)
            {
                list.Add(x, y);
                y = y + h * f(x, y); //делаем шаг
                x += h;
            }
            LineItem myCircle = my_Pane.AddCurve("МЭ", list, Color.Red, SymbolType.Circle);
            zedGrapgControl1.AxisChange();
            zedGrapgControl1.Invalidate();
        }
        private void BetterEiler(ZedGraphControl Zed_GraphControl)
        {
            GraphPane my_Pane = Zed_GraphControl.GraphPane;
            my_Pane.Title.Text = "Ex";
            my_Pane.XAxis.Title.Text = "Мое значение по X";
            my_Pane.YAxis.Title.Text = "Мое значение по Y";

            my_Pane.XAxis.MajorGrid.IsVisible = true;
            my_Pane.YAxis.MajorGrid.IsVisible = true;
            my_Pane.YAxis.MinorGrid.IsVisible = true;
            my_Pane.XAxis.MinorGrid.IsVisible = true;

            PointPairList list = new PointPairList();

            double a = 0, h = 0.1, y0 = 1, x0 = a, x = x0, y = y0;


            for (int i = 0; i < n + 1; i++)
            {
                list.Add(x, y);
                y = y + h * f(x + h / 2, y + (h / 2) * f(x, y)); //делаем шаг
                x += h;
            }
            LineItem myCircle = my_Pane.AddCurve("УМЭ", list, Color.Orange, SymbolType.Circle);
            zedGrapgControl1.AxisChange();
            zedGrapgControl1.Invalidate();
        }


        private void RungeKutto2(ZedGraphControl Zed_GraphControl)
        {
            GraphPane my_Pane = Zed_GraphControl.GraphPane;
            my_Pane.Title.Text = "Ex";
            my_Pane.XAxis.Title.Text = "Мое значение по X";
            my_Pane.YAxis.Title.Text = "Мое значение по Y";

            my_Pane.XAxis.MajorGrid.IsVisible = true;
            my_Pane.YAxis.MajorGrid.IsVisible = true;
            my_Pane.YAxis.MinorGrid.IsVisible = true;
            my_Pane.XAxis.MinorGrid.IsVisible = true;

            PointPairList list = new PointPairList();


            double a = 0, h = 0.1, y0 = 1, x0 = a, x = x0, y = y0;


            for (int i = 0; i < n + 1; i++)
            {
                list.Add(x, y);
                double d = f(x, y);
                y = y + (h / 2) * (d + f(x + h, y + h * d)); //делаем шаг
                x += h;
            }
            LineItem myCircle = my_Pane.AddCurve("МРК2", list, Color.Yellow, SymbolType.Circle);
            zedGrapgControl1.AxisChange();
            zedGrapgControl1.Invalidate();
        }


        private void RungeKutto4(ZedGraphControl Zed_GraphControl)
        {
            GraphPane my_Pane = Zed_GraphControl.GraphPane;
            my_Pane.Title.Text = "Ex";
            my_Pane.XAxis.Title.Text = "Мое значение по X";
            my_Pane.YAxis.Title.Text = "Мое значение по Y";

            my_Pane.XAxis.MajorGrid.IsVisible = true;
            my_Pane.YAxis.MajorGrid.IsVisible = true;
            my_Pane.YAxis.MinorGrid.IsVisible = true;
            my_Pane.XAxis.MinorGrid.IsVisible = true;

            PointPairList list = new PointPairList();


            double a = 0, h = 0.1, y0 = 1, x0 = a, x = x0, y = y0, k1, k2, k3, k4;


            for (int i = 0; i < n + 1; i++)
            {
                list.Add(x, y);
                k1 = f(x, y);
                k2 = f(x + h / 2, y + (h * k1) / 2);
                k3 = f(x + h / 2, y + (h * k2) / 2);
                k4 = f(x + h, y + h * k3);
                y = y + (h / 6) * (k1 + 2 * k2 + 2 * k3 + k4); //делаем шаг
                x += h;
            }
            LineItem myCircle = my_Pane.AddCurve("МРК4", list, Color.Green, SymbolType.Circle);
            zedGrapgControl1.AxisChange();
            zedGrapgControl1.Invalidate();
        }
        private void YavnAdam4(ZedGraphControl Zed_GraphControl)
        {
            GraphPane my_Pane = Zed_GraphControl.GraphPane;
            my_Pane.Title.Text = "Ex";
            my_Pane.XAxis.Title.Text = "Мое значение по X";
            my_Pane.YAxis.Title.Text = "Мое значение по Y";

            my_Pane.XAxis.MajorGrid.IsVisible = true;
            my_Pane.YAxis.MajorGrid.IsVisible = true;
            my_Pane.YAxis.MinorGrid.IsVisible = true;
            my_Pane.XAxis.MinorGrid.IsVisible = true;

            PointPairList list = new PointPairList();

            X[0] = 0; Y[0] = 1;
            double a = 0, h = 0.1, y0 = 1, x0 = a, x = x0, y = y0, k1, k2, k3, k4;


            for (int k = 0; k < 4; k++)
            {

                k1 = f(X[k], Y[k]);
                k2 = f(X[k] + h / 2, Y[k] + (h * k1) / 2);
                k3 = f(X[k] + h / 2, Y[k] + (h * k2) / 2);
                k4 = f(X[k] + h, Y[k] + h * k3);
                Y[k + 1] = Y[k] + (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                X[k + 1] = X[k] + h;


                list.Add(X[k], Y[k]);
            }
            for (int k = 4; k < n + 1; k++)
            {

                Y[k + 1] = Y[k] + h * ((55 / 24) * f(X[k], Y[k]) - (59 / 24) * f(X[k - 1], Y[k - 1]) + (37 / 24) * f(X[k - 2], Y[k - 2]) - (3 / 8) * f(X[k - 3], Y[k - 3]));
                X[k + 1] = X[k] + h;
                list.Add(X[k], Y[k]);

            }
            LineItem myCircle = my_Pane.AddCurve("ЯМА4", list, Color.Cyan, SymbolType.Circle);
            zedGrapgControl1.AxisChange();
            zedGrapgControl1.Invalidate();
        }

        private void NotYavnA2(ZedGraphControl Zed_GraphControl)
        {
            GraphPane my_Pane = Zed_GraphControl.GraphPane;
            my_Pane.Title.Text = "Ex";
            my_Pane.XAxis.Title.Text = "Мое значение по X";
            my_Pane.YAxis.Title.Text = "Мое значение по Y";

            my_Pane.XAxis.MajorGrid.IsVisible = true;
            my_Pane.YAxis.MajorGrid.IsVisible = true;
            my_Pane.YAxis.MinorGrid.IsVisible = true;
            my_Pane.XAxis.MinorGrid.IsVisible = true;

            PointPairList list = new PointPairList();

            X[0] = 0; Y[0] = 1;
            double a = 0, h = 0.1, y0 = 1, x0 = a, x = x0, y = y0, k1, k2, k3, k4;


            for (int k = 0; k < 1; k++)
            {

                k1 = f(X[k], Y[k]);
                k2 = f(X[k] + h / 2, Y[k] + (h * k1) / 2);
                k3 = f(X[k] + h / 2, Y[k] + (h * k2) / 2);
                k4 = f(X[k] + h, Y[k] + h * k3);
                Y[k + 1] = Y[k] + (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                X[k + 1] = X[k] + h;


                list.Add(X[k], Y[k]);
            }
            for (int k = 1; k < n + 1; k++)
            {

                Y[k + 1] = Y[k] + (h / 2) * f(X[k + 1], Y[k + 1]) + f(X[k], Y[k]);
                X[k + 1] = X[k] + h;
                list.Add(X[k], Y[k]);

            }
            LineItem myCircle = my_Pane.AddCurve("НМА2", list, Color.Blue, SymbolType.Circle);
            zedGrapgControl1.AxisChange();
            zedGrapgControl1.Invalidate();
        }
        private void Scale(ZedGraphControl Zed_GraphControl)
        {
            GraphPane pane = Zed_GraphControl.GraphPane;
            // Установим масштаб по умолчанию для оси X
            pane.XAxis.Scale.MinAuto = true;
            pane.XAxis.Scale.MaxAuto = true;

            // Установим масштаб по умолчанию для оси Y
            pane.YAxis.Scale.MinAuto = true;
            pane.YAxis.Scale.MaxAuto = true;

            zedGrapgControl1.AxisChange();
            zedGrapgControl1.Invalidate();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Eiler(zedGrapgControl1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BetterEiler(zedGrapgControl1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RungeKutto4(zedGrapgControl1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RungeKutto2(zedGrapgControl1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Scale(zedGrapgControl1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            YavnAdam4(zedGrapgControl1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            NotYavnA2(zedGrapgControl1);
        }

    }
}
