using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _846DentalClinicManagementSystem
{
    public partial class AddExpensescs : Form
    {
        DateTimePicker dtp = new DateTimePicker();
        Rectangle _Rectangle = new Rectangle();

        public AddExpensescs()
        {
            InitializeComponent();

            ExpenseDG.Controls.Add(dtp);
            dtp.Visible = false;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.TextChanged += new EventHandler(dtp_TextChange);
        }

        private void AddExpensescs_Load(object sender, EventArgs e)
        {

        }

        private void dtp_TextChange(object sender, EventArgs e)
        {
            ExpenseDG.CurrentCell.Value = dtp.Text.ToString();
        }


        private void ExpenseDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (ExpenseDG.Columns[e.ColumnIndex].Name)
                {
                    case "Column1":
                        _Rectangle = ExpenseDG.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                        dtp.Location = new Point(_Rectangle.X, _Rectangle.Y);
                        dtp.Visible = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ExpenseDG_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ExpenseDG_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //float total = 0;
            //foreach (DataGridViewRow row in ExpenseDG.Rows)
            //{
            //    MessageBox.Show(row.Cells[2].Value.ToString());
            //    float.TryParse(row.Cells[3].Value.ToString(), out float amount);
            //    total += amount;
            //}
            //lbl_TotalExpense.Text = total.ToString();
            // lbl_total.Text = total.ToString();
        }

        private void btn_DeleteExpense_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow item in ExpenseDG.SelectedRows)
            {
                ExpenseDG.Rows.RemoveAt(item.Index);
            }
        }

        private void btn_SaveExpenses_Click(object sender, EventArgs e)
        {
            sas();
        }

        private void ExpenseDG_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
          //  MessageBox.Show(ExpenseDG.Rows[0].Cells[2].Value.ToString());
            //    float total = 0;
            //    foreach (DataGridViewRow row in ExpenseDG.Rows)
            //    {
            //        MessageBox.Show(row.Cells[2].Value.ToString());
            //        //     float.TryParse(row.Cells[3].Value.ToString(), out float amount);
            //        //     total += amount;
            //    }
            //    lbl_TotalExpense.Text = total.ToString();
        }

        private void sas()
        {
            MessageBox.Show(ExpenseDG.Rows[0].Cells[2].Value.ToString());
            //float total = 0;
            //foreach (DataGridViewRow row in ExpenseDG.Rows)
            //{
            //    try
            //    {
            //        if (string.IsNullOrEmpty(row.Cells[2].Value.ToString()) == false)
            //        {
            //            float.TryParse(row.Cells[3].Value.ToString(), out float amount);
            //            total += amount;
            //        }
            //    }catch(Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}

        }

        private void ExpenseDG_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(ExpenseDG.Rows[0].Cells[2].Value.ToString());
        }
    }
}
