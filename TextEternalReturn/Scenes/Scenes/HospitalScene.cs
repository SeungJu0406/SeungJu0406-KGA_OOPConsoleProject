using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes.Scenes
{
    internal class HospitalScene : Scene
    {
        enum Pos { Place ,Chest, Rest, MoveMap, Inventory, SIZE }
        Point[] points = new Point[(int)Pos.SIZE];
        public HospitalScene(Player player) : base(player)
        {
            points[(int)Pos.Place] = new Point() { x = X, y = Y + 0 };
            points[(int)Pos.Chest] = new Point() { x = X, y = Y + 2 };
            points[(int)Pos.Rest] = new Point() { x = X, y = Y + 3 };
            points[(int)Pos.MoveMap] = new Point() { x = X, y = Y + 4 };
            points[(int)Pos.Inventory] = new Point() { x = X, y = Y + 5 };
            curPoint = points[(int)Pos.Chest];
        }
        public override void Render()
        {
            PrintStatus();
            PrintHospital();
        }
        public override void Update()
        {
            UpdateKey();
        }
        public override void Enter()
        {
            Console.Clear();
        }
        public override void Exit()
        {
            game.prevScene = this;
        }
        private void PrintHospital()
        {
            SetCursor(points[(int)Pos.Place]);
            Console.WriteLine(" 병 원 ");
            SetCursor(points[(int)Pos.Chest]);
            Console.WriteLine("▷ 상자 열기");
            SetCursor(points[(int)Pos.Rest]);
            Console.WriteLine("▷ 휴식");
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
                game.ChangeScene(SceneType.ChestScene);
            }
            else if (curPoint.y == points[(int)Pos.Rest].y)
            {
                player.Rest();
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
        #region 커서 이동
        protected override void MoveUpCursor()
        {
            if (curPoint.y > points[(int)Pos.Chest].y)
            {
                curPoint.y -= 1;
            }
        }
        protected override void MoveDownCursor()
        {
            if (curPoint.y < points[(int)Pos.Inventory].y)
            {
                curPoint.y += 1;
            }
        }
        protected override void MoveLeftCursor()
        {
            base.MoveLeftCursor();
        }
        protected override void MoveRightCursor()
        {
            base.MoveRightCursor();
        }
        #endregion
        private void SetCursor(Point cursorPoint)
        {
            Console.SetCursorPosition(cursorPoint.x, cursorPoint.y);
        }
    }
}
