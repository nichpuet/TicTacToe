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
        int scale = 2;

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
        }

        private void GameScreen_Click(object sender, EventArgs e)
        {
            Point mp = this.PointToClient(Cursor.Position);
            mouseX = mp.X;
            mouseY = mp.Y;

            testLabel.Text = "X: " + mouseX+ "\nY: " + mouseY;

            if (mouseX < 65*scale && mouseX > 15*scale)
            {
                tempX = 15*scale;
            }
            else if (mouseX < 115*scale && mouseX > 65 * scale)
            {
                tempX = 65 * scale;
            }
            else if (mouseX < 165*scale && mouseX < 115 * scale)
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
            else if (mouseY < 165 * scale && mouseY < 115 * scale)
            {
                tempY = 115 * scale;
            }

            Tiles playerTile = new Tiles(tempX, tempY, p1Turn);
            if (p1Turn == true)
            {
                xTiles.Add(playerTile);
                foreach (Tiles t in blankTiles)
                {

                }
            }
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
