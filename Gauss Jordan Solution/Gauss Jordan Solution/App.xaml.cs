using Gauss_Jordan_Solution.CustomerItems;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Gauss_Jordan_Solution
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {

           
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            this.Dispatcher.UnhandledException += OnDispatcherUnhandledException;
        }
        void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            string exceptionMessage = string.Format("A handled exception occurred: {0}", e.Exception.Message);
            ApplicationMessageBox.Show(exceptionMessage, "Checkbox Selection Exception", "OK");
           
            e.Handled = true;
        }
    }
}

//Startup="Application_Startup"
//DispatcherUnhandledException="OnDispatcherUnhandledException">