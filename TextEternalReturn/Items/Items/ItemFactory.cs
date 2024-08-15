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
        public Item Create(ItemType name)
        {
            if (name == ItemType.Axe)
            {
                Item item = new Axe();
                item.name = "도끼";
                item.id = (int)ItemType.Axe;
                return item;
            }
            else if (name == ItemType.Chain)
            {
                Item item = new Chain();
                item.name = "사슬";
                item.id = (int)ItemType.Chain;
                return item;
            }
            else if (name == ItemType.Cloth)
            {
                Item item = new Cloth();
                item.name = "옷감";
                item.id = (int)ItemType.Cloth;
                return item;
            }
            else if (name == ItemType.Oil)
            {
                Item item = new Oil();
                item.name = "오일";
                item.id = (int)ItemType.Oil;
                return item;
            }
            else if (name == ItemType.Paper)
            {
                Item item = new Paper();
                item.name = "종이";
                item.id = (int)ItemType.Paper;
                return item;
            }
            else if (name == ItemType.Rubber)
            {
                Item item = new Rubber();
                item.name = "고무";
                item.id = (int)ItemType.Rubber;
                return item;
            }
            else if (name == ItemType.Sisser)
            {
                Item item = new Sisser();
                item.name = "가위";
                item.id = (int)ItemType.Sisser;
                return item;
            }
            else if (name == ItemType.Bandage)
            {
                Item item = new Bandage();
                item.name = "붕대";
                item.id = (int)ItemType.Bandage;
                return item;
            }
            else if (name == ItemType.Scrap)
            {
                Item item = new Scrap();
                item.name = "고철";
                item.id = (int)ItemType.Scrap;
                return item;
            }
            else if (name == ItemType.Shirt)
            {
                Item item = new Shirt();
                item.name = "셔츠";
                item.id = (int)ItemType.Shirt;
                return item;
            }
            else if (name == ItemType.ShortRod)
            {
                Item item = new ShortRod();
                item.name = "단봉";
                item.id = (int)ItemType.ShortRod;
                return item;
            }
            return null;
        }
        public Item RandomCreate()
        {
            ItemType random = (ItemType) Util.GetRandom(0, (int)ItemType.Bandage - 1);
            return Create(random);
        }
    }
}
