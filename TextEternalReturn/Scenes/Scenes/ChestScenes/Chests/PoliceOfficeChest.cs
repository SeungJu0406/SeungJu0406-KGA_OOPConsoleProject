using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes.Scenes.ChestScenes.Chests
{
    internal class PoliceOfficeChest : ChestScene
    {
        public PoliceOfficeChest(Player player) : base(player)
        {
            SceneID = (int)SceneType.PoliceOfficeChest;
            items.Insert(Util.GetRandom(0, 6), itemFactory.Create(ItemType.Shirt));
        }
    }
}
