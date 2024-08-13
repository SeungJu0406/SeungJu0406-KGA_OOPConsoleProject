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
        enum Choice { Attack, Run, SIZE}
        Point mobStatusPoint;
        Monster monster;
        MonsterFactory mobFactory = new MonsterFactory();
        Point[] points = new Point[2];
        
        public BattleScene(Player player) : base(player)
        {       
            mobStatusPoint = new Point() { x = statusPoint.x + 20 , y = statusPoint.y };
            points[(int)Choice.Attack] = new Point() { x = statusPoint.x, y = statusPoint.y + 4 };
            #region x,y
            int X = points[(int)Choice.Attack].x;
            int Y = points[(int)Choice.Attack].y;
            #endregion
            points[(int)Choice.Run] = new Point() { x = X + 20, y = Y };
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
            
        }
        public override void Enter()
        {
            monster = mobFactory.CreateRandom();
        }
        public override void Exit()
        {

        }
        public void PrintMobStatus()
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
        public void PrintBattleChoice()
        {
            SetCursor(points[(int)Choice.Attack]);
            Console.WriteLine("▷ 공격하기");
            SetCursor(points[(int)Choice.Run]);
            Console.WriteLine("▷ 도망가기");
            SetCursor(curPoint);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("▶");
            Console.ResetColor();
        }

        private void SetCursor(Point cursorPoint)
        {
            Console.SetCursorPosition(cursorPoint.x, cursorPoint.y);
        }
    }
}
