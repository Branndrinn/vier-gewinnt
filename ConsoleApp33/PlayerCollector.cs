using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectFour
{
    internal class PlayerCollector
    {
        public List<Player> AllPlayer { get; set; }
        public int Players { get; private set; }

        public BoardPrinter Bp { get; set; }

        public PlayerCollector(BoardPrinter bp)
        {
            Bp = bp;
            AllPlayer = new List<Player>();
            int players = PlayerCountRequest();
            Players = players;
        }

        public static readonly ConsoleColor[] Colors = { ConsoleColor.DarkGray, ConsoleColor.Blue, ConsoleColor.Red, ConsoleColor.Magenta, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.White };
        List<ConsoleColor> _colorsList = new List<ConsoleColor>(Colors);

        public void Collect()
        {
            for (int i = 0; i < Players; i++)
            {
                PlayerNameInput(i);
                PlayerColorInput(Colors, i);
            }
        }

        private void PlayerNameInput(int i)
        {
            PlayerPanel();
            Console.WriteLine("Name Spieler " + (i + 1));
            string name;
            do
            {
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Bitte geben sie einen Namen ein.");
                }
            }
            while (string.IsNullOrWhiteSpace(name) || IsNameTaken(AllPlayer, name));

            AllPlayer.Add(new Player(name, ConsoleColor.Black));
        }
        private bool IsNameTaken(List<Player> allPlayer, string name)
        {
            foreach (Player player in allPlayer)
            {
                if (name == player.Name)
                {
                    Console.WriteLine("Es können keinen namen doppelt verwendent werden.");
                    return true;
                }
            }
            return false;
        }
        private int PlayerCountRequest()
        {

            int players = int.MaxValue;
            while (players > Colors.Length)
            {
                Console.Clear();

                string line;
                do
                {
                    if (players < 2)
                    {
                        Console.WriteLine("Alleine zu spielen ist nicht möglich.");
                    }

                    Console.WriteLine("Wieviele Spieler?");
                    Console.WriteLine("Minimal: 2");
                    Console.WriteLine("Maximal: " + Colors.Length);
                    if (players > Colors.Length && players != int.MaxValue)
                        Console.WriteLine("Zuviele Spieler Maximal: " + Colors.Length);
                    line = Console.ReadLine();
                }
                while (!(int.TryParse(line, out players) && players > 1));



            }
            return players;
        }
        private void PlayerColorInput(ConsoleColor[] Colors, int i)
        {
            ColorBoard();
            string colorSelect;
            int colorNum = -1;
            if (_colorsList.Count == 1)
            {
                AllPlayer[i].Color = _colorsList[0];
                _colorsList.Remove(_colorsList[0]);
                Console.Clear();
                Console.WriteLine("Letzte verfügbare Farbe wurde dem Spieler " + AllPlayer[i].Name + " zugewiesen");
            }
            else
            {
                do
                {
                    if (colorNum != -1 && (colorNum < 1 || colorNum > Colors.Length))
                    {
                        Console.WriteLine("Es muss eine der gegebenen farben gewählt werden!");
                    }

                    colorSelect = Console.ReadLine();

                } while (!(int.TryParse(colorSelect, out colorNum) && colorNum > 0 && colorNum <= _colorsList.Count));
                ConsoleColor color = _colorsList[colorNum - 1];
                AllPlayer[i].Color = color;
                _colorsList.Remove(color);
            }
        }
        private void PlayerPanel()
        {
            Console.Clear();
            foreach (Player player in AllPlayer)
            {
                string colorName = ("" + player.Color);
                Console.Write("Spieler " + player.Name + " ");
                ConsoleHelper.WriteLineColoredBackground(player.Color, player.Color + "");
            }
        }
        private void ColorBoard()
        {
            Console.WriteLine("Farbe:");
            for (int z = 0; z < _colorsList.Count; z++)
            {
                ConsoleColor color = _colorsList[z];
                Console.Write(z + 1 + ") ");

                Console.BackgroundColor = color;
                if (Console.BackgroundColor != ConsoleColor.Black)
                {
                    Console.WriteLine(color);
                }
                else
                {
                    Console.WriteLine();
                }
                Console.ResetColor();
            }
        }



        public void PlayersTurn(Player player)
        {
            Console.Clear();
            Console.WriteLine();
            Bp.Print();
            Console.WriteLine();

            string line;

            int choice = int.MaxValue;
            do
            {
                Console.BackgroundColor = player.Color;
                Console.WriteLine("Spieler " + player.Name + " wirf einen Spielstein in eine Spielstein in eine von Dir gewünschte Spalte, in dem du eine Zahl von 1 bis " + Bp.Board.Width + " eingibst");
                Console.ResetColor();
                line = Console.ReadLine();


                if (int.TryParse(line, out choice))
                {
                    if (choice <= 0)
                    {
                        line = choice.ToString();
                        line = "null is shit";
                    }

                    else if (choice > Bp.Board.Width)
                    {
                        line = choice.ToString();
                        line = "other numbers too";
                    }
                }
                if (!int.TryParse(line, out choice))

                    Console.WriteLine("bitte geben Sie einen der gegebenen Zahlen ein");

                else if (int.TryParse(line, out choice) && choice > Bp.Board.Width)
                    Console.WriteLine("Die eingegebene Zahl ist zu groß");

                else if (int.TryParse(line, out choice) && choice == 0)
                    Console.WriteLine("Die eingegebene Zahl darf nicht 0 sein");

                else if (int.TryParse(line, out choice) && choice < 0)
                    Console.WriteLine("Negative Zahlen sind nicht geschtatet");

                else if (int.TryParse(line, out choice) && Bp.Board._board[choice - 1][0] != null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Die Spalte ist voll");
                    Console.ResetColor();
                }

            }
            while (!int.TryParse(line, out choice) || choice < 0 || choice - 1 > Bp.Board.Width || Bp.Board._board[choice - 1][0] != null);

            for (int i = Bp.Board.Height - 1; i >= 0; i--)
            {
                if (Bp.Board._board[choice - 1][i] == null)
                {
                    Bp.Board._board[choice - 1][i] = player;
                    break;
                }
            }


        }
        public bool RePlay()
        {
            int counter = 0;
            string choice;
            do
            {
                Console.WriteLine("Wollen Sie nochmal spielen?");
                Console.WriteLine("Wenn Sie das so wünschen drücken Sie bitte die Taste J für ja");
                Console.WriteLine("Wenn Ihr Verlangen gestillt ist drücken Sie bitte die Taste N für nein");
                choice = Console.ReadLine();

                if (counter > 5)
                    Console.WriteLine("Verdammt, bist du blöd? JA ODER NEIN !!!!!");

                else if (!(choice == "j" || choice == "n"))
                {
                    Console.WriteLine("Bitte Wählen Sie zwischen j für ja oder n für nein damit sie weiter spielen oder aufhören können");
                    counter++;
                }
            }

            while (!(choice == "j" || choice == "n"));

            switch (choice.ToLower())
            {
                case "n":
                    return false;
                case "j":
                case "y":
                    return true;
            }
            return false;
        }
    }
}