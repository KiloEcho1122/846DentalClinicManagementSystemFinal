﻿namespace _846DentalClinicManagementSystem
{
    partial class AddExpensescs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddExpensescs));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ExpenseDG = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.TopPanel2 = new System.Windows.Forms.Panel();
            this.txt_formHeader = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.btn_SaveExpenses = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_DeleteExpense = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_TotalExpense = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ExpenseDG)).BeginInit();
            this.TopPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // ExpenseDG
            // 
            this.ExpenseDG.AllowUserToResizeColumns = false;
            this.ExpenseDG.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ExpenseDG.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ExpenseDG.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ExpenseDG.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(85)))), ((int)(((byte)(120)))));
            this.ExpenseDG.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ExpenseDG.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ExpenseDG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ExpenseDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExpenseDG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.ExpenseDG.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ExpenseDG.DefaultCellStyle = dataGridViewCellStyle4;
            this.ExpenseDG.DoubleBuffered = true;
            this.ExpenseDG.EnableHeadersVisualStyles = false;
            this.ExpenseDG.HeaderBgColor = System.Drawing.Color.SeaGreen;
            this.ExpenseDG.HeaderForeColor = System.Drawing.Color.White;
            this.ExpenseDG.Location = new System.Drawing.Point(40, 75);
            this.ExpenseDG.Name = "ExpenseDG";
            this.ExpenseDG.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ExpenseDG.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ExpenseDG.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.ExpenseDG.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ExpenseDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ExpenseDG.Size = new System.Drawing.Size(623, 259);
            this.ExpenseDG.TabIndex = 72;
            this.ExpenseDG.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExpenseDG_CellClick);
            this.ExpenseDG.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExpenseDG_RowLeave);
            this.ExpenseDG.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.ExpenseDG_RowsAdded);
            this.ExpenseDG.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ExpenseDG_Scroll);
            this.ExpenseDG.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.ExpenseDG_UserAddedRow);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // TopPanel2
            // 
            this.TopPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.TopPanel2.Controls.Add(this.label1);
            this.TopPanel2.Controls.Add(this.txt_formHeader);
            this.TopPanel2.Controls.Add(this.pictureBox7);
            this.TopPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel2.Location = new System.Drawing.Point(0, 0);
            this.TopPanel2.Name = "TopPanel2";
            this.TopPanel2.Size = new System.Drawing.Size(705, 45);
            this.TopPanel2.TabIndex = 73;
            // 
            // txt_formHeader
            // 
            this.txt_formHeader.AutoSize = true;
            this.txt_formHeader.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_formHeader.ForeColor = System.Drawing.Color.Silver;
            this.txt_formHeader.Location = new System.Drawing.Point(54, 13);
            this.txt_formHeader.Name = "txt_formHeader";
            this.txt_formHeader.Size = new System.Drawing.Size(138, 22);
            this.txt_formHeader.TabIndex = 61;
            this.txt_formHeader.Text = "Add Expenses";
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackgroundImage = global::_846DentalClinicManagementSystem.Properties.Resources.btninventory;
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox7.Location = new System.Drawing.Point(10, 10);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(32, 28);
            this.pictureBox7.TabIndex = 60;
            this.pictureBox7.TabStop = false;
            // 
            // btn_SaveExpenses
            // 
            this.btn_SaveExpenses.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_SaveExpenses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_SaveExpenses.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_SaveExpenses.BorderRadius = 0;
            this.btn_SaveExpenses.ButtonText = "Save";
            this.btn_SaveExpenses.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SaveExpenses.DisabledColor = System.Drawing.Color.Gray;
            this.btn_SaveExpenses.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_SaveExpenses.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_SaveExpenses.Iconimage")));
            this.btn_SaveExpenses.Iconimage_right = null;
            this.btn_SaveExpenses.Iconimage_right_Selected = null;
            this.btn_SaveExpenses.Iconimage_Selected = null;
            this.btn_SaveExpenses.IconMarginLeft = 0;
            this.btn_SaveExpenses.IconMarginRight = 0;
            this.btn_SaveExpenses.IconRightVisible = true;
            this.btn_SaveExpenses.IconRightZoom = 0D;
            this.btn_SaveExpenses.IconVisible = true;
            this.btn_SaveExpenses.IconZoom = 90D;
            this.btn_SaveExpenses.IsTab = false;
            this.btn_SaveExpenses.Location = new System.Drawing.Point(554, 385);
            this.btn_SaveExpenses.Name = "btn_SaveExpenses";
            this.btn_SaveExpenses.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_SaveExpenses.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btn_SaveExpenses.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_SaveExpenses.selected = false;
            this.btn_SaveExpenses.Size = new System.Drawing.Size(109, 41);
            this.btn_SaveExpenses.TabIndex = 74;
            this.btn_SaveExpenses.Text = "Save";
            this.btn_SaveExpenses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SaveExpenses.Textcolor = System.Drawing.Color.White;
            this.btn_SaveExpenses.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SaveExpenses.Click += new System.EventHandler(this.btn_SaveExpenses_Click);
            // 
            // btn_DeleteExpense
            // 
            this.btn_DeleteExpense.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_DeleteExpense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_DeleteExpense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_DeleteExpense.BorderRadius = 0;
            this.btn_DeleteExpense.ButtonText = "Delete";
            this.btn_DeleteExpense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DeleteExpense.DisabledColor = System.Drawing.Color.Gray;
            this.btn_DeleteExpense.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_DeleteExpense.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_DeleteExpense.Iconimage")));
            this.btn_DeleteExpense.Iconimage_right = null;
            this.btn_DeleteExpense.Iconimage_right_Selected = null;
            this.btn_DeleteExpense.Iconimage_Selected = null;
            this.btn_DeleteExpense.IconMarginLeft = 0;
            this.btn_DeleteExpense.IconMarginRight = 0;
            this.btn_DeleteExpense.IconRightVisible = true;
            this.btn_DeleteExpense.IconRightZoom = 0D;
            this.btn_DeleteExpense.IconVisible = true;
            this.btn_DeleteExpense.IconZoom = 90D;
            this.btn_DeleteExpense.IsTab = false;
            this.btn_DeleteExpense.Location = new System.Drawing.Point(439, 385);
            this.btn_DeleteExpense.Name = "btn_DeleteExpense";
            this.btn_DeleteExpense.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_DeleteExpense.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btn_DeleteExpense.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_DeleteExpense.selected = false;
            this.btn_DeleteExpense.Size = new System.Drawing.Size(109, 41);
            this.btn_DeleteExpense.TabIndex = 75;
            this.btn_DeleteExpense.Text = "Delete";
            this.btn_DeleteExpense.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DeleteExpense.Textcolor = System.Drawing.Color.White;
            this.btn_DeleteExpense.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DeleteExpense.Click += new System.EventHandler(this.btn_DeleteExpense_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(677, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 16);
            this.label1.TabIndex = 62;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbl_TotalExpense
            // 
            this.lbl_TotalExpense.AutoSize = true;
            this.lbl_TotalExpense.Location = new System.Drawing.Point(628, 351);
            this.lbl_TotalExpense.Name = "lbl_TotalExpense";
            this.lbl_TotalExpense.Size = new System.Drawing.Size(28, 13);
            this.lbl_TotalExpense.TabIndex = 76;
            this.lbl_TotalExpense.Text = "0.00";
            // 
            // Column1
            // 
            this.Column1.FillWeight = 35.7868F;
            this.Column1.HeaderText = "Date";
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 228.4264F;
            this.Column2.HeaderText = "Miscellaneous";
            this.Column2.Name = "Column2";
            this.Column2.Width = 315;
            // 
            // Column3
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "N2";
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.FillWeight = 35.7868F;
            this.Column3.HeaderText = "Amount";
            this.Column3.Name = "Column3";
            this.Column3.ToolTipText = "Enter Amount";
            this.Column3.Width = 120;
            // 
            // AddExpensescs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 450);
            this.Controls.Add(this.lbl_TotalExpense);
            this.Controls.Add(this.btn_DeleteExpense);
            this.Controls.Add(this.btn_SaveExpenses);
            this.Controls.Add(this.TopPanel2);
            this.Controls.Add(this.ExpenseDG);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddExpensescs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddExpensescs";
            this.Load += new System.EventHandler(this.AddExpensescs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ExpenseDG)).EndInit();
            this.TopPanel2.ResumeLayout(false);
            this.TopPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomDataGrid ExpenseDG;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel TopPanel2;
        private Bunifu.Framework.UI.BunifuCustomLabel txt_formHeader;
        private System.Windows.Forms.PictureBox pictureBox7;
        private Bunifu.Framework.UI.BunifuFlatButton btn_DeleteExpense;
        private Bunifu.Framework.UI.BunifuFlatButton btn_SaveExpenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_TotalExpense;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}