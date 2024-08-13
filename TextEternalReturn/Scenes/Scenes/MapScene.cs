using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes.Scenes
{
    internal class MapScene : Scene
    {
        enum Pos
        {
            Map, X0, X1, X2, X3, X4, X5, X6,
            Y0,
            Y1,
            Y2,
            Y3,
            Y4,
            Y5,
            Y6,
            Player, Hyunwoo, SIZE
        }
        Point[] points = new Point[(int)Pos.SIZE];
        public MapScene(Player player) : base(player)
        {
            points[(int)Pos.Map] = new Point() { x = X, y = Y };
            #region 맵 좌표
            int mapX = X + 1;
            int mapY = Y + 1;
            points[(int)Pos.X0] = new Point() { x = mapX + 0, y = Y };
            points[(int)Pos.X1] = new Point() { x = mapX + 1, y = Y };
            points[(int)Pos.X2] = new Point() { x = mapX + 2, y = Y };
            points[(int)Pos.X3] = new Point() { x = mapX + 3, y = Y };
            points[(int)Pos.X4] = new Point() { x = mapX + 4, y = Y };
            points[(int)Pos.X5] = new Point() { x = mapX + 5, y = Y };
            points[(int)Pos.X6] = new Point() { x = mapX + 6, y = Y };
            points[(int)Pos.Y0] = new Point() { x = X, y = mapY + 0 };
            points[(int)Pos.Y1] = new Point() { x = X, y = mapY + 1 };
            points[(int)Pos.Y2] = new Point() { x = X, y = mapY + 2 };
            points[(int)Pos.Y3] = new Point() { x = X, y = mapY + 3 };
            points[(int)Pos.Y4] = new Point() { x = X, y = mapY + 4 };
            points[(int)Pos.Y5] = new Point() { x = X, y = mapY + 5 };
            points[(int)Pos.Y6] = new Point() { x = X, y = mapY + 6 };
            #endregion  
            points[(int)Pos.Player] = new Point() { x = points[(int)Pos.X3].x, y = points[(int)Pos.Y3].y };
            points[(int)Pos.Hyunwoo] = new Point() { x = points[(int)Pos.X0].x, y = points[(int)Pos.Y6].y };

        }
        public override void Render()
        {
            PrintMap();
        }
        public override void Update()
        {
            UpdateKey();
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
            Point map = points[(int)Pos.Map];
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
            SetCursor(points[(int)Pos.Player]);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("P");
            Console.ResetColor();
            SetCursor(points[(int)Pos.Hyunwoo]);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("H");
            Console.ResetColor();
        }
        private void UpdateKey()
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
        private void PushKeyZ()
        {

        }
        #region 커서 이동
        public void MoveUpCursor()
        {
            if (points[(int)Pos.Player].y > points[(int)Pos.Y0].y)
            {
                points[(int)Pos.Player].y--;
            }
        }
        public void MoveDownCursor()
        {
            if (points[(int)Pos.Player].y < points[(int)Pos.Y6].y)
            {
                points[(int)Pos.Player].y++;
            }
        }
        public void MoveLeftCursor()
        {
            if (points[(int)Pos.Player].x > points[(int)Pos.X0].x)
            {
                points[(int)Pos.Player].x--;
            }
        }
        public void MoveRightCursor()
        {
            if (points[(int)Pos.Player].x < points[(int)Pos.X6].x)
            {
                points[(int)Pos.Player].x++;
            }
        }
        #endregion
        private void SetCursor(Point cursorPoint)
        {
            Console.SetCursorPosition(cursorPoint.x, cursorPoint.y);
        }
    }
}
