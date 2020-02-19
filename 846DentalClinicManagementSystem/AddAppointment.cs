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
    public partial class AddAppointment : Form
    {
        
        //static String workingDirectory = Environment.CurrentDirectory;
        //static String projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
        //static String LocalDbSource = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=";
        //static String LocalDBFile = projectDirectory + @"\846DentalClinicDB.mdf";
        //static String connString = LocalDbSource + LocalDBFile + ";Integrated Security=True";
        SqlConnection sqlcon = new SqlConnection(GlobalVariable.connString);
       

        int SelectedDentistID = 0, AppNo = 0;
        string LName, MName, FName, StartTime, EndTime, refTime, AppDate,Note = "",AppStatus ="",contactNo;
        string DateChecker1,DateChecker2;
        ArrayList RemovedTreatment = new ArrayList();

        public AddAppointment()
        {
            InitializeComponent();
        }

        private void AddAppointment_Load(object sender, EventArgs e)
        {
            LoadDropDownList();
            DP_date.Value = DateTime.Now;
           

            // if add appointmen increment ID

            if (GlobalVariable.isAddAppointment == true && GlobalVariable.isEditAppointment == false)
            {
                fillAppID();
                btn_CreateBilling.Visible = false;
                bunifuCustomLabel5.Visible = false;
                statusSwitch.Visible = false;
                this.Text = "Add Appointment";

            }
            if (GlobalVariable.isEditAppointment == true && GlobalVariable.isAddAppointment ==false)
            {
                AppNo = GlobalVariable.AppointmentID;
                fillFormforUpdate();
                FormatEditForm();
               
              
            }

            lbl_AppNo.Text = "Appointment No. " + AppNo.ToString();
        }
        private void FormatEditForm()
        {
            this.Height = 464;
            // //labels
            lbl_AppNo.Left = 38;
            bunifuCustomLabel8.Top = 130;
            bunifuCustomLabel9.Top = 130;
            bunifuCustomLabel10.Top = 130;
            bunifuCustomLabel2.Top = 130;
            bunifuCustomLabel3.Top = 211;
            bunifuCustomLabel4.Top = 211;
            bunifuCustomLabel6.Top = 211;
            bunifuCustomLabel7.Top = 305;
            lblContact.Top = 305;
            bunifuCustomLabel5.Top = 423;
            //textboxes and dropdown

            txt_LName.Top = 153;
            txt_FName.Top = 153;
            txt_MName.Top = 153;
            TreatmentDropDownPanel.Top = 153;
          

            
            btn_RemoveItem.Top = 295;

            TreatmentList.Top = 231;
            DentistDD.Top = 231;
            DP_date.Top = 231;
            TimeDD.Top = 231;
            txt_Note.Top = 336;
            txt_ContactNo.Top = 336;
            // //buttons
            btn_CreateBilling.Top = 413;
            btn_close.Top = 413;
            btn_add.Top = 413;
            statusSwitch.Top = 419;



            txt_PatientSearch.Visible = false;
            btn_PatientSearch.Visible = false;
            AppSearch_DataGrid.Visible = false;
            bunifuCustomLabel1.Visible = false;
            btn_CreateBilling.Visible = true;
            btn_add.Text = "Update";
            txt_formHeader.Text = "Update Appointment";
            this.Text = "Update Appointment";

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Hide();
            GlobalVariable.isEditAppointment = false;
            GlobalVariable.isAddAppointment = false;
           // var main = Application.OpenForms.OfType<MainForm>().First();
            ////  main.ShowAppointment(DP_date.Value.ToShortDateString());
            //  main.SearchAppByDate_DP.Value = DP_date.Value;
          
        }

        private void btn_add_Click(object sender, EventArgs e)
        {

            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

            LName = myTI.ToTitleCase(txt_LName.Text.Trim());
            FName = myTI.ToTitleCase(txt_FName.Text.Trim());
            MName = myTI.ToTitleCase(txt_MName.Text.Trim());
            Note = txt_Note.Text.Trim();
            contactNo = txt_ContactNo.Text.Trim();


            bool isLNameValid = Regex.IsMatch(LName, @"^[a-zA-Z\x20]*?$");
            bool isFNameValid = Regex.IsMatch(FName, @"^[a-zA-Z\x20]*?$");
            bool isMNameValid = Regex.IsMatch(MName, @"^[a-zA-Z\x20]*?$");
            bool isContactValid = Regex.IsMatch(contactNo, @"^[0-9]+$");

            if ((isLNameValid == true) && (string.IsNullOrEmpty(LName) == false))
            {
                if ((isFNameValid == true) && (string.IsNullOrEmpty(FName) == false))
                {
                    if (isMNameValid == true)
                    {
                        if (TreatmentList.Items.Count > 0)
                        {

                            if (SelectedDentistID > 0)
                            {


                                if (string.IsNullOrEmpty(StartTime) == false)
                                {
                                  

                                    if (string.IsNullOrEmpty(AppDate) == false || DateChecker1 == DateChecker2)
                                    {
                                        AppDate = DP_date.Value.ToString("M/d/yyyy");

                                        if ((string.IsNullOrEmpty(contactNo) == false) && isContactValid && contactNo.Length == 11)
                                        {
                                            var main = Application.OpenForms.OfType<MainForm>().First();
                                            if (GlobalVariable.isAddAppointment == true && GlobalVariable.isEditAppointment == false)
                                            {
                                                insertAppointmentToDB();
                                                GlobalVariable.isAddAppointment = false;
                                                main.SearchAppByDate_DP.Value = DP_date.Value;
                                                this.Hide();

                                               
                                            }
                                            if (GlobalVariable.isEditAppointment == true && GlobalVariable.isAddAppointment == false)
                                            {
                                                updateAppointmentToDB();
                                                GlobalVariable.isEditAppointment = false;
                                                main.SearchAppByDate_DP.Value = DP_date.Value;
                                                this.Hide();

                                            }
                                        }
                                        else { MessageBox.Show("Invalid Contact Number"); }

                                    }
                                    else { MessageBox.Show("Invalid Date"); }

                                }
                                else { MessageBox.Show("Invalid Time"); }

                            }
                            else { MessageBox.Show("Invalid Dentist"); }

                        }
                        else { MessageBox.Show("Invalid Treatment"); }


                    } else { MessageBox.Show("Invalid Middle Name"); }

                } else { MessageBox.Show("Invalid First Name"); }

            } else { MessageBox.Show("Invalid Last Name"); }


        }
        //------------------------------------------------------------------------------------------------------------------------------------

       
        private bool checkExistingAppointmentTreatment(object items)
        {
            bool doesExist = true;
            SqlCommand cmd = new SqlCommand(
                "SELECT AppointmentID_fk FROM AppointmentTreatment WHERE AppointmentID_fk = @appID " +
                            "AND TreatmentType = @TreatmentType ", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@appID", AppNo);
            cmd.Parameters.AddWithValue("@TreatmentType", items.ToString());

            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }

            try
            {
                //object obj = .ToString();
                if (cmd.ExecuteScalar() == null)
                {
                    doesExist = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           sqlcon.Close();

            return doesExist;
        }

        private void InsertAppointmentTreatmentDB(object items)
        {
            SqlCommand cmd = new SqlCommand(
               "Insert Into [AppointmentTreatment] (AppointmentID_fk,TreatmentType) " +
               "Values(@AppID,@TreatmentType) ", sqlcon);
            cmd.Parameters.Clear();
            
            cmd.Parameters.AddWithValue("@AppID", AppNo);
            cmd.Parameters.AddWithValue("@TreatmentType", items.ToString());

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
        }


        //-----------------------------------------------------------------------------------------------------------------------------

        //PatientTreatmentDB - contains concatenation of AppointmentTreatment with and without prices
        private void PatientTreatmentDB()
        {
            // if wala pa sa datbase, insert new
            if (ExistingPatientTreatment() == false)
            {
                InsertPatientTreatmentDB();
            }
            else // else iupdate nalang
            {
               
                UpdatePatientTreatmentDB();
                
            }
        }

        private bool ExistingPatientTreatment()
        {
            bool doesExist = true;
            SqlCommand cmd = new SqlCommand(
                "SELECT AppointmentID_fk FROM PatientTreatment WHERE AppointmentID_fk = @appID ", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@appID", AppNo);

            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
               
            try
            {
                //object obj = .ToString();
                if (cmd.ExecuteScalar() == null)
                {
                    doesExist = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            sqlcon.Close();

            return doesExist;
        }

        private string GetAppointmentTreatmentString()
        {
            string treatment = "";
            
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                "SELECT TreatmentType FROM AppointmentTreatment WHERE AppointmentID_fk = @appNo", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@appNo", AppNo);
            adapter.SelectCommand = cmd;
            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                adapter.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    treatment += row[0].ToString() + ",";
                }
               
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            sqlcon.Close();
           
            return treatment.Remove(treatment.Length-1);
        }

        private void InsertPatientTreatmentDB()
        {
            string treatment = GetAppointmentTreatmentString().ToString();
            SqlCommand cmd = new SqlCommand(
               "Insert Into [PatientTreatment] (AppointmentID_fk,Treatment) " +
               "Values(@AppID,@treatment) ", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@AppID", AppNo);
            cmd.Parameters.AddWithValue("@treatment", treatment);

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
        }

        private void UpdatePatientTreatmentDB()
        {
            string treatment = GetAppointmentTreatmentString();
            SqlCommand cmd = new SqlCommand(
               "UPDATE [PatientTreatment] SET Treatment = @treatment " +
               "WHERE AppointmentID_fk = @appNo ", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@treatment", treatment);
            cmd.Parameters.AddWithValue("@appNo", AppNo);

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
        }


        //------------------------------------------------------------------------------------------------------------------------

        private void fillFormforUpdate()
        {
            string[] treatment = { };
            DataTable dt1 = new DataTable();
            SqlDataAdapter adapter1 = new SqlDataAdapter();
            SqlCommand cmd1= new SqlCommand("SELECT * From Appointment WHERE AppointmentID = @AppointmentID", sqlcon);
            cmd1.Parameters.Clear();
            cmd1.Parameters.AddWithValue("@AppointmentID", AppNo);
            adapter1.SelectCommand = cmd1;
            SqlCommand cmd2 = new SqlCommand("SELECT Treatment From PatientTreatment WHERE AppointmentID_fk = @AppointmentID", sqlcon);
            cmd2.Parameters.Clear();
            cmd2.Parameters.AddWithValue("@AppointmentID", AppNo);

            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }

            try
            {
                adapter1.Fill(dt1);
                treatment = Regex.Split(cmd2.ExecuteScalar().ToString(), "[,]");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            sqlcon.Close();


            foreach(string str in treatment)
            {
                
                TreatmentList.Items.Add(str.Trim());
            }

            String itemTime = dt1.Rows[0][6].ToString();
            txt_LName.Text = dt1.Rows[0][1].ToString();
            txt_FName.Text = dt1.Rows[0][2].ToString();
            txt_MName.Text = dt1.Rows[0][3].ToString();
            txt_ContactNo.Text = dt1.Rows[0][4].ToString();
            txt_Note.Text = dt1.Rows[0][10].ToString();

            if(dt1.Rows[0][11].ToString() == "COMPLETED") { statusSwitch.Value = true; }
           
         //   SelectedTreatmentID = Convert.ToInt32(dt.Rows[0][8]) - 1;



            for(int i = 0; i < DentistDD.Items.Length; i++)
            {
                if (DentistID[i] == Convert.ToInt32(dt1.Rows[0][11])) 
                {
                    SelectedDentistID = i;
                }
            }
            DentistDD.selectedIndex = SelectedDentistID;

            //   if (SelectedTreatmentID == -1) { SelectedTreatmentID = 0; }

            //  TreatmentDD.selectedIndex = SelectedTreatmentID;

            string dateTime = DateTime.Parse(dt1.Rows[0][5].ToString()).ToString("M/d/yyyy hh:mm:ss tt");
            DateChecker1 = dateTime;
            DP_date.Value = DateTime.ParseExact(dateTime, "M/d/yyyy hh:mm:ss tt", System.Globalization.CultureInfo.CurrentCulture);

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
                "UPDATE [Appointment] SET Appointment_LName = @LName, Appointment_FName = @FName, Appointment_MName = @MName, Appointment_Contact = @contact," +
                "AppointmentDate = @Date, StartTime = @StartTime, EndTime = @EndTime ,RefTime = @RefTime, EmployeeID_fk = @EmployeeID_fk ," +
                "AppointmentNote = @Note WHERE AppointmentID = @AppointmentID ", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@LName", LName);
            cmd.Parameters.AddWithValue("@FName", FName);
            cmd.Parameters.AddWithValue("@MName", MName);
            cmd.Parameters.AddWithValue("@contact", contactNo);
            cmd.Parameters.AddWithValue("@Date", AppDate);
            cmd.Parameters.AddWithValue("@StartTime", StartTime);
            cmd.Parameters.AddWithValue("@EndTime", EndTime);
            cmd.Parameters.AddWithValue("@RefTime", refTime);
            cmd.Parameters.AddWithValue("@EmployeeID_fk", SelectedDentistID);
            cmd.Parameters.AddWithValue("@Note", Note);
            cmd.Parameters.AddWithValue("@AppointmentID", AppNo);


            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                cmd.ExecuteNonQuery();
                foreach (var items in TreatmentList.Items)
                {
                    if (checkExistingAppointmentTreatment(items) == false)
                    {
                        InsertAppointmentTreatmentDB(items);
                    }

                }
                RemoveTreatmentFromDB();
                PatientTreatmentDB();
                MessageBox.Show("Appointment updated successfully");
              
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
                "Insert Into [Appointment] (Appointment_LName,Appointment_FName,Appointment_MName,Appointment_Contact,AppointmentDate,StartTime,EndTime,RefTime,EmployeeID_fk,AppointmentNote) " +
                "Values(@LName,@FName,@MName,@Contact,@Date,@StartTime,@EndTime,@RefTime,@EmployeeID_fk,@Note) ", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@LName", LName);
            cmd.Parameters.AddWithValue("@FName", FName);
            cmd.Parameters.AddWithValue("@MName", MName);
            cmd.Parameters.AddWithValue("@Contact", contactNo);
            cmd.Parameters.AddWithValue("@Date", AppDate);
            cmd.Parameters.AddWithValue("@StartTime", StartTime);
            cmd.Parameters.AddWithValue("@EndTime", EndTime);
            cmd.Parameters.AddWithValue("@RefTime", refTime);
            cmd.Parameters.AddWithValue("@EmployeeID_fk", SelectedDentistID);
            cmd.Parameters.AddWithValue("@Note", Note);

            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                cmd.ExecuteNonQuery();
                foreach (var items in TreatmentList.Items)
                {
                    if (checkExistingAppointmentTreatment(items) == false)
                    {
                        InsertAppointmentTreatmentDB(items);
                    }
                    
                }
                PatientTreatmentDB();
                MessageBox.Show("Appointment added successfully");
             
                this.Hide();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            sqlcon.Close();
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
            AppSearch_DataGrid.Visible = true;
        }


        List<int> DentistID = new List<int>();

        private void LoadDropDownList()
        {
            SqlDataAdapter adapter1 = new SqlDataAdapter();
            SqlDataAdapter adapter2 = new SqlDataAdapter();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            SqlCommand cmd = new SqlCommand(
                   "SELECT TreatmentType FROM Treatment ORDER BY TreatmentID ASC", sqlcon);
            SqlCommand cmd2 = new SqlCommand(
                  "SELECT EmployeeId,CONCAT(FirstName, ' ', LastName) FROM Employee Where JobTitle = 'Dentist' ORDER BY EmployeeID ASC", sqlcon);
            SqlCommand cmd3 = new SqlCommand(
                  "SELECT AppointmentID FROM Appointment ORDER BY AppointmentID DESC", sqlcon);

            adapter1.SelectCommand = cmd;
            adapter2.SelectCommand = cmd2;
            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                adapter1.Fill(dt1);
               foreach(DataRow row in dt1.Rows)
                {
                    //    this.TreatmentDD.AddItem(dt1.Rows[i][0].ToString());
                    Treatment_CB.Items.Add(row[0]);
                }

                adapter2.Fill(dt2);

                foreach (DataRow row in dt2.Rows)
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

        private void DP_date_onValueChanged(object sender, EventArgs e)
        {
            DateChecker2 = DP_date.Value.ToString("M/d/yyyy hh:mm:ss tt");
            Checktime();
        }

        private void fillAppID()
        {
            SqlCommand cmd = new SqlCommand(
                 "SELECT AppointmentID FROM Appointment ORDER BY AppointmentID DESC", sqlcon);
            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                AppNo = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + "or dito");
            }
            sqlcon.Close();
        }


        private void txt_PatientSearch_Leave(object sender, EventArgs e)
        {
           // AppSearch_DataGrid.Visible = false;
        }

        private void Treatment_CB_KeyDown(object sender, KeyEventArgs e)
        {
            Treatment_CB.DroppedDown = false;
        }

        private void Treatment_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TreatmentList.Items.Contains(Treatment_CB.SelectedItem) == false)
            {
                TreatmentList.Items.Add(Treatment_CB.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("Treatment is already selected !");
            }
        }

        private void RemoveTreatmentFromDB()
        {
            //Remove each treatment in the RemovedTreatment List
            if (RemovedTreatment.Count > 0)
            {
                foreach (string item in RemovedTreatment)
                {
                    SqlCommand cmd = new SqlCommand(
                                "DELETE From AppointmentTreatment Where AppointmentID_fk = @appID " +
                                "AND TreatmentType = @TreatmentType ", sqlcon);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@appID", AppNo);
                    cmd.Parameters.AddWithValue("@TreatmentType", item);
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
                }

                RemovedTreatment.Clear();
                PatientTreatmentDB();
            }
           

        }

        private void btn_RemoveItem_Click(object sender, EventArgs e)
        {
            if (TreatmentList.SelectedIndex > -1) 
            {
                if (GlobalVariable.isEditAppointment == true && GlobalVariable.isAddAppointment == false)
                {
                    DialogResult result = MessageBox.Show("Remove " + TreatmentList.SelectedItem + " ?","Remove Treatment",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if(result == DialogResult.Yes)
                    {

                        RemovedTreatment.Add(TreatmentList.SelectedItem);
                        
                    }
                }
               
                //Remove item anyway
                    TreatmentList.Items.RemoveAt(TreatmentList.SelectedIndex);
             
            }
        }

        private void AppSearch_DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (AppSearch_DataGrid.SelectedRows.Count > 0) // make sure user select at least 1 row 
            //{
            //    string ID = AppSearch_DataGrid.SelectedRows[0].Cells[0].Value + string.Empty;

            //    SqlDataAdapter adapter = new SqlDataAdapter();
            //    DataTable dt = new DataTable();
            //    SqlCommand cmd = new SqlCommand("SELECT * FROM Patient WHERE PatientID = @ID", sqlcon);
            //    cmd.Parameters.Clear();
            //    cmd.Parameters.AddWithValue("@ID", ID);
            //    adapter.SelectCommand = cmd;

            //    try
            //    {
            //        adapter.Fill(dt);
            //        txt_LName.Text = dt.Rows[0][1].ToString();
            //        txt_FName.Text = dt.Rows[0][2].ToString();
            //        txt_MName.Text = dt.Rows[0][3].ToString();
            //        txt_ContactNo.Text = dt.Rows[0][4].ToString();

            //    }
            //    catch (Exception ex) { Console.WriteLine(ex.Message); }


            //}
        }

        

        private void DentistDD_onItemSelected(object sender, EventArgs e)
        {

            SelectedDentistID = DentistID[DentistDD.selectedIndex];
   
        }

        private void AppointmentDatePick()
        {

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

        private void AppSearch_DataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (AppSearch_DataGrid.SelectedRows.Count > 0) // make sure user select at least 1 row 
                {
                    string ID = AppSearch_DataGrid.SelectedRows[0].Cells[0].Value + string.Empty;

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Patient WHERE PatientID = @ID", sqlcon);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ID", ID);
                    adapter.SelectCommand = cmd;

                    try
                    {
                        adapter.Fill(dt);
                        txt_LName.Text = dt.Rows[0][1].ToString();
                        txt_FName.Text = dt.Rows[0][2].ToString();
                        txt_MName.Text = dt.Rows[0][3].ToString();
                        txt_ContactNo.Text = dt.Rows[0][4].ToString();

                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void txt_LName_TextChanged(object sender, EventArgs e)
        {
            AppSearch_DataGrid.Visible = false;
        }

        private void statusSwitch_Click(object sender, EventArgs e)
        {
            
            if (CheckIfPatientAlreadyinPatientDB() > 0)  // there is already an existing record in PatientDB
            {
               
                if (statusSwitch.Value == true)
                {
                    AppStatus = "COMPLETED";
                    changeStatus();
                    updatePatientTreatment_PatientID();
                    MessageBox.Show("Appointment Status changed to COMPLETE !");
                }
                else
                {
                    AppStatus = "PENDING";
                    changeStatus();
                    MessageBox.Show("Appointment Status changed to PENDING !");
                }
            }
            else
            {
               DialogResult result =  MessageBox.Show("This Patient doesnt have record yet,\r\n Please complete Patient Information !"
                    , "Patient Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    AddEditPatientRecord addEditPatientRecord = new AddEditPatientRecord();
                    GlobalVariable.isAddPatient = true;
                    GlobalVariable.isAppointmentPatientExist = true;
                    addEditPatientRecord.Show();
                    statusSwitch.Value = false;
                }

            }
            var main = Application.OpenForms.OfType<MainForm>().First();
            main.ChangeStatusIcon(statusSwitch.Value);

        }


        private void changeStatus()
        {
            SqlCommand cmd = new SqlCommand(
               "UPDATE [Appointment] SET Status = @Status WHERE AppointmentID = @AppointmentID ", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@AppointmentID", AppNo);
            cmd.Parameters.AddWithValue("@Status", AppStatus);

            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            sqlcon.Close();
        }

      

    

        private void updatePatientTreatment_PatientID()
        {
            SqlCommand cmd = new SqlCommand(
              "UPDATE [PatientTreatment] SET PatientID_fk = @PatientID WHERE AppointmentID_fk = @AppointmentID ", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@AppointmentID", AppNo);
            cmd.Parameters.AddWithValue("@PatientID", GlobalVariable.PatientID);

            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            sqlcon.Close();
        }

        private void TimeDD_onItemSelected(object sender, EventArgs e)
        {

            Checktime();

        }

        private void Checktime()
        {
            if (TimeDD.selectedIndex > -1)
            {
                try
                {

                    String SelectedTime = TimeDD.selectedValue;

                    DateTime timeStartA = DateTime.ParseExact(SelectedTime, "hh:mm tt", System.Globalization.CultureInfo.CurrentCulture);
                    DateTime timeEndA = timeStartA.AddHours(1);
                    String Addedtime = (timeEndA.ToString("hh:mm tt"));



                    if (CheckOverlapseTimeinDB(timeStartA, timeEndA) == false)
                    {
                        StartTime = SelectedTime;
                        EndTime = Addedtime;
                        refTime = (timeStartA.ToString("HH:mm"));

                        AppDate = DP_date.Value.ToString("M/d/yyyy") + " " + StartTime;
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
                    else
                    {
                        MessageBox.Show("Time Overlapse with other appointment");
                        StartTime = "";
                    }
                }

                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
     
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
                   "SELECT StartTime,EndTime FROM Appointment WHERE EmployeeID_fk = @EmployeeID_fk AND " + "" +
                   "AppointmentDate =@date AND NOT AppointmentID = @AppID", sqlcon);

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@EmployeeID_fk", SelectedDentistID);
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



        private void btn_CreateBilling_Click(object sender, EventArgs e)
        {
            //check if the name already exist in the patient database
            // if exist { proceed to payment }
            //          { change pending status to complete}

            // if not   { complete patient info }
            //          { proceed to payment }
            //          { change pending status to complete}


            if (GlobalVariable.AppointmentID > 0)
            {
                if (CheckIfPatientAlreadyinPatientDB() > 0)  // there is already an existing record in PatientDB
                {
                   
                    //  GlobalVariable.TreatmentID = SelectedTreatmentID;
                   
                    if (CheckifBillingStatementAlreadyExist())
                    {
                        MessageBox.Show("Billing Statement already Exist !", "Billing Statement"
                            , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        GlobalVariable.isBillingStatementExist = true;
                    }

                    AddBilling addBilling = new AddBilling();
                    addBilling.ShowDialog();

                }                                           
                else
                {
                    MessageBox.Show("This Patient doesnt have record yet,\r\n Please complete Patient Information !" 
                        ,"Patient Record",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    AddEditPatientRecord addEditPatientRecord = new AddEditPatientRecord();
                    GlobalVariable.isAddPatient = true;
                    GlobalVariable.isAppointmentPatientExist = true;
                    addEditPatientRecord.Show();

                }
            }
        }

        

    private int CheckIfPatientAlreadyinPatientDB()
        {
            int PatientExist = 0;

            SqlCommand cmd = new SqlCommand(
                "SELECT p.PatientID FROM Patient p JOIN Appointment a " +
            "ON p.PatientFName = a.Appointment_FName AND " +
            "p.PatientMName = a.Appointment_MName AND " +
            "p.PatientLName = a.Appointment_LName " +
            "WHERE a.AppointmentID = @AppID", sqlcon);

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@AppId", AppNo);
            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {   
                object fetch = cmd.ExecuteScalar();
                if (fetch != null)
                {
                    PatientExist = (int)(fetch);
                }
               
                
            }
            catch (Exception ex) { Console.WriteLine(ex.Message + "No records found, create patient record"); }
            sqlcon.Close();

            GlobalVariable.PatientID = PatientExist;
            return PatientExist; // return the patientID if existing, return 0 if not
        }


        private bool CheckifBillingStatementAlreadyExist()
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT AmountPay FROM Billing WHERE AppointmentID_fk = @appNo",sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@appNo", AppNo);
            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
               if (cmd.ExecuteScalar() == null) { return false; }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            sqlcon.Close();
            return true;
        }
    }

}
