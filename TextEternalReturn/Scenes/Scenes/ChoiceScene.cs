using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEternalReturn.Scenes.Scenes
{
    public class ChoiceScene : Scene
    {

        public override void Enter()
        {
            
        }

        public override void Exit()
        {
            
        }
        public override void Render()
        {
            Console.Clear();
            Console.WriteLine("선택");
            Console.WriteLine("1. 동물 잡기");
            Console.WriteLine("2. 이동 하기");
            Console.WriteLine("3. 아이템 확인");
        }
        public override void Input()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    break;
            }
        }
        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
