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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddExpensescs));
            this.ExpenseDG = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.TopPanel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_formHeader = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.btn_SaveExpenses = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_DeleteExpense = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_AddRows = new Bunifu.Framework.UI.BunifuFlatButton();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_DeleteFromDatabase = new Bunifu.Framework.UI.BunifuFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.ExpenseDG)).BeginInit();
            this.TopPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // ExpenseDG
            // 
            this.ExpenseDG.AllowUserToAddRows = false;
            this.ExpenseDG.AllowUserToResizeColumns = false;
            this.ExpenseDG.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(214)))), ((int)(((byte)(132)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.ExpenseDG.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ExpenseDG.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ExpenseDG.BackgroundColor = System.Drawing.Color.White;
            this.ExpenseDG.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ExpenseDG.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ExpenseDG.DefaultCellStyle = dataGridViewCellStyle5;
            this.ExpenseDG.DoubleBuffered = true;
            this.ExpenseDG.EnableHeadersVisualStyles = false;
            this.ExpenseDG.HeaderBgColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ExpenseDG.HeaderForeColor = System.Drawing.Color.Black;
            this.ExpenseDG.Location = new System.Drawing.Point(42, 75);
            this.ExpenseDG.Name = "ExpenseDG";
            this.ExpenseDG.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ExpenseDG.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(214)))), ((int)(((byte)(132)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ExpenseDG.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(214)))), ((int)(((byte)(132)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.ExpenseDG.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.ExpenseDG.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ExpenseDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ExpenseDG.Size = new System.Drawing.Size(626, 285);
            this.ExpenseDG.TabIndex = 72;
            this.ExpenseDG.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExpenseDG_CellClick);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe MDL2 Assets", 18F);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(680, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 24);
            this.label1.TabIndex = 62;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
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
            this.btn_SaveExpenses.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(214)))), ((int)(((byte)(132)))));
            this.btn_SaveExpenses.BackColor = System.Drawing.Color.DarkGray;
            this.btn_SaveExpenses.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_SaveExpenses.BorderRadius = 0;
            this.btn_SaveExpenses.ButtonText = "SAVE";
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
            this.btn_SaveExpenses.Location = new System.Drawing.Point(532, 383);
            this.btn_SaveExpenses.Name = "btn_SaveExpenses";
            this.btn_SaveExpenses.Normalcolor = System.Drawing.Color.DarkGray;
            this.btn_SaveExpenses.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(214)))), ((int)(((byte)(132)))));
            this.btn_SaveExpenses.OnHoverTextColor = System.Drawing.Color.Black;
            this.btn_SaveExpenses.selected = false;
            this.btn_SaveExpenses.Size = new System.Drawing.Size(136, 41);
            this.btn_SaveExpenses.TabIndex = 74;
            this.btn_SaveExpenses.Text = "SAVE";
            this.btn_SaveExpenses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SaveExpenses.Textcolor = System.Drawing.Color.Black;
            this.btn_SaveExpenses.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_SaveExpenses.Click += new System.EventHandler(this.btn_SaveExpenses_Click);
            // 
            // btn_DeleteExpense
            // 
            this.btn_DeleteExpense.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(214)))), ((int)(((byte)(132)))));
            this.btn_DeleteExpense.BackColor = System.Drawing.Color.DarkGray;
            this.btn_DeleteExpense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_DeleteExpense.BorderRadius = 0;
            this.btn_DeleteExpense.ButtonText = "DELETE ROW";
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
            this.btn_DeleteExpense.Location = new System.Drawing.Point(183, 385);
            this.btn_DeleteExpense.Name = "btn_DeleteExpense";
            this.btn_DeleteExpense.Normalcolor = System.Drawing.Color.DarkGray;
            this.btn_DeleteExpense.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(214)))), ((int)(((byte)(132)))));
            this.btn_DeleteExpense.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_DeleteExpense.selected = false;
            this.btn_DeleteExpense.Size = new System.Drawing.Size(136, 41);
            this.btn_DeleteExpense.TabIndex = 75;
            this.btn_DeleteExpense.Text = "DELETE ROW";
            this.btn_DeleteExpense.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_DeleteExpense.Textcolor = System.Drawing.Color.Black;
            this.btn_DeleteExpense.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_DeleteExpense.Click += new System.EventHandler(this.btn_DeleteExpense_Click);
            // 
            // btn_AddRows
            // 
            this.btn_AddRows.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(214)))), ((int)(((byte)(132)))));
            this.btn_AddRows.BackColor = System.Drawing.Color.DarkGray;
            this.btn_AddRows.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_AddRows.BorderRadius = 0;
            this.btn_AddRows.ButtonText = "ADD ROW";
            this.btn_AddRows.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AddRows.DisabledColor = System.Drawing.Color.Gray;
            this.btn_AddRows.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_AddRows.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_AddRows.Iconimage")));
            this.btn_AddRows.Iconimage_right = null;
            this.btn_AddRows.Iconimage_right_Selected = null;
            this.btn_AddRows.Iconimage_Selected = null;
            this.btn_AddRows.IconMarginLeft = 0;
            this.btn_AddRows.IconMarginRight = 0;
            this.btn_AddRows.IconRightVisible = true;
            this.btn_AddRows.IconRightZoom = 0D;
            this.btn_AddRows.IconVisible = true;
            this.btn_AddRows.IconZoom = 90D;
            this.btn_AddRows.IsTab = false;
            this.btn_AddRows.Location = new System.Drawing.Point(40, 385);
            this.btn_AddRows.Name = "btn_AddRows";
            this.btn_AddRows.Normalcolor = System.Drawing.Color.DarkGray;
            this.btn_AddRows.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(214)))), ((int)(((byte)(132)))));
            this.btn_AddRows.OnHoverTextColor = System.Drawing.Color.Black;
            this.btn_AddRows.selected = false;
            this.btn_AddRows.Size = new System.Drawing.Size(136, 41);
            this.btn_AddRows.TabIndex = 77;
            this.btn_AddRows.Text = "ADD ROW";
            this.btn_AddRows.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AddRows.Textcolor = System.Drawing.Color.Black;
            this.btn_AddRows.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_AddRows.Click += new System.EventHandler(this.btn_AddRows_Click);
            // 
            // Column1
            // 
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.FillWeight = 35.7868F;
            this.Column1.HeaderText = "Date";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 145;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 228.4264F;
            this.Column2.HeaderText = "Expenses";
            this.Column2.Name = "Column2";
            this.Column2.Width = 300;
            // 
            // Column3
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "N2";
            this.Column3.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column3.FillWeight = 35.7868F;
            this.Column3.HeaderText = "Amount";
            this.Column3.Name = "Column3";
            this.Column3.ToolTipText = "Enter Amount";
            this.Column3.Width = 140;
            // 
            // btn_DeleteFromDatabase
            // 
            this.btn_DeleteFromDatabase.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(214)))), ((int)(((byte)(132)))));
            this.btn_DeleteFromDatabase.BackColor = System.Drawing.Color.DarkGray;
            this.btn_DeleteFromDatabase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_DeleteFromDatabase.BorderRadius = 0;
            this.btn_DeleteFromDatabase.ButtonText = "DELETE";
            this.btn_DeleteFromDatabase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DeleteFromDatabase.DisabledColor = System.Drawing.Color.Gray;
            this.btn_DeleteFromDatabase.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_DeleteFromDatabase.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_DeleteFromDatabase.Iconimage")));
            this.btn_DeleteFromDatabase.Iconimage_right = null;
            this.btn_DeleteFromDatabase.Iconimage_right_Selected = null;
            this.btn_DeleteFromDatabase.Iconimage_Selected = null;
            this.btn_DeleteFromDatabase.IconMarginLeft = 0;
            this.btn_DeleteFromDatabase.IconMarginRight = 0;
            this.btn_DeleteFromDatabase.IconRightVisible = true;
            this.btn_DeleteFromDatabase.IconRightZoom = 0D;
            this.btn_DeleteFromDatabase.IconVisible = true;
            this.btn_DeleteFromDatabase.IconZoom = 90D;
            this.btn_DeleteFromDatabase.IsTab = false;
            this.btn_DeleteFromDatabase.Location = new System.Drawing.Point(390, 383);
            this.btn_DeleteFromDatabase.Name = "btn_DeleteFromDatabase";
            this.btn_DeleteFromDatabase.Normalcolor = System.Drawing.Color.DarkGray;
            this.btn_DeleteFromDatabase.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(214)))), ((int)(((byte)(132)))));
            this.btn_DeleteFromDatabase.OnHoverTextColor = System.Drawing.Color.Black;
            this.btn_DeleteFromDatabase.selected = false;
            this.btn_DeleteFromDatabase.Size = new System.Drawing.Size(136, 41);
            this.btn_DeleteFromDatabase.TabIndex = 78;
            this.btn_DeleteFromDatabase.Text = "DELETE";
            this.btn_DeleteFromDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DeleteFromDatabase.Textcolor = System.Drawing.Color.Black;
            this.btn_DeleteFromDatabase.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_DeleteFromDatabase.Visible = false;
            this.btn_DeleteFromDatabase.Click += new System.EventHandler(this.btn_DeleteFromDatabase_Click);
            // 
            // AddExpensescs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 450);
            this.Controls.Add(this.btn_DeleteFromDatabase);
            this.Controls.Add(this.btn_AddRows);
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
        private Bunifu.Framework.UI.BunifuFlatButton btn_AddRows;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private Bunifu.Framework.UI.BunifuFlatButton btn_DeleteFromDatabase;
    }
}