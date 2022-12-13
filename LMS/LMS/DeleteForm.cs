using System.Data;
using System.Data.SqlClient;

namespace LMS
{
    public partial class DeleteForm : Form
    {
        public DeleteForm()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source = .\SQLEXPRESS;
                                                Initial Catalog=lms_database;
                                                Integrated Security=True");
        private void DeleteForm_Load(object sender, EventArgs e)
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
                dataGridView1.Rows.Add(sn++, id, name, author);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Close();
        }

        //Select Data
        private void button2_Click(object sender, EventArgs e)
        {

            DataGridViewRow data = dataGridView1.CurrentRow;
            string id = data.Cells["id"].Value.ToString();
            string name = data.Cells["btitle"].Value.ToString();
            string author = data.Cells["bauthor"].Value.ToString();

            textBox1.Text = name;
            textBox2.Text = author;
            textBox3.Text = id;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "delete from booksdetail where bid = '" + textBox3.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Delete successfully");
            con.Close();
            DisplayData();
        }
    }


}
