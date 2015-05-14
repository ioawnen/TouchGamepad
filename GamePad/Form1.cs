using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace gamepad
{
    public partial class Form1 : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams param = base.CreateParams;
                param.ExStyle |= 0x08000000;
                return param;
            }
        }

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        optionMenu optMenu = new optionMenu();
       
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;   //Embiggens window on start
            this.Bounds = Screen.PrimaryScreen.Bounds;      //Sets the bunds to cover everything
            this.FormBorderStyle = FormBorderStyle.None;    //removes the borders
        }

        private void upPress(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) { Console.WriteLine("UP RIGHT PRESS"); return; }
            else { Console.WriteLine("UP PRESS"); }
            SendKeys.Send(global::gamepad.Properties.Resources.upButtonKey);
        }
        private void leftPress(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) { Console.WriteLine("LEFT RIGHT PRESS"); return; }
            else { Console.WriteLine("LEFT PRESS"); }
            SendKeys.Send(global::gamepad.Properties.Resources.leftButtonKey);
        }
        private void downPress(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) { Console.WriteLine("DOWN RIGHT PRESS"); return; }
            else { Console.WriteLine("DOWN PRESS"); }
            SendKeys.Send(global::gamepad.Properties.Resources.downButtonKey);
        }
        private void rightPress(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) { Console.WriteLine("RIGHT RIGHT PRESS"); return; }
            else { Console.WriteLine("RIGHT PRESS"); }
            SendKeys.Send(global::gamepad.Properties.Resources.rightButtonKey);
        }
        private void aButtonPress(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) { Console.WriteLine("A RIGHT PRESS"); return; }
            else { Console.WriteLine("A PRESS"); }
            SendKeys.Send(global::gamepad.Properties.Resources.aButtonKey);
        }
        private void bButtonPress(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) { Console.WriteLine("B RIGHT PRESS"); return; }
            else { Console.WriteLine("B PRESS"); }
            SendKeys.Send(global::gamepad.Properties.Resources.bButtonKey);
        }
        private void xButtonPress(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) { Console.WriteLine("X RIGHT PRESS"); return; }
            else { Console.WriteLine("X PRESS"); }
            SendKeys.Send(global::gamepad.Properties.Resources.xButtonKey);
        }
        private void yButtonPress(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) { Console.WriteLine("Y RIGHT PRESS"); return; }
            else { Console.WriteLine("Y PRESS"); }
            SendKeys.Send(global::gamepad.Properties.Resources.yButtonKey);
        }  
        private void startButtonPress(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) { Console.WriteLine("START RIGHT PRESS"); return; }
            else { Console.WriteLine("START PRESS"); }
            SendKeys.Send(global::gamepad.Properties.Resources.startButtonKey);
            
        }
        private void selectButtonPress(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) { Console.WriteLine("SELECT RIGHT PRESS"); return; }
            else { Console.WriteLine("SELECT PRESS"); }
            SendKeys.Send(global::gamepad.Properties.Resources.selectButtonKey);   
        }

        private void menuButtonPress(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) { Console.WriteLine("MENU RIGHT PRESS"); return; }
            else { Console.WriteLine("MENU PRESS"); }

            if (optMenu.Visible) { optMenu.Hide(); }
            else { optMenu.Show(); }
        }
    }
}