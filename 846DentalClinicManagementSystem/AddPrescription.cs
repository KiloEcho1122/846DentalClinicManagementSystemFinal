using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _846DentalClinicManagementSystem
{
    public partial class AddPrescription : Form
    {
        public AddPrescription()
        {
            InitializeComponent();
        }
        SqlConnection sqlcon = new SqlConnection(GlobalVariable.connString);

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {

        }

        private void AddPrescription_Load(object sender, EventArgs e)
        {
            LoadMedicine();
        }

        private void MedicineDD_onItemSelected(object sender, EventArgs e)
        {
            if(MedicineDD.selectedIndex >= 0)
            {
                //int index = MedicineDD.selectedIndex;
                //if (index == 0 || index == 1 || index == 2 || index == 6 || index == 7) //enable weight textbox
                //{
                //    txt_weight.ReadOnly = false;
                //}
                //else
                //{
                //    txt_weight.ReadOnly = true;
                //}
      
                    LoadDosage();
            }
            
        }

        private void DosageDD_onItemSelected(object sender, EventArgs e)
        {

            int index = getDosageID();
            if (DosageDD.selectedIndex >= 0)
            {
                if (index == 1 || index == 3 || index == 4 || index == 6 || index == 7 || index == 15 || index == 16 || index == 18) //enable weight textbox
                {
                    txt_weight.ReadOnly = false;
                }
                else
                {
                    txt_weight.ReadOnly = true;
                }
                LoadNote();
            }

        }

        private void NoteDD_onItemSelected(object sender, EventArgs e)
        {
            string weight = txt_weight.Text.Trim();
            bool isWeightValid = Regex.IsMatch(weight, @"^[0-9]+$");

            if (txt_weight.ReadOnly == false)
            {
                if (!(!string.IsNullOrEmpty(weight) && isWeightValid && txt_weight.ReadOnly == false)) 
                {
                    MessageBox.Show("Invalid Weight !");
                    NoteDD.Clear();
                    txt_weight.Focus();
                }
              
            }
           
        }

        private void txt_weight_TextChanged(object sender, EventArgs e)
        {
            string weight = txt_weight.Text.Trim();
            bool isWeightValid = Regex.IsMatch(weight, @"^[0-9]+$");
            if (!string.IsNullOrEmpty(weight) && isWeightValid)
            {
                NoteDD.Clear();
                LoadNote();
            }
        }

        private void LoadMedicine()
        {
            MedicineDD.Clear(); // clear dropdown items
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                "SELECT MedicineType FROM Medicine",sqlcon);
            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);

                if(dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        MedicineDD.AddItem(row[0].ToString());
                    }
                }
               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void LoadDosage()
        {
            DosageDD.Clear(); // clear dropdown items
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                "SELECT DosageType FROM Dosage WHERE MedicineID_fk = @MedID", sqlcon);
            cmd.Parameters.AddWithValue("@MedID",MedicineDD.selectedIndex + 1);
            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        DosageDD.AddItem(row[0].ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

       

        private int getDosageID()
        {
            int id = 0;
            string DosageType = DosageDD.selectedValue;
            int MedicineID = MedicineDD.selectedIndex + 1;
            SqlCommand cmd = new SqlCommand(
                "SELECT DosageID FROM Dosage WHERE DosageType = @Dosage AND MedicineID_fk = @MedID",sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Dosage", DosageType);
            cmd.Parameters.AddWithValue("@MedID", MedicineID);
            try
            {
                if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
                object obj = cmd.ExecuteScalar();
                if(obj != null)
                {
                    id = (int)obj;
                } 
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            sqlcon.Close();

            return id;
        }


        private void LoadNote()
        {
            int DosageID = getDosageID();
            NoteDD.Clear(); // clear dropdown items
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                "SELECT Note FROM Prescription WHERE DosageID_fk = @DoseID", sqlcon);
            cmd.Parameters.AddWithValue("@DoseID", DosageID);
            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        int finalDose = 0;
                        int weight = 0;
                     //   int Medindex = MedicineDD.selectedIndex;
                      //  int DosIndex = DosageDD.selectedIndex;

                        if (!string.IsNullOrEmpty(txt_weight.Text))
                        {
                            weight = Convert.ToInt32(txt_weight.Text);
                        }

                        if (DosageID == 1)
                        {
                            finalDose = 25 * weight * 5 / 50 / 4; // mefenamic
                        }
                        else if (DosageID == 3)
                        {
                            finalDose = 20 * weight * 5 / 125 / 4; //paracetamol
                        }
                        else if (DosageID == 4)
                        {
                            finalDose = 20 * weight * 5 / 250 / 4; // paracetamol
                        }
                        else if (DosageID == 6)
                        {
                            finalDose = 5 * weight * 5 / 100; // ibuprofen
                        }
                        else if (DosageID == 7)
                        {
                            finalDose = 10 * weight * 5 / 100; //ibuprofen
                        }
                        else if (DosageID == 15)
                        {
                            finalDose = 20 * weight * 5 / 125 / 3; //Amoxicillin
                        }
                        else if (DosageID == 16)
                        {
                            finalDose = 20 * weight * 5 / 250 / 3; //Amoxicillin
                        }
                        else if (DosageID == 18)
                        {
                            finalDose = 20 * weight * 5 / 75 / 3; //Clindamycin
                        }

                        //if(Medindex == 0)
                        //{
                        //    if(DosIndex == 0)
                        //    {
                        //        finalDose = 25 * weight * 5 / 50 / 4; // mefenamic
                        //    }
                        //}
                        //else if(Medindex == 1)
                        //{
                        //    if(DosIndex == 0)
                        //    {
                        //        finalDose = 20 * weight * 5 / 125 / 4; //paracetamol
                        //    }
                        //    else if(DosIndex == 1)
                        //    {
                        //        finalDose = 20 * weight * 5 / 250 / 4; // paracetamol
                        //    }
                        //}else if(Medindex == 2)
                        //{
                        //    if (DosIndex == 0)
                        //    {
                        //        finalDose = 5 * weight * 5 / 100; // ibuprofen
                        //    }
                        //    else if (DosIndex == 1)
                        //    {
                        //        finalDose = 10 * weight * 5 / 100; //ibuprofen
                        //    }
                        //}
                        //else if(Medindex == 6)
                        //{
                        //    if (DosIndex == 0)
                        //    {
                        //        finalDose = 20 * weight * 5 / 125 / 3; //Amoxicillin
                        //    }
                        //    else if (DosIndex == 1)
                        //    {
                        //        finalDose = 20 * weight * 5 / 250 / 3; //Amoxicillin
                        //    }
                        //}
                        //else if(Medindex == 7)
                        //{
                        //    if (DosIndex == 0)
                        //    {
                        //        finalDose = 20 * weight * 5 / 75 / 3; //Clindamycin
                        //    }
                           
                        //}


                        row[0] = row[0].ToString().Replace("_", finalDose.ToString());
                        NoteDD.AddItem(row[0].ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
         

            if (MedicineDD.selectedIndex >= 0)
            {
                if (DosageDD.selectedIndex >= 0 || MedicineDD.selectedIndex >= 14)
                {
                    if (NoteDD.selectedIndex >= 0 || MedicineDD.selectedIndex >= 14)
                    {
                        string CompletePrescription = string.Empty;

                        if (MedicineDD.selectedIndex >= 14)
                        {

                            CompletePrescription = QuantityDD.selectedValue;
                            CompletePrescription += " - " + MedicineDD.selectedValue;
                          
                        }
                        else
                        {

                            CompletePrescription = QuantityDD.selectedValue;
                            CompletePrescription += " -  " + MedicineDD.selectedValue;
                            CompletePrescription += " " + DosageDD.selectedValue;
                            CompletePrescription += "  -  " + NoteDD.selectedValue; ;
                        }

                        PrevList.Items.Add(CompletePrescription);

                        if (!string.IsNullOrEmpty(txt_AddNote.Text))
                        {
                            PrevList.Items.Add(txt_AddNote.Text);
                            txt_AddNote.Clear();
                        }

                        MedicineDD.Clear();
                        DosageDD.Clear();
                        NoteDD.Clear();
                        txt_weight.Clear();
                        QuantityDD.selectedIndex = 0;
                        txt_weight.ReadOnly = true;
                        LoadMedicine();
                    }
                    else
                    {
                        MessageBox.Show("Please Select Note !");
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Dosage !");
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txt_AddNote.Text))
                {
                    PrevList.Items.Add(txt_AddNote.Text);
                    txt_AddNote.Clear();
                }
                else
                {
                    MessageBox.Show("Please Select Medicine !");
                }
           
               
            }

            if (!string.IsNullOrEmpty(txt_AddNote.Text))
            {
                PrevList.Items.Add(txt_AddNote.Text);
                txt_AddNote.Clear();
            }
        }

        private void lbl_Close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            if(PrevList.SelectedIndex > -1 )
            {
                DialogResult result = MessageBox.Show("Remove " + PrevList.SelectedItem + " ?", "Remove Treatment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    PrevList.Items.RemoveAt(PrevList.SelectedIndex);

                }
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
  
            PrintPrescription();
            addPrescriptionToDatabase();
            var ShowPatientInfo = Application.OpenForms.OfType<ShowPatientInfo>().First();
            ShowPatientInfo.LoadTreatmentHistory();
            this.Hide();
        }

        private void PrintPrescription()
        {
            DataSet1.dtDataDataTable dt1 = new DataSet1.dtDataDataTable();

            DataTable PatientTable = new DataTable();
            DataTable DentistTable = new DataTable();
            SqlDataAdapter PatientAdapter = new SqlDataAdapter();
            SqlDataAdapter DentistAdapter = new SqlDataAdapter();
            SqlCommand PatientCmd = new SqlCommand(
                "SELECT PatientFullName,PatientAge,PatientGender,PatientAddress FROM Patient WHERE PatientID = @PatientID", sqlcon);
            PatientCmd.Parameters.Clear();
            PatientCmd.Parameters.AddWithValue("@PatientID", GlobalVariable.PatientID);
            SqlCommand DentistCmd = new SqlCommand(
                "SELECT CONCAT(LastName,',',FirstName, ' ', MiddleName), LicenseNo," +
                "CONCAT(FirstName, ' ', MiddleName, ' ', LastName) FROM Employee WHERE EmployeeID = @EmployeeID AND JobTitle ='Dentist' ", sqlcon);
            DentistCmd.Parameters.Clear();
            DentistCmd.Parameters.AddWithValue("@EmployeeID", GlobalVariable.EmployeeID);
            PatientAdapter.SelectCommand = PatientCmd;
            DentistAdapter.SelectCommand = DentistCmd;

            try
            {
                PatientAdapter.Fill(PatientTable);
                DentistAdapter.Fill(DentistTable);

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            try
            {
                dt1.Rows.Add(
               PatientTable.Rows[0][0].ToString(),
               PatientTable.Rows[0][1].ToString(),
               PatientTable.Rows[0][2].ToString(),
               PatientTable.Rows[0][3].ToString(),
               DentistTable.Rows[0][2].ToString(),
               //DentistTable.Rows[0][0].ToString(),
               DentistTable.Rows[0][1].ToString()
               // DentistTable.Rows[0][2].ToString()
               );

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            //dt1.Rows.Add("Michael Mendiola", "22", "M", "186 Dr. Pilapil St. San Miguel Pasig City",
            //"Maranan, Esperanza G.", "20776", "Gingivitis", "Removal of tissues", "Deep Scaling", GlobalVariable.chartImagePath);

            DataTable dt = dt1;

            DataTable PrescriptionTable = new DataTable();

            PrescriptionTable.Columns.Add("Medicine", typeof(string));
            PrescriptionTable.Columns.Add("Quantity", typeof(string));
            PrescriptionTable.Columns.Add("Description", typeof(string));


            for (int i = 0; i < PrevList.Items.Count; i++)
            {
                string str = PrevList.Items[i].ToString();
                string[] tokens = str.Split(new[] { " - " }, StringSplitOptions.None);

                if (tokens.Length == 3)
                {
                    PrescriptionTable.Rows.Add(
                   i + 1 + ")   " + tokens[1],
                   "#" + tokens[0],
                   tokens[2]
                   );
                }
                else
                {
                    PrescriptionTable.Rows.Add(
                  i + 1 + ")   " + tokens[1],
                  "#" + tokens[0]
                  );
                }


            }

            CrystalDecisions.CrystalReports.Engine.ReportDocument report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            report = new CrystalReport7();
            report.Database.Tables["Prescription"].SetDataSource(PrescriptionTable);
            report.Database.Tables["dtData"].SetDataSource(dt);
            //  report.Database.Tables["dtTreatmentPrice"].SetDataSource(TreatmentPriceTable);
            AccountingReportForm accounting = new AccountingReportForm();
            accounting.crystalReportViewer1.ReportSource = report;
            accounting.ShowDialog();
            accounting.Dispose();
        }

        private void addPrescriptionToDatabase()
        {
            string FullPrescription = String.Empty;
            foreach(var items in PrevList.Items)
            {
                FullPrescription += items.ToString() + ",";
            }
            FullPrescription = FullPrescription.Remove(FullPrescription.Length - 1);

            SqlCommand cmd = new SqlCommand(
                "UPDATE PatientTreatment SET Prescription = @Prescription WHERE PatientTreatmentID = " +
                "(SELECT TOP 1 PatientTreatmentID FROM PatientTreatment WHERE PatientID_fk = @PatientID ORDER BY PatientTreatmentID DESC)", sqlcon); // update the recent patient treatment
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Prescription", FullPrescription);
            cmd.Parameters.AddWithValue("@PatientID", GlobalVariable.PatientID);
            try
            {
                if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
                cmd.ExecuteNonQuery();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                sqlcon.Close();
            }
            sqlcon.Close();
        }
    }
}
