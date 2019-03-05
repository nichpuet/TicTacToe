using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Tiles
    {
        public int x, y;
        public bool playerTurn;

        public Tiles(int _x, int _y, bool _playerTurn)
        {
            x = _x;
            y = _y;

            playerTurn = _playerTurn;
        }

        public void drawTile(int _x, int _y, bool _playerTurn)
        {
            if(_playerTurn == true)
            {

            }
        }
    }
}
