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
    public partial class Product : Form
    {
        OleDbConnection cn = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dr;
        DataSet ds = new DataSet();

        public Product()
        {
            InitializeComponent();
        }

       
        private void label12_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void populate()
        {
            cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Project-X(C#)\pro_tbl.accdb";
            cn.Open();
            cmd.CommandText = "select * from protbl";
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

        private void Product_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Seller frm = new Seller();
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

        private void button1_Click(object sender, EventArgs e)
        {
            cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Project-X(C#)\pro_tbl.accdb";
            try
            {
                cn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into protbl(ProId,ProName,ProQty,OrderDate,ProPrice) values(" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Added Successfully");
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

     

        private void button4_Click(object sender, EventArgs e)
        {
            cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Project-X(C#)\pro_tbl.accdb";
            cn.Open();
            cmd.CommandText = "select * from protbl";
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

        private void button2_Click(object sender, EventArgs e)
        {
            cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Project-X(C#)\pro_tbl.accdb";
            try
            {
                cn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                String query = "update protbl set ProName='" + textBox2.Text + "',ProQty='" + textBox3.Text + "',OrderDate='" + textBox4.Text + "',ProPrice='" + textBox5.Text + "' where ProID=" + textBox1.Text + " ";
                cmd.CommandText = query;

                cmd.ExecuteNonQuery();
                MessageBox.Show("Edit Successfully");
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
            cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Project-X(C#)\pro_tbl.accdb";
            try
            {
                cn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText = "delete from protbl where ProID=" + textBox1.Text + " ";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete Successfully");
                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            populate();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Dashboard das = new Dashboard();
            das.Show();
            this.Visible = false;
        }

        private void ovalShape1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

       
    }
}
