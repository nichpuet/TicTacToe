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

        public GameScreen()
        {
            InitializeComponent();
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

         
            if (mouseX < 65*scale && mouseX > 15*scale)
            {
                tempX = 15*scale;
            }
            else if (mouseX < 115*scale && mouseX > 65 * scale)
            {
                tempX = 65 * scale;
            }
            else if (mouseX < 165*scale && mouseX > 115 * scale)
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
            if (p1Turn == true)
            {
                xTiles.Add(playerTile);
                p1Turn = false;
                foreach(Tiles t in xTiles)
                {
                    t.drawTile(t.x, t.y, p1Turn, scale);
                }
                
            }
            else if (p1Turn == false)
            {
                oTiles.Add(playerTile);
                p1Turn = true;
                foreach(Tiles l in oTiles)
                {
                    l.drawTile(l.x, l.y, p1Turn, scale);
                }
            }

            for(int i = 0; i < blankTiles.Count(); i++)
            {
                if(blankTiles[i].x == tempX && blankTiles[i].y == tempY)
                {
                    blankTiles.RemoveAt(i);
                }
            }
            Refresh();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                Tiles blankTile = new Tiles((15 + (50*i))*scale, 15*scale, true);
                blankTiles.Add(blankTile);
            }
            for (int i = 0;i < 3; i++)
            {
                Tiles blankTile = new Tiles((15+(50*i))*scale, 65*scale, true);
                blankTiles.Add(blankTile);
            }
            for (int i = 0;i < 3; i++)
            {
                Tiles blankTile = new Tiles((15+(50 * i))*scale, 115*scale, true);
                blankTiles.Add(blankTile);
            }

            
        }
    }
}
