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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gauss_Jordan_Solution
{
    /// <summary>
    /// Interaction logic for UserControlInstruction.xaml
    /// </summary>
    public partial class UserControlInstruction : UserControl
    {
        public UserControlInstruction()
        {
            InitializeComponent();
        }
        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            VideoControl.Position = new TimeSpan(0, 0, 0);
        }
    }
}
