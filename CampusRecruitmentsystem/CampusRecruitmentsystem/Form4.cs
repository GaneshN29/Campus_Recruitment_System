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
using System.Collections.Specialized;
using System.Data.SqlClient;
namespace CampusRecruitmentsystem
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int id = 0;
            string name = "";
            string pass = "";
            string connString = ConfigurationManager.ConnectionStrings["CampusRecruitmentsystem.Properties.Settings.loginadminConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from loginadmin where [Admin ID] = '" + textBox1.Text.ToString() + "' and Password = '" + textBox2.Text.ToString() + "'", con);
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
                Form7 f = new Form7();
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

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox2.UseSystemPasswordChar==true)
                textBox2.UseSystemPasswordChar = false;
            else
                textBox2.UseSystemPasswordChar = true;
        }
    }
}
