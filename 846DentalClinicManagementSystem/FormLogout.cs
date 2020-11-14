using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;

namespace _846DentalClinicManagementSystem
{
    public partial class FormLogout : Form
    {
        public FormLogout()
        {
            InitializeComponent();
        }
        SqlConnection sqlcon = new SqlConnection(GlobalVariable.connString);

        private void btn_backup_Click(object sender, EventArgs e)
        {
            string command = GlobalVariable.path + @"\BackupData.bat";

            DialogResult result = MessageBox.Show("Backup Database ?", "Backup Database", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                BackupDatabase(command);
            }
           

        }

        private void BackupDatabase(string command)
        {
            sqlcon.Close(); // make sure to close the database connection first before backup

            string bat = command;
            var psi = new ProcessStartInfo();
            psi.CreateNoWindow = true; //This hides the dos-style black window that the command prompt usually shows
            psi.FileName = @"cmd.exe";
            psi.Verb = "runas"; //This is what actually runs the command as administrator
            psi.Arguments = "/C " + bat;
            try
            {
                var process = new Process();
                process.StartInfo = psi;
                process.Start();
                process.WaitForExit();
                MessageBox.Show("Backup Successful !");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                DialogResult result = MessageBox.Show("Backup Failed ! ", "Backup Database", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Retry)
                {
                    BackupDatabase(command);
                }
                
            }

        }
        
        private void btn_logout_Click(object sender, EventArgs e)
        {
            var main = Application.OpenForms.OfType<MainForm>().First();
            this.Hide(); //hide logout form
            main.Hide(); // hide mainform
            FormLogin formlogin = new FormLogin();
            formlogin.ShowDialog(); // show login form

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FormLogout_Load(object sender, EventArgs e)
        {

        }
    }
}
