using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssignmentFourMaze
{
    public partial class MazeGameForm : Form
    {
        Player player;
        FinishLine finishLine;
        Graphics graphics;
        int PlayerStartX;
        int PlayerStartY;
        int FinishStartX;
        int FinishStartY;
        string victoryMessage;

        public MazeGameForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// loads the form
        /// sets the starting location
        /// and makes the start and finish objects.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            startingLocations();
            finishLine = new FinishLine(FinishStartX, FinishStartY, new Rectangle(FinishStartX,FinishStartY,15,15));
            player = new Player(PlayerStartX,PlayerStartY,new Rectangle(PlayerStartX,PlayerStartY,15,15));

        }


        /// <summary>
        /// painting the graphics
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MazeGameForm_Paint(object sender, PaintEventArgs e)
        {
            graphics = e.Graphics;
            player.Draw(graphics);
            finishLine.Draw(graphics);
        }

        /// <summary>
        /// Key downstroke responceses
        /// Calling two functions to check for collision
        /// accounts for WASD too
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MazeGameForm_KeyDown(object sender, KeyEventArgs e)
        {
            CheckForFinish();
            CheckForCollision();
            switch (e.KeyCode)
            {
                case Keys.Left:
                    {
                        player.Move(Player.Movement.Left);
                        Invalidate();
                        break;
                    }
                case Keys.Right:
                    {
                        player.Move(Player.Movement.Right);
                        Invalidate();
                        break;
                    }
                case Keys.Up: 
                    {
                        player.Move(Player.Movement.Up);
                        Invalidate();
                        break;
                    }
                case Keys.Down:
                    {
                        player.Move(Player.Movement.Down);
                        Invalidate();
                        break;
                    }
                case Keys.W:
                    {
                        player.Move(Player.Movement.Up);
                        Invalidate();
                        break;
                    }
                case Keys.S:
                    {
                        player.Move(Player.Movement.Down);
                        Invalidate();
                        break;
                    }
                case Keys.A:
                    {
                        player.Move(Player.Movement.Left);
                        Invalidate();
                        break;
                    }
                case Keys.D:
                    {
                        player.Move(Player.Movement.Right);
                        Invalidate();
                        break;
                    }



            }


        }
        /// <summary>
        /// sets the x and y for the start and finish for the game
        /// will never set the start and finish the same
        /// </summary>
        private void startingLocations()
        {
            Random rand = new Random();
            int randomStart = rand.Next(1, 5);
            int randomFinish = rand.Next(1, 5);
            while (randomStart == randomFinish)
            {
                randomStart = rand.Next(1, 5);
                randomFinish = rand.Next(1, 5);
            }
            //Top Left x=30,y25
            //Top Right x=695 ,y=25
            //Bottom Left x=30 , y=600
            //Bottom Right x=695, y=600

            if (randomStart == 1)
            {
                PlayerStartX = 30;
                PlayerStartY = 25;
            }else if(randomStart == 2)
            {
                PlayerStartX = 695;
                PlayerStartY = 25;
            }else if (randomStart ==3)
            {
                PlayerStartX = 30;
                PlayerStartY = 600;
            }
            else if (randomStart==4)
            {
                PlayerStartX = 695;
                PlayerStartY = 600;
            }

            if (randomFinish == 1)
            {
                FinishStartX = 30;
                FinishStartY = 25;
            }
            else if (randomFinish == 2)
            {
                FinishStartX = 695;
                FinishStartY = 25;
            }
            else if (randomFinish == 3)
            {
                FinishStartX = 30;
                FinishStartY = 600;
            }
            else if (randomFinish == 4)
            {
                FinishStartX = 695;
                FinishStartY = 600;
            }

        }

        /// <summary>
        /// Checking to see if they hit the finish block
        /// triggers end of game message and restarts the app
        /// </summary>
        private void CheckForFinish() 
        {
            if (player.PlayerOnBoard.IntersectsWith(finishLine.FinishLineOnBoard))
            {
                victoryMessage = "You've Completed the Maze! Going again in 5 seconds!";
                textBoxVictory.Visible = true;
                textBoxVictory.AppendText(victoryMessage);
                System.Threading.Thread.Sleep(5000);
                Application.Restart();
            }
        }
        /// <summary>
        /// Checks to see if the player hit the walls
        /// Resets the player to the starting cords
        /// </summary>
        private void CheckForCollision()
        {
            foreach (var pictureBox in Controls.OfType<PictureBox>())
            {
                if (player.PlayerOnBoard.IntersectsWith(pictureBox.Bounds))
                {
                    player.PlayerOnBoard.X = PlayerStartX;
                    player.PlayerOnBoard.Y = PlayerStartY;
                }
            }
        }

    }
}
