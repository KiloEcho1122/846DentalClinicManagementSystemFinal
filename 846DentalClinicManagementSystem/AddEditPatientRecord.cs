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
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;

namespace _846DentalClinicManagementSystem
{
    public partial class AddEditPatientRecord : Form
    {

        public static AddEditPatientRecord AddEditPatient;
        //static String workingDirectory = Environment.CurrentDirectory;
        //static String projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
        //static String LocalDbSource = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=";
        //static String LocalDBFile = projectDirectory + @"\846DentalClinicDB.mdf";
        //static String connString = LocalDbSource + LocalDBFile + ";Integrated Security=True";
        SqlConnection sqlcon = new SqlConnection(GlobalVariable.connString);
        String LName, FName, MName, Gender, Address, Birthday;
        long age ;
        int PatientID;
     
        private void btn_close_Click(object sender, EventArgs e)
        {

            this.Hide();
            GlobalVariable.isAddPatient = false;
            GlobalVariable.isEditPatient = false;
            GlobalVariable.isAppointmentPatientExist = false;

        }

        private void gender_DD_onItemSelected(object sender, EventArgs e)
        {
            Gender = gender_DD.selectedValue;
        }

        private void birthday_DP_onValueChanged(object sender, EventArgs e)
        {
            DateTime birthday_date = birthday_DP.Value;
            DateTime DateNow = DateTime.Today;

            Birthday = birthday_DP.Value.ToString("M/d/yyyy");
            age = (long)(Math.Round((DateNow - birthday_date).TotalDays)/365);
            txt_Age.Text = age.ToString();

        }

        public AddEditPatientRecord()
        {
            InitializeComponent();
        }

        private void AddEditPatientRecord_Load(object sender, EventArgs e)
        {

            if (GlobalVariable.isAddPatient == true && GlobalVariable.isEditPatient == false)
            {
                LoadID();
                this.Text = "Add Patient Record";
                // Para to sa mga patient sa appointment na wala pang record sa PatientDB, magfill up ng form tas iload ung name sa form
                if (GlobalVariable.isAppointmentPatientExist == true)
                {
                    LoadAppointmentNameToForm();
                }
                
                
            }
            if (GlobalVariable.isEditPatient == true && GlobalVariable.isAddPatient == false)
            {
                txt_formHeader.Text = "Edit Patient Record";
                this.Text = "Edit Patient Record";
                btn_add.Text = "Update";
                PatientID = GlobalVariable.PatientID;
                txt_PatientNo.Text = PatientID.ToString();
                LoadPatientRecord();
            }
            
        }

        private void LoadAppointmentNameToForm()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Appointment WHERE AppointmentID = @AppID", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@AppID", GlobalVariable.AppointmentID);
            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);
                txt_LName.Text = dt.Rows[0][1].ToString();
                txt_FName.Text = dt.Rows[0][2].ToString();
                txt_MName.Text = dt.Rows[0][3].ToString();
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void LoadPatientRecord()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Patient WHERE PatientID = @ID", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", PatientID);
            adapter.SelectCommand = cmd;

            try{
                adapter.Fill(dt);
                txt_LName.Text = dt.Rows[0][1].ToString();
                txt_FName.Text = dt.Rows[0][2].ToString();
                txt_MName.Text = dt.Rows[0][3].ToString();
                birthday_DP.Value = DateTime.ParseExact(dt.Rows[0][4].ToString(), "M/d/yyyy hh:mm:ss tt", System.Globalization.CultureInfo.CurrentCulture);
                txt_Age.Text = dt.Rows[0][5].ToString();
                txt_address.Text = dt.Rows[0][6].ToString();
                String itemGender = dt.Rows[0][7].ToString();

                for (int i = 0; i < gender_DD.Items.Length; i++)
                {
                    if (gender_DD.Items[i] == itemGender)
                    {
                        gender_DD.selectedIndex = i;

                    }

                }
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }

        }

        private void LoadID()
        {
            SqlCommand cmd = new SqlCommand("SELECT PatientID From Patient ORDER BY PatientID DESC", sqlcon);
            sqlcon.Open();
            try
            {
                int ID = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                txt_PatientNo.Text = ID.ToString();
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            sqlcon.Close();
        }


        private void btn_add_Click(object sender, EventArgs e)
        {
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

            LName = myTI.ToTitleCase(txt_LName.Text.Trim());
            FName = myTI.ToTitleCase(txt_FName.Text.Trim());
            MName = myTI.ToTitleCase(txt_MName.Text.Trim());
            Address = myTI.ToTitleCase(txt_address.Text.Trim());

            bool isLNameValid = Regex.IsMatch(LName, @"^[a-zA-Z\x20]*?$");
            bool isFNameValid = Regex.IsMatch(FName, @"^[a-zA-Z\x20]*?$");
            bool isMNameValid = Regex.IsMatch(MName, @"^[a-zA-Z\x20]*?$");

            if ((isLNameValid == true) && (string.IsNullOrEmpty(LName) == false))
            {
                if ((isFNameValid == true) && (string.IsNullOrEmpty(FName) == false))
                {
                    if ((isMNameValid == true) && (string.IsNullOrEmpty(MName) == false))
                    {
                        if (string.IsNullOrEmpty(Gender) == false)
                        {
                            if ((string.IsNullOrEmpty(Birthday) == false) || (age < 2))
                            {
                                if (string.IsNullOrEmpty(Address) == false)
                                {
                                     var main = Application.OpenForms.OfType<MainForm>().First();
                                    if (GlobalVariable.isAddPatient == true && GlobalVariable.isEditPatient == false)
                                    {
                                        InsertPatientRecordToDB();
                                        main.PatientPanelSearch("");
                                        GlobalVariable.isAddPatient = false;
                                        GlobalVariable.isAppointmentPatientExist = false;
                                        this.Hide();
                                    }
                                    if (GlobalVariable.isEditPatient == true && GlobalVariable.isAddPatient == false)
                                    {
                                        UpdatePatientRecordToDB();
                                        main.PatientPanelSearch("");
                                        GlobalVariable.isEditPatient = false;
                                        this.Hide();

                                    }

                                   
                                }
                                else { MessageBox.Show("Invalid Address"); }
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

        private void InsertPatientRecordToDB()
        {
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO [Patient] (PatientLName,PatientFName,PatientMName,PatientBirthday,PatientAge,PatientAddress,PatientGender,PatientFullName) " +
                "VALUES(@LName,@FName,@MName,@birthday,@age,@address,@gender,@fullname)", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@LName",LName);
            cmd.Parameters.AddWithValue("@FName",FName);
            cmd.Parameters.AddWithValue("@MName",MName);
            cmd.Parameters.AddWithValue("@birthday",Birthday);
            cmd.Parameters.AddWithValue("@age",age);
            cmd.Parameters.AddWithValue("@address",Address);
            cmd.Parameters.AddWithValue("@gender",Gender);
            cmd.Parameters.AddWithValue("@fullname",FName + " " + MName + " " + LName );

            sqlcon.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Added Successfully");
            }catch(Exception ex) { Console.WriteLine(ex.Message); }

            sqlcon.Close();
            

        }

        private void UpdatePatientRecordToDB()
        {
            SqlCommand cmd = new SqlCommand(
                "UPDATE [Patient] SET PatientLName = @LName,PatientFName =@FName,PatientMName = @MName,PatientBirthday = @birthday, " +
                "PatientAge = @age,PatientAddress = @address,PatientGender = @gender,PatientFullName = @fullname " +
                "WHERE PatientID = @ID", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@LName", LName);
            cmd.Parameters.AddWithValue("@FName", FName);
            cmd.Parameters.AddWithValue("@MName", MName);
            cmd.Parameters.AddWithValue("@birthday", Birthday);
            cmd.Parameters.AddWithValue("@age", age);
            cmd.Parameters.AddWithValue("@address", Address);
            cmd.Parameters.AddWithValue("@gender", Gender);
            cmd.Parameters.AddWithValue("@fullname", FName + " " + MName + " " + LName);
            cmd.Parameters.AddWithValue("@ID", PatientID);

            sqlcon.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            sqlcon.Close();

        }

       
    }
}
