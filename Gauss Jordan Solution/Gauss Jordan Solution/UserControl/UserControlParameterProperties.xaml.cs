using Gauss_Jordan_Solution.GUIException;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Gauss_Jordan_Solution.CustomerItems;
using System.Windows.Controls.Primitives;

namespace Gauss_Jordan_Solution
{
    /// <summary>
    /// Interaction logic for UserControlParameterProperties.xaml
    /// </summary>
    public partial class UserControlParameterProperties : UserControl
    {
        private bool dragStarted = false;
        public UserControlParameterProperties()
        {
            InitializeComponent();

        }
        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            VideoControl.Position = new TimeSpan(0, 0, 0);
        }

        private void CheckBox_CChecked(object sender, RoutedEventArgs e)
        {
            
                ParameterProperties.Instance.ProgrammingLanguages["C++"] = true; 
        }
        private void CheckBox_CUnchecked(object sender, RoutedEventArgs e)
        {
            
                ParameterProperties.Instance.ProgrammingLanguages["C++"] = false;
            try
            {
                if (ASM.IsChecked == false)
                    throw (new CheckBoxException("No checkbox was selected."));
            }
            catch (CheckBoxException ex)
            {
                string exceptionMessage = string.Format("A handled exception occurred: {0}", ex.Message);
                ApplicationMessageBox.Show(exceptionMessage, "Checkbox Selection Exception", "OK");
            }
        }
        private void CheckBox_ASMChecked(object sender, RoutedEventArgs e)
        {
            ParameterProperties.Instance.ProgrammingLanguages["ASM"] = true;
        }
        private void CheckBox_ASMUnchecked(object sender, RoutedEventArgs e)
        {

            ParameterProperties.Instance.ProgrammingLanguages["ASM"] = false;
            try
            {
                if (C.IsChecked == false)
                    throw (new CheckBoxException("No checkbox was selected."));
            }
            catch (CheckBoxException ex)
            {
                string exceptionMessage = string.Format("A handled exception occurred: {0}", ex.Message);
                ApplicationMessageBox.Show(exceptionMessage, "Checkbox Selection Exception", "OK");
            }
       
        }

        private void TextBox_EnteredInputFileName(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    StreamReader fileReader = new StreamReader(file.Text);
                    ParameterProperties.Instance.inFileName = file.Text;
                }
            }

            catch (IOException ex)
            {

                string exceptionMessage = string.Format("A handled exception occurred: {0}", ex.Message);
                ApplicationMessageBox.Show(exceptionMessage, "Input File Exception", "OK");
                //MessageBox.Show(exceptionMessage, "File wasn't found", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void ButtonBrowseFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            try
            {
                if (openFileDialog.ShowDialog() == true)
                {
                    file.Text = openFileDialog.FileName;
                    ParameterProperties.Instance.inFileName= openFileDialog.FileName; 
                }
                else
                    throw (new IOException("File wasn't found"));
            }
            catch (IOException ex)
            {
                string exceptionMessage = string.Format("An unhandled exception occurred: {0}", ex.Message);
                MessageBox.Show(exceptionMessage, "File wasn't found", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
 
        private void Slider_ThreadsNumberChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            if (!dragStarted)
            {
                if (threadsNumber.Tag.Equals("setThreadsNrToProccessorCoresNr"))
                {
                    threadsNumber.Value = int.Parse(System.Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS"));
                    ParameterProperties.Instance.threadsNumber = (int)threadsNumber.Value;
                    threadsNumber.Tag = "setThreadsNrToSliderValue";
                }
            }

        }
        private void Slider_DragCompleted(object sender, DragCompletedEventArgs e)
        {

            threadsNumber.Value = int.Parse(TextBoxValue.Text);
            ParameterProperties.Instance.threadsNumber = (int)threadsNumber.Value;
            this.dragStarted = false;
        }

        private void Slider_DragStarted(object sender, DragStartedEventArgs e)
        {
            this.dragStarted = true;
        }
    }
}


//public static readonly DependencyProperty ValueProperty =
//    DependencyProperty.Register("Value", typeof(object),
//      typeof(UserControlParameterProperties), new PropertyMetadata(null));
