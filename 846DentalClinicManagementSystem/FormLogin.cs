using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace _846DentalClinicManagementSystem
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            btn_Login.Location = new Point(54, 366);
            
        }

        SqlConnection sqlcon = new SqlConnection(GlobalVariable.connString);

        private void btn_Login_Click(object sender, EventArgs e)
        {

            LoginCick();
            
        }

        Boolean isNewAccount = false;

        private void LoginCick()
        {

            SqlCommand cmd = new SqlCommand(
                "Select EmployeeID_fk from Login l INNER JOIN Employee e ON l.EmployeeID_fk = e.EmployeeId "+
                "WHERE Status = 'Active' AND Username = @username COLLATE SQL_Latin1_General_CP1_CS_AS" +
                " AND Password = @pass COLLATE SQL_Latin1_General_CP1_CS_AS", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
            cmd.Parameters.AddWithValue("@pass", txtPassword.Text.Trim());
            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            if (isNewAccount)
            {
                ChangePassword();
            }
            else { 
            
                try
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(cmd.ExecuteScalar())))
                    {
                        GlobalVariable.EmployeeID = Convert.ToInt32(cmd.ExecuteScalar());

                        if (txtPassword.Text.Trim() == "1234")
                        {
                            MessageBox.Show("You need to change your password");
                            pictureBox4.Visible = true;
                            txt_PasswordConfirm.Visible = true;
                            btn_Login.Location = new Point(54, 395);
                            isNewAccount = true;
                            txtPassword.Text = string.Empty;

                        }
                        else
                        {

                            LoginProgressbar loginprogress = new LoginProgressbar();
                            loginprogress.Show();
                            this.Hide();

                        }

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
            }
            sqlcon.Close();
        }

        private void ChangePassword()
        {

            if(txtPassword.Text.Length >= 8)
            {
                if (txtPassword.Text != "1234" && txt_PasswordConfirm.Text != "1234")
                {
                    if (txtPassword.Text.Trim() == txt_PasswordConfirm.Text.Trim())
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE [Login] SET Password = @Password WHERE EmployeeID_fk = @EmployeeID", sqlcon);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                        cmd.Parameters.AddWithValue("@EmployeeID", GlobalVariable.EmployeeID);

                        if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        sqlcon.Close();

                        MessageBox.Show("New Password Created!");
                        isNewAccount = false;
                        txt_PasswordConfirm.Visible = false;
                        pictureBox4.Visible = false;
                        btn_Login.Location = new Point(54, 366);

                    }
                    else
                    {
                        MessageBox.Show("Password not match!");
                        txtPassword.Text = string.Empty;
                        txt_PasswordConfirm.Text = string.Empty;

                    }
                }
                else
                {
                    MessageBox.Show("Invalid Password!");
                }
            }
            else
            {
                MessageBox.Show("Password must be atleast 8 characters!");
            }
           
           
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

        private void txt_PasswordConfirm_OnValueChanged(object sender, EventArgs e)
        {
            if (!txt_PasswordConfirm.isPassword)
            {
                txt_PasswordConfirm.isPassword = true;
            }
        }

        private void txt_PasswordConfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoginCick();

            }
        }
    }
}
