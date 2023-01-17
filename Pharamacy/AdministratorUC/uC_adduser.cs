using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharamacy.AdministratorUC
{
    public partial class uC_adduser : UserControl
    {
        Database fn = new Database();
        String query;
        public uC_adduser()
        {
            InitializeComponent();
        }

        private void uC_adduser_Load(object sender, EventArgs e)
        {

        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            try
            {
                string role = cboUser.Text;
                string name = txtName.Text;
                string dob = date.Text;
                Int64 mobile = Int64.Parse(txtMobile.Text);
                string email = txtEmail.Text;
                string username = txtUser.Text;
                string password = txtPass.Text;

                try
                {
                    query = "insert into users(userRole,name,dob,mobile,email,username,pass)values('" + role + "','" + name + "','" + dob + "','" + mobile + "','" + email + "','" + username + "','" + password + "')";
                    fn.setData(query, "Sign up Successfully");
                }
                catch (Exception)
                {
                    MessageBox.Show("Username already Exit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Uncorreclty Data Entry Please check well your data", "Warning", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
            }
           

        }
        public void Reset()
        {
            cboUser.SelectedIndex = -1;
            txtPass.Clear();
            txtEmail.Clear();
            txtMobile.Clear();
            txtPass.Clear();
            txtUser.Clear();
            date.ResetText();
            txtName.Clear();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            query = "select*from users where username ='"+txtUser.Text+"'";
            DataSet ds = fn.getData(query);

            if(ds.Tables[0].Rows.Count==0)
            {
                pictureBox2.ImageLocation = @"C:\Users\Wiron\source\repos\Pharamacy\Pharamacy\Pharmacy Management System in C#\no.png";
            }
            else
            {
                pictureBox2.ImageLocation = @"C:\Users\Wiron\source\repos\Pharamacy\Pharamacy\Pharmacy Management System in C#\yes.png";
            }
        }
    }
}

