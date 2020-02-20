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
    public partial class AddEditEmployee : Form
    {
        public AddEditEmployee()
        {
            InitializeComponent();
        }

        SqlConnection sqlcon = new SqlConnection(GlobalVariable.connString);

        private void AddEditDentist_Load(object sender, EventArgs e)
        {
            if (GlobalVariable.isAddEmployee == true && GlobalVariable.isEditEmployee == false)
            {
                LoadID();
                this.txt_formHeader.Text = "Add Dentist/Staff ";


            }
            if (GlobalVariable.isEditEmployee == true && GlobalVariable.isAddEmployee == false)
            {
                this.txt_formHeader.Text = "Edit Dentist/Staff Record";
                btn_add.Text = "Update";
                txt_EmployeeNo.Text = GlobalVariable.EmpID.ToString();
                LoadDentistRecord();
            }
        }

        private void LoadID()
        {
            SqlCommand cmd = new SqlCommand("SELECT EmployeeID From Employee ORDER BY EmployeeID DESC", sqlcon);
            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                int ID = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                GlobalVariable.EmpID = ID - 1; // every add lang naman to
                txt_EmployeeNo.Text = ID.ToString();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            sqlcon.Close();
        }


        private void LoadDentistRecord()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Employee WHERE EmployeeID = @EmpID", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@EmpID", GlobalVariable.EmpID);
            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);
                if(dt.Rows[0][1].ToString() == "Admin")
                {
                    Permission_DD.selectedIndex = 1;
                }
                else
                {
                    Permission_DD.selectedIndex = 0;
                }
                txt_LName.Text = dt.Rows[0][2].ToString();
                txt_FName.Text = dt.Rows[0][3].ToString();
                txt_MName.Text = dt.Rows[0][4].ToString();
                if (dt.Rows[0][5].ToString() == "Male")
                {
                    GenderDD.selectedIndex = 0;
                }
                else
                {
                    GenderDD.selectedIndex = 1;
                }
                DateTime dateTime = DateTime.Parse(dt.Rows[0][6].ToString());
                EmployeeBirthday_DP.Value = dateTime;
                txt_EmailAdd.Text = dt.Rows[0][8].ToString();
                txt_Contact.Text = dt.Rows[0][9].ToString();
                txt_HomeAddress.Text = dt.Rows[0][10].ToString();
                if (dt.Rows[0][11].ToString() == "Dentist")
                {
                    PositionDD.selectedIndex = 0;
                }
                else
                {
                    PositionDD.selectedIndex = 1;
                }

                txt_LicenseNo.Text = dt.Rows[0][12].ToString();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Hide();
            GlobalVariable.isAddEmployee = false;
            GlobalVariable.isEditEmployee = false;
     
        }
        String Permission,LName, FName, MName, Gender,Birthday,Email,ContactNo,HomeAdd,Position,LicenseNo;

        private void GenderDD_onItemSelected(object sender, EventArgs e)
        {
            Gender = GenderDD.selectedValue;
        }

        private void Permission_DD_onItemSelected(object sender, EventArgs e)
        {
            Permission = Permission_DD.selectedValue;
        }

        private void PositionDD_onItemSelected(object sender, EventArgs e)
        {
            Position = PositionDD.selectedValue;
            if(PositionDD.selectedValue.ToString() == "Dentist")
            {
                txt_LicenseNo.Enabled = true;
            }
            else
            {
                txt_LicenseNo.Enabled = false;
            }
        }

        long age;

        private void EmployeeBirthday_DP_onValueChanged(object sender, EventArgs e)
        {
            DateTime birthday_date = EmployeeBirthday_DP.Value;
            DateTime DateNow = DateTime.Today;

            Birthday = EmployeeBirthday_DP.Value.ToString("M/d/yyyy");
            age = (long)(Math.Round((DateNow - birthday_date).TotalDays) / 365);
   
        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

            LName = myTI.ToTitleCase(txt_LName.Text.Trim());
            FName = myTI.ToTitleCase(txt_FName.Text.Trim());
            MName = myTI.ToTitleCase(txt_MName.Text.Trim());
            Email = txt_EmailAdd.Text.Trim();
            ContactNo = txt_Contact.Text.Trim();
            HomeAdd = txt_HomeAddress.Text.Trim();
            LicenseNo = txt_LicenseNo.Text.Trim();

            bool isLNameValid = Regex.IsMatch(LName, @"^[a-zA-Z\x20]*?$");
            bool isFNameValid = Regex.IsMatch(FName, @"^[a-zA-Z\x20]*?$");
            bool isMNameValid = Regex.IsMatch(MName, @"^[a-zA-Z\x20]*?$");
            bool isLicenseNoValid = Regex.IsMatch(LicenseNo, @"^[0-9]+$");
            bool isContactValid = Regex.IsMatch(ContactNo, @"^[0-9]+$");

          


            if (string.IsNullOrEmpty(Permission) == false)
            {

                if ((isLNameValid == true) && (string.IsNullOrEmpty(LName) == false))
                {
                    if ((isFNameValid == true) && (string.IsNullOrEmpty(FName) == false))
                    {
                        if ((isMNameValid == true) && (string.IsNullOrEmpty(MName) == false))
                        {
                            if(string.IsNullOrEmpty(Gender) == false)
                            {
                                if(age >= 18 && age <= 60)
                                {
                                    if (string.IsNullOrEmpty(Email) == false)
                                    {

                                        if ((string.IsNullOrEmpty(ContactNo) == false) && isContactValid && (ContactNo.Length == 11 || ContactNo.Length == 8))
                                        {
                                            if (string.IsNullOrEmpty(HomeAdd) == false)
                                            {
                                                if (string.IsNullOrEmpty(Position) == false)
                                                {
                                                    if (((string.IsNullOrEmpty(LicenseNo) == false) && isLicenseNoValid) || Position == "Staff")
                                                    {

                                                        var main = Application.OpenForms.OfType<MainForm>().First();
                                                        if (GlobalVariable.isAddEmployee == true && GlobalVariable.isEditEmployee == false)
                                                        {
                                                            InsertEmployeeRecordToDB();
                                                            main.DisplayEmployeeDataGrid("");
                                                            GlobalVariable.isAddEmployee = false;
                                                            GlobalVariable.isAppointmentPatientExist = false;
                                                            this.Hide();
                                                        }
                                                        if (GlobalVariable.isEditEmployee == true && GlobalVariable.isAddEmployee == false)
                                                        {
                                                            UpdateEmployeeRecordToDB();
                                                            MessageBox.Show("Record Updated Successfully");
                                                            main.DisplayEmployeeDataGrid("");
                                                            GlobalVariable.isEditEmployee = false;
                                                            this.Hide();

                                                        }
                                                    }
                                                    else { MessageBox.Show("Invalid License Number"); }
                                                }
                                                else { MessageBox.Show("Invalid Position"); }
                                            }
                                            else { MessageBox.Show("Invalid Home Address"); }
                                        }
                                        else { MessageBox.Show("Invalid Contact No"); }
                                    }
                                    else { MessageBox.Show("Invalid Email Address"); }
                                }
                                else { MessageBox.Show("Invalid Birthday"); }
                            }
                            else { MessageBox.Show("Invalid Gender"); }
                        }
                        else { MessageBox.Show("Invalid Middle Name"); }

                    }
                    else { MessageBox.Show("Invalid First Name"); }

                }
                else { MessageBox.Show("Invalid Last Name"); }

            }
            else { MessageBox.Show("Invalid Permission"); }
        }

        private void InsertEmployeeRecordToDB()
        {
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO [Employee] (Permission,LastName,FirstName,MiddleName,Gender,Birthday,Age,EmailAdd,ContactNo,HomeAddress,JobTitle,LicenseNo) " +
                "VALUES(@Permission,@LastName,@FirstName,@MiddleName,@Gender,@Birthday,@Age,@EmailAdd,@ContactNo,@HomeAddress,@JobTitle,@LicenseNo)", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Permission", Permission);
            cmd.Parameters.AddWithValue("@LastName", LName);
            cmd.Parameters.AddWithValue("@FirstName", FName);
            cmd.Parameters.AddWithValue("@MiddleName", MName);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Birthday", Birthday);
            cmd.Parameters.AddWithValue("@Age", age);
            cmd.Parameters.AddWithValue("@EmailAdd", Email);
            cmd.Parameters.AddWithValue("@ContactNo", ContactNo);
            cmd.Parameters.AddWithValue("@HomeAddress", HomeAdd);
            cmd.Parameters.AddWithValue("@JobTitle", Position);
            cmd.Parameters.AddWithValue("@LicenseNo", LicenseNo);
            

            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                cmd.ExecuteNonQuery();
                LoadID();
                AddUserLogin();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            sqlcon.Close();


        }

        private void AddUserLogin()
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO [Login] (Username, EmployeeID_fk) VALUES (@UserName,@EmployeeID_fk)",sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Username",Email);
            cmd.Parameters.AddWithValue("@EmployeeID_fk", GlobalVariable.EmpID);

            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Added Successfully");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            GlobalVariable.EmpID = 0; //remove value to EmpID
            sqlcon.Close();
        }

        private void EditUserLogin()
        {
            SqlCommand cmd = new SqlCommand("UPDATE [Login] SET Username = @Username WHERE EmployeeID_fk = @EmployeeID_fk)", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Username", Email);
            cmd.Parameters.AddWithValue("@EmployeeID_fk", GlobalVariable.EmpID);

            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Added Successfully");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            sqlcon.Close();
        }

        private void UpdateEmployeeRecordToDB()
        {

            SqlCommand cmd = new SqlCommand(
                 "UPDATE [Employee] SET Permission = @Permission, LastName = @LastName, FirstName = @FirstName, MiddleName = @MiddleName, Gender = @Gender," +
                 " Birthday = @Birthday, Age = @Age, EmailAdd = @EmailAdd, ContacNo = @ContactNo, HomeAddress = @HomeAddress, JobTitle = @JobTitle, LicenseNo = @LicenseNo " +
                 "WHERE EmployeeID = @ID", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Permission", Permission);
            cmd.Parameters.AddWithValue("@LastName", LName);
            cmd.Parameters.AddWithValue("@FirstName", FName);
            cmd.Parameters.AddWithValue("@MiddleName", MName);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Birthday", Birthday);
            cmd.Parameters.AddWithValue("@Age", age);
            cmd.Parameters.AddWithValue("@EmailAdd", Email);
            cmd.Parameters.AddWithValue("@ContactNo", ContactNo);
            cmd.Parameters.AddWithValue("@HomeAddress", HomeAdd);
            cmd.Parameters.AddWithValue("@JobTitle", Position);
            cmd.Parameters.AddWithValue("@LicenseNo", LicenseNo);
            cmd.Parameters.AddWithValue("@ID", GlobalVariable.EmpID);


            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                cmd.ExecuteNonQuery();
                EditUserLogin();

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            sqlcon.Close();


        }
    }

}
