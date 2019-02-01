using System.Diagnostics;
using System.Windows.Forms;

namespace Scrabble
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://badkiddevelopment.blogspot.com/p/scrabble-nights.html");
        }
    }
}
