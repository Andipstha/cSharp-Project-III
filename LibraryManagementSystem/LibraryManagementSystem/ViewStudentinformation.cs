using LibraryManagementSystem.Properties;
using RestSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace LibraryManagementSystem
{
    public partial class ViewStudentinformation : Form
    {
        public ViewStudentinformation()
        {
            InitializeComponent();
        }

        private void txtSearchEnrollment_TextChanged(object sender, EventArgs e)
        {

        }

        private void ViewStudentinformation_Load(object sender, EventArgs e)
        {

            panel2.Visible = false;

            /*Connection to SqlDatabase*/
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = .\SQLEXPRESS;
                                                Initial Catalog=LibraryDBS;
                                                Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            //cmd.CommandText = "select * from NewStudent ";
            cmd.CommandText = "select * from NewStudent where hidden = 0 ";

            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            dataGridView1.DataSource = DS.Tables[0];
        }

        int bid;
        Int64 rowid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = .\SQLEXPRESS;
                                                Initial Catalog=LibraryDBS;
                                                Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewStudent where stuid = "+bid+" ";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            rowid = Int64.Parse(DS.Tables[0].Rows[0][0].ToString());

            txtSName.Text = DS.Tables[0].Rows[0][1].ToString();
            txtEnrollment.Text = DS.Tables[0].Rows[0][2].ToString();
            txtDepartment.Text = DS.Tables[0].Rows[0][3].ToString();
            txtSemester.Text = DS.Tables[0].Rows[0][4].ToString();
            txtContact.Text = DS.Tables[0].Rows[0][5].ToString();
            txtEmail.Text = DS.Tables[0].Rows[0][6].ToString();
            //image2.Image = DS.Tables[0].Rows[0][7].Image();
            //byte[] imageData = (byte[])DS.Tables[0].Rows[0][7]; // Replace 7 with the index of the image column
            //using (MemoryStream ms = new MemoryStream(imageData))
            //{
            //    Image image = Image.FromStream(ms);
            //    image2.Image = image;
            //}
            if (DS.Tables[0].Rows[0][7] != DBNull.Value)
            {
                byte[] imageData = (byte[])DS.Tables[0].Rows[0][7]; // Replace 7 with the index of the image column
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Image image = Image.FromStream(ms);
                    image2.Image = image;
                }
            }
            else
            {
                // Set a default image or clear the PictureBox control
                image2.Image = null;
                // OR
                // image2.Image = Properties.Resources.defaultImage;
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String sname = txtSName.Text;
            String enroll = txtEnrollment.Text;
            String dep = txtDepartment.Text;
            String sem = txtSemester.Text;
            Int64 contact = Int64.Parse(txtContact.Text);
            String semail = txtEmail.Text;

            if (MessageBox.Show("Data will Be Updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source = .\SQLEXPRESS;
                                                Initial Catalog=LibraryDBS;
                                                Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update NewStudent set sname = '" + sname + "' , enroll = '" + enroll + "' , dep = '" + dep + "' , sem = '" + sem + "' , contact = '" + contact + "' , email = '" + semail + "' , image = @image where stuid = " + rowid + " ";
                MemoryStream memstr = new MemoryStream();


                pictureBox1.Image.Save(memstr, image2.Image.RawFormat);
                cmd.Parameters.AddWithValue("image", memstr.ToArray());

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                ViewStudentinformation_Load(this, null); //Refresh the table after updating the table
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ViewStudentinformation_Load(this, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will Be Deleted. Confirm?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source = .\SQLEXPRESS;
                                                Initial Catalog=LibraryDBS;
                                                Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                //UPDATE NewStudent SET hidden = 1 WHERE hidden = 0;
                //cmd.CommandText = " delete from NewStudent where stuid = "+rowid+" ";
                cmd.CommandText = " update NewStudent set hidden = 1 where stuid = " + rowid + " "; 

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                ViewStudentinformation_Load(this, null); //Refresh the table after updating the table
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Unsaved Data Will Be Lost.","Are You Sure?",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            String imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| ALL Files(*.*)|*.*";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    image2.ImageLocation = imageLocation;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
