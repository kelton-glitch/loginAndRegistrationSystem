using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace loginAndRegistrationSystem
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;data Source=db_users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string login = "SELECT * FROM tbl_users WHERE username= '" + txtUsername.Text + "' and password= '" + txtPassword.Text + "'";
            cmd = new OleDbCommand(login, con);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                new dashboard().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password, Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtUsername.Text = "";
                txtPassword.Text = "";
                txtUsername.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        private void chkBoxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
                
            }

            else
            {
                txtPassword.PasswordChar = '*';
                
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            new frmRegister().Show();
            this.Hide();
        }
    }
}
