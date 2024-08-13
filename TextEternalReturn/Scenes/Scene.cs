using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes
{
    public abstract class Scene
    {
        protected Game game;
        protected Scene curScene;
        protected ConsoleKey consoleKey;
        protected Player player;
        protected Point statusPoint;
        public struct Point()
        {
            public int x, y;
        }
        protected Point curPoint;
        protected Scene(Player player)
        {
            this.game = Game.getInstance();
            this.player = player;
            curScene = game.curScene;
            statusPoint = new Point() { x = 0, y = 0 };
        }
        public abstract void Render();
        public abstract void Input();
        public abstract void Update();
        public abstract void Enter();
        public abstract void Exit();
        #region 스테이터스 화면
        protected void PrintStatus()
        {
            SetCursor(statusPoint);
            Console.WriteLine($"체력: {player.curHp,5}/{player.maxHp}");
            statusPoint.y++;
            Console.WriteLine($"공격력: {player.power,5}");
            statusPoint.y++;
            Console.WriteLine($"경험치: {player.exp,+5}");
            statusPoint.y = 0;
        }
        private void SetCursor(Point cursorPoint)
        {
            Console.SetCursorPosition(cursorPoint.x, cursorPoint.y);
        }
        #endregion
    }
}
