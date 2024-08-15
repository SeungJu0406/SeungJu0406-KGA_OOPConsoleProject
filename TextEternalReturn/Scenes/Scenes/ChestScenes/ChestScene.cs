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
        protected Pos[] points;
        public ChestScene(Player player) : base(player) { }
        public override void Render()
        {

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

        private void SetItem()
        {

        }
    }
}
