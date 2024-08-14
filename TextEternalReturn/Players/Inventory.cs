using TextEternalReturn.Items;
using TextEternalReturn.Items.Foods;

namespace TextEternalReturn.Players
{
    public class Inventory
    {
        // Food를 담을수있는 인벤토리 
        public List<Food> inventory { get; private set; }
        // 자동으로 음식먹어주는 우선순위 큐
        Player player;
        public Action OnGetItem;
        public Action OnRemoveItem;
        public Inventory(Player player)
        {
            this.player = player;
            inventory = new List<Food>(10);
            player.OnLoseHp += UseAuto;
        }
        public void GetItem(Item item)
        {
            if (inventory.Count < inventory.Capacity)
            {
                Food food = item as Food;
                inventory.Add(food);
                OnGetItem?.Invoke();

            }
        }
        // 아이템 사용하기
        public void UseItem(int key)
        {
            Food food = inventory[key];
            food.Use(player);
            inventory.Remove(food);
            OnRemoveItem?.Invoke();
        }
        // 아이템 버리기
        public void ThrowItem(Food food)
        {
            inventory.Remove(food);
            OnRemoveItem?.Invoke();
        }
        // 아이템 자동 사용하기
        private void UseAuto()
        {
            if (inventory.Count > 0)
            {
                Food food = inventory[0];
                inventory.RemoveAt(0);
                OnRemoveItem?.Invoke();
                food.Use(player);
            }
        }
    }
}
