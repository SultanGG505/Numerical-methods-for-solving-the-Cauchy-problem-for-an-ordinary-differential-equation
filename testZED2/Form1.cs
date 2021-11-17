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
        public static int n;
        public string ME = "Euler's method.";
        public string BME = "an improved Euler method.";
        public string MRK2 = "the Runge-Kutta method of the second order.";
        public string MRK4 = "the fourth-order Runge-Kutta method.";
        public string YavnA4 = "an explicit Adams method of the fourth order.";
        public string NeYavnA2 = "the second-order implicit Adams method.";



        string selectedCountry = "0";
        public string varFunc = "0";
        public string varPoint = "0";
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
        protected override void OnSizeChanged(EventArgs e)
        {
            GetSize();
        }
        static double f1(double x, double y)
        {
            return x * x - 2 * y;
        }
        static double f2(double x, double y)
        {
            return Math.Pow(Math.E, x) - y;
        }
        static double f3(double x, double y)
        {
            return x * Math.Pow(Math.E, Math.Pow(-x, 2)) - 2 * x * y;
        }


        private void Eiler(ZedGraphControl Zed_GraphControl)
        {
            GraphPane my_Pane = Zed_GraphControl.GraphPane;

            PointPairList list = new PointPairList();
            double[] X = new double[n + 4];
            double[] Y = new double[n + 4];

            double a = 0, h = 0.1, y0 = 1, x0 = a, x = x0, y = y0;

            if (varPoint != "0")
            {
                if (varFunc == "1")
                {
                    for (int i = 0; i < n + 1; i++)
                    {
                        list.Add(x, y);
                        y = y + h * f1(x, y); //делаем шаг
                        x += h;
                    }
                }
                if (varFunc == "2")
                {
                    for (int i = 0; i < n + 1; i++)
                    {
                        list.Add(x, y);
                        y = y + h * f2(x, y); //делаем шаг
                        x += h;
                    }
                }
                if (varFunc == "3")
                {
                    for (int i = 0; i < n + 1; i++)
                    {
                        list.Add(x, y);
                        y = y + h * f3(x, y); //делаем шаг
                        x += h;
                    }
                }
                if (varFunc != "0")
                {
                    LineItem myCircle = my_Pane.AddCurve(ME, list, Color.Red, SymbolType.Circle);
                    zedGrapgControl1.AxisChange();
                    zedGrapgControl1.Invalidate();
                }
                if (varFunc == "0")
                {
                    MessageBox.Show("select a function");
                }

            }
            else
            {
                MessageBox.Show("Enter count of points");
            }


        }
        private void BetterEiler(ZedGraphControl Zed_GraphControl)
        {
            GraphPane my_Pane = Zed_GraphControl.GraphPane;

            PointPairList list = new PointPairList();

            double a = 0, h = 0.1, y0 = 1, x0 = a, x = x0, y = y0;

            if (varPoint != "0")
            {
                if (varFunc == "1")
                {
                    for (int i = 0; i < n + 1; i++)
                    {
                        list.Add(x, y);
                        y = y + h * f1(x + h / 2, y + (h / 2) * f1(x, y)); //делаем шаг
                        x += h;
                    }
                }
                if (varFunc == "2")
                {
                    for (int i = 0; i < n + 1; i++)
                    {
                        list.Add(x, y);
                        y = y + h * f2(x + h / 2, y + (h / 2) * f2(x, y)); //делаем шаг
                        x += h;
                    }
                }
                if (varFunc == "3")
                {
                    for (int i = 0; i < n + 1; i++)
                    {
                        list.Add(x, y);
                        y = y + h * f3(x + h / 2, y + (h / 2) * f3(x, y)); //делаем шаг
                        x += h;
                    }
                }
                if (varFunc != "0")
                {
                    LineItem myCircle = my_Pane.AddCurve(BME, list, Color.Orange, SymbolType.Circle);
                    zedGrapgControl1.AxisChange();
                    zedGrapgControl1.Invalidate();
                }
                if (varFunc == "0")
                {
                    MessageBox.Show("select a function");
                }

            }
            else
            {
                MessageBox.Show("Enter count of points");
            }


        }


        private void RungeKutto2(ZedGraphControl Zed_GraphControl)
        {
            GraphPane my_Pane = Zed_GraphControl.GraphPane;

            PointPairList list = new PointPairList();


            double a = 0, h = 0.1, y0 = 1, x0 = a, x = x0, y = y0;

            if (varPoint != "0")
            {
                if (varFunc == "1")
                {
                    for (int i = 0; i < n + 1; i++)
                    {
                        list.Add(x, y);
                        double d = f1(x, y);
                        y = y + (h / 2) * (d + f1(x + h, y + h * d)); //делаем шаг
                        x += h;
                    }
                }
                if (varFunc == "2")
                {
                    for (int i = 0; i < n + 1; i++)
                    {
                        list.Add(x, y);
                        double d = f2(x, y);
                        y = y + (h / 2) * (d + f2(x + h, y + h * d)); //делаем шаг
                        x += h;
                    }
                }
                if (varFunc == "3")
                {
                    for (int i = 0; i < n + 1; i++)
                    {
                        list.Add(x, y);
                        double d = f3(x, y);
                        y = y + (h / 2) * (d + f3(x + h, y + h * d)); //делаем шаг
                        x += h;
                    }
                }
                if (varFunc != "0")
                {
                    LineItem myCircle = my_Pane.AddCurve(MRK2, list, Color.Yellow, SymbolType.Circle);
                    zedGrapgControl1.AxisChange();
                    zedGrapgControl1.Invalidate();
                }
                if (varFunc == "0")
                {
                    MessageBox.Show("select a function");
                }

            }
            else
            {
                MessageBox.Show("Enter count of points");
            }

        }
        private void RungeKutto4(ZedGraphControl Zed_GraphControl)
        {
            GraphPane my_Pane = Zed_GraphControl.GraphPane;
            PointPairList list = new PointPairList();
            double a = 0, h = 0.1, y0 = 1, x0 = a, x = x0, y = y0, k1, k2, k3, k4;

            if (varPoint != "0")
            {
                if (varFunc == "1")
                {
                    for (int i = 0; i < n + 1; i++)
                    {
                        list.Add(x, y);
                        k1 = f1(x, y);
                        k2 = f1(x + h / 2, y + (h * k1) / 2);
                        k3 = f1(x + h / 2, y + (h * k2) / 2);
                        k4 = f1(x + h, y + h * k3);
                        y = y + (h / 6) * (k1 + 2 * k2 + 2 * k3 + k4); //делаем шаг
                        x += h;
                    }
                }
                if (varFunc == "2")
                {
                    for (int i = 0; i < n + 1; i++)
                    {
                        list.Add(x, y);
                        k1 = f2(x, y);
                        k2 = f2(x + h / 2, y + (h * k1) / 2);
                        k3 = f2(x + h / 2, y + (h * k2) / 2);
                        k4 = f2(x + h, y + h * k3);
                        y = y + (h / 6) * (k1 + 2 * k2 + 2 * k3 + k4); //делаем шаг
                        x += h;
                    }
                }
                if (varFunc == "3")
                {
                    for (int i = 0; i < n + 1; i++)
                    {
                        list.Add(x, y);
                        k1 = f3(x, y);
                        k2 = f3(x + h / 2, y + (h * k1) / 2);
                        k3 = f3(x + h / 2, y + (h * k2) / 2);
                        k4 = f3(x + h, y + h * k3);
                        y = y + (h / 6) * (k1 + 2 * k2 + 2 * k3 + k4); //делаем шаг
                        x += h;
                    }
                }
                if (varFunc != "0")
                {
                    LineItem myCircle = my_Pane.AddCurve(MRK4, list, Color.Green, SymbolType.Circle);
                    zedGrapgControl1.AxisChange();
                    zedGrapgControl1.Invalidate();
                }
                if (varFunc == "0")
                {
                    MessageBox.Show("select a function");
                }
            }
            else
            {
                MessageBox.Show("Enter count of points");
            }
        }
        private void YavnAdam4(ZedGraphControl Zed_GraphControl)
        {
            GraphPane my_Pane = Zed_GraphControl.GraphPane;
            PointPairList list = new PointPairList();
            double[] X = new double[n + 4];
            double[] Y = new double[n + 4];
            X[0] = 0; Y[0] = 1;
            double a = 0, h = 0.1, y0 = 1, x0 = a, x = x0, y = y0, k1, k2, k3, k4;

            if (varPoint != "0")
            {
                if (varFunc == "1")
                {
                    for (int k = 0; k < 4; k++)
                    {
                        k1 = f1(X[k], Y[k]);
                        k2 = f1(X[k] + h / 2, Y[k] + (h * k1) / 2);
                        k3 = f1(X[k] + h / 2, Y[k] + (h * k2) / 2);
                        k4 = f1(X[k] + h, Y[k] + h * k3);
                        Y[k + 1] = Y[k] + (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                        X[k + 1] = X[k] + h;
                        list.Add(X[k], Y[k]);
                    }
                    for (int k = 4; k < n + 1; k++)
                    {
                        Y[k + 1] = Y[k] + (h / 24) * (55 * f1(X[k], Y[k]) - 59 * f1(X[k - 1], Y[k - 1]) + 37 * f1(X[k - 2], Y[k - 2]) - 9 * f1(X[k - 3], Y[k - 3]));
                        X[k + 1] = X[k] + h;
                        list.Add(X[k], Y[k]);
                    }
                }
                if (varFunc == "2")
                {
                    for (int k = 0; k < 4; k++)
                    {
                        k1 = f2(X[k], Y[k]);
                        k2 = f2(X[k] + h / 2, Y[k] + (h * k1) / 2);
                        k3 = f2(X[k] + h / 2, Y[k] + (h * k2) / 2);
                        k4 = f2(X[k] + h, Y[k] + h * k3);
                        Y[k + 1] = Y[k] + (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                        X[k + 1] = X[k] + h;
                        list.Add(X[k], Y[k]);
                    }
                    for (int k = 4; k < n + 1; k++)
                    {
                        Y[k + 1] = Y[k] + (h / 24) * (55 * f2(X[k], Y[k]) - 59 * f2(X[k - 1], Y[k - 1]) + 37 * f2(X[k - 2], Y[k - 2]) - 9 * f2(X[k - 3], Y[k - 3]));
                        X[k + 1] = X[k] + h;
                        list.Add(X[k], Y[k]);
                    }
                }
                if (varFunc == "3")
                {
                    for (int k = 0; k < 4; k++)
                    {
                        k1 = f3(X[k], Y[k]);
                        k2 = f3(X[k] + h / 2, Y[k] + (h * k1) / 2);
                        k3 = f3(X[k] + h / 2, Y[k] + (h * k2) / 2);
                        k4 = f3(X[k] + h, Y[k] + h * k3);
                        Y[k + 1] = Y[k] + (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                        X[k + 1] = X[k] + h;
                        list.Add(X[k], Y[k]);
                    }
                    for (int k = 4; k < n + 1; k++)
                    {
                        Y[k + 1] = Y[k] + (h / 24) * (55 * f3(X[k], Y[k]) - 59 * f3(X[k - 1], Y[k - 1]) + 37 * f3(X[k - 2], Y[k - 2]) - 9 * f3(X[k - 3], Y[k - 3]));
                        X[k + 1] = X[k] + h;
                        list.Add(X[k], Y[k]);
                    }
                }
                if (varFunc != "0")
                {
                    LineItem myCircle = my_Pane.AddCurve(YavnA4, list, Color.Cyan, SymbolType.Circle);
                    zedGrapgControl1.AxisChange();
                    zedGrapgControl1.Invalidate();
                }
                if (varFunc == "0")
                {
                    MessageBox.Show("select a function");
                }
            }
            else
            {
                MessageBox.Show("Enter count of points");
            }

        }

        private void NotYavnA2(ZedGraphControl Zed_GraphControl)
        {
            GraphPane my_Pane = Zed_GraphControl.GraphPane;
            PointPairList list = new PointPairList();
            double[] X = new double[n + 4];
            double[] Y = new double[n + 4];
            X[0] = 0; Y[0] = 1;
            double a = 0, h = 0.1, y0 = 1, x0 = a, x = x0, y = y0, k1, k2, k3, k4;

            if (varPoint != "0")
            {
                if (varFunc == "1")
                {
                    for (int k = 0; k < 1; k++) // ПЕРЕДАЛАТЬ НА МЕТОД ЭЙЛЕРА
                    {

                        k1 = f1(X[k], Y[k]);
                        k2 = f1(X[k] + h / 2, Y[k] + (h * k1) / 2);
                        k3 = f1(X[k] + h / 2, Y[k] + (h * k2) / 2);
                        k4 = f1(X[k] + h, Y[k] + h * k3);
                        Y[k + 1] = Y[k] + (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                        X[k + 1] = X[k] + h;


                        list.Add(X[k], Y[k]);
                    }
                    for (int k = 1; k < n + 1; k++)
                    {

                        Y[k + 1] = Y[k] + (h / 2) * f1(X[k + 1], Y[k + 1]) + f1(X[k], Y[k]);
                        X[k + 1] = X[k] + h;
                        list.Add(X[k], Y[k]);

                    }
                }
                if (varFunc == "2")
                {
                    for (int k = 0; k < 1; k++) // ПЕРЕДАЛАТЬ НА МЕТОД ЭЙЛЕРА
                    {

                        k1 = f2(X[k], Y[k]);
                        k2 = f2(X[k] + h / 2, Y[k] + (h * k1) / 2);
                        k3 = f2(X[k] + h / 2, Y[k] + (h * k2) / 2);
                        k4 = f2(X[k] + h, Y[k] + h * k3);
                        Y[k + 1] = Y[k] + (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                        X[k + 1] = X[k] + h;


                        list.Add(X[k], Y[k]);
                    }
                    for (int k = 1; k < n + 1; k++)
                    {

                        Y[k + 1] = Y[k] + (h / 2) * f2(X[k + 1], Y[k + 1]) + f2(X[k], Y[k]);
                        X[k + 1] = X[k] + h;
                        list.Add(X[k], Y[k]);

                    }
                }
                if (varFunc == "3")
                {
                    for (int k = 0; k < 1; k++) // ПЕРЕДАЛАТЬ НА МЕТОД ЭЙЛЕРА
                    {

                        k1 = f3(X[k], Y[k]);
                        k2 = f3(X[k] + h / 2, Y[k] + (h * k1) / 2);
                        k3 = f3(X[k] + h / 2, Y[k] + (h * k2) / 2);
                        k4 = f3(X[k] + h, Y[k] + h * k3);
                        Y[k + 1] = Y[k] + (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                        X[k + 1] = X[k] + h;


                        list.Add(X[k], Y[k]);
                    }
                    for (int k = 1; k < n + 1; k++)
                    {

                        Y[k + 1] = Y[k] + (h / 2) * f3(X[k + 1], Y[k + 1]) + f3(X[k], Y[k]);
                        X[k + 1] = X[k] + h;
                        list.Add(X[k], Y[k]);

                    }
                }
                if (varFunc != "0")
                {
                    LineItem myCircle = my_Pane.AddCurve(NeYavnA2, list, Color.Blue, SymbolType.Circle);
                    zedGrapgControl1.AxisChange();
                    zedGrapgControl1.Invalidate();
                }
                if (varFunc == "0")
                {
                    MessageBox.Show("select a function");
                }

            }
            else
            {
                MessageBox.Show("Enter count of points");
            }
        }

        private void GriddenOn(GraphPane my_Pane)
        {
            //GraphPane my_Pane = Zed_GraphControl.GraphPane;



            my_Pane.XAxis.MajorGrid.IsVisible = true;
            my_Pane.YAxis.MajorGrid.IsVisible = true;
            my_Pane.YAxis.MinorGrid.IsVisible = true;
            my_Pane.XAxis.MinorGrid.IsVisible = true;
        }
        private void Scale(GraphPane pane)
        {
            //GraphPane pane = Zed_GraphControl.GraphPane;
            // Установим масштаб по умолчанию для оси X
            pane.XAxis.Scale.MinAuto = true;
            pane.XAxis.Scale.MaxAuto = true;

            // Установим масштаб по умолчанию для оси Y
            pane.YAxis.Scale.MinAuto = true;
            pane.YAxis.Scale.MaxAuto = true;

            zedGrapgControl1.AxisChange();
            zedGrapgControl1.Invalidate();
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
        private void BTN_EM(object sender, EventArgs e)
        {
            GriddenOn(zedGrapgControl1.GraphPane);
            Eiler(zedGrapgControl1);

        }

        private void BTN_BEM(object sender, EventArgs e)
        {
            GriddenOn(zedGrapgControl1.GraphPane);

            BetterEiler(zedGrapgControl1);
        }

        private void BTN_RK4(object sender, EventArgs e)
        {
            GriddenOn(zedGrapgControl1.GraphPane);

            RungeKutto4(zedGrapgControl1);
        }

        private void BTN_RK2(object sender, EventArgs e)
        {
            GriddenOn(zedGrapgControl1.GraphPane);

            RungeKutto2(zedGrapgControl1);
        }

        private void BTN_Scale(object sender, EventArgs e)
        {
            Scale(zedGrapgControl1.GraphPane);


        }

        private void BTN_AM4(object sender, EventArgs e)
        {
            GriddenOn(zedGrapgControl1.GraphPane);

            YavnAdam4(zedGrapgControl1);
        }

        private void BTN_AM2(object sender, EventArgs e)
        {
            GriddenOn(zedGrapgControl1.GraphPane);

            NotYavnA2(zedGrapgControl1);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedCountry = SelectFuncBox.SelectedItem.ToString();
                switch (selectedCountry)
                {
                    case "1)  y' = x * x - 2 * y":
                        ResOfSelection.Text = " y' = x * x - 2 * y";
                        varFunc = "1";
                        break;
                    case "2) y' = e^x-y":
                        ResOfSelection.Text = "y' = e^x-y";
                        varFunc = "2";
                        break;
                    case "3) y' = x * e^(-x^2)-2xy":
                        ResOfSelection.Text = "y' = x * e^(-x^2)-2xy";
                        varFunc = "3";
                        break;
                    default:
                        ResOfSelection.Text = "choose varFunciant";
                        varFunc = "0";
                        break;
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("You have not selected a function!");
            }


            //MessageBox.Show(selectedCountry);
        }

        private void BTN_Clear(object sender, EventArgs e)
        {
            Clear(zedGrapgControl1);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SelectCountOfPoints.Text))
            {
                varPoint = "0";
                //MessageBox.Show("Enter number of points!");
            }

            else
            {
                varPoint = "1";
                n = Convert.ToInt32(SelectCountOfPoints.Text);
            }
        }

        private void SelectCountOfPoints_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void StartingXInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void StartintYInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }
    }
}
