using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class GameScreen : UserControl
    {

        List<Tiles> xTiles = new List<Tiles>();
        List<Tiles> oTiles = new List<Tiles>();
        List<Tiles> blankTiles = new List<Tiles>();

        bool p1Turn = true;

        int mouseX, tempX;
        int mouseY, tempY;
        public int scale = 2;

        bool gameWon = false, spaceDown = false;

        public GameScreen()
        {
            InitializeComponent();

            OnStart();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            
            Pen boardPen = new Pen(Color.Black, 5);
            e.Graphics.DrawLine(boardPen, 65*scale, 15*scale, 65*scale,165*scale);
            e.Graphics.DrawLine(boardPen, 115 * scale, 15 * scale, 115 * scale, 165 * scale);
            e.Graphics.DrawLine(boardPen, 15 * scale, 65 * scale, 165 * scale, 65 * scale);
            e.Graphics.DrawLine(boardPen, 15 * scale, 115 * scale, 165 * scale, 115 * scale);

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


            Point mp = this.PointToClient(Cursor.Position);
            mouseX = mp.X;
            mouseY = mp.Y;


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

            Tiles playerTile = new Tiles(tempX, tempY, p1Turn);

            for (int i = 0; i < blankTiles.Count(); i++)
            {
                if (blankTiles[i].x == tempX && blankTiles[i].y == tempY)
                {
                    blankTiles.RemoveAt(i);

                    if (p1Turn == true)
                    {
                        xTiles.Add(playerTile);
                        p1Turn = false;
                        foreach (Tiles t in xTiles)
                        {
                            t.drawTile(t.x, t.y, p1Turn, scale);
                        }

                    }
                    else if (p1Turn == false)
                    {
                        oTiles.Add(playerTile);
                        p1Turn = true;
                        foreach (Tiles l in oTiles)
                        {
                            l.drawTile(l.x, l.y, p1Turn, scale);
                        }
                    }
                }
            }
            WinCheck(p1Turn);
            Refresh();
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    spaceDown = false;
                    break;
            }
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    spaceDown = true;
                    break;

            }
        }

        private void OnStart()
        {
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

        private void WinCheck(bool pTurn)
        {
            int counterX = 0, counterO = 0;
            for (int k = 0; k < 3; k++)
            {
                counterO = 0;
                counterX = 0;
                for (int i = 0; i < xTiles.Count(); i++)
                {
                    if (xTiles[i].x == 15*scale + (50*scale)*k && pTurn == true)
                    {
                        counterX++;
                    }

                    if (counterX == 3)
                    {
                        winLabel.Text = "X's Win";
                        winLabel.Visible = true;
                        counterX = 0;
                        gameWon = true;
                    }
                }
                for (int i = 0; i < oTiles.Count(); i++)
                {
                    if (oTiles[i].x == 15*scale + (50 * scale) * k && pTurn == false)
                    {
                        counterO++;
                    }

                    if (counterO == 3)
                    {
                        winLabel.Text = "O's Win";
                        winLabel.Visible = true;
                        counterX = 0;
                        gameWon = true;
                    }
                }
            }

            for (int k = 0; k < 3; k++)
            {
                counterO = 0;
                counterX = 0;
                for (int i = 0; i < xTiles.Count(); i++)
                {
                    if (xTiles[i].y == 15*scale + (50 * scale) * k && pTurn == true)
                    {
                        counterX++;
                    }

                    if (counterX == 3)
                    {
                        winLabel.Text = "X's Win";
                        winLabel.Visible = true;
                        counterX = 0;
                        gameWon = true;
                    }
                }
                for (int i = 0; i < oTiles.Count(); i++)
                {
                    if (oTiles[i].y == 15*scale + (50 * scale) * k && pTurn == false)
                    {
                        counterO++;
                    }

                    if (counterO == 3)
                    {
                        winLabel.Text = "O's Win";
                        winLabel.Visible = true;
                        counterX = 0;
                        gameWon = true;
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
                    winLabel.Text = "X's Win";
                    winLabel.Visible = true;
                    counterX = 0;
                    gameWon = true;
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
                    winLabel.Text = "O's Win";
                    winLabel.Visible = true;
                    counterX = 0;
                    gameWon = true;
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
                    winLabel.Text = "X's Win";
                    winLabel.Visible = true;
                    counterX = 0;
                    gameWon = true;
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
                    winLabel.Text = "O's Win";
                    winLabel.Visible = true;
                    counterX = 0;
                    gameWon = true;
                }
            }
            if (blankTiles.Count() == 0)
            {
                winLabel.Text = "Tie Game";
                winLabel.Visible = true;
            }
        }
    }
}
