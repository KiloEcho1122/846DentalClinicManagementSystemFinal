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
    public partial class AddException : Form
    {
        SqlConnection sqlcon = new SqlConnection(GlobalVariable.connString);
        string StartTime, EndTime, refTime, AppDateException,Reason;
        int SelectedDentistID = 0, AppExNo = 0;
        List<int> DentistID = new List<int>();

        public AddException()
        {
            InitializeComponent();
            FillDropDown();
            DP_date.Value = DateTime.Now;
            
            

            if (GlobalVariable.isAddAppException == true && GlobalVariable.isEditAppException == false)
            {

                fillAppExceptionID();
                this.txt_formHeader.Text = "Add Exception ";
                StartTimeDD.selectedIndex = 0;
                EndTimeDD.selectedIndex = EndTimeDD.Items.Length - 1;


            }
            if (GlobalVariable.isEditAppException == true && GlobalVariable.isAddAppException == false)
            {
                AppExNo = GlobalVariable.AppExceptionID;
                this.txt_formHeader.Text = "Edit Exception ";
                btn_add.Text = "Update";
                fiillFormforUpdate();
                btn_cancelException.Visible = true;

            }
        }


        private void fiillFormforUpdate()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("SELECT * FROM AppointmentException WHERE AppExceptionID = @AppExNo",sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@AppExNo", AppExNo);
            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            string dateTime = DateTime.Parse(dt.Rows[0][1].ToString()).ToString("M/d/yyyy hh:mm:ss tt");
            DP_date.Value = DateTime.ParseExact(dateTime, "M/d/yyyy hh:mm:ss tt", System.Globalization.CultureInfo.CurrentCulture);
            String time1 = dt.Rows[0][2].ToString();
            String time2 = dt.Rows[0][3].ToString();
            for (int i = 0; i < StartTimeDD.Items.Length; i++)
            {
                if (StartTimeDD.Items[i] == time1)
                {
                    StartTimeDD.selectedIndex = i;

                }
                if (StartTimeDD.Items[i] == time2)
                {
                    EndTimeDD.selectedIndex = i;

                }

            }
            txt_Note.Text = dt.Rows[0][5].ToString();
            for (int i = 0; i < DentistID.Count; i++)
            {

                if (DentistID[i] == Convert.ToInt32(dt.Rows[0][6]))
                {
                    SelectedDentistID = i;
                }
            }
            DentistDD.selectedIndex = SelectedDentistID;

        }

        private void fillAppExceptionID()
        {
            SqlCommand cmd = new SqlCommand(
                 "SELECT AppExceptionID FROM AppointmentException ORDER BY AppExceptionID DESC", sqlcon);
            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                AppExNo = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "or dito");
            }
            sqlcon.Close();
        }

        private void FillDropDown()
        {
            SqlDataAdapter adapter1 = new SqlDataAdapter();
            DataTable dt1 = new DataTable();
            SqlCommand cmd1 = new SqlCommand(
                 "SELECT EmployeeId,CONCAT(FirstName, ' ', LastName) FROM Employee Where JobTitle = 'Dentist' ORDER BY EmployeeID ASC", sqlcon);
            adapter1.SelectCommand = cmd1;
            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                adapter1.Fill(dt1);
                foreach (DataRow row in dt1.Rows)
                {
                    DentistID.Add((int)row[0]);
                    this.DentistDD.AddItem(row[1].ToString());
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "dito ba yun");
            }
            sqlcon.Close();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
       
            Reason = txt_Note.Text.Trim();
            if (SelectedDentistID > 0)
            {

                if ((StartTimeDD.selectedIndex == EndTimeDD.selectedIndex) == false && (string.IsNullOrEmpty(StartTime) == false || string.IsNullOrEmpty(EndTime) == false)){
                    if (string.IsNullOrEmpty(AppDateException) == false)
                    {
                        AppDateException = DP_date.Value.ToString("M/d/yyyy");
                        var main = Application.OpenForms.OfType<MainForm>().First();
                        if (GlobalVariable.isAddAppException == true && GlobalVariable.isEditAppException == false)
                        {
                            InsertAppException();
                            GlobalVariable.isAddAppException = false;
                            if (main.SearchAppByDate_DP.Value == DP_date.Value)
                            {
                                main.RefreshAppointmentView();
                            }
                            else
                            {
                                main.SearchAppByDate_DP.Value = DP_date.Value;
                            }
                            GlobalVariable.InsertActivityLog("Added Appointment Exception, Appointment Exception ID = " + AppExNo, "Add");
                            this.Hide();


                        }
                        if (GlobalVariable.isEditAppException == true && GlobalVariable.isAddAppException == false)
                        {
                            UpdateAppException();
                            GlobalVariable.isEditAppException = false;
                            if (main.SearchAppByDate_DP.Value == DP_date.Value)
                            {
                                main.RefreshAppointmentView();
                            }
                            else
                            {
                                main.SearchAppByDate_DP.Value = DP_date.Value;
                            }
                            GlobalVariable.InsertActivityLog("Added Appointment, Appointment Exception ID = " + AppExNo, "Edit");
                            this.Hide();

                        }
                    }
                    else { MessageBox.Show("Invalid Date"); }

                
                 }
            else
            {
                MessageBox.Show("Invalid Time!");
            }
                }
            else {
                MessageBox.Show("Invalid Dentist!");
            }
        }

        private void InsertAppException()
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO [AppointmentException] (Date,StartTime,EndTime,RefTime,Reason,EmployeeID_fk) " +
                "VALUES(@Date,@StartTime,@EndTime,@RefTime,@Reason,@EmployeeID_fk)", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@date", AppDateException);
            cmd.Parameters.AddWithValue("@StartTime", StartTime);
            cmd.Parameters.AddWithValue("@EndTime", EndTime);
            cmd.Parameters.AddWithValue("@RefTime", refTime);
            cmd.Parameters.AddWithValue("@Reason", Reason);
            cmd.Parameters.AddWithValue("@EmployeeID_fk", SelectedDentistID);
            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Success!");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            sqlcon.Close();
        }

        private void UpdateAppException()
        {
            SqlCommand cmd = new SqlCommand("UPDATE [AppointmentException] SET Date = @Date,StartTime = @StartTime" +
                ",EndTime = @EndTime,RefTime = @RefTime,Reason = @Reason,EmployeeID_fk = @EmployeeID_fk WHERE AppExceptionID = @AppExceptionID" , sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@date", AppDateException);
            cmd.Parameters.AddWithValue("@StartTime", StartTime);
            cmd.Parameters.AddWithValue("@EndTime", EndTime);
            cmd.Parameters.AddWithValue("@RefTime", refTime);
            cmd.Parameters.AddWithValue("@Reason", Reason);
            cmd.Parameters.AddWithValue("@EmployeeID_fk", SelectedDentistID);
            cmd.Parameters.AddWithValue("@AppExceptionID", GlobalVariable.AppExceptionID);
            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Success!");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            sqlcon.Close();
        }


        private void EndTimeDD_onItemSelected(object sender, EventArgs e)
        {
            Checktime();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            GlobalVariable.isEditAppException = false;
            GlobalVariable.isAddAppException = false;
        }

        private void btn_cancelException_Click(object sender, EventArgs e)
        {
            var main = Application.OpenForms.OfType<MainForm>().First();
            DialogResult result = MessageBox.Show("Are you sure you want to cancel exception?"
                                   ,"Cancel Exception", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE [AppointmentException] SET Status='CANCELLED' Where AppExceptionID = @id",sqlcon);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id", AppExNo);
                    if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
     
                try
                    {
                        cmd.ExecuteNonQuery();
                        GlobalVariable.isEditAppException = false;
                        MessageBox.Show("Appointment Exception Cancelled Successfully");
                    if (main.SearchAppByDate_DP.Value == DP_date.Value)
                    {
                        main.RefreshAppointmentView();
                    }
                    else
                    {
                        main.SearchAppByDate_DP.Value = DP_date.Value;
                    }
                    this.Hide();

                }
                catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    sqlcon.Close();
                }
          //  main.Dispose();
            
    
        }

        private void StartTimeDD_onItemSelected(object sender, EventArgs e)
        {
            
            Checktime();
        }

        private void DentistDD_onItemSelected(object sender, EventArgs e)
        {
            SelectedDentistID = DentistID[DentistDD.selectedIndex];
        }

        private void DP_date_onValueChanged(object sender, EventArgs e)
        {
            //DateChecker2 = DP_date.Value.ToString("M/d/yyyy hh:mm:ss tt");
            Checktime();
           
        }


        private void Checktime()
        {
            if (StartTimeDD.selectedIndex > -1 && EndTimeDD.selectedIndex > -1)
            {
                try
                {

                    string SelectedStartTime = StartTimeDD.selectedValue;
                    string SelectedEndTime = EndTimeDD.selectedValue;

                    DateTime timeStartA = DateTime.ParseExact(SelectedStartTime, "hh:mm tt", System.Globalization.CultureInfo.CurrentCulture);
                    DateTime timeEndA = DateTime.ParseExact(SelectedEndTime, "hh:mm tt", System.Globalization.CultureInfo.CurrentCulture);
           



                    if (CheckOverlapseTimeinDB(timeStartA, timeEndA) == false)
                    {
                        StartTime = SelectedStartTime;
                        EndTime = SelectedEndTime;
                        refTime = (timeStartA.ToString("HH:mm"));

                        AppDateException = DP_date.Value.ToString("M/d/yyyy") + " " + StartTime;
                        DateTime DateApp = DateTime.ParseExact(AppDateException, "M/d/yyyy hh:mm tt", System.Globalization.CultureInfo.CurrentCulture);
                        DateTime CurrentDate = DateTime.Now;

                        //check if Date is not less than current date
                        if (DateApp > CurrentDate)
                        {
                            AppDateException = DP_date.Value.ToString("M/d/yyyy");
                        }
                        else
                        {
                            AppDateException = "";

                        }

                    }
                    else
                    {
                        MessageBox.Show("Time Overlapse with other appointment");
                        StartTime = "";
                        EndTime = "";
                    }
                }

                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }

        }

       

        private bool CheckOverlapseTimeinDB(DateTime timeStartA, DateTime timeEndA)
        {
            String date = DP_date.Value.ToString("M/d/yyyy");
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlDataAdapter adapter2 = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                   "SELECT StartTime,EndTime FROM Appointment WHERE EmployeeID_fk = @EmployeeID_fk AND " + "" +
                   "AppointmentDate =@date AND NOT Status ='CANCELLED' ", sqlcon);

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@EmployeeID_fk", SelectedDentistID);
            cmd.Parameters.AddWithValue("@date", date);
            adapter.SelectCommand = cmd;

            //AND NOT AppointmentID = @AppID
            try
            {
                adapter.Fill(dt);

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }


            SqlCommand cmd2 = new SqlCommand(
                  "SELECT StartTime,EndTime FROM AppointmentException WHERE EmployeeID_fk = @EmployeeID_fk AND " + "" +
                  "Date =@date AND NOT AppExceptionID = @AppExceptionID AND NOT Status ='CANCELLED'", sqlcon);
            cmd2.Parameters.Clear();
            cmd2.Parameters.AddWithValue("@EmployeeID_fk", SelectedDentistID);
            cmd2.Parameters.AddWithValue("@date", date);
            cmd2.Parameters.AddWithValue("@AppExceptionID", AppExNo);
            adapter.SelectCommand = cmd2;

            //Console.WriteLine(SelectedDentistID + "   " + date);
            //AND NOT AppointmentID = @AppID
            try
            {
                adapter.Fill(dt);
               
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }


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

            return false;
        }


        private static bool isOverlapDates(DateTime dtStartA, DateTime dtEndA, DateTime dtStartB, DateTime dtEndB)
        {
            return dtStartA < dtEndB && dtStartB < dtEndA;
        }


    }
}
