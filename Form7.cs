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
    public partial class Form7 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Veera Kuraganti\\OneDrive\\Documents\\ADB.mdf\";Integrated Security=True;Connect Timeout=30");
       
        public Form7()
        {
            InitializeComponent();
            refereshdata();
        }

        private void refereshdata()
        {
            SqlCommand cmd = new SqlCommand("select * from cdb", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("MARKET VALUE IS empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("FERTILIZER NEEDED", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("SEED RATE empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("PLANTING SEASON IS empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("SOIL TYPE IS empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("CROP NAME IS empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Veera Kuraganti\\OneDrive\\Documents\\ADB.mdf\";Integrated Security=True;Connect Timeout=30");
            con.Open();

            SqlCommand checkCmd = new SqlCommand("select count(*) from cdb where CropName=@CropName", con);
            checkCmd.Parameters.AddWithValue("@CropName", textBox6.Text);
            int count = (int)checkCmd.ExecuteScalar();

            if (count > 0)
            {
                MessageBox.Show(" CropName already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                con.Close();
                return;
            }
            SqlCommand cmd = new SqlCommand("insert into cdb values(@CropName,@SoilType,@PlantingSeason,@SeedRate,@FertilizerNeeded,@MarketValue_QUINTAL)", con);
            cmd.Parameters.AddWithValue("@CropName",textBox6.Text);
            cmd.Parameters.AddWithValue("@SoilType",textBox5.Text);
            cmd.Parameters.AddWithValue("@PlantingSeason",textBox4.Text);
            cmd.Parameters.AddWithValue("@SeedRate",int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@FertilizerNeeded",textBox2.Text);
            cmd.Parameters.AddWithValue("@MarketValue_QUINTAL",int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data inserted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = ""; textBox6.Text = "";
            refereshdata();
           
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Veera Kuraganti\\OneDrive\\Documents\\ADB.mdf\";Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from cdb", con);
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("MARKET VALUE IS empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("FERTILIZER NEEDED", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("SEED RATE empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("PLANTING SEASON IS empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("SOIL TYPE IS empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("CROP NAME IS empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Veera Kuraganti\\OneDrive\\Documents\\ADB.mdf\";Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("update cdb set SoilType=@SoilType,PlantingSeason=@PlantingSeason,SeedRate=@SeedRate,FertilizerNeeded=@FertilizerNeeded,MarketValue_QUINTAL=@MarketValue_QUINTAL where CropName=@CropName", con);
            cmd.Parameters.AddWithValue("@CropName", textBox6.Text);
            cmd.Parameters.AddWithValue("@SoilType", textBox5.Text);
            cmd.Parameters.AddWithValue("@PlantingSeason", textBox4.Text);
            cmd.Parameters.AddWithValue("@SeedRate",int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@FertilizerNeeded", textBox2.Text);
            cmd.Parameters.AddWithValue("@MarketValue_QUINTAL", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = ""; textBox6.Text = "";
            refereshdata();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index =e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox6.Text = selectedRow.Cells[0].Value.ToString();
            textBox5.Text = selectedRow.Cells[1].Value.ToString();
            textBox4.Text = selectedRow.Cells[2].Value.ToString();
            textBox3.Text = selectedRow.Cells[3].Value.ToString();
            textBox2.Text = selectedRow.Cells[4].Value.ToString();
            textBox1.Text = selectedRow.Cells[5].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("CROP NAME IS empty ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;


            }
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete ?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Veera Kuraganti\\OneDrive\\Documents\\ADB.mdf\";Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete cdb where CropName=@CropName",con);
            cmd.Parameters.AddWithValue("@CropName",textBox6.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Deleted","Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            da = new SqlDataAdapter("select * from cdb where CropName like'" + this.textBox7.Text + "%'", con);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
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
