using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Items;

namespace TextEternalReturn.Players
{
    public class CraftInventory
    {
        List<Item> inventory;
        Player player;
        public CraftInventory(Player player)
        {
            this.player = player;
            inventory = new List<Item>(4);
        }
        public void GetItem(Item item)
        {
            if(inventory.Count < inventory.Capacity)
            {
                inventory.Add(item);
            }
        }
    }
}
