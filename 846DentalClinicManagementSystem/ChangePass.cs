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

namespace _846DentalClinicManagementSystem
{
    public partial class ChangePass : Form
    {
        public ChangePass()
        {
            InitializeComponent();
            lbl_EmpID.Text = GlobalVariable.changePassID.ToString();
            lbl_EmpName.Text = GlobalVariable.changePassName ;
            GetPassword();

        }
        SqlConnection sqlcon = new SqlConnection(GlobalVariable.connString);

        private void lbl_Close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void ShowPass_CB_CheckStateChanged(object sender, EventArgs e)
        {

            if (ShowPass_CB.CheckState == CheckState.Checked)
            {
                txt_pass.UseSystemPasswordChar = true;
                txt_ConfirmPass.UseSystemPasswordChar = true;
              

            }
            else
            {
                txt_pass.UseSystemPasswordChar = false;
                txt_ConfirmPass.UseSystemPasswordChar = false;
              
            }
        }

        private void GetPassword()
        {
            SqlCommand cmd = new SqlCommand("SELECT Password FROM Login WHERE EmployeeID_fk = @EmployeeID", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@EmployeeID", GlobalVariable.changePassID);

            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }

            try
            {
               object pass =  cmd.ExecuteScalar();
                if(pass != null)
                {
                    txt_pass.Text = pass.ToString();
                    txt_ConfirmPass.Text = pass.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            sqlcon.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_pass.Text.Length >= 8)
            {

                if (txt_pass.Text.Trim() == txt_ConfirmPass.Text.Trim())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE [Login] SET Password = @Password WHERE EmployeeID_fk = @EmployeeID", sqlcon);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Password", txt_ConfirmPass.Text.Trim());
                    cmd.Parameters.AddWithValue("@EmployeeID", GlobalVariable.changePassID);

                    if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    sqlcon.Close();

                    MessageBox.Show("Password Save !");
                    this.Hide();


                }
                else
                {
                    MessageBox.Show("Password not match!");

                }
            }
            else
            {
                MessageBox.Show("Password must be atleast 8 characters!");
            }
        }
    }
}
