using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Players;
using TextEternalReturn.Monsters;

namespace TextEternalReturn.Scenes.Scenes
{
    public class BattleScene : Scene
    {
        public enum Choice { Attack, UseItem,Run, SIZE}
        public struct Point
        {
            public int x, y;
            public Choice choice;
        }
        Point mobStatusPoint;
        Monster monster;
        MonsterFactory mobFactory = new MonsterFactory();
        Point[] points = new Point[3];
        Point curPoint;
        public BattleScene(Player player) : base(player)
        {       
            mobStatusPoint = new Point() { x = statusPoint.x + 20 , y = statusPoint.y};
            points[(int)Choice.Attack] = new Point() { x = statusPoint.x, y = statusPoint.y + 4 , choice = Choice.Attack };
            #region x,y
            int X = points[(int)Choice.Attack].x;
            int Y = points[(int)Choice.Attack].y;
            #endregion
            points[(int)Choice.UseItem] = new Point() { x = X + 20, y = Y, choice = Choice.UseItem };
            points[(int)Choice.Run] = new Point() { x = X , y = Y+1 , choice = Choice.Run };
            curPoint = points[(int)Choice.Attack];
        }
        public override void Render()
        {
            Console.Clear();
            PrintStatus();
            PrintMobStatus();
            PrintBattleChoice();
        }
        public override void Update()
        {
            UpdateKey();
        }
        public override void Enter()
        {
            monster = mobFactory.CreateRandom();
        }
        public override void Exit()
        {
            game.prevScene = this;
        }
        private void PrintMobStatus()
        {
            SetCursor(mobStatusPoint);
            Console.WriteLine($"{monster.name}");
            mobStatusPoint.y++;
            SetCursor(mobStatusPoint);
            Console.WriteLine($"체력: {monster.curHp,5}/{monster.maxHp}");           
            mobStatusPoint.y++;
            SetCursor(mobStatusPoint);
            Console.WriteLine($"공격력: {monster.power,5}");
            mobStatusPoint.y = statusPoint.y;
        }
        private void PrintBattleChoice()
        {
            SetCursor(points[(int)Choice.Attack]);
            Console.WriteLine("▷ 공격하기");
            SetCursor(points[(int)Choice.UseItem]);
            Console.WriteLine("▷ 아이템 사용");
            SetCursor(points[(int)Choice.Run]);
            Console.WriteLine("▷ 도망가기");
            SetCursor(curPoint);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("▶");
            Console.ResetColor();
        }
        private void UpdateKey()
        {
            switch (consoleKey) 
            {
                case ConsoleKey.UpArrow:
                    MoveUpCursor();
                    break;
                case ConsoleKey.DownArrow:
                    MoveDownCursor();
                    break;
                case ConsoleKey.LeftArrow:
                    MoveLeftCursor();
                    break;
                case ConsoleKey.RightArrow:
                    MoveRightCursor();
                    break;
                case ConsoleKey.Z:
                    break;
                default:
                    break;
            }
        }

        #region 커서 옮기기
        private void MoveUpCursor() // 1이하는 위쪽으로 못감
        {
            if ((int)curPoint.choice > 1)
            {
                curPoint = points[(int)curPoint.choice - 2];
            }
        }
        private void MoveDownCursor() // SIZE-2 이상은 위로 못감
        {
            if ((int)curPoint.choice < (int)Choice.SIZE -2)
            {
                curPoint = points[(int)curPoint.choice + 2];
            }
        }
        private void MoveLeftCursor() // 짝수라면 왼쪽못감
        {
            if ((int)curPoint.choice%2 !=0)
            {
                curPoint = points[(int)curPoint.choice - 1];
            }
        }
        private void MoveRightCursor()
        {
            if ((int)curPoint.choice % 2 == 0 &&
                (int)curPoint.choice+1 != (int)Choice.SIZE)
            {
                curPoint = points[(int)curPoint.choice + 1];
            }
        }
        #endregion
        private void SetCursor(Point cursorPoint)
        {
            Console.SetCursorPosition(cursorPoint.x, cursorPoint.y);
        }
    }
}
