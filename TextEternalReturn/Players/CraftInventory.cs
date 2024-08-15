using TextEternalReturn.Items;

namespace TextEternalReturn.Players
{
    public class CraftInventory
    {
        public bool[] checking;
        public bool completion;
        public List<Item> inventory;
        Player player;
        public CraftInventory(Player player)
        {
            this.player = player;
            checking = new bool[(int)ItemType.SIZE];
            inventory = new List<Item>((int)ItemType.SIZE);
        }
        public void GetItem(Item item)
        {
            CheckItem(item);
            inventory.Add(item);
        }
        public void CheckItem(Item item)
        {
            checking[item.id] = true;
            if (!(checking[(int)ItemType.Bandage]))
                return;
            if (!(checking[(int)ItemType.Scrap]))
                return;
            if (!(checking[(int)ItemType.Shirt]))
                return;
            if (!(checking[(int)ItemType.ShortRod]))
                return;
            completion = true;
        }
    }
}
