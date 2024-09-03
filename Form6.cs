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
    public partial class Form6 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Veera Kuraganti\\OneDrive\\Documents\\ADB.mdf\";Integrated Security=True;Connect Timeout=30");
        
        public Form6()
        {
            InitializeComponent();
            refereshdata();
        }

        private void refereshdata()
        {

            SqlCommand cmd = new SqlCommand("select * from sdb", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Veera Kuraganti\\OneDrive\\Documents\\ADB.mdf\";Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from sdb", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            int W = Screen.PrimaryScreen.Bounds.Width;
            int H = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(W, H);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("GROWING PLANTS IS empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("NITROGEN CONTENT empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("MOISTURE CONTENT empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("pH VALUE IS empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("SOIL TYPE IS empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("SOIL NAME IS empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Veera Kuraganti\\OneDrive\\Documents\\ADB.mdf\";Integrated Security=True;Connect Timeout=30");
            con.Open();
           
            SqlCommand checkCmd = new SqlCommand("select count(*) from sdb where SoilName=@SoilName", con);
            checkCmd.Parameters.AddWithValue("@SoilName", textBox6.Text);
            int count = (int)checkCmd.ExecuteScalar();

            if (count > 0)
            {
                MessageBox.Show("Soil Name already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                con.Close();
                return;
            }
            SqlCommand cmd = new SqlCommand("insert into sdb values(@SoilName,@SoilType,@pHValue,@MoistureContent,@NitrogenContent,@GrowingPlants)",con);
            cmd.Parameters.AddWithValue("@SoilName",textBox6.Text);
            cmd.Parameters.AddWithValue("@SoilType",textBox5.Text);
            cmd.Parameters.AddWithValue("@pHValue",int.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@MoistureContent",int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@NitrogenContent",int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@GrowingPlants", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            

            
            MessageBox.Show("Data inserted","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = ""; textBox6.Text = "";
            refereshdata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("GROWING PLANTS IS empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("NITROGEN CONTENT empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("MOISTURE CONTENT empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("pH VALUE IS empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("SOIL TYPE IS empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("SOIL NAME IS empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Veera Kuraganti\\OneDrive\\Documents\\ADB.mdf\";Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("update sdb set SoilType=@SoilType,pHValue=@pHValue,MoistureContent=@MoistureContent,NitrogenContent=@NitrogenContent,GrowingPlants=@GrowingPlants where SoilName=@SoilName", con);
            cmd.Parameters.AddWithValue("@SoilName", textBox6.Text);
            cmd.Parameters.AddWithValue("@SoilType", textBox5.Text);
            cmd.Parameters.AddWithValue("@pHValue", int.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@MoistureContent", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@NitrogenContent", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@GrowingPlants", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = ""; textBox6.Text = "";
            refereshdata();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("SOIL NAME IS empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete ?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Veera Kuraganti\\OneDrive\\Documents\\ADB.mdf\";Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete sdb where SoilName=@SoilName", con);
            cmd.Parameters.AddWithValue("@SoilName", textBox6.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data deleted","Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = ""; textBox6.Text = "";
            refereshdata();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Veera Kuraganti\\OneDrive\\Documents\\ADB.mdf\";Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlDataAdapter da;
            DataTable dt;
            con.Close();
            da = new SqlDataAdapter("select * from sdb where SoilName like'"+this.textBox7.Text+ "%'",con);
            dt = new DataTable();
            da.Fill(dt); 
         
            dataGridView1.DataSource =dt;
            con.Close();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox6.Text = selectedRow.Cells[0].Value.ToString();
            textBox5.Text = selectedRow.Cells[1].Value.ToString();
            textBox4.Text = selectedRow.Cells[2].Value.ToString();
            textBox3.Text = selectedRow.Cells[3].Value.ToString();
            textBox2.Text = selectedRow.Cells[4].Value.ToString();
            textBox1.Text = selectedRow.Cells[5].Value.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            form.ShowDialog();  

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
