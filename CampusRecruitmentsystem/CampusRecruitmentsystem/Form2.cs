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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox2.UseSystemPasswordChar ==true)
            textBox2.UseSystemPasswordChar = false;
            else
                textBox2.UseSystemPasswordChar = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int reg=0;
            string name = "";
            string pass = "";
            string connString = ConfigurationManager.ConnectionStrings["CampusRecruitmentsystem.Properties.Settings.loginstudentConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from loginstudent where [Registration No] = '"+textBox1.Text.ToString()+"' and Password = '"+textBox2.Text.ToString()+"'", con);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                name = read.GetString(2);
                reg = read.GetInt32(0);
                pass = read.GetString(1);
            }
            if (textBox1.Text == reg.ToString() && textBox2.Text == pass)
            {
                MessageBox.Show("Welcome "+name+" !");
                int y=int.Parse(textBox1.Text);
                Form5 f = new Form5(y);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
