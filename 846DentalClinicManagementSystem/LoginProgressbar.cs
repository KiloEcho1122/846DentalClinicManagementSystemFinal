﻿using System;
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
            Random random = new Random();
            int incre = random.Next(1, 5);

            this.progressBar1.Increment(incre + 3);
            label1.Text = ("Loading : " + progressBar1.Value + "%");
            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                MainForm objFrmMain = new MainForm();
                this.Hide();
                objFrmMain.Show();
            }
        }
    }
}
