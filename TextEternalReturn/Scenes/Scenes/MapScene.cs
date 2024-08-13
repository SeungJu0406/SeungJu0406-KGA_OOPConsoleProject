using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes.Scenes
{
    internal class MapScene : Scene
    {
        enum MapPoint
        {
            Map, X0, X1, X2, X3, X4, X5, X6,
            Y0,
            Y1,
            Y2,
            Y3,
            Y4,
            Y5,
            Y6,
            Player, SIZE
        }
        Point[] points = new Point[(int)MapPoint.SIZE];
        public MapScene(Player player) : base(player)
        {
            points[(int)MapPoint.Map] = new Point() { x = X, y = Y };
            points[(int)MapPoint.Player] = new Point() { x = X + 4, y = Y + 4 };
        }
        public override void Render()
        {
            PrintMap();
        }
        public override void Input()
        {
            Console.ReadLine();
        }
        public override void Update()
        {

        }
        public override void Enter()
        {
            Console.Clear();
        }
        public override void Exit()
        {
            game.prevScene = this;
        }
        private void PrintMap()
        {
            Point map = points[(int)MapPoint.Map];
            SetCursor(map);
            map.y++;
            Console.WriteLine("#########");
            SetCursor(map);
            map.y++;
            Console.WriteLine("#       #");
            SetCursor(map);
            map.y++;
            Console.WriteLine("#       #");
            SetCursor(map);
            map.y++;
            Console.WriteLine("#       #");
            SetCursor(map);
            map.y++;
            Console.WriteLine("#       #");
            SetCursor(map);
            map.y++;
            Console.WriteLine("#       #");
            SetCursor(map);
            map.y++;
            Console.WriteLine("#       #");
            SetCursor(map);
            map.y++;
            Console.WriteLine("#       #");
            SetCursor(map);
            map.y++;
            Console.WriteLine("#########");
            SetCursor(points[(int)MapPoint.Player]);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("P");
            Console.ResetColor();
        }
        private void SetCursor(Point cursorPoint)
        {
            Console.SetCursorPosition(cursorPoint.x, cursorPoint.y);
        }
    }
}
