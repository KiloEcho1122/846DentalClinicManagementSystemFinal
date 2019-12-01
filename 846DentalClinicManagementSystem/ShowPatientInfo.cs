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
using System.Collections;using System.IO;
using System.Text.RegularExpressions;

namespace _846DentalClinicManagementSystem
{
    public partial class ShowPatientInfo : Form
    {
        public ShowPatientInfo()
        {
            InitializeComponent();
        }

        private void btn_closePatientInfo_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void PatientInfoTAB_Click(object sender, EventArgs e)
        {
            if (PatientInfoTAB.SelectedIndex == 0)
            {

            }
            else if (PatientInfoTAB.SelectedIndex == 1)
            {
                SetDefaultTeethColor();
                TeethArray.Clear();
                RetrievePatientTeethStatus();
            }
            else if (PatientInfoTAB.SelectedIndex == 2)
            {
                LoadTreatmentHistory();

            }
            else if (PatientInfoTAB.SelectedIndex == 3)
            {
                LoadNotes();
            }
        }

        SqlConnection sqlcon = new SqlConnection(GlobalVariable.connString);
        Boolean NoteIsEdit;
       
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

        //
        Boolean reSize = false;


        SolidBrush red = new SolidBrush(Color.FromArgb(239, 45, 45));
        SolidBrush white = new SolidBrush(Color.White);
        SolidBrush blue = new SolidBrush(Color.FromArgb(51, 01, 247));

        //Teeth Legend Icon
        Image TeethLegend;

        //Teeth String Status
        string TeethStatus = null;

        // Draw Check in the teeth
        Point[] check = { new Point(0, 18), new Point(8, 30), new Point(30, 0), new Point(8, 23) };

        //Draw X in the Teeth
        Point[] ekis1 = { new Point(3, 0), new Point(30, 27), new Point(27, 30), new Point(0, 3) };
        Point[] ekis2 = { new Point(27, 0), new Point(30, 3), new Point(3, 30), new Point(0, 27) };


        int PatientID = GlobalVariable.PatientID;

        ArrayList TeethArray = new ArrayList();

        string[] TopTeethColor = new string[52];
        string[] BottomTeethColor = new string[52];
        string[] LeftTeethColor = new string[52];
        string[] RightTeethColor = new string[52];
        string[] CenterTeethColor = new string[52];
        //string[] OK = new string[52];
        //string[] Missing = new string[52];
        //string[] RF = new string[52];
        //string[] Implant = new string[52];
        //string[] Impacted = new string[52];
          String[] Checked = new string[52];
         String[] ex = new String[52];


        private void ShowPatientInfo_Load(object sender, EventArgs e)
        {
            lbl_PatientName.Text = GlobalVariable.PatientName;
            Payment_Panel.Visible = false;
            ShowBilling();
            Billing_DataGrid.Width = 922;
           
        }

        private void SetDefaultTeethColor()
        {
            for (int i = 0; i < 52; i++)
            {
                TopTeethColor[i] = "OK";
                BottomTeethColor[i] = "OK";
                LeftTeethColor[i] = "OK";
                RightTeethColor[i] = "OK";
                CenterTeethColor[i] = "OK";
                //OK[i] = "true";
                //Missing[i] = "false";
                //RF[i] = "false";
                //Implant[i] = "false";
                //Impacted[i] = "false";


              //  Checked[i] = "false";
             //ex[i] = "false";

            }
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


        //LEGEND -------------------------------------------------------------------------------------------
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            TeethBrushColor = new SolidBrush(Color.White);
            TeethLegend = global::_846DentalClinicManagementSystem.Properties.Resources.check_mark;
            TeethStatus = "OK";
            reSize = false;
        }

        private void btn_Missing_Click(object sender, EventArgs e)
        {
            TeethBrushColor = new SolidBrush(Color.White);
            TeethLegend = global::_846DentalClinicManagementSystem.Properties.Resources.M;
            TeethStatus = "Missing";
            reSize = false;
        }

        private void btn_RF_Click(object sender, EventArgs e)
        {
            TeethBrushColor = new SolidBrush(Color.White);
            TeethLegend = global::_846DentalClinicManagementSystem.Properties.Resources.RF;
            TeethStatus = "RF";
            reSize = false;
        }

        private void btn_Implant_Click(object sender, EventArgs e)
        {
            TeethBrushColor = new SolidBrush(Color.White);
            TeethLegend = global::_846DentalClinicManagementSystem.Properties.Resources.icons8_dental_implant_50;
            TeethStatus = "Implant";
            reSize = false;
        }

        private void btn_Impacted_Click(object sender, EventArgs e)
        {
            TeethBrushColor = new SolidBrush(Color.White);
            TeethLegend = global::_846DentalClinicManagementSystem.Properties.Resources.IMP;
            TeethStatus = "Impacted";
            reSize = false;
        }

        private void btn_Caries_Click(object sender, EventArgs e)
        {
            TeethBrushColor = new SolidBrush(Color.FromArgb(237, 28, 36));
            TeethLegend = null;
            TeethStatus = "Caries";
            reSize = false;
        }

        private void btn_Composite_Click(object sender, EventArgs e)
        {
            TeethBrushColor = new SolidBrush(Color.FromArgb(64, 0, 128));
            TeethLegend = null;
            TeethStatus = "Composite";
            reSize = false;
        }

        private void btn_Amalgram_Click(object sender, EventArgs e)
        {
            TeethBrushColor = new SolidBrush(Color.FromArgb(127, 127, 127));
            TeethLegend = null;
            TeethStatus = "Amalgram";
            reSize = false;
        }

        private void btn_Recurrent_Click(object sender, EventArgs e)
        {
            TeethBrushColor = new SolidBrush(Color.FromArgb(255, 128, 64));
            TeethLegend = null;
            TeethStatus = "Recurrent";
            reSize = false;
        }

        private void btn_PFM_Click(object sender, EventArgs e)
        {
            TeethBrushColor = new SolidBrush(Color.FromArgb(207, 181, 59));
            TeethLegend = global::_846DentalClinicManagementSystem.Properties.Resources.pfm;
            TeethStatus = "PFM";
            reSize = true;
        }

        private void btn_CER_Click(object sender, EventArgs e)
        {
            TeethBrushColor = new SolidBrush(Color.FromArgb(240, 230, 120));
            TeethLegend = global::_846DentalClinicManagementSystem.Properties.Resources.cer;
            TeethStatus = "CER";
            reSize = true;
        }

        private void btn_GC_Click(object sender, EventArgs e)
        {
            TeethBrushColor = new SolidBrush(Color.FromArgb(255, 215, 0));
            TeethLegend = global::_846DentalClinicManagementSystem.Properties.Resources.gc;
            TeethStatus = "GC";
            reSize = true;

        }

        private void btn_MC_Click(object sender, EventArgs e)
        {
            TeethBrushColor = new SolidBrush(Color.FromArgb(195, 195, 195));
            TeethLegend = global::_846DentalClinicManagementSystem.Properties.Resources.mc;
            TeethStatus = "MC";
            reSize = true;
        }

        private void btn_CERIO_Click(object sender, EventArgs e)
        {
            TeethBrushColor = new SolidBrush(Color.FromArgb(240, 230, 120));
            TeethLegend = global::_846DentalClinicManagementSystem.Properties.Resources.CERIO;
            TeethStatus = "CERIO";
            reSize = true;
        }

        private void btn_GIO_Click(object sender, EventArgs e)
        {
            TeethBrushColor = new SolidBrush(Color.FromArgb(255, 215, 0));
            TeethLegend = global::_846DentalClinicManagementSystem.Properties.Resources.GIO;
            TeethStatus = "GIO";
            reSize = true;
        }

        private void btn_MIO_Click(object sender, EventArgs e)
        {
            TeethBrushColor = new SolidBrush(Color.FromArgb(195, 195, 195));
            TeethLegend = global::_846DentalClinicManagementSystem.Properties.Resources.MIO;
            TeethStatus = "MIO";
            reSize = true;
        }

        //---------------------------------------------------------------------------------------------------

        // Function to fill teeth by parts
        private void FillTeeth(Panel TeethPanel, MouseEventArgs e, int index)
        {
            Graphics gs = TeethPanel.CreateGraphics();
            PictureBox icon = new PictureBox();
            icon = IconNumber(index);


            if (string.IsNullOrEmpty(TeethStatus) == false)
            {


                if (this.TopRectangle.Contains(e.Location))
                {
                    gs.FillPolygon(TeethBrushColor, TopPolygonFill);
                    TopTeethColor[index] = TeethStatus;
                }
                else if (this.BottomRectangle.Contains(e.Location))
                {
                    gs.FillPolygon(TeethBrushColor, BottomPolygonFill);
                    BottomTeethColor[index] = TeethStatus;
                }
                else if (this.LeftRectangle.Contains(e.Location))
                {
                    gs.FillPolygon(TeethBrushColor, LeftPolygonFill);
                    LeftTeethColor[index] = TeethStatus;
                }
                else if (this.RightRectangle.Contains(e.Location))
                {
                    gs.FillPolygon(TeethBrushColor, RightPolygonFill);
                    RightTeethColor[index] = TeethStatus;
                }
                else if (this.InsideRectangle.Contains(e.Location))
                {
                    gs.FillRectangle(TeethBrushColor, InsideRectangleFill);
                    CenterTeethColor[index] = TeethStatus;
                }

                // if ever na merong ibang operation sa ibang part ng teeth
                // iooverwrite nya kasi one operation lang pwede per teeth
                if (TopTeethColor[index] != TeethStatus && TopTeethColor[index] != "OK")
                {
                    gs.FillPolygon(TeethBrushColor, TopPolygonFill);
                    TopTeethColor[index] = TeethStatus;
                }
                if (BottomTeethColor[index] != TeethStatus && TopTeethColor[index] != "OK")
                {
                    gs.FillPolygon(TeethBrushColor, BottomPolygonFill);
                    BottomTeethColor[index] = TeethStatus;
                }
                if (LeftTeethColor[index] != TeethStatus && TopTeethColor[index] != "OK")
                {
                    gs.FillPolygon(TeethBrushColor, LeftPolygonFill);
                    LeftTeethColor[index] = TeethStatus;
                }
                if (RightTeethColor[index] != TeethStatus && TopTeethColor[index] != "OK")
                {
                    gs.FillPolygon(TeethBrushColor, RightPolygonFill);
                    RightTeethColor[index] = TeethStatus;
                }
                if (CenterTeethColor[index] != TeethStatus && TopTeethColor[index] != "OK")
                {
                    gs.FillRectangle(TeethBrushColor, InsideRectangleFill);
                    CenterTeethColor[index] = TeethStatus;
                }

                icon.Image = TeethLegend;
                if (reSize)
                {
                    icon.Size = new Size(33,16);
                    icon.Left = TeethPanel.Left;
                 //   icon.Top = TeethPanel.Top
                }
                else
                {
                    icon.Size = new Size(20, 16);
                    icon.Left = TeethPanel.Left + 7;
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


            //if (Checked[index] == "false" && ex[index] == "false")
            //        {
            //            if (this.TopRectangle.Contains(e.Location))
            //            {

            //                if (TopTeethColor[index] == "White")
            //                {
            //                    gs.FillPolygon(red, TopPolygonFill);
            //                    TopTeethColor[index] = "Red";
            //                }
            //                else if (TopTeethColor[index] == "Red")
            //                {
            //                    gs.FillPolygon(blue, TopPolygonFill);
            //                    TopTeethColor[index] = "Blue";
            //                }
            //                else if (TopTeethColor[index] == "Blue")
            //                {
            //                    gs.FillPolygon(white, TopPolygonFill);
            //                    TopTeethColor[index] = "White";
            //                }
            //            }
            //            else if (this.BottomRectangle.Contains(e.Location))
            //            {

            //                if (BottomTeethColor[index] == "White")
            //                {
            //                    gs.FillPolygon(red, BottomPolygonFill);
            //                    BottomTeethColor[index] = "Red";
            //                }
            //                else if (BottomTeethColor[index] == "Red")
            //                {
            //                    gs.FillPolygon(blue, BottomPolygonFill);
            //                    BottomTeethColor[index] = "Blue";
            //                }
            //                else if (BottomTeethColor[index] == "Blue")
            //                {
            //                    gs.FillPolygon(white, BottomPolygonFill);
            //                    BottomTeethColor[index] = "White";
            //                }

            //            }
            //            else if (this.LeftRectangle.Contains(e.Location))
            //            {
            //                if (LeftTeethColor[index] == "White")
            //                {
            //                    gs.FillPolygon(red, LeftPolygonFill);
            //                    LeftTeethColor[index] = "Red";
            //                }
            //                else if (LeftTeethColor[index] == "Red")
            //                {
            //                    gs.FillPolygon(blue, LeftPolygonFill);
            //                    LeftTeethColor[index] = "Blue";
            //                }
            //                else if (LeftTeethColor[index] == "Blue")
            //                {
            //                    gs.FillPolygon(white, LeftPolygonFill);
            //                    LeftTeethColor[index] = "White";
            //                }

            //            }
            //            else if (this.RightRectangle.Contains(e.Location))
            //            {

            //                if (RightTeethColor[index] == "White")
            //                {
            //                    gs.FillPolygon(red, RightPolygonFill);
            //                    RightTeethColor[index] = "Red";
            //                }
            //                else if (RightTeethColor[index] == "Red")
            //                {
            //                    gs.FillPolygon(blue, RightPolygonFill);
            //                    RightTeethColor[index] = "Blue";
            //                }
            //                else if (RightTeethColor[index] == "Blue")
            //                {
            //                    gs.FillPolygon(white, RightPolygonFill);
            //                    RightTeethColor[index] = "White";
            //                }

            //            }
            //            else if (this.InsideRectangle.Contains(e.Location))
            //            {
            //                if (CenterTeethColor[index] == "White")
            //                {
            //                    gs.FillRectangle(red, InsideRectangleFill);
            //                    CenterTeethColor[index] = "Red";
            //                }
            //                else if (CenterTeethColor[index] == "Red")
            //                {
            //                    gs.FillRectangle(blue, InsideRectangleFill);
            //                    CenterTeethColor[index] = "Blue";
            //                }
            //                else if (CenterTeethColor[index] == "Blue")
            //                {
            //                    gs.FillRectangle(white, InsideRectangleFill);
            //                    CenterTeethColor[index] = "White";
            //                }

            //            }
            //        }

    

            //        TopTeethColor[index] = "White";
            //        BottomTeethColor[index] = "White";
            //        LeftTeethColor[index] = "White";
            //        RightTeethColor[index] = "White";
            //        CenterTeethColor[index] = "White";

            //        if (Checked[index] == "false" && ex[index] == "false")
            //        {

            //            TeethPanel.Invalidate();
            //            TeethPanel.Update();
            //            gs.DrawPolygon(p2, check);
            //            gs.FillPolygon(blue, check);
            //            Checked[index] = "true";

            //        }
            //        else if (Checked[index] == "true" && ex[index] == "false")
            //        {

            //            TeethPanel.Invalidate();
            //            TeethPanel.Update();
            //            gs.DrawPolygon(p3, ekis1);
            //            gs.DrawPolygon(p3, ekis2);
            //            gs.FillPolygon(red, ekis1);
            //            gs.FillPolygon(red, ekis2);
            //            ex[index] = "true";
            //            Checked[index] = "false";

            //        }
            //        else if (Checked[index] == "false" && ex[index] == "true")
            //        {

            //            TeethPanel.Invalidate();
            //            TeethPanel.Update();
            //            TeethPanel.Refresh();
            //            ex[index] = "false";
            //        }


     
           

        }
        // Mouse Click event to call FillTeeth Function
        private void TeethPanel1_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel1, e,  0);
        private void TeethPanel2_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel2, e,  1);
        private void TeethPanel3_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel3, e,  2);
        private void TeethPanel4_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel4, e,  3);
        private void TeethPanel5_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel5, e,  4);
        private void TeethPanel6_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel6, e,  5);
        private void TeethPanel7_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel7, e, 6);
        private void TeethPanel8_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel8, e,  7);
        private void TeethPanel9_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel9, e,8);
        private void TeethPanel10_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel10, e,  9);
        private void TeethPanel11_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel11, e,  10);
        private void TeethPanel12_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel12, e,  11);
        private void TeethPanel13_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel13, e,  12);
        private void TeethPanel14_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel14, e,  13);
        private void TeethPanel15_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel15, e, 14);
        private void TeethPanel16_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel16, e, 15);
        private void TeethPanel17_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel17, e,16);
        private void TeethPanel18_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel18, e, 17);
        private void TeethPanel19_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel19, e, 18);
        private void TeethPanel20_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel20, e, 19);
        private void TeethPanel21_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel21, e,  20);
        private void TeethPanel22_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel22, e, 21);
        private void TeethPanel23_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel23, e, 22);
        private void TeethPanel24_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel24, e, 23);
        private void TeethPanel25_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel25, e, 24);
        private void TeethPanel26_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel26, e, 25);
        private void TeethPanel27_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel27, e,26);
        private void TeethPanel28_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel28, e,27);
        private void TeethPanel29_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel29, e, 28);
        private void TeethPanel30_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel30, e,29);
        private void TeethPanel31_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel31, e,30);
        private void TeethPanel32_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel32, e, 31);
        private void TeethPanel33_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel33, e, 32);
        private void TeethPanel34_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel34, e, 33);
        private void TeethPanel35_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel35, e, 34);
        private void TeethPanel36_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel36, e,  35);
        private void TeethPanel37_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel37, e,  36);
        private void TeethPanel38_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel38, e,  37);
        private void TeethPanel39_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel39, e,  38);
        private void TeethPanel40_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel40, e, 39);
        private void TeethPanel41_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel41, e,  40);
        private void TeethPanel42_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel42, e,  41);
        private void TeethPanel43_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel43, e,  42);
        private void TeethPanel44_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel44, e,  43);
        private void TeethPanel45_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel45, e, 44);
        private void TeethPanel46_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel46, e,  45);
        private void TeethPanel47_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel47, e,  46);
        private void TeethPanel48_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel48, e, 47);
        private void TeethPanel49_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel49, e, 48);
        private void TeethPanel50_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel50, e, 49);
        private void TeethPanel51_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel51, e, 50);
        private void TeethPanel52_MouseClick(object sender, MouseEventArgs e) => FillTeeth(TeethPanel52, e, 51);

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
                "Insert Into Teeth (TeethNumber,TeethTop,TeethBottom,TeethRight,TeethLeft,TeethCenter,TeethCheck,TeethCross) " +
                "Values(@TeethNum,@Top,@Bottom,@Right,@Left,@Center,@Check,@Cross) ", sqlcon);

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@TeethNum", TeethNum);
            cmd.Parameters.AddWithValue("@Top", TopTeethColor[TeethNum]);
            cmd.Parameters.AddWithValue("@Bottom", BottomTeethColor[TeethNum]);
            cmd.Parameters.AddWithValue("@Right", RightTeethColor[TeethNum]);
            cmd.Parameters.AddWithValue("@Left", LeftTeethColor[TeethNum]);
            cmd.Parameters.AddWithValue("@Center", CenterTeethColor[TeethNum]);
            cmd.Parameters.AddWithValue("@Check", Checked[TeethNum]);
            cmd.Parameters.AddWithValue("@Cross", ex[TeethNum]);

            SqlCommand cmd2 = new SqlCommand(
                " SELECT TOP 1 * FROM [Teeth] ORDER BY TeethID DESC", sqlcon);


            sqlcon.Open();
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
                "Insert Into [PatientTeeth] (PatientID_fk,TeethID_fk) " +
                "Values(@PatientID_fk,@TeethID_fk) ", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@PatientID_fk", PatientID);
            cmd.Parameters.AddWithValue("@TeethID_fk", TeethID_fk);

            sqlcon.Open();
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
            //SqlCommand cmd = new SqlCommand(
            //    "SELECT CASE WHEN EXISTS ( SELECT Teethnumber FROM Teeth INNER JOIN [Patient-Teeth] " +
            //    "ON TeethID = TeethID_fk WHERE PatientID_fk = @patientID AND TeethNumber = @teethnum) " +
            //    "THEN CAST (1 AS BIT) ELSE CAST(0 AS BIT) END " ,sqlcon);
            SqlCommand cmd = new SqlCommand(
                "SELECT TeethID FROM Teeth " +
                "INNER JOIN[PatientTeeth] ON TeethID = TeethID_fk " +
                "WHERE PatientID_fk = @patientID AND TeethNumber = @teethnum", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@patientID", PatientID);
            cmd.Parameters.AddWithValue("@teethnum", teethNum);

            sqlcon.Open();
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
                "TeethLeft = @Left, TeethCenter = @Center, TeethCheck = @Check, TeethCross = @Cross " +
                "WHERE TeethID = @TeethID", sqlcon);

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Top", TopTeethColor[TeethNum]);
            cmd.Parameters.AddWithValue("@Bottom", BottomTeethColor[TeethNum]);
            cmd.Parameters.AddWithValue("@Right", RightTeethColor[TeethNum]);
            cmd.Parameters.AddWithValue("@Left", LeftTeethColor[TeethNum]);
            cmd.Parameters.AddWithValue("@Center", CenterTeethColor[TeethNum]);
            cmd.Parameters.AddWithValue("@Check", Checked[TeethNum]);
            cmd.Parameters.AddWithValue("@Cross", ex[TeethNum]);
            cmd.Parameters.AddWithValue("@TeethID", TeethID);


            sqlcon.Open();
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
            String teethTop = "White", teethBottom = "White", teethLeft = "White", teethRight = "White";
            String teethCenter = "White", teethCheck = "false", teethEx = "false";

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                    "SELECT TeethNumber, TeethTop, TeethBottom, TeethRight," +
                    "TeethLeft,TeethCenter, TeethCheck, TeethCross " +
                    "FROM Teeth INNER JOIN [PatientTeeth] " +
                    "ON TeethID = TeethID_fk " +
                    "WHERE PatientID_fk = @PatientID", sqlcon);

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
                TopTeethColor[teethNumber] = teethTop = dt.Rows[i][1].ToString();
                BottomTeethColor[teethNumber] = teethBottom = dt.Rows[i][2].ToString();
                RightTeethColor[teethNumber] = teethRight = dt.Rows[i][3].ToString();
                LeftTeethColor[teethNumber] = teethLeft = dt.Rows[i][4].ToString();
                CenterTeethColor[teethNumber] = teethCenter = dt.Rows[i][5].ToString();
                Checked[teethNumber] = teethCheck = dt.Rows[i][6].ToString();
                ex[teethNumber] = teethEx = dt.Rows[i][7].ToString();

                Panel teethNumberPanel = new Panel();
                teethNumberPanel = PanelNumber(teethNumber);
                Graphics gs = teethNumberPanel.CreateGraphics();


                if (teethTop == "Red")
                {
                    gs.FillPolygon(red, TopPolygonFill);

                }
                else if (teethTop == "Blue")
                {
                    gs.FillPolygon(blue, TopPolygonFill);
                }

                if (teethBottom == "Red")
                {
                    gs.FillPolygon(red, BottomPolygonFill);
                }
                else if (teethBottom == "Blue")
                {
                    gs.FillPolygon(blue, BottomPolygonFill);
                }

                if (teethLeft == "Red")
                {
                    gs.FillPolygon(red, LeftPolygonFill);
                }

                else if (teethLeft == "Blue")
                {
                    gs.FillPolygon(blue, LeftPolygonFill);
                }
                if (teethRight == "Red")
                {
                    gs.FillPolygon(red, RightPolygonFill);
                }
                else if (teethRight == "Blue")
                {
                    gs.FillPolygon(blue, RightPolygonFill);
                }
                if (teethCenter == "Red")
                {
                    gs.FillRectangle(red, InsideRectangleFill);
                }
                else if (teethCenter == "Blue")
                {
                    gs.FillRectangle(blue, InsideRectangleFill);
                }


                if (teethCheck == "true")
                {
                    gs.DrawPolygon(p2, check);
                    gs.FillPolygon(blue, check);

                }
                if (teethEx == "true")
                {
                    gs.DrawPolygon(p3, ekis1);
                    gs.DrawPolygon(p3, ekis2);
                    gs.FillPolygon(red, ekis1);
                    gs.FillPolygon(red, ekis2);
                }



            }
        }

        private void RefreshTeethPanel()
        {
            foreach(int panelControls in TeethArray)
            {
                int panelNumber = panelControls + 1;
                string panelName = "TeethPanel" + panelNumber;

                foreach (Control panelControl in panel1.Controls)
                {

                    if (panelControl.Name == panelName)
                    {
                        panelControl.Enabled = false;
                        panelControl.Enabled = true;
                    }
                }
            }
        }

      
        private void btn_SaveChart_Click(object sender, EventArgs e)
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
                    
                    //Console.WriteLine(Convert.ToInt32(cmd.ExecuteScalar()));
                }
                else
                {
                    // means wala pang existing  status sa teethnumber ng patient
                    // so mag iinsert ng bago
                    insertTeethStatus(teeth);
                   
                    //Console.WriteLine(Convert.ToInt32(cmd.ExecuteScalar()));
                }
            }
            MessageBox.Show("Save Successfully");
            TeethArray.Clear(); // empty arraylist
        }

        private void btn_RefreshChart_Click(object sender, EventArgs e)
        {
            // DisableTeethPanel();

            RefreshTeethPanel();
            SetDefaultTeethColor();
            RetrievePatientTeethStatus();
            TeethArray.Clear();

        }
 //----------------------------------------------------------------------------------------------------------------------------------
 // Notes
        private void btn_SaveNotes_Click_1(object sender, EventArgs e)
        {
            String PatientNote = txt_PatientNote.Text.Trim();
            String DateToday = DateTime.Today.ToString("M/d/yyyy");

            if (NoteIsEdit == true)
            {
                UpdateNote(PatientNote, DateToday);
            }
            else
            {
                InsertNote(PatientNote, DateToday);
            }
            txt_PatientNote.Clear();
            LoadNotes();
            NoteIsEdit = false;
        }

        private void UpdateNote(String PatientNote, String DateToday)
        {
            int NoteID = (int)(NoteDD.SelectedRows[0].Cells[0].Value);
            
            if (string.IsNullOrWhiteSpace(PatientNote) == false && NoteID > 0 )
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE [Notes] SET Note = @Note, NoteDate = @Date, PatientID_fk = @PatientID " +
                    "WHERE NotesID = @NoteID", sqlcon);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Note", PatientNote);
                cmd.Parameters.AddWithValue("@Date", DateToday);
                cmd.Parameters.AddWithValue("@PatientID", PatientID);
                cmd.Parameters.AddWithValue("@NoteID", NoteID);

                sqlcon.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Note Updated Successfully");
                }catch(Exception ex) { Console.WriteLine(ex.Message); }
                sqlcon.Close();
            }
        }
        
        private void InsertNote(String PatientNote,String DateToday)
        {
            if (string.IsNullOrWhiteSpace(PatientNote) == false)
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO [Notes] (Note,NoteDate,PatientID_fk) VALUES (@Note,@Date,@PatientID)", sqlcon);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Note", PatientNote);
                cmd.Parameters.AddWithValue("@Date", DateToday);
                cmd.Parameters.AddWithValue("@PatientID", PatientID);

                sqlcon.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Note Added Successfully");

                }catch(Exception ex) { Console.WriteLine(ex.Message); }
                sqlcon.Close();
            }
        }


        private void LoadNotes()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                "SELECT NotesID AS ID,NoteDate AS Date,Note FROM Notes WHERE PatientID_fk = @PatientID", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@PatientID", PatientID);
            adapter.SelectCommand = cmd;

            try
            {
                adapter.Fill(dt);
                NoteDD.DataSource = dt;

                NoteDD.Columns[0].Width = 50;
                NoteDD.Columns[1].Width = 80;

                NoteDD.Columns[1].DefaultCellStyle.Format = "M/d/yyyy";


            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void NoteDD_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            NoteIsEdit = true;
            txt_PatientNote.Text = NoteDD.SelectedRows[0].Cells[2].Value.ToString();


        }

        //-------------------------------------------------------------------------------------------------------------------------------
        //Treatment History

        private void LoadTreatmentHistory()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                "SELECT a.AppointmentID,a.AppointmentDate As Date,CONCAT(a.StartTime, ' - ', a.EndTime) AS Time, " +
                "p.Treatment,CONCAT(d.DentistFName, ' ', d.DentistLName) AS Dentist, a.Status " +
                "FROM Appointment a INNER JOIN PatientTreatment p ON a.AppointmentID = p.AppointmentID_fk " +
                "INNER JOIN Dentist d ON a.DentistID_fk = d.DentistID  WHERE p.PatientID_fk = @PatientID AND a.Status = 'COMPLETED'", sqlcon);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@PatientID", PatientID);
            adapter.SelectCommand = cmd;

            try
            {
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //replace comma "," with line break
                    dt.Rows[0][3] = dt.Rows[0][3].ToString().Replace(",", Environment.NewLine);
                }
                TreatmentHistory_DG.DataSource = dt;

                TreatmentHistory_DG.Columns[1].DefaultCellStyle.Format = "M/d/yyyy";


            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
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
                Billing_DataGrid.Columns[6].DefaultCellStyle.Format = "M/d/yyyy hh:mm tt";

            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }

            

            if (Billing_DataGrid.Rows.Count > 0)
            {
                Billing_DataGrid.Rows[0].Selected = true;
                GlobalVariable.BillingID = (int)(Billing_DataGrid.SelectedRows[0].Cells[0].Value);
            }

        }

        private void btn_AddPayment_Click(object sender, EventArgs e)
        {
            Billing_DataGrid.Width = 715;
            Payment_Panel.Visible = true;
            if (Billing_DataGrid.SelectedRows.Count > 0) // make sure user select at least 1 row 
            {

                txt_BllingID.Text = GlobalVariable.BillingID.ToString();
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

        private void InsertPayment()
        {
           float.TryParse(txt_Amount.Text,out float Amount);
        
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO [Payment] (PaymentAmount,PaymentBalance,LoginID_fk,BillingID_fk) " +
                "VALUES (@Amount,(SELECT BillingBalance FROM Billing WHERE BillingID = @BillingID) - @Amount " +
                ",@LoginID,@BillingID)",sqlcon);

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Amount", Amount);
            cmd.Parameters.AddWithValue("@LoginID", GlobalVariable.LoginID);
            cmd.Parameters.AddWithValue("@BillingID", GlobalVariable.BillingID);
            sqlcon.Open();
            try
            {
                cmd.ExecuteNonQuery();
               
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
            sqlcon.Open();
            try
            {
                cmd.ExecuteNonQuery();
               
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            sqlcon.Close();
        }

        private void btn_closePayment_Click(object sender, EventArgs e)
        {
            txt_Amount.Clear();
            Payment_Panel.Visible = false;
            Billing_DataGrid.Width = 922;
        }

        private void Billing_DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_BllingID.Text = Billing_DataGrid.SelectedRows[0].Cells[0].Value.ToString();
            GlobalVariable.BillingID = (int)(Billing_DataGrid.SelectedRows[0].Cells[0].Value);
            ShowPaymentHistory();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            add();
            ShowPaymentHistory();
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

        private void btn_CancelPayment_Click(object sender, EventArgs e)
        {
            if (PaymentHistory_DataGrid.SelectedRows.Count > 0)
            {

                SqlCommand cmd = new SqlCommand(
                "UPDATE Payment SET Status = 'Canceled', LoginID_fk = @LoginID WHERE PaymentID = @PaymentID", sqlcon);

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@LoginID", GlobalVariable.LoginID);
                cmd.Parameters.AddWithValue("@PaymentID", (int)(PaymentHistory_DataGrid.SelectedRows[0].Cells[0].Value));

                sqlcon.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    UpdateBalanceAfterPayment();
                    ShowPaymentHistory();
                    var ShowPatientInfo = Application.OpenForms.OfType<ShowPatientInfo>().First();
                    if (paymentID.Count > 0) { ShowPatientInfo.UpdateBillingAfterPayment(); }
                    ShowPatientInfo.ShowBilling();
                    paymentID.Clear();

                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                sqlcon.Close();
            }
        }


        private void ShowPaymentHistory()
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(
                "SELECT PaymentID,PaymentDate,PaymentAmount,PaymentBalance,CONCAT(l.FName, ' ', l.LName) AS UpdatedBy,Status " +
                "FROM Payment p INNER JOIN Login l ON p.LoginID_fk = l.LoginID WHERE BillingID_fk = @BillingID", sqlcon);

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


    }

   
}
