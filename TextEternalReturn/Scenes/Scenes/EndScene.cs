using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes.Scenes
{
    internal class EndScene : Scene
    {
        public EndScene(Player player) : base(player)
        {

        }
        public override void Render()
        {
            if (game.isWin)
            {
                Console.WriteLine("이겼어요!");
            }
            else
            {
                Console.WriteLine("졌어요 ㅠㅠ");
            }
        }
        public override void Input()
        {

        }
        public override void Update()
        {
            game.GameOver();
        }
        public override void Enter()
        {
            Console.Clear();
        }
        public override void Exit()
        {
            game.prevScene = this;
        }

        protected override void MoveUpCursor()
        {
            throw new NotImplementedException();
        }

        protected override void MoveDownCursor()
        {
            throw new NotImplementedException();
        }

        protected override void MoveLeftCursor()
        {
            throw new NotImplementedException();
        }

        protected override void MoveRightCursor()
        {
            throw new NotImplementedException();
        }

        protected override void PushKeyZ()
        {
            throw new NotImplementedException();
        }
    }
}
