using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentFourMaze
{
    class Player
    {
        public int playerX { get; }
        public int playerY { get; }
        public Rectangle PlayerOnBoard;// = new Rectangle(playerX, playerY, width, height);
        public int speed = 10;
        
        public Player(int x, int y,Rectangle player)
        {
            playerX = x;
            playerY = y;
            PlayerOnBoard = player;
            
        }
        /// <summary>
        /// Movement directions
        /// </summary>
        public enum Movement    
        {
            Left, Right, Up, Down
        }
        /// <summary>
        /// Draw graphics for the player piece
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(Graphics graphics)
        {
            graphics.DrawRectangle(Pens.Firebrick, PlayerOnBoard.X, PlayerOnBoard.Y, PlayerOnBoard.Width, PlayerOnBoard.Height);
            graphics.FillRectangle(Brushes.Black, PlayerOnBoard);
        }
        /// <summary>
        /// Movement for player piece
        /// </summary>
        /// <param name="movement"></param>
        public void Move(Movement movement)
        {
            switch (movement)
            {
                case Movement.Left:
                    PlayerOnBoard.X -= speed;

                    break;

            
            
                case Movement.Right:
                    PlayerOnBoard.X += speed;
                    break;

            
            
                case Movement.Up:
                    PlayerOnBoard.Y -= speed;
                    break;

            
            
                case Movement.Down:
                    PlayerOnBoard.Y += speed;
                    break;

            }

        }
    }
}
