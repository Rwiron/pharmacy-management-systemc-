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
    public partial class Administrations : Form
    {
        Database fn = new Database();
        string query;
        DataSet ds;

        public Administrations()
        {
            InitializeComponent();
        }

        private void check_CheckedChanged(object sender, EventArgs e)
        {
            if (check.Checked)
            {
                TextPass.PasswordChar = '\0';

            }
            else
            {
                TextPass.PasswordChar = '♣';
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            query = "select * from users";
            ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count == 0)
            {
                if(txtUsername.Text=="ROOT" && TextPass.Text == "Wiron")
                {
                    Admin am = new Admin();
                    am.Show();
                    this.Hide();
                }
            }
            else
            {
                query = "select * from users where username = '" + txtUsername.Text + "'and pass='" + TextPass.Text + "'";
                ds= fn.getData(query);
                if (ds.Tables[0].Rows.Count!=0)
                {
                    string role = ds.Tables[0].Rows[0][1].ToString();
                    if (role == "Administrator")
                    {
                        Admin n = new Admin();
                        n.Show();
                        this.Hide();
                    }
                    else if (role == "Pharmacist")
                    {
                        Pharmacist m = new Pharmacist();
                        m.Show();
                        this.Hide();
                    }
                }
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult iExit;

            try
            {
                iExit = MessageBox.Show("Confirm if you want to exit", "PharmacyManagementSystem"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (iExit == DialogResult.Yes)
                {
                    Application.Exit();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}