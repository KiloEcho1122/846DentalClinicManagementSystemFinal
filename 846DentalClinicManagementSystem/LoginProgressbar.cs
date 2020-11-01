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
    public partial class LoginProgressbar : Form
    {
        public LoginProgressbar()
        {
            InitializeComponent();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void LoginProgressbar_Load(object sender, EventArgs e)
        {
            this.timer1.Start();
    
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Random random = new Random();
                int incre = random.Next(1, 5);

                this.progressBar1.Increment(incre + 3);
                lbl_percent.Text = (progressBar1.Value + "%");
                if (progressBar1.Value == 100)
                {

                    label1.Text = "Loading Complete....";
                    timer1.Stop();
                    MainForm objFrmMain = new MainForm();
                    objFrmMain.Show();
                    this.Hide();

                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                label1.Text = "Loading Complete....";
                timer1.Stop();
                MainForm objFrmMain = new MainForm();
                objFrmMain.Show();
                this.Hide();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
