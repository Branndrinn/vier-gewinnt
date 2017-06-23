using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ConnectFour
{
    class GameLogic
    {
        private List<Player> AllPlayer { get; set; }
        private FlashingPlayerCoins FlashingPlayerCoins { get; set; }
        public PlayerCollector PlayerCollector { get; set; }
        public Board Board { get; set; }
        public GameLogic(Board board, PlayerCollector playerCollector, FlashingPlayerCoins flashingPlayerCoins)
        {
            PlayerCollector = playerCollector;
            AllPlayer = PlayerCollector.AllPlayer;
            Board = board;
            FlashingPlayerCoins = flashingPlayerCoins;
        }

        private bool HasPlayer4InColumn(Player player)
        {
            for (int y = 0; y < Board.Width; y++)
            {
                for (int x = 0; x < Board.Height - 3; x++)
                {
                    if (Board._board[y][x] == player && 
                        Board._board[y][x + 1] == player && 
                        Board._board[y][x + 2] == player && 
                        Board._board[y][x + 3] == player)
                    {
                        Player coin1 = Board._board[y][x];
                        Player coin2 = Board._board[y][x+1];
                        Player coin3 = Board._board[y][x+2];
                        Player coin4 = Board._board[y][x+3];

                        int[,] intCoin1 = new int[,] { { y, x} };
                        int[,] intCoin2 = new int[,] { { y, x+1 } };
                        int[,] intCoin3 = new int[,] { { y, x+2 } };
                        int[,] intCoin4 = new int[,] { { y, x+3 } };

                        FlashingPlayerCoins.FlashColumn(player, intCoin1, intCoin2, intCoin3, intCoin4);
                        return true;
                    }
                }
            }
            return false;
        }

        private bool HasPlayer4InRow(Player player)
        {
            for (int y = 0; y < Board.Width - 3; y++)
            {
                for (int x = 0; x < Board.Height ; x++)
                {
                    
                    if (Board._board[y][x] == player && Board._board[y + 1][x] == player && Board._board[y + 2][x] == player && Board._board[y + 3][x] == player)
                    {
                        FlashingPlayerCoins.FlashRow(player, x, y);
                        return true;
                    }

                }
            }
            return false;
        }

        private bool HasPlayer4InDiagonal1(Player player)
        {
            for (int y = 0; y < Board.Width - 3; y++)
            {
                for (int x = 0; x < Board.Height - 3; x++)
                {
                    if (Board._board[x][y] == player && Board._board[x + 1][y + 1] == player && Board._board[x + 2][y + 2] == player && Board._board[x + 3][x + 3] == player)
                    {
                        FlashingPlayerCoins.FlashDiagonal1(player, x, y);
                        return true;
                    }
                }
            }
            return false;
        }

        private bool HasPlayer4InDiagonal2(Player player)
        {
            for (int y = 0; y < Board.Width - 3; y++)
            {
                for (int x = 0; x < Board.Height - 3; x++)
                {
                    {
                        if (Board._board[y + 3][x] == player && Board._board[y + 2][x + 1] == player && Board._board[y + 1][x + 2] == player && Board._board[y][x + 3] == player)
                        {
                            FlashingPlayerCoins.FlashDiagonal2(player, x, y);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool HasPlayerWinn(Player player)
        {
            if (HasPlayer4InColumn(player) || HasPlayer4InDiagonal1(player) || HasPlayer4InDiagonal2(player) || HasPlayer4InRow(player))
            {
                return true;
            }
            return false;
        }

        public void WinnTextInitialization(Player player)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Spieler " + player.Name + " Sie haben gewonnen!!! YEAHH!!!");
                Thread.Sleep(300);
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Spieler " + player.Name + " Sie haben gewonnen!!! YEAHH!!!");
                Thread.Sleep(300);
                Console.Clear();
                Console.ResetColor();
            }

            if (PlayerCollector.RePlay() == false)
            {
                Environment.Exit(0);
            }
            else
            {
                ConnectFourGame.Play();
            }
        }
        public void DoTurnsUntilWinn()
        {
            do
            {
                foreach (Player player in PlayerCollector.AllPlayer)
                {
                    PlayerCollector.PlayersTurn(player);
                    if (HasPlayerWinn(player))
                    {
                        WinnTextInitialization(player);
                    }
                }
            }
            while (true);
        }

        private void HasPlayer(out Player[][] asdf, ref int count)
        {

            count++;

            asdf = new Player[Board.Width][];
         

            for (int i = 0; i < Board.Width; i++)
            {
                asdf[i] = new Player[Board.Height];
            }



        }
    }
}