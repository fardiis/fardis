using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection();
            command = new SqlCommand();
            connection.ConnectionString = "server=.;initial catalog=MANAGER;integrated security=true";
            command.Connection = connection;
            connection.Open();
            SqlCommand cmd = new SqlCommand(" select ad_ID FROM Addmin Where ad_username=@ad_username and ad_password =@ad_password ", connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@ad_username", textBox1.Text);
            cmd.Parameters.AddWithValue("@ad_password", textBox2.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.Visible = false;
                Managment obj2 = new Managment();
                obj2.ShowDialog();

            }
            else
            {
                MessageBox.Show("invalid username or password.....try again");
            }
            connection.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection();
            command = new SqlCommand();
            connection.ConnectionString = "server=.;initial catalog=MANAGER;integrated security=true";
            command.Connection = connection;
            connection.Open();
            SqlCommand cmd = new SqlCommand(" select ad_ID FROM Employee Where em_username=@em_username and em_password =@em_password ", connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@em_username", textBox1.Text);
            cmd.Parameters.AddWithValue("@em_password", textBox2.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.Visible = false;
                EmployeeList obj2 = new EmployeeList();
                obj2.ShowDialog();

            }
            else
            {
                MessageBox.Show("invalid username or password.....try again");
            }
            connection.Close();
        }

  

    

        private void LinkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Registration obj = new Registration();
            obj.ShowDialog();
        }
    }
}
