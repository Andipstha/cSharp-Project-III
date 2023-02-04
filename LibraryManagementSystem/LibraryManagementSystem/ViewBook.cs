﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class ViewBook : Form
    {
        public ViewBook()
        {
            InitializeComponent();
        }

        private void ViewBook_Load(object sender, EventArgs e)
        {
            panel2.Visible = false; //Hide Panel 2
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = .\SQLEXPRESS;
                                                Initial Catalog=LibraryDBS;
                                                Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewBook";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

/*Global Variable*/
        int bid;
        Int64 rowid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true; //Show Panel 2

/*Connection to SqlDatabase*/
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = .\SQLEXPRESS;
                                                Initial Catalog=LibraryDBS;
                                                Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewBook where bid = "+bid+" ";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowid = Int64.Parse( ds.Tables[0].Rows[0][0].ToString() );

            txtBName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtAuther.Text = ds.Tables[0].Rows[0][2].ToString();
            txtPublication.Text = ds.Tables[0].Rows[0][3].ToString();
            txtPDate.Text = ds.Tables[0].Rows[0][4].ToString();
            txtPrice.Text = ds.Tables[0].Rows[0][5].ToString();
            txtQuantity.Text = ds.Tables[0].Rows[0][6].ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
            if(txtBookName.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source = .\SQLEXPRESS;
                                                Initial Catalog=LibraryDBS;
                                                Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewBook where bName LIKE '"+txtBookName.Text+"%' ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source = .\SQLEXPRESS;
                                                Initial Catalog=LibraryDBS;
                                                Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewBook";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtBookName.Clear();
            panel2.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Data will Be Updated. Confirm?","Success",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                String bname = txtBName.Text;
                String bauthor = txtAuther.Text;
                String publication = txtPublication.Text;
                string pdate = txtPDate.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
                Int64 quan = Int64.Parse(txtQuantity.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source = .\SQLEXPRESS;
                                                Initial Catalog=LibraryDBS;
                                                Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update NewBook set bName = '" + bname + "' ,bauthor = '" + bauthor + "' ,bPubl = '" + publication + "' ,bPDate = '" + pdate + "' ,bPrice = " + price + " ,bQuan = " + quan + " where bid = " + rowid + " ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will Deleted. Confirm?", "Confirmation Diaglog", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source = .\SQLEXPRESS;
                                                Initial Catalog=LibraryDBS;
                                                Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from NewBook where bid = "+rowid+" ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }
    }
}
