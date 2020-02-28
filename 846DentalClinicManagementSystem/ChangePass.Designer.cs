namespace _846DentalClinicManagementSystem
{
    partial class ChangePass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePass));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.TopBillingPanel = new System.Windows.Forms.Panel();
            this.lbl_Close = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txt_formHeader = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.bunifuCustomLabel6 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btn_save = new Bunifu.Framework.UI.BunifuFlatButton();
            this.ShowPass_CB = new System.Windows.Forms.CheckBox();
            this.txt_pass = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.txt_ConfirmPass = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.lbl_EmpName = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lbl_EmpID = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.TopBillingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // TopBillingPanel
            // 
            this.TopBillingPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.TopBillingPanel.Controls.Add(this.lbl_Close);
            this.TopBillingPanel.Controls.Add(this.txt_formHeader);
            this.TopBillingPanel.Controls.Add(this.pictureBox7);
            this.TopBillingPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopBillingPanel.Location = new System.Drawing.Point(0, 0);
            this.TopBillingPanel.Name = "TopBillingPanel";
            this.TopBillingPanel.Size = new System.Drawing.Size(432, 45);
            this.TopBillingPanel.TabIndex = 66;
            // 
            // lbl_Close
            // 
            this.lbl_Close.AutoSize = true;
            this.lbl_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Close.Font = new System.Drawing.Font("Segoe MDL2 Assets", 18F);
            this.lbl_Close.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl_Close.Location = new System.Drawing.Point(406, 2);
            this.lbl_Close.Name = "lbl_Close";
            this.lbl_Close.Size = new System.Drawing.Size(22, 24);
            this.lbl_Close.TabIndex = 80;
            this.lbl_Close.Text = "X";
            this.lbl_Close.Click += new System.EventHandler(this.lbl_Close_Click);
            // 
            // txt_formHeader
            // 
            this.txt_formHeader.AutoSize = true;
            this.txt_formHeader.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_formHeader.ForeColor = System.Drawing.Color.Silver;
            this.txt_formHeader.Location = new System.Drawing.Point(53, 9);
            this.txt_formHeader.Name = "txt_formHeader";
            this.txt_formHeader.Size = new System.Drawing.Size(272, 22);
            this.txt_formHeader.TabIndex = 61;
            this.txt_formHeader.Text = "Change Employee Password";
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackgroundImage = global::_846DentalClinicManagementSystem.Properties.Resources.btninventory;
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox7.Location = new System.Drawing.Point(9, 6);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(32, 28);
            this.pictureBox7.TabIndex = 60;
            this.pictureBox7.TabStop = false;
            // 
            // bunifuCustomLabel6
            // 
            this.bunifuCustomLabel6.AutoSize = true;
            this.bunifuCustomLabel6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel6.ForeColor = System.Drawing.Color.Teal;
            this.bunifuCustomLabel6.Location = new System.Drawing.Point(20, 84);
            this.bunifuCustomLabel6.Name = "bunifuCustomLabel6";
            this.bunifuCustomLabel6.Size = new System.Drawing.Size(60, 17);
            this.bunifuCustomLabel6.TabIndex = 70;
            this.bunifuCustomLabel6.Text = "Name : ";
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.Teal;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(20, 59);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(96, 17);
            this.bunifuCustomLabel1.TabIndex = 71;
            this.bunifuCustomLabel1.Text = "Employee ID :";
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.Teal;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(20, 117);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(77, 17);
            this.bunifuCustomLabel2.TabIndex = 72;
            this.bunifuCustomLabel2.Text = "Password :";
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.Teal;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(20, 167);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(133, 17);
            this.bunifuCustomLabel3.TabIndex = 73;
            this.bunifuCustomLabel3.Text = "Confirm Password :";
            // 
            // btn_save
            // 
            this.btn_save.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(214)))), ((int)(((byte)(132)))));
            this.btn_save.BackColor = System.Drawing.Color.DarkGray;
            this.btn_save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_save.BorderRadius = 0;
            this.btn_save.ButtonText = "SAVE";
            this.btn_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_save.DisabledColor = System.Drawing.Color.Gray;
            this.btn_save.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_save.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_save.Iconimage")));
            this.btn_save.Iconimage_right = null;
            this.btn_save.Iconimage_right_Selected = null;
            this.btn_save.Iconimage_Selected = null;
            this.btn_save.IconMarginLeft = 0;
            this.btn_save.IconMarginRight = 0;
            this.btn_save.IconRightVisible = true;
            this.btn_save.IconRightZoom = 0D;
            this.btn_save.IconVisible = true;
            this.btn_save.IconZoom = 90D;
            this.btn_save.IsTab = false;
            this.btn_save.Location = new System.Drawing.Point(299, 225);
            this.btn_save.Name = "btn_save";
            this.btn_save.Normalcolor = System.Drawing.Color.DarkGray;
            this.btn_save.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(214)))), ((int)(((byte)(132)))));
            this.btn_save.OnHoverTextColor = System.Drawing.Color.Black;
            this.btn_save.selected = false;
            this.btn_save.Size = new System.Drawing.Size(106, 35);
            this.btn_save.TabIndex = 74;
            this.btn_save.Text = "SAVE";
            this.btn_save.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_save.Textcolor = System.Drawing.Color.Black;
            this.btn_save.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // ShowPass_CB
            // 
            this.ShowPass_CB.AutoSize = true;
            this.ShowPass_CB.Location = new System.Drawing.Point(170, 205);
            this.ShowPass_CB.Name = "ShowPass_CB";
            this.ShowPass_CB.Size = new System.Drawing.Size(102, 17);
            this.ShowPass_CB.TabIndex = 75;
            this.ShowPass_CB.Text = "Show Password";
            this.ShowPass_CB.UseVisualStyleBackColor = true;

            this.ShowPass_CB.CheckStateChanged += new System.EventHandler(this.ShowPass_CB_CheckStateChanged);

            // 
            // txt_pass
            // 
            this.txt_pass.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_pass.BorderColor = System.Drawing.Color.SeaGreen;
            this.txt_pass.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pass.ForeColor = System.Drawing.Color.Black;
            this.txt_pass.Location = new System.Drawing.Point(170, 115);
            this.txt_pass.Multiline = true;
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.PasswordChar = '*';
            this.txt_pass.Size = new System.Drawing.Size(235, 35);
            this.txt_pass.TabIndex = 76;
            // 
            // txt_ConfirmPass
            // 
            this.txt_ConfirmPass.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_ConfirmPass.BorderColor = System.Drawing.Color.SeaGreen;
            this.txt_ConfirmPass.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ConfirmPass.ForeColor = System.Drawing.Color.Black;
            this.txt_ConfirmPass.Location = new System.Drawing.Point(170, 164);
            this.txt_ConfirmPass.Multiline = true;
            this.txt_ConfirmPass.Name = "txt_ConfirmPass";
            this.txt_ConfirmPass.PasswordChar = '*';
            this.txt_ConfirmPass.Size = new System.Drawing.Size(235, 35);
            this.txt_ConfirmPass.TabIndex = 77;
            // 
            // lbl_EmpName
            // 
            this.lbl_EmpName.AutoSize = true;
            this.lbl_EmpName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_EmpName.ForeColor = System.Drawing.Color.Teal;
            this.lbl_EmpName.Location = new System.Drawing.Point(167, 84);
            this.lbl_EmpName.Name = "lbl_EmpName";
            this.lbl_EmpName.Size = new System.Drawing.Size(60, 17);
            this.lbl_EmpName.TabIndex = 78;
            this.lbl_EmpName.Text = "Name : ";
            // 
            // lbl_EmpID
            // 
            this.lbl_EmpID.AutoSize = true;
            this.lbl_EmpID.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_EmpID.ForeColor = System.Drawing.Color.Teal;
            this.lbl_EmpID.Location = new System.Drawing.Point(167, 59);
            this.lbl_EmpID.Name = "lbl_EmpID";
            this.lbl_EmpID.Size = new System.Drawing.Size(96, 17);
            this.lbl_EmpID.TabIndex = 79;
            this.lbl_EmpID.Text = "Employee ID :";
            // 
            // ChangePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 272);
            this.Controls.Add(this.lbl_EmpID);
            this.Controls.Add(this.lbl_EmpName);
            this.Controls.Add(this.txt_ConfirmPass);
            this.Controls.Add(this.txt_pass);
            this.Controls.Add(this.ShowPass_CB);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.bunifuCustomLabel3);
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.bunifuCustomLabel6);
            this.Controls.Add(this.TopBillingPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChangePass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ChangePass";
            this.TopBillingPanel.ResumeLayout(false);
            this.TopBillingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel TopBillingPanel;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_Close;
        private Bunifu.Framework.UI.BunifuCustomLabel txt_formHeader;
        private System.Windows.Forms.PictureBox pictureBox7;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel6;
        private System.Windows.Forms.CheckBox ShowPass_CB;
        private Bunifu.Framework.UI.BunifuFlatButton btn_save;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_EmpID;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_EmpName;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txt_ConfirmPass;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txt_pass;
    }
}