using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Players;
using static TextEternalReturn.Scenes.Scenes.BattleScene;

namespace TextEternalReturn.Scenes.Scenes.PlaceScenes
{
    public class PlaceScene : Scene
    {
        protected enum Pos { Place, Chest, Rest, MoveMap, Inventory, SIZE }
        protected Point[] points = new Point[(int)Pos.SIZE];
        public PlaceScene(Player player) : base(player)
        {
            points[(int)Pos.Place] = new Point() { x = X, y = Y + 0 };
            points[(int)Pos.Chest] = new Point() { x = X, y = Y + 2 };
            points[(int)Pos.Rest] = new Point() { x = X, y = Y + 3 };
            points[(int)Pos.MoveMap] = new Point() { x = X, y = Y + 4 };
            points[(int)Pos.Inventory] = new Point() { x = X, y = Y + 5 };
            curPoint = points[(int)Pos.Chest];
        }
        public override void Enter()
        {
            Console.Clear();
        }
        public override void Exit()
        {
            game.prevScene = this;
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

        }
        protected override void MoveRightCursor()
        {

        }
        #endregion

        protected override void PushKeyZ()
        {
            throw new NotImplementedException();
        }

        protected override void UpdateKey()
        {
            base.UpdateKey();
        }
    }
}
