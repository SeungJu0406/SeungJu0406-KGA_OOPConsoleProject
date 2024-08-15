using TextEternalReturn.Players;
using TextEternalReturn.Scenes;

namespace TextEternalReturn.Scenes.Scenes
{
    public class ChoiceScene : Scene
    {
        enum Pos { Battle, Map, Inventory, SIZE }
        Point[] points = new Point[(int)Pos.SIZE];
        Point curPoint;
        public ChoiceScene(Player player) : base(player)
        {
            points[(int)Pos.Battle] = new Point() { x = X, y = Y };
            points[(int)Pos.Map] = new Point() { x = X, y = Y + 1 };
            points[(int)Pos.Inventory] = new Point() { x = X, y = Y + 2 };
        }
        public override void Enter()
        {
            Console.Clear();
            curPoint = points[(int)Pos.Battle];
        }

        public override void Exit()
        {
            game.prevScene = this;
        }
        public override void Render()
        {
            PrintStatus();
            PrintChoice();
        }
        public override void Update()
        {
            UpdateKey();
        }

        private void PrintChoice()
        {
            SetCursor(points[(int)Pos.Battle]);
            Console.WriteLine("▷ 동물 잡기");
            SetCursor(points[(int)Pos.Map]);
            Console.WriteLine("▷ 이동 하기");
            SetCursor(points[(int)Pos.Inventory]);
            Console.WriteLine("▷ 아이템 확인");

            SetCursor(curPoint);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("▶");
            Console.ResetColor();
        }
        protected override void PushKeyZ()
        {
            if (curPoint.y == points[(int)Pos.Battle].y)
            {
                game.ChangeScene(SceneType.BattleScene);
            }
            else if(curPoint.y == points[(int)Pos.Map].y)
            {
                game.ChangeScene(SceneType.MapScene);
            }
            else if (curPoint.y == points[(int)Pos.Inventory].y)
            {
                game.ChangeScene(SceneType.InventoryScene);
            }
        }
        #region 커서 옮기기
        protected override void MoveUpCursor()
        {
            if(curPoint.y > points[(int)Pos.Battle].y)
            {
                curPoint.y -= 1;
            }
        }
        protected override void MoveDownCursor()
        {
            if (curPoint.y < points[(int)Pos.Inventory].y)
            {
                curPoint.y += 1;
            }
        }
        #endregion
    }
}
