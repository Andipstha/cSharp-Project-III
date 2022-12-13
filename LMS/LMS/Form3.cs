using System.Data;
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
            DisplayData();
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
                string id = table.Rows[i]["bid"].ToString();
                string name = table.Rows[i]["btitle"].ToString();
                string author = table.Rows[i]["bauthor"].ToString();
                dataGridView1.Rows.Add(sn++, name, author);
            }

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
                string query = "insert into booksdetail values('" + txtTitle.Text + "','" + txtAuthor.Text + "')";
                //string query = "insert into booksdetail" + "(btitle,bauthor)" + "values('" + txtTitle.Text + "','" + txtAuthor.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("saved successfully");
                con.Close();
                DisplayData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Display
       

            
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Close();
            
        }
    }
}
