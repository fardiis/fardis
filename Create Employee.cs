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
    
    public partial class Create_Employee : Form
    {
        SqlConnection connection;
        SqlCommand command;
        public Create_Employee()
        {
            InitializeComponent();
        }

        private void Create_Employee_Load(object sender, EventArgs e)
        {

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
                SqlCommand cmd = new SqlCommand("insert into Employee(em_username , em_password , em_fullname,task )values( @em_username , @em_password , @em_fullname,@task  ) ", connection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@em_username", textBox2.Text);
                cmd.Parameters.AddWithValue("em_fullname", textBox1.Text);
                cmd.Parameters.AddWithValue("@em_password ", textBox3.Text);
                cmd.Parameters.AddWithValue("@task  ", textBox4.Text);

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("account created seccessfuly");
                    SqlCommand cmd1 = new SqlCommand("select max(em_ID) from Employee", connection);
                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    if (dr1.Read())
                    {
                        MessageBox.Show("dear Employee ,your id is  '" + dr1.GetInt32(0) + "' your registetration seccessfullt");
                        this.Hide();
                        Managment obj2 = new Managment();
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
            EmployeeList obj3 = new EmployeeList();
            obj3.ShowDialog();
        }

        
    }
    }

