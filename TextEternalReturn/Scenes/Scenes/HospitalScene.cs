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
        public HospitalScene(Player player) : base(player)
        {

        }
        public override void Render()
        {
            Console.WriteLine("병원");
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
