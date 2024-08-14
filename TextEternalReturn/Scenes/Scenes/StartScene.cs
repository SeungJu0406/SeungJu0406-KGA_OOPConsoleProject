using TextEternalReturn.Players;
namespace TextEternalReturn.Scenes.Scenes
{
    public class StartScene : Scene
    {
        bool error;
        Point startPoint;
        public StartScene(Player player) : base(player)
        {
            error = false;
            startPoint = new Point() { x = x, y = y };
        }
        public override void Render()
        {
            Console.Clear();
            if (!(error)) PrintStart();
            else PrintError();
        }
        public override void Update()
        {
            UpdateKey(consoleKey);
        }
        public override void Enter()
        {
            Console.Clear();
            error = false;
        }
        public override void Exit()
        {
            game.prevScene = this;
        }
        private void PrintStart()
        {
            Point cursor = startPoint;
            SetCursor(cursor);
            Console.WriteLine("Text Eternal Return");
            cursor.y++;
            SetCursor(cursor);
            Console.WriteLine("Z를 눌러 지금 바로 시작");
        }
        private void PrintError()
        {
            Point cursor = startPoint;
            SetCursor(cursor);
            Console.WriteLine("Text Eternal Return");
            cursor.y++;
            SetCursor(cursor);
            Console.WriteLine("제발 Z를 눌러 지금 바로 시작");
        }
        private void UpdateKey(ConsoleKey consolekey)
        {
            if (consoleKey == ConsoleKey.Z)
                game.ChangeScene(SceneType.ChoiceScene);
            else
                error = true;
        }
        private void SetCursor(Point cursorPoint)
        {
            Console.SetCursorPosition(cursorPoint.x, cursorPoint.y);
        }

    }

}
