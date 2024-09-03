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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VEERA.ADO
{
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Veera Kuraganti\\OneDrive\\Documents\\ADB.mdf\";Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from mdb", con);
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
            Form10 form10 = new Form10();
                form10.ShowDialog();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Veera Kuraganti\\OneDrive\\Documents\\ADB.mdf\";Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from mdb where CropName like '" + this.textBox6.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;


                if (dt.Rows.Count == 1)
                {
                    DataRow row = dt.Rows[0];
                   
                    textBox6.Text = row["CropName"].ToString();
                    textBox5.Text = row["MarketPrice_QUINTAL"].ToString();
                    textBox1.Text = row["EstimateYield"].ToString();
                    textBox3.Text = row["ProductionCosts"].ToString();
                    
                }



            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            
            textBox3.Text = "";
           
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
