namespace _846DentalClinicManagementSystem
{
    partial class AddEditDentist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditDentist));
            this.txt_LicenseNo = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.bunifuCustomLabel5 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txt_DentistNo = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.bunifuCustomLabel11 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txt_formHeader = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.TopPanel2 = new System.Windows.Forms.Panel();
            this.txt_MName = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.txt_FName = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.txt_LName = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.bunifuCustomLabel10 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel9 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel8 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btn_close = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_add = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.TopPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_LicenseNo
            // 
            this.txt_LicenseNo.BackColor = System.Drawing.Color.SeaGreen;
            this.txt_LicenseNo.BorderColor = System.Drawing.Color.SeaGreen;
            this.txt_LicenseNo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_LicenseNo.ForeColor = System.Drawing.SystemColors.Menu;
            this.txt_LicenseNo.Location = new System.Drawing.Point(193, 305);
            this.txt_LicenseNo.Multiline = true;
            this.txt_LicenseNo.Name = "txt_LicenseNo";
            this.txt_LicenseNo.Size = new System.Drawing.Size(191, 35);
            this.txt_LicenseNo.TabIndex = 64;
            // 
            // bunifuCustomLabel5
            // 
            this.bunifuCustomLabel5.AutoSize = true;
            this.bunifuCustomLabel5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel5.ForeColor = System.Drawing.Color.Teal;
            this.bunifuCustomLabel5.Location = new System.Drawing.Point(87, 311);
            this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
            this.bunifuCustomLabel5.Size = new System.Drawing.Size(77, 17);
            this.bunifuCustomLabel5.TabIndex = 65;
            this.bunifuCustomLabel5.Text = "License No";
            // 
            // txt_DentistNo
            // 
            this.txt_DentistNo.BackColor = System.Drawing.Color.SeaGreen;
            this.txt_DentistNo.BorderColor = System.Drawing.Color.SeaGreen;
            this.txt_DentistNo.Enabled = false;
            this.txt_DentistNo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DentistNo.ForeColor = System.Drawing.Color.Black;
            this.txt_DentistNo.Location = new System.Drawing.Point(193, 90);
            this.txt_DentistNo.Multiline = true;
            this.txt_DentistNo.Name = "txt_DentistNo";
            this.txt_DentistNo.Size = new System.Drawing.Size(191, 35);
            this.txt_DentistNo.TabIndex = 53;
            this.txt_DentistNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bunifuCustomLabel11
            // 
            this.bunifuCustomLabel11.AutoSize = true;
            this.bunifuCustomLabel11.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel11.ForeColor = System.Drawing.Color.Teal;
            this.bunifuCustomLabel11.Location = new System.Drawing.Point(95, 96);
            this.bunifuCustomLabel11.Name = "bunifuCustomLabel11";
            this.bunifuCustomLabel11.Size = new System.Drawing.Size(71, 17);
            this.bunifuCustomLabel11.TabIndex = 52;
            this.bunifuCustomLabel11.Text = "Patient ID";
            // 
            // txt_formHeader
            // 
            this.txt_formHeader.AutoSize = true;
            this.txt_formHeader.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_formHeader.ForeColor = System.Drawing.Color.Silver;
            this.txt_formHeader.Location = new System.Drawing.Point(53, 10);
            this.txt_formHeader.Name = "txt_formHeader";
            this.txt_formHeader.Size = new System.Drawing.Size(165, 22);
            this.txt_formHeader.TabIndex = 3;
            this.txt_formHeader.Text = "Add New Dentist";
            // 
            // TopPanel2
            // 
            this.TopPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.TopPanel2.Controls.Add(this.txt_formHeader);
            this.TopPanel2.Controls.Add(this.pictureBox5);
            this.TopPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel2.Location = new System.Drawing.Point(0, 0);
            this.TopPanel2.Name = "TopPanel2";
            this.TopPanel2.Size = new System.Drawing.Size(487, 45);
            this.TopPanel2.TabIndex = 51;
            // 
            // txt_MName
            // 
            this.txt_MName.BackColor = System.Drawing.Color.SeaGreen;
            this.txt_MName.BorderColor = System.Drawing.Color.SeaGreen;
            this.txt_MName.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MName.ForeColor = System.Drawing.SystemColors.Menu;
            this.txt_MName.Location = new System.Drawing.Point(193, 254);
            this.txt_MName.Multiline = true;
            this.txt_MName.Name = "txt_MName";
            this.txt_MName.Size = new System.Drawing.Size(191, 35);
            this.txt_MName.TabIndex = 47;
            // 
            // txt_FName
            // 
            this.txt_FName.BackColor = System.Drawing.Color.SeaGreen;
            this.txt_FName.BorderColor = System.Drawing.Color.SeaGreen;
            this.txt_FName.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_FName.ForeColor = System.Drawing.SystemColors.Menu;
            this.txt_FName.Location = new System.Drawing.Point(193, 200);
            this.txt_FName.Multiline = true;
            this.txt_FName.Name = "txt_FName";
            this.txt_FName.Size = new System.Drawing.Size(191, 35);
            this.txt_FName.TabIndex = 46;
            // 
            // txt_LName
            // 
            this.txt_LName.BackColor = System.Drawing.Color.SeaGreen;
            this.txt_LName.BorderColor = System.Drawing.Color.SeaGreen;
            this.txt_LName.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_LName.ForeColor = System.Drawing.SystemColors.Menu;
            this.txt_LName.Location = new System.Drawing.Point(193, 145);
            this.txt_LName.Multiline = true;
            this.txt_LName.Name = "txt_LName";
            this.txt_LName.Size = new System.Drawing.Size(191, 35);
            this.txt_LName.TabIndex = 45;
            // 
            // bunifuCustomLabel10
            // 
            this.bunifuCustomLabel10.AutoSize = true;
            this.bunifuCustomLabel10.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel10.ForeColor = System.Drawing.Color.Teal;
            this.bunifuCustomLabel10.Location = new System.Drawing.Point(87, 254);
            this.bunifuCustomLabel10.Name = "bunifuCustomLabel10";
            this.bunifuCustomLabel10.Size = new System.Drawing.Size(95, 17);
            this.bunifuCustomLabel10.TabIndex = 50;
            this.bunifuCustomLabel10.Text = "Middle Name";
            // 
            // bunifuCustomLabel9
            // 
            this.bunifuCustomLabel9.AutoSize = true;
            this.bunifuCustomLabel9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel9.ForeColor = System.Drawing.Color.Teal;
            this.bunifuCustomLabel9.Location = new System.Drawing.Point(87, 200);
            this.bunifuCustomLabel9.Name = "bunifuCustomLabel9";
            this.bunifuCustomLabel9.Size = new System.Drawing.Size(79, 17);
            this.bunifuCustomLabel9.TabIndex = 49;
            this.bunifuCustomLabel9.Text = "First  Name";
            // 
            // bunifuCustomLabel8
            // 
            this.bunifuCustomLabel8.AutoSize = true;
            this.bunifuCustomLabel8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel8.ForeColor = System.Drawing.Color.Teal;
            this.bunifuCustomLabel8.Location = new System.Drawing.Point(89, 145);
            this.bunifuCustomLabel8.Name = "bunifuCustomLabel8";
            this.bunifuCustomLabel8.Size = new System.Drawing.Size(77, 17);
            this.bunifuCustomLabel8.TabIndex = 48;
            this.bunifuCustomLabel8.Text = "Last Name";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // btn_close
            // 
            this.btn_close.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_close.BorderRadius = 0;
            this.btn_close.ButtonText = "   Close";
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.DisabledColor = System.Drawing.Color.Gray;
            this.btn_close.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_close.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_close.Iconimage")));
            this.btn_close.Iconimage_right = null;
            this.btn_close.Iconimage_right_Selected = null;
            this.btn_close.Iconimage_Selected = null;
            this.btn_close.IconMarginLeft = 0;
            this.btn_close.IconMarginRight = 0;
            this.btn_close.IconRightVisible = true;
            this.btn_close.IconRightZoom = 0D;
            this.btn_close.IconVisible = true;
            this.btn_close.IconZoom = 90D;
            this.btn_close.IsTab = false;
            this.btn_close.Location = new System.Drawing.Point(90, 379);
            this.btn_close.Name = "btn_close";
            this.btn_close.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_close.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btn_close.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_close.selected = false;
            this.btn_close.Size = new System.Drawing.Size(145, 48);
            this.btn_close.TabIndex = 61;
            this.btn_close.Text = "   Close";
            this.btn_close.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_close.Textcolor = System.Drawing.Color.White;
            this.btn_close.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_add
            // 
            this.btn_add.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.BorderRadius = 0;
            this.btn_add.ButtonText = "     Add";
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
            this.btn_add.Location = new System.Drawing.Point(241, 379);
            this.btn_add.Name = "btn_add";
            this.btn_add.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_add.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btn_add.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_add.selected = false;
            this.btn_add.Size = new System.Drawing.Size(143, 48);
            this.btn_add.TabIndex = 60;
            this.btn_add.Text = "     Add";
            this.btn_add.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_add.Textcolor = System.Drawing.Color.White;
            this.btn_add.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::_846DentalClinicManagementSystem.Properties.Resources.btnpatients;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(9, 7);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 28);
            this.pictureBox5.TabIndex = 2;
            this.pictureBox5.TabStop = false;
            // 
            // AddEditDentist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 497);
            this.Controls.Add(this.txt_LicenseNo);
            this.Controls.Add(this.bunifuCustomLabel5);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.txt_DentistNo);
            this.Controls.Add(this.bunifuCustomLabel11);
            this.Controls.Add(this.TopPanel2);
            this.Controls.Add(this.txt_MName);
            this.Controls.Add(this.txt_FName);
            this.Controls.Add(this.txt_LName);
            this.Controls.Add(this.bunifuCustomLabel10);
            this.Controls.Add(this.bunifuCustomLabel9);
            this.Controls.Add(this.bunifuCustomLabel8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddEditDentist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddEditDentist";
            this.Load += new System.EventHandler(this.AddEditDentist_Load);
            this.TopPanel2.ResumeLayout(false);
            this.TopPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowsFormsControlLibrary1.BunifuCustomTextbox txt_LicenseNo;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel5;
        private Bunifu.Framework.UI.BunifuFlatButton btn_close;
        private Bunifu.Framework.UI.BunifuFlatButton btn_add;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txt_DentistNo;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel11;
        private Bunifu.Framework.UI.BunifuCustomLabel txt_formHeader;
        private System.Windows.Forms.Panel TopPanel2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txt_MName;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txt_FName;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txt_LName;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel10;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel9;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel8;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}