using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace andmarket
{
    public partial class Seller : Form
    {
        OleDbConnection cn = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dr;
        DataSet ds = new DataSet();

        public Seller()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Product frm = new Product();
            frm.Show();
            this.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Purchaser frm = new Purchaser();
            frm.Show();
            this.Visible = false;
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void populate()
        {
            cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Project-X(C#)\Sell_tbl.accdb";
            cn.Open();
            cmd.CommandText = "select * from selltbl";
            cmd.Connection = cn;
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dataGridView1.Rows.Count > 0)
                dataGridView1.Rows.RemoveAt(0);
            dataGridView1.DataSource = dt;
            cn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Project-X(C#)\Sell_tbl.accdb";
            try
            {
                cn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into selltbl(Id,Name,Age,Phone,Address) values(" + textBox1.Text + ",'" + textBox2.Text + "'," + textBox3.Text + ",'" + textBox4.Text + "','" + textBox5.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Seller Added Successfully");
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Project-X(C#)\Sell_tbl.accdb";
            try
            {
                cn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                String query = "update selltbl set Name='" + textBox2.Text + "',Age=" + textBox3.Text + ",Phone='" + textBox4.Text + "',Address='" + textBox5.Text + "' where Id=" + textBox1.Text + " ";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Edit Successfull");
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Project-X(C#)\Sell_tbl.accdb";
            try
            {
                cn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText = "delete from selltbl where Id=" + textBox1.Text + " ";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete Successfull");
                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }



        }

        private void Seller_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Dashboard das = new Dashboard();
            das.Show();
            this.Visible = false;
        }
    }
}
