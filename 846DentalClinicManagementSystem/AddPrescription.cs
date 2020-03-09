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
                int index = MedicineDD.selectedIndex;
                if (index == 0 || index == 1 || index == 2 || index == 6 || index == 7) //enable weight textbox
                {
                    txt_weight.ReadOnly = false;
                }
                else
                {
                    txt_weight.ReadOnly = true;
                }
      
                    LoadDosage();
            }
            
        }

        private void DosageDD_onItemSelected(object sender, EventArgs e)
        {

            string weight = txt_weight.Text.Trim();
            bool isWeightValid = Regex.IsMatch(weight, @"^[0-9]+$");


            if (!string.IsNullOrEmpty(weight) && isWeightValid)
            {
                if (DosageDD.selectedIndex >= 0)
                {
                    LoadNote();
                }
            }
            else
            {
                MessageBox.Show("Invalid Weight !");
                DosageDD.Clear();
                LoadDosage();
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

        private void LoadNote()
        {
            NoteDD.Clear(); // clear dropdown items
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                "SELECT Note FROM Prescription WHERE DosageID_fk = @DoseID", sqlcon);
            cmd.Parameters.AddWithValue("@DoseID", DosageDD.selectedIndex + 1);
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
                        int Medindex = MedicineDD.selectedIndex;
                        int DosIndex = DosageDD.selectedIndex;

                        if (!string.IsNullOrEmpty(txt_weight.Text))
                        {
                            weight = Convert.ToInt32(txt_weight.Text);
                        }
         
                        if(Medindex == 0)
                        {
                            if(DosIndex == 0)
                            {
                                finalDose = 25 * weight * 5 / 50 / 4; // mefenamic
                            }
                        }
                        else if(Medindex == 1)
                        {
                            if(DosIndex == 0)
                            {
                                finalDose = 20 * weight * 5 / 125 / 4; //paracetamol
                            }
                            else if(DosIndex == 1)
                            {
                                finalDose = 20 * weight * 5 / 250 / 4; // paracetamol
                            }
                        }else if(Medindex == 2)
                        {
                            if (DosIndex == 0)
                            {
                                finalDose = 5 * weight * 5 / 100; // ibuprofen
                            }
                            else if (DosIndex == 2)
                            {
                                finalDose = 10 * weight * 5 / 100; //ibuprofen
                            }
                        }
                        else if(Medindex == 6)
                        {
                            if (DosIndex == 0)
                            {
                                finalDose = 20 * weight * 5 / 125 / 3; //Amoxicillin
                            }
                            else if (DosIndex == 1)
                            {
                                finalDose = 20 * weight * 5 / 250 / 3; //Amoxicillin
                            }
                        }
                        else if(Medindex == 7)
                        {
                            if (DosIndex == 0)
                            {
                                finalDose = 20 * weight * 5 / 75 / 3; //Clindamycin
                            }
                           
                        }


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
                if (DosageDD.selectedIndex >= 0)
                {
                    if (NoteDD.selectedIndex >= 0)
                    {
                      

                        string CompletePrescription = string.Empty;
                        CompletePrescription = MedicineDD.selectedValue;
                        CompletePrescription += " (" + DosageDD.selectedValue + ")";
                        CompletePrescription += "  -  " + NoteDD.selectedValue;

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

        }
    }
}
