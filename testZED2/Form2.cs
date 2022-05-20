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
            this.BackColor = Color.SeaShell;
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
            Tilt(sender,e);
        }
    }
}
