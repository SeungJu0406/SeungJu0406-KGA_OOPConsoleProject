using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes
{
    public abstract class Scene
    {
        protected Game game;
        protected Scene curScene;
        protected ConsoleKey consoleKey;
        protected Player player;
        public struct Point()
        {
            public int x, y;
        }
        protected Point curPoint;
        protected Point[] points = new Point[3];
        protected Scene(Player player)
        {
            this.game = Game.getInstance();
            this.player = player;
            curScene = game.curScene;
        }
        public abstract void Render();
        public abstract void Input();
        public abstract void Update();
        public abstract void Enter();
        public abstract void Exit();
    }
}
