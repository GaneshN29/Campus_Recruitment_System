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
    public partial class Form7 : Form
    {
        int g = 0;
        public Form7()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            g = comboBox1.SelectedIndex;

            if (g == 2)
            {
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                label1.Text = "Registration No";
                label3.Text = "Name";
            }
            else {
                if (g == 1)
                {
                    label3.Text = "Company Name";
                    label1.Text = "Company ID";
                }
                else {
                    label1.Text = "Admin ID";
                    label3.Text = "Name";
                }
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            
              
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
        
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (g == 2)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                {
                    MessageBox.Show("Please Enter the Detail!");
                }
            }
            else
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Please Enter the Detail!");
                }
            }
            if (g == 0)
            {
                string connString = ConfigurationManager.ConnectionStrings["CampusRecruitmentsystem.Properties.Settings.loginadminConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(connString);
                    con.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE loginadmin SET Password ='" + textBox2.Text + "', Name ='" + textBox3.Text + "'Where [Admin ID] ='" + textBox1.Text + "'", con);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update Sucessfull!");
                    con.Close();
                }
                if (g == 1)
                {


                    string connString = ConfigurationManager.ConnectionStrings["CampusRecruitmentsystem.Properties.Settings.login_companyConnectionString"].ConnectionString;
                    SqlConnection con = new SqlConnection(connString);
                   
                        con.Open();

                        SqlCommand cmd = new SqlCommand("UPDATE logincompany SET Password = '" + textBox2.Text.ToString() + "', [Company Name] = '" + textBox3.Text.ToString() + "' Where [Company ID] ='" + textBox1.Text + "'", con);
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Update Sucessfull!");
                        con.Close();
                    }
                
                if (g == 2)
                {
                    
                    string connString = ConfigurationManager.ConnectionStrings["CampusRecruitmentsystem.Properties.Settings.loginstudentConnectionString"].ConnectionString;
                    SqlConnection con = new SqlConnection(connString);
                 
                        con.Open();

                        SqlCommand cmd = new SqlCommand("UPDATE loginstudent SET Password ='" + textBox2.Text + "', Name ='" + textBox3.Text + "', Branch ='" + textBox4.Text + "', Batch ='" + textBox5.Text + "', CGPA ='" + textBox6.Text + "' Where [Registration No] ='" + textBox1.Text + "'", con);
                     
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Update Sucessfull!");
                        con.Close();
                    }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (g == 0)
            {
                string connString = ConfigurationManager.ConnectionStrings["CampusRecruitmentsystem.Properties.Settings.loginadminConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                SqlCommand cw = new SqlCommand("select * from loginadmin", con);
                var read=cw.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(read);
                dataGridView1.DataSource = table;
                con.Close();
            }
            if (g == 1) {
                string connString = ConfigurationManager.ConnectionStrings["CampusRecruitmentsystem.Properties.Settings.login_companyConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                SqlCommand cw = new SqlCommand("select * from logincompany", con);
                var read = cw.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(read);
                dataGridView1.DataSource = table;
                con.Close();
            }
            if (g == 2)
            {
                string connString = ConfigurationManager.ConnectionStrings["CampusRecruitmentsystem.Properties.Settings.loginstudentConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                SqlCommand cw = new SqlCommand("select * from loginstudent", con);
                var read = cw.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(read);
                dataGridView1.DataSource = table;
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
 if (g == 0)
            {
                int reg = 0;
                
                string connString = ConfigurationManager.ConnectionStrings["CampusRecruitmentsystem.Properties.Settings.loginadminConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                SqlCommand cw = new SqlCommand("select * from loginadmin where [Admin ID] = '" + textBox1.Text.ToString() + "'", con);
                SqlDataReader read = cw.ExecuteReader();
                while (read.Read())
                {
                   
                    reg = read.GetInt32(0);
                  
                }
                con.Close();
                if (textBox1.Text == reg.ToString())
                {
                    MessageBox.Show("Data Already Exist!");
                    textBox1.Clear();
     
                }
                else
                {
                    con.Open();
               
                    SqlCommand cmd = new SqlCommand("INSERT INTO loginadmin ([Admin ID], Password, Name) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", con);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Insertion Sucessfull!");
                    con.Close();
                }
            }
                if (g == 1)
                {
                    int reg = 0;

                    string connString = ConfigurationManager.ConnectionStrings["CampusRecruitmentsystem.Properties.Settings.login_companyConnectionString"].ConnectionString;
                    SqlConnection con = new SqlConnection(connString);
                    con.Open();
                    SqlCommand cw = new SqlCommand("select * from logincompany where [Company ID] = '" + textBox1.Text.ToString() + "'", con);
                    SqlDataReader read = cw.ExecuteReader();
                    while (read.Read())
                    {

                        reg = read.GetInt32(0);

                    }
                    con.Close();
                    if (textBox1.Text == reg.ToString())
                    {
                        MessageBox.Show("Data Already Exist!");
                        textBox1.Clear();

                    }
                    else
                    {
                        con.Open();
                       
                        SqlCommand cmd = new SqlCommand("INSERT INTO logincompany ([Company ID], Password,[Company Name]) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", con);
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Insertion Sucessfull!");
                        con.Close();
                    }
                }
                if (g == 2)
                {
                    int reg = 0;

                    string connString = ConfigurationManager.ConnectionStrings["CampusRecruitmentsystem.Properties.Settings.loginstudentConnectionString"].ConnectionString;
                    SqlConnection con = new SqlConnection(connString);
                    con.Open();
                    SqlCommand cw = new SqlCommand("select * from loginstudent where [Registration No] = '" + textBox1.Text.ToString() + "'", con);
                    SqlDataReader read = cw.ExecuteReader();
                    while (read.Read())
                    {

                        reg = read.GetInt32(0);

                    }
                    con.Close();
                    if (textBox1.Text == reg.ToString())
                    {
                        MessageBox.Show("Data Already Exist!");
                        textBox1.Clear();

                    }
                    else
                    {
                        con.Open();
                       
                        SqlCommand cmd = new SqlCommand("INSERT INTO loginstudent ([Registration No], Password, Name,Branch,Batch,CGPA) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')", con);
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Insertion Sucessfull!");
                        con.Close();
                    }
                }        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null)
            {
                MessageBox.Show("Enter the ID You want to Delete!");
            }
            else {
                if (g == 0)
                {
                    string connString = ConfigurationManager.ConnectionStrings["CampusRecruitmentsystem.Properties.Settings.loginadminConnectionString"].ConnectionString;
                    SqlConnection con = new SqlConnection(connString);
                    con.Open();

                    SqlCommand cmd = new SqlCommand("Delete loginadmin Where [Admin ID] ='" + textBox1.Text + "'", con);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Delete Sucessfull!");
                    con.Close();
                }
                if (g == 1)
                {


                    string connString = ConfigurationManager.ConnectionStrings["CampusRecruitmentsystem.Properties.Settings.login_companyConnectionString"].ConnectionString;
                    SqlConnection con = new SqlConnection(connString);

                    con.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE logincompany Where [Company ID] ='" + textBox1.Text + "'", con);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Delete Sucessfull!");
                    con.Close();
                }

                if (g == 2)
                {

                    string connString = ConfigurationManager.ConnectionStrings["CampusRecruitmentsystem.Properties.Settings.loginstudentConnectionString"].ConnectionString;
                    SqlConnection con = new SqlConnection(connString);

                    con.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE loginstudent Where [Registration No] ='" + textBox1.Text + "'", con);

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Delete Sucessfull!");
                    con.Close();
                }
            }
        }
    }
}