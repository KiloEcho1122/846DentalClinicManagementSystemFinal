using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace _846DentalClinicManagementSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

        }
        static String workingDirectory = Environment.CurrentDirectory;
        static String projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
        static String LocalDbSource = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=";
        static String LocalDBFile = projectDirectory + @"\846DentalClinicDB.mdf";
        static String connString = LocalDbSource + LocalDBFile + ";Integrated Security=True";
        SqlConnection sqlcon = new SqlConnection(connString);

        public static MainForm c1;
        public int AppointmentID =0,PatientID = 0;
        public String PatientName;


        public Boolean isEditAppointment { get; set; }
        public Boolean isAddAppointment { get; set; }
        public Boolean isEditPatient { get; set; }
        public Boolean isAddPatient { get; set; }

        private void HidePanels()
        {
            HomePanel.Visible = false;
            PatientsPanel.Visible = false;
            AccountingPanel.Visible = false;
            ReminderPanel.Visible = false;
            SchedulerPanel.Visible = false;
        }

        private void playVideo()
        {
            
            String videopath = projectDirectory + @"\Resources\846.mp4";
            this.axWindowsMediaPlayer1.uiMode = "none";
            this.axWindowsMediaPlayer1.settings.setMode("loop", true);
            this.axWindowsMediaPlayer1.Ctlenabled = false;
            this.axWindowsMediaPlayer1.URL = videopath;
            this.axWindowsMediaPlayer1.stretchToFit = true;
            this.axWindowsMediaPlayer1.Ctlcontrols.play();

            Console.WriteLine();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string date = DateTime.Today.ToString("M/d/yyyy");
            HidePanels();
            HomePanel.Visible = true;
            playVideo();
            ShowAppointment(date);
            PatientPanelSearch("");
            c1 = this;

        }


        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            HidePanels();
            HomePanel.Visible = true;
            
        }

        private void btn_Scheduler_Click(object sender, EventArgs e)
        {
            
            HidePanels();
            SchedulerPanel.Visible = true;
            
        }

        private void btn_Patients_Click(object sender, EventArgs e)
        {
            HidePanels();
            PatientsPanel.Visible = true;
        }

        private void btn_Accounting_Click(object sender, EventArgs e)
        {
            HidePanels();
            AccountingPanel.Visible = true;
        }

        private void btn_Reminder_Click(object sender, EventArgs e)
        {
            HidePanels();
            ReminderPanel.Visible = true;
        }

        private void btn_AddApp_Click(object sender, EventArgs e)
        {
            AddAppointment addAppointment = new AddAppointment();
            isAddAppointment = true;
            addAppointment.Show();
           
        }

        public void ShowAppointment(string date)
        {
            
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                   "SELECT	Appointment.AppointmentID AS No, "+
                   "CONCAT(Appointment_LName, ', ',Appointment_FName , ' ', Appointment_MName) AS Patient_Name, " +
                   "CONCAT(DentistFName, ' ', DentistMName, ' ', DentistLName) AS Dentist, "+
                   "TreatmentType AS Treatment, " +
                   "CONCAT(StartTime, ' - ', EndTime) AS Time, AppointmentDate AS Date," +
                   "Appointment.Status, Appointment.AppointmentNote AS Note " +
                   "FROM Appointment INNER JOIN[Dentist] ON DentistID_fk = DentistID "+
                   "INNER JOIN[Treatment] ON TreatmentID_fk = TreatmentID " +
                   "WHERE AppointmentDate = @date ORDER BY RefTime ASC", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@date", date);
           
            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);

                Appointment_DataGrid.DataSource = dt;


                Appointment_DataGrid.Columns[0].Width = 25;
                Appointment_DataGrid.Columns[1].Width = 165;
                Appointment_DataGrid.Columns[2].Width = 150;
                Appointment_DataGrid.Columns[3].Width = 150;
                Appointment_DataGrid.Columns[4].Width = 140;
                Appointment_DataGrid.Columns[5].Width = 70;
                Appointment_DataGrid.Columns[6].Width = 70;

            

            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }

            if (Appointment_DataGrid.Rows.Count > 0)
            {
                Appointment_DataGrid.Rows[0].Selected = true;
                ShowAppointmentDetail();
            }
            
        }

        private void SearchAppByDate_DP_onValueChanged(object sender, EventArgs e)
        {
            string date = SearchAppByDate_DP.Value.ToString("M/d/yyyy");
            ShowAppointment(date);
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            string date = monthCalendar1.SelectionRange.Start.ToString("M/d/yyyy");
            ShowAppointment(date);
        }

        private void Appointment_DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            ShowAppointmentDetail();
            AppointmentID = Convert.ToInt32(Appointment_DataGrid.SelectedRows[0].Cells[0].Value);

            
        }

        private void ShowAppointmentDetail()
        {
            if (Appointment_DataGrid.SelectedRows.Count > 0) // make sure user select at least 1 row 
            {
                string Patient = Appointment_DataGrid.SelectedRows[0].Cells[1].Value + string.Empty;
                string Dentist = Appointment_DataGrid.SelectedRows[0].Cells[2].Value + string.Empty;
                string Treatment = Appointment_DataGrid.SelectedRows[0].Cells[3].Value + string.Empty;
                string Time = Appointment_DataGrid.SelectedRows[0].Cells[4].Value + string.Empty;
                string Date = Appointment_DataGrid.SelectedRows[0].Cells[5].Value + string.Empty;
                string Status = Appointment_DataGrid.SelectedRows[0].Cells[6].Value + string.Empty;
                string Note = Appointment_DataGrid.SelectedRows[0].Cells[7].Value + string.Empty;



                DateTime dateTime = DateTime.ParseExact(Date, "M/d/yyyy hh:mm:ss tt", System.Globalization.CultureInfo.CurrentCulture);
                Date = dateTime.ToString("dddd, dd MMMM yyyy");

                lbl_Patient.Text = Patient;
                lbl_Dentist.Text = Dentist;
                lbl_treatment.Text = Treatment;
                lbl_Time.Text = Time;
                lbl_Status.Text = Status;
                lbl_Note.Text = Note;
                lbl_Date.Text = Date;
            }
         }
        

        private void btn_EditApp_Click(object sender, EventArgs e)
        {
           
            if (AppointmentID > 0)
            {
                AddAppointment addAppointment = new AddAppointment();
                isEditAppointment = true;
                addAppointment.Show();
               
            }
        }

        private void PatientsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_SearchPatient_OnTextChange(object sender, EventArgs e)
        {
            String search = txt_SearchPatient.text.Trim();
            PatientPanelSearch(search);
        }

        public void PatientPanelSearch(String search)
        {
            
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                "SELECT PatientID AS ID, CONCAT(PatientLName, ', ',PatientFName , ' ', PatientMName) AS Name , " +
                "PatientGender AS Gender, PatientAge AS Age, PatientBirthday AS Birthday,PatientAddress AS Address " +
                "FROM [Patient] WHERE PatientFullName LIKE @search ORDER BY PatientLName ASC", sqlcon);

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@search", "%" + search + "%");

            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);

                Patient_DataGrid.DataSource = dt;
                Patient_DataGrid.Columns[0].Width = 40;
                Patient_DataGrid.Columns[1].Width = 200;
                Patient_DataGrid.Columns[5].Width = 250;


            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void btn_PatientSearch_Click(object sender, EventArgs e)
        {
            String search = txt_SearchPatient.text.Trim();
            PatientPanelSearch(search);
        }

        private void Patient_DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           PatientID = Convert.ToInt32 (Patient_DataGrid.SelectedRows[0].Cells[0].Value);
        }

        private void btn_AddPatient_Click(object sender, EventArgs e)
        {
            AddEditPatientRecord addEditPatient = new AddEditPatientRecord();
            isAddPatient = true;
            addEditPatient.Show();
        }

        private void Patient_DataGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PatientID = Convert.ToInt32(Patient_DataGrid.SelectedRows[0].Cells[0].Value);
           PatientName = Patient_DataGrid.SelectedRows[0].Cells[1].Value.ToString();
            if (PatientID > 0)
            {
                ShowPatientInfo showPatientInfo = new ShowPatientInfo();
                showPatientInfo.Show();
            }
        }

        private void btn_EditPatient_Click(object sender, EventArgs e)
        {
            Console.WriteLine(PatientID);
            if (PatientID > 0)
            {
                AddEditPatientRecord addEditPatient = new AddEditPatientRecord();
                isEditPatient = true;
                addEditPatient.Show();

            }
        }
    }
}
