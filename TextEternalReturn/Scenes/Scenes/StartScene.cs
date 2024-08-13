using TextEternalReturn.Players;
namespace TextEternalReturn.Scenes.Scenes
{
    public class StartScene : Scene
    {
        bool error;
        public StartScene(Player player) : base(player)
        {
            error = false;
        }
        public override void Render()
        {
            Console.Clear();
            if(!(error))PrintStart();
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
            curScene = null;
        }
        private void PrintStart()
        {
            Console.WriteLine("Text Eternal Return");
            Console.WriteLine("Z를 눌러 지금 바로 시작");
        }
        private void PrintError()
        {
            Console.WriteLine("Text Eternal Return");
            Console.WriteLine("제발 Z를 눌러 지금 바로 시작");
        }
        private void UpdateKey(ConsoleKey consolekey)
        {
            if (consoleKey == ConsoleKey.Z)
                game.ChangeScene(SceneType.ChoiceScene);
            else
                error = true;
        }
        
    }

}
