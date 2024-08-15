using TextEternalReturn.Monsters;
using TextEternalReturn.Monsters.Monsters;
using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes.Scenes
{
    public class BattleScene : Scene
    {
        public enum Pos { Attack, UseItem, Run, SIZE }
        public struct Point
        {
            public int x, y;
            public Pos choice;
        }
        Scene prevScene;
        Point mobStatusPoint;
        Monster monster;
        MonsterFactory mobFactory = new MonsterFactory();

        Point[] points = new Point[(int)Pos.SIZE];
        Point curPoint;

        public BattleScene(Player player) : base(player)
        {
            mobStatusPoint = new Point() { x = statusPoint.x + 20, y = statusPoint.y };
            points[(int)Pos.Attack] = new Point() { x = X, y = Y, choice = Pos.Attack };
            points[(int)Pos.UseItem] = new Point() { x = X + 20, y = Y, choice = Pos.UseItem };
            points[(int)Pos.Run] = new Point() { x = X, y = Y + 1, choice = Pos.Run };
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
            if (game.battleHyun)
            {
                monster = mobFactory.Create(MonsterType.Hyunwoo);
                curPoint = points[(int)Pos.Attack];
                prevScene = game.prevScene;
                game.battleHyun = false;
                return;
            }
            if (!(game.prevScene is InventoryScene))
            {
                monster = mobFactory.CreateRandom();
                curPoint = points[(int)Pos.Attack];
                prevScene = game.prevScene;
                return;
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
            SetCursor(points[(int)Pos.Attack]);
            Console.WriteLine("▷ 공격하기");
            SetCursor(points[(int)Pos.UseItem]);
            Console.WriteLine("▷ 아이템 사용");
            SetCursor(points[(int)Pos.Run]);
            Console.WriteLine("▷ 도망가기");
            SetCursor(curPoint);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("▶");
            Console.ResetColor();
        }
        protected override void PushKeyZ()
        {
            player.CheckLoseHp();
            switch (curPoint.choice)
            {
                case Pos.Attack:
                    Attack();
                    break;
                case Pos.UseItem:
                    UseItem();
                    break;
                case Pos.Run:
                    Run();
                    break;
                default:
                    break;
            }
        }
        private void Attack()
        {
            player.Attack(monster);
            if (monster.isDie)
            {
                DieMonster(monster);
                return;
            }
            monster.Attack(player);
            if (player.isDie)
            {
                game.isWin = false;
                game.ChangeScene(SceneType.EndScene);
                return;
            }
        }
        private void DieMonster(Monster monster)
        {
            if (monster is Hyunwoo)
            {
                game.isWin = true;
                game.ChangeScene(SceneType.EndScene);
                return;
            }
            player.GetExp(monster.exp);
            player.GetFood(monster.reward);
            Run();
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
        protected override void MoveUpCursor() // 1이하는 위쪽으로 못감
        {
            if ((int)curPoint.choice > 1)
            {
                curPoint = points[(int)curPoint.choice - 2];
            }
        }
        protected override void MoveDownCursor() // SIZE-2 이상은 위로 못감
        {
            if ((int)curPoint.choice < (int)Pos.SIZE - 2)
            {
                curPoint = points[(int)curPoint.choice + 2];
            }
        }
        protected override void MoveLeftCursor() // 짝수라면 왼쪽못감
        {
            if ((int)curPoint.choice % 2 != 0)
            {
                curPoint = points[(int)curPoint.choice - 1];
            }
        }
        protected override void MoveRightCursor()
        {
            if ((int)curPoint.choice % 2 == 0 &&
                (int)curPoint.choice + 1 != (int)Pos.SIZE)
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
