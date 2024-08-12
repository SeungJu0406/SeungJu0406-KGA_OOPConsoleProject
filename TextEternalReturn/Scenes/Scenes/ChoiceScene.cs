namespace TextEternalReturn.Scenes.Scenes
{
    public class ChoiceScene : Scene
    {
        enum CursorPoint { AnimalHunt, MoveMap, CheckInventory, SIZE }
        public struct Point()
        {
            public int X, Y;
            public SceneType scene;
        }
        Point[] points = new Point[3];
        Point curPoint;
        ConsoleKey consoleKey;
        public ChoiceScene(Game game) : base(game)
        {
            points[(int)CursorPoint.AnimalHunt] = new Point() { X = 0, Y = 3, scene = SceneType.BattleScene };
            points[(int)CursorPoint.MoveMap] = new Point() { X = 0, Y = 4, scene = SceneType.MapScene };
            points[(int)CursorPoint.CheckInventory] = new Point() { X = 0, Y = 5, scene = SceneType.InventoryScene };
            curPoint = points[(int)CursorPoint.AnimalHunt];
        }
        public override void Enter()
        {
            Console.Clear();
        }

        public override void Exit()
        {

        }
        public override void Render()
        {
            PrintChoice();
        }
        public override void Input()
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
        public override void Update()
        {
            UpdateKey(consoleKey);
        }

        private void PrintChoice()
        {
            SetCursor(points[(int)CursorPoint.AnimalHunt]);
            Console.WriteLine("▷ 동물 잡기");
            SetCursor(points[(int)CursorPoint.MoveMap]);
            Console.WriteLine("▷ 이동 하기");
            SetCursor(points[(int)CursorPoint.CheckInventory]);
            Console.WriteLine("▷ 아이템 확인");

            SetCursor(curPoint);
            Console.WriteLine("▶");
        }
        private void UpdateKey(ConsoleKey consolekey)
        {
            switch (consoleKey)
            {
                case ConsoleKey.UpArrow:
                    MoveUpCursor(curPoint);
                    break;
                case ConsoleKey.DownArrow:
                    MoveDownCursor(curPoint);
                    break;
                case ConsoleKey.Z:
                    game.ChangeScene(curPoint.scene);
                    break;
            }
        }
        private void SetCursor(Point cursorPoint)
        {
            Console.SetCursorPosition(cursorPoint.X, cursorPoint.Y);
        }
        private void MoveUpCursor(Point curPoint)
        {
            int index = Array.IndexOf(points, curPoint);
            if (index - 1 >= 0)
            {
                this.curPoint = points[index - 1];
            }
        }
        private void MoveDownCursor(Point curPoint)
        {
            int index = Array.IndexOf(points, curPoint);
            if (index + 1 < (int)CursorPoint.SIZE)
            {
                this.curPoint = points[index + 1];
            }
        }
    }
}
