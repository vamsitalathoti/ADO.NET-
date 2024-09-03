using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace VEERA.ADO
{
    public partial class Form4 : Form
    {
        private byte[] userPhoto;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            int W = Screen.PrimaryScreen.Bounds.Width;
            int H = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(W, H);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("FIRST NAME empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("LAST NAME IS empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("CONTACT NUMBER IS empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("ADDRESS IS empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("CONFORM PASSWORD IS empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("SET PASSWORD IS empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("CREATE USERID empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("STATE ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (textBox2.Text != textBox1.Text)
            {
                MessageBox.Show("SET PASSWORD AND CONFORM PASSWORD IS NOT SAME ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (textBox6.Text.Length != 10)
            {
                MessageBox.Show("INVALID  CONTACT NUMBER ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Veera Kuraganti\\OneDrive\\Documents\\ADB.mdf\";Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand checkCmd = new SqlCommand("select count(*) from udb where uid=@uid", con);
            checkCmd.Parameters.AddWithValue("@uid", textBox3.Text);
            int count = (int)checkCmd.ExecuteScalar();

            if (count > 0)
            {
                MessageBox.Show("USERID already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                con.Close();
                return;
            }


            SqlCommand cmd = new SqlCommand("insert into udb values (@fname,@lname,@cno,@add,@sta,@uid,@psw,@cpsw)", con);
            cmd.Parameters.AddWithValue("@fname", textBox8.Text);
            cmd.Parameters.AddWithValue("@lname", textBox7.Text);
            cmd.Parameters.AddWithValue("@cno", textBox6.Text);
            cmd.Parameters.AddWithValue("@add", textBox5.Text);
            cmd.Parameters.AddWithValue("@sta", comboBox1.Text);
            cmd.Parameters.AddWithValue("@uid", textBox3.Text);
            cmd.Parameters.AddWithValue("@psw", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@cpsw", int.Parse(textBox1.Text));




            int result = cmd.ExecuteNonQuery();

            if (result > 0)


                MessageBox.Show("Register succsfully","INFORMATION",MessageBoxButtons.OK,MessageBoxIcon.Information);

            Form3 form3 = new Form3();
            form3.ShowDialog();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please enter only Number's", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please enter only contact Number's", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(openFileDialog.FileName);
                userPhoto = File.ReadAllBytes(openFileDialog.FileName); 
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }
    }
    }

