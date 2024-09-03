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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
           
           
        }

        

        private void Form12_Load(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.ShowDialog();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Veera Kuraganti\\OneDrive\\Documents\\ADB.mdf\";Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from cdb where CropName like '" + this.textBox6.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;


                if (dt.Rows.Count == 1)
                {
                    DataRow row = dt.Rows[0];
                    textBox6.Text = row["CropName"].ToString();
                    textBox5.Text = row["SoilType"].ToString();
                    textBox4.Text = row["PlantingSeason"].ToString();
                    textBox3.Text = row["SeedRate"].ToString();
                    textBox2.Text = row["FertilizerNeeded"].ToString();
                    textBox1.Text = row["MarketValue_QUINTAL"].ToString();
                }



            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
    }
}
