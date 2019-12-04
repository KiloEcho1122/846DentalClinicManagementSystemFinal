using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _846DentalClinicManagementSystem
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        SqlConnection sqlcon = new SqlConnection(GlobalVariable.connString);

        private void btn_Login_Click(object sender, EventArgs e)
        {
            LoginCick();
        }

        private void LoginCick()
        {

            SqlCommand cmd = new SqlCommand(
                "Select LoginID from Login Where Username = @username COLLATE SQL_Latin1_General_CP1_CS_AS" +
                " and Password = @pass COLLATE SQL_Latin1_General_CP1_CS_AS", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
            cmd.Parameters.AddWithValue("@pass", txtPassword.Text.Trim());
            sqlcon.Open();

            try
            {
                if (!string.IsNullOrEmpty(Convert.ToString(cmd.ExecuteScalar())))
                {
                    GlobalVariable.LoginID = Convert.ToInt32(cmd.ExecuteScalar());
                    LoginProgressbar loginprogress = new LoginProgressbar();
                    loginprogress.Show();
                    this.Hide();
                    
                }
                else
                {
                    MessageBox.Show("Incorrect Username/Password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sqlcon.Close();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoginCick();

            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoginCick();

            }
        }

        

        private void btn_Login_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoginCick();

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_OnValueChanged(object sender, EventArgs e)
        {
            if (!txtPassword.isPassword)
            {
                txtPassword.isPassword = true;
            }
            
            
        }
    }
}
