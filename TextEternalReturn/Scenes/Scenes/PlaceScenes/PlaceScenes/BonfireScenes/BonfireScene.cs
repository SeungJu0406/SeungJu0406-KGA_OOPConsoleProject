using System.Runtime.CompilerServices;
using TextEternalReturn.Items.Foods;
using TextEternalReturn.Items.Foods.Foods;
using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes.Scenes.PlaceScenes.PlaceScenes.BonfireScenes
{
    internal class BonfireScene : PlaceScene
    {
        enum Pos { Inventory, Cooking, SelectFood, CookingCount, Exit, SIZE }
        int cookingCount;
        int maxCookingCount;
        Point[] points;
        FoodFactory foodFactory = new FoodFactory();
        Food[] dishs;
        Food dish;
        Food ingredient;
        BonfireInventory bonfireInventory;
        public BonfireScene(Player player) : base(player)
        {
            
            SceneID = (int)SceneType.BonFireScene;
            points = new Point[(int)Pos.SIZE];
            points[(int)Pos.Inventory] = new Point() { x = X, y = Y };
            points[(int)Pos.Exit] = new Point() { x = X + 20, y = Y };
            points[(int)Pos.Cooking] = new Point() { x = X, y = Y + 1 };
            points[(int)Pos.SelectFood] = new Point() { x = X, y = Y + 2 };
            points[(int)Pos.CookingCount] = new Point() { x = X, y = Y + 3 };
            maxCookingCount = 5;
            
        }
        public override void Enter()
        {
            Console.Clear();
            bonfireInventory = game.sceneList[(int)SceneType.BonFireInventory] as BonfireInventory;
            bonfireInventory.OnSelect += ReturnFood;
            curPoint = points[(int)Pos.Inventory];
            cookingCount = 0;
        }
        public override void Render()
        {
            base.Render();
            PrintBonfire();
        }
        public override void Update()
        {
            base.Update();
        }
        public override void Exit()
        {
            base.Exit();
            dish = null;
            ingredient = null;
        }
        private void PrintBonfire()
        {
            SetCursor(points[(int)Pos.Inventory]);
            Console.WriteLine("▷ 아이템 확인");
            SetCursor(points[(int)Pos.Exit]);
            Console.WriteLine("▷ 나가기");
            SetCursor(points[(int)Pos.Cooking]);
            Console.WriteLine("▷ 요리하기");
            Console.ForegroundColor = ConsoleColor.Green;
            SetCursor(curPoint);
            Console.WriteLine("▶");
            Console.ResetColor();
            SetCursor(points[(int)Pos.SelectFood]);
            
            if (ingredient != null)
            {          
                Console.Write("선택한 재료: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{ingredient.name}");
            }
            else
                Console.WriteLine("                         ");
            SetCursor(points[(int)Pos.CookingCount]);
            if (cookingCount > maxCookingCount)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{dish.name}");
                Console.ResetColor();
                Console.WriteLine("를 만들었습니다.");
            }
            else if (ingredient != null)
            {
                for (int i = 0; i < cookingCount; i++)
                {
                    Console.Write("■");
                }
                Console.ResetColor();
                for (int i = 0; i < maxCookingCount - cookingCount; i++)
                {
                    Console.Write("□");
                }
                Console.WriteLine("             ");
            }
            else
                Console.WriteLine("                             ");
        }
        protected override void PushKeyZ()
        {
            if (curPoint.x == points[(int)Pos.Inventory].x &&
                curPoint.y == points[(int)Pos.Inventory].y)
            {
                game.ChangeScene(SceneType.InventoryScene);
            }
            else if (curPoint.x == points[(int)Pos.Exit].x &&
                    curPoint.y == points[(int)Pos.Exit].y)
            {
                game.ChangeScene(SceneType.MapScene);
            }
            else if (curPoint.x == points[(int)Pos.Cooking].x &&
                    curPoint.y == points[(int)Pos.Cooking].y)
            {
                Cooking();
            }
        }
        private void Cooking()
        {
            // 모닥불 인벤토리로 이동 -> 음식 선택 -> z를 눌러 게이지를채우고 다 채우면 음식 완성
            if (ingredient == null)
            {
                cookingCount = 0;
                game.ChangeScene(SceneType.BonFireInventory);
            }
            cookingCount++;
            if (cookingCount > maxCookingCount)
            {
                if (ingredient is Salmon)
                    dish = foodFactory.Create(FoodType.SalmonSteak);
                else if (ingredient is CodFish)
                    dish = foodFactory.Create(FoodType.FishCuttlet);
                else if (ingredient is Meat)
                    dish = foodFactory.Create(FoodType.Steak);
                player.GetFood(dish);
                ingredient = null;
            }
        }
        private void ReturnFood(Food food)
        {
            ingredient = food;
        }
        #region 커서 이동
        protected override void MoveUpCursor()
        {
            if (curPoint.x == points[(int)Pos.Inventory].x &&
                curPoint.y > points[(int)Pos.Inventory].y)
            {
                curPoint.y -= 1;
            }
        }
        protected override void MoveDownCursor()
        {
            if (curPoint.x == points[(int)Pos.Cooking].x &&
                curPoint.y < points[(int)Pos.Cooking].y)
            {
                curPoint.y += 1;
            }
        }
        Point temp;
        protected override void MoveLeftCursor()
        {
            if (curPoint.x == points[(int)Pos.Exit].x &&
               curPoint.y == points[(int)Pos.Exit].y)
            {
                curPoint = temp;
            }
        }
        protected override void MoveRightCursor()
        {
            if (curPoint.x != points[(int)Pos.Exit].x ||
                curPoint.y != points[(int)Pos.Exit].y)
            {
                temp = curPoint;
                curPoint = points[(int)Pos.Exit];

            }
        }
        #endregion
    }
}
