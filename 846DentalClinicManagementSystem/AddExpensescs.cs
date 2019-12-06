using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        SqlConnection sqlcon = new SqlConnection(GlobalVariable.connString);

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
                        ExpenseDG.CurrentCell.Value = dtp.Text.ToString();
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

        

        private void btn_DeleteExpense_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow item in ExpenseDG.SelectedRows)
            {
                try
                {
                    
                    ExpenseDG.Rows.RemoveAt(item.Index);
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
               
            }
        }

        private void btn_SaveExpenses_Click(object sender, EventArgs e)
        {
            ExpenseDG.EndEdit();
            if (IsValidCellValues())
            {
                foreach (DataGridViewRow row in ExpenseDG.Rows)
                {
                    string date = row.Cells[0].Value.ToString();
                    string exp = row.Cells[1].Value.ToString();
                    float.TryParse(row.Cells[2].Value.ToString(), out float amount);

                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO [Expense] (ExpenseDate,ExpenseName,ExpenseAmt) " +
                        "VALUES(@date,@expense,@amt)", sqlcon);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@expense", exp);
                    cmd.Parameters.AddWithValue("@amt", amount);

                    sqlcon.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    sqlcon.Close();

                }
                MessageBox.Show("Expenses Added Successfully");
                var main = Application.OpenForms.OfType<MainForm>().First();
                main.LoadMonthlyExpenses();
                main.LoadGrossProfit();
                this.Hide();
            }
        }

       

        private Boolean IsValidCellValues()
        {
            if(ExpenseDG.Rows.Count  == 0)
            {
                return false;
            }
            
            foreach (DataGridViewRow row in ExpenseDG.Rows)
            {
                try
                {

                    object date = row.Cells[0].Value;
                    object exp = row.Cells[1].Value;
                    object amt = row.Cells[2].Value;

                    int rowIndex = row.Index + 1;

                        if (date == null || string.IsNullOrWhiteSpace(date.ToString()))
                        {
                            MessageBox.Show("Invalid Date on row " + rowIndex);
                            return false;
                        }

                        if (exp == null || string.IsNullOrWhiteSpace(exp.ToString()))
                        {
                            MessageBox.Show("Invalid Expense on row " + rowIndex);
                            return false;
                        }

                        if (amt != null)
                        {
                            float.TryParse(row.Cells[2].Value.ToString(), out float amount);
                            if (amount < 1)
                            {
                                MessageBox.Show("Invalid Amount on row " + rowIndex);
                                return false;
                            }
                        }
                        else {
                            MessageBox.Show("Invalid Amount on row " + rowIndex);
                            return false;
                        }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                

            }
            return true;

        }

        private void btn_AddRows_Click(object sender, EventArgs e)
        {
            ExpenseDG.Rows.Add();
        }
    }
}
