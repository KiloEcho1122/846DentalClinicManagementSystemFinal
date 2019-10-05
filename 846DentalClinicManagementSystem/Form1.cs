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
    public partial class Login : Form
    {
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mike\Documents\846DentalClinicManagementSystem\846DentalClinicManagementSystem\846DentalClinicDB.mdf;Integrated Security=True";

        public Login()
        {
            InitializeComponent();
        }

        private void LoginCick()
        {
            SqlConnection sqlcon = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(
                "Select Username,Password from Login Where Username = @username COLLATE SQL_Latin1_General_CP1_CS_AS" +
                " and Password = @pass COLLATE SQL_Latin1_General_CP1_CS_AS", sqlcon);
            cmd.Parameters.Clear();
            SqlParameter userParam = new SqlParameter("@username", txtUsername.Text.Trim());
            SqlParameter passParam = new SqlParameter("@pass", txtPassword.Text.Trim());
            cmd.Parameters.Add(userParam);
            cmd.Parameters.Add(passParam);
            sqlcon.Open();

            try
            {
                if (!string.IsNullOrEmpty(Convert.ToString(cmd.ExecuteScalar())))
                {
                    LoginProgressbar loginprogress = new LoginProgressbar();
                    this.Hide();
                    loginprogress.Show();
                }
                else
                {
                    MessageBox.Show("bobo mo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    
        private void btn_Login_Click(object sender, EventArgs e)
     {
            LoginCick();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0.0)
            {
                this.Opacity -= 0.04;

            }
            else
            {
                timer1.Stop();
                Application.Exit();
            }

        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
        }
    }
}
