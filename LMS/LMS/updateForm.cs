using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LMS
{
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source = .\SQLEXPRESS;
                                                Initial Catalog=lms_database;
                                                Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            //update booksdetail set btitle = 'new', bauthor = 'new' where bid = 1;
            try
            {

                /*
                                con.Open();
                                //string query = "insert into booksdetail values('" + textBox2.Text + "','" + textBox3.Text + "')";
                                string query = "update booksdetail set btitle = '" + textBox2.Text + "',bauthor = '" + textBox3.Text + "' where bid ='" + textBox1.Text + "'";
                                SqlCommand cmd = new SqlCommand(query, con);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("saved successfully");
                                con.Close();
                */
                con.Open();

                string query = "update booksdetail set btitle='" + textBox2.Text + "', bauthor='" + textBox3.Text + "'  where bid = '" + textBox1.Text + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update successfully");
                con.Close();
                DisplayData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Display

            
        }

        void DisplayData()
        {
            dataGridView1.Rows.Clear();
            string query = "select * from booksdetail";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            int sn = 1;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string bid = table.Rows[i]["bid"].ToString();
                string name = table.Rows[i]["btitle"].ToString();
                string author = table.Rows[i]["bauthor"].ToString();
                dataGridView1.Rows.Add(sn++, name, author, bid);
            }

        }

        void UpdateForm_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Close();
        }
    }
}
