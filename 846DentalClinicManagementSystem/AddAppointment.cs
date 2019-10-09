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
    public partial class AddAppointment : Form
    {
        
        static String workingDirectory = Environment.CurrentDirectory;
        static String projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
        static String LocalDbSource = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=";
        static String LocalDBFile = projectDirectory + @"\846DentalClinicDB.mdf";
        static String connString = LocalDbSource + LocalDBFile + ";Integrated Security=True";
        SqlConnection sqlcon = new SqlConnection(connString);

        int SelectedTreatmentID = 0, SelectedDentistID = 0, AppNo = 0;
        String LName, MName, FName, StartTime, EndTime, refTime, AppDate,Note = "";
        Boolean isDateChanged = false;


        public AddAppointment()
        {
            InitializeComponent();
        }

        private void AddAppointment_Load(object sender, EventArgs e)
        {
            
            LoadDropDownList();
            // if add appointmen increment ID
            var main = Application.OpenForms.OfType<MainForm>().First();
            if (main.isAddAppointment == true && main.isEditAppointment == false)
            {
                fillAppID();
                txt_AppNo.Text = AppNo.ToString();

            }
            if (main.isEditAppointment == true && main.isAddAppointment ==false)
            {
                AppNo = MainForm.c1.AppointmentID;
                txt_AppNo.Text = AppNo.ToString();
                txt_PatientSearch.Enabled = false;
                btn_add.Text = "Update";
                txt_formHeader.Text = "Update Appointment";
                fillFormforUpdate();

            }


        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Hide();
            var main = Application.OpenForms.OfType<MainForm>().First();
            main.isEditAppointment = false;
            main.isAddAppointment = false;


        }

        private void btn_add_Click(object sender, EventArgs e)
        {

            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

            LName = myTI.ToTitleCase(txt_LName.Text.Trim());
            FName = myTI.ToTitleCase(txt_FName.Text.Trim());
            MName = myTI.ToTitleCase(txt_MName.Text.Trim());
            Note = txt_Note.Text.Trim();

            bool isLNameValid = Regex.IsMatch(LName, @"^[a-zA-Z\x20]*?$");
            bool isFNameValid = Regex.IsMatch(FName, @"^[a-zA-Z\x20]*?$");
            bool isMNameValid = Regex.IsMatch(MName, @"^[a-zA-Z\x20]*?$");

            if ((isLNameValid == true) && (string.IsNullOrEmpty(LName) == false))
            {
                if ((isFNameValid == true) && (string.IsNullOrEmpty(FName) == false))
                {
                    if ((isMNameValid == true) && (string.IsNullOrEmpty(MName) == false))
                    {
                        if (SelectedTreatmentID > 0)
                        {
                            if (SelectedDentistID > 0)
                            {
                                if (string.IsNullOrEmpty(StartTime) == false)
                                {
                                   
                                    if (isDateChanged == false)
                                    {
                                        AppointmentDatePick();
                                    }
                                    //MessageBox.Show(AppDate);

                                    if (string.IsNullOrEmpty(AppDate) == false)
                                    {
                                        var main = Application.OpenForms.OfType<MainForm>().First();
                                        if (main.isAddAppointment == true && main.isEditAppointment == false)
                                        {
                                            insertAppointmentToDB();
                                            main.isAddAppointment = false;

                                        }
                                        if (main.isEditAppointment == true && main.isAddAppointment == false)
                                        {
                                            updateAppointmentToDB();
                                            main.isEditAppointment = false;

                                        }


                                    } else { MessageBox.Show("Invalid Date"); }

                                } else { MessageBox.Show("Time Overlapse with other appointment"); }

                            } else { MessageBox.Show("Invalid Dentist"); }

                        } else { MessageBox.Show("Invalid Treatment"); }

                    } else { MessageBox.Show("Invalid Middle Name"); }

                } else { MessageBox.Show("Invalid First Name"); }

            } else { MessageBox.Show("Invalid Last Name"); }

        }

        private void fillFormforUpdate()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("SELECT * From Appointment WHERE AppointmentID = @AppointmentID",sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@AppointmentID", AppNo);
            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            String itemTime = dt.Rows[0][5].ToString();
            txt_LName.Text = dt.Rows[0][1].ToString();
            txt_FName.Text = dt.Rows[0][2].ToString();
            txt_MName.Text = dt.Rows[0][3].ToString();
            txt_Note.Text = dt.Rows[0][10].ToString();
            SelectedTreatmentID = Convert.ToInt32(dt.Rows[0][8]) - 1;
            SelectedDentistID= Convert.ToInt32(dt.Rows[0][9]) - 1;

            if (SelectedDentistID == -1) { SelectedDentistID = 0; }
            if (SelectedTreatmentID == -1) { SelectedTreatmentID = 0; }
         
            TreatmentDD.selectedIndex = SelectedTreatmentID;
            DentistDD.selectedIndex = SelectedDentistID;

            DP_date.Value = DateTime.ParseExact(dt.Rows[0][4].ToString(), "M/d/yyyy hh:mm:ss tt", System.Globalization.CultureInfo.CurrentCulture);

            for (int i = 0; i < TimeDD.Items.Length; i++)
            {
                if (TimeDD.Items[i] == itemTime)
                {
                    TimeDD.selectedIndex = i;

                }

            }
           
          
        }

        private void updateAppointmentToDB()
        {
         
            SqlCommand cmd = new SqlCommand(
                "UPDATE [Appointment] SET Appointment_LName = @LName, Appointment_FName = @FName, Appointment_MName = @MName, AppointmentDate = @Date," +
                "StartTime = @StartTime, EndTime = @EndTime ,RefTime = @RefTime,TreatmentID_fk = @TreatmentID_fk, DentistID_fk = @DentistID_fk ," +
                "AppointmentNote = @Note WHERE AppointmentID = @AppointmentID ", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@LName", LName);
            cmd.Parameters.AddWithValue("@FName", FName);
            cmd.Parameters.AddWithValue("@MName", MName);
            cmd.Parameters.AddWithValue("@Date", AppDate);
            cmd.Parameters.AddWithValue("@StartTime", StartTime);
            cmd.Parameters.AddWithValue("@EndTime", EndTime);
            cmd.Parameters.AddWithValue("@RefTime", refTime);
            cmd.Parameters.AddWithValue("@TreatmentID_fk", SelectedTreatmentID);
            cmd.Parameters.AddWithValue("@DentistID_fk", SelectedDentistID);
            cmd.Parameters.AddWithValue("@Note", Note);
            cmd.Parameters.AddWithValue("@AppointmentID", AppNo);

            sqlcon.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Appointment updated successfully");
                //DateTime Todaydate = DateTime.Today;
                //string date = Todaydate.ToString("M/d/yyyy");
                MainForm.c1.ShowAppointment(AppDate);

                this.Hide();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            sqlcon.Close();
        }

        private void insertAppointmentToDB()
        {

            SqlCommand cmd = new SqlCommand(
                "Insert Into [Appointment] (Appointment_LName,Appointment_FName,Appointment_MName,AppointmentDate,StartTime,EndTime,RefTime,TreatmentID_fk,DentistID_fk,AppointmentNote) " +
                "Values(@LName,@FName,@MName,@Date,@StartTime,@EndTime,@RefTime,@TreatmentID_fk,@DentistID_fk,@Note) ", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@LName", LName);
            cmd.Parameters.AddWithValue("@FName", FName);
            cmd.Parameters.AddWithValue("@MName", MName);
            cmd.Parameters.AddWithValue("@Date", AppDate);
            cmd.Parameters.AddWithValue("@StartTime", StartTime);
            cmd.Parameters.AddWithValue("@EndTime", EndTime);
            cmd.Parameters.AddWithValue("@RefTime", refTime);
            cmd.Parameters.AddWithValue("@TreatmentID_fk", SelectedTreatmentID);
            cmd.Parameters.AddWithValue("@DentistID_fk", SelectedDentistID);
            cmd.Parameters.AddWithValue("@Note", Note);

            sqlcon.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Appointment added successfully");
                //DateTime Todaydate = DateTime.Today;
                //string date = Todaydate.ToString("M/d/yyyy");
                MainForm.c1.ShowAppointment(AppDate);

                this.Hide();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            sqlcon.Close();
        }

        private void DP_date_onValueChanged(object sender, EventArgs e)
        {

            AppointmentDatePick();
            isDateChanged = true;

        }

        private void AppointmentDatePick()
        {
            Checktime();
            try
            {
                String time = TimeDD.selectedValue;
                AppDate = DP_date.Value.ToString("M/d/yyyy") + " " + time;
                DateTime DateApp = DateTime.ParseExact(AppDate, "M/d/yyyy hh:mm tt", System.Globalization.CultureInfo.CurrentCulture);
                DateTime CurrentDate = DateTime.Now;

                //check if Date is not less than current date
                if (DateApp > CurrentDate)
                {
                    AppDate = DP_date.Value.ToString("M/d/yyyy");
                }
                else
                {
                    AppDate = "";
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message + AppDate); }


        }

        private void btn_PatientSearch_Click(object sender, EventArgs e)
        {
            PatientSearch();

        }

        private void PatientSearch()
        {
            String search = txt_PatientSearch.text.Trim();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                "SELECT PatientID AS ID, CONCAT(PatientLName, ', ',PatientFName , ' ', PatientMName) AS Name , " +
                "PatientGender AS Gender, PatientAge AS Age, PatientBirthday AS Birthday,PatientAddress AS Address " +
                "FROM [Patient] WHERE PatientFullName LIKE @search ", sqlcon);

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@search", "%" + search + "%");

            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);

                AppSearch_DataGrid.DataSource = dt;

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void txt_PatientSearch_OnTextChange(object sender, EventArgs e)
        {
            PatientSearch();
        }

        private void AppSearch_DataGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (AppSearch_DataGrid.SelectedRows.Count > 0) // make sure user select at least 1 row 
            {
                string ID = AppSearch_DataGrid.SelectedRows[0].Cells[0].Value + string.Empty;

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Patient WHERE PatientID = @ID", sqlcon);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID",ID);
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
        }

        private void LoadDropDownList()
        {
            SqlDataAdapter adapter1 = new SqlDataAdapter();
            SqlDataAdapter adapter2 = new SqlDataAdapter();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            SqlCommand cmd = new SqlCommand(
                   "SELECT TreatmentType FROM Treatment ORDER BY TreatmentID ASC", sqlcon);
            SqlCommand cmd2 = new SqlCommand(
                  "SELECT CONCAT(DentistFName,' ',DentistMName, ' ', DentistLName) FROM Dentist ORDER BY DentistID ASC", sqlcon);
            SqlCommand cmd3 = new SqlCommand(
                  "SELECT AppointmentID FROM Appointment ORDER BY AppointmentID DESC", sqlcon);

            adapter1.SelectCommand = cmd;
            adapter2.SelectCommand = cmd2;
            sqlcon.Open();
            try
            {
                adapter1.Fill(dt1);
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    this.TreatmentDD.AddItem(dt1.Rows[i][0].ToString());
                }

                adapter2.Fill(dt2);
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    this.DentistDD.AddItem(dt2.Rows[i][0].ToString());
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            sqlcon.Close();

        }

        private void fillAppID()
        {
            SqlCommand cmd = new SqlCommand(
                 "SELECT AppointmentID FROM Appointment ORDER BY AppointmentID DESC", sqlcon);
            sqlcon.Open();
            try
            {
                AppNo = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void TreatmentDD_onItemSelected(object sender, EventArgs e)
        {
            SelectedTreatmentID = TreatmentDD.selectedIndex + 1;
        }

        private void DentistDD_onItemSelected(object sender, EventArgs e)
        {
            SelectedDentistID = DentistDD.selectedIndex + 1;
        }

        private void TimeDD_onItemSelected(object sender, EventArgs e)
        {

            Checktime();

        }

        private void Checktime()
        {
            try
            {
                String SelectedTime = TimeDD.selectedValue;
                DateTime timeStartA = DateTime.ParseExact(SelectedTime, "hh:mm tt", System.Globalization.CultureInfo.CurrentCulture);
                DateTime timeEndA = timeStartA.AddHours(1);
                String Addedtime = (timeEndA.ToString("hh:mm tt"));

                //exclusive for appointment update only
                //DateTime prevTime = DateTime.ParseExact(itemTime, "hh:mm tt", System.Globalization.CultureInfo.CurrentCulture);
                //prevTime = prevTime.AddMinutes(30);
                //String prevTimeString = prevTime.ToString("hh:mm tt");
            
                //
                    
                    if (CheckOverlapseTimeinDB(timeStartA, timeEndA) == false)
                    {
                        StartTime = SelectedTime;
                        EndTime = Addedtime;
                        refTime = (timeStartA.ToString("HH:mm"));
                    }
                    else {
                    MessageBox.Show("Time Overlapse with other appointment");
                    StartTime = "";
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

     
        }

        private static bool isValidTime(DateTime dtStartA, DateTime dtEndA)
        {

            DateTime timeStart = DateTime.ParseExact("08:00 AM", "hh:mm tt", System.Globalization.CultureInfo.CurrentCulture);
            DateTime timeEnd = DateTime.ParseExact("06:00 PM", "hh:mm tt", System.Globalization.CultureInfo.CurrentCulture);

            if ((dtEndA.Subtract(dtStartA).TotalMinutes) >= 600 || (dtStartA.Subtract(dtEndA).TotalMinutes) >= 600)
            {
                return true;
            }
            return dtStartA < timeStart || dtEndA > timeEnd || dtStartA > timeEnd || dtEndA < timeStart || dtStartA == dtEndA;

        }


        private bool CheckOverlapseTimeinDB(DateTime timeStartA, DateTime timeEndA)
        {
            String date = DP_date.Value.ToString("M/d/yyyy");
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                   "SELECT StartTime,EndTime FROM Appointment WHERE DentistID_fk = @DentistID_fk AND " + "" +
                   "AppointmentDate =@date AND NOT AppointmentID = @AppID", sqlcon);

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@DentistID_fk", SelectedDentistID);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@AppID", AppNo);
            adapter.SelectCommand = cmd;

            //Console.WriteLine(SelectedDentistID + "   " + date);

            try
            {
                adapter.Fill(dt);
                String StartTime, EndTime;

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    StartTime = dt.Rows[i][0].ToString();
                    EndTime = dt.Rows[i][1].ToString();


                    DateTime timeStartB = DateTime.ParseExact(StartTime, "hh:mm tt", System.Globalization.CultureInfo.CurrentCulture);
                    DateTime timeEndB = DateTime.ParseExact(EndTime, "hh:mm tt", System.Globalization.CultureInfo.CurrentCulture);

                    if (isOverlapDates(timeStartA, timeEndA, timeStartB, timeEndB) == true)
                    {
                        return true;
                        
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
 
            return false;
        }


        private static bool isOverlapDates(DateTime dtStartA, DateTime dtEndA, DateTime dtStartB, DateTime dtEndB)
        {
            return dtStartA < dtEndB && dtStartB < dtEndA;
        }

    }

}
