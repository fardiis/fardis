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
    public partial class Registration : Form
    {
        SqlConnection connection;
        SqlCommand command;
        public Registration()
        {
            InitializeComponent();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection();
            command = new SqlCommand();
            connection.ConnectionString = "server=.;initial catalog=MANAGER;integrated security=true";
            command.Connection = connection;
            connection.Open();
            
            try
            {
                SqlCommand cmd = new SqlCommand("insert into Addmin(ad_username , ad_password , ad_fullname )values( @ad_username , @ad_password , @ad_fullname) ", connection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ad_username", textBox2.Text);
                cmd.Parameters.AddWithValue("ad_fullname", textBox1.Text);
                cmd.Parameters.AddWithValue("@ad_password", textBox3.Text);
               
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("account created seccessfuly");
                    SqlCommand cmd1 = new SqlCommand("select max(ad_ID) from Addmin", connection);
                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    if (dr1.Read())
                    {
                        MessageBox.Show("dear manager ,your id is  '" + dr1.GetInt32(0) + "' your registetration seccessfullt");
                        this.Hide();
                        Home obj2 = new Home();
                        obj2.ShowDialog();

                    }
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("account not created ");
                }
                connection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 obj3 = new Form1();
            obj3.ShowDialog();
        }
    }
}
