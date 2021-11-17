
namespace testZED2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.EM = new System.Windows.Forms.Button();
            this.BEM = new System.Windows.Forms.Button();
            this.RK4 = new System.Windows.Forms.Button();
            this.RK2 = new System.Windows.Forms.Button();
            this.SetDefScale = new System.Windows.Forms.Button();
            this.AM4 = new System.Windows.Forms.Button();
            this.AM2 = new System.Windows.Forms.Button();
            this.SelectFuncBox = new System.Windows.Forms.ListBox();
            this.ClearAll = new System.Windows.Forms.Button();
            this.SelectCountOfPoints = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ResOfSelection = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.StartingXInput = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.StartintYInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // EM
            // 
            this.EM.BackColor = System.Drawing.SystemColors.Highlight;
            this.EM.Location = new System.Drawing.Point(950, 30);
            this.EM.Name = "EM";
            this.EM.Size = new System.Drawing.Size(178, 56);
            this.EM.TabIndex = 0;
            this.EM.Text = "Euler\'s method";
            this.EM.UseVisualStyleBackColor = false;
            this.EM.Click += new System.EventHandler(this.BTN_EM);
            // 
            // BEM
            // 
            this.BEM.BackColor = System.Drawing.SystemColors.Highlight;
            this.BEM.Location = new System.Drawing.Point(950, 92);
            this.BEM.Name = "BEM";
            this.BEM.Size = new System.Drawing.Size(178, 79);
            this.BEM.TabIndex = 1;
            this.BEM.Text = "an improved Euler method";
            this.BEM.UseVisualStyleBackColor = false;
            this.BEM.Click += new System.EventHandler(this.BTN_BEM);
            // 
            // RK4
            // 
            this.RK4.BackColor = System.Drawing.SystemColors.Highlight;
            this.RK4.Location = new System.Drawing.Point(950, 273);
            this.RK4.Name = "RK4";
            this.RK4.Size = new System.Drawing.Size(178, 73);
            this.RK4.TabIndex = 2;
            this.RK4.Text = "the fourth-order Runge-Kutta method\n";
            this.RK4.UseVisualStyleBackColor = false;
            this.RK4.Click += new System.EventHandler(this.BTN_RK4);
            // 
            // RK2
            // 
            this.RK2.BackColor = System.Drawing.SystemColors.Highlight;
            this.RK2.Location = new System.Drawing.Point(950, 187);
            this.RK2.Name = "RK2";
            this.RK2.Size = new System.Drawing.Size(178, 70);
            this.RK2.TabIndex = 3;
            this.RK2.Text = "the Runge-Kutta method of the second order\n";
            this.RK2.UseVisualStyleBackColor = false;
            this.RK2.Click += new System.EventHandler(this.BTN_RK2);
            // 
            // SetDefScale
            // 
            this.SetDefScale.Location = new System.Drawing.Point(950, 622);
            this.SetDefScale.Name = "SetDefScale";
            this.SetDefScale.Size = new System.Drawing.Size(144, 55);
            this.SetDefScale.TabIndex = 4;
            this.SetDefScale.Text = "set default scale";
            this.SetDefScale.UseVisualStyleBackColor = true;
            this.SetDefScale.Click += new System.EventHandler(this.BTN_Scale);
            // 
            // AM4
            // 
            this.AM4.BackColor = System.Drawing.SystemColors.Highlight;
            this.AM4.Location = new System.Drawing.Point(950, 370);
            this.AM4.Name = "AM4";
            this.AM4.Size = new System.Drawing.Size(178, 59);
            this.AM4.TabIndex = 5;
            this.AM4.Text = "an explicit Adams method of the fourth order\n";
            this.AM4.UseVisualStyleBackColor = false;
            this.AM4.Click += new System.EventHandler(this.BTN_AM4);
            // 
            // AM2
            // 
            this.AM2.BackColor = System.Drawing.SystemColors.Highlight;
            this.AM2.Location = new System.Drawing.Point(950, 448);
            this.AM2.Name = "AM2";
            this.AM2.Size = new System.Drawing.Size(178, 60);
            this.AM2.TabIndex = 6;
            this.AM2.Text = "the second-order implicit Adams method";
            this.AM2.UseVisualStyleBackColor = false;
            this.AM2.Click += new System.EventHandler(this.BTN_AM2);
            // 
            // SelectFuncBox
            // 
            this.SelectFuncBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.SelectFuncBox.FormattingEnabled = true;
            this.SelectFuncBox.ItemHeight = 16;
            this.SelectFuncBox.Items.AddRange(new object[] {
            "1)  y\' = x * x - 2 * y",
            "2) y\' = e^x-y",
            "3) y\' = x * e^(-x^2)-2xy"});
            this.SelectFuncBox.Location = new System.Drawing.Point(735, 48);
            this.SelectFuncBox.Name = "SelectFuncBox";
            this.SelectFuncBox.Size = new System.Drawing.Size(152, 84);
            this.SelectFuncBox.TabIndex = 7;
            this.SelectFuncBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // ClearAll
            // 
            this.ClearAll.Location = new System.Drawing.Point(770, 622);
            this.ClearAll.Name = "ClearAll";
            this.ClearAll.Size = new System.Drawing.Size(135, 55);
            this.ClearAll.TabIndex = 8;
            this.ClearAll.Text = "clear all";
            this.ClearAll.UseVisualStyleBackColor = true;
            this.ClearAll.Click += new System.EventHandler(this.BTN_Clear);
            // 
            // SelectCountOfPoints
            // 
            this.SelectCountOfPoints.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.SelectCountOfPoints.Location = new System.Drawing.Point(735, 298);
            this.SelectCountOfPoints.Name = "SelectCountOfPoints";
            this.SelectCountOfPoints.Size = new System.Drawing.Size(100, 22);
            this.SelectCountOfPoints.TabIndex = 12;
            this.SelectCountOfPoints.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            this.SelectCountOfPoints.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SelectCountOfPoints_KeyPress);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(732, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "select a function below";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(732, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "selected function:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(732, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 23);
            this.label3.TabIndex = 15;
            this.label3.Text = "Write count of points";
            // 
            // ResOfSelection
            // 
            this.ResOfSelection.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ResOfSelection.Location = new System.Drawing.Point(732, 195);
            this.ResOfSelection.Name = "ResOfSelection";
            this.ResOfSelection.Size = new System.Drawing.Size(184, 62);
            this.ResOfSelection.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DarkCyan;
            this.label5.Location = new System.Drawing.Point(732, 473);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 26);
            this.label5.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(732, 448);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 23);
            this.label6.TabIndex = 18;
            this.label6.Text = "current X";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(859, 448);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 23);
            this.label7.TabIndex = 19;
            this.label7.Text = "current Y";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.DarkCyan;
            this.label8.Location = new System.Drawing.Point(859, 473);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 26);
            this.label8.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(732, 332);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(173, 23);
            this.label9.TabIndex = 22;
            this.label9.Text = "enter the starting point X";
            // 
            // StartingXInput
            // 
            this.StartingXInput.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.StartingXInput.Location = new System.Drawing.Point(735, 358);
            this.StartingXInput.Name = "StartingXInput";
            this.StartingXInput.Size = new System.Drawing.Size(100, 22);
            this.StartingXInput.TabIndex = 21;
            this.StartingXInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StartingXInput_KeyPress);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(732, 383);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(173, 23);
            this.label10.TabIndex = 24;
            this.label10.Text = "enter the starting point X";
            // 
            // StartintYInput
            // 
            this.StartintYInput.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.StartintYInput.Location = new System.Drawing.Point(735, 409);
            this.StartintYInput.Name = "StartintYInput";
            this.StartintYInput.Size = new System.Drawing.Size(100, 22);
            this.StartintYInput.TabIndex = 23;
            this.StartintYInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StartintYInput_KeyPress);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1160, 740);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.StartintYInput);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.StartingXInput);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ResOfSelection);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectCountOfPoints);
            this.Controls.Add(this.ClearAll);
            this.Controls.Add(this.SelectFuncBox);
            this.Controls.Add(this.AM2);
            this.Controls.Add(this.AM4);
            this.Controls.Add(this.SetDefScale);
            this.Controls.Add(this.RK2);
            this.Controls.Add(this.RK4);
            this.Controls.Add(this.BEM);
            this.Controls.Add(this.EM);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "graphical representation of numerical methods for solving Cauchy problems for an " +
    "ordinary differential equation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button EM;
        private System.Windows.Forms.Button BEM;
        private System.Windows.Forms.Button RK4;
        private System.Windows.Forms.Button RK2;
        private System.Windows.Forms.Button SetDefScale;
        private System.Windows.Forms.Button AM4;
        private System.Windows.Forms.Button AM2;
        private System.Windows.Forms.ListBox SelectFuncBox;
        private System.Windows.Forms.Button ClearAll;
        private System.Windows.Forms.TextBox SelectCountOfPoints;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ResOfSelection;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox StartingXInput;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox StartintYInput;
    }
}

