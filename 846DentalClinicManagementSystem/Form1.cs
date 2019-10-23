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
using System.IO;


namespace _846DentalClinicManagementSystem
{
    public partial class Login : Form
    {

        //static String workingDirectory = Environment.CurrentDirectory;
        //static String projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
        //static String LocalDbSource = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=";
        //static String LocalDBFile = projectDirectory + @"\846DentalClinicDB.mdf";
        //static String connString = LocalDbSource + LocalDBFile + ";Integrated Security=True";
        SqlConnection sqlcon = new SqlConnection(GlobalVariable.connString);

        public Login()
        {
            InitializeComponent();
        }

        private void LoginCick()
        {
            
            SqlCommand cmd = new SqlCommand(
                "Select Username,Password from Login Where Username = @username COLLATE SQL_Latin1_General_CP1_CS_AS" +
                " and Password = @pass COLLATE SQL_Latin1_General_CP1_CS_AS", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
            cmd.Parameters.AddWithValue("@pass", txtPassword.Text.Trim());
            sqlcon.Open();

            try
            {
                if (!string.IsNullOrEmpty(Convert.ToString(cmd.ExecuteScalar())))
                {
                    GlobalVariable.Username = txtUsername.Text.Trim();
                    LoginProgressbar loginprogress = new LoginProgressbar();
                    this.Hide();
                    loginprogress.Show();
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
