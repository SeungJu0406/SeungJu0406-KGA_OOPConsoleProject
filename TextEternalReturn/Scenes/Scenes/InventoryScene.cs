using TextEternalReturn.Items;
using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes.Scenes
{
    internal class InventoryScene : Scene
    {
        enum Pos { FisrtItem, LastItem ,Exit, SIZE }
        List<Item> inventory;
        int index = 0;
        Point[] points = new Point[(int)Pos.SIZE];
        public InventoryScene(Player player) : base(player)
        {
            this.inventory = player.inventory.inventory;           
            points[(int)Pos.FisrtItem] = new Point() { x = X, y = Y };
            points[(int)Pos.LastItem] = new Point() { x = X, y = inventory.Count + (Y-1) };
            points[(int)Pos.Exit] = new Point() { x = X+20, y = Y };
            player.inventory.OnGetItem += CheckGetItem;
            player.inventory.OnRemoveItem += CheckRemoveItem;
                       
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
            curPoint = points[(int)Pos.FisrtItem];
            points[(int)Pos.LastItem].y = inventory.Count + (Y - 1);
        }
        public override void Exit()
        {
            game.prevScene = this;
        }
        private void PrintInventory()
        {
            Point items = points[(int)Pos.FisrtItem];
            foreach (Item item in inventory)
            {
                SetCursor(items);
                Console.WriteLine($"▷ {item.name}");
                items.y++;
            }
            SetCursor(points[(int)Pos.Exit]);
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
            if(curPoint.x == points[(int)Pos.Exit].x && curPoint.y == points[(int)Pos.Exit].y)
            {
                int prevSceneIndex = Array.IndexOf(game.sceneList, game.prevScene);
                game.ChangeScene((SceneType) prevSceneIndex);
            }
            else
            {
                if (inventory.Count>0) 
                {
                    int key = curPoint.y - points[(int)Pos.FisrtItem].y;
                    player.UseItem(key);               
                    MoveUpCursor();            
                }
                if (inventory.Count == 0)
                {
                    MoveRightCursor();
                }
            }
        }
        private void CheckGetItem()
        {
            points[(int)Pos.LastItem].y++;
        }
        private void CheckRemoveItem()
        {
            points[(int)Pos.LastItem].y--;
        }
        #region 커서 움직임
        private void MoveUpCursor()
        {
            if (curPoint.y > points[(int)Pos.FisrtItem].y)
            {
                curPoint.y -= 1;
            }
        }
        private void MoveDownCursor()
        {
            if (curPoint.y < points[(int)Pos.LastItem].y)
            {
                curPoint.y += 1;
            }
        }
        Point temp;
        private void MoveRightCursor()
        {
            if (curPoint.x != points[(int)Pos.Exit].x ||
               curPoint.y != points[(int)Pos.Exit].y)
            {
                temp = curPoint;
                curPoint = points[(int)Pos.Exit];
            }
        }
        private void MoveLeftCursor()
        {
            if (curPoint.x == points[(int)Pos.Exit].x &&
                curPoint.y == points[(int)Pos.Exit].y)
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
