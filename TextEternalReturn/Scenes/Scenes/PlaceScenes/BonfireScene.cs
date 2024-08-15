using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes.Scenes.PlaceScenes
{
    internal class BonfireScene : Scene
    {
        public BonfireScene(Player player) : base(player)
        {

        }
        public override void Render()
        {
            base.Render();
        }
        public override void Update()
        {
            base.Update();
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
