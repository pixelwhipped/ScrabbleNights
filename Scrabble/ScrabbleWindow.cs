using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Scrabble.GameComponents;
using Scrabble.Properties;

namespace Scrabble
{
    
    public partial class ScrabbleWindow : Form
    {
        public Point Mouse { get { return PointToClient(MousePosition); } }
        public readonly Scrabble Scrabble;
        public Game Game { get { return Scrabble.ActiveGame; } set { Scrabble.ActiveGame = value; }
        }
        
        private Rules _rules;
        private AboutBox _about;
        private Options _options;
        private BoardComponent _scrabbleBoard;

        private readonly List<PlayerComponet> _playerComponents = new List<PlayerComponet>();

        public FormState _windowState;
        public ScrabbleWindow()
        {
        }

        public ScrabbleWindow(Scrabble scrabble): this()
        {
            Scrabble = scrabble;
            InitializeComponent();            
            InitializeCustomComponent();            
        }

        private void InitializeCustomComponent()
        {
            _rules = new Rules();
            _about = new AboutBox();
            _options = new Options(Scrabble);
            _scrabbleBoard = new BoardComponent(Scrabble)
            {
                Location = new Point(ClientSize.Width - (Common.BoardWidthPx + Common.BoardPaddingPx), Height - (Common.BoardHeightPx + Common.BoardPaddingPx + Menu.Bottom)),
                Name = @"Scabble Board",
                Size = new Size(Common.BoardWidthPx, Common.BoardHeightPx),
                TabIndex = 1
            };
            Controls.Add(_scrabbleBoard);
            HighScoreName.Text = Scrabble.Settings.HighScoreName;
            HighScoreValue.Text = Scrabble.Settings.HighScoreValue.ToString();
            _windowState = new FormState();
            if (Scrabble.Settings.Fullscreen)
            {
                _windowState.Maximize(this);
            }
            else
            {
                _windowState.Restore(this);
            }
            
            
        }       
        
        public new void Update()
        {
            base.Update();
        }

        protected override void OnClosing(CancelEventArgs e)
        {                       
            _rules.Hide();
            _about.Hide();
            _rules.Dispose();
            _about.Dispose();
            base.OnClosing(e);
        }

        private void RulesMenuItemClick(object sender, EventArgs e)
        {
            _rules.Show();
        }

        public void ExitMenuItemClick(object sender, EventArgs e)
        {
            Dispose(true);
        }

        private void AboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            _about.Show();
        }

        private void OptionsMenuItemClick(object sender, EventArgs e)
        {
            _options.Show();
        }

        private void ValidateKey()
        {
            if (!Licensing.Licence.ValidateKey(Scrabble.Settings.Serial, Scrabble.PrivateKey))
            {
                var reg = new Register();
               var rresult = reg.ShowDialog(this);
                switch (rresult)
                {
                    case DialogResult.OK:
                        {
                            if (!Licensing.Licence.ValidateKey(reg.RegCode.Text, Scrabble.PrivateKey))
                            {
                                var dr = MessageBox.Show(Resources.LicensingInvalidKeyTryAgain, Resources.LicensingInvalidKey, MessageBoxButtons.YesNo);
                                switch (dr)
                                {
                                    case DialogResult.Yes:
                                        {
                                            ValidateKey();
                                            break;
                                        }
                                    case DialogResult.No:
                                        {
                                            Application.Exit();
                                            this.Visible = false;
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                Scrabble.Settings.Serial = reg.RegCode.Text;
                                Scrabble.Settings.Save();
                            }
                            break;
                        }
                    default:
                        {
                            Application.Exit();
                            break;
                        }
                }
            }
        }
        
        private void NewGameMenuItemClick(object sender, EventArgs e)
        {
            //ValidateKey(); Disabled as is now free.
            var newGame = new NewGame(Scrabble);
            var result = newGame.ShowDialog(this);
            switch (result)
            {
                case DialogResult.OK:
                    {
                        EndGameToolStripMenuItemClick(sender,e);
                        var players = new List<Player>
                                          {
                                              Player.ConstructPlayer(newGame.Player1NameTextBox.Text,
                                                                     newGame.Player1IsHumanCheckBox.Checked),
                                              Player.ConstructPlayer(newGame.Player2NameTextBox.Text,
                                                                     newGame.Player2IsHumanCheckBox.Checked)
                                              
                                          };
                        if(newGame.Player3EnabledCheckBox.Checked)
                        {
                            players.Add(Player.ConstructPlayer(newGame.Player3NameTextBox.Text,
                                                                     newGame.Player3IsHumanCheckBox.Checked));
                        }
                        if (newGame.Player4EnabledCheckBox.Checked)
                        {
                            players.Add(Player.ConstructPlayer(newGame.Player4NameTextBox.Text,
                                                                     newGame.Player4IsHumanCheckBox.Checked));
                        }
                        Game = new Game(Scrabble, players.ToArray());
                        StartGame();
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        break;
                    }
                default:
                    {
                        throw new InvalidOperationException();
                    }
            }
        }

        private void SaveGameMenuItemClick(object sender, EventArgs e)
        {
            if (Game == null) return;
            var save = new SaveFileDialog
                           {
                               InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments),
                               Filter = Resources.SaveGameFilter + @" (*.SAV)|*.sav",
                               FilterIndex = 1,
                               FileName =
                                   Game.Players[0].Name + @" Vs " + Game.Players[1].Name + DateTime.Now.ToString(" MMM d yyyy")
                           };
            if (save.ShowDialog() != DialogResult.OK) return;
            var gd = Game.GameData;
            Utilities.SerializeObject(gd, save.FileName);
        }

        private void OpenGameMenuItemClick(object sender, EventArgs e)
        {
            EndGameToolStripMenuItemClick(sender, e);
            var open = new OpenFileDialog
            {
                InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments),
                Filter = Resources.SaveGameFilter + @" (*.SAV)|*.sav",
                FilterIndex = 1
            };
            if (open.ShowDialog() != DialogResult.OK) return;
            GameData data;
            Utilities.DeserializeObject(open.FileName, out data);
            Game = new Game(Scrabble,data);
            StartGame();
        }

        public void StartGame()
        {
            if (Game == null) return;
            endGameToolStripMenuItem.Enabled = true;
            SaveGameMenuItem.Enabled = true;
            ExchangeButton.Enabled = true;
            ShuffleButton.Enabled = true;
            PassButton.Enabled = true;
            HintButton.Enabled = true;

            for (var x = 0; x < Game.Players.Length; x++)
            {
                var p = new PlayerComponet(Scrabble, Game.Players[x])
                            {
                                Location = new Point(24, ((x + 1)*100)+100),
                                Size = new Size(7*Common.TileSizePx, 100)
                            };
                _playerComponents.Add(p);
                Controls.Add(p);
            }           
            Game.StartGame();            
        }

        private void EndGameToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (Game != null)
            {
                var result = MessageBox.Show(this, Resources.SaveGameText, Resources.SaveGameCaption, MessageBoxButtons.YesNoCancel,
                                        MessageBoxIcon.Question);
                switch (result)
                {
                    case DialogResult.Yes:
                        {
                            SaveGameMenuItemClick(sender,e);
                            break;
                        }
                    case DialogResult.No:
                        {
                            break;
                        }
                    case DialogResult.Cancel:
                        {
                            return;
                        }
                    default:
                        {
                            throw new InvalidOperationException();
                        }
                }
                endGameToolStripMenuItem.Enabled = false;
                SaveGameMenuItem.Enabled = false;
                ExchangeButton.Enabled = false;
                ShuffleButton.Enabled = false;
                PassButton.Enabled = false;
                foreach(var p in _playerComponents)
                {
                    Controls.Remove(p);
                }
                _playerComponents.Clear();
            }
            Game = null;
        }

        private void PassButtonClick(object sender, EventArgs e)
        {
            Game.EndTurn(EndOfTurn.Pass);
        }

        private void ExchangeButtonClick(object sender, EventArgs e)
        {
            Game.EndTurn(EndOfTurn.Exchange);
        }

        private void ShuffleButtonClick(object sender, EventArgs e)
        {
            Game.PlayerShuffleTiles();
            RefreshComponents();
        }

        public void ShowEndGame()
        {
            var p = Game.Winner;
            if(Game.Winner.Score >= Settings.Default.HighScoreValue)
            {
                Scrabble.Settings.HighScoreName = Game.Winner.Name;
                Scrabble.Settings.HighScoreValue = Game.Winner.Score;
                HighScoreName.Text = Game.Winner.Name;
                HighScoreValue.Text = Game.Winner.Score.ToString();
                Scrabble.Settings.Save();
            }
            var result = MessageBox.Show(this, p.Name + Common.SpaceString + Resources.WinningScore + Common.SpaceString + p.Score + Common.CommaString + Common.SpaceString + Resources.PlayAgain, Resources.Congradulations+ Common.SpaceString + p.Name, MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question);

            switch (result)
            {
                case DialogResult.Yes:
                    {
                        var players = new List<Player>();                
                        endGameToolStripMenuItem.Enabled = false;
                        SaveGameMenuItem.Enabled = false;
                        ExchangeButton.Enabled = false;
                        ShuffleButton.Enabled = false;
                        PassButton.Enabled = false;
                        foreach (var px in _playerComponents)
                        {
                            players.Add(Player.ConstructPlayer(px.Player.Name,
                                                               px.Player.PlayerType == PlayerType.Human));                                                        
                            Controls.Remove(px);
                        }
                        _playerComponents.Clear();
                        Game = new Game(Scrabble, players.ToArray());
                        StartGame();                       
                        break;
                    }
                case DialogResult.No:
                    {
                        endGameToolStripMenuItem.Enabled = false;
                        SaveGameMenuItem.Enabled = false;
                        ExchangeButton.Enabled = false;
                        ShuffleButton.Enabled = false;
                        PassButton.Enabled = false;
                        foreach (var px in _playerComponents)
                        {
                            Controls.Remove(px);
                        }
                        _playerComponents.Clear();
                        Game = null;
                        break;
                    }               
                default:
                    {
                        throw new InvalidOperationException();
                    }
            }
        }

        public void RefreshComponents()
        {
            
            if (Game != null || !IsDisposed)
            {
                foreach (var p in _playerComponents)
                {
                    p.Refresh();
                }
                _scrabbleBoard.Refresh();
                if (Game != null) TileCount.Text = Game.Tiles.TilePeices.Count.ToString();
            }
            Refresh();
        }       

        public void EnableButtons()
        {
            PassButton.Enabled = true;
            ExchangeButton.Enabled = true;
            ShuffleButton.Enabled = true;
            HintButton.Enabled = true;
        }

        public void DisableButtons()
        {
            PassButton.Enabled = false;
            ExchangeButton.Enabled = false;
            ShuffleButton.Enabled = false;
            HintButton.Enabled = false;
        }

        
        private void HintButtonClick(object sender, EventArgs e)
        {
            Game.HintCount++;
            if(Game.HintCount == 2)
                HintButton.Enabled = false;
            ResetHints();
        }

    }
}
