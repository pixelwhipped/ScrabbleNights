using System;
using System.Drawing;
using System.Windows.Forms;

namespace Scrabble.GameComponents
{
    public class GameComponent : Control
    {
        public Point Mouse { get { return PointToClient(MousePosition); } }

        public bool MouseOver
        {
            get { return RectangleToScreen(ClientRectangle).Contains(MousePosition); }
        }

        public readonly Scrabble Scrabble;
        public Game Game { get { return Scrabble.ActiveGame; } }

        public GameComponent() 
        {
        }

        public GameComponent(Scrabble scrabble): this()
        {

            Scrabble = scrabble;
            SetStyle(
                ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint |
                ControlStyles.SupportsTransparentBackColor, true);
            Scrabble.Timer.Tick += Update;
        }

        public virtual void Update(object sender, EventArgs e)
        {
           // if (MouseOver)
            Refresh();
        }
    }
}
