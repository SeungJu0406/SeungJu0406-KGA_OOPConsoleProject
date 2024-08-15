using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Players;

namespace TextEternalReturn.Scenes.Scenes.ChestScenes.Chests
{
    internal class AlleyChest : ChestScene
    {
        public AlleyChest(Player player) : base(player)
        {
            SceneID = (int)SceneType.AlleyChest;
            items.Insert(Util.GetRandom(0, 6), itemFactory.Create(ItemType.Shirt));
        }
    }
}
