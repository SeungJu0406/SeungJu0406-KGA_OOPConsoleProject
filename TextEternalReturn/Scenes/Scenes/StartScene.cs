namespace TextEternalReturn.Scenes.Scenes
{
    public class StartScene : Scene
    {
        bool error;
        Scene curScene;
        ConsoleKey consoleKey;
        public StartScene(Game game) : base(game)
        {
            error = false;
        }
        public override void Render()
        {
            Console.Clear();
            if(!(error))PrintStart();
            else PrintError();
        }
        public override void Input()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Enter:
                    // 맵 화면으로 이동
                    consoleKey = ConsoleKey.Enter;
                    break;
                default:
                    // 에러메세지
                    consoleKey = default;
                    break;
            }
        }
        public override void Update()
        {
            UpdateKey(consoleKey);
        }
        public override void Enter()
        {
            error = false;
        }
        public override void Exit()
        {
            curScene = null;
        }
        private void PrintStart()
        {
            Console.WriteLine("Text Eternal Return");
            Console.WriteLine("엔터키를 눌러 지금 바로 시작");
        }
        private void PrintError()
        {
            Console.WriteLine("Text Eternal Return");
            Console.WriteLine("제발 엔터키를 눌러 지금 바로 시작");
        }
        private void UpdateKey(ConsoleKey consolekey)
        {
            if (consoleKey == ConsoleKey.Enter)
                game.ChangeScene(SceneType.ChoiceScene);
            else
                error = true;
        }

    }

}
