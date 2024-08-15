using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes.Scenes.PlaceScenes.PlaceScenes
{
    internal class BonfireScene : PlaceScene
    {
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
        protected override void PushKeyZ()
        {

        }
    }
}
