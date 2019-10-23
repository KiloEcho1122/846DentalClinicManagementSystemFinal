using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace _846DentalClinicManagementSystem
{
    public partial class PaymentHistory : Form
    {
        SqlConnection sqlcon = new SqlConnection(GlobalVariable.connString);
        ArrayList paymentID = new ArrayList();

        public PaymentHistory()
        {
            InitializeComponent();
        }

        private void PaymentHistory_Load(object sender, EventArgs e)
        {
            lbl_PatientName.Text = GlobalVariable.PatientName;
            ShowPaymentHistory();
        }

        private void ShowPaymentHistory()
        {
            
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                "SELECT PaymentID,PaymentDate,PaymentAmount,PaymentBalance,UpdatedBy,Status " +
                "FROM Payment WHERE BillingID_fk = @BillingID", sqlcon);

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@BillingID", GlobalVariable.BillingID);
            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);
                PaymentHistory_DataGrid.DataSource = dt;

                PaymentHistory_DataGrid.Columns[0].HeaderText = "ID";
                PaymentHistory_DataGrid.Columns[1].HeaderText = "Date";
                PaymentHistory_DataGrid.Columns[2].HeaderText = "Payment";
                PaymentHistory_DataGrid.Columns[3].HeaderText = "Balance after Payment";
                PaymentHistory_DataGrid.Columns[4].HeaderText = "Updated By";
               
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            if (PaymentHistory_DataGrid.Rows.Count > 0)
            {
                PaymentHistory_DataGrid.Rows[0].Selected = true;
            }

            }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            
            this.Hide();
        }

        private void btn_AddBilling_Click(object sender, EventArgs e)
        {
            if (PaymentHistory_DataGrid.SelectedRows.Count > 0)
            {
               
                SqlCommand cmd = new SqlCommand(
                "UPDATE Payment SET Status = 'Canceled' WHERE PaymentID = @PaymentID", sqlcon);

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@PaymentID", (int)(PaymentHistory_DataGrid.SelectedRows[0].Cells[0].Value));

                sqlcon.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    UpdateBalanceAfterPayment();
                    ShowPaymentHistory();
                    var ShowPatientInfo = Application.OpenForms.OfType<ShowPatientInfo>().First();
                    ShowPatientInfo.UpdateBillingAfterPayment();
                    ShowPatientInfo.ShowBilling();


                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                sqlcon.Close();
            }
        }
        
        private void getPaymentID()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                "SELECT PaymentID FROM Payment WHERE BillingID_fk = @BillingID AND Status = 'Completed'", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@BillingID", GlobalVariable.BillingID);
            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    paymentID.Add(row[0]);
                }
            
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
           

        }

        private void UpdateBalanceAfterPayment()
        {
            getPaymentID();
            bool _firstLoopDone = false;
            if (paymentID.Count > 0 && _firstLoopDone == false)
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Payment SET PaymentBalance = (SELECT AmountCharged FROM Billing WHERE BillingID = @BillingID) - " +
                    "(SELECT PaymentAmount FROM Payment WHERE PaymentID = @PaymentID) WHERE PaymentID = @PaymentID", sqlcon);

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@BillingID", GlobalVariable.BillingID);
                cmd.Parameters.AddWithValue("@PaymentID", paymentID[0]);
                if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                sqlcon.Close();
                _firstLoopDone = true;
            }
            if (paymentID.Count > 1 && _firstLoopDone == true) {
                for (int i = 1; i < paymentID.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand(
                    "UPDATE Payment SET PaymentBalance = (SELECT PaymentBalance FROM Payment WHERE PaymentID = @Payment1)" +
                    " - (SELECT PaymentAmount FROM Payment WHERE PaymentID = @Payment2) WHERE PaymentID = @Payment2", sqlcon);

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Payment1", paymentID[i - 1]);
                    cmd.Parameters.AddWithValue("@Payment2", paymentID[i]);
                    if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                    sqlcon.Close();
                }
            }
        }

     

    }
    
}
