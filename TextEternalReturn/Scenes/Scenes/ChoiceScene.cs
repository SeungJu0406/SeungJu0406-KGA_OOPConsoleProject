﻿using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes.Scenes
{
    public class ChoiceScene : Scene
    {
        enum CursorPoint { AnimalHunt, MoveMap, CheckInventory, SIZE }
        public struct Point()
        {
            public int x, y;
            public SceneType scene;
        }
        Point[] points = new Point[3];
        Point curPoint;    
        public ChoiceScene(Player player) : base(player)
        {
            points[(int)CursorPoint.AnimalHunt] = new Point() { x = 0, y = 4, scene = SceneType.BattleScene };
            int X = points[(int)CursorPoint.AnimalHunt].x;
            int Y = points[(int)CursorPoint.AnimalHunt].y;
            points[(int)CursorPoint.MoveMap] = new Point() { x = X, y = Y+1, scene = SceneType.MapScene };
            points[(int)CursorPoint.CheckInventory] = new Point() { x = X, y = Y+2, scene = SceneType.InventoryScene };
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
            PrintStatus();
            PrintChoice();
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("▶");
            Console.ResetColor();
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
        #region 커서 옮기기
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
        #endregion
        private void SetCursor(Point cursorPoint)
        {
            Console.SetCursorPosition(cursorPoint.x, cursorPoint.y);
        }
    }
}
