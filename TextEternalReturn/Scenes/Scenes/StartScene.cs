using TextEternalReturn.Players;
namespace TextEternalReturn.Scenes.Scenes
{
    public class StartScene : Scene
    {
        bool error;
        Point startPoint;
        public StartScene(Player player) : base(player)
        {
            SceneID = (int)SceneType.StartScene;
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
            base.Update();
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
        protected override void PushKeyZ()
        {
            Game.game.ChangeScene(SceneType.ChoiceScene);
        }
        #region 커서 이동
        protected override void MoveUpCursor() { }

        protected override void MoveDownCursor() { }

        protected override void MoveRightCursor() { }

        protected override void MoveLeftCursor() { }

        #endregion
    }

}
