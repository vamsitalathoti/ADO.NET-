using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VEERA.ADO
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            int W = Screen.PrimaryScreen.Bounds.Width;
            int H = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(W, H);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
                form1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("USERID IS empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("PASWORD IS empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Veera Kuraganti\\OneDrive\\Documents\\ADB.mdf\";Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("select count (*) from udb where uid=@uid AND psw=@psw", con);
            cmd.Parameters.AddWithValue("@uid", textBox1.Text);
            cmd.Parameters.AddWithValue("@psw", textBox2.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("Login succsfully","INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form10 form10 = new Form10();
                    form10.ShowDialog();


            }
            else
            {
                MessageBox.Show("Invalid credentials",
                    "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please enter only ALPHABATIC", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please enter only Number's", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
