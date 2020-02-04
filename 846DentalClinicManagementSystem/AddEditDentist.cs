using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _846DentalClinicManagementSystem
{
    public partial class AddEditDentist : Form
    {
        public AddEditDentist()
        {
            InitializeComponent();
        }

        SqlConnection sqlcon = new SqlConnection(GlobalVariable.connString);

        private void AddEditDentist_Load(object sender, EventArgs e)
        {
            if (GlobalVariable.isAddDentist == true && GlobalVariable.isEditDentist == false)
            {
                LoadID();
                this.Text = "Add Dentist Record";


            }
            if (GlobalVariable.isEditDentist == true && GlobalVariable.isAddDentist == false)
            {
                txt_formHeader.Text = "Edit Dentist Record";
                this.Text = "Edit Dentist Record";
                btn_add.Text = "Update";
                txt_DentistNo.Text = GlobalVariable.DentID.ToString();
                LoadDentistRecord();
            }
        }

        private void LoadID()
        {
            SqlCommand cmd = new SqlCommand("SELECT DentistID From Dentist ORDER BY DentistID DESC", sqlcon);
            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                int ID = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                txt_DentistNo.Text = ID.ToString();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            sqlcon.Close();
        }


        private void LoadDentistRecord()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Dentist WHERE DentistID = @DentistID", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@DentistID", GlobalVariable.DentID);
            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);
                txt_LName.Text = dt.Rows[0][1].ToString();
                txt_FName.Text = dt.Rows[0][2].ToString();
                txt_MName.Text = dt.Rows[0][3].ToString();
                txt_LicenseNo.Text = dt.Rows[0][4].ToString();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Hide();
            GlobalVariable.isAddDentist = false;
            GlobalVariable.isEditDentist = false;
     
        }
        String LName, FName, MName, LicenseNo;
        private void btn_add_Click(object sender, EventArgs e)
        {
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

            LName = myTI.ToTitleCase(txt_LName.Text.Trim());
            FName = myTI.ToTitleCase(txt_FName.Text.Trim());
            MName = myTI.ToTitleCase(txt_MName.Text.Trim());
            LicenseNo = txt_LicenseNo.Text.Trim();

            bool isLNameValid = Regex.IsMatch(LName, @"^[a-zA-Z\x20]*?$");
            bool isFNameValid = Regex.IsMatch(FName, @"^[a-zA-Z\x20]*?$");
            bool isMNameValid = Regex.IsMatch(MName, @"^[a-zA-Z\x20]*?$");
            bool isLicenseNoValid = Regex.IsMatch(LicenseNo, @"^[0-9]+$");

            if ((isLNameValid == true) && (string.IsNullOrEmpty(LName) == false))
            {
                if ((isFNameValid == true) && (string.IsNullOrEmpty(FName) == false))
                {
                    if ((isMNameValid == true) && (string.IsNullOrEmpty(MName) == false))
                    {
                        if ((string.IsNullOrEmpty(LicenseNo) == false) && isLicenseNoValid)
                        {

                            var main = Application.OpenForms.OfType<MainForm>().First();
                               if (GlobalVariable.isAddDentist == true && GlobalVariable.isEditDentist == false)
                               {
                                     InsertDentistRecordToDB();
                                     main.DentistPanelSearch("");
                                     GlobalVariable.isAddDentist = false;
                                     GlobalVariable.isAppointmentPatientExist = false;
                                     this.Hide();
                               }
                               if (GlobalVariable.isEditDentist == true && GlobalVariable.isAddDentist == false)
                               {
                                     UpdateDentistRecordToDB();
                                     MessageBox.Show("Record Updated Successfully");
                                     main.DentistPanelSearch("");
                                     GlobalVariable.isEditDentist = false;
                                     this.Hide();

                               }
                        }
                        else { MessageBox.Show("Invalid License Number"); }
                    }
                    else { MessageBox.Show("Invalid Middle Name"); }

                }
                else { MessageBox.Show("Invalid First Name"); }

            }
            else { MessageBox.Show("Invalid Last Name"); }
        }

        private void InsertDentistRecordToDB()
        {
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO [Dentist] (DentistLName,DentistFName,DentistMName,DentistLicenseNo) " +
                "VALUES(@LName,@FName,@MName,@LicenseNo)", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@LName", LName);
            cmd.Parameters.AddWithValue("@FName", FName);
            cmd.Parameters.AddWithValue("@MName", MName);
            cmd.Parameters.AddWithValue("@LicenseNo", LicenseNo);
            

            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Added Successfully");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            sqlcon.Close();


        }
        private void UpdateDentistRecordToDB()
        {

            SqlCommand cmd = new SqlCommand(
                 "UPDATE [Dentist] SET DentistLName = @LName,DentistFName =@FName,DentistMName = @MName,DentistLicenseNo = @LicenseNo " +
                 "WHERE DentistID = @ID", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@LName", LName);
            cmd.Parameters.AddWithValue("@FName", FName);
            cmd.Parameters.AddWithValue("@MName", MName);
            cmd.Parameters.AddWithValue("@LicenseNo", LicenseNo);
            cmd.Parameters.AddWithValue("@ID", GlobalVariable.DentID);


            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            sqlcon.Close();


        }
    }

}
