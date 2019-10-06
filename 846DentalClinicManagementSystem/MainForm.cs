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

        String connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mike\Documents\846DentalClinicManagementSystem\846DentalClinicManagementSystem\846DentalClinicDB.mdf;Integrated Security=True";
        public static MainForm c1;
       



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
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string videopath = projectDirectory + @"\Resources\846.mp4";
            this.axWindowsMediaPlayer1.uiMode = "none";
            this.axWindowsMediaPlayer1.settings.setMode("loop", true);
            this.axWindowsMediaPlayer1.Ctlenabled = false;
            this.axWindowsMediaPlayer1.URL = videopath;
            this.axWindowsMediaPlayer1.stretchToFit = true;
            this.axWindowsMediaPlayer1.Ctlcontrols.play();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            HidePanels();
            HomePanel.Visible = true;
            playVideo();
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
            DateTime asa = DateTime.Today;
            string date = asa.ToString("M/d/yyyy");
            ShowAppointment(date);
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
            addAppointment.Show();

        }

        public void ShowAppointment(string date)
        {
            
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection sqlcon = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(
                   "SELECT	Appointment.AppointmentID AS No, "+
                   "CONCAT(Appointment_FName, ' ', Appointment_MName, ' ', Appointment_LName) AS Patient_Name, " +
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



                //int totalwidth = 0;

                ////  MessageBox.Show(Appointment_DataGrid.ColumnCount.ToString());


                //for (int i = 0; i < Appointment_DataGrid.ColumnCount - 2; i++)
                //{
                //    Appointment_DataGrid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                //}

                //if (Appointment_DataGrid.Columns[7].Width > 100)
                //{
                //    Appointment_DataGrid.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //}

                //foreach (DataGridViewColumn column in Appointment_DataGrid.Columns)
                //{
                //    totalwidth += column.Width;
                //   // MessageBox.Show("sasasas"   +column.Width.ToString());
                //}
                //MessageBox.Show(totalwidth.ToString());
                //if (totalwidth < Appointment_DataGrid.Width)
                //{


                //int diff = Appointment_DataGrid.Width - totalwidth;
                // Appointment_DataGrid.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //   MessageBox.Show(totalwidth.ToString());

                //}
                //else
                //{
                foreach (DataGridViewColumn column in Appointment_DataGrid.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                //}

            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
        
           
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
    }
}
