using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace LibraryManagementSystem
{
    public partial class mainDashboard : Form
    {
        public mainDashboard()
        {
            InitializeComponent();
        }

        private void mainDashboard_Load(object sender, EventArgs e)
        {
            /*Connection to SqlDatabase*/
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = .\SQLEXPRESS;
                                                Initial Catalog=LibraryDBS;
                                                Integrated Security=True";
            con.Open();
            
            SqlCommand cmd = new SqlCommand("select sum(bQuan) from NewBook", con);
            var count1 = cmd.ExecuteScalar();
            totalBook.Text= count1.ToString();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand("select count(*) from NewStudent where hidden = 0", con);
            var count2 = cmd1.ExecuteScalar();
            totalStudent.Text = count2.ToString();
            cmd1.Connection = con;
            cmd1.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand("select count(book_issue_date) from IRbook", con);
            var count3 = cmd2.ExecuteScalar();
            totalBooksIssued.Text = count3.ToString();
            cmd2.Connection = con;
            cmd2.ExecuteNonQuery();

            SqlCommand cmd3 = new SqlCommand("select count(book_return_date) from IRbook", con);
            var count4 = cmd3.ExecuteScalar();
            totalBooksReturned.Text = count4.ToString();
            cmd3.Connection = con;
            cmd3.ExecuteNonQuery();

            con.Close();
        }


    }
}
