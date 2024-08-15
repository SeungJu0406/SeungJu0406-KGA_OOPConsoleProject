using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Items.Items.Need;
using TextEternalReturn.Items.Items.NotNeed;

namespace TextEternalReturn.Items.Items
{
    public class ItemFactory
    {
        public Item Create(ItemName name)
        {
            if (name == ItemName.Axe)
            {
                Item item = new Axe();
                return item;
            }
            else if (name == ItemName.Chain)
            {
                Item item = new Chain();
                return item;
            }
            else if (name == ItemName.Cloth)
            {
                Item item = new Cloth();
                return item;
            }
            else if (name == ItemName.Oil)
            {
                Item item = new Oil();
                return item;
            }
            else if (name == ItemName.Paper)
            {
                Item item = new Paper();
                return item;
            }
            else if (name == ItemName.Rubber)
            {
                Item item = new Rubber();
                return item;
            }
            else if (name == ItemName.Sisser)
            {
                Item item = new Sisser();
                return item;
            }
            else if (name == ItemName.Bandage)
            {
                Item item = new Bandage();
                return item;
            }
            else if (name == ItemName.Scrap)
            {
                Item item = new Scrap();
                return item;
            }
            else if (name == ItemName.Shirt)
            {
                Item item = new Shirt();
                return item;
            }
            else if (name == ItemName.ShortRod)
            {
                Item item = new ShortRod();
                return item;
            }
        }
        public Item RandomCreate()
        {
            ItemName random = (ItemName) Util.GetRandom(0, (int)ItemName.Bandage - 1);
            return Create(random);
        }
    }
}
