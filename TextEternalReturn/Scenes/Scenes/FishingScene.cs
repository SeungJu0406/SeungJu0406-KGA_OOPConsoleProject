﻿using System;
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
            base.Render();
        }

        public override void Update()
        {
            base.Update();
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
        protected override void PushKeyZ()
        {

        }
    }
}
