namespace TextEternalReturn.Maps.AStars
{
    public class AStar
    {
        public static Block GetAStarFinding(Board board, Block start, Block finish)
        {       
            if(board.Exist(start) && board.Exist(finish))
            {
                // 맵 클리어
                board.Clear();
                // 해당 점을 현재위치로 정함
                Block current = start;
                // 주변 4방향의 갈수있는가? 를 구함
                List<Block> around=board.GetArroundBlock(board, current);
                // 갈수있는곳의 F값을 구함
                FuncHeuristics(around, current, finish);
                // F값이 가장 작은곳을 다음 블럭으로 정함
                current = GetNextBlock(around);
                // 다음 블럭의 이전을 시작 블럭으로 바꾸고
                // 시작 블럭의 다음을 다음블럭으로 정함
                current.prev.next = current;
            }
            return start;
        }
        private static Block GetNextBlock(List<Block> OpenArround)
        {
            Block result = null;
            for (int i = 0; i < OpenArround.Count; i++)
            {
                if (result == null || result.F > OpenArround[i].F)
                    result = OpenArround[i];
            }
            return result;
        }
        private static Block GetNextBlock(List<Block> OpenArround, Block current)
        {
            Block result = null;
            for (int i = 0; i < OpenArround.Count; i++)
            {
                if (result == null || result.F > OpenArround[i].F)
                    result = OpenArround[i];
            }
            return result;
        }
        private static void FuncHeuristics(List<Block> around, Block current, Block finish)
        {
            for(int i = 0; i < around.Count; i++)
            {
                Block block = around[i];
                block.G = 10;
                block.H = (Math.Abs(finish.x - around[i].x) + Math.Abs(finish.y - around[i].y)) * 10;
                block.prev = current;
            }
        }
    }
}
