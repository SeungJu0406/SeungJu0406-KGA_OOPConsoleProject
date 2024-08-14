using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Items.Foods;

namespace TextEternalReturn.Monsters.Monsters
{
    public class Hyunwoo : Monster
    {
        public Hyunwoo()
        {
            name = "현우";
            maxHp = 1000;
            curHp = 1000;
            power = 100;
        }
        public Hyunwoo GetHyunwoo()
        {
            return this;
        }
    }
}
