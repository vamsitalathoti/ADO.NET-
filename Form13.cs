using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VEERA.ADO
{
    public partial class Form13 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Veera Kuraganti\\OneDrive\\Documents\\ADB.mdf\";Integrated Security=True;Connect Timeout=30");

      

        public Form13()
        {
            InitializeComponent();
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.CurrentCellDirtyStateChanged += dataGridView1_CurrentCellDirtyStateChanged;
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;




        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns["QUANTITY"].Index)
            {
                TextBox txtBox = e.Control as TextBox;
                if (txtBox != null)
                {
                    txtBox.KeyPress -= TextBox_KeyPress;
                    txtBox.KeyPress += TextBox_KeyPress;
                }
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            LoadData();
            int W = Screen.PrimaryScreen.Bounds.Width;
            int H = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(W, H);
        }

        private void LoadData()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Veera Kuraganti\\OneDrive\\Documents\\ADB.mdf\";Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from pdb", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
           
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText  = "SELECT TO BUY";
            checkBoxColumn.Name= "SELECT";
            dataGridView1.Columns.Add(checkBoxColumn);
           
           


           
           
           con.Close();
            DataGridViewTextBoxColumn quantityColumn = new DataGridViewTextBoxColumn();
            quantityColumn.HeaderText = "Quantity";
            quantityColumn.Name = "QUANTITY";
            dataGridView1.Columns.Add(quantityColumn);

            // Add TotalCost column
            DataGridViewTextBoxColumn totalCostColumn = new DataGridViewTextBoxColumn();
            totalCostColumn.HeaderText = "Total Cost";
            totalCostColumn.Name = "TOTAL_COST";
            totalCostColumn.ReadOnly = true;
            dataGridView1.Columns.Add(totalCostColumn);

        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();   
                form10.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form14 form14 = new Form14();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)row.Cells["SELECT"];
                if (checkBox.Value != null && (bool)checkBox.Value)
                {
                    
                    form14.AddRow(row);
                   
                }
            }
            form14.CalculateAndAddTotalCostRow();
            form14.Show();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["SELECT"].Index && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)dataGridView1.Rows[e.RowIndex].Cells["SELECT"];
                if ((bool)checkBox.Value)
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells["QUANTITY"].Value == null)
                    {
                        MessageBox.Show("Please enter a quantity for the selected item.");
                        checkBox.Value = false;
                    }
                    else
                    {
                        UpdateCostForRow(e.RowIndex);
                    }
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells["QUANTITY"].Value = null;
                    dataGridView1.Rows[e.RowIndex].Cells["TOTAL_COST"].Value = null;
                }
            }
            else if (e.ColumnIndex == dataGridView1.Columns["QUANTITY"].Index && e.RowIndex >= 0)
            {
                UpdateCostForRow(e.RowIndex);
            }
        }

        private void UpdateCostForRow(int rowIndex)
        {
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            if (row.Cells["Cost_KG"].Value != null && row.Cells["QUANTITY"].Value != null)
            {
                double costPerKg;
                int quantity;
                if (double.TryParse(row.Cells["Cost_KG"].Value.ToString(), out costPerKg) &&
                    int.TryParse(row.Cells["QUANTITY"].Value.ToString(), out quantity))
                {
                    double totalCost = costPerKg * quantity;
                    row.Cells["TOTAL_COST"].Value = totalCost;
                }


            }
        }

        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Veera Kuraganti\\OneDrive\\Documents\\ADB.mdf\";Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from pdb where PesticideName like '" + this.textBox6.Text + "%'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;


                if (dt.Rows.Count == 1)
                {
                    DataRow row = dt.Rows[0];
                    textBox6.Text = row["PesticideName"].ToString();
                    textBox5.Text = row["CropName"].ToString();
                    textBox4.Text = row["Type"].ToString();
                    textBox3.Text = row["Disease"].ToString();
                    textBox2.Text = row["Manufacturer"].ToString();
                    textBox1.Text = row["Cost_KG"].ToString();
                }



            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
    }
    public static class user
    {
      
    }
}
