using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gauss_Jordan_Solution.CustomerItems
{
    public partial class ApplicationMessageBox : Form
    {
        public ApplicationMessageBox()
        {
            InitializeComponent();
        }

        private void ApplicationMessageBox_Load(object sender, EventArgs e)
        {

        }

        static ApplicationMessageBox AppMessageBox;
        static DialogResult result = DialogResult.No;

        public static DialogResult Show(string Text, string Caption, string buttonOK)
        {
           
            AppMessageBox = new ApplicationMessageBox();
            AppMessageBox.label.Text = Text;
            AppMessageBox.button.Text = buttonOK;
            AppMessageBox.Text = Caption;
 
            AppMessageBox.ShowDialog();
            return result;


        }
        private void button_Click(object sender, EventArgs e)
        {
            result = DialogResult.OK;
            AppMessageBox.Close();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
