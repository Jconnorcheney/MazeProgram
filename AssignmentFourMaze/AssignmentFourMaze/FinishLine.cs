using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentFourMaze
{
    class FinishLine
    {
        public int finishLineX { get; }
        public int finishLineY { get; }
        public Rectangle FinishLineOnBoard;

        /// <summary>
        /// constructor for finish line.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="finishLine"></param>
        public FinishLine(int x, int y, Rectangle finishLine)
        {
            finishLineX = x;
            finishLineY = y;
            FinishLineOnBoard = finishLine;
        }
        /// <summary>
        /// drawing stats for the finish line
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(Graphics graphics)
        {
            graphics.DrawRectangle(Pens.Firebrick, FinishLineOnBoard.X, FinishLineOnBoard.Y, FinishLineOnBoard.Width, FinishLineOnBoard.Height);
            graphics.FillRectangle(Brushes.Green, FinishLineOnBoard);
        }
    }
}
