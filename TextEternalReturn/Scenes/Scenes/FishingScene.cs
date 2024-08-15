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
        public FishingScene(Player player) : base(player)
        {

        }
        public override void Enter()
        {
            throw new NotImplementedException();
        }

        public override void Exit()
        {
            game.prevScene = this;
        }

        public override void Render()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
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
        protected override void PushKeyZ()
        {
            base.PushKeyZ();
        }
    }
}
