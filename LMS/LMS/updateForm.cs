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
    public partial class updateForm : Form
    {
        public updateForm()
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
                con.Open();
                
                //string query = "insert into booksdetail values('" + textBox2.Text + "','" + textBox3.Text + "')";
                string query = "update booksdetail set btitle = '"+ textBox2.Text + "',bauthor = '" + textBox3.Text+ "' where bid ='" + textBox1.Text + "'";
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
