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
    public partial class Form5 : Form
    {
        int r = 0;
        public Form5(int y)
        {
            r = y;
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["CampusRecruitmentsystem.Properties.Settings.companylistConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cw = new SqlCommand("select * from companylist", con);
            try
            {
                var read = cw.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(read);
                dataGridView1.DataSource = table;
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Create First!");
            }

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = r.ToString();
            string pass = "";
            int b = 0;
            string connString = ConfigurationManager.ConnectionStrings["CampusRecruitmentsystem.Properties.Settings.companylistConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            
                SqlCommand cmd = new SqlCommand("select * from companylist where [Job ID] = '" + textBox1.Text.ToString() + "'", con);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {

                    b = read.GetInt32(3);
                    pass = read.GetString(1);
                }
                if (b == 0 || pass == null)
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    MessageBox.Show("Wrong Job ID!");
                }
                else
                {
                    if (comboBox1.Text == b.ToString() && textBox2.Text == pass)
                    {
                        string conn = ConfigurationManager.ConnectionStrings["CampusRecruitmentsystem.Properties.Settings.companyConnectionString"].ConnectionString;
                        SqlConnection co = new SqlConnection(conn);
                        co.Open();

                        SqlCommand c = new SqlCommand("INSERT INTO " + pass + " (RegNo,Batch,Branch,Link) VALUES('" + r + "','" + comboBox1.Text + "','" + comboBox2.Text + "','"+richTextBox1.Text+"')", co);
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        
                        c.ExecuteNonQuery();
                        MessageBox.Show("Insertion Sucessfull!");
                        co.Close();
                    }
                    else
                    {
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        MessageBox.Show("Invalid entry!");

                    }
                    con.Close();
                }  
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = r.ToString();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
         
        }
    }
}
