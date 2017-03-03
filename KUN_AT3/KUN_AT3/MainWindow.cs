using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using System.Collections;

namespace KUN_AT3
{
    public partial class MainWindow : Form
    {
        PrintDocument printDoc = new PrintDocument();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                Information info = new Information();
                info.NumberOfKUN = NumberOfKUN.Text;
                info.DateOfKUN = DateOfKUN.Text;
                info.NumBoardAircraft1 = NumBoardAircraft1.Text;
                info.NumBoardAircraft2 = NumBoardAircraft2.Text;
                info.NumBoardAircraft3 = NumBoardAircraft3.Text;
                info.NumBoardAircraft4 = NumBoardAircraft4.Text;
                info.NumBoardAircraft5 = NumBoardAircraft5.Text;
                SaveXML.SaveData("data.xml", info);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void NumberOfKUN_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void NumBoardAircraft1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void NumBoardAircraft1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                NumBoardAircraft1.Focus();
            }
            else
            {
                NumBoardAircraft2.Focus();
            }
        }

        private void NumBoardAircraft2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                NumBoardAircraft1.Focus();
            }
            else
            {
                NumBoardAircraft3.Focus();
            }

        }

        private void NumBoardAircraft3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                NumBoardAircraft2.Focus();
            }
            else
            {
                NumBoardAircraft4.Focus();
            }
        }

        private void NumBoardAircraft4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                NumBoardAircraft3.Focus();
            }
            else
            {
                NumBoardAircraft5.Focus();
            }
        }

        private void NumBoardAircraft5_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                NumBoardAircraft4.Focus();
            }
        }
            [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest,
            int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        private Bitmap memoryImage;
        private void CaptureScreen()
        {
            Graphics mygraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width,
                this.ClientRectangle.Height, dc1, 0, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
        }
        private void printDocument1_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }
        //private void printButton_Click(System.Object sender, System.EventArgs e)
        //{
        //    CaptureScreen();
        //    printDocument1.Print();
        //}
    //
        private void PrinterSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog dlg = new PrintDialog();
            dlg.Document = printDoc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CaptureScreen();
                printDocument1.Print();
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox a = new AboutBox();
            a.Show();
        }

    }
}
