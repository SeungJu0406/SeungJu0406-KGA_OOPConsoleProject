using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Players;
using TextEternalReturn.Items;
using System.Net;

namespace TextEternalReturn.Scenes.Scenes
{
    internal class InventoryScene : Scene
    {
        List<Item> inventory;

        public InventoryScene(Game game,Player player) : base(game,player)
        {
            this.inventory = player.inventory.inventory;
        }
        public override void Render()
        {
            PrintInventory();
        }
        public override void Input()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Enter:
                    break;
            }
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

        }
        private void PrintInventory()
        {
            foreach(Item item in inventory)
            {
                Console.WriteLine($"▷ {item.name}");
            }
        }
    }
}
