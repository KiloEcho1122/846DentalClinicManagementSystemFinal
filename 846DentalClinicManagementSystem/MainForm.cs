﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
        
        SqlConnection sqlcon = new SqlConnection(GlobalVariable.connString);
        List<Panel> Panels = new List<Panel>();
        string[,] timeArray = new string[19,2];

        private void HidePanels()
        {
            HomePanel.Visible = false;
            PatientsPanel.Visible = false;
            AccountingPanel.Visible = false;
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
            timer1.Enabled = true;
            Loadusername();
            HidePanels();
            HomePanel.Visible = true;
            playVideo();
            iniatializeTimeArray();
            setTimelabel();
            DrawAppointmentTable();
            SearchAppByDate_DP.Value = DateTime.Now;
            PatientPanelSearch("");
            setAutoScrollfalse();
        }

        private void Loadusername()
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT CONCAT(FName, ' ', LName) FROM Login WHERE LoginID = @LoginID", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@LoginID", GlobalVariable.LoginID);
            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                if (cmd.ExecuteScalar() != null) lbl_userName.Text = cmd.ExecuteScalar().ToString();

            }
            catch(Exception e)
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
            LoadMonthlyProfit();
            LoadMonthlyExpenses();
            LoadGrossProfit();
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
                timeLabel.Location = new Point(50, horizontalY - 15);
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
                TimePanel_Footer.Visible = false;
                AppTimePanel.Size = new Size(184, 463);
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
                    verticalX += 300;
                    this.Appointment_Panel.Controls.Add(verticalPanel);
                }


                Panel panel = new Panel();
                panel.Size = new Size(2150, 45);
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
                    aira.Location = new Point(loc, 45);
                    aira.Size = new Size(161, 20);
                    aira.Margin = new Padding(0);
                    
                    if (i % 2 == 0)
                    {
                        aira.BackColor = Color.PaleTurquoise;
                    }
                    else
                    {
                        aira.BackColor = Color.Pink;
                    }
                    if(i == 12) aira.Size = new Size(176, 20);
                    if (i == 13)
                    {
                        aira.Location = new Point(loc + 15, 45);
                       
                    }

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
                    addEditPatient.Show();

                }
            }
            
        }



        //-------------------------------------------------------------------------------------------------
        // Inventory


        private void btn_AddExpenses_Click(object sender, EventArgs e)
        {
            if (GlobalVariable.isAddExpense == false)
            {
                GlobalVariable.isAddExpense = true;
                AddExpensescs addExpensescs = new AddExpensescs();
                addExpensescs.Show();
            }

        }
        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {
            LoadMonthlyProfit();
            LoadMonthlyExpenses();
            LoadGrossProfit();
        }

        private void LoadMonthlyProfit()
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


            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        private float LoadNetProfit(DateTime firstDayOfMonth, DateTime lastDayOfMonth)
        {
            float output = 0;
            foreach (DataGridViewRow row in Profit_DG.Rows)
            {
                float.TryParse(row.Cells[2].Value.ToString(), out float amt);
                output += amt;
            }

            return output;
        }

        private float LoadNetExpense(DateTime firstDayOfMonth, DateTime lastDayOfMonth)
        {
            float output = 0;
            foreach(DataGridViewRow row in displayExpenseDG.Rows)
            {
                float.TryParse(row.Cells[3].Value.ToString(), out float amt);
                output += amt;
            }
           
            return output;
        }

        public void LoadGrossProfit()
        {
            DateTime date = Inventory_DatePicker.Value;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddSeconds(-1);
            float netProfit = LoadNetProfit(firstDayOfMonth, lastDayOfMonth);
            float netExpense = LoadNetExpense(firstDayOfMonth, lastDayOfMonth);
            float grossProfit = netProfit - netExpense;

            lbl_netProfit.Text = netProfit.ToString();
            lbl_netExpense.Text = netExpense.ToString();
            lbl_GrossProfit.Text = grossProfit.ToString();

        }


        public void LoadMonthlyExpenses()
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
                

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void displayExpenseDG_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
         
            GlobalVariable.ExpenseId = Convert.ToInt32(displayExpenseDG.SelectedRows[0].Cells[0].Value);
            if(GlobalVariable.isEditExpense == false)
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

        // Patient Panel End --------------------------------------------------------------------------------------------------------


    }
}
