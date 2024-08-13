using TextEternalReturn.Items;
using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes.Scenes
{
    internal class InventoryScene : Scene
    {
        enum CursorPoint { FisrtItem, LastItem ,Exit, SIZE }
        List<Item> inventory;
        int index = 0;
        Point[] points;
        public InventoryScene(Player player) : base(player)
        {
            this.inventory = player.inventory.inventory;
            points = new Point[3];
            points[(int)CursorPoint.FisrtItem] = new Point() { x = 0, y = 4 };
            int X = points[(int)CursorPoint.FisrtItem].x;
            int Y = points[(int)CursorPoint.FisrtItem].y;
            points[(int)CursorPoint.LastItem] = new Point() { x = 0, y = inventory.Count + (Y-1) };
            points[(int)CursorPoint.Exit] = new Point() { x = 20, y = Y };
            
            curPoint = points[(int)CursorPoint.FisrtItem];
        }
        public override void Render()
        {
            Console.Clear();
            PrintStatus();
            PrintInventory();
        }
        public override void Update()
        {
            UpdateKey();
        }
        public override void Enter()
        {
            Console.Clear();
        }
        public override void Exit()
        {

        }
        private void PrintInventory()
        {           
            SetCursor(points[(int)CursorPoint.FisrtItem]);
            foreach (Item item in inventory)
            {
                Console.WriteLine($"▷ {item.name}");
            }
            SetCursor(points[(int)CursorPoint.Exit]);
            Console.WriteLine("▷ 나가기");
            SetCursor(curPoint);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("▶");
            Console.ResetColor();
        }
        private void UpdateKey()
        {
            switch (consoleKey)
            {
                case ConsoleKey.UpArrow:
                    MoveUpCursor();
                    break;
                case ConsoleKey.DownArrow:
                    MoveDownCursor();
                    break;
                case ConsoleKey.RightArrow:
                    MoveRightCursor();
                    break;
                case ConsoleKey.LeftArrow:
                    MoveLeftCursor();
                    break;
                case ConsoleKey.Z:
                    PushKeyZ();
                    break;
                default:
                    break;
            }
        }
        private void PushKeyZ() 
        {
            if(curPoint.x == points[(int)CursorPoint.Exit].x && curPoint.y == points[(int)CursorPoint.Exit].y)
            {
                game.ChangeScene(SceneType.ChoiceScene);
            }
            else
            {
                if (inventory.Count>0) 
                {
                    int key = curPoint.y - points[(int)CursorPoint.FisrtItem].y;
                    player.UseItem(key);
                    MoveUpCursor();            
                }
                if (inventory.Count == 0)
                {
                    MoveRightCursor();
                }
            }
        }
        #region 커서 움직임
        private void MoveUpCursor()
        {
            if (curPoint.y > points[(int)CursorPoint.FisrtItem].y)
            {
                curPoint.y -= 1;
            }
        }
        private void MoveDownCursor()
        {
            if (curPoint.y < points[(int)CursorPoint.LastItem].y)
            {
                curPoint.y += 1;
            }
        }
        Point temp;
        private void MoveRightCursor()
        {
            if (curPoint.x != points[(int)CursorPoint.Exit].x ||
               curPoint.y != points[(int)CursorPoint.Exit].y)
            {
                temp = curPoint;
                curPoint = points[(int)CursorPoint.Exit];
            }
        }
        private void MoveLeftCursor()
        {
            if (curPoint.x == points[(int)CursorPoint.Exit].x &&
                curPoint.y == points[(int)CursorPoint.Exit].y)
            {
                curPoint = temp;
            }
        }
        #endregion
        private void SetCursor(Point cursorPoint)
        {
            Console.SetCursorPosition(cursorPoint.x, cursorPoint.y);
        }
    }
}
