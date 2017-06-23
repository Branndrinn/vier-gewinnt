using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    class GetBoardSizeInts
    {
        public static int GetBoardHeight()
        {
            int height = int.MaxValue;
            string line;
            Console.WriteLine();
            do
            {
                Console.WriteLine("Bitte geben Sie eine Zahl ein um die Höhe des Spielfeldes zu definieren");
                Console.WriteLine("Minimal: 4");
                Console.WriteLine("maximal: 25");
                line = Console.ReadLine();
                Console.Clear();
                int.TryParse(line, out height);

                if (!int.TryParse(line, out height))
                {
                    Console.WriteLine("Bitte geben Sie eine Zahl ein");
                }

                else if (height < 4)
                {
                    Console.WriteLine("Das Spielfeld darf nicht niedriger als 4 sein");
                }

                else if (height > 25)
                {
                    Console.WriteLine("Das Spielfeld darf nicht höher sein als 12 sein");
                }

            }
            while (height < 4 || height > 25);
            return height;
        }
        public static int GetBoardWidth()
        {
            int width = int.MaxValue;
            string line;

            Console.WriteLine();
            do
            {

                Console.WriteLine("Bitte geben Sie eine Zahl ein um die Breite des Spielfeldes zu definieren");
                Console.WriteLine("Minimal: 4");
                Console.WriteLine("Maximal: 45");
                line = Console.ReadLine();
                Console.Clear();
                int.TryParse(line, out width);

                if (!int.TryParse(line, out width))
                {
                    Console.WriteLine("Bitte geben Sie eine Zahl ein");
                }

                else if (width < 4)
                {
                    Console.WriteLine("Das Spielfeld darf nicht schmaler 4 breit sein");
                }

                else if (width > 45)
                {
                    Console.WriteLine("Das Spielfeld darf nicht breiter als 45 sein");
                }
            }
            while (width < 4 || width > 45);
            return width;
        }
    }
}
