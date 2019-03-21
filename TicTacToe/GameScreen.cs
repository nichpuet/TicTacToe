using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace TicTacToe
{
    public partial class GameScreen : UserControl
    {
        //Setting up lists for use later
        List<Tiles> xTiles = new List<Tiles>();
        List<Tiles> oTiles = new List<Tiles>();
        List<Tiles> blankTiles = new List<Tiles>();

        //Setting up sounds for later
        SoundPlayer winSound = new SoundPlayer(Properties.Resources.gong);
        SoundPlayer clickSound = new SoundPlayer(Properties.Resources.jabSound);

        //Setting up variables for later
        bool pTurn = true;

        int mouseX, tempX;
        int mouseY, tempY;
        public int scale = 2;

        bool gameWon = false;

        public GameScreen()
        {
            InitializeComponent();

            OnStart();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //Drawing the board
            Pen boardPen = new Pen(Color.Black, 5);
            e.Graphics.DrawLine(boardPen, 65 * scale, 15 * scale, 65 * scale,165 * scale);
            e.Graphics.DrawLine(boardPen, 115 * scale, 15 * scale, 115 * scale, 165 * scale);
            e.Graphics.DrawLine(boardPen, 15 * scale, 65 * scale, 165 * scale, 65 * scale);
            e.Graphics.DrawLine(boardPen, 15 * scale, 115 * scale, 165 * scale, 115 * scale);

            //Drawing any x's and o's in their seperate lists (Using goofy math)
            Pen xPen = new Pen(Color.Red, 3);
            Pen oPen = new Pen(Color.Blue, 3);

            foreach(Tiles t in xTiles)
            {
                e.Graphics.DrawLine(xPen, t.drawX1, t.drawY1, t.drawX2, t.drawY2);
                e.Graphics.DrawLine(xPen, t.drawX1 + (40 * scale), t.drawY1, t.drawX2 - (40 * scale), t.drawY2);
            }
            foreach(Tiles t in oTiles)
            {
                e.Graphics.DrawEllipse(oPen, t.drawX1, t.drawY1, t.drawX2, t.drawY2);
            }         
        }

        private void GameScreen_Click(object sender, EventArgs e)
        {
            //When the screen is click it checks the section clicked and places either an x or o in its list.
            if (gameWon == false)
            {
                Point mp = this.PointToClient(Cursor.Position);
                mouseX = mp.X;
                mouseY = mp.Y;

                //Sets the tempX/Y used to make the tiles to the corners of the tile they are placed in based off where you clicked
                if (mouseX < 65 * scale && mouseX > 15 * scale)
                {
                    tempX = 15 * scale;
                }
                else if (mouseX < 115 * scale && mouseX > 65 * scale)
                {
                    tempX = 65 * scale;
                }
                else if (mouseX < 165 * scale && mouseX > 115 * scale)
                {
                    tempX = 115 * scale;
                }

                if (mouseY < 65 * scale && mouseY > 15 * scale)
                {
                    tempY = 15 * scale;
                }
                else if (mouseY < 115 * scale && mouseY > 65 * scale)
                {
                    tempY = 65 * scale;
                }
                else if (mouseY < 165 * scale && mouseY > 115 * scale)
                {
                    tempY = 115 * scale;
                }

                Tiles playerTile = new Tiles(tempX, tempY, pTurn);

                //This only happens if there IS a blank tile in the blankTiles list
                for (int i = 0; i < blankTiles.Count(); i++)
                {
                    if (blankTiles[i].x == tempX && blankTiles[i].y == tempY)
                    {
                        blankTiles.RemoveAt(i);

                        if (pTurn == true)
                        {
                            xTiles.Add(playerTile);
                            pTurn = false;
                            foreach (Tiles t in xTiles)
                            {
                                t.drawTile(t.x, t.y, pTurn, scale);
                            }

                        }
                        else if (pTurn == false)
                        {
                            oTiles.Add(playerTile);
                            pTurn = true;
                            foreach (Tiles l in oTiles)
                            {
                                l.drawTile(l.x, l.y, pTurn, scale);
                            }
                        }
                        //plays a sound whenever a x or o is placed
                        clickSound.Play();
                    }
                }
                //checks if anyone has won
                WinCheck();
                Refresh();
            }
        }

        private void winLabel_Click(object sender, EventArgs e)
        {
            //if the winCheck comes back positive the click resets the screen
            if (gameWon == true)
            {
                Reset();
            }
        }

        private void Reset()
        {
            //clears all the list and board before redrawing and establishing the blankTiles list again
            xTiles.Clear();
            oTiles.Clear();
            blankTiles.Clear();

            Graphics g = this.CreateGraphics();
            g.Clear(Color.BurlyWood);
            Refresh();

            gameWon = false;
            winLabel.Visible = false;
            pTurn = true;

            OnStart();  
        }

        private void OnStart()
        {
            //puts the 3x3 of tiles in the blankTiles list 
            for (int i = 0; i < 3; i++)
            {
                Tiles blankTile = new Tiles((15 + (50 * i)) * scale, 15 * scale, true);
                blankTiles.Add(blankTile);
            }
            for (int i = 0; i < 3; i++)
            {
                Tiles blankTile = new Tiles((15 + (50 * i)) * scale, 65 * scale, true);
                blankTiles.Add(blankTile);
            }
            for (int i = 0; i < 3; i++)
            {
                Tiles blankTile = new Tiles((15 + (50 * i)) * scale, 115 * scale, true);
                blankTiles.Add(blankTile);
            }
        }
        //Checks each row of the table for a winner, then checks each column, after checks each diaganol.
        private void WinCheck()
        {
            int counterX = 0, counterO = 0;
            for (int k = 0; k < 3; k++)
            {
                counterO = 0;
                counterX = 0;
                for (int i = 0; i < xTiles.Count(); i++)
                {
                    if (xTiles[i].x == 15*scale + (50*scale)*k )
                    {
                        counterX++;
                    }
                    if (counterX == 3)
                    {
                        winLabel.Text = "X's Win. Click This to Reset";
                        winLabel.Visible = true;
                        counterX = 0;
                        gameWon = true;
                        winSound.Play();
                    }
                }
                
                for (int i = 0; i < oTiles.Count(); i++)
                {
                    if (oTiles[i].x == 15*scale + (50 * scale) * k)
                    {
                        counterO++;
                    }

                    if (counterO == 3)
                    {
                        winLabel.Text = "O's Win. Click This to Reset";
                        winLabel.Visible = true;
                        counterX = 0;
                        gameWon = true;
                        winSound.Play();
                    }
                }

            }
            

            for (int k = 0; k < 3; k++)
            {
                counterO = 0;
                counterX = 0;
                for (int i = 0; i < xTiles.Count(); i++)
                {
                    if (xTiles[i].y == 15*scale + (50 * scale) * k )
                    {
                        counterX++;
                    }

                    if (counterX == 3)
                    {
                        winLabel.Text = "X's Win. Click This to Reset";
                        winLabel.Visible = true;
                        counterX = 0;
                        gameWon = true;
                        winSound.Play();
                    }
                }
                for (int i = 0; i < oTiles.Count(); i++)
                {
                    if (oTiles[i].y == 15*scale + (50 * scale) * k )
                    {
                        counterO++;
                    }

                    if (counterO == 3)
                    {
                        winLabel.Text = "O's Win. Click This to Reset";
                        winLabel.Visible = true;
                        counterX = 0;
                        gameWon = true;
                        winSound.Play();
                    }
                }
            }

            counterX = 0;
            counterO = 0;

            for (int i = 0; i < xTiles.Count(); i++)
            {
                if (xTiles[i].x == 15 * scale && xTiles[i].y == 15 * scale)
                {
                    counterX++;
                }
                if (xTiles[i].x == 15 * scale + 50 * scale && xTiles[i].y == 15 * scale + 50 * scale)
                {
                    counterX++;
                }
                if(xTiles[i].x == 15 * scale + 100 * scale && xTiles[i].y == 15 * scale + 100 * scale)
                {
                    counterX++;
                }

                if (counterX == 3)
                {
                    winLabel.Text = "X's Win. Click This to Reset";
                    winLabel.Visible = true;
                    counterX = 0;
                    gameWon = true;
                    winSound.Play();
                }
            }
            for (int i = 0; i < oTiles.Count(); i++)
            {
                if (oTiles[i].x == 15 * scale && oTiles[i].y == 15 * scale)
                {
                    counterO++;
                }
                if (oTiles[i].x == 15 * scale + 50 * scale && oTiles[i].y == 15 * scale + 50 * scale)
                {
                    counterO++;
                }
                if (oTiles[i].x == 15 * scale + 100 * scale && oTiles[i].y == 15 * scale + 100 * scale)
                {
                    counterO++;
                }

                if (counterO == 3)
                {
                    winLabel.Text = "O's Win. Click This to Reset";
                    winLabel.Visible = true;
                    counterX = 0;
                    gameWon = true;
                    winSound.Play();
                }
            }

            counterX = 0;
            counterO = 0;

            for (int i = 0; i < xTiles.Count(); i++)
            {
                if (xTiles[i].x == 15 * scale + 100 * scale && xTiles[i].y == 15 * scale)
                {
                    counterX++;
                }
                if (xTiles[i].x == 15 * scale + 50 * scale && xTiles[i].y == 15 * scale + 50 * scale)
                {
                    counterX++;
                }
                if (xTiles[i].x == 15 * scale && xTiles[i].y == 15 * scale + 100 * scale)
                {
                    counterX++;
                }

                if (counterX == 3)
                {
                    winLabel.Text = "X's Win. Click This to Reset";
                    winLabel.Visible = true;
                    counterX = 0;
                    gameWon = true;
                    winSound.Play();
                }
            }
            for (int i = 0; i < oTiles.Count(); i++)
            {
                if (oTiles[i].x == 230 && oTiles[i].y == 30)
                {
                    counterO++;
                }
                if (oTiles[i].x == 130 && oTiles[i].y == 130)
                {
                    counterO++;
                }
                if (oTiles[i].x == 30 && oTiles[i].y == 230)
                {
                    counterO++;
                }

                if (counterO == 3)
                {
                    winLabel.Text = "O's Win. Click This to Reset";
                    winLabel.Visible = true;
                    counterX = 0;
                    gameWon = true;
                    winSound.Play();
                }
            }
            if (blankTiles.Count() == 0 && gameWon == false)
            {
                winLabel.Text = "Tie Game. Click This to Reset";
                winLabel.Visible = true;
                gameWon = true;
                winSound.Play();
            }
        }
    }
} 
