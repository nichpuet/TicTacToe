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
        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            int scale = 2;
            Pen boardPen = new Pen(Color.Black, 5);
            e.Graphics.DrawLine(boardPen, 65*scale, 15*scale, 65*scale,165*scale);
            e.Graphics.DrawLine(boardPen, 115 * scale, 15 * scale, 115 * scale, 165 * scale);
        }
    }
}
