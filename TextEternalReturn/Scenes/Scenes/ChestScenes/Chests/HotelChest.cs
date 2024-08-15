using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes.Scenes.ChestScenes.Chests
{
    internal class HotelChest : ChestScene
    {
        public HotelChest(Player player) : base(player)
        {
            for(int i = 0; i < 7; i++)
            {
                items[i] = itemFactory.RandomCreate();
            }
            items.Insert(Util.GetRandom(0, 6), itemFactory.Create(ItemName.Bandage));
        }
    }
}
