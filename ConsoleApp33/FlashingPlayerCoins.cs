using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectFour
{
    class FlashingPlayerCoins
    {
        private BoardPrinter BoardPrinter { get; set; }

        public FlashingPlayerCoins(BoardPrinter boardPrinter)
        {
            BoardPrinter = boardPrinter;
        }

        //public void FlashColumn(Player player, int x, int y)
        public void FlashColumn(Player player, int[,] coin1, int[,] coin2, int[,] coin3, int[,] coin4)
        {
            for (int i = 0; i < 5; i++)
            {
                ConsoleColor OldPlayerColor = player.Color;
                Console.Clear();
                BoardPrinter.Board._board[coin1[0, 0]][coin1[0, 1]].Color = ConsoleColor.Black;
                BoardPrinter.Board._board[coin2[0, 0]][coin2[0, 1]].Color = ConsoleColor.Black;
                BoardPrinter.Board._board[coin3[0, 0]][coin3[0, 1]].Color = ConsoleColor.Black;
                BoardPrinter.Board._board[coin4[0, 0]][coin4[0, 1]].Color = ConsoleColor.Black;
                BoardPrinter.Print();
                Thread.Sleep(300);
                BoardPrinter.Board._board[coin1[0, 0]][coin1[0, 1]].Color = OldPlayerColor;
                BoardPrinter.Board._board[coin2[0, 0]][coin2[0, 1]].Color = OldPlayerColor;
                BoardPrinter.Board._board[coin3[0, 0]][coin3[0, 1]].Color = OldPlayerColor;
                BoardPrinter.Board._board[coin4[0, 0]][coin4[0, 1]].Color = OldPlayerColor;
                BoardPrinter.Print();
                Thread.Sleep(300);
            }

            /*ConsoleColor OldPlayerColor = BoardPrinter.Board._board[y][x].Color;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                BoardPrinter.Board._board[y][x].Color = ConsoleColor.Black;
                BoardPrinter.Board._board[y][x + 1].Color = ConsoleColor.Black;
                BoardPrinter.Board._board[y][x + 2].Color = ConsoleColor.Black;
                BoardPrinter.Board._board[y][x + 3].Color = ConsoleColor.Black;

                BoardPrinter.Print();
                Thread.Sleep(300);

                BoardPrinter.Board._board[y][x].Color = OldPlayerColor;
                BoardPrinter.Board._board[y][x + 1].Color = OldPlayerColor;
                BoardPrinter.Board._board[y][x + 2].Color = OldPlayerColor;
                BoardPrinter.Board._board[y][x + 3].Color = OldPlayerColor;

                BoardPrinter.Print();
                Thread.Sleep(300);
            }*/
        }

        public void FlashRow(Player player, int x, int y)
        {
            ConsoleColor OldPlayerColor = BoardPrinter.Board._board[y][x].Color;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                BoardPrinter.Board._board[y][x].Color = ConsoleColor.Black;
                BoardPrinter.Board._board[y + 1][x].Color = ConsoleColor.Black;
                BoardPrinter.Board._board[y + 2][x].Color = ConsoleColor.Black;
                BoardPrinter.Board._board[y + 3][x].Color = ConsoleColor.Black;
            }
        }

        public void FlashDiagonal1(Player player, int x, int y)
        {
            ConsoleColor OldPlayerColor = BoardPrinter.Board._board[y + 1][x + 2].Color;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                BoardPrinter.Board._board[y][x].Color = ConsoleColor.Black;
                BoardPrinter.Board._board[y + 1][x + 1].Color = ConsoleColor.Black;
                BoardPrinter.Board._board[y + 2][x + 2].Color = ConsoleColor.Black;
                BoardPrinter.Board._board[y + 3][x + 3].Color = ConsoleColor.Black;
            }
        }

        public void FlashDiagonal2(Player player, int x, int y)
        {
            ConsoleColor OldPlayerColor = BoardPrinter.Board._board[y + 3][x].Color;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                BoardPrinter.Board._board[y + 3][x].Color = ConsoleColor.Black;
                BoardPrinter.Board._board[y + 2][x + 1].Color = ConsoleColor.Black;
                BoardPrinter.Board._board[y + 1][x + 2].Color = ConsoleColor.Black;
                BoardPrinter.Board._board[y][x + 3].Color = ConsoleColor.Black;
            }
        }
    }
}
