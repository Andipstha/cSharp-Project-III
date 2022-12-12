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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
<<<<<<< HEAD
        SqlConnection con = new SqlConnection(@"Data Source = .\SQLEXPRESS;
                                                Initial Catalog=lms_database;
                                                Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
            new Form3().Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            new updateForm().Show();
            this.Hide();
=======

        private void Form2_Load(object sender, EventArgs e)
        {
>>>>>>> e8a16c6603b716a8a9ab7b212f7eb6d56a1e55f3

        }
    }
}
