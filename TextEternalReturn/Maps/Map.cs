using TextEternalReturn.Maps.AStars;

namespace TextEternalReturn.Maps
{
    public class Map
    {
        public int[,] maps { get; private set; }
        public Board board { get; private set; }
        public Block[,] blocks { get; private set; }
        public int sizeX { get; private set; }
        public int sizeY {  get; private set; }
        public Map()
        {
            maps = new int[7, 7]{
                { 0, 0, 0, 0, 0, 0, 0 },
                { 0, 1, 1, 0, 1, 1, 0 },
                { 0, 1, 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 0, 0, 0 },
                { 0, 1, 0, 0, 0, 1, 0 },
                { 0, 1, 1, 0, 1, 1, 0 },
                { 0, 0, 0, 0, 0, 0, 0 },
            };
            sizeX = maps.GetLength(1);
            sizeY = maps.GetLength(0);
            board = new Board();         
            board.SetBoard(maps);
            blocks = board.board;
        }
    }
}
