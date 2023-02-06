using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        public void loadform(object Form)
        {
            if (mainPanel.Controls.Count > 0)

                this.mainPanel.Controls.RemoveAt(0);

            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(f);
            this.mainPanel.Tag = f;
            f.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you Sure you want to Exit?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        public static int restrict = 0;

        private void addNewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(restrict == 0)
            {
                restrict++;
                AddBooks abs = new AddBooks();
                abs.TopMost = true;
                abs.Show();
            }
            else
            {
                MessageBox.Show("Form is already opened");
            }
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBook vb = new ViewBook();
            vb.Show();
        }
        /*Add Student*/
        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AddStudent ast = new AddStudent();
            //ast.Show();
            loadform(new AddStudent());
        }

        private void viewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ViewStudentinformation vsi = new ViewStudentinformation();
            //vsi.Show();
            loadform(new ViewStudentinformation());
        }

        private void issueBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //IssueBooks ib = new IssueBooks();
            //ib.Show();
            loadform(new IssueBooks());
        }

        private void returnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ReturnBook rb = new ReturnBook();
            //rb.Show();
            loadform(new ReturnBook());
        }

        private void completeBookDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //CompleteBookDetails cbd = new CompleteBookDetails();
            //cbd.Show();
            loadform(new CompleteBookDetails());


        }
    }
}
