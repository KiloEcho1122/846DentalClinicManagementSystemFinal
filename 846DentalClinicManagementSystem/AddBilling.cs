using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace _846DentalClinicManagementSystem
{
    public partial class AddBilling : Form
    {

        SqlConnection sqlcon = new SqlConnection(GlobalVariable.connString);

        public AddBilling()
        {
            InitializeComponent();
        }

       

        float[] TreatmentPrice;
        float TotalAmount = 0;
        List<TextBox> textboxes = new List<TextBox>();
        List<Label> labels = new List<Label>();

        private void AddBilling_Load(object sender, EventArgs e)
        {
           // InitializeComponent();
            if (GlobalVariable.isBillingStatementExist == true)
            {
                txt_formHeader.Text = "Update Billing Statement";
                btn_AddBilling.Text = "Update";

            }
            CreateControls();


        }

        private bool CheckPaymentMadeExist()
        {
            SqlCommand cmd = new SqlCommand(
                   "SELECT AmountPay FROM Billing WHERE AppointmentID_fk = @appNo ", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@appNo", GlobalVariable.AppointmentID);

            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                object obj = cmd.ExecuteScalar();
                if (obj != null && float.Parse(obj.ToString()) > 0) return true;

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            sqlcon.Close();
            return false;
        }

  
        private void CreateControls()
        {

            int xPositionLabel = 20;
            int yPositionLabel = 88; //125
            int xPositonTextBox = 249;
            int yPositionTextBox = 82; //119

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                "SELECT TreatmentType,TreatmentPrice FROM AppointmentTreatment " +
                "WHERE AppointmentID_fk = @appNo", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("appNo", GlobalVariable.AppointmentID);
            adapter.SelectCommand = cmd;
            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                adapter.Fill(dt);

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            sqlcon.Close();

            this.Height += 37 * dt.Rows.Count + 1;



            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string treatment = dt.Rows[i][0].ToString();
                Label label = addLabel(i, xPositionLabel, yPositionLabel, treatment);
                TextBox textBox = addTextBox(i, xPositonTextBox, yPositionTextBox);
                textboxes.Add(textBox);
                labels.Add(label);
                this.Controls.Add(label);
                textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
                textBox.KeyDown += new KeyEventHandler(this.textBox_KeyDown);
                this.Controls.Add(textBox);
                yPositionLabel += 37;
                yPositionTextBox += 37;
                if (GlobalVariable.isBillingStatementExist == true)
                {
                    textBox.Text = dt.Rows[i][1].ToString();
                }

            }

            lbl_TotalAmt.Top = yPositionLabel + 30;
            lbl_Total.Top = yPositionLabel + 30;
            btn_AddBilling.Top = yPositionLabel + 62;
            lbl_Total.TabIndex = dt.Rows.Count + 2;
            btn_AddBilling.TabIndex = dt.Rows.Count + 4;
            TreatmentPrice = new float[dt.Rows.Count]; //initialize size of array
         //   this.Location = new Point(1976, 380);
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);

            }


        }



        private void textBox_TextChanged(object sender, EventArgs e)
        {
            float TotalAmt = 0;
            // TextBox currentTextBox = (TextBox)sender;
            foreach (var txt in textboxes)
            {
                bool isPaymentValid = Regex.IsMatch(txt.Text, @"^(\(?\+?[0-9]*\)?)?[0-9\(\)]*$");
                if (isPaymentValid == true && string.IsNullOrWhiteSpace(txt.Text) == false)
                {
                    txt.BackColor = System.Drawing.Color.SeaGreen;
                    TotalAmt += float.Parse(txt.Text);

                }

            }

            lbl_Total.Text = "₱ " + TotalAmt.ToString();
            TotalAmount = TotalAmt;

        }



        Label addLabel(int i, int x, int y, string treatment)
        {
            //Bunifu.Framework.UI.BunifuCustomLabel();
            Label label = new Label();
            label.AutoSize = true;
            label.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label.ForeColor = System.Drawing.Color.Teal;
            label.Location = new System.Drawing.Point(x, y);
            label.Name = "TreatmentLabel" + i.ToString();
            label.Size = new System.Drawing.Size(121, 17);
            label.TabIndex = 40 + i;
            label.Text = treatment;
            return label;
        }

        TextBox addTextBox(int i, int x, int y)
        {
            TextBox textbox = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            textbox.BackColor = System.Drawing.Color.SeaGreen;
            //textbox.BorderColor = System.Drawing.Color.SeaGreen;
            textbox.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textbox.ForeColor = System.Drawing.SystemColors.Menu;
            textbox.Location = new System.Drawing.Point(x, y);
            textbox.Multiline = true;
            textbox.Name = "txt_AmtCharge" + i.ToString();
            textbox.Size = new System.Drawing.Size(121, 31);
            textbox.TabIndex = i + 1;
            return textbox;
        }


        private void btn_AddBilling_Click(object sender, EventArgs e)
        {
            AddBillingFunction();
        }

        private void AddBillingFunction()
        {
            if (CheckPaymentMadeExist())
            {
                MessageBox.Show("This Billing Statement Has Payment Exist" +
                    " Void first the payment before making changes", "Billing Statement", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool isValid = true;
                string message = "Add Billing Statement ?";
                if (GlobalVariable.isBillingStatementExist) message = "Update Billing Statement ?";
                
                DialogResult result = MessageBox.Show(message, "Billing Statement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    foreach (var txt in textboxes)
                    {
                        string payment = txt.Text.Trim();
                        bool isPaymentValid = Regex.IsMatch(payment, @"^(\(?\+?[0-9]*\)?)?[0-9\(\)]*$");
                        if (isPaymentValid == false || string.IsNullOrEmpty(payment))
                        {
                            isValid = false;
                            MessageBox.Show("Invalid Amount !");
                            txt.BackColor = System.Drawing.Color.Red;
                            txt.Focus();
                            break;
                        }

                    }

                    if (isValid == true)
                    {
                        for (int i = 0; i < textboxes.Count; i++)
                        {
                            float AmtCharge = float.Parse(textboxes[i].Text);
                            string TreatmentType = labels[i].Text.Trim();
                            InsertTreatmentPrice(AmtCharge, TreatmentType);


                        }
                        if (GlobalVariable.isBillingStatementExist)
                        {
                            UpdateBillingStatement();
                        }
                        else
                        {
                            CreateBillingStatement();
                        }
                        UpdatePatientTreatmentDB();
                        GlobalVariable.isBillingStatementExist = false;
                        this.Hide();

                    }
                }
            }

        }

        private void InsertTreatmentPrice(float AmtCharge, string TreatmentType)
        {
            SqlCommand cmd = new SqlCommand(
                    "UPDATE AppointmentTreatment SET TreatmentPrice = @TreatmentPrice " +
                    "WHERE AppointmentID_fk = @appNo AND TreatmentType = @TreatmentType", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@TreatmentPrice", AmtCharge);
            cmd.Parameters.AddWithValue("@appNo", GlobalVariable.AppointmentID);
            cmd.Parameters.AddWithValue("@TreatmentType", TreatmentType);

            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            sqlcon.Close();


        }
       

        private void UpdateBillingStatement()
        {
            SqlCommand cmd = new SqlCommand(
                    "UPDATE Billing SET AmountCharged = @AmtCharged, BillingBalance = @Balance" +
                    " WHERE AppointmentID_fk = @appNo ", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@AmtCharged", TotalAmount);
            cmd.Parameters.AddWithValue("@Balance", TotalAmount);
            cmd.Parameters.AddWithValue("@appNo", GlobalVariable.AppointmentID);

            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Billing Statement Updated!");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            sqlcon.Close();
        }

        private void CreateBillingStatement()
        {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Billing (AmountCharged,AmountPay,BillingBalance,PatientID_fk,AppointmentID_fk) " +
                    "VALUES (@AmtCharged,@AmtPay,@Balance,@PatientID,@appNo)", sqlcon);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@AmtCharged", TotalAmount);
                cmd.Parameters.AddWithValue("@AmtPay", 0);
                cmd.Parameters.AddWithValue("@Balance", TotalAmount);  //Default Balance is also the amount charge because there is no payment made yet
                cmd.Parameters.AddWithValue("@PatientID", GlobalVariable.PatientID);
                cmd.Parameters.AddWithValue("@appNo", GlobalVariable.AppointmentID);

            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
                {
                    cmd.ExecuteNonQuery();
                MessageBox.Show("Billing Statement Created!");
            }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                sqlcon.Close();
       

        }

        private string GetAppointmentTreatmentString()
        {
            string treatment_Price = "";

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                "SELECT TreatmentType,TreatmentPrice FROM AppointmentTreatment WHERE AppointmentID_fk = @appNo", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@appNo", GlobalVariable.AppointmentID);
            adapter.SelectCommand = cmd;
            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                adapter.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    treatment_Price += row[0].ToString() + " - " + row[1].ToString() + ",";
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            sqlcon.Close();

            return treatment_Price.Remove(treatment_Price.Length - 1);
        }


        private void UpdatePatientTreatmentDB()
        {
            string treatment_Price = GetAppointmentTreatmentString();
            SqlCommand cmd = new SqlCommand(
               "UPDATE [PatientTreatment] SET Treatment_Price = @treatment_price " +
               "WHERE AppointmentID_fk = @appNo ", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@treatment_price", treatment_Price);
            cmd.Parameters.AddWithValue("@appNo", GlobalVariable.AppointmentID);

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


        private void btn_Close_Click(object sender, EventArgs e)
        {
            GlobalVariable.isBillingStatementExist = false;
            this.Hide();
        }

        private void btn_AddBilling_KeyDown(object sender, KeyEventArgs e)
        {
            AddBillingFunction();
        }
    }
}
