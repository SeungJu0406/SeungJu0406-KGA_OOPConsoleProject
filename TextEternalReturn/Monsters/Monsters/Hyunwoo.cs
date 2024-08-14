using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEternalReturn.Monsters.Monsters
{
    public class Hyunwoo : Monster
    {
        public static Hyunwoo hyunwoo = new Hyunwoo();
        public string name = "현우";
        public int maxHp = 1000;
        public int curHp = 1000; 
        public int power = 100 
        private Hyunwoo(){ }
        public Hyunwoo GetHyunwoo()
        {
            return this;
        }
    }
}
