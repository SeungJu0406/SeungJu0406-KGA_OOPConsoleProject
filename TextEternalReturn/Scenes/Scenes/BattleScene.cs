using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes.Scenes
{
    internal class BattleScene : Scene
    {
        public BattleScene(Player player) : base(player)
        {

        }
        public override void Render()
        {
            Console.Clear();
            PrintStatus();
        }
        public override void Update()
        {

        }
        public override void Enter()
        {

        }
        public override void Exit()
        {

        }
        
    }
}
