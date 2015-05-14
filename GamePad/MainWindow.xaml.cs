using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;

using System.Reflection;
using System.Windows.Interop;

namespace GamePad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
#region Code to stop gamepad ever stealing focus
            //Set the window style to noactivate.                               //this is what enables gamepad to NOT steal focus
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SetWindowLong(helper.Handle, GWL_EXSTYLE,
                GetWindowLong(helper.Handle, GWL_EXSTYLE) | WS_EX_NOACTIVATE);
        }

        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_NOACTIVATE = 0x08000000;

        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowLong(IntPtr hWnd,int nIndex,int dwNewLong);

        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd,int nIndex);
       
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
            #endregion

#region keys and bools
        const uint KEYEVENTF_KEYUP = 0x0002;
        const uint KEYEVENTF_EXTENDEDKEY = 0x0001;

        const int VK_LBUTTON = 0x01;
        const int VK_RBUTTON = 0x02;
        const int VK_CANCEL = 0x03;
        const int VK_MBUTTON = 0x04;
        const int VK_XBUTTON1 = 0x05;
        const int VK_XBUTTON2 = 0x06;
        
        const int VK_BACK = 0x08;
        const int VK_TAB = 0x09; // VK_TAB (09) TAB key
        const int VK_CLEAR = 0x0C; // VK_CLEAR (0C) CLEAR key
        const int VK_RETURN = 0x0D; // VK_RETURN (0D)
        const int VK_SHIFT = 0x10; // VK_SHIFT (10) SHIFT key
        const int VK_CONTROL = 0x11; // VK_CONTROL (11) CTRL key
        const int VK_MENU = 0x12; // VK_MENU (12) ALT key
        const int VK_PAUSE = 0x13; // VK_PAUSE (13) PAUSE key
        const int VK_CAPITAL = 0x14; // VK_CAPITAL (14) CAPS LOCK key   
        const int VK_ESCAPE = 0X1B;
        const int VK_SPACE = 0x20;
        const int VK_PRIOR = 0x21; // VK_PRIOR (21) PAGE UP key
        const int VK_NEXT = 0x22; // VK_NEXT (22) PAGE DOWN key
        const int VK_END = 0x23;
        const int VK_HOME = 0x24;
        const int VK_LEFT = 0x25; // VK_LEFT (25) LEFT ARROW key
        const int VK_UP = 0x26;
        const int VK_RIGHT = 0x27;
        const int VK_DOWN = 0x28;
        const int VK_SELECT = 0x29; // VK_SELECT (29) SELECT key
        const int VK_PRINT = 0x2A; // VK_PRINT (2A) PRINT key
        const int VK_EXECUTE = 0x2B; // VK_EXECUTE (2B) EXECUTE key
        const int VK_SNAPSHOT = 0x2C; // VK_SNAPSHOT (2C) PRINT SCREEN key
        const int VK_INSERT = 0x2D; // VK_INSERT (2D) INS key
        const int VK_DELETE = 0x2E; // VK_DELETE (2E) DEL key
        const int VK_HELP = 0x2F;  // VK_HELP (2F) HELP key

        const int VK_0 = 0x30;
        const int VK_1 = 0x31;
        const int VK_2 = 0x32;
        const int VK_3 = 0x33;
        const int VK_4 = 0x34;
        const int VK_5 = 0x35;
        const int VK_6 = 0x36;
        const int VK_7 = 0x37;
        const int VK_8 = 0x38;
        const int VK_9 = 0x39;
        
        const int VK_A = 0x41;
        const int VK_B = 0x42;
        const int VK_C = 0x43;
        const int VK_D = 0x44;
        const int VK_E = 0x45;
        const int VK_F = 0x46;
        const int VK_G = 0x47;
        const int VK_H = 0x48;
        const int VK_I = 0x49;
        const int VK_J = 0x4A;
        const int VK_K = 0x4B;
        const int VK_L = 0x4C;
        const int VK_M = 0x4D;
        const int VK_N = 0x4E;
        const int VK_O = 0x4F;
        const int VK_P = 0x50;
        const int VK_Q = 0x51;
        const int VK_R = 0x52;
        const int VK_S = 0x53;
        const int VK_T = 0x54;
        const int VK_U = 0x55;
        const int VK_V = 0x56;
        const int VK_W = 0x57;
        const int VK_X = 0x58;
        const int VK_Y = 0x59;
        const int VK_Z = 0x5A;

        const int VK_LWIN = 0x5B; // VK_LWIN (5B) Left Windows key (Microsoft Natural keyboard)
        const int VK_RWIN = 0x5C; // VK_RWIN (5C) Right Windows key (Natural keyboard)
        const int VK_APPS = 0x5D; // VK_APPS (5D) Applications key (Natural keyboard)
        const int VK_SLEEP = 0x5F; // VK_SLEEP (5F) Computer Sleep key
       
        const int VK_NUMPAD0 = 0x60;
        const int VK_NUMPAD1 = 0x61;
        const int VK_NUMPAD2 = 0x62;
        const int VK_NUMPAD3 = 0x63;
        const int VK_NUMPAD4 = 0x64;
        const int VK_NUMPAD5 = 0x65;
        const int VK_NUMPAD6 = 0x66;
        const int VK_NUMPAD7 = 0x67;
        const int VK_NUMPAD8 = 0x68;
        const int VK_NUMPAD9 = 0x69;

        const int VK_MULTIPLY = 0x6A;   // *
        const int VK_ADD = 0x6B;        // +
        const int VK_SEPARATOR = 0x6C;  // _ underscore presumably
        const int VK_SUBTRACT = 0x6D;   // -
        const int VK_DECIMAL = 0x6E;    //  .
        const int VK_DIVIDE = 0x6F;     // /

        const int VK_F1 = 0x70;        
        const int VK_F2 = 0x71;
        const int VK_F3 = 0x72;
        const int VK_F4 = 0x73;
        const int VK_F5 = 0x74; 
        const int VK_F6 = 0x75;  
        const int VK_F7 = 0x76;     
        const int VK_F8 = 0x77;  
        const int VK_F9 = 0x78;     
        const int VK_F10 = 0x79;        
        const int VK_F11 = 0x7A;   
        const int VK_F12 = 0x7B;   
        const int VK_F13 = 0x7C;    
        const int VK_F14 = 0x7D;    
        const int VK_F15 = 0x7E;
        const int VK_F16 = 0x7F;  
        const int VK_F17 = 0x80; 
        const int VK_F18 = 0x81;
        const int VK_F19 = 0x82;
        const int VK_F20 = 0x83;
        const int VK_F21 = 0x84;
        const int VK_F22 = 0x85;
        const int VK_F23 = 0x86;
        const int VK_F24 = 0x87;
        
        const int VK_NUMLOCK = 0x90;  // VK_NUMLOCK (90) NUM LOCK key
        const int VK_SCROLL = 0x91; // VK_SCROLL (91) SCROLL LOCK key
        const int VK_LSHIFT = 0xA0; // VK_LSHIFT (A0) Left SHIFT key
        const int VK_RSHIFT = 0xA1; // VK_RSHIFT (A1) Right SHIFT key
        const int VK_LCONTROL = 0xA2; // VK_LCONTROL (A2) Left CONTROL key
        const int VK_RCONTROL = 0xA3; // VK_RCONTROL (A3) Right CONTROL key
        const int VK_LMENU = 0xA4; // VK_LMENU (A4) Left MENU key
        const int VK_RMENU = 0xA5; // VK_RMENU (A5) Right MENU key

        const int VK_BROWSER_BACK = 0xA6;  
        const int VK_BROWSER_FORWARD = 0xA7; 
        const int VK_BROWSER_REFRESH = 0xA8;
        const int VK_BROWSER_STOP = 0xA9;
        const int VK_BROWSER_SEARCH = 0xAA;
        const int VK_BROWSER_FAVOURITES = 0xAB;
        const int VK_BROWSER_HOME = 0xAC;
        const int VK_VOLUME_MUTE = 0xAD;
        const int VK_VOLUME_DOWN = 0xAE;

        const int VK_VOLUME_UP = 0xAF;  
        const int VK_MEDIA_NEXT_TRACK = 0xB0; 
        const int VK_MEDIA_PREV_TRACK = 0xB1; 
        const int VK_MEDIA_STOP = 0xB2;
        const int VK_MEDIA_PLAY_PAUSE = 0xB3; 
        const int VK_LAUNCH_MAIL = 0xB4;
        const int VK_LAUNCH_MEDIA_SELECT= 0xB5;
        const int VK_LAUNCH_APP1 = 0xB6;
        const int VK_LAUNCH_APP2 = 0xB7;

        const int VK_OEM_1  = 0xBA;             //OEM Dependant (US standard layout ;: key)
        const int VK_OEM_PLUS  = 0xBB;             //corresponds to + key for any region
        const int VK_OEM_COMMA = 0xBC;             //corresponds to , key for any region
        const int VK_OEM_MINUS  = 0xBD;            //corresponds to - key for any region
        const int VK_OEM_PERIOD  = 0xBE;           //corresponds to . key for any region
        const int VK_OEM_2  = 0xBF;             //OEM Dependant (US standard layout /? key)
        const int VK_OEM_3  = 0xC0;             //OEM Dependant (US standard layout ~ key)
        const int VK_OEM_4  = 0xDB;             //OEM Dependant (US standard layout [{ key)
        const int VK_OEM_5  = 0xDC;             //OEM Dependant (US standard layout \| key)
        const int VK_OEM_6  = 0xDD;             //OEM Dependant (US standard layout ]} key)
        const int VK_OEM_7  = 0xDE;             //OEM Dependant (US standard layout '" key)
        const int VK_OEM_8  = 0xDF;             //OEM Dependant (fuck knows.)

       //0X0A - 0B are resevered keycodes
       //0X0E -0F are reserved keycodes    
       // 0x15 - 0x1A are language/undefined keycodes
       // 0X1C - 0X1F are IME codes (not needed)
       //0x3a-40 are undefined
       //0x88 - 8F are Unnassigned
       //0x92 - 96 are OEM specific, 0x97 - 9F are unassigned 
       //0XB8-B9 ARE RESERVED
       //0xC1-D7 RESERVED    
       //0xD8-DA RESERVED   

        bool upKillTouch = false;
        bool downKillTouch = false;
        bool leftKillTouch = false;
        bool rightKillTouch = false;
        bool upLeftKillTouch = false;
        bool upRightKillTouch = false;
        bool downLeftKillTouch =  false;
        bool downRightKillTouch = false;
        bool aKillTouch = false;
        bool bKillTouch = false;
        bool xKillTouch = false;
        bool yKillTouch = false;
        bool startKillTouch = false;
        bool selectKillTouch = false;
        //bool menuKillTouch = false;
        bool l1KillTouch = false;
        bool l2KillTouch = false;
        bool r1KillTouch = false;
        bool r2KillTouch = false;
        bool hotKey1KillTouch = false;
        bool hotKey2KillTouch = false;
        bool hotKey3KillTouch = false;
        //bool fullscreen = false;
        bool sendKeyMode = false; //if send key mode == true, buttons will utlise the sendkey versions of their input
        bool exit1Touch = false;
        bool exit2Touch = false;

        #endregion

        

        

        private NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenu trayMenu;

        OptionWindow options = new OptionWindow(); //Make the options menu

        public MainWindow()
        {
            InitializeComponent();
           
            // Create a tray menu with only one item.
            trayMenu = new System.Windows.Forms.ContextMenu();
            trayMenu.MenuItems.Add("Exit", exitButtonPress);

            // Create a tray icon. In this example we use a
            // standard system icon for simplicity, but you
            // can of course use your own custom icon too.
            trayIcon = new NotifyIcon();
            trayIcon.Text = "GamePad";
            trayIcon.Icon = new Icon(global::GamePad.Properties.Resources.icon, 40, 40);
            // Add menu to tray icon and show it.
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;            //Show icon in tray
            ShowInTaskbar = false;              // Remove from taskbar

            //SET LAYOUT HERE FROM SETTINGS
            setKeyOpacity(Properties.Settings.Default.buttonOpacity); //Opacity
            setabxyScale(Properties.Settings.Default.abxyScale); //abxy Scale
            setdpadScale(Properties.Settings.Default.dpadScale); //dpad Scale
            setCentreScale(Properties.Settings.Default.centerScale); //center Scale
            setHotKeyScale(Properties.Settings.Default.hotKeyScale);
            setHotKeyButtonOffset(Properties.Settings.Default.hotKeyOffset);
            setdpadOffset(Properties.Settings.Default.dpadOffset);
            setabxyOffset(Properties.Settings.Default.abxyOffset);
            setCenterButtonOffset(Properties.Settings.Default.centerOffset);
            
            //MAP DEFAULT KEYS UPON OPENING GAMEPAD
            options.upButtonAssign.SelectedValue = Properties.Settings.Default.upButton;
            options.downButtonAssign.SelectedValue = Properties.Settings.Default.downButton;
            options.leftButtonAssign.SelectedValue = Properties.Settings.Default.leftButton;
            options.rightButtonAssign.SelectedValue = Properties.Settings.Default.rightButton;
            options.aButtonAssign.SelectedValue = Properties.Settings.Default.aButton;
            options.bButtonAssign.SelectedValue = Properties.Settings.Default.bButton;
            options.xButtonAssign.SelectedValue = Properties.Settings.Default.xButton;
            options.yButtonAssign.SelectedValue = Properties.Settings.Default.yButton;
            options.startButtonAssign.SelectedValue = Properties.Settings.Default.startButton;
            options.selectButtonAssign.SelectedValue = Properties.Settings.Default.selectButton;
            options.l1ButtonAssign.SelectedValue = Properties.Settings.Default.l1Button;
            options.l2ButtonAssign.SelectedValue = Properties.Settings.Default.l2Button;
            options.r1ButtonAssign.SelectedValue = Properties.Settings.Default.r1Button;
            options.r2ButtonAssign.SelectedValue = Properties.Settings.Default.r2Button;
            options.hotKey1ButtonAssign.SelectedValue = Properties.Settings.Default.hotKey1Button;
            options.hotKey2ButtonAssign.SelectedValue = Properties.Settings.Default.hotKey2Button;
            options.hotKey3ButtonAssign.SelectedValue = Properties.Settings.Default.hotKey3Button;
            
            touchXLabel.Visibility = Visibility.Collapsed;
            touchYLabel.Visibility = Visibility.Collapsed;
            mouseXLabel.Visibility = Visibility.Collapsed;
            mouseYLabel.Visibility = Visibility.Collapsed;
            //scaletestSlider.Visibility = Visibility.Collapsed 
        }

#region opacity
        public void setKeyOpacity(double val) //Sets key opacity to an input double between 0.00 and 1.00
        {
            aButtonImage.Opacity = val;
            bButtonImage.Opacity = val;
            xButtonImage.Opacity = val;
            yButtonImage.Opacity = val;
            leftButtonImage.Opacity = val;
            upButtonImage.Opacity = val;
            rightButtonImage.Opacity = val;
            downButtonImage.Opacity = val;
            l1ButtonImage.Opacity = val;
            l2ButtonImage.Opacity = val;
            r1ButtonImage.Opacity = val;
            r2ButtonImage.Opacity = val;
            menuButtonImage.Opacity = val; 
            startButtonImage.Opacity = val;
            selectButtonImage.Opacity = val;
            hotKeyCanvas.Opacity = val;
            //VisibilityToggle.Opacity = val;
            //upLeftButton.Opacity = val;
            //upRightButton.Opacity = val;
            //downLeftButton.Opacity = val;
            //downRightButton.Opacity = val;
            menuToggle.Opacity = val;

            //Opacity doesn't quite work for this Ian setting it to max with these controls makes the gamepad invisible

            /*dpadCanvas.Opacity = val;
            abxyCanvas.Opacity = val;
            lButtonCanvas.Opacity = val;
            rButtonCanvas.Opacity = val;
            centerButtonCanvas.Opacity = val;*/
        }
#endregion

#region scaling
        public void setdpadScale(double scale)
        {
            ScaleTransform x = new ScaleTransform(scale, scale);
            dpadCanvas.RenderTransform = x;                      // Currently this function works and can replace the individual button images, but the render origins of the canvas need to be fucked with
            //upButtonImage.RenderTransform = x;
            //downButtonImage.RenderTransform = x;
            //leftButtonImage.RenderTransform = x;
            //rightButtonImage.RenderTransform = x;
        }
        public void setabxyScale(double scale)
        {
            ScaleTransform x = new ScaleTransform(scale, scale);
            //abxyCanvas.RenderTransform = x;                    Currently this function works and can replace the individual button images, but the render origins of the canvas need to be fucked with
            aButtonImage.RenderTransform = x;
            bButtonImage.RenderTransform = x;
            xButtonImage.RenderTransform = x;
            yButtonImage.RenderTransform = x;
            buttonBacking.RenderTransform = x;
        }
        public void setCentreScale(double scale)
        {
            
            ScaleTransform x = new ScaleTransform(scale, scale);
            //centerButtonCanvas.RenderTransform = x;            Currently this function works and can replace the individual button images, but the render origins of the canvas need to be fucked with
            startButtonImage.RenderTransform = x;
            selectButtonImage.RenderTransform = x;
            menuButtonImage.RenderTransform = x;
        }

        public void setHotKeyScale(double scale) //fine.
        {
            ScaleTransform x = new ScaleTransform(scale, scale);
            hotKeyCanvas.RenderTransform = x;           
        }

        public void setLRScale( Double scale)
        {
            ScaleTransform x = new ScaleTransform(scale, scale);
            lButtonCanvas.RenderTransform = x;             //    Currently this function works and can replace the individual button images, but the render origins of the canvas need to be fucked with
            rButtonCanvas.RenderTransform = x;
            //l1ButtonImage.RenderTransform = x;
            //l2ButtonImage.RenderTransform = x;
            //r1ButtonImage.RenderTransform = x;
            //r2ButtonImage.RenderTransform = x;

        }
        #endregion

#region offsets
        public void setdpadOffset(System.Drawing.Point pos)
        {
            Thickness x = dpadCanvas.Margin;
            x.Right = pos.X;
            x.Bottom = pos.Y;
            dpadCanvas.Margin = x;          
        }
        public void setabxyOffset(System.Drawing.Point pos)
        {
            Thickness x = abxyCanvas.Margin;
            x.Right = pos.X;
            x.Bottom = pos.Y;
            abxyCanvas.Margin = x;
        }
        public void setCenterButtonOffset(System.Drawing.Point pos)
        {
            Thickness x = centerButtonCanvas.Margin;
            x.Right = pos.X;
            x.Bottom = pos.Y;
            centerButtonCanvas.Margin = x;
        }

        public void setLButtonOffset(System.Drawing.Point pos)
        {
            Thickness x = lButtonCanvas.Margin;
            x.Right = pos.X;
            x.Bottom = pos.Y;
            lButtonCanvas.Margin = x;
        }

        public void setRButtonOffset(System.Drawing.Point pos)
        {
            Thickness x = rButtonCanvas.Margin;
            x.Right = pos.X;
            x.Bottom = pos.Y;
            rButtonCanvas.Margin = x;
        }

        public void setHotKeyButtonOffset(System.Drawing.Point pos)
        {
            Thickness x = hotKeyCanvas.Margin;
            x.Right = pos.X;
            x.Bottom = pos.Y;
            hotKeyCanvas.Margin = x;
        }
        #endregion

#region keypress cases
        private void pressKey(string key)
        {
            switch (key) //Keys commented out indicate they are not standard or even usable
            {
                case "Left Mouse Key": keybd_event((byte)VK_LBUTTON, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Right Mouse Key": keybd_event((byte)VK_RBUTTON, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                //case "Cancel": keybd_event((byte)VK_CANCEL, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Middle Mouse Key": keybd_event((byte)VK_MBUTTON, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "X1 Mouse key": keybd_event((byte)VK_XBUTTON1, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "X2 Mouse key": keybd_event((byte)VK_XBUTTON2, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Backspace": keybd_event((byte)VK_BACK, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Tab": keybd_event((byte)VK_TAB, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                //case "Clear": keybd_event((byte)VK_CLEAR, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Enter": keybd_event((byte)VK_RETURN, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Shift": keybd_event((byte)VK_SHIFT, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Ctrl": keybd_event((byte)VK_CONTROL, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Alt": keybd_event((byte)VK_MENU, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Pause": keybd_event((byte)VK_PAUSE, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Caps Lock": keybd_event((byte)VK_CAPITAL, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Esc": keybd_event((byte)VK_ESCAPE, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Space": keybd_event((byte)VK_SPACE, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Page Up": keybd_event((byte)VK_PRIOR, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Page Down": keybd_event((byte)VK_NEXT, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "End": keybd_event((byte)VK_END, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Home": keybd_event((byte)VK_HOME, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Left Arrow": keybd_event((byte)VK_LEFT, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Up Arrow": keybd_event((byte)VK_UP, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Right Arrow": keybd_event((byte)VK_T, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Down Arrow": keybd_event((byte)VK_U, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                //case "Select": keybd_event((byte)VK_SELECT, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                //case "Print Key": keybd_event((byte)VK_PRINT, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                //case "Execute Key": keybd_event((byte)VK_EXECUTE, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Insert": keybd_event((byte)VK_INSERT, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Delete": keybd_event((byte)VK_DELETE, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Help": keybd_event((byte)VK_HELP, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;

                case "0": keybd_event((byte)VK_0, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "1": keybd_event((byte)VK_1, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "2": keybd_event((byte)VK_2, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "3": keybd_event((byte)VK_3, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "4": keybd_event((byte)VK_4, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "5": keybd_event((byte)VK_5, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "6": keybd_event((byte)VK_6, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "7": keybd_event((byte)VK_7, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "8": keybd_event((byte)VK_8, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "9": keybd_event((byte)VK_9, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;

                case "A": keybd_event((byte)VK_A, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "B": keybd_event((byte)VK_B, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "C": keybd_event((byte)VK_C, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "D": keybd_event((byte)VK_D, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "E": keybd_event((byte)VK_E, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "F": keybd_event((byte)VK_F, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "G": keybd_event((byte)VK_G, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "H": keybd_event((byte)VK_H, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "I": keybd_event((byte)VK_I, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "J": keybd_event((byte)VK_J, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "K": keybd_event((byte)VK_K, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "L": keybd_event((byte)VK_L, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "M": keybd_event((byte)VK_M, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "N": keybd_event((byte)VK_N, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "O": keybd_event((byte)VK_O, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "P": keybd_event((byte)VK_P, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Q": keybd_event((byte)VK_Q, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "R": keybd_event((byte)VK_R, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "S": keybd_event((byte)VK_S, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "T": keybd_event((byte)VK_T, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "U": keybd_event((byte)VK_U, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "V": keybd_event((byte)VK_V, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "W": keybd_event((byte)VK_W, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "X": keybd_event((byte)VK_X, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Y": keybd_event((byte)VK_Y, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Z": keybd_event((byte)VK_Z, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
               
                case "Left Windows Key": keybd_event((byte)VK_LWIN, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Right Windows Key": keybd_event((byte)VK_RWIN, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Application Key": keybd_event((byte)VK_APPS, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Sleep": keybd_event((byte)VK_SLEEP, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;

                case "NUM0": keybd_event((byte)VK_NUMPAD0, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "NUM1": keybd_event((byte)VK_NUMPAD1, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "NUM2": keybd_event((byte)VK_NUMPAD2, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "NUM3": keybd_event((byte)VK_NUMPAD3, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "NUM4": keybd_event((byte)VK_NUMPAD4, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "NUM5": keybd_event((byte)VK_NUMPAD5, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "NUM6": keybd_event((byte)VK_NUMPAD6, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "NUM7": keybd_event((byte)VK_NUMPAD7, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "NUM8": keybd_event((byte)VK_NUMPAD8, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "NUM9": keybd_event((byte)VK_NUMPAD9, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
        
                case "*": keybd_event((byte)VK_MULTIPLY, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "+": keybd_event((byte)VK_ADD, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "separator": keybd_event((byte)VK_SEPARATOR, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "-": keybd_event((byte)VK_SUBTRACT, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case ".": keybd_event((byte)VK_DECIMAL, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "/": keybd_event((byte)VK_DIVIDE, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
               
                case "F1": keybd_event((byte)VK_F1, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "F2": keybd_event((byte)VK_F2, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "F3": keybd_event((byte)VK_F3, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "F4": keybd_event((byte)VK_F4, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "F5": keybd_event((byte)VK_F5, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "F6": keybd_event((byte)VK_F6, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "F7": keybd_event((byte)VK_F7, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "F8": keybd_event((byte)VK_F8, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "F9": keybd_event((byte)VK_F9, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "F10": keybd_event((byte)VK_F10, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "F11": keybd_event((byte)VK_F11, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "F12": keybd_event((byte)VK_F12, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "F13": keybd_event((byte)VK_F13, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "F14": keybd_event((byte)VK_F14, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "F15": keybd_event((byte)VK_F15, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "F16": keybd_event((byte)VK_F16, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "F17": keybd_event((byte)VK_F17, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "F18": keybd_event((byte)VK_F18, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "F19": keybd_event((byte)VK_F19, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "F20": keybd_event((byte)VK_F20, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "F21": keybd_event((byte)VK_F21, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "F22": keybd_event((byte)VK_F22, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "F23": keybd_event((byte)VK_F23, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "F24": keybd_event((byte)VK_F24, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;

                
                case "Num Lock": keybd_event((byte)VK_NUMLOCK, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Scroll Lock": keybd_event((byte)VK_SCROLL, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Left Shift": keybd_event((byte)VK_LSHIFT, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Right Shift": keybd_event((byte)VK_RSHIFT, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Left Ctrl": keybd_event((byte)VK_LCONTROL, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Right Ctrl": keybd_event((byte)VK_RCONTROL, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Left Alt": keybd_event((byte)VK_LMENU, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Right Alt": keybd_event((byte)VK_RMENU, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;

                case "; or :": keybd_event((byte)VK_OEM_1, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "/ or ?": keybd_event((byte)VK_OEM_2, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "[ or {": keybd_event((byte)VK_OEM_1, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "~": keybd_event((byte)VK_OEM_2, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "\\ or |": keybd_event((byte)VK_OEM_1, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "] or }": keybd_event((byte)VK_OEM_2, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "single/double quote": keybd_event((byte)VK_OEM_2, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
              
                
            }
            Console.WriteLine(key+" DOWN");
        }
        private void pressKeySendKeyMode(string key)
        {
            switch (key) //Keys commented out indicate they are not standard or even usable
            {
                //case "Left Mouse Key": keybd_event((byte)VK_LBUTTON, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                //case "Right Mouse Key": keybd_event((byte)VK_RBUTTON, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                //case "Cancel": keybd_event((byte)VK_CANCEL, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                //case "Middle Mouse Key": keybd_event((byte)VK_MBUTTON, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                //case "X1 Mouse key": keybd_event((byte)VK_XBUTTON1, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                //case "X2 Mouse key": keybd_event((byte)VK_XBUTTON2, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Backspace": SendKeys.SendWait("{BS}"); break;
                case "Tab": SendKeys.SendWait("{TAB}"); break;
                //case "Clear": keybd_event((byte)VK_CLEAR, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Enter": SendKeys.SendWait("{~}"); break;
                case "Shift": SendKeys.SendWait("{+}"); break;
                case "Ctrl": SendKeys.SendWait("{^}"); break;
                case "Alt": SendKeys.SendWait("{%}"); break;
                case "Pause": SendKeys.SendWait("{BREAK}"); break;
                case "Caps Lock": SendKeys.SendWait("{CAPSLOCK}"); break;
                case "Esc": SendKeys.SendWait("{ESC}"); break;
                case "Space": SendKeys.SendWait(" "); break;
                case "Page Up": SendKeys.SendWait("{PGUP}"); break;
                case "Page Down": SendKeys.SendWait("{PGDN}"); break;
                case "End": SendKeys.SendWait("{END}"); break;
                case "Home": SendKeys.SendWait("{HOME}"); break;
                case "Left Arrow": SendKeys.SendWait("{LEFT}"); break;
                case "Up Arrow": SendKeys.SendWait("{UP}"); break;
                case "Right Arrow": SendKeys.SendWait("{RIGHT}"); break;
                case "Down Arrow": SendKeys.SendWait("{DOWN}"); break;
                //case "Select": keybd_event((byte)VK_SELECT, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                //case "Print Key": keybd_event((byte)VK_PRINT, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                //case "Execute Key": keybd_event((byte)VK_EXECUTE, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Insert": SendKeys.SendWait("{INSERT}"); break;
                case "Delete": SendKeys.SendWait("{DEL}"); break;
                case "Help": SendKeys.SendWait("{HELP}"); break;

                case "0": SendKeys.SendWait("0"); break;
                case "1": SendKeys.SendWait("1"); break;
                case "2": SendKeys.SendWait("2"); break;
                case "3": SendKeys.SendWait("3"); break;
                case "4": SendKeys.SendWait("4"); break;
                case "5": SendKeys.SendWait("5"); break;
                case "6": SendKeys.SendWait("6"); break;
                case "7": SendKeys.SendWait("7"); break;
                case "8": SendKeys.SendWait("8"); break;
                case "9": SendKeys.SendWait("9"); break;

                case "A": SendKeys.SendWait("a"); break;
                case "B": SendKeys.SendWait("b"); break;
                case "C": SendKeys.SendWait("c"); break;
                case "D": SendKeys.SendWait("d"); break;
                case "E": SendKeys.SendWait("e"); break;
                case "F": SendKeys.SendWait("f"); break;
                case "G": SendKeys.SendWait("g"); break;
                case "H": SendKeys.SendWait("h"); break;
                case "I": SendKeys.SendWait("i"); break;
                case "J": SendKeys.SendWait("j"); break;
                case "K": SendKeys.SendWait("k"); break;
                case "L": SendKeys.SendWait("l"); break;
                case "M": SendKeys.SendWait("m"); break;
                case "N": SendKeys.SendWait("n"); break;
                case "O": SendKeys.SendWait("o"); break;
                case "P": SendKeys.SendWait("p"); break;
                case "Q": SendKeys.SendWait("q"); break;
                case "R": SendKeys.SendWait("r"); break;
                case "S": SendKeys.SendWait("s"); break;
                case "T": SendKeys.SendWait("t"); break;
                case "U": SendKeys.SendWait("u"); break;
                case "V": SendKeys.SendWait("v"); break;
                case "W": SendKeys.SendWait("w"); break;
                case "X": SendKeys.SendWait("x"); break;
                case "Y": SendKeys.SendWait("y"); break;
                case "Z": SendKeys.SendWait("z"); break;



                case "Left Windows Key": SendKeys.SendWait("{LWin}"); break;
                case "Right Windows Key": SendKeys.SendWait("{RWin}"); break;
                case "Application Key": SendKeys.SendWait("{AppsKey}"); break;
                case "Sleep": SendKeys.SendWait("{Sleep}"); break;

                case "NUM0": SendKeys.SendWait("{Numpad0}"); break;
                case "NUM1": SendKeys.SendWait("{Numpad1}"); break;
                case "NUM2": SendKeys.SendWait("{Numpad2}"); break;
                case "NUM3": SendKeys.SendWait("{Numpad3}"); break;
                case "NUM4": SendKeys.SendWait("{Numpad4}"); break;
                case "NUM5": SendKeys.SendWait("{Numpad5}"); break;
                case "NUM6": SendKeys.SendWait("{Numpad6}"); break;
                case "NUM7": SendKeys.SendWait("{Numpad7}"); break;
                case "NUM8": SendKeys.SendWait("{Numpad8}"); break;
                case "NUM9": SendKeys.SendWait("{Numpad9}"); break;

                case "*": SendKeys.SendWait("MULTIPLY"); break;
                case "+": SendKeys.SendWait("ADD"); break;
                //case "separator": SendKeys.SendWait("z"); break;
                case "-": SendKeys.SendWait("SUBTRACT"); break;
                case ".": SendKeys.SendWait("OemPeriod"); break;
                case "/": SendKeys.SendWait("DIVIDE"); break;

                case "F1": SendKeys.SendWait("{F1}"); break;
                case "F2": SendKeys.SendWait("{F2}"); break;
                case "F3": SendKeys.SendWait("{F3}"); break;
                case "F4": SendKeys.SendWait("{F4}"); break;
                case "F5": SendKeys.SendWait("{F5}"); break;
                case "F6": SendKeys.SendWait("{F6}"); break;
                case "F7": SendKeys.SendWait("{F7}"); break;
                case "F8": SendKeys.SendWait("{F8}"); break;
                case "F9": SendKeys.SendWait("{F9}"); break;
                case "F10": SendKeys.SendWait("{F10}"); break;
                case "F11": SendKeys.SendWait("{F11}"); break;
                case "F12": SendKeys.SendWait("{F12}"); break;
                case "F13": SendKeys.SendWait("{F13}"); break;
                case "F14": SendKeys.SendWait("{F14}"); break;
                case "F15": SendKeys.SendWait("{F15}"); break;
                case "F16": SendKeys.SendWait("{F16}"); break;
                case "F17": SendKeys.SendWait("{F17}"); break;
                case "F18": SendKeys.SendWait("{F18}"); break;
                case "F19": SendKeys.SendWait("{F19}"); break;
                case "F20": SendKeys.SendWait("{F20}"); break;
                case "F21": SendKeys.SendWait("{F21}"); break;
                case "F22": SendKeys.SendWait("{F22}"); break;
                case "F23": SendKeys.SendWait("{F23}"); break;
                case "F24": SendKeys.SendWait("{F24}"); break;



                case "Num Lock": SendKeys.SendWait("{NumLock}"); break;
                case "Scroll Lock": SendKeys.SendWait("{ScrollLock}"); break;
                case "Left Shift": SendKeys.SendWait("{LShift}"); break;
                case "Right Shift": SendKeys.SendWait("{RShift}"); break;
                case "Left Ctrl": SendKeys.SendWait("{LCtrl}"); break;
                case "Right Ctrl": SendKeys.SendWait("{RCtrl}"); break;
                case "Left Alt": SendKeys.SendWait("{LAlt}"); break;
                case "Right Alt": SendKeys.SendWait("{RAlt}"); break;

                case "; or :": SendKeys.SendWait(";"); break;
                case "/ or ?": SendKeys.SendWait("/"); break;
                case "[ or {": SendKeys.SendWait("{{}"); break;
                case "~": SendKeys.SendWait("{#}"); break;
                case "\\ or |": SendKeys.SendWait("{}}"); break;
                case "] or }": SendKeys.SendWait("{}}"); break;
                case "single/double quote": SendKeys.SendWait("\"");  break;
            }
            Console.WriteLine(key + " DOWN");
        }
        private void releaseKey(string key)
        {
            switch (key)
            {
                case "Left Mouse Key": keybd_event((byte)VK_LBUTTON, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Right Mouse Key": keybd_event((byte)VK_RBUTTON, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                //case "Cancel": keybd_event((byte)VK_CANCEL, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); break;
                case "Middle Mouse Key": keybd_event((byte)VK_MBUTTON, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "X1 Mouse key": keybd_event((byte)VK_XBUTTON1, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "X2 Mouse key": keybd_event((byte)VK_XBUTTON2, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Backspace": keybd_event((byte)VK_BACK, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Tab": keybd_event((byte)VK_TAB, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                //case "Clear": keybd_event((byte)VK_CLEAR, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Enter": keybd_event((byte)VK_RETURN, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Shift": keybd_event((byte)VK_SHIFT, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Ctrl": keybd_event((byte)VK_CONTROL, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Alt": keybd_event((byte)VK_MENU, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Pause": keybd_event((byte)VK_PAUSE, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Caps Lock": keybd_event((byte)VK_CAPITAL, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Esc": keybd_event((byte)VK_ESCAPE, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Space": keybd_event((byte)VK_SPACE, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Page Up": keybd_event((byte)VK_PRIOR, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Page Down": keybd_event((byte)VK_NEXT, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "End": keybd_event((byte)VK_END, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Home": keybd_event((byte)VK_HOME, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Left Arrow": keybd_event((byte)VK_LEFT, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Up Arrow": keybd_event((byte)VK_UP, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Right Arrow": keybd_event((byte)VK_T, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Down Arrow": keybd_event((byte)VK_U, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                //case "Select": keybd_event((byte)VK_SELECT, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                //case "Print Key": keybd_event((byte)VK_PRINT, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                //case "Execute Key": keybd_event((byte)VK_EXECUTE, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Insert": keybd_event((byte)VK_INSERT, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Delete": keybd_event((byte)VK_DELETE, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Help": keybd_event((byte)VK_HELP, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;

                case "0": keybd_event((byte)VK_0, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "1": keybd_event((byte)VK_1, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "2": keybd_event((byte)VK_2, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "3": keybd_event((byte)VK_3, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "4": keybd_event((byte)VK_4, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "5": keybd_event((byte)VK_5, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "6": keybd_event((byte)VK_6, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "7": keybd_event((byte)VK_7, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "8": keybd_event((byte)VK_8, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "9": keybd_event((byte)VK_9, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;

                case "A": keybd_event((byte)VK_A, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "B": keybd_event((byte)VK_B, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "C": keybd_event((byte)VK_C, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "D": keybd_event((byte)VK_D, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "E": keybd_event((byte)VK_E, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "F": keybd_event((byte)VK_F, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "G": keybd_event((byte)VK_G, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "H": keybd_event((byte)VK_H, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "I": keybd_event((byte)VK_I, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "J": keybd_event((byte)VK_J, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "K": keybd_event((byte)VK_K, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "L": keybd_event((byte)VK_L, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "M": keybd_event((byte)VK_M, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "N": keybd_event((byte)VK_N, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "O": keybd_event((byte)VK_O, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "P": keybd_event((byte)VK_P, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Q": keybd_event((byte)VK_Q, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "R": keybd_event((byte)VK_R, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "S": keybd_event((byte)VK_S, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "T": keybd_event((byte)VK_T, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "U": keybd_event((byte)VK_U, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "V": keybd_event((byte)VK_V, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "W": keybd_event((byte)VK_W, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "X": keybd_event((byte)VK_X, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Y": keybd_event((byte)VK_Y, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Z": keybd_event((byte)VK_Z, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
               
                case "Left Windows Key": keybd_event((byte)VK_LWIN, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Right Windows Key": keybd_event((byte)VK_RWIN, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Application Key": keybd_event((byte)VK_APPS, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Sleep": keybd_event((byte)VK_SLEEP, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;

                case "NUM0": keybd_event((byte)VK_NUMPAD0, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "NUM1": keybd_event((byte)VK_NUMPAD1, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "NUM2": keybd_event((byte)VK_NUMPAD2, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "NUM3": keybd_event((byte)VK_NUMPAD3, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "NUM4": keybd_event((byte)VK_NUMPAD4, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "NUM5": keybd_event((byte)VK_NUMPAD5, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "NUM6": keybd_event((byte)VK_NUMPAD6, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "NUM7": keybd_event((byte)VK_NUMPAD7, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "NUM8": keybd_event((byte)VK_NUMPAD8, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "NUM9": keybd_event((byte)VK_NUMPAD9, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
        
                case "*": keybd_event((byte)VK_MULTIPLY, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "+": keybd_event((byte)VK_ADD, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "separator": keybd_event((byte)VK_SEPARATOR, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "-": keybd_event((byte)VK_SUBTRACT, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case ".": keybd_event((byte)VK_DECIMAL, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "/": keybd_event((byte)VK_DIVIDE, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
               
                case "F1": keybd_event((byte)VK_F1, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "F2": keybd_event((byte)VK_F2, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "F3": keybd_event((byte)VK_F3, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "F4": keybd_event((byte)VK_F4, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "F5": keybd_event((byte)VK_F5, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "F6": keybd_event((byte)VK_F6, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "F7": keybd_event((byte)VK_F7, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "F8": keybd_event((byte)VK_F8, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "F9": keybd_event((byte)VK_F9, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "F10": keybd_event((byte)VK_F10, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "F11": keybd_event((byte)VK_F11, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "F12": keybd_event((byte)VK_F12, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "F13": keybd_event((byte)VK_F13, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "F14": keybd_event((byte)VK_F14, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "F15": keybd_event((byte)VK_F15, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "F16": keybd_event((byte)VK_F16, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "F17": keybd_event((byte)VK_F17, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "F18": keybd_event((byte)VK_F18, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "F19": keybd_event((byte)VK_F19, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "F20": keybd_event((byte)VK_F20, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "F21": keybd_event((byte)VK_F21, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "F22": keybd_event((byte)VK_F22, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "F23": keybd_event((byte)VK_F23, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "F24": keybd_event((byte)VK_F24, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                
                case "Num Lock": keybd_event((byte)VK_NUMLOCK, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Scroll Lock": keybd_event((byte)VK_SCROLL, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Left Shift": keybd_event((byte)VK_LSHIFT, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Right Shift": keybd_event((byte)VK_RSHIFT, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Left Ctrl": keybd_event((byte)VK_LCONTROL, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Right Ctrl": keybd_event((byte)VK_RCONTROL, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Left Alt": keybd_event((byte)VK_LMENU, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "Right Alt": keybd_event((byte)VK_RMENU, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;

                case "; or :": keybd_event((byte)VK_OEM_1, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "/ or ?": keybd_event((byte)VK_OEM_2, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "[ or {": keybd_event((byte)VK_OEM_1, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "~": keybd_event((byte)VK_OEM_2, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "\\ or |": keybd_event((byte)VK_OEM_1, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "] or }": keybd_event((byte)VK_OEM_2, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break;
                case "single/double quote": keybd_event((byte)VK_OEM_2, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); break; 
            }
            Console.WriteLine(key+" UP");
        }
#endregion

#region button press events
        private async void upTouch(object sender, TouchEventArgs e)
        {          
            upKillTouch = true;
            while (upKillTouch)
            {

                if (sendKeyMode == false)
                {
                    //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    pressKey(Properties.Settings.Default.upButton);
                    
                }

                else
                {
                    pressKeySendKeyMode(Properties.Settings.Default.upButton);
                }
                await Task.Delay(400);
            }
        }

        private void upTouchRelease(object sender, TouchEventArgs e)
        {            
            upKillTouch = false;
            if (sendKeyMode == false)
            {
                //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                releaseKey(Properties.Settings.Default.upButton);
            }
        }

        private async void downTouch(object sender, TouchEventArgs e)
        {
            downKillTouch = true;
            while (downKillTouch)
            {

                if (sendKeyMode == false)
                {
                    //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    pressKey(Properties.Settings.Default.downButton);

                }

                else
                {
                    pressKeySendKeyMode(Properties.Settings.Default.downButton);
                }
                await Task.Delay(400);
            }
           
        }

        private void downTouchRelease(object sender, TouchEventArgs e)
        {
            downKillTouch = false;

            if (sendKeyMode == false)
            {
                //keybd_event((byte)VK_DOWN, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                releaseKey(Properties.Settings.Default.downButton);
            }
        }

        private async void leftTouch(object sender, TouchEventArgs e)
        {
            leftKillTouch = true;
            while (leftKillTouch)
            {

                if (sendKeyMode == false)
                {
                    //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    pressKey(Properties.Settings.Default.leftButton);

                }

                else
                {
                    pressKeySendKeyMode(Properties.Settings.Default.leftButton);
                }
                await Task.Delay(400);
            }
        }
        private void leftTouchRelease(object sender, TouchEventArgs e)
        {
            leftKillTouch = false;
            if (sendKeyMode == false)
            {
                //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                releaseKey(Properties.Settings.Default.leftButton);
            }
        }

        private async void rightTouch(object sender, TouchEventArgs e)
        {
            rightKillTouch = true;
            while (rightKillTouch)
            {

                if (sendKeyMode == false)
                {
                    //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    pressKey(Properties.Settings.Default.rightButton);

                }

                else
                {
                    pressKeySendKeyMode(Properties.Settings.Default.rightButton);
                }
                await Task.Delay(400);
            }
        }
        private void rightTouchRelease(object sender, TouchEventArgs e)
        {
            rightKillTouch = false;
            if (sendKeyMode == false)
            {
                //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                releaseKey(Properties.Settings.Default.rightButton);
            }
        }

        private async void upLeftTouch(object sender, TouchEventArgs e)
        {
            upLeftKillTouch = true;
            while (upLeftKillTouch)
            {

                if (sendKeyMode == false)
                {
                    //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    pressKey(Properties.Settings.Default.upButton);
                    pressKey(Properties.Settings.Default.leftButton);

                }

                else
                {
                    pressKeySendKeyMode(Properties.Settings.Default.upButton);
                    pressKeySendKeyMode(Properties.Settings.Default.leftButton);
                }
                await Task.Delay(400);
            }
        }

        private void upLeftTouchRelease(object sender, TouchEventArgs e)
        {
            upLeftKillTouch = false;
            if (sendKeyMode == false)
            {
                //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                releaseKey(Properties.Settings.Default.upButton);
                releaseKey(Properties.Settings.Default.leftButton);
            }
        }

        private async void upRightTouch(object sender, TouchEventArgs e)
        {
            upRightKillTouch = true;
            while (upRightKillTouch)
            {

                if (sendKeyMode == false)
                {
                    //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    pressKey(Properties.Settings.Default.upButton);
                    pressKey(Properties.Settings.Default.rightButton);

                }

                else
                {
                    pressKeySendKeyMode(Properties.Settings.Default.upButton);
                    pressKeySendKeyMode(Properties.Settings.Default.rightButton);
                }
                await Task.Delay(400);
            }
        }


        private void upRightTouchRelease(object sender, TouchEventArgs e)
        {
            upRightKillTouch = false;
            if (sendKeyMode == false)
            {
                //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                releaseKey(Properties.Settings.Default.upButton);
                releaseKey(Properties.Settings.Default.rightButton);
            }
        }

        private async void downLeftTouch(object sender, TouchEventArgs e)
        {
            downLeftKillTouch = true;
            while (downLeftKillTouch)
            {

                if (sendKeyMode == false)
                {
                    //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    pressKey(Properties.Settings.Default.downButton);
                    pressKey(Properties.Settings.Default.leftButton);

                }

                else
                {
                    pressKeySendKeyMode(Properties.Settings.Default.downButton);
                    pressKeySendKeyMode(Properties.Settings.Default.leftButton);
                }
                await Task.Delay(400);
            }
        }

        private void downLeftTouchRelease(object sender, TouchEventArgs e)
        {
            downLeftKillTouch = false;
            if (sendKeyMode == false)
            {
                //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                releaseKey(Properties.Settings.Default.downButton);
                releaseKey(Properties.Settings.Default.leftButton);
            }
        }

        private async void downRightTouch(object sender, TouchEventArgs e)
        {
           downRightKillTouch = true;
            while (downRightKillTouch)
            {

                if (sendKeyMode == false)
                {
                    //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    pressKey(Properties.Settings.Default.downButton);
                    pressKey(Properties.Settings.Default.rightButton);

                }

                else
                {
                    pressKeySendKeyMode(Properties.Settings.Default.downButton);
                    pressKeySendKeyMode(Properties.Settings.Default.rightButton);
                }
                await Task.Delay(400);
            }
        }


        private void downRightTouchRelease(object sender, TouchEventArgs e)
        {
            downRightKillTouch = false;
            if (sendKeyMode == false)
            {
                //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                releaseKey(Properties.Settings.Default.downButton);
                releaseKey(Properties.Settings.Default.rightButton);
            }
        }
        private async void aTouch(object sender, TouchEventArgs e)
        {
            aKillTouch = true;
            while (aKillTouch)
            {

                if (sendKeyMode == false)
                {
                    //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    pressKey(Properties.Settings.Default.aButton);

                }

                else
                {
                    pressKeySendKeyMode(Properties.Settings.Default.aButton);
                }
                await Task.Delay(400);
            }
        }
        private void aTouchRelease(object sender, TouchEventArgs e)
        {
            aKillTouch = false;
            if (sendKeyMode == false)
            {
                //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                releaseKey(Properties.Settings.Default.aButton);
            }
        }

        private async void bTouch(object sender, TouchEventArgs e)
        {
            bKillTouch = true;
            while (bKillTouch)
            {

                if (sendKeyMode == false)
                {
                    //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    pressKey(Properties.Settings.Default.bButton);

                }

                else
                {
                    pressKeySendKeyMode(Properties.Settings.Default.bButton);
                }
                await Task.Delay(400);
            }
        }
        private void bTouchRelease(object sender, TouchEventArgs e)
        {
            bKillTouch = false;
            if (sendKeyMode == false)
            {
                //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                releaseKey(Properties.Settings.Default.bButton);
            }
        }

        private async void xTouch(object sender, TouchEventArgs e)
        {
            xKillTouch = true;
            while (xKillTouch)
            {

                if (sendKeyMode == false)
                {
                    //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    pressKey(Properties.Settings.Default.xButton);

                }

                else
                {
                    pressKeySendKeyMode(Properties.Settings.Default.xButton);
                }
                await Task.Delay(400);
            }
        }
        private void xTouchRelease(object sender, TouchEventArgs e)
        {
            xKillTouch = false;
            if (sendKeyMode == false)
            {
                //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                releaseKey(Properties.Settings.Default.xButton);
            }
        }

        private async void yTouch(object sender, TouchEventArgs e)
        {
            yKillTouch = true;
            while (yKillTouch)
            {

                if (sendKeyMode == false)
                {
                    //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    pressKey(Properties.Settings.Default.yButton);

                }

                else
                {
                    pressKeySendKeyMode(Properties.Settings.Default.yButton);
                }
                await Task.Delay(400);
            }
        }
        private void yTouchRelease(object sender, TouchEventArgs e)
        {
            yKillTouch = false;
            if (sendKeyMode == false)
            {
                //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                releaseKey(Properties.Settings.Default.yButton);
            }
        }

        private async void startTouch(object sender, TouchEventArgs e)
        {
            startKillTouch = true;
            while (startKillTouch)
            {

                if (sendKeyMode == false)
                {
                    //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    pressKey(Properties.Settings.Default.startButton);

                }

                else
                {
                    pressKeySendKeyMode(Properties.Settings.Default.startButton);
                }
                await Task.Delay(400);
            }
        }
        private void startTouchRelease(object sender, TouchEventArgs e)
        {
            startKillTouch = false;
            if (sendKeyMode == false)
            {
                //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                releaseKey(Properties.Settings.Default.startButton);
            }
        }

        private async void selectTouch(object sender, TouchEventArgs e)
        {
            selectKillTouch = true;
            while (selectKillTouch)
            {

                if (sendKeyMode == false)
                {
                    //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    pressKey(Properties.Settings.Default.selectButton);

                }

                else
                {
                    pressKeySendKeyMode(Properties.Settings.Default.selectButton);
                }
                await Task.Delay(400);
            }
        }
        private void selectTouchRelease(object sender, TouchEventArgs e)
        {
            selectKillTouch = false;
            if (sendKeyMode == false)
            {
                //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                releaseKey(Properties.Settings.Default.selectButton);
            }
        }

        private async void l1Touch(object sender, TouchEventArgs e)
        {
            l1KillTouch = true;
            while (l1KillTouch)
            {

                if (sendKeyMode == false)
                {
                    //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    pressKey(Properties.Settings.Default.l1Button);

                }

                else
                {
                    pressKeySendKeyMode(Properties.Settings.Default.l1Button);
                }
                await Task.Delay(400);
            }
        }
        private void l1TouchRelease(object sender, TouchEventArgs e)
        {
            l1KillTouch = false;
            if (sendKeyMode == false)
            {
                //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                releaseKey(Properties.Settings.Default.l1Button);
            }
        }

        private async void l2Touch(object sender, TouchEventArgs e)
        {
            l2KillTouch = true;
            while (l2KillTouch)
            {

                if (sendKeyMode == false)
                {
                    //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    pressKey(Properties.Settings.Default.l2Button);

                }

                else
                {
                    pressKeySendKeyMode(Properties.Settings.Default.l2Button);
                }
                await Task.Delay(400);
            }
        }
        private void l2TouchRelease(object sender, TouchEventArgs e)
        {
            l2KillTouch = false;
            if (sendKeyMode == false)
            {
                //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                releaseKey(Properties.Settings.Default.l2Button);
            }
        }

        private async void r1Touch(object sender, TouchEventArgs e)
        {
            r1KillTouch = true;
            while (r1KillTouch)
            {

                if (sendKeyMode == false)
                {
                    //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    pressKey(Properties.Settings.Default.r1Button);

                }

                else
                {
                    pressKeySendKeyMode(Properties.Settings.Default.r1Button);
                }
                await Task.Delay(400);
            }
        }
        private void r1TouchRelease(object sender, TouchEventArgs e)
        {
            r1KillTouch = false;
            if (sendKeyMode == false)
            {
                //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                releaseKey(Properties.Settings.Default.r1Button);
            }
        }

        private async void r2Touch(object sender, TouchEventArgs e)
        {
            r2KillTouch = true;
            while (r2KillTouch)
            {

                if (sendKeyMode == false)
                {
                    //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    pressKey(Properties.Settings.Default.r2Button);

                }

                else
                {
                    pressKeySendKeyMode(Properties.Settings.Default.r2Button);
                }
                await Task.Delay(400);
            }
        }
        private void r2TouchRelease(object sender, TouchEventArgs e)
        {
            r2KillTouch = false;
            if (sendKeyMode == false)
            {
                //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                releaseKey(Properties.Settings.Default.r2Button);
            }
        }

        private async void hotKey1Touch(object sender, TouchEventArgs e)
        {
            hotKey1KillTouch = true;
            while (hotKey1KillTouch)
            {

                if (sendKeyMode == false)
                {
                    //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    pressKey(Properties.Settings.Default.hotKey1Button);

                }

                else
                {
                    pressKeySendKeyMode(Properties.Settings.Default.hotKey1Button);
                }
                await Task.Delay(400);
            }
        }
        private void hotKey1TouchRelease(object sender, TouchEventArgs e)
        {
            hotKey1KillTouch = false;
            if (sendKeyMode == false)
            {
                //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                releaseKey(Properties.Settings.Default.hotKey1Button);
            }
        }

        private async void hotKey2Touch(object sender, TouchEventArgs e)
        {
            hotKey2KillTouch = true;
            while (hotKey2KillTouch)
            {

                if (sendKeyMode == false)
                {
                    //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    pressKey(Properties.Settings.Default.hotKey2Button);

                }

                else
                {
                    pressKeySendKeyMode(Properties.Settings.Default.hotKey2Button);
                }
                await Task.Delay(400);
            }
        }
        private void hotKey2TouchRelease(object sender, TouchEventArgs e)
        {
            hotKey2KillTouch = false;
            if (sendKeyMode == false)
            {
                //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                releaseKey(Properties.Settings.Default.hotKey2Button);
            }
        }

        private async void hotKey3Touch(object sender, TouchEventArgs e)
        {
            hotKey3KillTouch = true;
            while (hotKey3KillTouch)
            {

                if (sendKeyMode == false)
                {
                    //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
                    pressKey(Properties.Settings.Default.hotKey3Button);

                }

                else
                {
                    pressKeySendKeyMode(Properties.Settings.Default.hotKey3Button);
                }
                await Task.Delay(400);
            }
        }
        private void hotKey3TouchRelease(object sender, TouchEventArgs e)
        {
            hotKey3KillTouch = false;
            if (sendKeyMode == false)
            {
                //keybd_event((byte)w, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
                releaseKey(Properties.Settings.Default.hotKey3Button);
            }
        }

        private void exitButtonPress(object sender, EventArgs e)
        {
            trayIcon.Dispose();
            options.Close();
            Process.GetCurrentProcess().Kill();
            this.Close();
        }

        private void onMenuTouchDown(object sender, TouchEventArgs e) //this needs fucking with, as it was I had to hold down the menu button on the tab to keep the options window open
        {
            if (options.IsVisible) { options.Hide(); }
            else { options.Show(); }

            //options.Show();
        }


        

        private void onMenuMouseDown(object sender, MouseButtonEventArgs e) //Lets me actually test the damn thing.
        {
            if (options.IsVisible) { options.Hide(); }
            else { options.Show(); }
         
        }
#endregion

#region debug tools
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            setabxyScale(scaletestSlider.Value / 100);
            setdpadScale(scaletestSlider.Value / 100);
            setCentreScale(scaletestSlider.Value / 100);
            setHotKeyScale(scaletestSlider.Value / 100);
            setLRScale(scaletestSlider.Value / 100);
        }

        private void onMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            System.Drawing.Point point = System.Windows.Forms.Control.MousePosition;
            mouseXLabel.Content = "mouseX "+point.X;
            mouseYLabel.Content = "mouseY "+point.Y;
        }

        private void onTouchMove(object sender, TouchEventArgs e)
        {
            System.Windows.Input.TouchPoint touch = e.GetTouchPoint(this.grid);
            touchXLabel.Content = "touchX " + touch.Position.X;
            touchYLabel.Content = "touchY " + touch.Position.Y;
        }
   
        private void scaleSliderOpacityToggle(object sender, TouchEventArgs e)
        {
            if (scaletestSlider.IsVisible)
            {
                scaletestSlider.Visibility = Visibility.Collapsed;
                scaleLabel.Visibility = Visibility.Collapsed;
            }

            else
            {
                scaletestSlider.Visibility = Visibility.Visible;
                scaleLabel.Visibility = Visibility.Visible;
            }

            if (fullscreenToggleButton.IsVisible)
            { fullscreenToggleButton.Visibility = Visibility.Collapsed; }
            else
            { fullscreenToggleButton.Visibility = Visibility.Visible; }
        }
        #endregion

#region other Buttons
        private void onMenuToggle(object sender, MouseButtonEventArgs e) //this can easily be made smaller as more efficient.
        {
            /*
            if (menuKeyCanvas.IsVisible)
            {
                menuKeyCanvas.Visibility = Visibility.Collapsed;
                
            }

            else
            {
                menuKeyCanvas.Visibility = Visibility.Visible;
            }*/
            
            if (scaletestSlider.IsVisible)
                    {
                        scaletestSlider.Visibility = Visibility.Collapsed;
                        scaleLabel.Visibility = Visibility.Collapsed;
                    }

            else
                    {
                        scaletestSlider.Visibility = Visibility.Visible;
                        scaleLabel.Visibility = Visibility.Visible;
                    }

           if (fullscreenToggleButton.IsVisible)
            {
                fullscreenToggleButton.Visibility = Visibility.Collapsed; 
            }

           else
            {
                fullscreenToggleButton.Visibility = Visibility.Visible; 
            }

            if (opacitySlider.IsVisible)
            {
                opacitySlider.Visibility = Visibility.Collapsed;
                opacityLabel.Visibility = Visibility.Collapsed;
            }

            else
            {
                opacitySlider.Visibility = Visibility.Visible;
                opacityLabel.Visibility = Visibility.Visible;
            }

            if (sendKeyToggleButton.IsVisible)
            {
                sendKeyToggleButton.Visibility = Visibility.Collapsed;
            }

            else
            {
                sendKeyToggleButton.Visibility = Visibility.Visible;
            }

            if (exitButton.IsVisible && exitButton2.IsVisible)
            {
                exitButton.Visibility = Visibility.Collapsed;
                exitButton2.Visibility = Visibility.Collapsed;
            }
            else
            {
                exitButton.Visibility = Visibility.Visible;
                exitButton2.Visibility = Visibility.Visible;
            }

            if (escapeButton.IsVisible)
            {
                escapeButton.Visibility = Visibility.Collapsed;
            }

            else
            {
                escapeButton.Visibility = Visibility.Visible;
            }

            if (toggleHotkeysButton.IsVisible)
            {
                toggleHotkeysButton.Visibility = Visibility.Collapsed;
            }

            else
            {
                toggleHotkeysButton.Visibility = Visibility.Visible;
            }
        }
            
        private void onToggleHotkeys(object sender, MouseButtonEventArgs e)
        {
            if (hotKeyCanvas.IsVisible)
            {
                hotKeyCanvas.Visibility = Visibility.Collapsed;
            }

            else hotKeyCanvas.Visibility = Visibility.Visible;
        }

        private void fullscreenToggle(object sender, TouchEventArgs e) //Ehy are there two methods that do the same thing? Ian, If there are ever two methods that do the same thing, think touch/mouse I test on pc too.
        {
            SendKeys.SendWait("%{ENTER}");
        }

        private void opacitySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {    
            double opVal = Math.Round(opacitySlider.Value) / 100; //Cleaning up the output and getting it ready for putting it in settings
            //opVal = opacitySlider.Value;
            Properties.Settings.Default.buttonOpacity = opVal;
            setKeyOpacity(opVal);
        }

        private void toggleSendKeyMode(object sender, TouchEventArgs e)
        {
            if (sendKeyMode == false)
            {
                sendKeyMode = true;
                System.Windows.Forms.MessageBox.Show("SendKey Mode is now Enabled!");
            }
            else
            {
                sendKeyMode = false;
                System.Windows.Forms.MessageBox.Show("SendKey Mode is now Disabled!");
            }    
        }

        private void toggleSendKeyMode(object sender, MouseButtonEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
            if (sendKeyMode == false)
            {
                sendKeyMode = true;
                System.Windows.Forms.MessageBox.Show("SendKey Mode is now Enabled!");
            }

            else
            {
                sendKeyMode = false;
                System.Windows.Forms.MessageBox.Show("SendKey Mode is now Disabled!");
            } 
        }

        private void escapeKey(object sender, TouchEventArgs e)
        {
            keybd_event((byte)VK_ESCAPE, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); 
        }

        private async void exitKey(object sender, TouchEventArgs e)
        {
            exit1Touch = true;

            if (exit1Touch && exit2Touch)
            {
                trayIcon.Dispose();
                options.Close();
                Process.GetCurrentProcess().Kill();
                SendKeys.SendWait("{ESC}");
                SendKeys.SendWait("%{F4}");
                this.Close();
            }
            
            await Task.Delay(400);
        }

       

        private void exitKeyRelease(object sender, TouchEventArgs e)
        {
            exit1Touch = false;
        }

        private async void exitKey2(object sender, TouchEventArgs e)
        {
            exit2Touch = true;
            if (exit1Touch && exit2Touch)
            {
                trayIcon.Dispose();
                options.Close();
                Process.GetCurrentProcess().Kill();
                SendKeys.SendWait("{ESC}");
                SendKeys.SendWait("%{F4}");
                
                
                this.Close();
            }
            await Task.Delay(400);
        }

        private void exitKey2Release(object sender, TouchEventArgs e)
        {
            exit2Touch = false;
        }
        #endregion

        

        
    }
}
