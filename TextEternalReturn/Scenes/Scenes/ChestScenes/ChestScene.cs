using System.Runtime.InteropServices;
using TextEternalReturn.Items;
using TextEternalReturn.Items.Items;
using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes.Scenes.ChestScenes
{
    internal class ChestScene : Scene
    {
        protected enum Pos { FirstItem, LastItem, Exit, SIZE }
        protected ItemFactory itemFactory = new ItemFactory();
        protected List<Item> items = new List<Item>(8);
        protected Point[] points;
        public ChestScene(Player player) : base(player)
        {
            points = new Point[(int)Pos.SIZE];
            points[(int)Pos.FirstItem] = new Point() { x = X, y = Y };
            points[(int)Pos.LastItem] = new Point() { x = X, y = Y + items.Count - 1 };
            points[(int)Pos.Exit] = new Point() { x = X + 20, y = Y };
            SetItem();
            curPoint = points[(int)Pos.FirstItem];
        }
        public override void Render()
        {
            Console.Clear();
            PrintStatus();
            PrintCollectItem();
            PrintChest();
        }
        public override void Update()
        {
            UpdateKey();
        }
        public override void Enter()
        {
            Console.Clear();
            points[(int)Pos.LastItem].y = Y + items.Count - 1;
        }
        public override void Exit()
        {
            game.prevScene = this;
        }

        protected void SetItem()
        {
            for (int i = 0; i < 7; i++)
            {
                items.Add(itemFactory.RandomCreate());
            }
        }
        protected void PrintChest()
        {
            Point itemPos = points[(int)Pos.FirstItem];
            foreach (Item item in items)
            {
                SetCursor(itemPos);
                Console.WriteLine($"▷ {item.name}");
                itemPos.y++;
            }
            SetCursor(points[(int)Pos.Exit]);
            Console.WriteLine("▷ 나가기");
            SetCursor(curPoint);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("▶");
            Console.ResetColor();
        }
        protected override void PushKeyZ()
        {
            if(curPoint.x == points[(int)Pos.Exit].x)
            {
                SceneType prevScene = (SceneType) Array.IndexOf(game.sceneList, game.prevScene);
                game.ChangeScene(prevScene);
            }
            else if (curPoint.x == points[(int)Pos.FirstItem].x)
            {
                RemoveItem();
            }
        }
        private void RemoveItem()
        {
            int itemIndex = curPoint.y - points[(int)Pos.FirstItem].y;
            player.craftInventory.GetItem(items[itemIndex]);
            items.RemoveAt(itemIndex);
            MoveUpCursor();
            points[(int)Pos.LastItem].y--;
            if (items.Count == 0)
                MoveRightCursor();
        }
        #region 커서 이동
        protected override void MoveUpCursor()
        {
            if (curPoint.x == points[(int)Pos.LastItem].x &&
                curPoint.y > points[(int)Pos.FirstItem].y)
            {
                curPoint.y -= 1;
            }
        }
        protected override void MoveDownCursor()
        {
            if(curPoint.x == points[(int)Pos.LastItem].x &&
                curPoint.y < points[(int)Pos.LastItem].y)
            {
                curPoint.y += 1;
            }
        }
        Point temp;
        protected override void MoveRightCursor()
        {
            if (curPoint.x != points[(int)Pos.Exit].x ||
               curPoint.y != points[(int)Pos.Exit].y)
            {
                temp = curPoint;
                curPoint = points[(int)Pos.Exit];
            }
        }
        protected override void MoveLeftCursor()
        {
            if (curPoint.x == points[(int)Pos.Exit].x &&
                curPoint.y == points[(int)Pos.Exit].y)
            {
                if (items.Count > 0)
                    curPoint = temp;
            }
        }
        #endregion

    }
}
