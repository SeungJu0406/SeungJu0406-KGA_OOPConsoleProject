using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Players;
using TextEternalReturn.Items.Foods;
using TextEternalReturn.Items.Foods.Foods;

namespace TextEternalReturn.Scenes.Scenes
{
    public class FishingScene : Scene
    {
        enum Pos { Inventory, Fishing, FishingCount, Exit, SIZE}
        Point[] points;
        int FishingCount;
        int MaxFishingCount;

        Food[] fishs;
        Food caughtFish;
        public FishingScene(Player player) : base(player)
        {
            points = new Point[(int)Pos.SIZE];
            points[(int)Pos.Inventory] = new Point() { x = X, y = Y };
            points[(int)Pos.Exit] = new Point() { x = X + 20, y = Y };
            points[(int)Pos.Fishing] = new Point() { x = X, y = Y + 1 };
            points[(int)Pos.FishingCount] = new Point() { x = X, y = Y + 3 };
            FishingCount = 0;
            MaxFishingCount = 5;
            curPoint= points[(int)Pos.Inventory];
            fishs = new Food[] { new Salmon(), new CodFish() };
        }
        public override void Enter()
        {
            Console.Clear();
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
            if (FishingCount >= 5) 
            {

                Console.Write($"{/*생선 이름*/caughtFish.name}");
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
            }
                                      
        }
        protected override void PushKeyZ()
        {
            
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
            if(curPoint.x == points[(int)Pos.Exit].x &&
               curPoint.y == points[(int)Pos.Exit].y)
            {
                curPoint = temp;
            }
        }
        protected override void MoveRightCursor()
        {
            if(curPoint.x != points[(int)Pos.Exit].x ||
                curPoint.y != points[(int)Pos.Exit].y)
            {
                temp = curPoint;
                curPoint = points[(int)Pos.Exit];
                
            }
        }
        #endregion
        
    }
}
