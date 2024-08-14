using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes.Scenes
{
    internal class PoliceOfficeScene :Scene
    {
        public PoliceOfficeScene(Player player) : base(player)
        {

        }
        public override void Render()
        {
            Console.WriteLine("경찰서");
        }
        public override void Update()
        {

        }
        public override void Enter()
        {
            Console.Clear();
        }
        public override void Exit()
        {
            game.prevScene = this;
        }
    }
}
