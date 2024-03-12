using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace andmarket
{
    public partial class Dashboard : Form
    {
       
       
        public Dashboard()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Product pro = new Product();
            pro.Show();
            this.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Purchaser prc = new Purchaser();
            prc.Show();
            this.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {
           Seller sell = new Seller();
            sell.Show();
            this.Visible = false;
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Visible = false;
        }

        private void ovalShape1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Project-X(C#)\pro_tbl.accdb");
                cn.Open();
                DateTime dtdate1 = DateTime.Parse(date1.Text);
                DateTime dtdate2 = DateTime.Parse(date2.Text);
                OleDbCommand cmd = new OleDbCommand("select * from protbl where OrderDate between #"
                    + dtdate1.ToString("dd/MM/yyyy") + "# and #" + dtdate2.ToString("dd/MM/yyyy")
                    + "# order by OrderDate desc", cn);
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                dt.Clear();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                cn.Close();
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

       
       

        

       
    }
}
