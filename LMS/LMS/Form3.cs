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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source = .\SQLEXPRESS;
                                                Initial Catalog=lms_database;
                                                Integrated Security=True");

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //con.Open();
            //string query = "Insert into booksdetail" + "(btitle,bauthor)" + "values(@btitle,@bauthor)";

            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandText = query;
            //cmd.Parameters.AddWithValue("@btitle", txtTitle.Text);
            //cmd.Parameters.AddWithValue("@bauthor", txtAuthor.Text);

            //cmd.ExecuteNonQuery();
            //con.Close();
            try
            {
                con.Open();
                string query = "insert into booksdetail" + "(btitle,bauthor)" + "values('" + txtTitle.Text + "','" + txtAuthor.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("saved successfully");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
