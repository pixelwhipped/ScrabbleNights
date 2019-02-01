using System;
using System.Windows.Forms;

namespace Scrabble
{
    public partial class Options : Form
    {

        public readonly Scrabble Scrabble;
        public Game Game { get { return Scrabble.ActiveGame; } }

        public Options()
        {
            InitializeComponent();
        }

        public Options(Scrabble scrabble)
            : this()
        {
            Scrabble = scrabble;
            InitializeCustomComponent();
        }

        private void InitializeCustomComponent()
        {
           DifficultyTrackBar.Value = Scrabble.Settings.Difficulty;
           Player1DefaultTextBox.Text = Scrabble.Settings.DefaultPlayer1;
           Player2DefaultTextBox.Text = Scrabble.Settings.DefaultPlayer2;
           Player3DefaultTextBox.Text = Scrabble.Settings.DefaultPlayer3;
           Player4DefaultTextBox.Text = Scrabble.Settings.DefaultPlayer4;
           EnableSoundCheckBox.Checked = Scrabble.Settings.EnableMusic;
           AllowBlanksCheckBox.Checked = Scrabble.Settings.ReuseBlank;
           FullScreenCheckBox.Checked = Scrabble.Settings.Fullscreen;

        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            Scrabble.Settings.Save();
            if (Scrabble.Settings.Fullscreen)
            {
                Scrabble.ActiveWindow._windowState.Maximize(Scrabble.ActiveWindow);
            }else
            {
                Scrabble.ActiveWindow._windowState.Restore(Scrabble.ActiveWindow);
            }
            Hide();
        }

        private void OptionsFormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void EnableMusicCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            if (EnableSoundCheckBox.Checked)
            {
                Scrabble.Settings.EnableMusic = true;
                Scrabble.BackgroundMusic.PlayLooping();
            }
            else
            {
                Scrabble.Settings.EnableMusic = false;
                Scrabble.BackgroundMusic.Stop();
            }
        }

        private void Player1DefaultTextBoxTextChanged(object sender, EventArgs e)
        {
            Scrabble.Settings.DefaultPlayer1 = Player1DefaultTextBox.Text;
        }

        private void Player2DefaultTextBoxTextChanged(object sender, EventArgs e)
        {
            Scrabble.Settings.DefaultPlayer2 = Player2DefaultTextBox.Text;
        }

        private void Player3DefaultTextBoxTextChanged(object sender, EventArgs e)
        {
            Scrabble.Settings.DefaultPlayer3 = Player3DefaultTextBox.Text;
        }

        private void Player4DefaultTextBoxTextChanged(object sender, EventArgs e)
        {
            Scrabble.Settings.DefaultPlayer4 = Player4DefaultTextBox.Text;
        }

        private void AllowBlanksCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Scrabble.Settings.ReuseBlank = AllowBlanksCheckBox.Checked;
        }

        private void FullScreenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Scrabble.Settings.Fullscreen = FullScreenCheckBox.Checked;
        }
    }
}
