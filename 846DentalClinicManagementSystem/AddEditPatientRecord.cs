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
using System.Collections;

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
        String LName, FName, MName, Gender, Address, Birthday, ContactNo;
        long age ;
        int PatientID;
        ArrayList ExistingApp = new ArrayList();

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
                txt_ContactNo.Text = dt.Rows[0][4].ToString();
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
                txt_ContactNo.Text = dt.Rows[0][4].ToString();
                birthday_DP.Value = DateTime.ParseExact(dt.Rows[0][5].ToString(), "M/d/yyyy hh:mm:ss tt", System.Globalization.CultureInfo.CurrentCulture);
                txt_Age.Text = dt.Rows[0][6].ToString();
                txt_address.Text = dt.Rows[0][7].ToString();
                String itemGender = dt.Rows[0][8].ToString();

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

        private void lbl_Close_Click(object sender, EventArgs e)
        {

            this.Hide();
            GlobalVariable.isAddPatient = false;
            GlobalVariable.isEditPatient = false;
            GlobalVariable.isAppointmentPatientExist = false;

        }

        private void LoadID()
        {
            SqlCommand cmd = new SqlCommand("SELECT PatientID From Patient ORDER BY PatientID DESC", sqlcon);
            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
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
            ContactNo = txt_ContactNo.Text.Trim();

            bool isLNameValid = Regex.IsMatch(LName, @"^[a-zA-Z\x20]*?$");
            bool isFNameValid = Regex.IsMatch(FName, @"^[a-zA-Z\x20]*?$");
            bool isMNameValid = Regex.IsMatch(MName, @"^[a-zA-Z\x20]*?$");
            bool isContactValid = Regex.IsMatch(ContactNo, @"^[0-9]+$");

            if ((isLNameValid == true) && (string.IsNullOrEmpty(LName) == false))
            {
                if ((isFNameValid == true) && (string.IsNullOrEmpty(FName) == false))
                {
                    if ((isMNameValid == true) && (string.IsNullOrEmpty(MName) == false))
                    {
                        if ((string.IsNullOrEmpty(ContactNo) == false) && isContactValid && (ContactNo.Length == 11 || ContactNo.Length == 8 ))
                        {

                            if (string.IsNullOrEmpty(Gender) == false)
                            {
                                if ((string.IsNullOrEmpty(Birthday) == false) && (age >= 2 && age <= 80))
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
                                            GlobalVariable.InsertActivityLog("Added Patient, Patient ID = " + GlobalVariable.PatientID, "Add");
                                            this.Hide();
                                        }
                                        if (GlobalVariable.isEditPatient == true && GlobalVariable.isAddPatient == false)
                                        {
                                            UpdatePatientRecordToDB();
                                            CheckExistingApp_Patient();
                                            MessageBox.Show("Record Updated Successfully");
                                            main.PatientPanelSearch("");
                                            GlobalVariable.isEditPatient = false;
                                            GlobalVariable.InsertActivityLog("Edited Patient, Patient ID = " + GlobalVariable.PatientID, "Edit");
                                            this.Hide();

                                        }


                                    }
                                    else { MessageBox.Show("Invalid Address"); }
                                }
                                else { MessageBox.Show("Invalid Birthday"); }

                            }
                            else { MessageBox.Show("Invalid Gender"); }
                        }
                        else { MessageBox.Show("Invalid Contact Number"); }
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
                "INSERT INTO [Patient] (PatientLName,PatientFName,PatientMName,PatientContact,PatientBirthday,PatientAge,PatientAddress,PatientGender,PatientFullName) " +
                "VALUES(@LName,@FName,@MName,@Contact,@birthday,@age,@address,@gender,@fullname)", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@LName",LName);
            cmd.Parameters.AddWithValue("@FName",FName);
            cmd.Parameters.AddWithValue("@MName",MName);
            cmd.Parameters.AddWithValue("@Contact", ContactNo);
            cmd.Parameters.AddWithValue("@birthday",Birthday);
            cmd.Parameters.AddWithValue("@age",age);
            cmd.Parameters.AddWithValue("@address",Address);
            cmd.Parameters.AddWithValue("@gender",Gender);
            cmd.Parameters.AddWithValue("@fullname",FName + " " + MName + " " + LName );

            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
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
                "UPDATE [Patient] SET PatientLName = @LName,PatientFName =@FName,PatientMName = @MName,PatientContact = @Contact,PatientBirthday = @birthday, " +
                "PatientAge = @age,PatientAddress = @address,PatientGender = @gender,PatientFullName = @fullname " +
                "WHERE PatientID = @ID", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@LName", LName);
            cmd.Parameters.AddWithValue("@FName", FName);
            cmd.Parameters.AddWithValue("@MName", MName);
            cmd.Parameters.AddWithValue("@Contact", ContactNo);
            cmd.Parameters.AddWithValue("@birthday", Birthday);
            cmd.Parameters.AddWithValue("@age", age);
            cmd.Parameters.AddWithValue("@address", Address);
            cmd.Parameters.AddWithValue("@gender", Gender);
            cmd.Parameters.AddWithValue("@fullname", FName + " " + MName + " " + LName);
            cmd.Parameters.AddWithValue("@ID", PatientID);

            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                cmd.ExecuteNonQuery();
               
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            sqlcon.Close();

        }

        //Check whether patient has an existing appointment record
        private void CheckExistingApp_Patient()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                "SELECT AppointmentID_fk FROM PatientTreatment WHERE PatientID_fk = @PatientID",sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@PatientID", GlobalVariable.PatientID);
            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);
                foreach(DataRow AppID in dt.Rows)
                {
                    UpdateAppInfoOnPatientUpdate((int)AppID[0]);
                }

            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

           
        }
    
        

        //Updates the info of patient in appointment if the patient info in patient table is updated
        private void UpdateAppInfoOnPatientUpdate(int AppID)
        {
           
                SqlCommand cmd = new SqlCommand(
               "UPDATE [Appointment] SET Appointment_LName = @LName, Appointment_FName = @FName, Appointment_MName = @MName," +
               "Appointment_Contact = @contact WHERE AppointmentID = @AppointmentID ", sqlcon);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@LName", LName);
                cmd.Parameters.AddWithValue("@FName", FName);
                cmd.Parameters.AddWithValue("@MName", MName);
                cmd.Parameters.AddWithValue("@contact", ContactNo);
                cmd.Parameters.AddWithValue("@AppointmentID", AppID);

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
