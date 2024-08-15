using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes.Scenes
{
    public class FishingScene : Scene
    {
        enum Pos { Inventory, Fishing, FishingCount, Exit, SIZE}
        Point[] points;
        int FishingCount;
        int MaxFishingCount;
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

                Console.Write($"{/*생선 이름*/}");
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
        }
        protected override void MoveDownCursor()
        {
        
        }

        protected override void MoveLeftCursor()
        {
            
        }
        protected override void MoveRightCursor()
        {
            
        }
        #endregion
        
    }
}
