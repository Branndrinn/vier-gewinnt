using System;
using System.Collections.Generic;

namespace ConnectFour
{
    class BoardPrinter
    {
        public Board Board { get; set; }

        public BoardPrinter(Board board)
        {
            Board = board;
        }
        public void Print()
        {

            string empty = "    ";
            string HorizontalEdge = new string('-', Board.Width * 5 + 1);
            Console.Clear();
            Console.WriteLine();
            Console.Write("|");
            for (int i = 0; i < Board.Width; i++)
            {
                if (i < 9)
                    Console.Write(" " + 0 + (i + 1) + " |");
                else
                    Console.Write(" " + (i + 1) + " |");
            }
            Console.WriteLine();

            Console.WriteLine(HorizontalEdge);
            for (int x = 0; x < Board.Height; x++)
            {

                Console.Write("|");

                for (int y = 0; y < Board.Width; y++)
                {

                    if (y == Board.Width - 1)
                    {

                        if (Board._board[y][x] == null)
                        {
                            Console.WriteLine(empty + "|");
                            Console.WriteLine(HorizontalEdge);
                        }
                        else
                        {
                            Console.BackgroundColor = Board._board[y][x].Color;
                            Console.Write("    ");
                            Console.ResetColor();
                            Console.WriteLine("|");
                            Console.WriteLine(HorizontalEdge);
                        }

                    }
                    else
                    {
                        if (Board._board[y][x] == null)
                        {
                            Console.Write(empty + "|");
                        }
                        else
                        {
                            Console.BackgroundColor = Board._board[y][x].Color;
                            Console.Write("    ");
                            Console.ResetColor();
                            Console.Write("|");
                        }
                    }
                }
            }
            Console.Write("|");
            for (int i = 0; i < Board.Width; i++)
            {
                if (i < 9)
                    Console.Write(" " + 0 + (i + 1) + " |");
                else
                    Console.Write(" " + (i + 1) + " |");
            }
            Console.WriteLine();
        }
    }
}
