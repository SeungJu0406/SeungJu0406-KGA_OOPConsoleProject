using TextEternalReturn.Maps;
using TextEternalReturn.Maps.AStars;
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
            Player, Hyunwoo, 
            Hotel, Alley, Harbor, Hospital, Bonfire,
            SIZE
        }
        Point[] points = new Point[(int)Pos.SIZE];
        List<Point> walls;

        Map map = new Map();
        int mapX;
        int mapY;

        int moveCount = 0;
        public MapScene(Player player) : base(player)
        {
            SceneID = (int)SceneType.MapScene;
            points[(int)Pos.Map] = new Point() { x = X, y = Y };
            #region 맵 좌표
            mapX = X + 1;
            mapY = Y + 1;
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
            points[(int)Pos.Hotel] = new Point() { x = points[(int)Pos.X0].x, y = points[(int)Pos.Y0].y };
            points[(int)Pos.Alley] = new Point() { x = points[(int)Pos.X6].x, y = points[(int)Pos.Y0].y };
            points[(int)Pos.Harbor] = new Point() { x = points[(int)Pos.X0].x, y = points[(int)Pos.Y6].y };
            points[(int)Pos.Hospital] = new Point() { x = points[(int)Pos.X6].x, y = points[(int)Pos.Y6].y };
            points[(int)Pos.Bonfire] = new Point() { x = points[(int)Pos.X3].x, y = points[(int)Pos.Y3].y };
            walls = new List<Point>(map.board.CountWall());
            #region 벽 좌표
            for (int y = 0; y < map.sizeY; y++)
            {
                for (int x = 0; x < map.sizeX; x++)
                {
                    if (map.blocks[y, x].wall)
                        walls.Add(new Point() { x = points[(int)Pos.X0].x + x, y = points[(int)Pos.Y0].y + y });
                }
            }
            #endregion 
        }
        public override void Render()
        {
            base.Render();
            PrintMap();
        }
        public override void Update()
        {
            base.Update();      
            MoveHyun();
            CheckMeetPlayer();
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
            Point mapPoint = points[(int)Pos.Map];
            SetCursor(mapPoint);
            mapPoint.y++;
            Console.WriteLine("OOOOOOOOO");
            for (int y = 0; y < map.sizeY; y++)
            {
                SetCursor(mapPoint);
                mapPoint.y++;
                Console.Write("O       O");
            }
            for(int i = 0; i <walls.Count; i++)
            {
                SetCursor(walls[i]);
                Console.WriteLine("O");
            }
            SetCursor(mapPoint);
            mapPoint.y++;
            Console.WriteLine("OOOOOOOOO");
            for (int i = (int)Pos.Hotel; i <= (int)Pos.Hospital; i++)
            {
                SetCursor(points[i]);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("$");
                Console.ResetColor();
            }
            SetCursor(points[(int)Pos.Bonfire]);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("@");
            Console.ResetColor();
            SetCursor(points[(int)Pos.Player]);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("P");
            Console.ResetColor();
            SetCursor(points[(int)Pos.Hyunwoo]);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("H");
            Console.ResetColor();
        }
        protected override void PushKeyZ()
        {
            if (points[(int)Pos.Player].x == points[(int)Pos.Hotel].x &&
                points[(int)Pos.Player].y == points[(int)Pos.Hotel].y)
            {
                game.ChangeScene(SceneType.HotelScene);
            }
            else if (points[(int)Pos.Player].x == points[(int)Pos.Alley].x &&
                        points[(int)Pos.Player].y == points[(int)Pos.Alley].y)
            {
                game.ChangeScene(SceneType.AlleyScene);
            }
            else if (points[(int)Pos.Player].x == points[(int)Pos.Harbor].x &&
                       points[(int)Pos.Player].y == points[(int)Pos.Harbor].y)
            {
                game.ChangeScene(SceneType.HarborScene);
            }
            else if (points[(int)Pos.Player].x == points[(int)Pos.Hospital].x &&
                        points[(int)Pos.Player].y == points[(int)Pos.Hospital].y)
            {
                game.ChangeScene(SceneType.HospitalScene);
            }
            else if (points[(int)Pos.Player].x == points[(int)Pos.Bonfire].x &&
                points[(int)Pos.Player].y == points[(int)Pos.Bonfire].y)
            {
                game.ChangeScene(SceneType.BonFireScene);
            }
            else 
                game.ChangeScene(SceneType.ChoiceScene);
        }
        #region 커서 이동
        protected override void MoveUpCursor()
        {
            if (points[(int)Pos.Player].y > points[(int)Pos.Y0].y) // 맵 바깥으로 안나가는가
            {
                bool isWall = map.blocks[points[(int)Pos.Player].y - mapY - 1, points[(int)Pos.Player].x - mapX].wall; // 움직이려는 위치에 벽이 있는가
                if (!(isWall))
                {
                    points[(int)Pos.Player].y -= 1;
                    moveCount++;
                }
            }
        }
        protected override void MoveDownCursor()
        {
            if (points[(int)Pos.Player].y < points[(int)Pos.Y6].y)
            {
                bool isWall = map.blocks[points[(int)Pos.Player].y - mapY + 1, points[(int)Pos.Player].x - mapX].wall;
                if (!(isWall))
                {
                    points[(int)Pos.Player].y += 1;
                    moveCount++;
                }
            }
        }
        protected override void MoveLeftCursor()
        {
            if (points[(int)Pos.Player].x > points[(int)Pos.X0].x)
            {
                bool isWall = map.blocks[points[(int)Pos.Player].y - mapY, points[(int)Pos.Player].x - mapX - 1].wall;
                if (!(isWall))
                {
                    points[(int)Pos.Player].x -= 1;
                    moveCount++;
                }
            }
        }
        protected override void MoveRightCursor()
        {
            if (points[(int)Pos.Player].x < points[(int)Pos.X6].x)
            {
                bool isWall = map.blocks[points[(int)Pos.Player].y - mapY, points[(int)Pos.Player].x - mapX + 1].wall;
                if (!(isWall))
                {
                    points[(int)Pos.Player].x += 1;
                    moveCount++;
                }
            }
        }
        #endregion
        private void MoveHyun()
        {
            if (moveCount >= 2 ) 
            {
                moveCount = 0;
                int HyunX = points[(int)Pos.Hyunwoo].x - mapX;
                int HyunY = points[(int)Pos.Hyunwoo].y - mapY;
                Block start = map.board.board[HyunY, HyunX];
                int playerX = points[(int)Pos.Player].x - mapX;
                int playerY = points[(int)Pos.Player].y - mapY;
                Block finish = map.board.board[playerY, playerX];
                start = AStar.GetAStarFinding(map.board, start, finish);
                if (start != null && start.next != null)
                {
                    points[(int)Pos.Hyunwoo].x = start.next.x + mapX;
                    points[(int)Pos.Hyunwoo].y = start.next.y + mapY;
                }
            }
        }
        private void CheckMeetPlayer()
        {
            if (points[(int)Pos.Hyunwoo].x == points[(int)Pos.Player].x &&
                points[(int)Pos.Hyunwoo].y == points[(int)Pos.Player].y)
            {
                game.battleHyun = true;
                game.ChangeScene(SceneType.BattleScene);
            }
        }
    }
}
