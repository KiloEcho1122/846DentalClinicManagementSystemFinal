﻿namespace _846DentalClinicManagementSystem
{
    partial class AddAppointment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAppointment));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.TopPanel2 = new System.Windows.Forms.Panel();
            this.lbl_Close = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txt_formHeader = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.AppSearch_DataGrid = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.DentistDD = new Bunifu.Framework.UI.BunifuDropdown();
            this.TimeDD = new Bunifu.Framework.UI.BunifuDropdown();
            this.DP_date = new Bunifu.Framework.UI.BunifuDatepicker();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel6 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel7 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txt_Note = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuCustomLabel8 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel9 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel10 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txt_LName = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.txt_FName = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.txt_MName = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.lbl_AppNo = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.Treatment_CB = new System.Windows.Forms.ComboBox();
            this.TreatmentList = new System.Windows.Forms.ListBox();
            this.bunifuCustomLabel5 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblContact = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txt_ContactNo = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TreatmentDropDownPanel = new System.Windows.Forms.Panel();
            this.statusSwitch = new Bunifu.Framework.UI.BunifuiOSSwitch();
            this.btn_RemoveItem = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_CreateBilling = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_CancelApp = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_add = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_PatientSearch = new Bunifu.Framework.UI.BunifuThinButton2();
            this.txt_PatientSearch = new Bunifu.Framework.UI.BunifuTextbox();
            this.TopPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppSearch_DataGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.TreatmentDropDownPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // TopPanel2
            // 
            this.TopPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.TopPanel2.Controls.Add(this.lbl_Close);
            this.TopPanel2.Controls.Add(this.txt_formHeader);
            this.TopPanel2.Controls.Add(this.pictureBox5);
            this.TopPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel2.Location = new System.Drawing.Point(0, 0);
            this.TopPanel2.Name = "TopPanel2";
            this.TopPanel2.Size = new System.Drawing.Size(790, 45);
            this.TopPanel2.TabIndex = 0;
            this.TopPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.TopPanel2_Paint);
            // 
            // lbl_Close
            // 
            this.lbl_Close.AutoSize = true;
            this.lbl_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Close.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Close.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl_Close.Location = new System.Drawing.Point(753, 7);
            this.lbl_Close.Name = "lbl_Close";
            this.lbl_Close.Size = new System.Drawing.Size(16, 17);
            this.lbl_Close.TabIndex = 43;
            this.lbl_Close.Text = "X";
            this.lbl_Close.Click += new System.EventHandler(this.lbl_Close_Click);
            // 
            // txt_formHeader
            // 
            this.txt_formHeader.AutoSize = true;
            this.txt_formHeader.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_formHeader.ForeColor = System.Drawing.Color.White;
            this.txt_formHeader.Location = new System.Drawing.Point(53, 10);
            this.txt_formHeader.Name = "txt_formHeader";
            this.txt_formHeader.Size = new System.Drawing.Size(233, 22);
            this.txt_formHeader.TabIndex = 3;
            this.txt_formHeader.Text = "Add New Appointments";
            this.txt_formHeader.Click += new System.EventHandler(this.txt_formHeader_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(9, 7);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 28);
            this.pictureBox5.TabIndex = 2;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.Teal;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(18, 48);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(101, 17);
            this.bunifuCustomLabel1.TabIndex = 5;
            this.bunifuCustomLabel1.Text = "Search Patient";
            this.bunifuCustomLabel1.Click += new System.EventHandler(this.bunifuCustomLabel1_Click);
            // 
            // AppSearch_DataGrid
            // 
            this.AppSearch_DataGrid.AllowUserToAddRows = false;
            this.AppSearch_DataGrid.AllowUserToDeleteRows = false;
            this.AppSearch_DataGrid.AllowUserToResizeColumns = false;
            this.AppSearch_DataGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.AppSearch_DataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.AppSearch_DataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AppSearch_DataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.AppSearch_DataGrid.BackgroundColor = System.Drawing.Color.White;
            this.AppSearch_DataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AppSearch_DataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AppSearch_DataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.AppSearch_DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AppSearch_DataGrid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AppSearch_DataGrid.DoubleBuffered = true;
            this.AppSearch_DataGrid.EnableHeadersVisualStyles = false;
            this.AppSearch_DataGrid.HeaderBgColor = System.Drawing.Color.LemonChiffon;
            this.AppSearch_DataGrid.HeaderForeColor = System.Drawing.Color.Black;
            this.AppSearch_DataGrid.Location = new System.Drawing.Point(45, 112);
            this.AppSearch_DataGrid.MultiSelect = false;
            this.AppSearch_DataGrid.Name = "AppSearch_DataGrid";
            this.AppSearch_DataGrid.ReadOnly = true;
            this.AppSearch_DataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(214)))), ((int)(((byte)(132)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AppSearch_DataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(214)))), ((int)(((byte)(132)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.AppSearch_DataGrid.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.AppSearch_DataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AppSearch_DataGrid.Size = new System.Drawing.Size(723, 65);
            this.AppSearch_DataGrid.TabIndex = 6;
            this.AppSearch_DataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AppSearch_DataGrid_CellClick);
            this.AppSearch_DataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AppSearch_DataGrid_CellContentClick);
            // 
            // DentistDD
            // 
            this.DentistDD.BackColor = System.Drawing.Color.Transparent;
            this.DentistDD.BorderRadius = 3;
            this.DentistDD.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DentistDD.ForeColor = System.Drawing.Color.White;
            this.DentistDD.Items = new string[0];
            this.DentistDD.Location = new System.Drawing.Point(37, 286);
            this.DentistDD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DentistDD.Name = "DentistDD";
            this.DentistDD.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.DentistDD.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.DentistDD.selectedIndex = -1;
            this.DentistDD.Size = new System.Drawing.Size(162, 53);
            this.DentistDD.TabIndex = 6;
            this.DentistDD.onItemSelected += new System.EventHandler(this.DentistDD_onItemSelected);
            // 
            // TimeDD
            // 
            this.TimeDD.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.TimeDD.BorderRadius = 3;
            this.TimeDD.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeDD.ForeColor = System.Drawing.Color.White;
            this.TimeDD.Items = new string[] {
        "09:00 AM",
        "09:30 AM",
        "10:00 AM",
        "10:30 AM",
        "11:00 AM",
        "11:30 AM",
        "12:00 PM",
        "12:30 PM",
        "01:00 PM",
        "01:30 PM",
        "02:00 PM",
        "02:30 PM",
        "03:00 PM",
        "03:30 PM",
        "04:00 PM",
        "04:30 PM",
        "05:00 PM"};
            this.TimeDD.Location = new System.Drawing.Point(415, 286);
            this.TimeDD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TimeDD.Name = "TimeDD";
            this.TimeDD.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.TimeDD.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.TimeDD.selectedIndex = -1;
            this.TimeDD.Size = new System.Drawing.Size(162, 53);
            this.TimeDD.TabIndex = 7;
            this.TimeDD.onItemSelected += new System.EventHandler(this.TimeDD_onItemSelected);
            // 
            // DP_date
            // 
            this.DP_date.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.DP_date.BorderRadius = 0;
            this.DP_date.ForeColor = System.Drawing.Color.White;
            this.DP_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DP_date.FormatCustom = "dddd, MMMM dd  yyyy";
            this.DP_date.Location = new System.Drawing.Point(217, 286);
            this.DP_date.Name = "DP_date";
            this.DP_date.Size = new System.Drawing.Size(182, 53);
            this.DP_date.TabIndex = 8;
            this.DP_date.Value = new System.DateTime(2019, 10, 8, 0, 17, 0, 47);
            this.DP_date.onValueChanged += new System.EventHandler(this.DP_date_onValueChanged);
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.Teal;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(605, 185);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(73, 17);
            this.bunifuCustomLabel2.TabIndex = 11;
            this.bunifuCustomLabel2.Text = "Treatment";
            this.bunifuCustomLabel2.Click += new System.EventHandler(this.bunifuCustomLabel2_Click);
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.Teal;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(38, 266);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(52, 17);
            this.bunifuCustomLabel3.TabIndex = 12;
            this.bunifuCustomLabel3.Text = "Dentist";
            this.bunifuCustomLabel3.Click += new System.EventHandler(this.bunifuCustomLabel3_Click);
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel4.ForeColor = System.Drawing.Color.Teal;
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(214, 266);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(40, 17);
            this.bunifuCustomLabel4.TabIndex = 13;
            this.bunifuCustomLabel4.Text = "Date";
            this.bunifuCustomLabel4.Click += new System.EventHandler(this.bunifuCustomLabel4_Click);
            // 
            // bunifuCustomLabel6
            // 
            this.bunifuCustomLabel6.AutoSize = true;
            this.bunifuCustomLabel6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel6.ForeColor = System.Drawing.Color.Teal;
            this.bunifuCustomLabel6.Location = new System.Drawing.Point(417, 266);
            this.bunifuCustomLabel6.Name = "bunifuCustomLabel6";
            this.bunifuCustomLabel6.Size = new System.Drawing.Size(37, 17);
            this.bunifuCustomLabel6.TabIndex = 14;
            this.bunifuCustomLabel6.Text = "Time";
            this.bunifuCustomLabel6.Click += new System.EventHandler(this.bunifuCustomLabel6_Click);
            // 
            // bunifuCustomLabel7
            // 
            this.bunifuCustomLabel7.AutoSize = true;
            this.bunifuCustomLabel7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel7.ForeColor = System.Drawing.Color.Teal;
            this.bunifuCustomLabel7.Location = new System.Drawing.Point(216, 360);
            this.bunifuCustomLabel7.Name = "bunifuCustomLabel7";
            this.bunifuCustomLabel7.Size = new System.Drawing.Size(40, 17);
            this.bunifuCustomLabel7.TabIndex = 15;
            this.bunifuCustomLabel7.Text = "Note";
            this.bunifuCustomLabel7.Click += new System.EventHandler(this.bunifuCustomLabel7_Click);
            // 
            // txt_Note
            // 
            this.txt_Note.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_Note.BorderColor = System.Drawing.Color.Black;
            this.txt_Note.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Note.ForeColor = System.Drawing.Color.Black;
            this.txt_Note.Location = new System.Drawing.Point(217, 391);
            this.txt_Note.Multiline = true;
            this.txt_Note.Name = "txt_Note";
            this.txt_Note.Size = new System.Drawing.Size(551, 35);
            this.txt_Note.TabIndex = 9;
            this.txt_Note.TextChanged += new System.EventHandler(this.txt_Note_TextChanged);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.TopPanel2;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuCustomLabel8
            // 
            this.bunifuCustomLabel8.AutoSize = true;
            this.bunifuCustomLabel8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel8.ForeColor = System.Drawing.Color.Teal;
            this.bunifuCustomLabel8.Location = new System.Drawing.Point(35, 185);
            this.bunifuCustomLabel8.Name = "bunifuCustomLabel8";
            this.bunifuCustomLabel8.Size = new System.Drawing.Size(77, 17);
            this.bunifuCustomLabel8.TabIndex = 21;
            this.bunifuCustomLabel8.Text = "Last Name";
            this.bunifuCustomLabel8.Click += new System.EventHandler(this.bunifuCustomLabel8_Click);
            // 
            // bunifuCustomLabel9
            // 
            this.bunifuCustomLabel9.AutoSize = true;
            this.bunifuCustomLabel9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel9.ForeColor = System.Drawing.Color.Teal;
            this.bunifuCustomLabel9.Location = new System.Drawing.Point(215, 185);
            this.bunifuCustomLabel9.Name = "bunifuCustomLabel9";
            this.bunifuCustomLabel9.Size = new System.Drawing.Size(79, 17);
            this.bunifuCustomLabel9.TabIndex = 22;
            this.bunifuCustomLabel9.Text = "First  Name";
            this.bunifuCustomLabel9.Click += new System.EventHandler(this.bunifuCustomLabel9_Click);
            // 
            // bunifuCustomLabel10
            // 
            this.bunifuCustomLabel10.AutoSize = true;
            this.bunifuCustomLabel10.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel10.ForeColor = System.Drawing.Color.Teal;
            this.bunifuCustomLabel10.Location = new System.Drawing.Point(392, 185);
            this.bunifuCustomLabel10.Name = "bunifuCustomLabel10";
            this.bunifuCustomLabel10.Size = new System.Drawing.Size(95, 17);
            this.bunifuCustomLabel10.TabIndex = 23;
            this.bunifuCustomLabel10.Text = "Middle Name";
            this.bunifuCustomLabel10.Click += new System.EventHandler(this.bunifuCustomLabel10_Click);
            // 
            // txt_LName
            // 
            this.txt_LName.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_LName.BorderColor = System.Drawing.Color.Black;
            this.txt_LName.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_LName.ForeColor = System.Drawing.Color.Black;
            this.txt_LName.Location = new System.Drawing.Point(37, 208);
            this.txt_LName.Multiline = true;
            this.txt_LName.Name = "txt_LName";
            this.txt_LName.Size = new System.Drawing.Size(164, 35);
            this.txt_LName.TabIndex = 2;
            this.txt_LName.TextChanged += new System.EventHandler(this.txt_LName_TextChanged);
            // 
            // txt_FName
            // 
            this.txt_FName.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_FName.BorderColor = System.Drawing.Color.Black;
            this.txt_FName.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_FName.ForeColor = System.Drawing.Color.Black;
            this.txt_FName.Location = new System.Drawing.Point(217, 208);
            this.txt_FName.Multiline = true;
            this.txt_FName.Name = "txt_FName";
            this.txt_FName.Size = new System.Drawing.Size(159, 35);
            this.txt_FName.TabIndex = 3;
            this.txt_FName.TextChanged += new System.EventHandler(this.txt_FName_TextChanged);
            // 
            // txt_MName
            // 
            this.txt_MName.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_MName.BorderColor = System.Drawing.Color.Black;
            this.txt_MName.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MName.ForeColor = System.Drawing.Color.Black;
            this.txt_MName.Location = new System.Drawing.Point(395, 208);
            this.txt_MName.Multiline = true;
            this.txt_MName.Name = "txt_MName";
            this.txt_MName.Size = new System.Drawing.Size(182, 35);
            this.txt_MName.TabIndex = 4;
            this.txt_MName.TextChanged += new System.EventHandler(this.txt_MName_TextChanged);
            // 
            // lbl_AppNo
            // 
            this.lbl_AppNo.AutoSize = true;
            this.lbl_AppNo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_AppNo.ForeColor = System.Drawing.Color.Teal;
            this.lbl_AppNo.Location = new System.Drawing.Point(606, 48);
            this.lbl_AppNo.Name = "lbl_AppNo";
            this.lbl_AppNo.Size = new System.Drawing.Size(121, 17);
            this.lbl_AppNo.TabIndex = 27;
            this.lbl_AppNo.Text = "Appointment No.";
            this.lbl_AppNo.Click += new System.EventHandler(this.lbl_AppNo_Click);
            // 
            // Treatment_CB
            // 
            this.Treatment_CB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Treatment_CB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Treatment_CB.BackColor = System.Drawing.Color.Gainsboro;
            this.Treatment_CB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Treatment_CB.DropDownHeight = 150;
            this.Treatment_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Treatment_CB.ForeColor = System.Drawing.Color.Black;
            this.Treatment_CB.FormattingEnabled = true;
            this.Treatment_CB.IntegralHeight = false;
            this.Treatment_CB.ItemHeight = 13;
            this.Treatment_CB.Location = new System.Drawing.Point(1, 0);
            this.Treatment_CB.MaxDropDownItems = 10;
            this.Treatment_CB.Name = "Treatment_CB";
            this.Treatment_CB.Size = new System.Drawing.Size(173, 21);
            this.Treatment_CB.TabIndex = 30;
            this.Treatment_CB.Text = "Select Treatment";
            this.Treatment_CB.SelectedIndexChanged += new System.EventHandler(this.Treatment_CB_SelectedIndexChanged);
            this.Treatment_CB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Treatment_CB_KeyDown);
            // 
            // TreatmentList
            // 
            this.TreatmentList.BackColor = System.Drawing.Color.Gainsboro;
            this.TreatmentList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.TreatmentList.FormattingEnabled = true;
            this.TreatmentList.HorizontalScrollbar = true;
            this.TreatmentList.Location = new System.Drawing.Point(596, 286);
            this.TreatmentList.Name = "TreatmentList";
            this.TreatmentList.Size = new System.Drawing.Size(171, 43);
            this.TreatmentList.TabIndex = 31;
            this.TreatmentList.SelectedIndexChanged += new System.EventHandler(this.TreatmentList_SelectedIndexChanged);
            // 
            // bunifuCustomLabel5
            // 
            this.bunifuCustomLabel5.AutoSize = true;
            this.bunifuCustomLabel5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel5.ForeColor = System.Drawing.Color.Teal;
            this.bunifuCustomLabel5.Location = new System.Drawing.Point(42, 478);
            this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
            this.bunifuCustomLabel5.Size = new System.Drawing.Size(83, 17);
            this.bunifuCustomLabel5.TabIndex = 35;
            this.bunifuCustomLabel5.Text = "Completed";
            this.bunifuCustomLabel5.Click += new System.EventHandler(this.bunifuCustomLabel5_Click);
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.ForeColor = System.Drawing.Color.Teal;
            this.lblContact.Location = new System.Drawing.Point(35, 360);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(86, 17);
            this.lblContact.TabIndex = 37;
            this.lblContact.Text = "Contact No";
            this.lblContact.Click += new System.EventHandler(this.lblContact_Click);
            // 
            // txt_ContactNo
            // 
            this.txt_ContactNo.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_ContactNo.BorderColor = System.Drawing.Color.Black;
            this.txt_ContactNo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ContactNo.ForeColor = System.Drawing.Color.Black;
            this.txt_ContactNo.Location = new System.Drawing.Point(37, 391);
            this.txt_ContactNo.Multiline = true;
            this.txt_ContactNo.Name = "txt_ContactNo";
            this.txt_ContactNo.Size = new System.Drawing.Size(164, 35);
            this.txt_ContactNo.TabIndex = 36;
            this.txt_ContactNo.TextChanged += new System.EventHandler(this.txt_ContactNo_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(3, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(151, 13);
            this.panel1.TabIndex = 38;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(0, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(173, 1);
            this.panel4.TabIndex = 41;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(153, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(21, 11);
            this.panel2.TabIndex = 39;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Location = new System.Drawing.Point(154, 21);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(19, 11);
            this.panel5.TabIndex = 41;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Location = new System.Drawing.Point(2, 18);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(2, 15);
            this.panel7.TabIndex = 42;
            this.panel7.Paint += new System.Windows.Forms.PaintEventHandler(this.panel7_Paint);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(1, 18);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(4, 14);
            this.panel3.TabIndex = 40;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // TreatmentDropDownPanel
            // 
            this.TreatmentDropDownPanel.Controls.Add(this.Treatment_CB);
            this.TreatmentDropDownPanel.Controls.Add(this.panel1);
            this.TreatmentDropDownPanel.Controls.Add(this.panel7);
            this.TreatmentDropDownPanel.Controls.Add(this.panel3);
            this.TreatmentDropDownPanel.Controls.Add(this.panel2);
            this.TreatmentDropDownPanel.Controls.Add(this.panel5);
            this.TreatmentDropDownPanel.Location = new System.Drawing.Point(596, 208);
            this.TreatmentDropDownPanel.Name = "TreatmentDropDownPanel";
            this.TreatmentDropDownPanel.Size = new System.Drawing.Size(178, 35);
            this.TreatmentDropDownPanel.TabIndex = 42;
            this.TreatmentDropDownPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TreatmentDropDownPanel_Paint);
            // 
            // statusSwitch
            // 
            this.statusSwitch.BackColor = System.Drawing.Color.Transparent;
            this.statusSwitch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("statusSwitch.BackgroundImage")));
            this.statusSwitch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.statusSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.statusSwitch.Location = new System.Drawing.Point(131, 474);
            this.statusSwitch.Name = "statusSwitch";
            this.statusSwitch.OffColor = System.Drawing.Color.Gray;
            this.statusSwitch.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.statusSwitch.Size = new System.Drawing.Size(43, 25);
            this.statusSwitch.TabIndex = 34;
            this.statusSwitch.Value = false;
            this.statusSwitch.OnValueChange += new System.EventHandler(this.statusSwitch_OnValueChange);
            this.statusSwitch.Click += new System.EventHandler(this.statusSwitch_Click);
            // 
            // btn_RemoveItem
            // 
            this.btn_RemoveItem.Activecolor = System.Drawing.Color.DarkGray;
            this.btn_RemoveItem.BackColor = System.Drawing.Color.DarkGray;
            this.btn_RemoveItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_RemoveItem.BorderRadius = 0;
            this.btn_RemoveItem.ButtonText = "Remove";
            this.btn_RemoveItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_RemoveItem.DisabledColor = System.Drawing.Color.Gray;
            this.btn_RemoveItem.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_RemoveItem.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_RemoveItem.Iconimage")));
            this.btn_RemoveItem.Iconimage_right = null;
            this.btn_RemoveItem.Iconimage_right_Selected = null;
            this.btn_RemoveItem.Iconimage_Selected = null;
            this.btn_RemoveItem.IconMarginLeft = 0;
            this.btn_RemoveItem.IconMarginRight = 0;
            this.btn_RemoveItem.IconRightVisible = true;
            this.btn_RemoveItem.IconRightZoom = 0D;
            this.btn_RemoveItem.IconVisible = true;
            this.btn_RemoveItem.IconZoom = 90D;
            this.btn_RemoveItem.IsTab = false;
            this.btn_RemoveItem.Location = new System.Drawing.Point(657, 347);
            this.btn_RemoveItem.Name = "btn_RemoveItem";
            this.btn_RemoveItem.Normalcolor = System.Drawing.Color.DarkGray;
            this.btn_RemoveItem.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(214)))), ((int)(((byte)(132)))));
            this.btn_RemoveItem.OnHoverTextColor = System.Drawing.Color.Black;
            this.btn_RemoveItem.selected = false;
            this.btn_RemoveItem.Size = new System.Drawing.Size(111, 30);
            this.btn_RemoveItem.TabIndex = 32;
            this.btn_RemoveItem.Text = "Remove";
            this.btn_RemoveItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_RemoveItem.Textcolor = System.Drawing.Color.Black;
            this.btn_RemoveItem.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_RemoveItem.Click += new System.EventHandler(this.btn_RemoveItem_Click);
            // 
            // btn_CreateBilling
            // 
            this.btn_CreateBilling.Activecolor = System.Drawing.Color.DarkGray;
            this.btn_CreateBilling.BackColor = System.Drawing.Color.DarkGray;
            this.btn_CreateBilling.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_CreateBilling.BorderRadius = 0;
            this.btn_CreateBilling.ButtonText = "Make Billing Statement";
            this.btn_CreateBilling.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CreateBilling.DisabledColor = System.Drawing.Color.Gray;
            this.btn_CreateBilling.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_CreateBilling.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_CreateBilling.Iconimage")));
            this.btn_CreateBilling.Iconimage_right = null;
            this.btn_CreateBilling.Iconimage_right_Selected = null;
            this.btn_CreateBilling.Iconimage_Selected = null;
            this.btn_CreateBilling.IconMarginLeft = 0;
            this.btn_CreateBilling.IconMarginRight = 0;
            this.btn_CreateBilling.IconRightVisible = true;
            this.btn_CreateBilling.IconRightZoom = 0D;
            this.btn_CreateBilling.IconVisible = true;
            this.btn_CreateBilling.IconZoom = 90D;
            this.btn_CreateBilling.IsTab = false;
            this.btn_CreateBilling.Location = new System.Drawing.Point(367, 466);
            this.btn_CreateBilling.Name = "btn_CreateBilling";
            this.btn_CreateBilling.Normalcolor = System.Drawing.Color.DarkGray;
            this.btn_CreateBilling.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(214)))), ((int)(((byte)(132)))));
            this.btn_CreateBilling.OnHoverTextColor = System.Drawing.Color.Black;
            this.btn_CreateBilling.selected = false;
            this.btn_CreateBilling.Size = new System.Drawing.Size(146, 38);
            this.btn_CreateBilling.TabIndex = 29;
            this.btn_CreateBilling.Text = "Make Billing Statement";
            this.btn_CreateBilling.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CreateBilling.Textcolor = System.Drawing.Color.Black;
            this.btn_CreateBilling.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_CreateBilling.Click += new System.EventHandler(this.btn_CreateBilling_Click);
            // 
            // btn_CancelApp
            // 
            this.btn_CancelApp.Activecolor = System.Drawing.Color.DarkGray;
            this.btn_CancelApp.BackColor = System.Drawing.Color.DarkGray;
            this.btn_CancelApp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_CancelApp.BorderRadius = 0;
            this.btn_CancelApp.ButtonText = "Cancel Appointment";
            this.btn_CancelApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CancelApp.DisabledColor = System.Drawing.Color.Gray;
            this.btn_CancelApp.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_CancelApp.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_CancelApp.Iconimage")));
            this.btn_CancelApp.Iconimage_right = null;
            this.btn_CancelApp.Iconimage_right_Selected = null;
            this.btn_CancelApp.Iconimage_Selected = null;
            this.btn_CancelApp.IconMarginLeft = 0;
            this.btn_CancelApp.IconMarginRight = 0;
            this.btn_CancelApp.IconRightVisible = true;
            this.btn_CancelApp.IconRightZoom = 0D;
            this.btn_CancelApp.IconVisible = true;
            this.btn_CancelApp.IconZoom = 90D;
            this.btn_CancelApp.IsTab = false;
            this.btn_CancelApp.Location = new System.Drawing.Point(523, 466);
            this.btn_CancelApp.Name = "btn_CancelApp";
            this.btn_CancelApp.Normalcolor = System.Drawing.Color.DarkGray;
            this.btn_CancelApp.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(214)))), ((int)(((byte)(132)))));
            this.btn_CancelApp.OnHoverTextColor = System.Drawing.Color.Black;
            this.btn_CancelApp.selected = false;
            this.btn_CancelApp.Size = new System.Drawing.Size(137, 38);
            this.btn_CancelApp.TabIndex = 10;
            this.btn_CancelApp.Text = "Cancel Appointment";
            this.btn_CancelApp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CancelApp.Textcolor = System.Drawing.Color.Black;
            this.btn_CancelApp.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_CancelApp.Visible = false;
            this.btn_CancelApp.Click += new System.EventHandler(this.btn_CancelApp_Click_1);
            // 
            // btn_add
            // 
            this.btn_add.Activecolor = System.Drawing.Color.DarkGray;
            this.btn_add.BackColor = System.Drawing.Color.DarkGray;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.BorderRadius = 0;
            this.btn_add.ButtonText = "Add";
            this.btn_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_add.DisabledColor = System.Drawing.Color.Gray;
            this.btn_add.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_add.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_add.Iconimage")));
            this.btn_add.Iconimage_right = null;
            this.btn_add.Iconimage_right_Selected = null;
            this.btn_add.Iconimage_Selected = null;
            this.btn_add.IconMarginLeft = 0;
            this.btn_add.IconMarginRight = 0;
            this.btn_add.IconRightVisible = true;
            this.btn_add.IconRightZoom = 0D;
            this.btn_add.IconVisible = true;
            this.btn_add.IconZoom = 90D;
            this.btn_add.IsTab = false;
            this.btn_add.Location = new System.Drawing.Point(670, 466);
            this.btn_add.Name = "btn_add";
            this.btn_add.Normalcolor = System.Drawing.Color.DarkGray;
            this.btn_add.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(214)))), ((int)(((byte)(132)))));
            this.btn_add.OnHoverTextColor = System.Drawing.Color.Black;
            this.btn_add.selected = false;
            this.btn_add.Size = new System.Drawing.Size(97, 38);
            this.btn_add.TabIndex = 11;
            this.btn_add.Text = "Add";
            this.btn_add.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_add.Textcolor = System.Drawing.Color.Black;
            this.btn_add.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_PatientSearch
            // 
            this.btn_PatientSearch.ActiveBorderThickness = 1;
            this.btn_PatientSearch.ActiveCornerRadius = 20;
            this.btn_PatientSearch.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.btn_PatientSearch.ActiveForecolor = System.Drawing.Color.White;
            this.btn_PatientSearch.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.btn_PatientSearch.BackColor = System.Drawing.Color.White;
            this.btn_PatientSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_PatientSearch.BackgroundImage")));
            this.btn_PatientSearch.ButtonText = "Search";
            this.btn_PatientSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_PatientSearch.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PatientSearch.ForeColor = System.Drawing.Color.Black;
            this.btn_PatientSearch.IdleBorderThickness = 1;
            this.btn_PatientSearch.IdleCornerRadius = 20;
            this.btn_PatientSearch.IdleFillColor = System.Drawing.Color.White;
            this.btn_PatientSearch.IdleForecolor = System.Drawing.Color.DarkBlue;
            this.btn_PatientSearch.IdleLineColor = System.Drawing.Color.RoyalBlue;
            this.btn_PatientSearch.Location = new System.Drawing.Point(309, 63);
            this.btn_PatientSearch.Margin = new System.Windows.Forms.Padding(5);
            this.btn_PatientSearch.Name = "btn_PatientSearch";
            this.btn_PatientSearch.Size = new System.Drawing.Size(94, 41);
            this.btn_PatientSearch.TabIndex = 1;
            this.btn_PatientSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_PatientSearch.Click += new System.EventHandler(this.btn_PatientSearch_Click);
            // 
            // txt_PatientSearch
            // 
            this.txt_PatientSearch.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_PatientSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txt_PatientSearch.BackgroundImage")));
            this.txt_PatientSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.txt_PatientSearch.ForeColor = System.Drawing.Color.Black;
            this.txt_PatientSearch.Icon = ((System.Drawing.Image)(resources.GetObject("txt_PatientSearch.Icon")));
            this.txt_PatientSearch.Location = new System.Drawing.Point(34, 68);
            this.txt_PatientSearch.Name = "txt_PatientSearch";
            this.txt_PatientSearch.Size = new System.Drawing.Size(267, 36);
            this.txt_PatientSearch.TabIndex = 0;
            this.txt_PatientSearch.text = "";
            this.txt_PatientSearch.OnTextChange += new System.EventHandler(this.txt_PatientSearch_OnTextChange);
            this.txt_PatientSearch.Leave += new System.EventHandler(this.txt_PatientSearch_Leave);
            // 
            // AddAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(790, 530);
            this.Controls.Add(this.TreatmentDropDownPanel);
            this.Controls.Add(this.txt_ContactNo);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.bunifuCustomLabel5);
            this.Controls.Add(this.statusSwitch);
            this.Controls.Add(this.btn_RemoveItem);
            this.Controls.Add(this.TreatmentList);
            this.Controls.Add(this.btn_CreateBilling);
            this.Controls.Add(this.lbl_AppNo);
            this.Controls.Add(this.txt_MName);
            this.Controls.Add(this.txt_FName);
            this.Controls.Add(this.txt_LName);
            this.Controls.Add(this.bunifuCustomLabel10);
            this.Controls.Add(this.bunifuCustomLabel9);
            this.Controls.Add(this.bunifuCustomLabel8);
            this.Controls.Add(this.btn_CancelApp);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.txt_Note);
            this.Controls.Add(this.bunifuCustomLabel7);
            this.Controls.Add(this.bunifuCustomLabel6);
            this.Controls.Add(this.bunifuCustomLabel4);
            this.Controls.Add(this.bunifuCustomLabel3);
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Controls.Add(this.DP_date);
            this.Controls.Add(this.TimeDD);
            this.Controls.Add(this.DentistDD);
            this.Controls.Add(this.AppSearch_DataGrid);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.btn_PatientSearch);
            this.Controls.Add(this.txt_PatientSearch);
            this.Controls.Add(this.TopPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Appointment";
            this.Load += new System.EventHandler(this.AddAppointment_Load);
            this.TopPanel2.ResumeLayout(false);
            this.TopPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AppSearch_DataGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.TreatmentDropDownPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel TopPanel2;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txt_Note;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel7;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel6;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel4;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuDatepicker DP_date;
        private Bunifu.Framework.UI.BunifuDropdown TimeDD;
        private Bunifu.Framework.UI.BunifuDropdown DentistDD;
        private Bunifu.Framework.UI.BunifuCustomDataGrid AppSearch_DataGrid;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_PatientSearch;
        private Bunifu.Framework.UI.BunifuTextbox txt_PatientSearch;
        private Bunifu.Framework.UI.BunifuCustomLabel txt_formHeader;
        private System.Windows.Forms.PictureBox pictureBox5;
        private Bunifu.Framework.UI.BunifuFlatButton btn_CancelApp;
        private Bunifu.Framework.UI.BunifuFlatButton btn_add;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_AppNo;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txt_MName;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txt_FName;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txt_LName;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel10;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel9;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel8;
        private Bunifu.Framework.UI.BunifuFlatButton btn_CreateBilling;
        private System.Windows.Forms.ListBox TreatmentList;
        private System.Windows.Forms.ComboBox Treatment_CB;
        private Bunifu.Framework.UI.BunifuFlatButton btn_RemoveItem;
        private Bunifu.Framework.UI.BunifuiOSSwitch statusSwitch;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel5;
        private System.Windows.Forms.Panel panel1;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txt_ContactNo;
        private Bunifu.Framework.UI.BunifuCustomLabel lblContact;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel TreatmentDropDownPanel;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_Close;
    }
}