using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task
{
    public partial class Managment : Form
    {
        public Managment()
        {
            InitializeComponent();
        }

        private void EmployeeAcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Create_Employee obj4 = new Create_Employee();
            obj4.ShowDialog();
        }

        private void EmployeeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeList obj3 = new EmployeeList();
            obj3.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 obj4 = new Form1();
            obj4.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MasterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
