using AstarNote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEternalReturn.Maps
{
    public class Map
    {
        int[,] maps;
        Board board;
        public Map()
        {
            maps = new int[7,7];
            board = new Board();
            board.SetBoard(maps);
        }
    }
}
