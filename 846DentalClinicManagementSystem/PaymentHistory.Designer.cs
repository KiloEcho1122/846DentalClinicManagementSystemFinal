namespace _846DentalClinicManagementSystem
{
    partial class PaymentHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentHistory));
            this.PaymentHistory_DataGrid = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btn_Close = new Bunifu.Framework.UI.BunifuImageButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lbl_PatientName = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lbl_Patient = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btn_AddBilling = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentHistory_DataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Close)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // PaymentHistory_DataGrid
            // 
            this.PaymentHistory_DataGrid.AllowUserToAddRows = false;
            this.PaymentHistory_DataGrid.AllowUserToDeleteRows = false;
            this.PaymentHistory_DataGrid.AllowUserToResizeColumns = false;
            this.PaymentHistory_DataGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PaymentHistory_DataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.PaymentHistory_DataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PaymentHistory_DataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.PaymentHistory_DataGrid.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.PaymentHistory_DataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PaymentHistory_DataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PaymentHistory_DataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.PaymentHistory_DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PaymentHistory_DataGrid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PaymentHistory_DataGrid.DoubleBuffered = true;
            this.PaymentHistory_DataGrid.EnableHeadersVisualStyles = false;
            this.PaymentHistory_DataGrid.HeaderBgColor = System.Drawing.Color.SeaGreen;
            this.PaymentHistory_DataGrid.HeaderForeColor = System.Drawing.Color.White;
            this.PaymentHistory_DataGrid.Location = new System.Drawing.Point(24, 79);
            this.PaymentHistory_DataGrid.Name = "PaymentHistory_DataGrid";
            this.PaymentHistory_DataGrid.ReadOnly = true;
            this.PaymentHistory_DataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.PaymentHistory_DataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PaymentHistory_DataGrid.Size = new System.Drawing.Size(636, 234);
            this.PaymentHistory_DataGrid.TabIndex = 55;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Red;
            this.btn_Close.Image = ((System.Drawing.Image)(resources.GetObject("btn_Close.Image")));
            this.btn_Close.ImageActive = null;
            this.btn_Close.Location = new System.Drawing.Point(641, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(52, 28);
            this.btn_Close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_Close.TabIndex = 56;
            this.btn_Close.TabStop = false;
            this.btn_Close.Zoom = 10;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.panel4.Controls.Add(this.bunifuCustomLabel4);
            this.panel4.Controls.Add(this.pictureBox3);
            this.panel4.Controls.Add(this.btn_Close);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(692, 29);
            this.panel4.TabIndex = 58;
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel4.ForeColor = System.Drawing.Color.Silver;
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(27, 3);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(134, 21);
            this.bunifuCustomLabel4.TabIndex = 3;
            this.bunifuCustomLabel4.Text = "Payment History";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::_846DentalClinicManagementSystem.Properties.Resources.btnpatients;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(8, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(19, 20);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // lbl_PatientName
            // 
            this.lbl_PatientName.AutoSize = true;
            this.lbl_PatientName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PatientName.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_PatientName.Location = new System.Drawing.Point(89, 47);
            this.lbl_PatientName.Name = "lbl_PatientName";
            this.lbl_PatientName.Size = new System.Drawing.Size(0, 17);
            this.lbl_PatientName.TabIndex = 60;
            // 
            // lbl_Patient
            // 
            this.lbl_Patient.AutoSize = true;
            this.lbl_Patient.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Patient.ForeColor = System.Drawing.Color.Teal;
            this.lbl_Patient.Location = new System.Drawing.Point(21, 47);
            this.lbl_Patient.Name = "lbl_Patient";
            this.lbl_Patient.Size = new System.Drawing.Size(62, 17);
            this.lbl_Patient.TabIndex = 59;
            this.lbl_Patient.Text = "Patient :";
            // 
            // btn_AddBilling
            // 
            this.btn_AddBilling.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_AddBilling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddBilling.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddBilling.ForeColor = System.Drawing.Color.White;
            this.btn_AddBilling.Location = new System.Drawing.Point(507, 315);
            this.btn_AddBilling.Margin = new System.Windows.Forms.Padding(0);
            this.btn_AddBilling.Name = "btn_AddBilling";
            this.btn_AddBilling.Size = new System.Drawing.Size(153, 42);
            this.btn_AddBilling.TabIndex = 66;
            this.btn_AddBilling.Text = "Cancel Payment";
            this.btn_AddBilling.UseVisualStyleBackColor = false;
            this.btn_AddBilling.Click += new System.EventHandler(this.btn_AddBilling_Click);
            // 
            // PaymentHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 366);
            this.Controls.Add(this.btn_AddBilling);
            this.Controls.Add(this.lbl_PatientName);
            this.Controls.Add(this.lbl_Patient);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.PaymentHistory_DataGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PaymentHistory";
            this.Text = "PaymentHistory";
            this.Load += new System.EventHandler(this.PaymentHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PaymentHistory_DataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Close)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomDataGrid PaymentHistory_DataGrid;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuImageButton btn_Close;
        private System.Windows.Forms.Panel panel4;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_PatientName;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_Patient;
        private System.Windows.Forms.Button btn_AddBilling;
    }
}