using System;
using System.Windows.Forms;

namespace Scrabble
{
    public partial class NewGame : Form
    {
        public readonly Scrabble Scrabble;
        public Game Game { get { return Scrabble.ActiveGame; } }

        public NewGame()
        {
            InitializeComponent();
            
        }

        public NewGame(Scrabble scrabble)
            : this()
        {
            Scrabble = scrabble;
            Player1NameTextBox.Text = Scrabble.Settings.DefaultPlayer1;
            Player2NameTextBox.Text = Scrabble.GetRandomName();
            Player3NameTextBox.Text = Scrabble.GetRandomName();
            Player4NameTextBox.Text = Scrabble.GetRandomName();            
        }

        private void Player1IsHumanCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            if (Player1IsHumanCheckBox.Checked)
            {
                Player1NameTextBox.Enabled = true;
                RememberPlayer1CheckBox.Enabled = true;
                Player1NameTextBox.Text = Scrabble.Settings.DefaultPlayer1;
                return;
            }
            Player1NameTextBox.Enabled = false;
            RememberPlayer1CheckBox.Enabled = false;
            RememberPlayer1CheckBox.Checked = false;
            Player1NameTextBox.Text = Scrabble.GetRandomName();
        }

        private void Player2IsHumanCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            if (Player2IsHumanCheckBox.Checked)
            {
                Player2NameTextBox.Enabled = true;
                RememberPlayer2CheckBox.Enabled = true;
                Player2NameTextBox.Text = Scrabble.Settings.DefaultPlayer2;
                return;
            }
            Player2NameTextBox.Enabled = false;
            RememberPlayer2CheckBox.Enabled = false;
            RememberPlayer2CheckBox.Checked = false;
            Player2NameTextBox.Text = Scrabble.GetRandomName();
        }

        private void Player3IsHumanCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            if (Player3IsHumanCheckBox.Checked)
            {
                Player3NameTextBox.Enabled = true;
                RememberPlayer3CheckBox.Enabled = true;
                Player3NameTextBox.Text = Scrabble.Settings.DefaultPlayer3;
                return;
            }
            Player3NameTextBox.Enabled = false;
            RememberPlayer3CheckBox.Enabled = false;
            RememberPlayer3CheckBox.Checked = false;
            Player3NameTextBox.Text = Scrabble.GetRandomName();
        }

        private void Player4IsHumanCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            if (Player4IsHumanCheckBox.Checked)
            {
                Player4NameTextBox.Enabled = true;
                RememberPlayer4CheckBox.Enabled = true;
                Player4NameTextBox.Text = Scrabble.Settings.DefaultPlayer4;
                return;
            }
            Player4NameTextBox.Enabled = false;
            RememberPlayer4CheckBox.Enabled = false;
            RememberPlayer4CheckBox.Checked = false;
            Player4NameTextBox.Text = Scrabble.GetRandomName();
        }

        private void CancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Hide();
        }

        private void BeginClick(object sender, EventArgs e)
        {
            Scrabble.Settings.DefaultPlayer1 = RememberPlayer1CheckBox.Checked
                                                   ? Player1NameTextBox.Text
                                                   : Scrabble.Settings.DefaultPlayer1;
            Scrabble.Settings.DefaultPlayer2 = RememberPlayer2CheckBox.Checked
                                                   ? Player2NameTextBox.Text
                                                   : Scrabble.Settings.DefaultPlayer2;
            Scrabble.Settings.DefaultPlayer3 = RememberPlayer3CheckBox.Checked
                                                   ? Player3NameTextBox.Text
                                                   : Scrabble.Settings.DefaultPlayer3;
            Scrabble.Settings.DefaultPlayer4 = RememberPlayer4CheckBox.Checked
                                                   ? Player4NameTextBox.Text
                                                   : Scrabble.Settings.DefaultPlayer4;
            Scrabble.Settings.Save();
            DialogResult = DialogResult.OK;
            Hide();
        }

    }
}
