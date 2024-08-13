using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Items;
using TextEternalReturn.Items.Foods;
using TextEternalReturn.Items.Foods.Foods;

namespace TextEternalReturn.Players
{
    public class Inventory
    {
        // Food를 담을수있는 인벤토리 
        public List<Item> inventory {  get; private set; }
        // 자동으로 음식먹어주는 우선순위 큐
        PriorityMinQueue autoQueue;
        Player player;

        public Inventory(Player player)
        {
            this.player = player;
            inventory = new List<Item>(10);          
            autoQueue = new PriorityMinQueue(inventory.Capacity);
            player.OnLoseHp += UseAuto;
        }
        public void GetItem(Item item)
        {
            if (inventory.Count == inventory.Capacity)
                return;
            inventory.Add(item);
            Food food = item as Food;
            if ( food != null)
            {
                autoQueue.Enqueue(food, food.id);
            }
        }
        // 아이템 사용하기
        public void UseItem(int key)
        {
            //리스트에서 빼면서 아이템의 효과(메서드) 사용
            if (inventory[key] is Food)
            {
                Food food = inventory[key] as Food;
                food.Use(player);
                inventory.Remove(food);
                autoQueue.Remove(food);

            }
            else
                return;
        }
        // 아이템 버리기
        public void ThrowItem(Item item)
        {
            inventory.Remove(item);
            Food food = item as Food;
            if (food != null) 
            {
                autoQueue.Remove(food);
            }
        }
        // 아이템 자동 사용하기
        private void UseAuto()
        {
            Food food = autoQueue.Dequeue();
            inventory.Remove(food);
            if(food != null)
                food.Use(player);
        }
        
    }
}
