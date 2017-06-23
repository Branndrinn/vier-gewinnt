using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    class ConnectFourGame
    {
        public static void Play()
        {
            int width = GetBoardSizeInts.GetBoardWidth();
            int height = GetBoardSizeInts.GetBoardHeight();
            Board b = new Board(height, width);
            BoardPrinter bp = new BoardPrinter(b);
            FlashingPlayerCoins fpc = new FlashingPlayerCoins(bp);
            PlayerCollector pc = new PlayerCollector(bp);
            GameLogic gl = new GameLogic(b, pc, fpc);
            pc.Collect();
            bp.Print();
            gl.DoTurnsUntilWinn();
        }
    }
}
