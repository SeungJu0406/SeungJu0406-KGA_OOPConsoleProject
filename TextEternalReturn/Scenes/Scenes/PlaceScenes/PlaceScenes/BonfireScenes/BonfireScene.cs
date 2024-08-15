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
        int maxcookingCount;
        Point[] points;
        FoodFactory foodFactory = new FoodFactory();
        Food[] dishs;
        Food dish;
        public BonfireScene(Player player) : base(player)
        {
            SceneID = (int)SceneType.BonFireScene;
        }
        public override void Render()
        {
            base.Render();
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
            Console.WriteLine("▷ 낚시줄 당기기");
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
                for (int i = 0; i < maxcookingCount - cookingCount; i++)
                {
                    Console.Write("□");
                }
                Console.WriteLine("             ");
            }
        }
        protected override void PushKeyZ()
        {

        }
    }
}
