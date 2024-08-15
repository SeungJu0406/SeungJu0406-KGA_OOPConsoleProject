using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes.Scenes.PlaceScenes.PlaceScenes
{
    internal class HarborScene : PlaceScene
    {
        enum Pos { Place, Chest, Rest, Fishing, MoveMap, Inventory, SIZE }
        Point[] points = new Point[(int)Pos.SIZE];
        public HarborScene(Player player) : base(player)
        {
            SceneID = (int)SceneType.HarborScene;
            points[(int)Pos.Place] = new Point() { x = X, y = Y + 0 };
            points[(int)Pos.Chest] = new Point() { x = X, y = Y + 2 };
            points[(int)Pos.Rest] = new Point() { x = X, y = Y + 3 };
            points[(int)Pos.Fishing] = new Point() { x = X, y = Y + 4 };
            points[(int)Pos.MoveMap] = new Point() { x = X, y = Y + 5 };
            points[(int)Pos.Inventory] = new Point() { x = X, y = Y + 6 };
            curPoint = points[(int)Pos.Chest];
        }
        public override void Render()
        {
            base.Render();
            PrintHarbor();
        }
        public override void Update()
        {
            base.Update();
        }
        private void PrintHarbor()
        {
            SetCursor(points[(int)Pos.Place]);
            Console.WriteLine(" 항 구 ");
            SetCursor(points[(int)Pos.Chest]);
            Console.WriteLine("▷ 상자 열기");
            SetCursor(points[(int)Pos.Rest]);
            Console.WriteLine("▷ 휴식");
            SetCursor(points[(int)Pos.Fishing]);
            Console.WriteLine("▷ 낚시 하기");
            SetCursor(points[(int)Pos.MoveMap]);
            Console.WriteLine("▷ 이동 하기");
            SetCursor(points[(int)Pos.Inventory]);
            Console.WriteLine("▷ 아이템 확인");
            SetCursor(curPoint);
            Console.WriteLine("▶");
        }
        protected override void PushKeyZ()
        {
            if (curPoint.y == points[(int)Pos.Chest].y)
            {
                game.ChangeScene(SceneType.HarborChest);
            }
            else if (curPoint.y == points[(int)Pos.Rest].y)
            {
                player.Rest();
            }
            else if (curPoint.y == points[(int)Pos.Fishing].y)
            {
                game.ChangeScene(SceneType.FishingScene);
            }
            else if (curPoint.y == points[(int)Pos.MoveMap].y)
            {
                game.ChangeScene(SceneType.MapScene);
            }
            else if (curPoint.y == points[(int)Pos.Inventory].y)
            {
                game.ChangeScene(SceneType.InventoryScene);
            }
        }
    }
}
