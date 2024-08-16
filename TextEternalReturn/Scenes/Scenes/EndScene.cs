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
        enum Pos { EndText, SIZE}
        Point[] points; 
        public EndScene(Player player) : base(player)
        {
            SceneID = (int)SceneType.EndScene;
            points = new Point[(int)Pos.SIZE];
            points[(int)Pos.EndText] = new Point() { x = X , y = Y };
        }
        public override void Render()
        {
            PrintEnd();
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
        private void PrintEnd()
        {
            SetCursor(points[(int)Pos.EndText]);
            if (game.isWin)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("최후의 1인이 되었습니다. 승리하였습니다");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("패배 하였습니다.");
                Console.ResetColor();
            }
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
