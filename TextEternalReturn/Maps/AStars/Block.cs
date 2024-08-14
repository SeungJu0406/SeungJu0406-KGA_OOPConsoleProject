using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEternalReturn.Maps.AStars
{
    public class Block
    {
        public int x, y;
        public bool wall;
        public int F => G + H;
        public int G;
        public int H;
        public bool isOpen;
        public bool isCheck;
        public Block prev;
        public Block next;
        public Block(int x, int y)
        {
            this.x = x;
            this.y = y;           
        }
        public void SetPrice(int G, int H)
        {
            this.G = G;
            this.H = H;        
        }
        public void Clear()
        {
            G = 0;
            H = 0;
            isOpen = false;
            isCheck = false;
            prev = null;
            next = null;
        }
    }
}
