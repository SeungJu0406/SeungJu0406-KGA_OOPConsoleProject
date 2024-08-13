using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes.Scenes
{
    internal class MapScene : Scene
    {
        public MapScene(Player player) : base(player)
        {

        }
        public override void Render()
        {
            throw new NotImplementedException();
        }
        public override void Input()
        {
            Console.ReadLine();
        }
        public override void Update()
        {
            
        }
        public override void Enter()
        {

        }
        public override void Exit()
        {
            game.prevScene = this;
        }
    }
}
