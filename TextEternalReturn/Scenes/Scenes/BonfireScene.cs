using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes.Scenes
{
    internal class BonfireScene : Scene { 
        public BonfireScene(Player player) : base(player)
        {

        }
        public override void Render()
        {
            PrintStatus();
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
        private void PrintHotel()
        {

        }
        protected override void PushKeyZ()
        {
            base.PushKeyZ();
        }
        #region 커서 이동
        protected override void MoveUpCursor()
        {
            base.MoveUpCursor();
        }
        protected override void MoveDownCursor()
        {
            base.MoveDownCursor();
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
