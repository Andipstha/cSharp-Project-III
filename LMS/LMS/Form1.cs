using System;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;


namespace LMS
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        public Form1()
        {
            InitializeComponent();
            //this.FormBorderStyle = FormBorderStyle.None;
            //button1.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
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
//=======
//            //try
//            //{
//            //    String querry = "SELECT * FROM lmsAdmin WHERE username = '" +usrTxt.Text+ "' AND password = '" +passTxt+ "' ";
//            //    SqlDataAdapter sda = new SqlDataAdapter(querry, con);

//            //    DataTable dtable = new DataTable();
//            //    sda.Fill(dtable);
//            //    if(dtable.Rows.Count > 0)
//            //    {
//            //        username = usrTxt.Text;
//            //        password = passTxt.Text;
//            //        MessageBox.Show("Success!");
//            //        //Open new form
//            //        new Form2().Show();
//            //        this.Hide();

//            //    }
//            //}
//            //catch 
//            //{
//            //    MessageBox.Show("Error!");
//            //}
//            if (usrTxt.Text == "admin" && passTxt.Text == "123")
//>>>>>>> e8a16c6603b716a8a9ab7b212f7eb6d56a1e55f3
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
 }
