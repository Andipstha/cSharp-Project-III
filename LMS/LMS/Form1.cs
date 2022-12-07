using System.Data;
using System.Data.SqlClient;


namespace LMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source = .\SQLEXPRESS;
                                                Initial Catalog=lms_database;
                                                Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            String username, password;

            username = usrTxt.Text;
            password = passTxt.Text;

            try
            {
                String querry = "SELECT * FROM lmsAdmin WHERE username = '" + usrTxt.Text + "' AND password = '" + passTxt.Text + "' ";
                SqlDataAdapter sda = new SqlDataAdapter(querry, con);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);
                if (dtable.Rows.Count > 0)
                {
                    username = usrTxt.Text;
                    password = passTxt.Text;
                    MessageBox.Show("Success!");
                    //Open new form
                    new Form2().Show();
                    this.Hide();

                }
                else
                {
                    usrTxt.Clear();
                    passTxt.Clear();
                    usrTxt.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Error!");
            }
            //if (usrTxt.Text == "andipstha" && passTxt.Text == "123")
            //{
            //    new Form2().Show();
            //    this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("The User name or password you entered is incorrect, Try again");
            //    usrTxt.Clear();
            //    passTxt.Clear();
            //    usrTxt.Focus()
            //}
        }
    }
 }
