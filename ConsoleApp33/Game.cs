using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//namespace VierGewinnt
//{
//enum Player
//{
//    None,
//    Player1,
//    Player2
//}

//    public class Game
//    {
//        const int WIDTH = 7;
//        const int HEIGHT = 6;
//        Player[,] _board = new Player[WIDTH, HEIGHT];
//        public void Example()
//        {
//            string playerOne = NamePlayerOne();
//            string playerTwo = NamePlayerTwo();
//            bool TurnRepeat = true;
//            bool moveInvalid2 = true;
//            bool moveInvalid = true;
//            bool rePlay = false;

//            while (!rePlay)
//            {
//                CreateEmptyField();
//                rePlay = false;

//                while (TurnRepeat)
//                {
//                    moveInvalid = false;
//                    moveInvalid2 = false;
//                    while (!moveInvalid)
//                    {
//                        moveInvalid = Turn(Player.Player1, ConsoleColor.Blue, playerOne, playerTwo, playerOne);
//                        Winn(playerOne, rePlay, WinnLogic(playerOne, Player.Player1));
//                    }
//                    while (!moveInvalid2)
//                    {
//                        moveInvalid2 = Turn(Player.Player2, ConsoleColor.Red, playerOne, playerTwo, playerTwo);
//                        Winn(playerTwo, rePlay, WinnLogic(playerTwo, Player.Player2));

//                    }
//                }
//            }
//        }

//        private static void PrintBoard(Player[,] board, string playerOne, string playerTwo)
//        {
//            Console.WriteLine("  1   2   3   4   5   6   7          Spieler " + playerOne + ": Blau     Spieler " + playerTwo + ": Rot");
//            for (int y = 0; y < 6; y++)
//            {
//                Console.WriteLine("-----------------------------");
//                for (var x = 0; x < 7; x++)
//                {
//                    //Console.Write(board[x, y]+"|");
//                    Player player = board[x, y];
//                    Console.Write("|");
//                    if (player.Equals(Player.None))
//                        Console.Write("   ");
//                    else if (Player.Player1.Equals(player))
//                    {
//                        Console.BackgroundColor = ConsoleColor.Blue;
//                        Console.Write("   ");
//                        Console.ResetColor();
//                    }
//                    else if (Player.Player2.Equals(player))
//                    {
//                        Console.BackgroundColor = ConsoleColor.Red;
//                        Console.Write("   ");
//                        Console.ResetColor();
//                    }
//                    if (x == 6)
//                        Console.Write("|");
//                }
//                Console.WriteLine();
//                if (y == 5)
//                    Console.WriteLine("-----------------------------");
//            }
//        }
//        private bool Turn(Player p, ConsoleColor c, string playerOneBoard, string playerTwoBoard, string name)
//        {
//            Console.Clear();
//            Console.WriteLine();
//            PrintBoard(_board, playerOneBoard, playerTwoBoard);
//            Console.WriteLine();
//            Console.BackgroundColor = c;
//            Console.WriteLine(" Spieler " + name + " wirf einen Spielstein in eine von Dir gewünschte Spalte, in dem du eine Zahl von 1 bis 7 eingibst!");
//            Console.ResetColor();
//            int choice;
//            try
//            {
//                choice = Convert.ToInt32(Console.ReadLine());
//            }
//            catch (FormatException)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("Fehler:");
//                Console.WriteLine("Keine Zahl.");
//                Console.ResetColor();
//                Thread.Sleep(1500);
//                return false;
//            }
//            choice -= 1;
//            try
//            {
//                if (_board[choice, 0] != Player.None)
//                {
//                    Console.ForegroundColor = ConsoleColor.Red;
//                    Console.WriteLine("Spalte voll");
//                    Console.ResetColor();
//                    Thread.Sleep(500);
//                    return false;
//                }
//            }
//            catch (IndexOutOfRangeException)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("Fehler:");
//                Console.WriteLine("Zahl nicht im wählbarem Bereich!");
//                Console.ResetColor();
//                Thread.Sleep(1500);
//                return false;
//            }
//            for (int i = 5; i >= 0; i--)
//            {

//                if (_board[choice, i] == Player.None)
//                {
//                    _board[choice, i] = p;
//                    break;
//                }
//            }
//            return true;
//        }

//        private void Winn(string name, bool rePlay, bool winn)
//        {
//            if (winn)
//            {
//                for (int i = 0; i < 5; i++)
//                {
//                    Console.Clear();
//                    Console.BackgroundColor = ConsoleColor.Red;
//                    Console.ForegroundColor = ConsoleColor.Blue;
//                    Console.WriteLine("Spieler " + name + " Du hast gewonnen!!! YEAHH!!!");
//                    //   Console.ResetColor();
//                    Thread.Sleep(300);
//                    Console.Clear();
//                    Console.BackgroundColor = ConsoleColor.Blue;
//                    Console.ForegroundColor = ConsoleColor.Red;
//                    Console.WriteLine("Spieler " + name + " Du hast gewonnen!!! YEAHH!!!");
//                    // Console.ResetColor();
//                    Thread.Sleep(300);
//                    Console.Clear();
//                }

//                Console.ResetColor();
//                Console.Clear();
//                Console.WriteLine(" Wollt ihr noch mal?");
//                Console.WriteLine(" Für ja J");
//                Console.WriteLine(" Für nein N");
//                string choice = Console.ReadLine();

//                switch (choice.ToLower())
//                {
//                    case "n":
//                        Environment.Exit(0);
//                        break;
//                    case "j":
//                    case "y":
//                        CreateEmptyField();
//                        break;
//                    default:
//                        break;
//                }
//            }
//        }
//        private bool WinnLogic(string name, Player p)
//        {
//            int y = 5;
//            int x = 0;
//            while (y >= 0)
//            {
//                if (_board[x, y] == p && _board[x + 1, y] == p && _board[x + 2, y] == p && _board[x + 3, y] == p)
//                {

//                    return true;

//                }
//                if (x == 3)
//                {
//                    x = -1;
//                    y--;
//                }
//                x++;
//            }

//            y = 0;
//            x = 0;
//            while (x <= 5)
//            {
//                if (_board[x, y] == p && _board[x, y + 1] == p && _board[x, y + 2] == p && _board[x, y + 3] == p)
//                {
//                    return true;

//                }
//                y++;
//                if (y == 5)
//                {
//                    y = 0;
//                    x++;
//                }
//            }

//            x = 0;
//            y = 3;
//            while (y <= 5 && x <= 3)
//            {
//                if (_board[x, y] == p && _board[x + 1, y - 1] == p && _board[x + 2, y - 2] == p && _board[x + 3, y - 3] == p)
//                {
//                    return true;

//                }

//                if (x == 3)
//                {
//                    x = -1;
//                    y++;
//                }
//                x++;
//            }

//            x = 0;
//            y = 0;
//            while (y < 3 && x <= 3)
//            {
//                if (_board[x, y] == p && _board[x + 1, y + 1] == p && _board[x + 2, y + 2] == p && _board[x + 3, y + 3] == p)
//                {
//                    return true;

//                }

//                if (x == 3)
//                {
//                    x = -1;
//                    y++;
//                }
//                x++;
//            }


//            return false;

//        }

//        private static string NamePlayerOne()
//        {
//            Console.WriteLine("Spieler Eins bitte gib Deinen Namen ein!");
//            string playerOne = Console.ReadLine();
//            return playerOne;
//        }
//        private static string NamePlayerTwo()
//        {
//            Console.WriteLine("Spieler Zwei bitte gib Deinen Namen ein!");
//            string playerTwo = Console.ReadLine();
//            return playerTwo;
//        }

//        private void CreateEmptyField()
//        {
//            for (var x = 0; x < WIDTH; x++)
//            {
//                for (var y = 0; y < HEIGHT; y++)
//                {
//                    _board[x, y] = Player.None;
//                }
//            }
//        }
//        private bool HasPlayer4InColumn()
//        {
//            for (int column = 0; column < HEIGHT; column++)
//            {
//                int amount = 0;
//                Player prev = Player.None;
//                for (int row = 0; row < WIDTH; row++)
//                {
//                    Player current = _board[row, column];
//                    if (row != 0)
//                    {
//                        if (row.Equals(prev) && !row.Equals(Player.None))
//                        {
//                            amount++;
//                            if (amount == 4) return true;
//                        }
//                        else
//                        {
//                            prev = current;
//                            amount = 0;
//                        }
//                    }
//                }
//            }
//            return false;
//        }

//        private bool HasPlayer4InRow()
//        {
//            for (int row = 0; row < WIDTH; row++)
//            {
//                int amount = 0;
//                Player prev = Player.None;
//                for (int column = 0; column < HEIGHT; column++)
//                {
//                    Player current = _board[row, column];
//                    if (column != 0)
//                    {
//                        if (current.Equals(prev) && !current.Equals(Player.None))
//                        {
//                            amount++;
//                            if (amount == 4) return true;
//                        }
//                        else
//                        {
//                            prev = current;
//                            amount = 0;
//                        }
//                    }
//                }
//            }
//            return false;
//            //int y = 0;
//            //int sameFields = 0;
//            //for (int x = 0;!(x == 6 && y == 5);x++ )
//            //{
//            //    if(_board[x,y] == p && _board[x+1,y] == p)
//            //    {
//            //        sameFields++;
//            //        if (sameFields == 4)
//            //        {
//            //            return true;
//            //        }
//            //    }

//            //    if(x == 6)
//            //    {
//            //        x = -1;
//            //        y++;
//            //    }

//            //}
//            //return false;
//        }
//    }
//}