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
            if(GlobalVariable.isAddExpense == false && GlobalVariable.isEditExpense == true)
            {
                editExpenseView();
            }

        }

        private void editExpenseView()
        {
            btn_AddRows.Visible = false;
            btn_DeleteExpense.Visible = false;
            txt_formHeader.Text = "Edit Expense";

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                "SELECT ExpenseDate,ExpenseName,ExpenseAmt" +
                " FROM Expense WHERE ExpenseID = @ExpenseID", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ExpenseID", GlobalVariable.ExpenseId);
            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);
                ExpenseDG.Rows.Add();
                ExpenseDG.Rows[0].Cells[0].Value = dt.Rows[0][0];
                ExpenseDG.Rows[0].Cells[1].Value = dt.Rows[0][1];
                ExpenseDG.Rows[0].Cells[2].Value = dt.Rows[0][2];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
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
            GlobalVariable.isAddExpense = false;
            GlobalVariable.isEditExpense = false;
            this.Hide();
          
        }

        

        private void btn_DeleteExpense_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow item in ExpenseDG.SelectedRows)
            {
                try
                {
                    
                    ExpenseDG.Rows.RemoveAt(item.Index);
                    dtp.Visible = false;
                    //foreach(Control control in ExpenseDG.Controls)
                    //{

                    //    if(control.Location == e)
                    //}
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
               
            }
        }
        private void AddExpenseSave()
        {
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


                    if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    sqlcon.Close();

                }
            }
        }

        private void EditExpenseSave()
        {
            if (IsValidCellValues())
            {
                foreach (DataGridViewRow row in ExpenseDG.Rows)
                {
                    string date = row.Cells[0].Value.ToString();
                    string exp = row.Cells[1].Value.ToString();
                    float.TryParse(row.Cells[2].Value.ToString(), out float amount);

                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Expense SET ExpenseDate = @date,ExpenseName = @expense, " +
                        "ExpenseAmt = @amt WHERE ExpenseId = @ExpenseID", sqlcon);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@expense", exp);
                    cmd.Parameters.AddWithValue("@amt", amount);
                    cmd.Parameters.AddWithValue("@ExpenseID", GlobalVariable.ExpenseId);

                    if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    sqlcon.Close();

                }
            }
        }

        private void btn_SaveExpenses_Click(object sender, EventArgs e)
        {
            ExpenseDG.EndEdit();

            if (GlobalVariable.isAddExpense == true && GlobalVariable.isEditExpense == false)
            {
                AddExpenseSave();
                MessageBox.Show("Expenses Added Successfully");
            }
            else if (GlobalVariable.isAddExpense == false && GlobalVariable.isEditExpense == true)
            {
                EditExpenseSave();
                MessageBox.Show("Expenses Updated Successfully");
            }

            var main = Application.OpenForms.OfType<MainForm>().First();
            main.LoadMonthlyExpenses();
            main.LoadGrossProfit();
            GlobalVariable.isAddExpense = false;
            GlobalVariable.isEditExpense = false;
            this.Hide();
            
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
