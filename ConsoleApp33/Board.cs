using System;

namespace ConnectFour
{
    class Board
    {

        public Player[][] _board { get; set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public Board(int height, int width)
        {
            Width = width;
            Height = height;
            _board = new Player[Width][];

            for (int i = 0; i < Width; i++)
            {
                _board[i] = new Player[Height];
            }
        }
    }
}
