﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Tiles
    {
        //Setting up variables for use later
        public int x, y;
        public bool playerTurn;

        public int drawX1, drawX2, drawY1, drawY2;

        //bringing variables in from other forms
        public Tiles(int _x, int _y, bool _playerTurn)
        {
            x = _x;
            y = _y;
            playerTurn = _playerTurn;
        }

        //Does the math for the variables for drawing the x's and o's
        public void drawTile(int _x, int _y, bool _playerTurn, int scale)
        {
            if(_playerTurn == true)
            {
                drawX1 = _x + 5 * scale;
                drawX2 = (45 * scale) - (5 * scale);
                drawY1 = _y + 5 * scale;
                drawY2 = (45 * scale) - (5 * scale);
            }
            else if (_playerTurn == false)
            {
                drawX1 = _x + 5 * scale;
                drawY1 = _y + 5 * scale;
                drawX2 = _x + (50 * scale) - (5 * scale);
                drawY2 = _y + (50 * scale) - (5 * scale);
            }
        }
    }
}
