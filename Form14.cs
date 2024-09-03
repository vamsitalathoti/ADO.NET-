using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace VEERA.ADO
{
    public partial class Form14 : Form
    {
        private PrintDocument printDocument;
        private PrintPreviewDialog printPreviewDialog;
        private string userName;
        private string userAddress;
        private string Number;
        
        private double totalCost;

       

        public Form14()
        {
            InitializeComponent();
            InitializePrintComponents();

           



        }

       

        private void InitializePrintComponents()
        {
            printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font headerFont = new Font("Arial",20, FontStyle.Bold);
            
            Font footerFont = new Font("Arial", 12, FontStyle.Italic);
            

            float headerHeight = e.Graphics.MeasureString("Header Text", headerFont).Height + 10;
           

            float footerHeight = e.Graphics.MeasureString("Footer Text", footerFont).Height + 10; 

            
            string headerText = "                DIGITAL AGRICULTURE                          ";

          

            e.Graphics.DrawString(headerText, headerFont, Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top - headerHeight);

            
            string footerText = $" FROM CIET,GUNTUR LAM{DateTime.Now.ToString()}";

            
            e.Graphics.DrawString(footerText, footerFont, Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top + footerHeight / 15);


            
            Rectangle adjustedBounds = new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top + (int)headerHeight, e.MarginBounds.Width, e.MarginBounds.Height - (int)headerHeight - (int)footerHeight);

            
            Bitmap bitmap = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bitmap, adjustedBounds);

            Font detailsFont = new Font("Arial",10, FontStyle.Regular);
            e.Graphics.DrawString($" TO Name: {userName}", detailsFont, Brushes.Green, e.MarginBounds.Left, e.MarginBounds.Top+ footerHeight/1);
            e.Graphics.DrawString($"Address: {userAddress}", detailsFont, Brushes.DarkBlue, e.MarginBounds.Left, e.MarginBounds.Bottom + footerHeight/2);
            e.Graphics.DrawString($"Number: {Number}", detailsFont, Brushes.DarkBlue, e.MarginBounds.Left, e.MarginBounds.Bottom + footerHeight / 1);
        }
        public void PrintDataGridView()
        {
            UserDetailsForm userDetailsForm = new UserDetailsForm();
            if (userDetailsForm.ShowDialog() == DialogResult.OK)
            {
                userName = userDetailsForm.UserName;
                userAddress = userDetailsForm.UserAddress;
                Number=userDetailsForm.Number;
                printPreviewDialog.ShowDialog();
            }


        }

        public void AddRow(DataGridViewRow row)
        {
            if (dataGridView1.ColumnCount == 0)
            {
                foreach (DataGridViewColumn column in row.DataGridView.Columns)
                {
                    if (column.Name != "SELECT")
                    {
                        dataGridView1.Columns.Add((DataGridViewColumn)column.Clone());
                    }
                }
            }
            int rowIndex = dataGridView1.Rows.Add();
            for (int i = 0; i < row.Cells.Count; i++)
            {
                if (row.DataGridView.Columns[i].Name != "SELECT")
                {
                    dataGridView1.Rows[rowIndex].Cells[row.DataGridView.Columns[i].Name].Value = row.Cells[i].Value;
                }
            }
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            int W = Screen.PrimaryScreen.Bounds.Width;
            int H = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(W, H);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

       public void CalculateAndAddTotalCostRow()
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Tag != null && row.Tag.ToString() == "TotalRow")
                {
                    dataGridView1.Rows.Remove(row);
                    break;
                }
            }

            double totalCost = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["TOTAL_COST"].Value != null)
                {
                    double value;
                    if (double.TryParse(row.Cells["TOTAL_COST"].Value.ToString(), out value))
                    {
                        totalCost += value;
                    }
                }
            }

            int totalRowIndex = dataGridView1.Rows.Add();
            DataGridViewRow totalRow = dataGridView1.Rows[totalRowIndex];
            totalRow.Tag = "TotalRow";
            totalRow.DefaultCellStyle.BackColor = Color.LightGray;
            totalRow.DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);

            totalRow.Cells[0].Value = "TOTAL";
            totalRow.Cells["TOTAL_COST"].Value = totalCost;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintDataGridView();
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form13 form13 = new Form13();
            form13.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        internal void SetTotalCost(double totalCost)
        {
            this.totalCost = totalCost;
            CalculateAndAddTotalCostRow();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
       

    


