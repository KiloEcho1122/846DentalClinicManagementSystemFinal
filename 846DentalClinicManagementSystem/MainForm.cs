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
using System.Text.RegularExpressions;

namespace _846DentalClinicManagementSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            

        }
        
        //static String LocalDbSource = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=";
        //static String LocalDBFile = projectDirectory + @"\846DentalClinicDB.mdf";
        //static String connString = LocalDbSource + LocalDBFile + ";Integrated Security=True";
        SqlConnection sqlcon = new SqlConnection(GlobalVariable.connString);
        List<Panel> Panels = new List<Panel>();
        string[,] timeArray = new string[19,2];



        //public static MainForm c1;
        //public int AppointmentID =0,PatientID = 0;
        //public String PatientName;


        //public Boolean isEditAppointment { get; set; }
        //public Boolean isAddAppointment { get; set; }
        //public Boolean isEditPatient { get; set; }
        //public Boolean isAddPatient { get; set; }
        //public Boolean isAppointmentPatientExist { get; set; }

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
         
            String workingDirectory = Environment.CurrentDirectory;
            String projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
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
            HidePanels();
            HomePanel.Visible = true;
            playVideo();
            iniatializeTimeArray();
            setTimelabel();
            DrawAppointmentTable();
            
            SearchAppByDate_DP.Value = DateTime.Now;
            PatientPanelSearch("");
            //c1 = this;
            setAutoScrollfalse();
        }

        //Main Panel Start

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

        // Main Panel End -----------------------------------------------------------------------------------------------------------

        //Scheduler Panel Start  ----------------------------------------------------------------------------------------------------

        private void iniatializeTimeArray()
        {
            DateTime time2 = new DateTime(2019, 10, 29, 9, 0, 0);
            int loc = 61;
            for (int i = 0; i < 19; i++)
            {
                timeArray[i, 0] = time2.ToString("hh:mm tt");
                timeArray[i, 1] = loc.ToString();
                time2 = time2.AddMinutes(30);
                loc += 50;
            }
        }

        public void ShowAppointment(string date)
        {
            string query;
            string date2 = "";
            int ControlsCount = 0;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd;

            if (WeekSwitch.Value == false)
            {
                query = "SELECT	Appointment.AppointmentID AS No, " +
                   "CONCAT(Appointment_LName, ', ',Appointment_FName , ' ', Appointment_MName) AS Patient_Name, " +
                   "DentistID_fk,Treatment," +
                   "Appointment.Status, StartTime, AppointmentDate,Appointment_Contact FROM Appointment INNER JOIN[PatientTreatment] ON AppointmentID = AppointmentID_fk " +
                   "WHERE AppointmentDate = @date ORDER BY RefTime ASC";


                cmd = new SqlCommand(query, sqlcon);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@date", date);

                ControlsCount = 3;

            }
            else
            {
                DateTime betweenDate = DateTime.ParseExact(date, "M/d/yyyy", System.Globalization.CultureInfo.CurrentCulture);
                int b = (int)betweenDate.DayOfWeek;
                if (b != 0)
                {
                    betweenDate = betweenDate.AddDays(-(b));
                    date = betweenDate.ToShortDateString();
                }
                betweenDate = betweenDate.AddDays(6);
                date2 = betweenDate.ToShortDateString();

                query = "SELECT	Appointment.AppointmentID AS No, " +
                   "CONCAT(Appointment_LName, ', ',Appointment_FName , ' ', Appointment_MName) AS Patient_Name, " +
                   "DentistID_fk,Treatment," +
                   "Appointment.Status, StartTime, AppointmentDate,Appointment_Contact FROM Appointment INNER JOIN[PatientTreatment] ON AppointmentID = AppointmentID_fk " +
                   "WHERE AppointmentDate BETWEEN @date AND @date2 ORDER BY AppointmentDate ASC";

               
                cmd  = new SqlCommand(query, sqlcon);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@date2", date2);

                ControlsCount = 8;
            }
            
            
           
            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);
                //check if data table contains row
                if (dt.Rows.Count > 0)
                {
                    //replace comma "," with line break
                    dt.Rows[0][3] = dt.Rows[0][3].ToString().Replace(",", Environment.NewLine);
                }

                while (this.Appointment_Panel.Controls.Count != ControlsCount)
                {
                    this.Appointment_Panel.Controls.RemoveAt(ControlsCount);
                    Panels.Clear();
                }


                foreach (DataRow row in dt.Rows)
                {
                    string id = row[0].ToString();
                    string name = row[1].ToString();
                    string treatment = row[3].ToString();
                    int dentist_id = (int)(row[2]);
                    string status = row[4].ToString();
                    string time = row[5].ToString();
                    string appdate = row[6].ToString();
                    string contact = row[7].ToString();

                    DrawAppointments(id, name, treatment, dentist_id, status, time, appdate,contact);
                }

                DrawLines();

            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }

        }

        

        private int appointmentYlocation(string time)
        {
            int y = 0;

            for (int i = 0; i < 19; i++)
            {
                if (timeArray[i, 0] == time) {
                    Int32.TryParse(timeArray[i, 1], out y);
                    return y;
                }
            }

            return y;
        }

        private int appointmentXlocation(string date, int dentID)
        {
            int loc = 0;

           DateTime StartDate =  DateTime.ParseExact(date, "M/d/yyyy hh:mm:ss tt", System.Globalization.CultureInfo.CurrentCulture);
           int b = (int)StartDate.DayOfWeek;


            switch (b)
            {
                case 0: loc = 11;
                    break;
                case 1:  loc = 311;
                    break;
                case 2: loc = 611;
                    break;
                case 3:  loc = 911;
                    break;
                case 4: loc = 1211;
                    break; 
                case 5:  loc = 1511;
                    break;
                case 6:  loc = 1811;
                    break;
            }
            if (dentID == 2)
            {
                loc += 150;   
            }

            return loc;
        }

        bool isWeek = false;
   

        private void DrawAppointments(string id, string name, string treatment, int dentID, string status, string time, string date,string contact)
        {
            treatment = treatment.Replace(",", Environment.NewLine);
            Appointment_Panel.AutoScrollPosition = new Point(0, 0); // set the autoscroll to normal position
            int x = 0;
            int y = appointmentYlocation(time); // get the y location
            int labelWidth = 260;
            int FlowPanelWidth = 298;
            Single nameTextSize = 12.25F, treatmentTextSize = 11.25F;
     
            if (WeekSwitch.Value == false)
            {
                 x = (dentID == 1) ? 11 : 311;  // get the x location
            }
            else
            {
                 x = appointmentXlocation(date, dentID);
                y += 50;
                labelWidth = 110;
                FlowPanelWidth = 148;
                nameTextSize = 10.25F;
                treatmentTextSize = 9.25F;

            }
        
         
            //clear list controls of panel
           
            Appointment_Panel.AutoScrollPosition = new Point(0, 0);
            //
          
                FlowLayoutPanel appointment = new FlowLayoutPanel();
               // appointment.Name = id.ToString();
                appointment.Size = new Size(FlowPanelWidth, 98);
                appointment.Location = new Point(x, y);
                appointment.FlowDirection = FlowDirection.LeftToRight;
                appointment.WrapContents = true;
            //  appointment.AutoScroll = true;
                appointment.BackColor = Color.LightSeaGreen;
            if (dentID == 2) { appointment.BackColor = Color.FromArgb(217, 102, 135); }
                this.Appointment_Panel.Controls.Add(appointment);

            Label namee = new Label();
            new ToolTip().SetToolTip(namee, name);
            namee.Text = name;
            namee.ForeColor = Color.White;
            namee.Size = new Size(labelWidth, 20);
            namee.Font = new Font("Microsoft Sans Serif", nameTextSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            appointment.Controls.Add(namee);

            PictureBox pictureBox = new PictureBox();
            pictureBox.Name = id.ToString();
            pictureBox.BackColor = System.Drawing.Color.Transparent;
            pictureBox.Size = new System.Drawing.Size(20, 20);
            pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBox.Click += (sender, e) =>
            {
                Int32.TryParse(pictureBox.Name, out int appid);
                editApp(appid);
                


            };

            if (status == "COMPLETED")
            {
                pictureBox.Image = global::_846DentalClinicManagementSystem.Properties.Resources.success;
            }
            else
            {
                pictureBox.Image = global::_846DentalClinicManagementSystem.Properties.Resources.warning;
            }
            appointment.Controls.Add(pictureBox);

            Label lblcontact = new Label();
            new ToolTip().SetToolTip(lblcontact, contact);
            lblcontact.Text = contact;
            lblcontact.ForeColor = Color.White;
            lblcontact.Size = new Size(labelWidth, 20);
            lblcontact.Font = new Font("Microsoft Sans Serif", nameTextSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            appointment.Controls.Add(lblcontact);

            Label name1 = new Label();
            name1.Text = treatment;
            new ToolTip().SetToolTip(name1, treatment);
            name1.ForeColor = Color.White;
            name1.Size = new Size(labelWidth + 50, 78);
            name1.Font = new Font("Microsoft Sans Serif", treatmentTextSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            appointment.Controls.Add(name1);

        }
        int LastScrollPosX = 0, LastScrollPosY= 0;
        public void RefreshAppointmentView()
        {
            string date = SearchAppByDate_DP.Value.ToString("M/d/yyyy");
            if (isWeek) { DrawAppointmentTable(); }
            ShowAppointment(date);
            Appointment_Panel.AutoScrollPosition = new Point(LastScrollPosX, LastScrollPosY);
        }

        private void SearchAppByDate_DP_onValueChanged(object sender, EventArgs e)
        {
            LastScrollPosX = Appointment_Panel.HorizontalScroll.Value;
            LastScrollPosY = Appointment_Panel.VerticalScroll.Value;
            RefreshAppointmentView();
        }

        public void ChangeStatusIcon(Boolean AppStatus) {

            foreach (Control control in Appointment_Panel.Controls) {
                    foreach(Control s in control.Controls)
                {
                    if (s.Name == GlobalVariable.AppointmentID.ToString())
                    {
                
                      if (AppStatus == true)
                        {

                            ((PictureBox)s).Image = global::_846DentalClinicManagementSystem.Properties.Resources.success;
                        }
                        else
                        {
                            ((PictureBox)s).Image = global::_846DentalClinicManagementSystem.Properties.Resources.warning;
                        }
                    }
                }
                    
                        }

        }

        private void editApp(int id)
        {

            GlobalVariable.AppointmentID = id;
            if (GlobalVariable.isEditAppointment == false)
            {
                if (GlobalVariable.AppointmentID > 0)
                {
                    GlobalVariable.isEditAppointment = true;
                    AddAppointment addAppointment = new AddAppointment();
                    addAppointment.Show();
                }
            }
        }

        private void btn_CreateAppointment_Click(object sender, EventArgs e)
        {
            if (GlobalVariable.isAddAppointment == false)
            {
                AddAppointment addAppointment = new AddAppointment();
                GlobalVariable.isAddAppointment = true;
                addAppointment.Show();
            }
        }

        private void btn_AddPatient2_Click(object sender, EventArgs e)
        {
            if (GlobalVariable.isAddPatient == false)
            {
                GlobalVariable.isAddPatient = true;
                AddEditPatientRecord addEditPatient = new AddEditPatientRecord();
                addEditPatient.Show();
            }
        }

    private void setTimelabel()
        {
            int horizontalY = 60;
            DateTime time = new DateTime(2019, 10, 29, 9, 0, 0);

            for (int i = 0; i < 19; i++)
            {

                Label timeLabel = new Label();
                timeLabel.Font = new Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                timeLabel.Location = new Point(50, horizontalY - 10);
                timeLabel.Text = time.ToString("hh:mm tt");
                this.AppTimePanel.Controls.Add(timeLabel);
                time = time.AddMinutes(30);
                horizontalY += 50;
            }
        }

        private void DrawAppointmentTable()
        {
        
            int verticalX = 10;
            int verticalY = 0;
            int vertx = verticalX;
            AppointmentHeader_Panel.Controls.Clear();
            Appointment_Panel.Controls.Clear();
            AppointmentHeader_Panel.AutoScrollPosition = new Point(0, 0);

            this.AppointmentHeader_Panel.Controls.Add(this.panel27);
            this.AppointmentHeader_Panel.Controls.Add(this.panel26);


            if (WeekSwitch.Value == false)
            {
         
                for (int i = 0; i < 3; i++)
                {
                    Panel verticalPanel = new Panel();
                    verticalPanel.Size = new Size(1, 960);
                    verticalPanel.BackColor = Color.Silver;
                    verticalPanel.Margin = new Padding(0);
                    verticalPanel.Location = new Point(verticalX, verticalY);
                    verticalX += 300;
                    this.Appointment_Panel.Controls.Add(verticalPanel);

                }
                isWeek = false;
              
            }
            else
            {

                Appointment_Panel.Controls.Clear();
                AppointmentHeader_Panel.Controls.Clear();
                AppointmentHeader_Panel.AutoScrollPosition = new Point(0, 0);

                for (int i = 0; i < 8; i++)
                {
                    Panel verticalPanel = new Panel();
                    verticalPanel.Size = new Size(1, 960);
                    verticalPanel.BackColor = Color.Silver;
                    verticalPanel.Margin = new Padding(0);
                    verticalPanel.Location = new Point(verticalX, verticalY);
                    verticalX += 300;
                    this.Appointment_Panel.Controls.Add(verticalPanel);
                }


                Panel panel = new Panel();
                panel.Size = new Size(2100, 45);
                panel.BackColor = Color.Salmon;
                panel.Margin = new Padding(0);
                panel.Location = new Point(0, 0);
                this.AppointmentHeader_Panel.Controls.Add(panel);

               


                DateTime dateStart = SearchAppByDate_DP.Value;

                int b = (int)dateStart.DayOfWeek;

                if (b != 0)
                {
                    dateStart = dateStart.AddDays(-(b));

                }
                

                for (int i = 0; i < 7; i++)
                {

                    Label label4 = new Label();
                    label4.Font = new Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    label4.Location = new Point(vertx + 20, verticalY );
                    label4.Text = dateStart.ToString("ddd");
                    panel.Controls.Add(label4);


                    Label label = new Label();
                    label.Font = new Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    label.Location = new Point(vertx + 20, verticalY + 20);
                    label.Text = dateStart.ToString("M/d");
                    panel.Controls.Add(label);

                    vertx += 300;
                    dateStart = dateStart.AddDays(1);
                }
                int loc = 0;
                for (int i = 0; i < 14; i++)
                {
                    Panel aira = new Panel();
                    aira.Size = new Size(161, 20);
                    aira.Margin = new Padding(0);
                    aira.Location = new Point(loc, 45);
                    if (i % 2 == 0)
                    {
                        aira.BackColor = Color.PaleTurquoise;
                    }
                    else
                    {
                        aira.BackColor = Color.Pink;
                    }
                    if (i == 13) { aira.Size = new Size(150, 20); }
                   

                    loc += 150;
                    this.AppointmentHeader_Panel.Controls.Add(aira);

                    Label esther = new Label();
                    esther.Font = new Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    esther.Location = new Point(58, 0);

                    if (i % 2 == 0)
                    {
                        esther.Text = "Dr. Aira";
                    }
                    else
                    {
                        esther.Text = "Dr. Esther";
                        esther.Location = new Point(54, 0);
                    }
                    if (i == 13) { aira.Size = new Size(150, 20); }

                    aira.Controls.Add(esther);
                }


                isWeek = true;
            }

            DrawLines();

        }

        private void setAutoScrollfalse()
        {

            AppTimePanel.VerticalScroll.Maximum = Appointment_Panel.VerticalScroll.Maximum;
            AppTimePanel.VerticalScroll.Minimum = Appointment_Panel.VerticalScroll.Minimum;
            AppointmentHeader_Panel.HorizontalScroll.Maximum = Appointment_Panel.HorizontalScroll.Maximum;
            AppointmentHeader_Panel.HorizontalScroll.Minimum = Appointment_Panel.HorizontalScroll.Minimum;
            AppTimePanel.AutoScroll = false;

        }
        
        private void DrawLines()
        {

            int horizontalX = 0;
            int horizontalY = 60;
            int width;

            if (WeekSwitch.Value == false)
            {
                width = 610;

            }
            else
            {
                width = 2110;
            }

            Panel HorizontalPanel1 = new Panel();
            HorizontalPanel1.Size = new Size(width, 1);
            HorizontalPanel1.BackColor = Color.Silver;
            HorizontalPanel1.Margin = new Padding(0);
            HorizontalPanel1.Location = new Point(horizontalX, 5);
            this.Appointment_Panel.Controls.Add(HorizontalPanel1);

            for (int i = 0; i < 19; i++)
            {
                Panel HorizontalPanel = new Panel();
                HorizontalPanel.Size = new Size(width, 1);
                HorizontalPanel.BackColor = Color.Silver;
                HorizontalPanel.Margin = new Padding(0);
                HorizontalPanel.Location = new Point(horizontalX, horizontalY);
                this.Appointment_Panel.Controls.Add(HorizontalPanel);
                horizontalY += 50;
            }
            
        }


        private void WeekSwitch_OnValueChange(object sender, EventArgs e)
        {
            
            DrawAppointmentTable();
            AppointmentHeader_Panel.AutoScroll = false;
            ShowAppointment(SearchAppByDate_DP.Value.ToString("M/d/yyyy"));


        }

        private void Appointment_Panel_Scroll(object sender, ScrollEventArgs e)
        {
           
            AppTimePanel.AutoScrollPosition = new Point(0, Appointment_Panel.VerticalScroll.Value);
            AppointmentHeader_Panel.AutoScrollPosition = new Point(Appointment_Panel.HorizontalScroll.Value, 0);
           
           // Console.WriteLine("Horizontal = " + Appointment_Panel.HorizontalScroll.Value);
           // Console.WriteLine("Vertical = " + Appointment_Panel.VerticalScroll.Value);
        }
        private void Appointment_Panel_MouseMove(object sender, MouseEventArgs e)
        {
            AppTimePanel.AutoScrollPosition = new Point(0, Appointment_Panel.VerticalScroll.Value);
        }


        // Scheduler Panel End ---------------------------------------------------------------------------------------------------------

        //Patient Panel Start ----------------------------------------------------------------------------------------------------------

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

                // dateformat
                Patient_DataGrid.Columns[4].DefaultCellStyle.Format = "MMMM d, yyyy";


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
            GlobalVariable.PatientID = Convert.ToInt32 (Patient_DataGrid.SelectedRows[0].Cells[0].Value);
        }

        private void btn_AddPatient_Click(object sender, EventArgs e)
        {
            if (GlobalVariable.isAddPatient == false)
            {
                GlobalVariable.isAddPatient = true;
                AddEditPatientRecord addEditPatient = new AddEditPatientRecord();
                addEditPatient.Show();
            }
            
        }


        private void ShowPatientDetails()
        {
            GlobalVariable.PatientID = Convert.ToInt32(Patient_DataGrid.SelectedRows[0].Cells[0].Value);
            GlobalVariable.PatientName = Patient_DataGrid.SelectedRows[0].Cells[1].Value.ToString();
            if (GlobalVariable.PatientID > 0)
            {
                ShowPatientInfo showPatientInfo = new ShowPatientInfo();
                showPatientInfo.Show();
            }
        }
        private void btn_ShowDetails_Click(object sender, EventArgs e)
        {
            ShowPatientDetails();
        }

        private void Patient_DataGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowPatientDetails();
        }


        private void btn_EditPatient_Click(object sender, EventArgs e)
        {
            if (GlobalVariable.isEditPatient == false)
            {
                if (GlobalVariable.PatientID > 0)
                {

                    GlobalVariable.isEditPatient = true;
                    AddEditPatientRecord addEditPatient = new AddEditPatientRecord();
                    addEditPatient.Show();

                }
            }
            
        }

        private void SchedulerPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        
















        // Patient Panel End --------------------------------------------------------------------------------------------------------


    }
}
