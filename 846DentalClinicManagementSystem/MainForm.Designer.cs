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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.btn_Reminder = new System.Windows.Forms.Button();
            this.btn_Home = new System.Windows.Forms.Button();
            this.btn_Patients = new System.Windows.Forms.Button();
            this.btn_Accounting = new System.Windows.Forms.Button();
            this.btn_Scheduler = new System.Windows.Forms.Button();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.CenterPanel = new System.Windows.Forms.Panel();
            this.ReminderPanel = new System.Windows.Forms.Panel();
            this.PatientsPanel = new System.Windows.Forms.Panel();
            this.AccountingPanel = new System.Windows.Forms.Panel();
            this.SchedulerPanel = new System.Windows.Forms.Panel();
            this.HomePanel = new System.Windows.Forms.Panel();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.MenuPanel.SuspendLayout();
            this.CenterPanel.SuspendLayout();
            this.HomePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.Color.Yellow;
            this.MenuPanel.Controls.Add(this.button6);
            this.MenuPanel.Controls.Add(this.btn_Reminder);
            this.MenuPanel.Controls.Add(this.btn_Home);
            this.MenuPanel.Controls.Add(this.btn_Patients);
            this.MenuPanel.Controls.Add(this.btn_Accounting);
            this.MenuPanel.Controls.Add(this.btn_Scheduler);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(311, 733);
            this.MenuPanel.TabIndex = 1;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.OliveDrab;
            this.button6.Enabled = false;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Lucida Bright", 18F, System.Drawing.FontStyle.Bold);
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(0, 538);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(311, 121);
            this.button6.TabIndex = 3;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // btn_Reminder
            // 
            this.btn_Reminder.BackColor = System.Drawing.Color.OliveDrab;
            this.btn_Reminder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Reminder.Font = new System.Drawing.Font("Lucida Bright", 18F, System.Drawing.FontStyle.Bold);
            this.btn_Reminder.Image = global::_846DentalClinicManagementSystem.Properties.Resources.btnreminders;
            this.btn_Reminder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Reminder.Location = new System.Drawing.Point(0, 437);
            this.btn_Reminder.Name = "btn_Reminder";
            this.btn_Reminder.Size = new System.Drawing.Size(311, 101);
            this.btn_Reminder.TabIndex = 0;
            this.btn_Reminder.Text = "REMINDERS";
            this.btn_Reminder.UseVisualStyleBackColor = false;
            this.btn_Reminder.Click += new System.EventHandler(this.btn_Reminder_Click);
            // 
            // btn_Home
            // 
            this.btn_Home.BackColor = System.Drawing.Color.OliveDrab;
            this.btn_Home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Home.Font = new System.Drawing.Font("Lucida Bright", 18F, System.Drawing.FontStyle.Bold);
            this.btn_Home.Image = global::_846DentalClinicManagementSystem.Properties.Resources.btnhome;
            this.btn_Home.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Home.Location = new System.Drawing.Point(0, 47);
            this.btn_Home.Name = "btn_Home";
            this.btn_Home.Size = new System.Drawing.Size(311, 93);
            this.btn_Home.TabIndex = 2;
            this.btn_Home.Text = "HOME";
            this.btn_Home.UseVisualStyleBackColor = false;
            this.btn_Home.Click += new System.EventHandler(this.btn_Home_Click);
            // 
            // btn_Patients
            // 
            this.btn_Patients.BackColor = System.Drawing.Color.OliveDrab;
            this.btn_Patients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Patients.Font = new System.Drawing.Font("Lucida Bright", 18F, System.Drawing.FontStyle.Bold);
            this.btn_Patients.Image = global::_846DentalClinicManagementSystem.Properties.Resources.btnpatients;
            this.btn_Patients.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Patients.Location = new System.Drawing.Point(0, 341);
            this.btn_Patients.Name = "btn_Patients";
            this.btn_Patients.Size = new System.Drawing.Size(311, 96);
            this.btn_Patients.TabIndex = 0;
            this.btn_Patients.Text = "PATIENTS";
            this.btn_Patients.UseVisualStyleBackColor = false;
            this.btn_Patients.Click += new System.EventHandler(this.btn_Patients_Click);
            // 
            // btn_Accounting
            // 
            this.btn_Accounting.BackColor = System.Drawing.Color.OliveDrab;
            this.btn_Accounting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Accounting.Font = new System.Drawing.Font("Lucida Bright", 18F, System.Drawing.FontStyle.Bold);
            this.btn_Accounting.Image = global::_846DentalClinicManagementSystem.Properties.Resources.btninventory;
            this.btn_Accounting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Accounting.Location = new System.Drawing.Point(-2, 241);
            this.btn_Accounting.Name = "btn_Accounting";
            this.btn_Accounting.Size = new System.Drawing.Size(313, 100);
            this.btn_Accounting.TabIndex = 1;
            this.btn_Accounting.Text = "ACCOUNTING";
            this.btn_Accounting.UseVisualStyleBackColor = false;
            this.btn_Accounting.Click += new System.EventHandler(this.btn_Accounting_Click);
            // 
            // btn_Scheduler
            // 
            this.btn_Scheduler.BackColor = System.Drawing.Color.OliveDrab;
            this.btn_Scheduler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Scheduler.Font = new System.Drawing.Font("Lucida Bright", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Scheduler.Image = global::_846DentalClinicManagementSystem.Properties.Resources.btnscheduler__2_;
            this.btn_Scheduler.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Scheduler.Location = new System.Drawing.Point(0, 140);
            this.btn_Scheduler.Name = "btn_Scheduler";
            this.btn_Scheduler.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_Scheduler.Size = new System.Drawing.Size(311, 101);
            this.btn_Scheduler.TabIndex = 0;
            this.btn_Scheduler.Text = "SCHEDULER";
            this.btn_Scheduler.UseVisualStyleBackColor = false;
            this.btn_Scheduler.Click += new System.EventHandler(this.btn_Scheduler_Click);
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.Yellow;
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(311, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1043, 46);
            this.TopPanel.TabIndex = 2;
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.Yellow;
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(311, 687);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(1043, 46);
            this.BottomPanel.TabIndex = 3;
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
            this.CenterPanel.Location = new System.Drawing.Point(311, 46);
            this.CenterPanel.Name = "CenterPanel";
            this.CenterPanel.Size = new System.Drawing.Size(1043, 641);
            this.CenterPanel.TabIndex = 4;
            // 
            // ReminderPanel
            // 
            this.ReminderPanel.BackColor = System.Drawing.Color.Aqua;
            this.ReminderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReminderPanel.Location = new System.Drawing.Point(0, 0);
            this.ReminderPanel.Name = "ReminderPanel";
            this.ReminderPanel.Size = new System.Drawing.Size(1043, 641);
            this.ReminderPanel.TabIndex = 3;
            // 
            // PatientsPanel
            // 
            this.PatientsPanel.BackColor = System.Drawing.Color.Aquamarine;
            this.PatientsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PatientsPanel.Location = new System.Drawing.Point(0, 0);
            this.PatientsPanel.Name = "PatientsPanel";
            this.PatientsPanel.Size = new System.Drawing.Size(1043, 641);
            this.PatientsPanel.TabIndex = 2;
            // 
            // AccountingPanel
            // 
            this.AccountingPanel.BackColor = System.Drawing.Color.Aquamarine;
            this.AccountingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AccountingPanel.Location = new System.Drawing.Point(0, 0);
            this.AccountingPanel.Name = "AccountingPanel";
            this.AccountingPanel.Size = new System.Drawing.Size(1043, 641);
            this.AccountingPanel.TabIndex = 1;
            // 
            // SchedulerPanel
            // 
            this.SchedulerPanel.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.SchedulerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SchedulerPanel.Location = new System.Drawing.Point(0, 0);
            this.SchedulerPanel.Name = "SchedulerPanel";
            this.SchedulerPanel.Size = new System.Drawing.Size(1043, 641);
            this.SchedulerPanel.TabIndex = 0;
            // 
            // HomePanel
            // 
            this.HomePanel.BackColor = System.Drawing.Color.SpringGreen;
            this.HomePanel.Controls.Add(this.axWindowsMediaPlayer1);
            this.HomePanel.Location = new System.Drawing.Point(0, 0);
            this.HomePanel.Name = "HomePanel";
            this.HomePanel.Size = new System.Drawing.Size(1058, 641);
            this.HomePanel.TabIndex = 1;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(38, 40);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(983, 554);
            this.axWindowsMediaPlayer1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.CenterPanel);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.MenuPanel);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "846 Dental Clinic";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MenuPanel.ResumeLayout(false);
            this.CenterPanel.ResumeLayout(false);
            this.HomePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Button btn_Reminder;
        private System.Windows.Forms.Button btn_Home;
        private System.Windows.Forms.Button btn_Patients;
        private System.Windows.Forms.Button btn_Accounting;
        private System.Windows.Forms.Button btn_Scheduler;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Panel CenterPanel;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel SchedulerPanel;
        private System.Windows.Forms.Panel ReminderPanel;
        private System.Windows.Forms.Panel PatientsPanel;
        private System.Windows.Forms.Panel AccountingPanel;
        private System.Windows.Forms.Panel HomePanel;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}