using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Data.SqlClient;
namespace CampusRecruitmentsystem
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar == true)
                textBox2.UseSystemPasswordChar = false;
            else
                textBox2.UseSystemPasswordChar = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = 0;
            string name = "";
            string pass = "";
            string connString = ConfigurationManager.ConnectionStrings["CampusRecruitmentsystem.Properties.Settings.login_companyConnectionString"].ConnectionString;
            SqlConnection co = new SqlConnection(connString);
            co.Open();
            SqlCommand cmd = new SqlCommand("select * from logincompany where [Company ID] = '" + textBox1.Text.ToString() + "' and Password = '" + textBox2.Text.ToString() + "'", co);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                name = read.GetString(2);
                id = read.GetInt32(0);
                pass = read.GetString(1);
            }
            if (textBox1.Text == id.ToString() && textBox2.Text == pass)
            {
                MessageBox.Show("Welcome " + name + " !");
                Form6 f = new Form6(name);
                f.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid entry!");
                textBox1.Clear();
                textBox2.Clear();
            }
            
        }
    }
}
