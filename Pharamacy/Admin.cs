using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharamacy
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            Administrations am = new Administrations();
            am.Show();
            this.Hide();  
        }

        private void btnDash_Click(object sender, EventArgs e)
        {
            uC_Dashboard1.Visible = true;
            uC_Dashboard1.BringToFront();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            uC_Dashboard1.Visible = false;
            uC_adduser1.Visible = false;
            btnDash.PerformClick();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            uC_adduser1.Visible = true;
            uC_adduser1.BringToFront();
        }
    }
}
