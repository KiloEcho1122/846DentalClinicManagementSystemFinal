using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Collections;
using Tulpep.NotificationWindow;
using System.Globalization;
using System.Web;
using System.Net.Mail;

namespace _846DentalClinicManagementSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();


        }

        SqlConnection sqlcon = new SqlConnection(GlobalVariable.connString);
        List<Panel> Panels = new List<Panel>();
        ArrayList DentistArray = new ArrayList();
        ArrayList DentistIDArray = new ArrayList();
        string[,] timeArray = new string[19, 2];

        private void HidePanels()
        {
            HomePanel.Visible = false;
            PatientsPanel.Visible = false;
            AccountingPanel.Visible = false;
            SchedulerPanel.Visible = false;
            Dentist_Panel.Visible = false;
            AppointmentHistory_Panel.Visible = false;
            ActivityLog_Panel.Visible = false;

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
            timer1.Enabled = true;
            NotificationTimer.Enabled = true;
            Loadusername();
            HidePanels();
            HomePanel.Visible = true;
            playVideo();
            AppointmentCountDashBoard();
            DentistCountDashBoard();
            PatientCountDashBoard();
            UnpaidBillsCountDashBoard();
            iniatializeTimeArray();
            setTimelabel();
            DrawAppointmentTable();
            SearchAppByDate_DP.Value = DateTime.Now;
            PatientPanelSearch("");
            DisplayEmployeeDataGrid("");
            setAutoScrollfalse();

        }

        private void Loadusername()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(
                "SELECT CONCAT(FirstName, ' ', LastName),Permission,JobTitle FROM Employee e INNER JOIN [Login] l ON " +
                "e.EmployeeID = l.EmployeeID_fk WHERE l.EmployeeId_fk = @EmployeeID", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@EmployeeID", GlobalVariable.EmployeeID);
            adapter.SelectCommand = cmd;

            try
            {
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    lbl_userName.Text = row[0].ToString();
                    GlobalVariable.User_name = row[0].ToString();
                    GlobalVariable.Permission = row[1].ToString();
                    GlobalVariable.JobTitle = row[2].ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            sqlcon.Close();
        }


        //Main Panel Start


        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_DateTimeNow.Text = System.DateTime.Now.ToString("dddd, MMM. dd yyyy hh:mm tt");
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Logout ?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                FormLogin formLogin = new FormLogin();
                formLogin.Show();
                this.Hide();
            }
        }


        private void btn_Home_Click(object sender, EventArgs e)
        {
            HidePanels();
            HomePanel.Visible = true;
            AppointmentCountDashBoard();
            DentistCountDashBoard();
            PatientCountDashBoard();
            UnpaidBillsCountDashBoard();

        }

        private void btn_Scheduler_Click(object sender, EventArgs e)
        {
            DrawAppointmentTable();
            SearchAppByDate_DP.Value = DateTime.Now;
            HidePanels();
            SchedulerPanel.Visible = true;
            GlobalVariable.InsertActivityLog("Viewed Appointment Tab", "View");


        }

        private void btn_Patients_Click(object sender, EventArgs e)
        {
            HidePanels();
            PatientsPanel.Visible = true;
            GlobalVariable.InsertActivityLog("Viewed Patients Tab", "View");
        }

        private void btn_Accounting_Click(object sender, EventArgs e)
        {

            if (GlobalVariable.Permission == "Admin")
            {
                HidePanels();
                AccountingPanel.Visible = true;
                Inventory_DatePicker.Value = System.DateTime.Today;
                LoadMonthlyProfit();
                LoadMonthlyExpenses();
                LoadGrossProfit();
                GlobalVariable.InsertActivityLog("Viewed Accounting Tab", "View");

            }
            else
            {
                MessageBox.Show("Permission Denied !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_Dentist_Click(object sender, EventArgs e)
        {
            if (GlobalVariable.Permission == "Admin")
            {
                HidePanels();
                Dentist_Panel.Visible = true;
                GlobalVariable.InsertActivityLog("Viewed Dentist/Employee Tab", "View");
            }
            else
            {
                MessageBox.Show("Permission Denied !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_ViewAppointmentHistory_Click(object sender, EventArgs e)
        {
            HidePanels();
            AppointmentHistory_Panel.Visible = true;
            LoadAppHistory();
            GlobalVariable.InsertActivityLog("Viewed Appointment History", "View");
        }

        private void btn_ActivityLogs_Click(object sender, EventArgs e)
        {
            if (GlobalVariable.Permission == "Admin")
            {
                HidePanels();
                ActivityLog_Panel.Visible = true;
                GlobalVariable.InsertActivityLog("Viewed Activity logs Tab", "View");
                LoadActivityLogsDD();
            }
            else
            {
                MessageBox.Show("Permission Denied !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Main Panel End -----------------------------------------------------------------------------------------------------------

        //App Historu Panel Start

        private void LoadAppHistory()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT a.AppointmentID AS ID, CONCAT(a.Appointment_LName, ',', a.Appointment_FName, ' ', a.Appointment_MName) AS Patient," +
            "a.AppointmentDate AS Date, CONCAT(a.StartTime, ' - ', a.EndTime) AS Time, CONCAT(e.FirstName, ' ', e.LastName) AS Dentist," +
            "a.Status FROM Appointment a INNER JOIN Employee e ON a.EmployeeID_fk = e.EmployeeId WHERE NOT a.Status = 'PENDING' ORDER BY a.AppointmentDate DESC", sqlcon);
            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);
                AppHistory_DataGrid.DataSource = dt;
                AppHistory_DataGrid.Columns[0].Width = 70;
                AppHistory_DataGrid.Columns[1].Width = 200;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            HidePanels();
            SchedulerPanel.Visible = true;
        }


        //App History Panel End

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
            string Appquery, ApExceptquery;
            string date2 = "";
            int ControlsCount = 0;
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlDataAdapter adapter2 = new SqlDataAdapter();
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            SqlCommand cmd, cmd2;

            if (WeekSwitch.Value == false)
            {

                Appquery = "SELECT a.AppointmentID AS No, CONCAT(a.Appointment_LName, ', ', a.Appointment_FName, ' ', a.Appointment_MName) AS Patient_Name, " +
                "a.EmployeeID_fk,p.Treatment,a.Status, a.StartTime, a.AppointmentDate,a.Appointment_Contact FROM Appointment a INNER JOIN[PatientTreatment] p " +
                "ON AppointmentID = AppointmentID_fk INNER JOIN[Employee] e ON e.EmployeeId = a.EmployeeID_fk " +
                "WHERE AppointmentDate = @date AND e.JobTitle = 'Dentist' AND NOT Status ='CANCELLED' ORDER BY RefTime ASC";
                cmd = new SqlCommand(Appquery, sqlcon);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@date", date);

                ApExceptquery = "SELECT * FROM [AppointmentException] WHERE Date = @date AND NOT Status ='CANCELLED' ORDER BY RefTime ASC";
                cmd2 = new SqlCommand(ApExceptquery, sqlcon);
                cmd2.Parameters.Clear();
                cmd2.Parameters.AddWithValue("@date", date);

                ControlsCount = DentistArray.Count + 1;

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

                Appquery = "SELECT a.AppointmentID AS No, CONCAT(a.Appointment_LName, ', ', a.Appointment_FName, ' ', a.Appointment_MName) AS Patient_Name, " +
               "a.EmployeeID_fk,p.Treatment,a.Status, a.StartTime, a.AppointmentDate,a.Appointment_Contact FROM Appointment a INNER JOIN[PatientTreatment] p " +
               "ON AppointmentID = AppointmentID_fk INNER JOIN[Employee] e ON e.EmployeeId = a.EmployeeID_fk " +
               "WHERE e.JobTitle = 'Dentist' AND NOT Status ='CANCELLED' AND AppointmentDate BETWEEN @date AND @date2 ORDER BY RefTime ASC";
                cmd = new SqlCommand(Appquery, sqlcon);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@date2", date2);

                ApExceptquery = "SELECT * FROM [AppointmentException] WHERE Date BETWEEN @date AND @date2 AND NOT Status ='CANCELLED' ORDER BY RefTime ASC";
                cmd2 = new SqlCommand(ApExceptquery, sqlcon);
                cmd2.Parameters.Clear();
                cmd2.Parameters.AddWithValue("@date", date);
                cmd2.Parameters.AddWithValue("@date2", date2);

                ControlsCount = 8;
            }


            adapter2.SelectCommand = cmd2;
            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);
                adapter2.Fill(dt2);

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

                //Appointment Schedukles
                foreach (DataRow row in dt.Rows)
                {
                    string id = row[0].ToString();
                    string name = row[1].ToString();
                    int dentist_id = (int)(row[2]);
                    string treatment = row[3].ToString();
                    string status = row[4].ToString();
                    string time = row[5].ToString();
                    string appdate = row[6].ToString();
                    string contact = row[7].ToString();

                    DrawAppointments(id, name, treatment, dentist_id, status, time, appdate, contact);
                }
                //Appointment Exception Schedules
                foreach (DataRow row in dt2.Rows)
                {
                    string id = row[0].ToString();
                    string Exceptdate = row[1].ToString();
                    string StartTime = row[2].ToString();
                    string EndTime = row[3].ToString();
                    string reason = row[5].ToString();
                    int dentist_id = (int)row[6];
                    DrawAppException(id, Exceptdate, StartTime, EndTime, reason, dentist_id);

                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            //put App Exception here

            DrawLines();
        }

        private int AppExceptionHeight(string start, string end)
        {
            int ret = 0;
            DateTime time1 = DateTime.ParseExact(start, "hh:mm tt", System.Globalization.CultureInfo.CurrentCulture);
            DateTime time2 = DateTime.ParseExact(end, "hh:mm tt", System.Globalization.CultureInfo.CurrentCulture);
            TimeSpan difference = time2 - time1;
            ret = ((int)difference.TotalMinutes / 30) * 50 - 2;
            return ret;
        }

        private void DrawAppException(string id, string Exceptdate, string StartTime, string EndTime, string reason, int dentist_id)
        {
            Appointment_Panel.AutoScrollPosition = new Point(0, 0); // set the autoscroll to normal position

            int x = 0;
            int y = appointmentYlocation(StartTime); // get the y location
            int labelWidth = 260;
            int FlowPanelWidth = 298;
            int FlowPanelHeight = AppExceptionHeight(StartTime, EndTime);
            Single nameTextSize = 12.25F, treatmentTextSize = 11.25F;

            if (WeekSwitch.Value == false)
            {
                for (int i = 0; i < DentistIDArray.Count; i++)
                {
                    if (dentist_id.ToString() == DentistIDArray[i].ToString())
                    {

                        x = (300 * i) + 11;
                    }
                }
                // get the x location
            }
            else
            {
                x = appointmentXlocation(Exceptdate, dentist_id);
                //  y += 50;
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
            appointment.Size = new Size(FlowPanelWidth, FlowPanelHeight);
            appointment.Location = new Point(x, y);
            appointment.FlowDirection = FlowDirection.LeftToRight;
            appointment.WrapContents = true;
            //  appointment.AutoScroll = true;
            appointment.BackColor = Color.Maroon;
            appointment.MouseMove += (sender, e) =>
            {
                AppTimePanel.AutoScrollPosition = new Point(0, Appointment_Panel.VerticalScroll.Value);
            };

            this.Appointment_Panel.Controls.Add(appointment);

            Label namee = new Label();
            namee.Text = "Not Available";
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
            pictureBox.Image = global::_846DentalClinicManagementSystem.Properties.Resources.edit;
            pictureBox.Click += (sender, e) =>
            {
                Int32.TryParse(pictureBox.Name, out int appid);
                editAppException(appid);



            };

            appointment.Controls.Add(pictureBox);

        }


        private int appointmentYlocation(string time)
        {
            int y = 0;

            for (int i = 0; i < 19; i++)
            {
                if (timeArray[i, 0] == time)
                {
                    Int32.TryParse(timeArray[i, 1], out y);
                    return y;
                }
            }

            return y;
        }

        private int appointmentXlocation(string date, int dentID)
        {
            int loc = 0;

            DateTime StartDate = DateTime.ParseExact(date, "M/d/yyyy hh:mm:ss tt", System.Globalization.CultureInfo.CurrentCulture);
            int b = (int)StartDate.DayOfWeek;

            for (int i = 0; i < DentistIDArray.Count; i++)
            {
                if (dentID.ToString() == DentistIDArray[i].ToString())
                {
                    loc = ((150 * i) + 11) + (b * (150 * DentistIDArray.Count));
                }
            }


            return loc;
        }

        bool isWeek = false;


        private void DrawAppointments(string id, string name, string treatment, int dentID, string status, string time, string date, string contact)
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
                for (int i = 0; i < DentistIDArray.Count; i++)
                {
                    if (dentID.ToString() == DentistIDArray[i].ToString())
                    {

                        x = (300 * i) + 11;
                    }
                }
                // get the x location
            }
            else
            {
                x = appointmentXlocation(date, dentID);
                //  y += 50;
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
            if (dentID % 2 == 0) { appointment.BackColor = Color.FromArgb(217, 102, 135); }
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



        private void DentistToArray()
        {
            DentistArray.Clear();
            DentistIDArray.Clear();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                "SELECT EmployeeID,CONCAT(FirstName , ' ', Lastname)  FROM Employee Where JobTitle = 'Dentist' ORDER BY EmployeeID ASC", sqlcon);

            adapter.SelectCommand = cmd;
            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                adapter.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    DentistIDArray.Add(row[0].ToString());
                    DentistArray.Add(row[1].ToString());

                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            sqlcon.Close();
        }

        private void ShowDentistHeader()
        {
            DentistToArray();
            int xStartPosition = 11;

            for (int i = 0; i < DentistArray.Count; i++)
            {


                Panel panel = new Panel();
                panel.Location = new System.Drawing.Point(xStartPosition, 17);
                panel.Margin = new System.Windows.Forms.Padding(0);
                panel.Size = new System.Drawing.Size(302, 41);
                if (i % 2 == 0)
                {
                    panel.BackColor = System.Drawing.Color.Pink;
                }
                else
                {
                    panel.BackColor = System.Drawing.Color.PaleTurquoise;
                }
                AppointmentHeader_Panel.Controls.Add(panel);


                Label label = new Label();
                label.AutoSize = true;
                label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label.Location = new System.Drawing.Point(59, 8);
                label.Size = new System.Drawing.Size(172, 24);
                label.Text = "Dr. " + DentistArray[i].ToString();
                panel.Controls.Add(label);

                xStartPosition += 300;
            }




        }

        int LastScrollPosX = 0, LastScrollPosY = 0;
        public void RefreshAppointmentView()
        {
            LastScrollPosX = Appointment_Panel.HorizontalScroll.Value;
            LastScrollPosY = Appointment_Panel.VerticalScroll.Value;
            string date = SearchAppByDate_DP.Value.ToString("M/d/yyyy");
            if (isWeek) { DrawAppointmentTable(); }
            ShowAppointment(date);
            Appointment_Panel.AutoScrollPosition = new Point(LastScrollPosX, LastScrollPosY);
        }

        private void SearchAppByDate_DP_onValueChanged(object sender, EventArgs e)
        {

            RefreshAppointmentView();
        }

        public void ChangeStatusIcon(Boolean AppStatus)
        {

            foreach (Control control in Appointment_Panel.Controls)
            {
                foreach (Control s in control.Controls)
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
                    addAppointment.ShowDialog();
                }
            }
        }

        private void btn_CreateAppointment_Click(object sender, EventArgs e)
        {
            if (GlobalVariable.isAddAppointment == false)
            {
                AddAppointment addAppointment = new AddAppointment();
                GlobalVariable.isAddAppointment = true;
                addAppointment.ShowDialog();
            }
        }

        private void btn_AddException_Click(object sender, EventArgs e)
        {
            if (GlobalVariable.isAddAppException == false)
            {
                AddException addException = new AddException();
                GlobalVariable.isAddAppException = true;
                addException.ShowDialog();
            }
        }

        private void editAppException(int id)
        {

            GlobalVariable.AppExceptionID = id;
            if (GlobalVariable.isEditAppException == false)
            {
                if (GlobalVariable.AppExceptionID > 0)
                {
                    GlobalVariable.isEditAppException = true;
                    AddException addException = new AddException();
                    addException.ShowDialog();
                }
            }
        }




        private void btn_AddPatient2_Click(object sender, EventArgs e)
        {
            if (GlobalVariable.isAddPatient == false)
            {
                GlobalVariable.isAddPatient = true;
                AddEditPatientRecord addEditPatient = new AddEditPatientRecord();
                addEditPatient.ShowDialog();
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
                timeLabel.Location = new Point(50, horizontalY - 15);
                timeLabel.Text = time.ToString("hh:mm tt");
                this.AppTimePanel.Controls.Add(timeLabel);
                time = time.AddMinutes(30);
                horizontalY += 50;
            }
        }

        private void DrawAppointmentTable()
        {
            int temp = 0;
            int verticalX = 10;
            int verticalY = 0;
            int vertx = verticalX;
            TimePanel_Footer.Visible = false;
            AppTimePanel.Size = new Size(184, 463);
            AppointmentHeader_Panel.Controls.Clear();
            Appointment_Panel.Controls.Clear();
            AppointmentHeader_Panel.AutoScrollPosition = new Point(0, 0);
            ShowDentistHeader();


            if (WeekSwitch.Value == false)
            {

                //AppointmentHeader_Panel.Controls.Add(this.panel26);
                //AppointmentHeader_Panel.Controls.Add(this.panel27);

                for (int i = 0; i < DentistArray.Count + 1; i++)
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

                TimePanel_Footer.Visible = true;
                AppTimePanel.Size = new Size(184, 450);
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
                    verticalX += (150 * DentistArray.Count);
                    this.Appointment_Panel.Controls.Add(verticalPanel);
                }


                Panel panel = new Panel();
                panel.Size = new Size(((DentistArray.Count * 150) * 7) + 10, 45);
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
                    label4.Location = new Point(vertx + 20, verticalY);
                    label4.Text = dateStart.ToString("ddd");
                    panel.Controls.Add(label4);


                    Label label = new Label();
                    label.Font = new Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    label.Location = new Point(vertx + 20, verticalY + 20);
                    label.Text = dateStart.ToString("M/d");
                    panel.Controls.Add(label);

                    vertx += (150 * DentistArray.Count);
                    dateStart = dateStart.AddDays(1);
                }
                int loc = 0;
                for (int i = 0; i < (DentistArray.Count * 7); i++)
                {

                    Panel WeekDentistPanel = new Panel();
                    WeekDentistPanel.Location = new Point(loc, 45);
                    WeekDentistPanel.Size = new Size(161, 20);
                    WeekDentistPanel.Margin = new Padding(0);

                    if (i % 2 == 0)
                    {
                        WeekDentistPanel.BackColor = Color.PaleTurquoise;
                    }
                    else
                    {
                        WeekDentistPanel.BackColor = Color.Pink;
                    }

                    // pra magreset sa index 0 if ever na lumagpas na si i




                    //Panel aira = new Panel();
                    //aira.Location = new Point(loc, 45);
                    //aira.Size = new Size(161, 20);
                    //aira.Margin = new Padding(0);

                    //if (i % 2 == 0)
                    //{
                    //    aira.BackColor = Color.PaleTurquoise;
                    //}
                    //else
                    //{
                    //    aira.BackColor = Color.Pink;
                    //}
                    //if (i == 12) aira.Size = new Size(176, 20);
                    //if (i == 13)
                    //{
                    //    aira.Location = new Point(loc + 15, 45);

                    //}

                    loc += 150;
                    this.AppointmentHeader_Panel.Controls.Add(WeekDentistPanel);



                    if (i % DentistArray.Count == 0)
                    {
                        temp = 0;
                    }
                    Label DentName = new Label();
                    DentName.Font = new Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    DentName.Location = new Point(45, 0);
                    DentName.Text = "Dr." + DentistArray[temp].ToString();
                    WeekDentistPanel.Controls.Add(DentName);

                    temp += 1;
                    //if (i % 2 == 0)
                    //{
                    //    esther.Text = "Dr. Aira";
                    //}
                    //else
                    //{
                    //    esther.Text = "Dr. Esther";
                    //    esther.Location = new Point(54, 0);
                    //}
                    //if (i == 13) { aira.Size = new Size(150, 20); }

                    //aira.Controls.Add(esther);
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
            WeekSwitch.Value = true;
            WeekSwitch.Value = false;

        }

        private void DrawLines()
        {

            int horizontalX = 0;
            int horizontalY = 60;
            int width;
            Appointment_Panel.AutoScrollPosition = new Point(0, 0);

            if (WeekSwitch.Value == false)
            {
                width = (DentistArray.Count * 300) + 10;

            }
            else
            {
                width = ((DentistArray.Count * 150) * 7) + 10;
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
            ShowAppointment(SearchAppByDate_DP.Value.ToString("M/d/yyyy"));
            AppointmentHeader_Panel.AutoScroll = false;


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
                "PatientGender AS Gender, PatientAge AS Age, PatientBirthday AS Birthday,PatientAddress AS Address," +
                "PatientContact As Contact FROM [Patient] WHERE PatientFullName LIKE @search ORDER BY PatientLName ASC", sqlcon);

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@search", "%" + search + "%");

            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);

                Patient_DataGrid.DataSource = dt;
                Patient_DataGrid.Columns[0].Width = 40;
                Patient_DataGrid.Columns[1].Width = 200;
                Patient_DataGrid.Columns[2].Width = 70;
                Patient_DataGrid.Columns[3].Width = 40;
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
            //GlobalVariable.PatientID = Convert.ToInt32 (Patient_DataGrid.SelectedRows[0].Cells[0].Value);
        }

        private void btn_AddPatient_Click(object sender, EventArgs e)
        {
            if (GlobalVariable.isAddPatient == false)
            {
                GlobalVariable.isAddPatient = true;
                AddEditPatientRecord addEditPatient = new AddEditPatientRecord();
                addEditPatient.ShowDialog();
            }

        }


        private void ShowPatientDetails()
        {
            GlobalVariable.PatientID = Convert.ToInt32(Patient_DataGrid.SelectedRows[0].Cells[0].Value);
            GlobalVariable.PatientName = Patient_DataGrid.SelectedRows[0].Cells[1].Value.ToString();
            if (GlobalVariable.PatientID > 0)
            {
                ShowPatientInfo showPatientInfo = new ShowPatientInfo();
                GlobalVariable.InsertActivityLog("Viewed Patient Details, Patient ID = " + GlobalVariable.PatientID, "View");
                showPatientInfo.ShowDialog();
            }
        }
        private void btn_ShowDetails_Click(object sender, EventArgs e)
        {
            ShowPatientDetails();
        }

        private void Patient_DataGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //ShowPatientDetails();
        }

        private void Patient_DataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                GlobalVariable.PatientID = Convert.ToInt32(Patient_DataGrid.SelectedRows[0].Cells[0].Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Patient_DataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ShowPatientDetails();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        private void btn_EditPatient_Click(object sender, EventArgs e)
        {
            if (GlobalVariable.isEditPatient == false)
            {
                if (GlobalVariable.PatientID > 0)
                {

                    GlobalVariable.isEditPatient = true;
                    AddEditPatientRecord addEditPatient = new AddEditPatientRecord();
                    addEditPatient.ShowDialog();

                }
            }

        }



        // Accounting Panel Start -------------------------------------------------------------------------------------------------



        private void btn_AddExpenses_Click(object sender, EventArgs e)
        {
            if (GlobalVariable.isAddExpense == false)
            {
                GlobalVariable.isAddExpense = true;
                AddExpensescs addExpensescs = new AddExpensescs();
                addExpensescs.ShowDialog();
            }

        }
        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {
            LoadGrossProfit();
        }

        private float LoadMonthlyProfit()
        {

            DateTime date = Inventory_DatePicker.Value;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddSeconds(-1);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                "SELECT b.BillingDate As Date, a.TreatmentType As Treatment, a.TreatmentPrice AS Amount " +
                "FROM AppointmentTreatment a INNER JOIN Billing b ON a.AppointmentID_fk = b.AppointmentID_fk " +
                "WHERE b.BillingDate BETWEEN @date AND @date2  AND b.BillingBalance = 0 ORDER BY b.BillingDate ASC ", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@date", firstDayOfMonth.ToString());
            cmd.Parameters.AddWithValue("@date2", lastDayOfMonth.ToString());

            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);
                Profit_DG.DataSource = dt;
                Profit_DG.Columns[0].DefaultCellStyle.Format = "MMMM d, yyyy";
                Profit_DG.Columns[2].Width = 100;
                Profit_DG.Columns[2].DefaultCellStyle.Format = "N2";
                Profit_DG.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            float output = 0;
            foreach (DataRow row in dt.Rows)
            {
                float.TryParse(row[2].ToString(), out float amt);
                output += amt;
            }

            return output;

        }


        public void LoadGrossProfit()
        {
            DateTime date = Inventory_DatePicker.Value;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddSeconds(-1);
            float netProfit = LoadMonthlyProfit();
            float netExpense = LoadMonthlyExpenses();
            float grossProfit = netProfit - netExpense;

            lbl_netProfit.Text = "₱ " + netProfit.ToString("N2", CultureInfo.CurrentCulture);
            lbl_netExpense.Text = "₱ " + netExpense.ToString("N2", CultureInfo.CurrentCulture);
            lbl_GrossProfit.Text = "₱ " + grossProfit.ToString("N2", CultureInfo.CurrentCulture);

        }


        public float LoadMonthlyExpenses()
        {
            DateTime date = Inventory_DatePicker.Value;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddSeconds(-1);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                "SELECT ExpenseID As Id, ExpenseDate As Date, ExpenseName As Expense,ExpenseAmt AS Amount" +
                " FROM Expense WHERE ExpenseDate BETWEEN @date AND @date2 ORDER BY ExpenseDate ASC ", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@date", firstDayOfMonth.ToString());
            cmd.Parameters.AddWithValue("@date2", lastDayOfMonth.ToString());

            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);
                displayExpenseDG.DataSource = dt;
                displayExpenseDG.Columns[1].DefaultCellStyle.Format = "MMMM d, yyyy";
                displayExpenseDG.Columns[0].Width = 40;
                displayExpenseDG.Columns[1].Width = 130;
                displayExpenseDG.Columns[2].Width = 200;
                displayExpenseDG.Columns[3].Width = 100;
                displayExpenseDG.Columns[3].DefaultCellStyle.Format = "N2";
                displayExpenseDG.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            float output = 0;
            foreach (DataRow row in dt.Rows)
            {
                float.TryParse(row[3].ToString(), out float amt);
                output += amt;
            }

            return output;
        }

        private void displayExpenseDG_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            GlobalVariable.ExpenseId = Convert.ToInt32(displayExpenseDG.SelectedRows[0].Cells[0].Value);
            if (GlobalVariable.isEditExpense == false)
            {
                if (GlobalVariable.ExpenseId > 0)
                {
                    GlobalVariable.isEditExpense = true;
                    AddExpensescs addExpensescs = new AddExpensescs();
                    addExpensescs.Show();
                }
            }

        }

        private void btn_Export2Excel_Click(object sender, EventArgs e)
        {
            //Initiate Excel Variables
            Microsoft.Office.Interop.Excel.Range CR;
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;

            //create new object of excel
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;

            //Define variables
            object misValue = System.Reflection.Missing.Value;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            // set row 1 height
            xlWorkSheet.Rows["1:1"].RowHeight = 36;

            //format excel -- profit area
            xlWorkSheet.Cells[1, 1].Formula = "Profit";
            CR = xlWorkSheet.Range["A1:C1"];
            CR.Select();
            CR.MergeCells = true;
            CR.Interior.ThemeColor = Microsoft.Office.Interop.Excel.XlThemeColor.xlThemeColorLight2;
            CR.Font.Size = 16;
            CR.Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            //format excel -- expense area
            xlWorkSheet.Cells[1, 6].Formula = "Expense";
            CR = xlWorkSheet.Range["F1:H1"];
            CR.Select();
            CR.MergeCells = true;
            CR.Interior.ThemeColor = Microsoft.Office.Interop.Excel.XlThemeColor.xlThemeColorAccent2;
            CR.Font.Size = 16;
            CR.Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            //copy profit table to excel
            copyAllProfitToClipboard();
            CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[3, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            //copy expense table to excel
            copyAllExpenseToClibboard();
            CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[3, 5];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

            //delete ID column of expense
            xlWorkSheet.Columns["E"].Delete();

            //Format Column width
            xlWorkSheet.Columns["A"].ColumnWidth = 11.71;
            xlWorkSheet.Columns["B"].ColumnWidth = 26.57;
            xlWorkSheet.Columns["C"].ColumnWidth = 13.57;
            xlWorkSheet.Columns["E"].ColumnWidth = 11.71;
            xlWorkSheet.Columns["F"].ColumnWidth = 26.57;
            xlWorkSheet.Columns["G"].ColumnWidth = 13.57;

            //align columns to center
            xlWorkSheet.Columns["A:H"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            GlobalVariable.InsertActivityLog("Exported Report to Excel", "Export");
        }


        private void copyAllExpenseToClibboard()
        {
            displayExpenseDG.RowHeadersVisible = false;
            displayExpenseDG.SelectAll();
            DataObject dataObj = displayExpenseDG.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
            displayExpenseDG.ClearSelection();
        }
        private void copyAllProfitToClipboard()
        {
            Profit_DG.RowHeadersVisible = false;
            Profit_DG.SelectAll();
            DataObject dataObj = Profit_DG.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
            Profit_DG.ClearSelection();
        }

        // Accounting Panel End --------------------------------------------------------------------------------------------------------

        // DashBoard Panel Start -----------------------------------------------------------------------------------------------------

        private void AppointmentCountDashBoard()
        {
            string CurrentDate = DateTime.Now.ToShortDateString();
            SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(*) FROM Appointment WHERE AppointmentDate = @AppDate AND Status = 'PENDING' ", sqlcon);
            cmd.Parameters.AddWithValue("@AppDate", CurrentDate);

            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }

            try
            {

                object count = cmd.ExecuteScalar();
                if (count != null)
                {
                    lbl_AppointmentCountDashboard.Text = "Appointments : " + count.ToString();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            sqlcon.Close();
        }

        private void PatientCountDashBoard()
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(*) FROM Patient", sqlcon);


            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }

            try
            {

                object count = cmd.ExecuteScalar();
                if (count != null)
                {
                    lbl_PatientCountDashboard.Text = "Active Patients : " + count.ToString();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            sqlcon.Close();
        }

        private void DentistCountDashBoard()
        {

            SqlCommand cmd = new SqlCommand(
                 "SELECT COUNT(*) FROM Employee Where JobTitle = 'Dentist' ", sqlcon);


            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }

            try
            {

                object count = cmd.ExecuteScalar();
                if (count != null)
                {
                    lbl_DentistCountDashboard.Text = "Active Dentists : " + count.ToString();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            sqlcon.Close();
        }

        private void UnpaidBillsCountDashBoard()
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(*) FROM Billing WHERE BillingBalance > 0", sqlcon);


            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }

            try
            {

                object count = cmd.ExecuteScalar();
                if (count != null)
                {
                    lbl_UnpaidBillsCountDashboard.Text = "Unpaid Bills : " + count.ToString();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            sqlcon.Close();
        }


        // DashBoard Panel End --------------------------------------------------------------------------------------------------------

        //Dentist Panel Start


        public void DisplayEmployeeDataGrid(String search)
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                "SELECT * From Employee Order By LastName", sqlcon);


            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);

                Employee_DataGrid.DataSource = dt;
                Employee_DataGrid.Columns[0].HeaderText = "Id";
                Employee_DataGrid.Columns[1].HeaderText = "Permission";
                Employee_DataGrid.Columns[2].HeaderText = "Last Name";
                Employee_DataGrid.Columns[3].HeaderText = "First Name";
                Employee_DataGrid.Columns[4].HeaderText = "Middle Name";
                Employee_DataGrid.Columns[8].HeaderText = "Email";
                Employee_DataGrid.Columns[9].HeaderText = "Contact";
                Employee_DataGrid.Columns[10].HeaderText = "Address";
                Employee_DataGrid.Columns[11].HeaderText = "Position";
                Employee_DataGrid.Columns[12].HeaderText = "License No";


            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }


        private void btn_AddEmployee_Click(object sender, EventArgs e)
        {
            if (GlobalVariable.isAddEmployee == false)
            {
                GlobalVariable.isAddEmployee = true;
                AddEditEmployee addEditDentist = new AddEditEmployee();
                addEditDentist.ShowDialog();
            }
        }

        private void btn_EditEmployee_Click(object sender, EventArgs e)
        {
            if (GlobalVariable.isEditEmployee == false)
            {
                if (GlobalVariable.EmpID > 0)
                {

                    GlobalVariable.isEditEmployee = true;
                    AddEditEmployee AddEditEmployee = new AddEditEmployee();
                    AddEditEmployee.ShowDialog();

                }
            }
        }


        private DataTable NotifDataTable(DateTime Apptime1, DateTime Apptime2)
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT a.AppointmentID, CONCAT(a.Appointment_LName,',',a.Appointment_FName, ' ',a.Appointment_MName ), " +
                                            "a.Appointment_Contact ,CONCAT(a.StartTime,' - ', a.EndTime), CONCAT(e.FirstName,' ' ,e.LastName) " +
                                            "FROM Appointment a INNER JOIN Employee e ON a.EmployeeID_fk = e.EmployeeId WHERE a.Status ='PENDING' AND " +
                                            "a.AppointmentDate = @date AND  RefTime BETWEEN @time1 AND @time2 ORDER BY a.RefTime ASC", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@date", System.DateTime.Now.ToShortDateString());
            cmd.Parameters.AddWithValue("@time1", Apptime1.ToString("HH:mm:ss"));
            cmd.Parameters.AddWithValue("@time2", Apptime2.ToString("HH:mm:ss"));
            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dt;
        }

        List<int> NotifID = new List<int>();

        private void NotificationTimer_Tick(object sender, EventArgs e)
        {
            DateTime Apptime1 = System.DateTime.Now;
            DateTime Apptime2 = Apptime1.AddMinutes(30);
            DataTable dt = NotifDataTable(Apptime1, Apptime2);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (!(NotifID.Contains((int)row[0])))
                    {
                        NotifID.Add((int)row[0]);
                        this.Invoke((MethodInvoker)delegate
                        {
                            PopupNotifier popup = new PopupNotifier();
                            popup.Size = new Size(300, 180);
                            popup.Image = Properties.Resources.info_icon;
                            popup.ImageSize = new Size(30, 30);
                            popup.ImagePadding = new Padding(5);
                            popup.HeaderHeight = 20;
                            popup.HeaderColor = Color.Orange;
                            popup.TitlePadding = new Padding(5);
                            popup.TitleFont = new System.Drawing.Font("Segoe UI", 13.25F);
                            popup.TitleText = " Appointment Notification";
                            popup.ContentFont = new System.Drawing.Font("Segoe UI", 11.25F);
                            popup.ContentPadding = new Padding(10);
                            popup.ContentText = row[1].ToString() + "\n" + row[2].ToString() + "\n" + row[3].ToString() + "\n" + "Dr. " + row[4].ToString();
                            popup.Delay = 120000;
                            popup.AnimationInterval = 20;
                            popup.Popup();
                        });
                    }


                }
            }

        }




        private void SendEmailToDentist()
        {

            string EmailSubject = "846 Dental Appointment for Tommorrow " + System.DateTime.Today.AddDays(1).ToShortDateString();
            string DentalEmailAdd = "846dentalclinic@gmail.com";
            string DentalEmailPass = "System2020";
            string SmtpServer = "smtp.gmail.com";


            try
            {
                for (int i = 0; i < DentistIDArray.Count; i++)
                {
                    string EmailBody = string.Empty;
                    string DentistEmailAdd = string.Empty;
                    DataTable dt = new DataTable();
                    dt = getAppointmentForEmail(Convert.ToInt32(DentistIDArray[i]));

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            EmailBody += row[1].ToString() + " - " + row[0].ToString() + Environment.NewLine;
                            DentistEmailAdd = row[2].ToString();
                        }

                        MailMessage mail = new MailMessage(DentalEmailAdd, DentistEmailAdd, EmailSubject, EmailBody);
                        SmtpClient client = new SmtpClient(SmtpServer);
                        client.Port = 587;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new System.Net.NetworkCredential(DentalEmailAdd, DentalEmailPass);
                        client.EnableSsl = true;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.Send(mail);
                    }
                    //Prompt Success MEssage on last email sent
                    if (i == DentistIDArray.Count - 1)
                    {
                        MessageBox.Show("Mail Sent !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GlobalVariable.InsertActivityLog("Send Emails To Dentists", "View");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Email Not Send, Please Check your Internet or Email!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }

        }

        private DataTable getAppointmentForEmail(int id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("SELECT CONCAT(a.Appointment_FName, ' ', a.Appointment_LName), CONCAT(a.StartTime,' - ',a.EndTime)," +
                "e.EmailAdd FROM Employee e INNER JOIN Appointment a ON a.EmployeeID_fk = e.EmployeeId WHERE a.AppointmentDate =" +
                " @date AND Status = 'PENDING' AND EmployeeID = @id ORDER BY RefTime ASC ", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@date", System.DateTime.Today.ToShortDateString());
            cmd.Parameters.AddWithValue("@id", id);
            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dt;
        }



        private void btn_SendEmail_Click(object sender, EventArgs e)
        {
            SendEmailToDentist();
        }


        private void Employee_DataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                GlobalVariable.EmpID = Convert.ToInt32(Employee_DataGrid.SelectedRows[0].Cells[0].Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            //Dentist Panel End


            //Activity Logs --------------------------------------------------------------------------------------------------


        }


        private void LoadActivityLogsDD()
        {
            UserDD.Clear();
            UserDD.AddItem("All");
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT CONCAT(FirstName, ' ', LastName) FROM Employee", sqlcon);
            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    UserDD.AddItem(row[0].ToString()); // load usernames to filter by user dropdown
                }

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            DateDD.Value = System.DateTime.Today; // load the date today to filter by date
            UserDD.selectedIndex = 0;
            MethodDD.selectedIndex = 0;

        }

        string FilterbyUser = string.Empty, FilterbyMethod = string.Empty, FilterbyDate = string.Empty;

        private void DateDD_onValueChanged(object sender, EventArgs e)
        {
            FilterbyDate = DateDD.Value.ToShortDateString();
            ShowActivityLogs();
        }

        private void UserDD_onItemSelected(object sender, EventArgs e)
        {
            if (UserDD.selectedIndex >= 0)
            {
                FilterbyUser = UserDD.selectedValue.ToString();
                ShowActivityLogs();
            }
        }

        private void MethodDD_onItemSelected(object sender, EventArgs e)
        {
            if (MethodDD.selectedIndex >= 0)
            {
                FilterbyMethod = MethodDD.selectedValue.ToString();
                ShowActivityLogs();
            }
        }

      

        private void ShowActivityLogs()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
            "SELECT Id, Date, Description, User_Name, Method, IP FROM ActivityLogs WHERE RefDate = @date AND " +
            "User_Name = CASE WHEN @user = 'All' THEN User_Name ELSE @user END AND  Method = CASE WHEN @method " +
            "= 'All' THEN Method ELSE @method END AND Status = 'OK' ORDER BY Date DESC", sqlcon);

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@date", FilterbyDate);
            cmd.Parameters.AddWithValue("@user", FilterbyUser);
            cmd.Parameters.AddWithValue("@method", FilterbyMethod);
            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);
                ActivityLogs_DataGrid.DataSource = dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Clear All Activity Logs ?", "Activity Logs", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(result == DialogResult.Yes)
            {
                DeleteActivityLogs();
                ShowActivityLogs();
                
            }
            
        }

        private void btn_restore_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Restore All Activity Logs ?", "Activity Logs", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                RestoreActivityLogs();
                ShowActivityLogs();

            }
           
        }

        private void DeleteActivityLogs()
        {
            SqlCommand cmd = new SqlCommand(
                "UPDATE ActivityLogs SET Status = 'DELETED' ", sqlcon);
            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                cmd.ExecuteNonQuery();

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            sqlcon.Close();
        }

        private void RestoreActivityLogs()
        {
            SqlCommand cmd = new SqlCommand(
                "UPDATE ActivityLogs SET Status = 'OK' ", sqlcon);
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
    }
}
