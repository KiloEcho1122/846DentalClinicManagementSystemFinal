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
    public partial class AddDiagnosis : Form
    {
        public AddDiagnosis()
        {
            InitializeComponent();
            LoadTreatmentList();
        }
        SqlConnection sqlcon = new SqlConnection(GlobalVariable.connString);

        private void LoadTreatmentList()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                   "SELECT TreatmentType FROM Treatment ORDER BY TreatmentID ASC", sqlcon);
            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    //    this.TreatmentDD.AddItem(dt1.Rows[i][0].ToString());
                    Treatment_CB.Items.Add(row[0]);
                }


            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "dito ba yun");
            }
        }


        private void txt_formHeader_Click(object sender, EventArgs e)
        {
           
        }


      
        private void InsertToDataTable()
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
                "SELECT CONCAT(DentistLName,',',DentistFName, ' ', DentistMName), DentistLicenseNo," +
                "CONCAT(DentistFName, ' ', DentistMName, ' ', DentistLName) FROM Dentist WHERE DentistID = @DentistID", sqlcon);
            DentistCmd.Parameters.Clear();
            DentistCmd.Parameters.AddWithValue("@DentistID", GlobalVariable.LoginID);
            PatientAdapter.SelectCommand = PatientCmd;
            DentistAdapter.SelectCommand = DentistCmd;

            try
            {
                PatientAdapter.Fill(PatientTable);
                DentistAdapter.Fill(DentistTable);

            }catch(Exception ex) { Console.WriteLine(ex.Message); }


            dt1.Rows.Add(
                PatientTable.Rows[0][0].ToString(),
                PatientTable.Rows[0][1].ToString(),
                PatientTable.Rows[0][2].ToString(),
                PatientTable.Rows[0][3].ToString(),
                DentistTable.Rows[0][0].ToString(),
                DentistTable.Rows[0][1].ToString(),
                txt_Diagnosis.Text.Trim(),
                txt_Findings.Text.Trim(),
                Treatment_CB.Text.Trim(),
                GlobalVariable.chartImagePath
                // DentistTable.Rows[0][2].ToString()
                );

            //dt1.Rows.Add("Michael Mendiola", "22", "M", "186 Dr. Pilapil St. San Miguel Pasig City",
            //"Maranan, Esperanza G.", "20776", "Gingivitis", "Removal of tissues", "Deep Scaling", GlobalVariable.chartImagePath);

            DataTable dt = dt1;
            CrystalDecisions.CrystalReports.Engine.ReportDocument report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            report = new CrystalReport1();
            report.SetDataSource(dt);
            Certificate certificate = new Certificate();
            certificate.crystalReportViewer1.ReportSource = report;
            certificate.ShowDialog();
            certificate.Dispose();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Diagnosis.Text) == false)
            {
                if (string.IsNullOrWhiteSpace(txt_Findings.Text) == false)
                {
                    if (Treatment_CB.Text != "Select Treatment")
                    {
                        InsertToDataTable();
                        this.Hide();
                    }
                    else { MessageBox.Show("Invalid Treatment"); }
                }
                else { MessageBox.Show("Invalid Findings !"); }
            }
            else { MessageBox.Show("Invalid Diagnosis !"); }
        }
    }
}
