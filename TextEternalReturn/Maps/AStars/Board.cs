using System.Linq;

namespace TextEternalReturn.Maps.AStars
{
    public class Board
    {
        public Block[,] board { get; private set; }
        public int sizeX { get; private set; }
        public int sizeY { get; private set; }
        public int wallCount {  get; private set; }
        public void SetBoard(int[,] maps)
        {
            int sizeX = maps.GetLength(1);
            int sizeY = maps.GetLength(0);
            board = new Block[sizeX, sizeY];
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    board[y, x] = new Block(x, y);
                    if (maps[y, x] == 1){
                        board[y, x].wall = true;
                        wallCount++;
                    }
                   
                }
            }
            this.sizeX = sizeX;
            this.sizeY = sizeY;
        }
        public int CountWall()
        {
            return wallCount;
        }
        public void Clear()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j].Clear();
                }
            }
        }
        public bool Exist(Block block)
        {
            return Exist(block.x, block.y);
        }
        public bool Exist(int x, int y)
        {
            if (0 <= x && x < sizeX &&
                 0 <= y && y < sizeY)
                return true;
            return false;
        }
        public List<Block> GetArroundBlock(Board board, Block current)
        {
            List<Block> around = new List<Block>();
            if (Exist(current.y - 1, current.x))// 상단
            {
                Block Block = board.board[current.y - 1, current.x];
                    around.Add(Block);
            }
            if (Exist(current.y, current.x - 1))// 좌측
            {
                Block Block = board.board[current.y, current.x - 1];
                    around.Add(Block);
            }
            if (Exist(current.y, current.x + 1))// 우측
            {
                Block Block = board.board[current.y, current.x + 1];
                    around.Add(Block);
            }
            if (Exist(current.y + 1, current.x))// 하단
            {
                Block Block = board.board[current.y + 1, current.x];
                    around.Add(Block);
                }
            around.RemoveAll(b => b.wall);
            return around;
        }

    }
}
