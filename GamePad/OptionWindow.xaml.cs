using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GamePad
{
    /// <summary>
    /// Interaction logic for OptionWindow.xaml
    /// </summary>
    /// 


    public partial class OptionWindow : Window 
    {

        //Make variables for settings
        double opVal;

        public OptionWindow()
        {
            InitializeComponent();

            setFieldValues(); //Set the fields to the previous settings on start

            string[] keyBindings = new string[] { "Left Mouse Key", "Right Mouse Key", "Middle Mouse Key", "X1 Mouse Key", "X2 Mouse Key", "Backspace", "Tab", "Enter", "Shift", "Ctrl", "Alt", "Pause", "Caps Lock", "Esc", "Space", "Page Up", "Page Down", "End", "Home", "Left Arrow", "Up Arrow", "Right Arrow", "Down Arrow", "Insert", "Delete", "Help", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "Left Windows Key", "Right Windows Key", "Application Key", "Sleep", "NUM0", "NUM1", "NUM2", "NUM3", "NUM4", "NUM5", "NUM6", "NUM7", "NUM8", "NUM9", "*", "+", "separator", "-", ".", "/", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12", "Num Lock", "Scroll Lock", "Left Shift", "Right Shift", "Left Ctrl", "Right Ctrl", "Left Alt", "Right Alt", "; or :", "/ or ?", "~", "\\ or |", "[ or {", "] or }", "single/double quote"};

            upButtonAssign.ItemsSource = keyBindings;
            downButtonAssign.ItemsSource = keyBindings;
            leftButtonAssign.ItemsSource = keyBindings;
            rightButtonAssign.ItemsSource = keyBindings;
            aButtonAssign.ItemsSource = keyBindings;
            bButtonAssign.ItemsSource = keyBindings;
            xButtonAssign.ItemsSource = keyBindings;
            yButtonAssign.ItemsSource = keyBindings;
            startButtonAssign.ItemsSource = keyBindings;
            selectButtonAssign.ItemsSource = keyBindings;
            l1ButtonAssign.ItemsSource = keyBindings;
            l2ButtonAssign.ItemsSource = keyBindings;
            r1ButtonAssign.ItemsSource = keyBindings;
            r2ButtonAssign.ItemsSource = keyBindings;
            hotKey1ButtonAssign.ItemsSource = keyBindings;
            hotKey2ButtonAssign.ItemsSource = keyBindings;
            hotKey3ButtonAssign.ItemsSource = keyBindings;

        }
        
        public void setFieldValues() //Sets fields to settings //SET TO PUBLIC TO TEST, ADD IN A GETTER/SETTER LATER
        {
            //Set variables to values in settings (for sliders)
            opVal = Properties.Settings.Default.buttonOpacity;

            //Set every field to the value in settings
            this.opacitySlider.Value = opVal * 100; // Slider goes from 0% - 100% so x100 settings value

            //THIS METHOD OF SETTING FIELDS JUST USED TO WIPE THEM, REPLACING .SELECTEDVALUE WITH .TEXT WORKED (KEEP THIS BLOCK OF CODE FOR A WHILE IN CASE IT IS NEEDED)
            /*
            upButtonAssign.SelectedValue = Properties.Settings.Default.upButton;
            downButtonAssign.SelectedValue = Properties.Settings.Default.downButton;
            leftButtonAssign.SelectedValue = Properties.Settings.Default.leftButton;
            rightButtonAssign.SelectedValue = Properties.Settings.Default.rightButton;
            aButtonAssign.SelectedValue = Properties.Settings.Default.aButton;
            bButtonAssign.SelectedValue = Properties.Settings.Default.bButton;
            xButtonAssign.SelectedValue = Properties.Settings.Default.xButton;
            yButtonAssign.SelectedValue = Properties.Settings.Default.yButton;
            startButtonAssign.SelectedValue = Properties.Settings.Default.startButton;
            selectButtonAssign.SelectedValue = Properties.Settings.Default.selectButton;
            l1ButtonAssign.SelectedValue = Properties.Settings.Default.l1Button;
            l2ButtonAssign.SelectedValue = Properties.Settings.Default.l2Button;
            r1ButtonAssign.SelectedValue = Properties.Settings.Default.r1Button;
            r2ButtonAssign.SelectedValue = Properties.Settings.Default.r2Button;
            hotKey1ButtonAssign.SelectedValue = Properties.Settings.Default.hotKey1Button;
            hotKey2ButtonAssign.SelectedValue = Properties.Settings.Default.hotKey2Button;
            hotKey3ButtonAssign.SelectedValue = Properties.Settings.Default.hotKey3Button;
            */
            upButtonAssign.Text = Properties.Settings.Default.upButton;
            downButtonAssign.Text = Properties.Settings.Default.downButton;
            leftButtonAssign.Text = Properties.Settings.Default.leftButton;
            rightButtonAssign.Text = Properties.Settings.Default.rightButton;
            aButtonAssign.Text = Properties.Settings.Default.aButton;
            bButtonAssign.Text = Properties.Settings.Default.bButton;
            xButtonAssign.Text = Properties.Settings.Default.xButton;
            yButtonAssign.Text = Properties.Settings.Default.yButton;
            startButtonAssign.Text = Properties.Settings.Default.startButton;
            selectButtonAssign.Text = Properties.Settings.Default.selectButton;
            l1ButtonAssign.Text = Properties.Settings.Default.l1Button;
            l2ButtonAssign.Text = Properties.Settings.Default.l2Button;
            r1ButtonAssign.Text = Properties.Settings.Default.r1Button;
            r2ButtonAssign.Text = Properties.Settings.Default.r2Button;
            hotKey1ButtonAssign.Text = Properties.Settings.Default.hotKey1Button;
            hotKey2ButtonAssign.Text = Properties.Settings.Default.hotKey2Button;
            hotKey3ButtonAssign.Text = Properties.Settings.Default.hotKey3Button;
        }

        //opacity is now handled from the main menu
        private void onOpacityValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) //Triggered whenever the slider is moved. Tends to spam events.
        {
            Console.WriteLine("OPACITY CHANGE "+opacitySlider.Value+" "+opVal); //For debug
            opVal = Math.Round(opacitySlider.Value) / 100; //Cleaning up the output and getting it ready for putting it in settings
        }

        private void onOKButtonClick(object sender, RoutedEventArgs e) //Where you would update the settings values
        {

            //Set the new values in settings
            Properties.Settings.Default.buttonOpacity = opVal;

            
            Properties.Settings.Default.downButton = downButtonAssign.Text;
            Properties.Settings.Default.upButton = upButtonAssign.Text;
            Properties.Settings.Default.leftButton = leftButtonAssign.Text;
            Properties.Settings.Default.rightButton = rightButtonAssign.Text;
            Properties.Settings.Default.aButton = aButtonAssign.Text;
            Properties.Settings.Default.bButton = bButtonAssign.Text;
            Properties.Settings.Default.xButton = xButtonAssign.Text;
            Properties.Settings.Default.yButton = yButtonAssign.Text;
            Properties.Settings.Default.startButton = startButtonAssign.Text;
            Properties.Settings.Default.selectButton = selectButtonAssign.Text;
            Properties.Settings.Default.l1Button = l1ButtonAssign.Text;
            Properties.Settings.Default.l2Button = l2ButtonAssign.Text;
            Properties.Settings.Default.r1Button = r1ButtonAssign.Text;
            Properties.Settings.Default.r2Button = r2ButtonAssign.Text;
            Properties.Settings.Default.hotKey1Button = hotKey1ButtonAssign.Text;
            Properties.Settings.Default.hotKey2Button = hotKey2ButtonAssign.Text;
            Properties.Settings.Default.hotKey3Button = hotKey3ButtonAssign.Text;

            //Trigger save
            Properties.Settings.Default.Save(); 
            Properties.Settings.Default.Upgrade();

            //Do whatever. Probably force the main window to update and similar shit, Hides window
            this.Hide();       
        }

        private void onClosing(object sender, System.ComponentModel.CancelEventArgs e) //Stops OptionWindow.Dispose when closing. Hides window instead.
        {
            this.Hide();
            e.Cancel = true;
        }

        private void onCancelButtonClick(object sender, RoutedEventArgs e) //Closes Window, resets values to previous
        {
            
            setFieldValues();
            this.Hide();
        }

       
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

     

        private void upButtonAssign_SelectionChanged(object sender, SelectionChangedEventArgs e) // when user changes value of the combo box, the button is assigned that key, i.e. W is mapped to UpButton
        {
            Properties.Settings.Default.upButton = upButtonAssign.Text;
            Console.WriteLine(Properties.Settings.Default.upButton);
        }

        private void downButtonAssign_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.downButton = downButtonAssign.Text;
            Console.WriteLine(Properties.Settings.Default.downButton);
        }

        private void leftButtonAssign_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.leftButton = leftButtonAssign.Text;
            Console.WriteLine(Properties.Settings.Default.leftButton);
        }

        private void rightButtonAssign_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.rightButton = rightButtonAssign.Text;
            Console.WriteLine(Properties.Settings.Default.rightButton);
        }

        private void aButtonAssign_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.aButton = aButtonAssign.Text;
            Console.WriteLine(Properties.Settings.Default.aButton);
        }

        private void bButtonAssign_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.bButton = bButtonAssign.Text;
            Console.WriteLine(Properties.Settings.Default.bButton);
        }

        private void xButtonAssign_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.xButton = xButtonAssign.Text;
            Console.WriteLine(Properties.Settings.Default.xButton);
        }

        private void yButtonAssign_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.yButton = yButtonAssign.Text;
            Console.WriteLine(Properties.Settings.Default.yButton);
        }

        private void l1ButtonAssign_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.l1Button = l1ButtonAssign.Text;
            Console.WriteLine(Properties.Settings.Default.l1Button);
        }

        private void l2ButtonAssign_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.l2Button= l2ButtonAssign.Text;
            Console.WriteLine(Properties.Settings.Default.l2Button);
        }

        private void r1ButtonAssign_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.r1Button = r1ButtonAssign.Text;
            Console.WriteLine(Properties.Settings.Default.r1Button);
        }

        private void r2ButtonAssign_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.r2Button = r2ButtonAssign.Text;
            Console.WriteLine(Properties.Settings.Default.r2Button);
        }

        private void startButtonAssign_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.startButton = startButtonAssign.Text;
            Console.WriteLine(Properties.Settings.Default.startButton);
        }

        private void selectButtonAssign_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.selectButton = selectButtonAssign.Text;
            Console.WriteLine(Properties.Settings.Default.selectButton);
        }

        private void toggleOpacity_Click(object sender, RoutedEventArgs e)
        {
            
            //MainWindow.scaletestSlider.Visibility = Visibility.Collapsed;
        }

        private void hotKey1ButtonAssign_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.hotKey1Button = hotKey1ButtonAssign.Text;
            Console.WriteLine(Properties.Settings.Default.hotKey1Button);
        }

        private void hotKey2ButtonAssign_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.hotKey1Button = hotKey2ButtonAssign.Text;
            Console.WriteLine(Properties.Settings.Default.hotKey2Button);

        }

        private void hotKey3ButtonAssign_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.hotKey1Button = hotKey3ButtonAssign.Text;
            Console.WriteLine(Properties.Settings.Default.hotKey3Button);
        }
    }
}
