using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes
{
    public abstract class Scene
    {
        public struct Point()
        {
            public int x, y;
        }
        public int SceneID;
        protected Game game;
        protected Player player;
        protected ConsoleKey consoleKey;
        protected Scene curScene;
        protected Point curPoint;
        protected Point statusPoint;
        private Point collectionPoint;
        private Point informationKey;
        protected int X, Y; // 스텟창 밑 기준점
        protected int x, y; // 게임 기준점
        protected Scene(Player player)
        {
            x = 25;
            y = 5;

            X = x; Y = y + 5;
            this.game = Game.getInstance();
            this.player = player;
            statusPoint = new Point() { x = x, y = y };
            informationKey = new Point() { x = X - 15, y = y };
            collectionPoint = new Point() { x = X - 15, y = Y };          
        }
        public virtual void Render()
        {
            PrintStatus();
            PrintInformationKey();
            PrintCollectItem();
        }
        public virtual void Input()
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
        public virtual void Update()
        {
            UpdateKey();
        }

        public abstract void Enter();

        public abstract void Exit();

        protected virtual void UpdateKey()
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
        protected abstract void MoveUpCursor();
        protected abstract void MoveDownCursor();
        protected abstract void MoveLeftCursor();
        protected abstract void MoveRightCursor();
        protected abstract void PushKeyZ();
        protected void SetCursor(Point cursorPoint)
        {
            Console.SetCursorPosition(cursorPoint.x, cursorPoint.y);
        }

        #region 스테이터스 화면
        protected void PrintStatus()
        {
            SetCursor(statusPoint);
            Console.WriteLine($"레벨: {player.level,6}");
            statusPoint.y++;
            SetCursor(statusPoint);
            Console.WriteLine($"체력: {player.curHp,5}/{player.maxHp}");
            statusPoint.y++;
            SetCursor(statusPoint);
            Console.WriteLine($"공격력: {player.power,5}");
            statusPoint.y++;
            SetCursor(statusPoint);
            Console.WriteLine($"경험치: {player.curExp,3}/{player.maxExp}");
            statusPoint.y = y;
        }

        #endregion
        #region 제작템 확인
        protected void PrintCollectItem()
        {

            SetCursor(collectionPoint);
            CollectFirst();

            collectionPoint.x += 5;
            SetCursor(collectionPoint);
            CollectThird();

            collectionPoint.y += 2;
            SetCursor(collectionPoint);
            CollectSecond();

            collectionPoint.x -= 5;
            SetCursor(collectionPoint);
            CollectFourth();

            collectionPoint.y += 2;
            SetCursor(collectionPoint);
            CompleteItem();

            collectionPoint.x = X - 15;
            collectionPoint.y = Y;
        }
        public void CollectFirst()
        {
            if (player.craftInventory.checking[(int)ItemType.Bandage])
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("붕대");
                Console.ResetColor();
                return;
            }
            Console.WriteLine("붕대");
        }
        public void CollectSecond()
        {
            if (player.craftInventory.checking[(int)ItemType.Scrap])
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("고철");
                Console.ResetColor();
                return;
            }
            Console.WriteLine("고철");
        }
        public void CollectThird()
        {
            if (player.craftInventory.checking[(int)ItemType.Shirt])
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("셔츠");
                Console.ResetColor();
                return;
            }
            Console.WriteLine("셔츠");
        }
        public void CollectFourth()
        {
            if (player.craftInventory.checking[(int)ItemType.ShortRod])
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("단봉");
                Console.ResetColor();
                return;
            }
            Console.WriteLine("단봉");
        }
        public void CompleteItem()
        {
            if (player.craftInventory.completion)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("팔괘장 획득");
                Console.ResetColor();
            }
        }
        #endregion
        #region 키 안내
        private void PrintInformationKey()
        {
            SetCursor(informationKey);
            Console.WriteLine("↑ ↓ → ← 이동");
            informationKey.y++;

            SetCursor(informationKey);
            Console.WriteLine("Z: 선택");

            informationKey.y = y;
        }
        #endregion
    }
}
