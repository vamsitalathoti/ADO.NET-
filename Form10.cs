using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VEERA.ADO
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
          Application.Exit();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            int W = Screen.PrimaryScreen.Bounds.Width;
            int H = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(W, H);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();
                form11.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form12 form12 = new Form12();
                form12.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form13 form13 = new Form13();
            form13.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form15 form15 = new Form15();
                form15.ShowDialog();

        }
    }
}
