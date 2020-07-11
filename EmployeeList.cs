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
    public partial class EmployeeList : Form
    {
        SqlConnection connection;
        SqlCommand command;
        public void ReadFromDataBase()
        {
            connection = new SqlConnection();
            command = new SqlCommand();
            connection.ConnectionString = "server=.;initial catalog= MANAGER;integrated security=true";
            command.Connection = connection;

            command.CommandText = "select *from Employee ";
            connection.Open();
            DataTable table = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(table);
            dataGridView1.DataSource = table;

        }
        public EmployeeList()
        {
            InitializeComponent();
        }

        private void EmployeeList_Load(object sender, EventArgs e)
        {
            ReadFromDataBase();

        }

        
    }
}
