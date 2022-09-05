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
    public partial class Form6 : Form
    {
        string d="";
        public Form6(string s)
        {
            d = s;
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome "+d;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string g = "";
            int c = 0;
            foreach (int s in checkedListBox1.CheckedIndices) {
                if (c != 0)
                    g += ", ";
                g += checkedListBox1.Items[s];
                c++;
            }
            string connString = ConfigurationManager.ConnectionStrings["CampusRecruitmentsystem.Properties.Settings.companyConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("CREATE TABLE " + d + " (RegNo int, Batch int, Branch varchar(10),Link varchar(100))", con);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Already Create!");
            }
            con.Close();
            string conn = ConfigurationManager.ConnectionStrings["CampusRecruitmentsystem.Properties.Settings.companylistConnectionString"].ConnectionString;
            SqlConnection co = new SqlConnection(conn);
            co.Open();
            try{
            SqlCommand cm = new SqlCommand("insert into companylist([Job ID],[Company Name],Role,Batch,Branch,[close Date],Description) values('"+textBox3.Text+"','" + d + "','" +textBox1.Text+ "','"+comboBox1.Text+"','"+g+"','"+textBox2.Text+"','"+richTextBox1.Text+"')", co);
            cm.ExecuteNonQuery();
            textBox1.Clear();
            textBox2.Clear();
            richTextBox1.Clear();

            MessageBox.Show("Addtion Sucessfull");
        }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Already Create!");
            }
            co.Close();
        
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["CampusRecruitmentsystem.Properties.Settings.companylistConnectionString"].ConnectionString;
            SqlConnection co = new SqlConnection(conn);
            co.Open();
            try{
            SqlCommand cm = new SqlCommand("delete from companylist where [Company Name] = '" + d + "'", co);
            cm.ExecuteNonQuery();
        }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Create First!");
            }
            co.Close();
            string connString = ConfigurationManager.ConnectionStrings["CampusRecruitmentsystem.Properties.Settings.companyConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            try{
            SqlCommand cmd = new SqlCommand("DROP TABLE "+ d, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Deletion Sucessfull");
        }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Create First!");
            }
            con.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["CampusRecruitmentsystem.Properties.Settings.companyConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cw = new SqlCommand("select * from " + d, con);
            try
            {
                var read = cw.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(read);
                dataGridView1.DataSource = table;
            }
            catch (SqlException sqlEx){
            MessageBox.Show("Create First!");
            }
            
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++) {
                    xcelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++) {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                            xcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        else
                            xcelApp.Cells[i + 2, j + 1] = null;
                }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
            }
            else {
                MessageBox.Show("Import Data or Create Table!");
            }
        }
    }
}
