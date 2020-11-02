using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace _846DentalClinicManagementSystem
{
    class GlobalVariable
    {
     //   public static string connString => ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        private static string workingDirectory = Environment.CurrentDirectory;

        private static string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

        static string path = Path.GetFullPath(Environment.CurrentDirectory);

        private static string chart = path + @"\ISADDATABASEFINAL.mdf";

        public static string connString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=" + chart + ";Integrated Security = True";

        //public static string chartImagePath = projectDirectory + @"\Resources\DentalChart2.bmp";

        public static string chartImagePath = @"C:\846 Dental Mangement System\DentalChart2.bmp";

        public static int AppointmentID { get; set; }
        
        public static int PatientID { get; set; }

        public static int EmpID { get; set; }

        public static int TreatmentID { get; set; }

        public static int BillingID { get; set; }

        public static int AppExceptionID { get; set; }

        public static Boolean isEditAppException { get; set; }

        public static Boolean isAddAppException { get; set; }

        public static Boolean isEditAppointment { get; set; }

        public static Boolean isAddAppointment { get; set; }

        public static Boolean isEditPatient { get; set; }

        public static Boolean isAddPatient { get; set; }

        public static Boolean isEditEmployee { get; set; }

        public static Boolean isAddEmployee { get; set; }

        public static Boolean isAppointmentPatientExist { get; set; }

        public static string PatientName { get; set; }

        public static MainForm Main { get; set; }

        public static int ExpenseId { get; set; }

        public static Boolean isEditExpense { get; set; }

        public static Boolean isAddExpense { get; set; }

        // public static string Username { get; set; }

        public static Boolean isBillingStatementExist { get; set; }

        public static int EmployeeID { get; set; }

        public static string Permission { get; set; }

        public static string JobTitle { get; set; }

        public static string User_name { get; set; }

        public static int changePassID { get; set; }

        public static string changePassName { get; set; }

        //for click appointment variables
        public static  DateTime DateApp { get; set; }

        public static int timeApp { get; set; }

        public static int dentApp  { get; set; }

        public static Boolean IsAppAddPanelClick { get; set; }

        public static Boolean IsAppAddExceptionPanelClick { get; set; }

        //-------------------------------------



        public static void InsertActivityLog(string Description, string method)
        {
            SqlConnection sqlcon = new SqlConnection(connString);
            string ip = GetLocalIP();
            SqlCommand cmd = new SqlCommand("Insert Into [ActivityLogs] (Description,User_Name,Method,IP) VALUES(@desc,@user,@method,@ip)", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@desc", Description);
            cmd.Parameters.AddWithValue("@user", User_name);
            cmd.Parameters.AddWithValue("@method", method);
            cmd.Parameters.AddWithValue("@ip", ip);

            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Description);
            }
            sqlcon.Close();

        }

        private static string GetLocalIP()
        {
            string ip = string.Empty;
            try
            {
                string hostName = Dns.GetHostName();
                ip = Dns.GetHostEntry(hostName).AddressList[1].ToString();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ip;

        }

        // private static int s = 1;






    }
}
