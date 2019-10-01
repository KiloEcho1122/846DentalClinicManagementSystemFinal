namespace _846DentalClinicManagementSystem
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.CenterPanel = new System.Windows.Forms.Panel();
            this.SchedulerPanel = new System.Windows.Forms.Panel();
            this.HomePanel = new System.Windows.Forms.Panel();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.ReminderPanel = new System.Windows.Forms.Panel();
            this.PatientsPanel = new System.Windows.Forms.Panel();
            this.AccountingPanel = new System.Windows.Forms.Panel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btn_Reminder = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_Accounting = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_Patients = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_Scheduler = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_Home = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.MenuPanel.SuspendLayout();
            this.TopPanel.SuspendLayout();
            this.CenterPanel.SuspendLayout();
            this.HomePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(82)))), ((int)(((byte)(121)))));
            this.MenuPanel.Controls.Add(this.btn_Reminder);
            this.MenuPanel.Controls.Add(this.btn_Accounting);
            this.MenuPanel.Controls.Add(this.btn_Patients);
            this.MenuPanel.Controls.Add(this.btn_Scheduler);
            this.MenuPanel.Controls.Add(this.btn_Home);
            this.MenuPanel.Controls.Add(this.pictureBox1);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuPanel.Location = new System.Drawing.Point(0, 63);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(246, 670);
            this.MenuPanel.TabIndex = 1;
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(85)))), ((int)(((byte)(120)))));
            this.TopPanel.Controls.Add(this.bunifuCustomLabel1);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1354, 63);
            this.TopPanel.TabIndex = 2;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(1323, 9);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(19, 21);
            this.bunifuCustomLabel1.TabIndex = 0;
            this.bunifuCustomLabel1.Text = "X";
            this.bunifuCustomLabel1.Click += new System.EventHandler(this.bunifuCustomLabel1_Click);
            // 
            // CenterPanel
            // 
            this.CenterPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CenterPanel.Controls.Add(this.HomePanel);
            this.CenterPanel.Controls.Add(this.ReminderPanel);
            this.CenterPanel.Controls.Add(this.PatientsPanel);
            this.CenterPanel.Controls.Add(this.AccountingPanel);
            this.CenterPanel.Controls.Add(this.SchedulerPanel);
            this.CenterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterPanel.Location = new System.Drawing.Point(0, 63);
            this.CenterPanel.Name = "CenterPanel";
            this.CenterPanel.Size = new System.Drawing.Size(1354, 670);
            this.CenterPanel.TabIndex = 4;
            // 
            // SchedulerPanel
            // 
            this.SchedulerPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.SchedulerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SchedulerPanel.Location = new System.Drawing.Point(0, 0);
            this.SchedulerPanel.Name = "SchedulerPanel";
            this.SchedulerPanel.Size = new System.Drawing.Size(1354, 670);
            this.SchedulerPanel.TabIndex = 0;
            // 
            // HomePanel
            // 
            this.HomePanel.BackColor = System.Drawing.Color.Gainsboro;
            this.HomePanel.Controls.Add(this.panel5);
            this.HomePanel.Controls.Add(this.panel3);
            this.HomePanel.Controls.Add(this.panel1);
            this.HomePanel.Controls.Add(this.axWindowsMediaPlayer1);
            this.HomePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HomePanel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomePanel.Location = new System.Drawing.Point(0, 0);
            this.HomePanel.Name = "HomePanel";
            this.HomePanel.Size = new System.Drawing.Size(1354, 670);
            this.HomePanel.TabIndex = 1;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(493, 63);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(835, 532);
            this.axWindowsMediaPlayer1.TabIndex = 1;
            // 
            // ReminderPanel
            // 
            this.ReminderPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.ReminderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReminderPanel.Location = new System.Drawing.Point(0, 0);
            this.ReminderPanel.Name = "ReminderPanel";
            this.ReminderPanel.Size = new System.Drawing.Size(1354, 670);
            this.ReminderPanel.TabIndex = 3;
            // 
            // PatientsPanel
            // 
            this.PatientsPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.PatientsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PatientsPanel.Location = new System.Drawing.Point(0, 0);
            this.PatientsPanel.Name = "PatientsPanel";
            this.PatientsPanel.Size = new System.Drawing.Size(1354, 670);
            this.PatientsPanel.TabIndex = 2;
            // 
            // AccountingPanel
            // 
            this.AccountingPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.AccountingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AccountingPanel.Location = new System.Drawing.Point(0, 0);
            this.AccountingPanel.Name = "AccountingPanel";
            this.AccountingPanel.Size = new System.Drawing.Size(1354, 670);
            this.AccountingPanel.TabIndex = 1;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.TopPanel;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuDragControl2
            // 
            this.bunifuDragControl2.Fixed = true;
            this.bunifuDragControl2.Horizontal = true;
            this.bunifuDragControl2.TargetControl = this.TopPanel;
            this.bunifuDragControl2.Vertical = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(277, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(187, 179);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(54)))), ((int)(((byte)(79)))));
            this.panel2.Controls.Add(this.bunifuCustomLabel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 122);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(187, 57);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(277, 240);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(187, 179);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(54)))), ((int)(((byte)(79)))));
            this.panel4.Controls.Add(this.bunifuCustomLabel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.ForeColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(0, 122);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(187, 57);
            this.panel4.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel5.Controls.Add(this.pictureBox4);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(277, 446);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(187, 179);
            this.panel5.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(54)))), ((int)(((byte)(79)))));
            this.panel6.Controls.Add(this.bunifuCustomLabel4);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.ForeColor = System.Drawing.Color.White;
            this.panel6.Location = new System.Drawing.Point(0, 122);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(187, 57);
            this.panel6.TabIndex = 0;
            // 
            // btn_Reminder
            // 
            this.btn_Reminder.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(107)))), ((int)(((byte)(255)))));
            this.btn_Reminder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(82)))), ((int)(((byte)(121)))));
            this.btn_Reminder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Reminder.BorderRadius = 0;
            this.btn_Reminder.ButtonText = "     Reminders";
            this.btn_Reminder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Reminder.DisabledColor = System.Drawing.Color.Gray;
            this.btn_Reminder.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_Reminder.Iconimage = global::_846DentalClinicManagementSystem.Properties.Resources.btnreminders;
            this.btn_Reminder.Iconimage_right = null;
            this.btn_Reminder.Iconimage_right_Selected = null;
            this.btn_Reminder.Iconimage_Selected = null;
            this.btn_Reminder.IconMarginLeft = 0;
            this.btn_Reminder.IconMarginRight = 0;
            this.btn_Reminder.IconRightVisible = true;
            this.btn_Reminder.IconRightZoom = 0D;
            this.btn_Reminder.IconVisible = true;
            this.btn_Reminder.IconZoom = 65D;
            this.btn_Reminder.IsTab = true;
            this.btn_Reminder.Location = new System.Drawing.Point(0, 485);
            this.btn_Reminder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_Reminder.Name = "btn_Reminder";
            this.btn_Reminder.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(82)))), ((int)(((byte)(121)))));
            this.btn_Reminder.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(82)))), ((int)(((byte)(121)))));
            this.btn_Reminder.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(107)))), ((int)(((byte)(255)))));
            this.btn_Reminder.selected = false;
            this.btn_Reminder.Size = new System.Drawing.Size(246, 90);
            this.btn_Reminder.TabIndex = 28;
            this.btn_Reminder.Text = "     Reminders";
            this.btn_Reminder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Reminder.Textcolor = System.Drawing.Color.Silver;
            this.btn_Reminder.TextFont = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reminder.Click += new System.EventHandler(this.btn_Reminder_Click);
            // 
            // btn_Accounting
            // 
            this.btn_Accounting.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(107)))), ((int)(((byte)(255)))));
            this.btn_Accounting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(82)))), ((int)(((byte)(121)))));
            this.btn_Accounting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Accounting.BorderRadius = 0;
            this.btn_Accounting.ButtonText = "     Accounting";
            this.btn_Accounting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Accounting.DisabledColor = System.Drawing.Color.Gray;
            this.btn_Accounting.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_Accounting.Iconimage = global::_846DentalClinicManagementSystem.Properties.Resources.btninventory;
            this.btn_Accounting.Iconimage_right = null;
            this.btn_Accounting.Iconimage_right_Selected = null;
            this.btn_Accounting.Iconimage_Selected = null;
            this.btn_Accounting.IconMarginLeft = 0;
            this.btn_Accounting.IconMarginRight = 0;
            this.btn_Accounting.IconRightVisible = true;
            this.btn_Accounting.IconRightZoom = 0D;
            this.btn_Accounting.IconVisible = true;
            this.btn_Accounting.IconZoom = 65D;
            this.btn_Accounting.IsTab = true;
            this.btn_Accounting.Location = new System.Drawing.Point(0, 396);
            this.btn_Accounting.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_Accounting.Name = "btn_Accounting";
            this.btn_Accounting.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(82)))), ((int)(((byte)(121)))));
            this.btn_Accounting.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(82)))), ((int)(((byte)(121)))));
            this.btn_Accounting.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(107)))), ((int)(((byte)(255)))));
            this.btn_Accounting.selected = false;
            this.btn_Accounting.Size = new System.Drawing.Size(246, 90);
            this.btn_Accounting.TabIndex = 27;
            this.btn_Accounting.Text = "     Accounting";
            this.btn_Accounting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Accounting.Textcolor = System.Drawing.Color.Silver;
            this.btn_Accounting.TextFont = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Accounting.Click += new System.EventHandler(this.btn_Accounting_Click);
            // 
            // btn_Patients
            // 
            this.btn_Patients.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(107)))), ((int)(((byte)(255)))));
            this.btn_Patients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(82)))), ((int)(((byte)(121)))));
            this.btn_Patients.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Patients.BorderRadius = 0;
            this.btn_Patients.ButtonText = "     Patients";
            this.btn_Patients.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Patients.DisabledColor = System.Drawing.Color.Gray;
            this.btn_Patients.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_Patients.Iconimage = global::_846DentalClinicManagementSystem.Properties.Resources.btnpatients;
            this.btn_Patients.Iconimage_right = null;
            this.btn_Patients.Iconimage_right_Selected = null;
            this.btn_Patients.Iconimage_Selected = null;
            this.btn_Patients.IconMarginLeft = 0;
            this.btn_Patients.IconMarginRight = 0;
            this.btn_Patients.IconRightVisible = true;
            this.btn_Patients.IconRightZoom = 0D;
            this.btn_Patients.IconVisible = true;
            this.btn_Patients.IconZoom = 65D;
            this.btn_Patients.IsTab = true;
            this.btn_Patients.Location = new System.Drawing.Point(0, 307);
            this.btn_Patients.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_Patients.Name = "btn_Patients";
            this.btn_Patients.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(82)))), ((int)(((byte)(121)))));
            this.btn_Patients.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(82)))), ((int)(((byte)(121)))));
            this.btn_Patients.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(107)))), ((int)(((byte)(255)))));
            this.btn_Patients.selected = false;
            this.btn_Patients.Size = new System.Drawing.Size(246, 90);
            this.btn_Patients.TabIndex = 26;
            this.btn_Patients.Text = "     Patients";
            this.btn_Patients.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Patients.Textcolor = System.Drawing.Color.Silver;
            this.btn_Patients.TextFont = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Patients.Click += new System.EventHandler(this.btn_Patients_Click);
            // 
            // btn_Scheduler
            // 
            this.btn_Scheduler.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(107)))), ((int)(((byte)(255)))));
            this.btn_Scheduler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(82)))), ((int)(((byte)(121)))));
            this.btn_Scheduler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Scheduler.BorderRadius = 0;
            this.btn_Scheduler.ButtonText = "     Scheduler";
            this.btn_Scheduler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Scheduler.DisabledColor = System.Drawing.Color.Gray;
            this.btn_Scheduler.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_Scheduler.Iconimage = global::_846DentalClinicManagementSystem.Properties.Resources.btnscheduler__2_;
            this.btn_Scheduler.Iconimage_right = null;
            this.btn_Scheduler.Iconimage_right_Selected = null;
            this.btn_Scheduler.Iconimage_Selected = null;
            this.btn_Scheduler.IconMarginLeft = 0;
            this.btn_Scheduler.IconMarginRight = 0;
            this.btn_Scheduler.IconRightVisible = true;
            this.btn_Scheduler.IconRightZoom = 0D;
            this.btn_Scheduler.IconVisible = true;
            this.btn_Scheduler.IconZoom = 65D;
            this.btn_Scheduler.IsTab = true;
            this.btn_Scheduler.Location = new System.Drawing.Point(0, 218);
            this.btn_Scheduler.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_Scheduler.Name = "btn_Scheduler";
            this.btn_Scheduler.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(82)))), ((int)(((byte)(121)))));
            this.btn_Scheduler.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(82)))), ((int)(((byte)(121)))));
            this.btn_Scheduler.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(107)))), ((int)(((byte)(255)))));
            this.btn_Scheduler.selected = false;
            this.btn_Scheduler.Size = new System.Drawing.Size(246, 90);
            this.btn_Scheduler.TabIndex = 25;
            this.btn_Scheduler.Text = "     Scheduler";
            this.btn_Scheduler.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Scheduler.Textcolor = System.Drawing.Color.Silver;
            this.btn_Scheduler.TextFont = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Scheduler.Click += new System.EventHandler(this.btn_Scheduler_Click);
            // 
            // btn_Home
            // 
            this.btn_Home.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(107)))), ((int)(((byte)(255)))));
            this.btn_Home.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(82)))), ((int)(((byte)(121)))));
            this.btn_Home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Home.BorderRadius = 0;
            this.btn_Home.ButtonText = "     Dashboard";
            this.btn_Home.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Home.DisabledColor = System.Drawing.Color.Gray;
            this.btn_Home.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_Home.Iconimage = global::_846DentalClinicManagementSystem.Properties.Resources.btnhome;
            this.btn_Home.Iconimage_right = null;
            this.btn_Home.Iconimage_right_Selected = null;
            this.btn_Home.Iconimage_Selected = null;
            this.btn_Home.IconMarginLeft = 0;
            this.btn_Home.IconMarginRight = 0;
            this.btn_Home.IconRightVisible = true;
            this.btn_Home.IconRightZoom = 0D;
            this.btn_Home.IconVisible = true;
            this.btn_Home.IconZoom = 65D;
            this.btn_Home.IsTab = true;
            this.btn_Home.Location = new System.Drawing.Point(0, 129);
            this.btn_Home.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_Home.Name = "btn_Home";
            this.btn_Home.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(82)))), ((int)(((byte)(121)))));
            this.btn_Home.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(82)))), ((int)(((byte)(121)))));
            this.btn_Home.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(107)))), ((int)(((byte)(255)))));
            this.btn_Home.selected = false;
            this.btn_Home.Size = new System.Drawing.Size(246, 90);
            this.btn_Home.TabIndex = 24;
            this.btn_Home.Text = "     Dashboard";
            this.btn_Home.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Home.Textcolor = System.Drawing.Color.Silver;
            this.btn_Home.TextFont = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Home.Click += new System.EventHandler(this.btn_Home_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::_846DentalClinicManagementSystem.Properties.Resources.download;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(246, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::_846DentalClinicManagementSystem.Properties.Resources.scheduler1;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(36, 23);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(109, 77);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::_846DentalClinicManagementSystem.Properties.Resources.scheduler1;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(44, 23);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(109, 77);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::_846DentalClinicManagementSystem.Properties.Resources.scheduler1;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(41, 23);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(109, 77);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(16, 10);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(111, 17);
            this.bunifuCustomLabel2.TabIndex = 0;
            this.bunifuCustomLabel2.Text = "Appointments :  8";
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(14, 10);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(108, 17);
            this.bunifuCustomLabel3.TabIndex = 1;
            this.bunifuCustomLabel3.Text = "Active Dentist :  2";
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(12, 10);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(82, 17);
            this.bunifuCustomLabel4.TabIndex = 5;
            this.bunifuCustomLabel4.Text = "Patients :  27";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.MenuPanel);
            this.Controls.Add(this.CenterPanel);
            this.Controls.Add(this.TopPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "846 Dental Clinic";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MenuPanel.ResumeLayout(false);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.CenterPanel.ResumeLayout(false);
            this.HomePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel CenterPanel;
        private System.Windows.Forms.Panel SchedulerPanel;
        private System.Windows.Forms.Panel ReminderPanel;
        private System.Windows.Forms.Panel PatientsPanel;
        private System.Windows.Forms.Panel AccountingPanel;
        private System.Windows.Forms.Panel HomePanel;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private Bunifu.Framework.UI.BunifuFlatButton btn_Home;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuFlatButton btn_Scheduler;
        private Bunifu.Framework.UI.BunifuFlatButton btn_Reminder;
        private Bunifu.Framework.UI.BunifuFlatButton btn_Accounting;
        private Bunifu.Framework.UI.BunifuFlatButton btn_Patients;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
    }
}