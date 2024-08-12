using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Items;
using TextEternalReturn.Items.Foods;

namespace TextEternalReturn.Players
{
    public class Inventory
    {
        // Food를 담을수있는 인벤토리 
        Item[] inventory;
        int Count;
        int Capacitor;
        // 자동으로 음식먹어주는 우선순위 큐
        PriorityMinQueue autoEating;
        public Inventory()
        {
            Count = 0;
            Capacitor = 10;
            inventory = new Item[Capacitor];          
            autoEating = new PriorityMinQueue(inventory.Length);
        }
        public void GetItem(Item item)
        {
            if (Count == Capacitor)
                return;
            inventory[Count] = item;
            if (item as Food != null)
            {
                //autoEating.Enqueue(item,);
            }
        }
    }
}
