using TextEternalReturn.Items.Foods;
using TextEternalReturn.Items.Foods.Foods;
using TextEternalReturn.Players;
using TextEternalReturn.Scenes.Scenes.PlaceScenes;

namespace TextEternalReturn.Scenes.Scenes
{
    public class FishingScene : Scene
    {
        enum Pos { Inventory, Fishing, FishingCount, Exit, SIZE }
        Point[] points;
        int FishingCount;
        int MaxFishingCount;
        FoodFactory foodFactory = new FoodFactory();
        Food[] fishs;
        Food caughtFish;
        PlaceScene prevScene;
        public FishingScene(Player player) : base(player)
        {
            SceneID = (int)SceneType.FishingScene;
            points = new Point[(int)Pos.SIZE];
            points[(int)Pos.Inventory] = new Point() { x = X, y = Y };
            points[(int)Pos.Exit] = new Point() { x = X + 20, y = Y };
            points[(int)Pos.Fishing] = new Point() { x = X, y = Y + 1 };
            points[(int)Pos.FishingCount] = new Point() { x = X, y = Y + 3 };
            FishingCount = 0;
            MaxFishingCount = 5;
            curPoint = points[(int)Pos.Inventory];
            fishs = new Food[2];
            fishs[0] = foodFactory.Create(FoodType.Salmon);
            fishs[1] = foodFactory.Create(FoodType.CodFish);
        }
        public override void Enter()
        {
            Console.Clear();
            if(game.prevScene is PlaceScene)
            {
                PlaceScene tempScene = game.prevScene as PlaceScene;
                prevScene = tempScene;
            }
        }

        public override void Exit()
        {
            game.prevScene = this;
        }

        public override void Render()
        {
            base.Render();
            PrintFishing();
        }

        public override void Update()
        {
            base.Update();
        }
        private void PrintFishing()
        {
            SetCursor(points[(int)Pos.Inventory]);
            Console.WriteLine("▷ 아이템 확인");
            SetCursor(points[(int)Pos.Exit]);
            Console.WriteLine("▷ 나가기");
            SetCursor(points[(int)Pos.Fishing]);
            Console.WriteLine("▷ 낚시줄 당기기");
            Console.ForegroundColor = ConsoleColor.Green;
            SetCursor(curPoint);
            Console.WriteLine("▶");
            SetCursor(points[(int)Pos.FishingCount]);
            if (FishingCount > 5)
            {

                Console.Write($"{caughtFish.name}");
                Console.ResetColor();
                Console.WriteLine("를 낚았습니다.");
            }
            else
            {
                for (int i = 0; i < FishingCount; i++)
                {
                    Console.Write("■");
                }
                Console.ResetColor();
                for (int i = 0; i < MaxFishingCount - FishingCount; i++)
                {
                    Console.Write("□");
                }
                Console.WriteLine("             ");
            }

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
                game.ChangeScene((SceneType)prevScene.SceneID);
            }
            else if (curPoint.x == points[(int)Pos.Fishing].x &&
                    curPoint.y == points[(int)Pos.Fishing].y)
            {
                Fishing();
            }
        }
        private void Fishing()
        {
            if(FishingCount > 5)
            {
                FishingCount = 0;
            }
            FishingCount++;
            if(FishingCount > 5)
            {
                caughtFish = fishs[Util.GetRandom(0, fishs.Length - 1)];
                player.GetFood(caughtFish);
            }          
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
            if (curPoint.x == points[(int)Pos.Fishing].x &&
                curPoint.y < points[(int)Pos.Fishing].y)
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
