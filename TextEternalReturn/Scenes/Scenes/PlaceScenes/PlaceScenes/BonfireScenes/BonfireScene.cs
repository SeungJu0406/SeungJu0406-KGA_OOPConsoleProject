using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Items.Foods;
using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes.Scenes.PlaceScenes.PlaceScenes.BonfireScenes
{
    internal class BonfireScene : PlaceScene
    {
        enum Pos { Inventory, Cooking, CookingCount, Exit, SIZE }
        int cookingCount;
        int maxCookingCount;
        Point[] points;
        FoodFactory foodFactory = new FoodFactory();
        Food[] dishs;
        Food dish;
        public BonfireScene(Player player) : base(player)
        {
            SceneID = (int)SceneType.BonFireScene;
            points = new Point[(int)Pos.SIZE];
            points[(int)Pos.Inventory] = new Point() { x = X, y = Y };
            points[(int)Pos.Exit] = new Point() { x = X + 20, y = Y };
            points[(int)Pos.Cooking] = new Point() { x = X, y = Y + 1 };
            points[(int)Pos.CookingCount] = new Point() { x = X, y = Y + 3 };
            cookingCount = 0;
            maxCookingCount = 5;
            
        }
        public override void Enter()
        {
            Console.Clear();
            curPoint = points[(int)Pos.Inventory];
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
            SetCursor(points[(int)Pos.CookingCount]);
            if (cookingCount > 5)
            {

                Console.Write($"{dish.name}");
                Console.ResetColor();
                Console.WriteLine("를 만들었습니다.");
            }
            else
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
            // 엔딩화면 시작화면 마무리
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
