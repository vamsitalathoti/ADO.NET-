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
    public partial class UserDetailsForm : Form
    {
        public string UserName { get; private set; }
        public string UserAddress { get; private set; }
        public String Number{  get; private set; }
        public UserDetailsForm()
        {
            InitializeComponent();
        }

        private void Form16_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserName = textBox1.Text;
            UserAddress = textBox2.Text;
            Number = textBox3.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
