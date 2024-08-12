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
        List<Item> inventory;
        // 자동으로 음식먹어주는 우선순위 큐
        PriorityMinQueue autoEating;
        public Inventory()
        {
            inventory = new List<Item>(10);          
            autoEating = new PriorityMinQueue(inventory.Capacity);
        }
        public void GetItem(Item item)
        {
            if (inventory.Count == inventory.Capacity)
                return;
            inventory.Add(item);
            Food food = item as Food;
            if ( food != null)
            {
                autoEating.Enqueue(food, food.id);
            }
        }
        // 아이템 사용하기
        public void UseItem(int key)
        {
            //리스트에서 빼면서 아이템의 효과(메서드) 사용
        }
        // 아이템 버리기
        public void ThrowItem(int key)
        {
            inventory.RemoveAt(key);
            Food food = inventory[key - 1] as Food;
            if (food != null) 
            {
                autoEating.Remove(food);
            }
        }
        // 아이템 자동 사용하기
    }
}
