using System.Runtime.InteropServices;
using TextEternalReturn.Items;
using TextEternalReturn.Items.Items;
using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes.Scenes.ChestScenes
{
    internal class ChestScene : Scene
    {
        protected enum Pos { Item0, Item7, Exit, SIZE }
        protected ItemFactory itemFactory = new ItemFactory();
        protected List<Item> items = new List<Item>(8);
        protected Point[] points;
        public ChestScene(Player player) : base(player)
        {
            points = new Point[(int)Pos.SIZE];
            points[(int)Pos.Item0] = new Point() { x = X, y = Y };
            points[(int)Pos.Item7] = new Point() { x = Y, y = Y + items.Count - 1 };
            points[(int)Pos.Exit] = new Point() { x = X + 20, y = Y };
            SetItem();
        }
        public override void Render()
        {
            PrintChest();
        }
        public override void Update()
        {

        }
        public override void Enter()
        {

        }
        public override void Exit()
        {
            game.prevScene = this;
        }

        protected void SetItem()
        {
            for (int i = 0; i < 7; i++)
            {
                items.Add(itemFactory.RandomCreate());
            }
        }
        protected void PrintChest()
        {
            Point itemPos = points[(int)Pos.Item0];
            foreach (Item item in items)
            {
                
            }
        }
    }
}
