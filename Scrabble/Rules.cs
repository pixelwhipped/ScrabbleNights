using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Scrabble
{
    public partial class Rules : Form
    {
        public Rules()
        {
            InitializeComponent();
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream("Scrabble.Rules.htm");
            if (stream == null)
            {
                throw new IOException("Cannot find mappings file. Internal: Rules");
            }
            RulesBrowser.DocumentStream = stream;          
        }

        private void RulesFormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
