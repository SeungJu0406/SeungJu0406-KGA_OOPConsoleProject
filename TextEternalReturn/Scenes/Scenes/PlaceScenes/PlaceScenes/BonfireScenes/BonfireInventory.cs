using TextEternalReturn.Items;
using TextEternalReturn.Items.Foods;
using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes.Scenes.PlaceScenes.PlaceScenes.BonfireScenes
{
    internal class BonfireInventory : Scene
    {
        enum Pos { FisrtItem, LastItem, Exit, SIZE }

        public Action<Food> OnSelect;
        List<Food> inventory;
        int index = 0;
        Point[] points = new Point[(int)Pos.SIZE];
        
        public BonfireInventory(Player player) : base(player)
        {
            SceneID = (int)SceneType.InventoryScene;
            this.inventory = player.foodInventory.inventory;
            points[(int)Pos.FisrtItem] = new Point() { x = X, y = Y };
            points[(int)Pos.LastItem] = new Point() { x = X, y = inventory.Count + (Y - 1) };
            points[(int)Pos.Exit] = new Point() { x = X + 20, y = Y };

        }
        public override void Render()
        {
            Console.Clear();
            base.Render();
            PrintInventory();
        }
        public override void Update()
        {
            base.Update();
        }
        public override void Enter()
        {
            Console.Clear();
            curPoint = inventory.Count > 0 ? points[(int)Pos.FisrtItem] : points[(int)Pos.Exit];
            points[(int)Pos.LastItem].y = inventory.Count + (Y - 1);
        }
        public override void Exit()
        {
            game.prevScene = this;
        }
        private void PrintInventory()
        {
            Point itemPos = points[(int)Pos.FisrtItem];
            foreach (Item item in inventory)
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
            if (curPoint.x == points[(int)Pos.Exit].x && curPoint.y == points[(int)Pos.Exit].y)
            {
                game.ChangeScene((SceneType)game.prevScene.SceneID);
            }
            else
            {
                if (inventory.Count > 0)
                {
                    SelectFood();
                }
                if (inventory.Count == 0)
                {
                    MoveRightCursor();
                }
            }
        }
        private void SelectFood()
        {
            int key = curPoint.y - points[(int)Pos.FisrtItem].y;
            if (inventory[key].id < (int)FoodType.SalmonSteak)
            {
                Food ingredient = inventory[key];
                player.foodInventory.ThrowItem(key);
                OnSelect?.Invoke(ingredient);
                game.ChangeScene((SceneType)game.prevScene.SceneID);

            }
        }
        #region 커서 움직임
        protected override void MoveUpCursor()
        {
            if (curPoint.x == points[(int)Pos.LastItem].x &&
                curPoint.y > points[(int)Pos.FisrtItem].y)
            {
                curPoint.y -= 1;
            }
        }
        protected override void MoveDownCursor()
        {
            // 이거 커서가 오른쪽에서 아이템 리스트 배열 개수만큼 내려가는 버그 발견 조건을 추가해야함
            if (curPoint.x == points[(int)Pos.LastItem].x &&
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
                if (inventory.Count > 0)
                    curPoint = temp;
            }
        }
        #endregion
    }
}
