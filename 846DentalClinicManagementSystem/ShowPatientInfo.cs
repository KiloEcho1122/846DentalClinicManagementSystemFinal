﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;

namespace _846DentalClinicManagementSystem
{
    public partial class ShowPatientInfo : Form
    {
        public ShowPatientInfo()
        {
            InitializeComponent();
        }

        int LatestNoteID = 0;

        private void ShowPatientInfo_Load(object sender, EventArgs e)
        {
            lbl_PatientName.Text = GlobalVariable.PatientName;
            Payment_Panel.Visible = false;
            ShowBilling();
            Billing_DataGrid.Width = 922;

        }


        private void PatientInfoTAB_Deselected(object sender, TabControlEventArgs e)
        {
            PreviousTab = e.TabPage;
        }

        TabPage PreviousTab = new TabPage();
        TabPage CurrentTab = new TabPage();
        private void PatientInfoTAB_Click(object sender, EventArgs e)
        {
            if (GlobalVariable.Permission == "Admin" || GlobalVariable.JobTitle == "Dentist")
            {
                if (this.PatientInfoTAB.SelectedTab == tabPage2)
                {
                    SetDefaultTeethColor();
                    initializeTeethOperation();
                    TeethArray.Clear();
                    RetrievePatientTeethStatus();
                    GlobalVariable.InsertActivityLog("Viewed Tooth Chart, Patient ID = " + GlobalVariable.PatientID, "View");

                }
                else if (this.PatientInfoTAB.SelectedTab == TreatmentHistory_TAB)
                {
                    LoadTreatmentHistory();
                    GlobalVariable.InsertActivityLog("Viewed Treatment History, Patient ID = " + GlobalVariable.PatientID, "View");
                }
                else if (this.PatientInfoTAB.SelectedTab == Notes_TAB)
                {
                   // DrawStickyNotes();
                    NotesLayoutPanel.Controls.Clear();
                    LoadNotes();
                    LatestNoteID = getNextNoteID();
                    GlobalVariable.InsertActivityLog("Viewed Dentist Notes, Patient ID = " + GlobalVariable.PatientID, "View");
                }

            }
            else
            {
                if (this.PatientInfoTAB.SelectedTab == tabPage2)
                {
                    panel1.Visible = false;
                    panel3.Visible = false;
                    panel6.Visible = false;
                    PatientInfoTAB.SelectedTab = PreviousTab;
                    MessageBox.Show("Permission Denied !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (this.PatientInfoTAB.SelectedTab == TreatmentHistory_TAB)
                {
                    LoadTreatmentHistory();
                    GlobalVariable.InsertActivityLog("Viewed Treatment History, Patient ID = " + GlobalVariable.PatientID, "View");
                }

                else if (this.PatientInfoTAB.SelectedTab == Notes_TAB)
                {
                    NotesLayoutPanel.Controls.Clear();
                    LoadNotes();
                    LatestNoteID = getNextNoteID();
                    GlobalVariable.InsertActivityLog("Viewed Dentist Notes, Patient ID = " + GlobalVariable.PatientID, "View");
                }
            }

        }


        SqlConnection sqlcon = new SqlConnection(GlobalVariable.connString);
      //  Boolean NoteIsEdit;
       
        // Inside each polygon - it determines the clickable part of the shape to change its fill color 
        Rectangle TopRectangle = new Rectangle(10, 0, 10, 10);
        Rectangle BottomRectangle = new Rectangle(10, 20, 10, 10);
        Rectangle LeftRectangle = new Rectangle(0, 10, 10, 10);
        Rectangle RightRectangle = new Rectangle(20, 10, 10, 10);

        // This is the Border Line of the teeth or the shape itself
        Rectangle InsideRectangle = new Rectangle(10, 10, 10, 10);                                  //Center Teeth
        Point[] a = { new Point(0, 0), new Point(30, 0), new Point(20, 10), new Point(10, 10) };    //Top Teeth
        Point[] b = { new Point(0, 0), new Point(0, 30), new Point(10, 20), new Point(10, 10) };    //Left Teeth
        Point[] c = { new Point(0, 30), new Point(30, 30), new Point(20, 20), new Point(10, 20) };  //Bottom Teeth
        Point[] d = { new Point(30, 30), new Point(30, 0), new Point(20, 10), new Point(20, 20) };  //Right Teeth

        // This is another border line inside the shape, this is where you color the shape
        Point[] TopPolygonFill = { new Point(1, 1), new Point(29, 1), new Point(19, 10), new Point(11, 10) };
        Point[] LeftPolygonFill = { new Point(1, 1), new Point(1, 29), new Point(10, 19), new Point(10, 11) };
        Point[] BottomPolygonFill = { new Point(0, 30), new Point(30, 30), new Point(20, 20), new Point(10, 21) };
        Point[] RightPolygonFill = { new Point(30, 30), new Point(30, 0), new Point(21, 10), new Point(21, 20) };
        Rectangle InsideRectangleFill = new Rectangle(11, 11, 9, 9);

        // Pen

        Pen p = new Pen(new SolidBrush(Color.Black));
        Pen p1 = new Pen(new SolidBrush(Color.Transparent));
        Pen p2 = new Pen(new SolidBrush(Color.Blue), 2);
        Pen p3 = new Pen(new SolidBrush(Color.Red), 2);

        //Solid Brush or Fill Color 
        SolidBrush TeethBrushColor = null;
        SolidBrush white = new SolidBrush(Color.White);

        //
        Boolean reSize = false;

        //Teeth Legend Icon
        Image TeethLegend;

        //Teeth String Status
        string TeethStatus = null;

        //Global Varible
        int PatientID = GlobalVariable.PatientID;

        //Array
        ArrayList TeethArray = new ArrayList();
        SolidBrush[] ToothColorBrush = new SolidBrush[16];
        Image[] ToothImage = new Image[16];

        //Teeth Parts Array
        string[] TopTeethColor = new string[52];
        string[] BottomTeethColor = new string[52];
        string[] LeftTeethColor = new string[52];
        string[] RightTeethColor = new string[52];
        string[] CenterTeethColor = new string[52];
        string[] TeethOperation = new string[16];
        
        private void SetDefaultTeethColor()
        {
            for (int i = 0; i < 52; i++)
            {
                TopTeethColor[i] = "OK";
                BottomTeethColor[i] = "OK";
                LeftTeethColor[i] = "OK";
                RightTeethColor[i] = "OK";
                CenterTeethColor[i] = "OK";
             
            }
        }
        private void initializeTeethOperation()
        {
            TeethOperation[0] = "OK";
            TeethOperation[1] = "M";
            TeethOperation[2] = "RF";
            TeethOperation[3] = "Implant";
            TeethOperation[4] = "Impacted";
            TeethOperation[5] = "Caries";
            TeethOperation[6] = "Composite";
            TeethOperation[7] = "Amalgram";
            TeethOperation[8] = "Recurrent";
            TeethOperation[9] = "PFM";
            TeethOperation[10] = "CER";
            TeethOperation[11] = "GC";
            TeethOperation[12] = "MC";
            TeethOperation[13] = "CERIO";
            TeethOperation[14] = "GIO";
            TeethOperation[15] = "MIO";

            ToothColorBrush[0] = new SolidBrush(Color.White);
            ToothColorBrush[1] = new SolidBrush(Color.White);
            ToothColorBrush[2] = new SolidBrush(Color.White);
            ToothColorBrush[3] = new SolidBrush(Color.White);
            ToothColorBrush[4] = new SolidBrush(Color.White);
            ToothColorBrush[5] = new SolidBrush(Color.FromArgb(237, 28, 36));
            ToothColorBrush[6] = new SolidBrush(Color.FromArgb(64, 0, 128));
            ToothColorBrush[7] = new SolidBrush(Color.FromArgb(127, 127, 127));
            ToothColorBrush[8] = new SolidBrush(Color.FromArgb(255, 128, 64));
            ToothColorBrush[9] = new SolidBrush(Color.FromArgb(207, 181, 59));
            ToothColorBrush[10] = new SolidBrush(Color.FromArgb(240, 230, 120));
            ToothColorBrush[11] = new SolidBrush(Color.FromArgb(255, 215, 0));
            ToothColorBrush[12] = new SolidBrush(Color.FromArgb(195, 195, 195));
            ToothColorBrush[13] = new SolidBrush(Color.FromArgb(240, 230, 120));
            ToothColorBrush[14] = new SolidBrush(Color.FromArgb(255, 215, 0));
            ToothColorBrush[15] = new SolidBrush(Color.FromArgb(195, 195, 195));

            ToothImage[0] = Properties.Resources.check_mark;
            ToothImage[1] = Properties.Resources.M;
            ToothImage[2] = Properties.Resources.RF;
            ToothImage[3] = Properties.Resources.icons8_dental_implant_50;
            ToothImage[4] = Properties.Resources.IMP;
            ToothImage[5] = null;
            ToothImage[6] = null;
            ToothImage[7] = null;
            ToothImage[8] = null;
            ToothImage[9] = Properties.Resources.pfm;
            ToothImage[10] = Properties.Resources.cer;
            ToothImage[11] = Properties.Resources.gc;
            ToothImage[12] = Properties.Resources.mc;
            ToothImage[13] = Properties.Resources.CERIO;
            ToothImage[14] = Properties.Resources.GIO;
            ToothImage[15] = Properties.Resources.MIO;

        }

        private void TeethPanel1_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel1);
        private void TeethPanel2_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel2);
        private void TeethPanel3_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel3);
        private void TeethPanel4_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel4);
        private void TeethPanel5_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel5);
        private void TeethPanel6_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel6);
        private void TeethPanel7_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel7);
        private void TeethPanel8_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel8);
        private void TeethPanel9_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel9);
        private void TeethPanel10_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel10);
        private void TeethPanel11_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel11);
        private void TeethPanel12_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel12);
        private void TeethPanel13_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel13);
        private void TeethPanel14_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel14);
        private void TeethPanel15_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel15);
        private void TeethPanel16_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel16);
        private void TeethPanel17_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel17);
        private void TeethPanel18_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel18);
        private void TeethPanel19_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel19);
        private void TeethPanel20_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel20);
        private void TeethPanel21_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel21);
        private void TeethPanel22_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel22);
        private void TeethPanel23_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel23);
        private void TeethPanel24_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel24);
        private void TeethPanel25_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel25);
        private void TeethPanel26_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel26);
        private void TeethPanel27_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel27);
        private void TeethPanel28_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel28);
        private void TeethPanel29_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel29);
        private void TeethPanel30_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel30);
        private void TeethPanel31_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel31);
        private void TeethPanel32_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel32);
        private void TeethPanel33_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel33);
        private void TeethPanel34_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel34);
        private void TeethPanel35_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel35);
        private void TeethPanel36_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel36);
        private void TeethPanel37_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel37);
        private void TeethPanel38_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel38);
        private void TeethPanel39_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel39);
        private void TeethPanel40_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel40);
        private void TeethPanel41_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel41);
        private void TeethPanel42_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel42);
        private void TeethPanel43_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel43);
        private void TeethPanel44_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel44);
        private void TeethPanel45_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel45);
        private void TeethPanel46_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel46);
        private void TeethPanel47_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel47);
        private void TeethPanel48_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel48);
        private void TeethPanel49_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel49);
        private void TeethPanel50_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel50);
        private void TeethPanel51_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel51);
        private void TeethPanel52_Paint(object sender, PaintEventArgs e) => DrawTeeth(TeethPanel52);


        private void DrawTeeth(Panel TeethPanel)
        {

            Graphics gs = TeethPanel.CreateGraphics();
            gs.DrawRectangle(p, InsideRectangle);
            gs.DrawRectangle(p1, InsideRectangleFill);

            gs.DrawPolygon(p, a);
            gs.DrawPolygon(p, b);
            gs.DrawPolygon(p, c);
            gs.DrawPolygon(p, d);

            gs.DrawPolygon(p1, TopPolygonFill);
            gs.DrawPolygon(p1, LeftPolygonFill);
            gs.DrawPolygon(p1, BottomPolygonFill);
            gs.DrawPolygon(p1, RightPolygonFill);

        }


        // Mouse Click event to call FillTeeth Function
        private void TeethPanel1_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel1, e, 0);
        private void TeethPanel2_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel2, e, 1);
        private void TeethPanel3_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel3, e, 2);
        private void TeethPanel4_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel4, e, 3);
        private void TeethPanel5_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel5, e, 4);
        private void TeethPanel6_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel6, e, 5);
        private void TeethPanel7_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel7, e, 6);
        private void TeethPanel8_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel8, e, 7);
        private void TeethPanel9_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel9, e, 8);
        private void TeethPanel10_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel10, e, 9);
        private void TeethPanel11_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel11, e, 10);
        private void TeethPanel12_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel12, e, 11);
        private void TeethPanel13_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel13, e, 12);
        private void TeethPanel14_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel14, e, 13);
        private void TeethPanel15_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel15, e, 14);
        private void TeethPanel16_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel16, e, 15);
        private void TeethPanel17_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel17, e, 16);
        private void TeethPanel18_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel18, e, 17);
        private void TeethPanel19_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel19, e, 18);
        private void TeethPanel20_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel20, e, 19);
        private void TeethPanel21_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel21, e, 20);
        private void TeethPanel22_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel22, e, 21);
        private void TeethPanel23_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel23, e, 22);
        private void TeethPanel24_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel24, e, 23);
        private void TeethPanel25_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel25, e, 24);
        private void TeethPanel26_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel26, e, 25);
        private void TeethPanel27_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel27, e, 26);
        private void TeethPanel28_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel28, e, 27);
        private void TeethPanel29_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel29, e, 28);
        private void TeethPanel30_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel30, e, 29);
        private void TeethPanel31_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel31, e, 30);
        private void TeethPanel32_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel32, e, 31);
        private void TeethPanel33_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel33, e, 32);
        private void TeethPanel34_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel34, e, 33);
        private void TeethPanel35_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel35, e, 34);
        private void TeethPanel36_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel36, e, 35);
        private void TeethPanel37_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel37, e, 36);
        private void TeethPanel38_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel38, e, 37);
        private void TeethPanel39_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel39, e, 38);
        private void TeethPanel40_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel40, e, 39);
        private void TeethPanel41_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel41, e, 40);
        private void TeethPanel42_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel42, e, 41);
        private void TeethPanel43_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel43, e, 42);
        private void TeethPanel44_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel44, e, 43);
        private void TeethPanel45_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel45, e, 44);
        private void TeethPanel46_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel46, e, 45);
        private void TeethPanel47_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel47, e, 46);
        private void TeethPanel48_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel48, e, 47);
        private void TeethPanel49_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel49, e, 48);
        private void TeethPanel50_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel50, e, 49);
        private void TeethPanel51_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel51, e, 50);
        private void TeethPanel52_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel52, e, 51);


        // Function to fill teeth by parts
        private void FillTeeth(Panel TeethPanel, MouseEventArgs e, int index)
        {
            Graphics gs = TeethPanel.CreateGraphics();
            
           


            if (string.IsNullOrEmpty(TeethStatus) == false)
            {

                if (this.TopRectangle.Contains(e.Location))
                {
                    gs.FillPolygon(TeethBrushColor, TopPolygonFill);
                    TopTeethColor[index] = TeethStatus;
                    DrawIconOnClick(index, TeethPanel.Left);
                }
                else if (this.BottomRectangle.Contains(e.Location))
                {
                    gs.FillPolygon(TeethBrushColor, BottomPolygonFill);
                    BottomTeethColor[index] = TeethStatus;
                    DrawIconOnClick(index, TeethPanel.Left);
                }
                else if (this.LeftRectangle.Contains(e.Location))
                {
                    gs.FillPolygon(TeethBrushColor, LeftPolygonFill);
                    LeftTeethColor[index] = TeethStatus;
                    DrawIconOnClick(index, TeethPanel.Left);
                }
                else if (this.RightRectangle.Contains(e.Location))
                {
                    gs.FillPolygon(TeethBrushColor, RightPolygonFill);
                    RightTeethColor[index] = TeethStatus;
                    DrawIconOnClick(index, TeethPanel.Left);
                }
                else if (this.InsideRectangle.Contains(e.Location))
                {
                    gs.FillRectangle(TeethBrushColor, InsideRectangleFill);
                    CenterTeethColor[index] = TeethStatus;
                    DrawIconOnClick(index, TeethPanel.Left);
                }

                // if ever na merong ibang operation sa ibang part ng teeth
                // iooverwrite nya kasi one operation lang pwede per teeth
                if (TopTeethColor[index] != TeethStatus)
                {
                    gs.FillPolygon(white, TopPolygonFill);
                    TopTeethColor[index] = TeethOperation[0];
                }
                if (BottomTeethColor[index] != TeethStatus)
                {
                    gs.FillPolygon(white, BottomPolygonFill);
                    BottomTeethColor[index] = TeethOperation[0];
                }
                if (LeftTeethColor[index] != TeethStatus)
                {
                    gs.FillPolygon(white, LeftPolygonFill);
                    LeftTeethColor[index] = TeethOperation[0];
                }
                if (RightTeethColor[index] != TeethStatus)
                {
                    gs.FillPolygon(white, RightPolygonFill);
                    RightTeethColor[index] = TeethOperation[0];
                }
                if (CenterTeethColor[index] != TeethStatus)
                {
                    gs.FillRectangle(white, InsideRectangleFill);
                    CenterTeethColor[index] = TeethOperation[0];
                }


            }
            else
            {
                MessageBox.Show("Please Pick Operation !");
            }

            if (!(TeethArray.Contains(index)))
            {
                TeethArray.Add(index);
            }
        }

        private void DrawIconOnClick(int index,int left)
        {
            PictureBox icon = new PictureBox();
            icon = IconNumber(index);
            icon.Image = TeethLegend;
            if (reSize)
            {
                icon.Size = new Size(33, 16);
                icon.Left = left;

            }
            else
            {
                icon.Size = new Size(20, 16);
                icon.Left = left + 7;
            }
        }


        //LEGEND -------------------------------------------------------------------------------------------
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            TeethBrushColor = ToothColorBrush[0];
            TeethLegend = ToothImage[0];
            TeethStatus = TeethOperation[0];
            reSize = false;
        }

        private void btn_Missing_Click(object sender, EventArgs e)
        {
            TeethBrushColor = ToothColorBrush[1];
            TeethLegend = ToothImage[1];
            TeethStatus = TeethOperation[1];
            reSize = false;
        }

        private void btn_RF_Click(object sender, EventArgs e)
        {
            TeethBrushColor = ToothColorBrush[2];
            TeethLegend = ToothImage[2];
            TeethStatus = TeethOperation[2];
            reSize = false;
        }

        private void btn_Implant_Click(object sender, EventArgs e)
        {
            TeethBrushColor = ToothColorBrush[3];
            TeethLegend = ToothImage[3];
            TeethStatus = TeethOperation[3];
            reSize = false;
        }

        private void btn_Impacted_Click(object sender, EventArgs e)
        {
            TeethBrushColor = ToothColorBrush[4];
            TeethLegend = ToothImage[4];
            TeethStatus = TeethOperation[4];
            reSize = false;
        }

        private void btn_Caries_Click(object sender, EventArgs e)
        {
            TeethBrushColor = ToothColorBrush[5];
            TeethLegend = ToothImage[5];
            TeethStatus = TeethOperation[5];
            reSize = false;
        }

        private void btn_Composite_Click(object sender, EventArgs e)
        {
            TeethBrushColor = ToothColorBrush[6];
            TeethLegend = ToothImage[6];
            TeethStatus = TeethOperation[6];
            reSize = false;
        }

        private void btn_Amalgram_Click(object sender, EventArgs e)
        {
            TeethBrushColor = ToothColorBrush[7];
            TeethLegend = ToothImage[7];
            TeethStatus = TeethOperation[7];
            reSize = false;
        }

        private void btn_Recurrent_Click(object sender, EventArgs e)
        {
            TeethBrushColor = ToothColorBrush[8];
            TeethLegend = ToothImage[8];
            TeethStatus = TeethOperation[8];
            reSize = false;
        }

        private void btn_PFM_Click(object sender, EventArgs e)
        {
            TeethBrushColor = ToothColorBrush[9];
            TeethLegend = ToothImage[9];
            TeethStatus = TeethOperation[9];
            reSize = true;
        }

        private void btn_CER_Click(object sender, EventArgs e)
        {
            TeethBrushColor = ToothColorBrush[10];
            TeethLegend = ToothImage[10];
            TeethStatus = TeethOperation[10];
            reSize = true;
        }

        private void btn_GC_Click(object sender, EventArgs e)
        {
            TeethBrushColor = ToothColorBrush[11];
            TeethLegend = ToothImage[11];
            TeethStatus = TeethOperation[11];
            reSize = true;

        }

        private void btn_MC_Click(object sender, EventArgs e)
        {
            TeethBrushColor = ToothColorBrush[12];
            TeethLegend = ToothImage[12];
            TeethStatus = TeethOperation[12];
            reSize = true;
        }
       
        private void btn_CERIO_Click(object sender, EventArgs e)
        {
            TeethBrushColor = ToothColorBrush[13];
            TeethLegend = ToothImage[13];
            TeethStatus = TeethOperation[13];
            reSize = true;
        }

        private void btn_GIO_Click(object sender, EventArgs e)
        {
            TeethBrushColor = ToothColorBrush[14];
            TeethLegend = ToothImage[14];
            TeethStatus = TeethOperation[14];
            reSize = true;
        }

        private void btn_MIO_Click(object sender, EventArgs e)
        {
            TeethBrushColor = ToothColorBrush[15];
            TeethLegend = ToothImage[15];
            TeethStatus = TeethOperation[15];
            reSize = true;
        }

        //---------------------------------------------------------------------------------------------------


        //return Teethpanel
        private Panel PanelNumber(int teethNumber)
        {
            teethNumber++;
            string PanelName = "TeethPanel" + teethNumber;

            foreach (Control panelControl in panel1.Controls)
            {
                if(panelControl is Panel)
                {
                    if (panelControl.Name == PanelName)
                    {
                        return (Panel)panelControl;
                    }

                }
            }
          
            return null;

        }

        //return icon number
        private PictureBox IconNumber(int iconNumber)
        {
            iconNumber++;
            string iconName = "icon" + iconNumber;

            foreach (Control icon in panel1.Controls)
            {
                if (icon is PictureBox)
                {
                    if (icon.Name == iconName)
                    {
                        return (PictureBox)icon;
                    }

                }
            }

            return null;
        }

        //insert teeth status to database
        private void insertTeethStatus(int TeethNum)
        {
            int TeethIDCount = 0;
            SqlCommand cmd = new SqlCommand(
                "Insert Into Teeth (TeethNumber,TeethTop,TeethBottom,TeethRight,TeethLeft,TeethCenter) " +
                "Values(@TeethNum,@Top,@Bottom,@Right,@Left,@Center) ", sqlcon);

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@TeethNum", TeethNum);
            cmd.Parameters.AddWithValue("@Top", TopTeethColor[TeethNum]);
            cmd.Parameters.AddWithValue("@Bottom", BottomTeethColor[TeethNum]);
            cmd.Parameters.AddWithValue("@Right", RightTeethColor[TeethNum]);
            cmd.Parameters.AddWithValue("@Left", LeftTeethColor[TeethNum]);
            cmd.Parameters.AddWithValue("@Center", CenterTeethColor[TeethNum]);

            SqlCommand cmd2 = new SqlCommand(
                "SELECT TOP 1 * FROM [Teeth] ORDER BY TeethID DESC", sqlcon);

            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                cmd.ExecuteNonQuery();
                TeethIDCount = Convert.ToInt32(cmd2.ExecuteScalar());
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            sqlcon.Close();
            // Console.WriteLine(TeethIDCount);
            InsertPatientTeeth(TeethIDCount);

        }

        private void InsertPatientTeeth(int TeethID_fk)
        {
           
            SqlCommand cmd = new SqlCommand(
                "Insert Into [PatientTeeth] (PatientID_fk,TeethID_fk,EmployeeID_fk) " +
                "Values(@PatientID_fk,@TeethID_fk,@EmployeeID_fk) ", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@PatientID_fk", PatientID);
            cmd.Parameters.AddWithValue("@TeethID_fk", TeethID_fk);
            cmd.Parameters.AddWithValue("@EmployeeID_fk", GlobalVariable.EmployeeID);

            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            sqlcon.Close();
        }

        /* Will Check on the database to see if the patient has already 
         * an entry of teeth number 
          */
        private int CheckPatientTeethEntry(int teethNum)
        {
            int ret = 0;
            SqlCommand cmd = new SqlCommand(
                "SELECT TeethID FROM Teeth " +
                "INNER JOIN[PatientTeeth] ON TeethID = TeethID_fk " +
                "WHERE PatientID_fk = @patientID AND TeethNumber = @teethnum", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@patientID", PatientID);
            cmd.Parameters.AddWithValue("@teethnum", teethNum);

            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                ret = (Convert.ToInt32(cmd.ExecuteScalar()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            sqlcon.Close();
            return ret;

        }

        private void UpdatePatientTeeth(int TeethID, int TeethNum)
        {
           
            SqlCommand cmd = new SqlCommand(
                "UPDATE [Teeth] SET TeethTop = @Top, TeethBottom = @Bottom, TeethRight = @Right, " +
                "TeethLeft = @Left, TeethCenter = @Center " +
                "WHERE TeethID = @TeethID", sqlcon);

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Top", TopTeethColor[TeethNum]);
            cmd.Parameters.AddWithValue("@Bottom", BottomTeethColor[TeethNum]);
            cmd.Parameters.AddWithValue("@Right", RightTeethColor[TeethNum]);
            cmd.Parameters.AddWithValue("@Left", LeftTeethColor[TeethNum]);
            cmd.Parameters.AddWithValue("@Center", CenterTeethColor[TeethNum]);
            cmd.Parameters.AddWithValue("@TeethID", TeethID);


            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            sqlcon.Close();
            UpdatePatientTeeth(TeethID);
        }

        private void UpdatePatientTeeth(int TeethID)
        {
            SqlCommand cmd = new SqlCommand(
                "UPDATE [PatientTeeth] SET EmployeeID_fk = @EmployeeID_fk", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@EmployeeID_fk", GlobalVariable.EmployeeID);

            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            sqlcon.Close();
        }

        private void RetrievePatientTeethStatus()
        {
            int teethNumber = 0;
           // String teethTop = "OK", teethBottom = "OK", teethLeft = "OK", teethRight = "OK", teethCenter = "OK";

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                    "SELECT TeethNumber, TeethTop, TeethBottom, TeethRight," +
                    "TeethLeft,TeethCenter,EditDate, CONCAT(e.FirstName, ' ',e.LastName) FROM Teeth INNER JOIN PatientTeeth p " +
                    "ON TeethID = TeethID_fk INNER JOIN Employee e ON p.EmployeeID_fk = e.EmployeeId WHERE PatientID_fk = @PatientID", sqlcon);

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@PatientID", PatientID);
            adapter.SelectCommand = cmd;

            try
            {
                adapter.Fill(dt);
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                teethNumber = Convert.ToInt32(dt.Rows[i][0]);
                TopTeethColor[teethNumber] = dt.Rows[i][1].ToString();
                BottomTeethColor[teethNumber] = dt.Rows[i][2].ToString();
                RightTeethColor[teethNumber] = dt.Rows[i][3].ToString();
                LeftTeethColor[teethNumber] = dt.Rows[i][4].ToString();
                CenterTeethColor[teethNumber] = dt.Rows[i][5].ToString();

                Panel teethNumberPanel = new Panel();
                PictureBox icon = new PictureBox();
                teethNumberPanel = PanelNumber(teethNumber);
                ToolTip ToolTip1 = new ToolTip();
                string ToolTipText = "Last Edited : " + dt.Rows[i][6].ToString() + "\n" + "By : Dr. " + dt.Rows[i][7].ToString();
                ToolTip1.SetToolTip(teethNumberPanel, ToolTipText);
                icon = IconNumber(teethNumber);
                Graphics gs = teethNumberPanel.CreateGraphics();

                int dummyVariable = 0;
                for (int j = 0; j < 16; j++)
                {
                   
                   
                    if (TopTeethColor[teethNumber] == TeethOperation[j])
                    {
                        gs.FillPolygon(ToothColorBrush[j], TopPolygonFill);
                        dummyVariable = j;
                    }
                    if (BottomTeethColor[teethNumber] == TeethOperation[j])
                    {
                        gs.FillPolygon(ToothColorBrush[j], BottomPolygonFill);
                        dummyVariable = j;
                    }
                    if (RightTeethColor[teethNumber] == TeethOperation[j])
                    {
                        gs.FillPolygon(ToothColorBrush[j], RightPolygonFill);
                        dummyVariable = j;
                    }
                    if (LeftTeethColor[teethNumber] == TeethOperation[j])
                    {
                        gs.FillPolygon(ToothColorBrush[j], LeftPolygonFill);
                        dummyVariable = j;
                    }
                    if (CenterTeethColor[teethNumber] == TeethOperation[j])
                    {
                        gs.FillRectangle(ToothColorBrush[j], InsideRectangleFill);
                        dummyVariable = j;
                    }
         
                }
                icon.Image = ToothImage[dummyVariable];
                if (dummyVariable > 8)
                {
                    icon.Size = new Size(33, 16);
                    icon.Left = teethNumberPanel.Left;
                }
                else
                {
                    icon.Size = new Size(20, 16);
                }

            }
        }

        private void RefreshTeethPanel()
        {
            foreach(int panelControls in TeethArray)
            {
                int panelNumber = panelControls + 1;
                string panelName = "TeethPanel" + panelNumber;
                string iconName = "icon" + panelNumber;
                Panel TeethPanel = new Panel();
                foreach (Control panelControl in panel1.Controls)
                {
                    if (panelControl is Panel)
                    {
                        if (panelControl.Name == panelName)
                        {
                            panelControl.Enabled = false;
                            panelControl.Enabled = true;
                            TeethPanel = (Panel)panelControl;

                            foreach (Control iconControl in panel1.Controls)
                            {
                                if (iconControl is PictureBox)
                                {
                                    if (iconControl.Name == iconName)
                                    {
                                        ((PictureBox)iconControl).Image = ToothImage[0];
                                        ((PictureBox)iconControl).Size = new Size(20, 16);
                                        ((PictureBox)iconControl).Left = TeethPanel.Left + 7;
                                    }

                                }
                            }
                        }
                    }
                    
                   
                }
            }
        }

 
        //----------------------------------------------------------------------------------------------------------------------------------
        // Notes
  

        private int getNextNoteID()
        {
            int id = 0;
            SqlCommand cmd = new SqlCommand(
                "SELECT NotesID FROM Notes ORDER BY NotesID DESC", sqlcon);
            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                if (cmd.ExecuteScalar() != null)
                {
                    id = (int)cmd.ExecuteScalar();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            sqlcon.Close();
            return id;
        }

        private void Savenotes(string id)
        {
            string txt ="";

            if (GlobalVariable.Permission == "Admin" || GlobalVariable.JobTitle == "Dentist")
            {
                foreach (Control control in NotesLayoutPanel.Controls)
                {
                    if (control.Name == id)
                    {
                        foreach (Control control2 in control.Controls)
                        {
                            if (control2.Name == "txt_Note")
                            {
                                txt = control2.Text;
                                if (txt == "Enter your notes here ...") txt = "";

                                if (CheckExistingNote(id))
                                {
                                    UpdateNote(id, txt, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"));


                                }
                                else
                                {
                                    InsertNote(txt, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"));

                                }
                                break;

                            }

                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("Permission Denied !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

        }

        private Boolean CheckExistingNote(string id)
        {
            Boolean exist = false;
            SqlCommand cmd = new SqlCommand(
                "SELECT NotesID FROM Notes WHERE NotesID = @NotesID", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@NotesID", id);
            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                if (cmd.ExecuteScalar() != null)
                {
                    exist = true;
                }

            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            sqlcon.Close();
            return exist;
        }

        private void Deletenotes(string id)
        {
            if (GlobalVariable.Permission == "Admin" || GlobalVariable.JobTitle == "Dentist")
            {

                SqlCommand cmd = new SqlCommand(
                "DELETE FROM Notes WHERE NotesID = @NoteID", sqlcon);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@NoteID", id);
                if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
                try
                {
                    cmd.ExecuteNonQuery();
                    GlobalVariable.InsertActivityLog("Deleted Note , Note ID = " + id + "Patient Id =  " + GlobalVariable.PatientID, "Delete");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                sqlcon.Close();

                foreach (Control control in NotesLayoutPanel.Controls)
                {
                    if (control.Name == id)
                    {
                        var index = NotesLayoutPanel.Controls.IndexOf(control);
                        this.NotesLayoutPanel.Controls.RemoveAt(index);

                    }
                }

            }
            else
            {
                MessageBox.Show("Permission Denied !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateNote(string id,string PatientNote, string DateToday)
        {

            
                SqlCommand cmd = new SqlCommand(
                       "UPDATE [Notes] SET Note = @Note, NoteDate = @Date, PatientID_fk = @PatientID " +
                       "WHERE NotesID = @NoteID", sqlcon);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Note", PatientNote);
                cmd.Parameters.AddWithValue("@Date", DateToday);
                cmd.Parameters.AddWithValue("@PatientID", PatientID);
                cmd.Parameters.AddWithValue("@NoteID", id);

                if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
                try
                {
                    cmd.ExecuteNonQuery();
                GlobalVariable.InsertActivityLog("Edited Note, Note ID = " + id + "Patient Id =  "+GlobalVariable.PatientID, "Edit");
                MessageBox.Show("Note Updated Successfully");
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                sqlcon.Close();
            
            
           
        }
        
        private void InsertNote(string PatientNote,string DateToday)
        {

                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO [Notes] (Note,NoteDate,PatientID_fk) VALUES (@Note,@Date,@PatientID)", sqlcon);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Note", PatientNote);
                cmd.Parameters.AddWithValue("@Date", DateToday);
                cmd.Parameters.AddWithValue("@PatientID", PatientID);

            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Note Added Successfully");
                    GlobalVariable.InsertActivityLog("Added Note, Patient Id =  " + GlobalVariable.PatientID, "Add");

            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
                sqlcon.Close();
            
        }


        private void LoadNotes()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                "SELECT NotesID,NoteDate,Note FROM Notes WHERE PatientID_fk = @PatientID", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@PatientID", PatientID);
            adapter.SelectCommand = cmd;

            try
            {
                adapter.Fill(dt);
                //NoteDD.DataSource = dt;
                //NoteDD.Columns[0].Width = 50;
                //NoteDD.Columns[1].Width = 80;
                //NoteDD.Columns[1].DefaultCellStyle.Format = "M/d/yyyy";

                foreach (DataRow row in dt.Rows)
                {
                    string id = row[0].ToString();
                    string dateTime = DateTime.Parse(row[1].ToString()).ToString("MMM. d yyyy hh:mm tt");
                    string note = row[2].ToString();
                    DrawStickyNotes(id, note, dateTime);
                }
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
        }

  


        //Experimental ------------------------
       
            private void DrawStickyNotes(string id, string note, string dateTime)
        {
            
                Panel panel = new Panel();
                panel.BackColor = System.Drawing.Color.LemonChiffon;
                panel.Location = new System.Drawing.Point(0, 0);
                panel.Name = id;
                panel.Size = new System.Drawing.Size(275, 184);
                this.NotesLayoutPanel.Controls.Add(panel);
                this.NotesLayoutPanel.Controls.SetChildIndex(panel, 0);
             
                Panel header = new Panel();
                header.BackColor = System.Drawing.Color.Khaki;
                header.Dock = System.Windows.Forms.DockStyle.Top;
                header.Location = new System.Drawing.Point(0, 0);
                header.Name = "NoteHeaderPanel";
                header.Size = new System.Drawing.Size(282, 27);
                panel.Controls.Add(header);

                Label delete = new Label();
                delete.AutoSize = true;
                delete.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                delete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                delete.Location = new System.Drawing.Point(258, 1);
                delete.Name = "NoteDelete" + id;
                delete.Size = new System.Drawing.Size(18, 23);
                delete.Text = "x";
                delete.Click += (sender, e) =>
                {
                    // Int32.TryParse(Save.Name, out int appid);
                    Deletenotes(id);
                };
                header.Controls.Add(delete);

                PictureBox Save = new PictureBox();
                Save.Image = global::_846DentalClinicManagementSystem.Properties.Resources.icons8_save_100;
                Save.Location = new System.Drawing.Point(5, 1);
                Save.Name = "SaveNote";
                Save.Size = new System.Drawing.Size(23, 23);
                Save.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                Save.Click += (sender, e) =>
                {
                   // Int32.TryParse(Save.Name, out int appid);
                    Savenotes(id);
                };
                header.Controls.Add(Save);

                TextBox Note = new TextBox();
                Note.BackColor = System.Drawing.Color.LemonChiffon;
                Note.BorderStyle = System.Windows.Forms.BorderStyle.None;
                Note.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Note.ForeColor = System.Drawing.Color.Silver;
                Note.Location = new System.Drawing.Point(7, 33);
                Note.Multiline = true;
                Note.Name = "txt_Note";
                Note.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
                Note.Size = new System.Drawing.Size(272, 122);
                Note.Text = note;
                if (Note.Text == "Enter your notes here ...")
                 {
                    Note.ForeColor = System.Drawing.Color.Silver;
                }
                else
                {
                    Note.ForeColor = System.Drawing.SystemColors.InfoText;
            }
                Note.Click += (sender, e) =>
                {
                    Note.ForeColor = System.Drawing.SystemColors.InfoText;
                    if (Note.Text == "Enter your notes here ...") Note.Text = "";

                };
            panel.Controls.Add(Note);

                Label date = new Label();
                date.AutoSize = true;
                date.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                date.ForeColor = System.Drawing.Color.DarkGray;
                date.Location = new System.Drawing.Point(4, 161);
                date.Name = "lbl_NoteDate";
                date.Size = new System.Drawing.Size(135, 15);
                date.Text = dateTime;
                panel.Controls.Add(date);
          


        }



        //----------------------------------------

        //-------------------------------------------------------------------------------------------------------------------------------
        //Treatment History

        public void LoadTreatmentHistory()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                "SELECT a.AppointmentID As ID,a.AppointmentDate As Date,CONCAT(a.StartTime, ' - ', a.EndTime) AS Time, " +
                "p.Treatment,CONCAT(e.FirstName, ' ', e.LastName) AS Dentist, a.Status, p.Prescription " +
                "FROM Appointment a INNER JOIN PatientTreatment p ON a.AppointmentID = p.AppointmentID_fk " +
                "INNER JOIN Employee e ON a.EmployeeID_fk = e.EmployeeId WHERE p.PatientID_fk = @PatientID AND a.Status = 'COMPLETED'", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@PatientID", PatientID);
            adapter.SelectCommand = cmd;

            try
            {
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //replace comma "," with line break
                    for(int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i][3] = dt.Rows[i][3].ToString().Replace(",", Environment.NewLine);
                        dt.Rows[i][6] = dt.Rows[i][6].ToString().Replace(",", Environment.NewLine);
                    }
                   
                }
                TreatmentHistory_DG.DataSource = dt;
                TreatmentHistory_DG.Columns[0].Width = 40;
                TreatmentHistory_DG.Columns[1].Width = 100;
                TreatmentHistory_DG.Columns[2].Width = 210;
                TreatmentHistory_DG.Columns[3].Width = 300;
                TreatmentHistory_DG.Columns[4].Width = 150;
                TreatmentHistory_DG.Columns[5].Width = 100;
                TreatmentHistory_DG.Columns[6].Width = 500;
                TreatmentHistory_DG.Columns[1].DefaultCellStyle.Format = "M/d/yyyy";


            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void btn_PrintPrescription_Click(object sender, EventArgs e)
        {
            if (TreatmentHistory_DG.Rows.Count > 0)
            {
                AddPrescription addPrescription = new AddPrescription();
                addPrescription.ShowDialog();
            }

        }



        // -------------------------------------------------------------------------------------------------------------------------------
        // Billing

        public void ShowBilling()
        { 
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand (
                "SELECT b.BillingID,b.BillingDate, t.Treatment_Price, b.AmountCharged,b.AmountPay,b.BillingBalance ,b.DateModified " +
                "FROM Billing b INNER JOIN PatientTreatment t ON b.AppointmentID_fk = t.AppointmentID_fk " +
                "INNER JOIN Patient p ON b.PatientID_fk = p.PatientID " +
                "WHERE b.PatientID_fk = @PatientID",sqlcon);

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@PatientID",PatientID);

            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);

                //check if data table contains row
                if (dt.Rows.Count > 0)
                {
                    //replace comma "," with line break
                    dt.Rows[0][2] = dt.Rows[0][2].ToString().Replace(",", Environment.NewLine);
                   
                    //if (string.IsNullOrEmpty(dt.Rows[0][5].ToString()))
                    //{
                    //    GetStartingBalance(dt.Rows[0][3].ToString()); //get the original balance which is equal to amount charge
                    //    adapter.Dispose();
                    //    dt.Dispose();
                    //    cmd.Dispose();
                    //    ShowBilling();
                    //    Billing_DataGrid.Refresh();
                    // }
                }
                Billing_DataGrid.DataSource = dt;
    
                //dateformat
                Billing_DataGrid.Columns[1].DefaultCellStyle.Format = "M/d/yyyy hh:mm tt";
                Billing_DataGrid.Columns[3].DefaultCellStyle.Format = "N2";
                Billing_DataGrid.Columns[4].DefaultCellStyle.Format = "N2";
                Billing_DataGrid.Columns[5].DefaultCellStyle.Format = "N2";
                Billing_DataGrid.Columns[6].DefaultCellStyle.Format = "M/d/yyyy hh:mm tt";

            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }

            

            if (Billing_DataGrid.Rows.Count > 0)
            {
                Billing_DataGrid.Rows[0].Selected = true;
                GlobalVariable.BillingID = (int)(Billing_DataGrid.SelectedRows[0].Cells[0].Value);
            }

        }


        private void add()
        {
            bool isPaymentValid = Regex.IsMatch(txt_Amount.Text, @"^(\(?\+?[0-9]*\)?)?[0-9\(\)]*$");

            foreach (DataGridViewRow row in Billing_DataGrid.Rows)
            {
                if (row.Cells[0].Value.ToString().Contains(txt_BllingID.Text))
                {
                    float _TotalPay = 0, _Balance = 0, _Payment = 0, _AmountCharge = 0;
                    float.TryParse(txt_Amount.Text, out _Payment);

                    if (isPaymentValid == true && _Payment > 0)
                    {
                       
                        
                        float.TryParse(row.Cells[3].Value.ToString(),out _AmountCharge);
                        float.TryParse(row.Cells[4].Value.ToString(), out _TotalPay);
                        float.TryParse(row.Cells[5].Value.ToString(), out _Balance);

                        if (_Balance > 0)
                        {
                            if (_TotalPay + _Payment <= _AmountCharge)
                            {
                                GlobalVariable.BillingID = Convert.ToInt32(txt_BllingID.Text);
                                DialogResult result = MessageBox.Show("Are you sure you want to add ₱ " + _Payment + " payment \r \n To Mr/Ms." + GlobalVariable.PatientName + " ?"
                                   , "Billing ID : " + GlobalVariable.BillingID, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                                if (result == DialogResult.Yes)
                                {
                                    InsertPayment();
                                    UpdateBillingAfterPayment();
                                    MessageBox.Show("Payment added succesfully");
                                    ShowBilling();
                                    PrintInvoice();
                                    txt_Amount.Clear();
                                   
                                    return;
                                }

                            }
                            else { MessageBox.Show("Payment exceeds the amount charged"); }

                        }
                        else { MessageBox.Show("Bill already Paid"); }
                    }
                    else { MessageBox.Show("Invalid Payment"); }

                }


            }

        }

        private void PrintInvoice()
        {
            DataTable PaymentTable = new DataTable();
            DataTable TreatmentPriceTable = new DataTable();
            SqlDataAdapter adapter1 = new SqlDataAdapter();
            SqlDataAdapter adapter2 = new SqlDataAdapter();
            SqlCommand cmd1 = new SqlCommand(
                "SELECT TOP 1 b.BillingID,p.PaymentID,p.PaymentAmount,p.PaymentBalance,b.AmountCharged,b.AmountPay,k.PatientFullName FROM Payment p INNER JOIN Billing b ON " +
                "b.BillingID = p.BillingID_fk INNER JOIN Patient k ON b.PatientID_fk = k.PatientID WHERE b.BillingID = @BillingId ORDER BY p.PaymentDate DESC", sqlcon);
            cmd1.Parameters.Clear();
            cmd1.Parameters.AddWithValue("@BillingID", GlobalVariable.BillingID);
            adapter1.SelectCommand = cmd1;
            SqlCommand cmd2 = new SqlCommand(
                "SELECT a.TreatmentType AS Treatment, a.TreatmentPrice AS Price FROM AppointmentTreatment a WHERE " +
                "AppointmentID_fk = (SELECT b.AppointmentID_fk FROM Billing b WHERE b.BillingID = @BillingId)",sqlcon);
            cmd2.Parameters.Clear();
            cmd2.Parameters.AddWithValue("@BillingID",GlobalVariable.BillingID);
            adapter2.SelectCommand = cmd2;
            try
            {
                adapter1.Fill(PaymentTable);
                adapter2.Fill(TreatmentPriceTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            CrystalDecisions.CrystalReports.Engine.ReportDocument report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            report = new CrystalReport5();
            report.Database.Tables["dtPayment"].SetDataSource(PaymentTable);
            report.Database.Tables["dtTreatmentPrice"].SetDataSource(TreatmentPriceTable);
            AccountingReportForm accounting = new AccountingReportForm();
            accounting.crystalReportViewer1.ReportSource = report;
            accounting.ShowDialog();
            accounting.Dispose();


        }

        private void InsertPayment()
        {
           float.TryParse(txt_Amount.Text,out float Amount);
        
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO [Payment] (PaymentAmount,PaymentBalance,EmployeeID_fk,BillingID_fk) " +
                "VALUES (@Amount,(SELECT BillingBalance FROM Billing WHERE BillingID = @BillingID) - @Amount " +
                ",@EmployeeID,@BillingID)",sqlcon);

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Amount", Amount);
            cmd.Parameters.AddWithValue("@EmployeeID", GlobalVariable.EmployeeID);
            cmd.Parameters.AddWithValue("@BillingID", GlobalVariable.BillingID);
            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                cmd.ExecuteNonQuery();
                GlobalVariable.InsertActivityLog("Added Payment on Billing ID = " + GlobalVariable.BillingID, "Add");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            sqlcon.Close();
            

        }

        public void UpdateBillingAfterPayment()
        {

            SqlCommand cmd = new SqlCommand(
            "UPDATE Billing SET AmountPay = (SELECT SUM(PaymentAmount) FROM Payment WHERE BillingID_fk = @BillingID AND Status = 'Completed') , " +
            "BillingBalance = (SELECT AmountCharged FROM Billing WHERE BillingID = @BillingID) - (SELECT SUM(PaymentAmount) FROM Payment WHERE BillingID_fk =  @BillingID AND Status = 'Completed'), " +
            "DateModified = CURRENT_TIMESTAMP WHERE BillingID = @BillingID", sqlcon);

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@BillingID", GlobalVariable.BillingID);
            if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
            try
            {
                cmd.ExecuteNonQuery();
               
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            sqlcon.Close();
        }



        private void Billing_DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //txt_BllingID.Text = Billing_DataGrid.SelectedRows[0].Cells[0].Value.ToString();
            //GlobalVariable.BillingID = (int)(Billing_DataGrid.SelectedRows[0].Cells[0].Value);
            //ShowPaymentHistory();
        }



        private void txt_Amount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                add();
            }
            
        }

        private void General_tab_Click(object sender, EventArgs e)
        {

        }
 //--------------------------------------------------------------------------------------------------------------------------------
//Payment History
        ArrayList paymentID = new ArrayList();


        private void ShowPaymentHistory()
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                "SELECT PaymentID,PaymentDate,PaymentAmount,PaymentBalance,CONCAT(e.FirstName, ' ', e.LastName) AS UpdatedBy,p.Status " +
                "FROM Payment p INNER JOIN Employee e ON p.EmployeeID_fk = e.EmployeeID WHERE BillingID_fk = @BillingID ORDER BY PaymentDate DESC", sqlcon);

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
                PaymentHistory_DataGrid.Columns[2].DefaultCellStyle.Format = "N2";
                PaymentHistory_DataGrid.Columns[3].DefaultCellStyle.Format = "N2";
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            if (PaymentHistory_DataGrid.Rows.Count > 0)
            {
                PaymentHistory_DataGrid.Rows[0].Selected = true;
            }

        }

        private void getPaymentID()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                "SELECT PaymentID FROM Payment WHERE BillingID_fk = @BillingID AND Status = 'Completed' ORDER BY PaymentID", sqlcon);
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
            if (paymentID.Count > 1 && _firstLoopDone == true)
            {
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
            if (paymentID.Count == 0)
            {
                SqlCommand cmd = new SqlCommand(
              "UPDATE Billing SET BillingBalance = AmountCharged, AmountPay = 0 WHERE BillingID = @BillingID", sqlcon);

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@BillingID", GlobalVariable.BillingID);

                if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                sqlcon.Close();
            }


        }

        private void Billing_DataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txt_BllingID.Text = Billing_DataGrid.SelectedRows[0].Cells[0].Value.ToString();
                GlobalVariable.BillingID = (int)(Billing_DataGrid.SelectedRows[0].Cells[0].Value);
                ShowPaymentHistory();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        //-------------------------------------- Experimental
  


        private void btn_AddPay_Click(object sender, EventArgs e)
        {
            Billing_DataGrid.Width = 715;
            Payment_Panel.Visible = true;
            if (Billing_DataGrid.SelectedRows.Count > 0) // make sure user select at least 1 row 
            {

                txt_BllingID.Text = GlobalVariable.BillingID.ToString();
            }
        }

        private void btn_PaymentAdd_Click(object sender, EventArgs e)
        {
            add();
            ShowPaymentHistory();
        }

        private void btn_PaymentClose_Click(object sender, EventArgs e)
        {
            txt_Amount.Clear();
            Payment_Panel.Visible = false;
            Billing_DataGrid.Width = 922;
        }

        private void btn_PrintCert1_Click(object sender, EventArgs e)
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);   
            }
           

            //dt1.Rows.Add("Michael Mendiola", "22", "M", "186 Dr. Pilapil St. San Miguel Pasig City",
            //"Maranan, Esperanza G.", "20776", "Gingivitis", "Removal of tissues", "Deep Scaling", GlobalVariable.chartImagePath);

            DataTable dt = dt1;
            CrystalDecisions.CrystalReports.Engine.ReportDocument report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            report = new CrystalReport2();
            report.SetDataSource(dt);
            Certificate2cs certificate = new Certificate2cs();
            certificate.crystalReportViewer1.ReportSource = report;
            certificate.ShowDialog();
            certificate.Dispose();
            GlobalVariable.InsertActivityLog("Printed Dental Certificate, Patient ID = " + GlobalVariable.PatientID, "Print");
        }

        private void btn_PrintCert2_Click(object sender, EventArgs e)
        {
            btn_ChartSave.Visible = false;
            btn_ChartRefresh.Visible = false;
            btn_PrintCert1.Visible = false;
            btn_PrintCert2.Visible = false;

            this.Show();
            int left = this.DesktopLocation.X + panel6.Location.X + PatientInfoTAB.Location.X;
            int top = this.DesktopLocation.Y + panel6.Location.Y + PatientInfoTAB.Location.Y + 25;
            Rectangle rect = new Rectangle(left, top, panel6.Width + panel1.Width - 7, panel6.Size.Height + 2);
            Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);

            try
            {
                System.IO.Directory.CreateDirectory(@"C:\846 Dental Mangement System");
                bmp.Save(GlobalVariable.chartImagePath, ImageFormat.Bmp);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           

            btn_ChartSave.Visible = true;
            btn_ChartRefresh.Visible = true;
            btn_PrintCert1.Visible = true;
            btn_PrintCert2.Visible = true;


            AddDiagnosis addDiagnosis = new AddDiagnosis();
            addDiagnosis.Show();
        }

        private void btn_ChartRefresh_Click(object sender, EventArgs e)
        {
            RefreshTeethPanel();
            SetDefaultTeethColor();
            RetrievePatientTeethStatus();
            TeethArray.Clear();
        }

        private void btn_ChartSave_Click(object sender, EventArgs e)
        {
            int teethID = 0;
            foreach (int teeth in TeethArray)
            {
                teethID = CheckPatientTeethEntry(teeth);
                if (teethID != 0)
                {
                    // means there is an existing status sa teethnumber ng patient
                    //so imbis na insert update lang to prevent data replication

                    UpdatePatientTeeth(teethID, teeth);
                    GlobalVariable.InsertActivityLog("Edited Tooth Chart, Patient ID = " + GlobalVariable.PatientID, "Edit");
                    //Console.WriteLine(Convert.ToInt32(cmd.ExecuteScalar()));
                }
                else
                {
                    // means wala pang existing  status sa teethnumber ng patient
                    // so mag iinsert ng bago
                    insertTeethStatus(teeth);
                    GlobalVariable.InsertActivityLog("Edited Tooth Chart, Patient ID = " + GlobalVariable.PatientID, "Edit");

                    //Console.WriteLine(Convert.ToInt32(cmd.ExecuteScalar()));
                }
            }
            MessageBox.Show("Save Successfully");
            TeethArray.Clear(); // empty arraylist
        }

        private void btn_NoteAdd_Click(object sender, EventArgs e)
        {
            if (GlobalVariable.Permission == "Admin" || GlobalVariable.JobTitle == "Dentist")
            {
                LatestNoteID++;
                string id = LatestNoteID.ToString();
                DrawStickyNotes(id, "Enter your notes here ...", DateTime.Now.ToString("MMM. d yyyy hh:mm tt"));
            }
            else
            {
                MessageBox.Show("Permission Denied !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_PaymentCancel_Click(object sender, EventArgs e)
        {
            if (GlobalVariable.Permission == "Admin")
            {
                if (PaymentHistory_DataGrid.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to cancel this payment ?"
                                 , "Payment ID : " + PaymentHistory_DataGrid.SelectedRows[0].Cells[0].Value, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                    if (result == DialogResult.Yes)
                    {
                        SqlCommand cmd = new SqlCommand(
                        "UPDATE Payment SET Status = 'Canceled', EmployeeID_fk = @EmployeeID WHERE PaymentID = @PaymentID", sqlcon);

                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@EmployeeID", GlobalVariable.EmployeeID);
                        cmd.Parameters.AddWithValue("@PaymentID", (int)(PaymentHistory_DataGrid.SelectedRows[0].Cells[0].Value));

                        if (sqlcon.State != ConnectionState.Open) { sqlcon.Open(); }
                        try
                        {
                            cmd.ExecuteNonQuery();
                            UpdateBalanceAfterPayment();
                            ShowPaymentHistory();
                            GlobalVariable.InsertActivityLog("Cancelled Payment on Billing ID = " + GlobalVariable.BillingID + " Payment ID = " + PaymentHistory_DataGrid.SelectedRows[0].Cells[0].Value.ToString(), "Cancel");
                            if (paymentID.Count > 0) { UpdateBillingAfterPayment(); }
                            ShowBilling();
                            paymentID.Clear();

                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        sqlcon.Close();

                    }
                     
                }

            }
            else
            {
                MessageBox.Show("Permission Denied !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }









        //-Experimental ------------------------------------
    }

   
}
