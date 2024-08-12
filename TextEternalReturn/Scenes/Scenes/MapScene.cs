using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEternalReturn.Scenes.Scenes
{
    internal class MapScene : Scene
    {
        public MapScene(Game game) : base(game)
        {

        }
        public override void Render()
        {
            Console.WriteLine("임시 텍스트");
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

        }
    }
}
