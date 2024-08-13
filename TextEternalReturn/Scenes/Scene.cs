using TextEternalReturn.Players;

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
        protected Scene(Player player)
        {
            this.game = Game.getInstance();
            this.player = player;
            statusPoint = new Point() { x = 0, y = 0 };
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
        #region 스테이터스 화면
        protected void PrintStatus()
        {
            SetCursor(statusPoint);
            Console.WriteLine($"레벨: {player.level,+5}");        
            statusPoint.y++;
            SetCursor(statusPoint);
            Console.WriteLine($"체력: {player.curHp,5}/{player.maxHp}");          
            statusPoint.y++;
            SetCursor(statusPoint);
            Console.WriteLine($"공격력: {player.power,5}");
            statusPoint.y++;
            SetCursor(statusPoint);
            Console.WriteLine($"경험치: {player.curExp,3}/{player.maxExp}");
            statusPoint.y = 0;
        }
        private void SetCursor(Point cursorPoint)
        {
            Console.SetCursorPosition(cursorPoint.x, cursorPoint.y);
        }
        #endregion
    }
}
