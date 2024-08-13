﻿using TextEternalReturn.Monsters;
using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes.Scenes
{
    public class BattleScene : Scene
    {
        public enum Choice { Attack, UseItem, Run, SIZE }
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
            mobStatusPoint = new Point() { x = statusPoint.x + 20, y = statusPoint.y };
            points[(int)Choice.Attack] = new Point() { x = statusPoint.x, y = statusPoint.y + 4, choice = Choice.Attack };
            #region x,y
            int X = points[(int)Choice.Attack].x;
            int Y = points[(int)Choice.Attack].y;
            #endregion
            points[(int)Choice.UseItem] = new Point() { x = X + 20, y = Y, choice = Choice.UseItem };
            points[(int)Choice.Run] = new Point() { x = X, y = Y + 1, choice = Choice.Run };           
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
            curPoint = points[(int)Choice.Attack];
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
                    PushKeyZ();
                    break;
                default:
                    break;
            }
        }
        private void PushKeyZ()
        {
            switch (curPoint.choice)
            {
                case Choice.Attack:
                    Attack();
                    break;
                case Choice.UseItem:
                    UseItem();
                    break;
                case Choice.Run:
                    Run();
                    break;
                default:
                    break;
            }
        }
        private void Attack()
        {
            // 플레이어가 몬스터를 공격
            // 플레이어 공격 후 몬스터도 공격
            player.Attack(monster);
            if (monster.isDie)
            {
                Run();
            }
            monster.Attack(player);
            if (player.isDie)
            {
                //플레이어가 죽었을때 엔딩화면으로
            }
        }
        private void UseItem()
        {
            // 인벤토리 창으로 이동
            // 이전에 잡고있던 몹은 저장하고있어야하는데
            game.ChangeScene(SceneType.InventoryScene);
        }
        private void Run()
        {
            int prevSceneIndex = Array.IndexOf(game.sceneList, game.prevScene);
            game.ChangeScene((SceneType)prevSceneIndex);
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
            if ((int)curPoint.choice < (int)Choice.SIZE - 2)
            {
                curPoint = points[(int)curPoint.choice + 2];
            }
        }
        private void MoveLeftCursor() // 짝수라면 왼쪽못감
        {
            if ((int)curPoint.choice % 2 != 0)
            {
                curPoint = points[(int)curPoint.choice - 1];
            }
        }
        private void MoveRightCursor()
        {
            if ((int)curPoint.choice % 2 == 0 &&
                (int)curPoint.choice + 1 != (int)Choice.SIZE)
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
