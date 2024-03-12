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
    public partial class Login : Form
    {
        OleDbConnection cn = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dr;

        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
        private void label5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void ovalShape2_Click(object sender, EventArgs e)
        {
            Dashboard das = new Dashboard();
            das.Show();
            this.Visible = false;
        }

        private void rectangleShape3_Click(object sender, EventArgs e)
        {
            cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\admin\Documents\Database2.accdb";
            cn.Open();
            cmd.CommandText = "select * from logindata where trim(uname) ='" + textBox1.Text + "' and trim(pwd)='" + textBox2.Text + "'";
            cmd.Connection = cn;
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("login Successfull");
                Dashboard frm = new Dashboard();
                frm.Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Username Or Password Is Wrong");
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\admin\Documents\Database2.accdb";
            cn.Open();
            cmd.CommandText = "select * from logindata where trim(uname) ='" + textBox1.Text + "' and trim(pwd)='" + textBox2.Text + "'";
            cmd.Connection = cn;
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("login Successfull");
                Dashboard frm = new Dashboard();
                frm.Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Username Or Password Is Wrong");
                textBox1.Clear();
                textBox2.Clear();
            }
        }

       

    
    }
}
