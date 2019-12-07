using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _846DentalClinicManagementSystem
{
    class GlobalVariable
    {
        public static string connString => ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

      //  public static SqlConnection sqlcon = new SqlConnection(connString);

        public static int AppointmentID { get; set; }
        
        public static int PatientID { get; set; }

        public static int TreatmentID { get; set; }

        public static int BillingID { get; set; }

        public static Boolean isEditAppointment { get; set; }

        public static Boolean isAddAppointment { get; set; }

        public static Boolean isEditPatient { get; set; }

        public static Boolean isAddPatient { get; set; }

        public static Boolean isAppointmentPatientExist { get; set; }

        public static string PatientName { get; set; }

        public static MainForm Main { get; set; }

        public static int ExpenseId { get; set; }

        public static Boolean isEditExpense { get; set; }

        public static Boolean isAddExpense { get; set; }

        // public static string Username { get; set; }

        public static Boolean isBillingStatementExist { get; set; }

        public static int LoginID { get; set; }

       // private static int s = 1;






    }
}
