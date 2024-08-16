using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Players;
using TextEternalReturn.Items.Foods;

namespace TextEternalReturn.Items.Foods
{
    public abstract class Food : Item
    {
        public int recovery { get; set; }
        public int Probability { get; set; }
        public Food()
        {

        }
        public void Use(Player player)
        {
            player.curHp += recovery;
            if(player.curHp > player.maxHp)
            {
                player.curHp = player.maxHp;
            }
        }
    }
}
