﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gauss_Jordan_Solution
{
    /// <summary>
    /// Interaction logic for UserControlDescription.xaml
    /// </summary>
    public partial class UserControlDescription : UserControl
    {
        public UserControlDescription()
        {
            InitializeComponent();
        }
        private void ButtonExampleOfMethod_Click(object sender, RoutedEventArgs e)
        {
            ButtonExampleOfMethod.Visibility = Visibility.Visible;
            Example2.Visibility = Example2.IsVisible ? Visibility.Hidden : Visibility.Visible;
        }
    }
}
