using TextEternalReturn.Monsters;
using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes.Scenes
{
    public class BattleScene : Scene
    {
        public enum Choice { Attack, UseItem, Run, SIZE }
        public struct Point
        {
            public int x, y;
            public Choice choice;
        }
        Scene prevScene;

        Point mobStatusPoint;
        Monster monster;
        MonsterFactory mobFactory = new MonsterFactory();

        Point[] points = new Point[3];
        Point curPoint;

        public BattleScene(Player player) : base(player)
        {
            int X = statusPoint.x;
            int Y = statusPoint.y + 4;
            mobStatusPoint = new Point() { x = statusPoint.x + 20, y = statusPoint.y };
            points[(int)Choice.Attack] = new Point() { x = X, y = Y, choice = Choice.Attack };
            points[(int)Choice.UseItem] = new Point() { x = X + 20, y = Y, choice = Choice.UseItem };
            points[(int)Choice.Run] = new Point() { x = X, y = Y + 1, choice = Choice.Run };
        }
        public override void Render()
        {
            PrintStatus();
            PrintMobStatus();
            PrintBattleChoice();
        }
        public override void Update()
        {
            UpdateKey();
        }

        public override void Enter()
        {
            Console.Clear();
            if (!(game.prevScene is InventoryScene))
            {
                monster = mobFactory.CreateRandom();
                curPoint = points[(int)Choice.Attack];
                prevScene = game.prevScene;
            }
        }
        public override void Exit()
        {
            game.prevScene = this;
        }
        private void PrintMobStatus()
        {
            SetCursor(mobStatusPoint);
            Console.WriteLine($"{monster.name}");
            mobStatusPoint.y++;
            SetCursor(mobStatusPoint);
            Console.WriteLine($"체력: {monster.curHp,5}/{monster.maxHp}");
            mobStatusPoint.y++;
            SetCursor(mobStatusPoint);
            Console.WriteLine($"공격력: {monster.power,5}");
            mobStatusPoint.y = statusPoint.y;
        }
        private void PrintBattleChoice()
        {
            SetCursor(points[(int)Choice.Attack]);
            Console.WriteLine("▷ 공격하기");
            SetCursor(points[(int)Choice.UseItem]);
            Console.WriteLine("▷ 아이템 사용");
            SetCursor(points[(int)Choice.Run]);
            Console.WriteLine("▷ 도망가기");
            SetCursor(curPoint);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("▶");
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
            switch (curPoint.choice)
            {
                case Choice.Attack:
                    Attack();
                    break;
                case Choice.UseItem:
                    UseItem();
                    break;
                case Choice.Run:
                    Run();
                    break;
                default:
                    break;
            }
        }
        private void Attack()
        {
            // 플레이어가 몬스터를 공격
            // 플레이어 공격 후 몬스터도 공격
            player.Attack(monster);
            if (monster.isDie)
            {
                player.GetItem(monster.reward);
                Run();
                return;
            }
            monster.Attack(player);
            if (player.isDie)
            {
                game.ChangeScene(SceneType.EndScene);
                return;
            }
        }
        private void UseItem()
        {
            game.ChangeScene(SceneType.InventoryScene);
        }
        private void Run()
        {
            int prevSceneIndex = Array.IndexOf(game.sceneList, prevScene);
            game.ChangeScene((SceneType)prevSceneIndex);
        }
        #region 커서 옮기기
        private void MoveUpCursor() // 1이하는 위쪽으로 못감
        {
            if ((int)curPoint.choice > 1)
            {
                curPoint = points[(int)curPoint.choice - 2];
            }
        }
        private void MoveDownCursor() // SIZE-2 이상은 위로 못감
        {
            if ((int)curPoint.choice < (int)Choice.SIZE - 2)
            {
                curPoint = points[(int)curPoint.choice + 2];
            }
        }
        private void MoveLeftCursor() // 짝수라면 왼쪽못감
        {
            if ((int)curPoint.choice % 2 != 0)
            {
                curPoint = points[(int)curPoint.choice - 1];
            }
        }
        private void MoveRightCursor()
        {
            if ((int)curPoint.choice % 2 == 0 &&
                (int)curPoint.choice + 1 != (int)Choice.SIZE)
            {
                curPoint = points[(int)curPoint.choice + 1];
            }
        }
        #endregion
        private void SetCursor(Point cursorPoint)
        {
            Console.SetCursorPosition(cursorPoint.x, cursorPoint.y);
        }
    }
}
