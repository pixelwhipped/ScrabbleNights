using System;
using System.Drawing;
using System.Windows.Forms;

namespace Scrabble.GameComponents
{
    public sealed class PlayerComponet: GameComponent
    {
        public Player Player;

        private static readonly Brush Fill = new SolidBrush(Color.FromArgb(64,255,255,255));

        public PlayerComponet(Scrabble scrabble, Player player)
            : base(scrabble)
        {
            Player = player;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            InitializeComponent();
        }
        
        protected override void OnPaint(PaintEventArgs pe)
        {
            var g = pe.Graphics;
            if(Scrabble.ActiveGame!=null&&Scrabble.ActiveGame.CurrentPlayer==Player)
            {
                g.FillRectangle(Fill,0,0,Width,Height);
            }
            DrawName(g);
            DrawScore(g);
            DrawTiles(g);
            base.OnPaint(pe);
        }

        protected override void OnClick(EventArgs e)
        {
            if (Player.PlayerType == PlayerType.Computer) return;
            for (var i = 0; i < Player.TilePeices.Count; i++)
            {
                var r = new Rectangle(i*Common.TileSizePx,
                                      Player.Placement.SelectedTiles.Contains(Player.TilePeices[i])
                                          ? Height - (int)(Common.TileSizePx*1.5f)
                                          : Height - Common.TileSizePx, Common.TileSizePx, Common.TileSizePx);
                if (!r.Contains(Mouse)) continue;
                if (Player.Placement.SelectedTiles.Contains(Player.TilePeices[i]))
                {
                    var p = Player.TilePeices[i];
                    Player.Placement.SelectedTiles.Remove(p);
                    Player.TilePeices.Remove(p);
                    Player.TilePeices.Add(p);
                }
                else
                {
                    var p = Player.TilePeices[i];
                    Player.Placement.SelectedTiles.Add(p);
                    Player.TilePeices.Remove(p);
                    Player.TilePeices.Insert(Player.Placement.SelectedTiles.Count - 1, p);
                }
            }
            base.OnClick(e);
        }

        private void DrawScore(Graphics g)
        {
            g.DrawString("Score: "+ Player.Score, Common.FontTileLetter, Common.BrushTileLetter, 0f, 42f);
        }

        private void DrawName(Graphics g)
        {
            Utilities.DrawGameFont(g, Player.Name, new Point(0, 0), 42, -15);
        }

        private void DrawTiles(Graphics g)
        {
            for (var i = 0; i < Player.TilePeices.Count; i++)
            {
                var r = new Rectangle(i * Common.TileSizePx, Player.Placement.SelectedTiles.Contains(Player.TilePeices[i]) ?  Height - (int)(Common.TileSizePx*1.5f)
                                          : Height - Common.TileSizePx, Common.TileSizePx, Common.TileSizePx);
                Utilities.DrawPlacementTile(g, Player.TilePeices[i], r.X, r.Y, Common.BrushTileLetterTranslucent);
                if (r.Contains(Mouse.X, Mouse.Y))
                    g.FillRectangle(new SolidBrush(Color.FromArgb(128, 255, 255, 255)), r);
            }
            var p = new Pen(Color.Black, 2);
            g.DrawRectangle(p, new Rectangle((int)(p.Width / 2f), (int)(p.Width / 2f), Width - (int)(p.Width), Height - (int)(p.Width)));

        }

        private void InitializeComponent()
        {
            SuspendLayout();
            MaximumSize = new Size(7*Common.TileSizePx, 100);
            MinimumSize = new Size(7 * Common.TileSizePx, 100);
            Size = new Size(7 * Common.TileSizePx, 100);
            ResumeLayout(false);

        }
    }
}
