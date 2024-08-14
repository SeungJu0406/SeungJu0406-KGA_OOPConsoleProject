namespace TextEternalReturn.Maps.AStars
{
    public class AStar
    {
        public static Block GetAStarFinding(Board board, Block start, Block finish)
        {
            if (board.Exist(start) && board.Exist(finish))
            {
                board.Clear();
                List<Block> OpenList = new List<Block>();
                List<Block> CheckList = new List<Block>();
                start.H = (Math.Abs(finish.x - start.x) + Math.Abs(finish.y - start.y)) * 10;
                Block current = start;
                while (current != null)
                {
                    List<Block> arround = board.GetArroundBlock(board, current);
                    List<Block> OpenAround = new List<Block>();
                    foreach (Block block in arround)
                    {
                        FuncHeuristics(block, current, finish, out int aroundG, out int aroundH);
                        if(aroundG + aroundH <= current.F) // 해당 블럭의 F값이 더 작을 경우 OpenList에서 제거
                        {
                            OpenList.Remove(block);
                            block.isOpen = false;
                        }
                        if (!block.isOpen && !block.isCheck)
                        {
                            block.G = aroundG;
                            block.H = aroundH;
                            block.prev = current;
                            block.isOpen = true;
                            OpenList.Add(block);
                            OpenAround.Add(block);
                        }
                    }
                    current.isCheck = true;
                    if (OpenList.Remove(current))
                        CheckList.Add(current);
                    if (OpenAround.Count > 0)
                    {
                        current = GetNextBlock(OpenAround, current); // F값이 가장 낮은값 선정
                    }
                    else
                    {
                        current = null;
                    }
                    if (current == finish)
                        break;
                    if (current == null)
                    {
                        current = GetNextBlock(OpenList); // 만약 주변이 막힌길이라면 갈수있던곳중 가장 F가 낮았던 블럭으로 이동
                    }
                }
                if (current != finish)
                    return null;
                while (current != start)
                {
                    current.prev.next = current;
                    current = current.prev;
                }
                return start;
            }
            return null;
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
            if (result.F > current.F)
                result = null;
            return result;
        }
        // 새로구한 F값이 더 높으면 다시 그값으로 F값을 넣게 바꿔야함
        private static void FuncHeuristics(Block around, Block current, Block finish, out int aroundG, out int aroundH)
        {
            aroundG = around.G;
            aroundH = around.H;
            //bool isDiagonalBlock = around.x - current.x != 0 && around.y - current.y != 0;
            aroundG = current.G + (/*isDiagonalBlock ? 14 :*/ 10);
            aroundH = (Math.Abs(finish.x - around.x) + Math.Abs(finish.y - around.y)) * 10;
        }
    }
}
