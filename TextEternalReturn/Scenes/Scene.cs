﻿using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes
{
    public abstract class Scene
    {
        public struct Point()
        {
            public int x, y;
        }
        protected Game game;
        protected Player player;
        protected ConsoleKey consoleKey;
        protected Scene curScene;
        protected Point curPoint;
        protected Point statusPoint;       
        protected int X, Y; // 스텟창 밑 기준점
        protected int x, y; // 게임 기준점
        protected Scene(Player player)
        {
            x = 25; 
            y = 5;

            X = x; Y = y + 5;
            this.game = Game.getInstance();
            this.player = player;
            statusPoint = new Point() { x = x, y = y };
        }
        public abstract void Render();
        public virtual void Input()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    consoleKey = ConsoleKey.UpArrow;
                    break;
                case ConsoleKey.DownArrow:
                    consoleKey = ConsoleKey.DownArrow;
                    break;
                case ConsoleKey.LeftArrow:
                    consoleKey = ConsoleKey.LeftArrow;
                    break;
                case ConsoleKey.RightArrow:
                    consoleKey = ConsoleKey.RightArrow;
                    break;
                case ConsoleKey.Z:
                    consoleKey = ConsoleKey.Z;
                    break;
                default:
                    consoleKey = default;
                    break;
            }
        }
        public abstract void Update();

        public abstract void Enter();

        public abstract void Exit();

        protected virtual void UpdateKey()
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
        protected abstract void MoveUpCursor();
        protected abstract void MoveDownCursor();
        protected abstract void MoveLeftCursor();
        protected abstract void MoveRightCursor();
        protected abstract void PushKeyZ();

        #region 스테이터스 화면
        protected void PrintStatus()
        {
            SetCursor(statusPoint);
            Console.WriteLine($"레벨: {player.level,6}");        
            statusPoint.y++;
            SetCursor(statusPoint);
            Console.WriteLine($"체력: {player.curHp,5}/{player.maxHp}");          
            statusPoint.y++;
            SetCursor(statusPoint);
            Console.WriteLine($"공격력: {player.power,5}");
            statusPoint.y++;
            SetCursor(statusPoint);
            Console.WriteLine($"경험치: {player.curExp,3}/{player.maxExp}");
            statusPoint.y = y;
        }

        #endregion
        protected void SetCursor(Point cursorPoint)
        {
            Console.SetCursorPosition(cursorPoint.x, cursorPoint.y);
        }
    }
}
