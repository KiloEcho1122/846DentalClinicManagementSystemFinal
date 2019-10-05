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

namespace _846DentalClinicManagementSystem
{
    public partial class AddAppointment : Form
    {
        public AddAppointment()
        {
            InitializeComponent();
        }

        String connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mike\Documents\846DentalClinicManagementSystem\846DentalClinicManagementSystem\846DentalClinicDB.mdf;Integrated Security=True";
        int SelectedTreatmentID = 0, SelectedDentistID = 0, AppNo = 0;
        String LName, MName, FName, StartTime, EndTime, refTime, AppDate, Note ="";

        private void AddAppointment_Load(object sender, EventArgs e)
        {
            LoadDropDownList();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {

            LName = txt_LName.Text.Trim();
            FName = txt_FName.Text.Trim();
            MName = txt_MName.Text.Trim();
            Note = txt_Note.Text.Trim();

            bool isLNameValid = Regex.IsMatch(LName, @"^[a-zA-Z\-]*?$");
            bool isFNameValid = Regex.IsMatch(FName, @"^[a-zA-Z\-]*?$");
            bool isMNameValid = Regex.IsMatch(MName, @"^[a-zA-Z\-]*?$");

            if ((isLNameValid == true) && (string.IsNullOrEmpty(LName) == false))
            {
               if ((isFNameValid == true) && (string.IsNullOrEmpty(FName) == false))
                {
                    if ((isMNameValid == true) && (string.IsNullOrEmpty(MName) == false))
                    {
                        if (SelectedTreatmentID > 0)
                        {
                            if (SelectedDentistID> 0)
                            {
                                if (string.IsNullOrEmpty(StartTime) == false)
                                {
                                    if (string.IsNullOrEmpty(AppDate) == false)
                                    {
                                        SqlConnection sqlcon = new SqlConnection(connString);
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
                                            this.Hide();
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }

                                        sqlcon.Close();

                                    } else { MessageBox.Show("Invalid Date"); }

                                } else { MessageBox.Show("Time Overlapse with other appointment"); }

                            } else { MessageBox.Show("Invalid Dentist"); }

                        } else { MessageBox.Show("Invalid Treatment"); }
                        
                    }else { MessageBox.Show("Invalid Middle Name"); }
            
                } else { MessageBox.Show("Invalid First Name"); }

            }else { MessageBox.Show("Invalid Last Name"); }

        }

        private void DP_date_onValueChanged(object sender, EventArgs e)
        {
            AppDate = DP_date.Value.ToString("MM/dd/yyyy hh:mm:ss tt");
            DateTime DateApp = DateTime.ParseExact(AppDate, "MM/dd/yyyy hh:mm:ss tt", System.Globalization.CultureInfo.CurrentCulture);
            DateTime CurrentDate = DateTime.Now;

            // check if Date is not less than current date
            if (DateApp > CurrentDate)
            {
                AppDate = DP_date.Value.ToString("MM/dd/yyyy");
            }
            else
            {
                AppDate = null;
            }
        
        }

        private void LoadDropDownList()
        {
            
            SqlDataAdapter adapter1 = new SqlDataAdapter();
            SqlDataAdapter adapter2 = new SqlDataAdapter();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            //  SqlDataReader dataReader;
            SqlConnection sqlcon = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(
                   "SELECT TreatmentType FROM Treatment ORDER BY TreatmentID ASC", sqlcon);
            SqlCommand cmd2 = new SqlCommand(
                  "SELECT CONCAT(DentistFName,' ',DentistMName, ' ', DentistLName) FROM Dentist ORDER BY DentistID ASC", sqlcon);
            SqlCommand cmd3 = new SqlCommand(
                  "SELECT AppointmentID FROM Appointment ORDER BY AppointmentID DESC",sqlcon);

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

               AppNo =  Convert.ToInt32(cmd3.ExecuteScalar()) + 1;
               txt_AppNo.Text = AppNo.ToString();
            
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            sqlcon.Close();
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
            String SelectedTime = TimeDD.selectedValue;
            try
            {
                DateTime timeStartA = DateTime.ParseExact(SelectedTime, "hh:mm tt", System.Globalization.CultureInfo.CurrentCulture);
                DateTime timeEndA = timeStartA.AddHours(1);
                String Addedtime = (timeEndA.ToString("hh:mm tt"));
            
                if (isValidTime(timeStartA, timeEndA) == false)
                {

                    if (CheckOverlapseTimeinDB(timeStartA, timeEndA) == false)
                    {
                        // Not time overlapse
                        StartTime = SelectedTime;
                        EndTime = Addedtime;
                        refTime = (timeStartA.ToString("HH:mm"));

                    } else { MessageBox.Show("Time Overlapse with other appointment"); }

                } else { MessageBox.Show("Invalid Time"); }
            
            }catch(Exception ex) { Console.WriteLine(ex.Message); }
         
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

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection sqlcon = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(
                   "SELECT StartTime,EndTime FROM Appointment", sqlcon);

            cmd.Parameters.Clear();
            adapter.SelectCommand = cmd;

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
