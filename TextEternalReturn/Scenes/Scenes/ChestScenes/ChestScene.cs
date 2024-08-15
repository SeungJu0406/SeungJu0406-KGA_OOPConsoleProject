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
        protected Point[] chestPoints;
        public ChestScene(Player player) : base(player)
        {
            chestPoints = new Point[(int)Pos.SIZE];
            chestPoints[(int)Pos.FirstItem] = new Point() { x = X, y = Y };
            chestPoints[(int)Pos.LastItem] = new Point() { x = X, y = Y + items.Count - 1 };
            chestPoints[(int)Pos.Exit] = new Point() { x = X + 20, y = Y };
            SetItem();
            curPoint = chestPoints[(int)Pos.FirstItem];
        }
        public override void Render()
        {
            PrintStatus();
            PrintChest();
        }
        public override void Update()
        {
            UpdateKey();
        }
        public override void Enter()
        {
            Console.Clear();
            chestPoints[(int)Pos.LastItem].y = Y + items.Count - 1;
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
            Point itemPos = chestPoints[(int)Pos.FirstItem];
            foreach (Item item in items)
            {
                SetCursor(itemPos);
                Console.WriteLine($"▷ {item.name}");
                itemPos.y++;
            }
            SetCursor(chestPoints[(int)Pos.Exit]);
            Console.WriteLine("▷ 나가기");
            SetCursor(curPoint);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("▶");
            Console.ResetColor();
        }
        protected override void MoveUpCursor()
        {
            if (curPoint.y > chestPoints[(int)Pos.FirstItem].y)
            {
                curPoint.y -= 1;
            }
        }
        protected override void MoveDownCursor()
        {
            if(curPoint.y < chestPoints[(int)Pos.LastItem].y)
            {
                curPoint.y += 1;
            }
        }
        Point temp;
        protected override void MoveRightCursor()
        {
            if (curPoint.x != chestPoints[(int)Pos.Exit].x ||
               curPoint.y != chestPoints[(int)Pos.Exit].y)
            {
                temp = curPoint;
                curPoint = chestPoints[(int)Pos.Exit];
            }
        }
        protected override void MoveLeftCursor()
        {
            if (curPoint.x == chestPoints[(int)Pos.Exit].x &&
                curPoint.y == chestPoints[(int)Pos.Exit].y)
            {
                if (items.Count > 0)
                    curPoint = temp;
            }
        }
    }
}
