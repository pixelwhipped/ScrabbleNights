using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Scrabble.GameComponents
{
    public class BoardComponent : GameComponent
    {
        public readonly GraphicsPath Star;

        private float _rotator;
        private Tween<double> _fader;
        private readonly TimeSpan _fadeRate = new TimeSpan(15L);
        private readonly TimeSpan _fadeTime = new TimeSpan(100L);
        private Tween<double> _hinter;
        private readonly TimeSpan _hintFadeRate = new TimeSpan(15L);
        private readonly TimeSpan __hintFadeTime = new TimeSpan(100L);   

        private readonly Matrix _rotatorMatrix = new Matrix();

        public BoardComponent(Scrabble scrabble) : base(scrabble)
        {
            #region Create Star

            _fader = new Tween<double>(_fadeTime, 0.0, 1.0);
            _hinter = new Tween<double>(__hintFadeTime, 0.0, 1.0);
            Star = new GraphicsPath();
            Star.AddLines(new[]
                              {
                                  new PointF(26.9400499815511f, 16.198001017554f),
                                  new PointF(20.5972100115072f, 19.992117795794f),
                                  new PointF(17.5503116837126f, 26.7258650135467f),
                                  new PointF(11.9818468548384f, 21.8659122913384f),
                                  new PointF(4.63612932088923f, 21.0489821083111f),
                                  new PointF(7.53746876153053f, 14.2512493640288f),
                                  new PointF(6.04446398158846f, 7.01261152672956f),
                                  new PointF(13.4060551976796f, 7.6713343665333f),
                                  new PointF(19.8290450322585f, 4.01454033385862f),
                                  new PointF(21.4774191744442f, 11.2193861823056f),
                                  new PointF(26.9400499815511f, 16.198001017554f)
                              });
            Star.CloseFigure();
            #endregion
        }

        public override void Update(object sender, EventArgs e)
        {
            _rotator += 3f;
            if (Game != null &&  Game.CurrentPlayer.PlayerType == PlayerType.Human)
            {
                var mx = new Rectangle(0, 0, Width, Height).Contains(Mouse) ? (Mouse.X / Common.TileSizePx) * Common.TileSizePx : 0;
                var my = new Rectangle(0, 0, Width, Height).Contains(Mouse) ? (Mouse.Y / Common.TileSizePx) * Common.TileSizePx : 0;
                Game.CurrentPlayer.Placement.Point = new Point(mx / Common.TileSizePx, my / Common.TileSizePx);
            }
            _fader.Update(_fadeRate);
            _hinter.Update(_hintFadeRate);
            Refresh();
        }

        protected override void OnClick(EventArgs e)
        {
            if (Game != null &&  Game.CurrentPlayer.PlayerType == PlayerType.Human)
            {
                if (((MouseEventArgs) e).Button == MouseButtons.Right)
                {
                    Game.CurrentPlayer.Placement.Orentation = Game.CurrentPlayer.Placement.Orentation ==
                                                              TileOrentation.Horizontal
                                                                  ? TileOrentation.Vertical
                                                                  : TileOrentation.Horizontal;
                }
                if (((MouseEventArgs) e).Button == MouseButtons.Left)
                {
                    Game.EndTurn(EndOfTurn.Place);
                }
            }
            base.OnClick(e);
        }  

        protected override void OnPaint(PaintEventArgs pe)
        {
            DrawBoard(pe.Graphics);
            if (Game != null)
            {
                DrawGameBoard(pe.Graphics);
                if (MouseOver||Game.CurrentPlayer.PlayerType==PlayerType.Computer)
                    DrawGamePlayerPlacement(pe.Graphics);
                DrawLastPlaces(pe.Graphics);
                DrawHintPlaces(pe.Graphics);
            }
            
            base.OnPaint(pe);
        }

        private void DrawLastPlaces(Graphics g)
        {
            if (Game == null) return;
            foreach (var l in Game.LastPlaces)
            {
                DrawBoardTile(g, new SolidBrush(Color.FromArgb(128-((int)(_fader.Value *120.0)),0 , 255, 0)), l.X, l.Y);                    
            }
        }

        private void DrawHintPlaces(Graphics g)
        {
            
            if (Game == null) return;
            if (Game.HintCount == 2)
            {

                foreach (var l in Game.HintPlaces)
                {
                    DrawBoardTile(g, new SolidBrush(Color.FromArgb(255 - ((int)(_hinter.Value * 255.0)), 30, 144, 255)), l.X,
                                 l.Y);
                }
            }
            if (Game.HintCount == 1 && Game.HintPlaces.Count != 0)
            {
                DrawBoardTile(g, new SolidBrush(Color.FromArgb(255 - ((int)(_hinter.Value * 255.0)), 30, 144, 255)), Game.HintPlaces[0].X,
                                Game.HintPlaces[0].Y);
            }
        }

        private void DrawBoardTile(Graphics g, Brush tileBrush, int x, int y)
        {
            var p = Common.PenTileBorder;
            var r = new Rectangle(x * Common.TileSizePx, y * Common.TileSizePx, Common.TileSizePx, Common.TileSizePx);
            g.FillRectangle(tileBrush, r);
            if (r.Contains(Mouse.X, Mouse.Y))
                g.FillRectangle(Common.BrushMouseOverHighlight, r);
            g.DrawRectangle(p, r);
        }

        private static void DrawSpecialTileText(Graphics g, string text, int x, int y)
        {
            var r = new Rectangle(x * Common.TileSizePx, y * Common.TileSizePx, Common.TileSizePx, Common.TileSizePx);
            var stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            g.DrawString(text, Common.FontSpecialTile, Common.BrushSpecialTileOverlayColor, r, stringFormat);

        }
      
        public void ResetLast()
        {
            _fader.Reset();
        }

        public void ResetHints()
        {
            _hinter.Reset();
        }
        private void DrawBoard(Graphics g)
        {
            for (var i = 0; i < Common.BoardWidth; i++)
            {
                for (var j = 0; j < Common.BoardHeight; j++)
                {
                    switch (Board.BoardLayout[i, j])
                    {
                        case Space.Blank:
                            {
                                DrawBoardTile(g, Common.BrushTileBlank, i, j);
                                break;
                            }
                        case Space.DoubleLetter:
                            {
                                DrawBoardTile(g, Common.BrushTileDoubleLetter, i, j);
                                DrawSpecialTileText(g, "DL", i, j);
                                break;
                            }
                        case Space.TrippleLetter:
                            {
                                DrawBoardTile(g, Common.BrushTileTripleLetter, i, j);
                                DrawSpecialTileText(g, "TL", i, j);
                                break;
                            }
                        case Space.DoubleWord:
                            {
                                DrawBoardTile(g, Common.BrushTileDoubleWord, i, j);
                                DrawSpecialTileText(g, "DW", i, j);
                                break;
                            }
                        case Space.TrippleWord:
                            {
                                DrawBoardTile(g, Common.BrushTileTripleWord, i, j);
                                DrawSpecialTileText(g, "TW", i, j);
                                break;
                            }
                        case Space.FirstWord:
                            {
                                DrawBoardTile(g, Common.BrushTileFirstWord, i, j);
                                var st = (GraphicsPath)Star.Clone();
                                _rotatorMatrix.RotateAt(_rotator, new PointF((i * Common.TileSizePx) + (Common.TileSizePx / 2f), (i * Common.TileSizePx) + (Common.TileSizePx / 2f)));
                                _rotatorMatrix.Translate((i * Common.TileSizePx), (j * Common.TileSizePx));
                                st.Transform(_rotatorMatrix);
                                g.FillPath(Brushes.AliceBlue, st);
                                _rotatorMatrix.Reset();
                                break;
                            }
                    }
                    g.DrawRectangle(Common.PenBoardBorder, new Rectangle((int)(Common.PenBoardBorder.Width / 2f), (int)(Common.PenBoardBorder.Width / 2f), Width - (int)(Common.PenBoardBorder.Width), Height - (int)(Common.PenBoardBorder.Width)));
                }
            }
        }

        private void DrawGameBoard(Graphics g)
        {
            for (var i = 0; i < Common.BoardWidth; i++)
            {
                for (var j = 0; j < Common.BoardHeight; j++)
                {
                    Utilities.DrawPlacementTile(g, Game.GameBoard[i][j], i * Common.TileSizePx, j * Common.TileSizePx, Common.BrushTileLetter);
                }
            }
        }

        private void DrawGamePlayerPlacement(Graphics g)
        {
            if (!MouseOver) return;
            List<Point> locations;
            List<List<Tile>> words;
            int score;
            string aword;
            var placeable = Game.ValidateBoard(Game.CurrentPlayer.Placement, out locations, out words, out aword,out score);
            var loffset = 0;
            foreach (var t in words)
            {
                foreach (var t1 in t)
                {
                    var p = locations[loffset];
                    if (Game.GameBoard[p.X][p.Y] == null)
                        Utilities.DrawPlacementTile(g, t1,
                                                    p.X*Common.TileSizePx, p.Y*Common.TileSizePx,
                                                    placeable
                                                        ? Common.BrushTileLetterPlaceable
                                                        : Common.BrushTileLetterUnPlaceable);
                    else
                        Utilities.DrawPlacementTile(g, t1,
                                                    p.X*Common.TileSizePx, p.Y*Common.TileSizePx,
                                                    Common.BrushTileLetterPlaced);
                    loffset++;
                }
            }
        }
    }
}
