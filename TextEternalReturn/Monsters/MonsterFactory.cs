using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Monsters.Monsters;

namespace TextEternalReturn.Monsters
{
    public class MonsterFactory
    {
        public Monster Create(MonsterType monsterType)
        {
            if (monsterType == MonsterType.Chicken)
            {
                Monster monster = new Chicken();
                monster.name = "닭";
                monster.hp = 50;
                monster.power = 10;
                monster.exp = 50;
                return monster;
            }
            else if (monsterType == MonsterType.WildBoar) 
            {
                Monster monster = new WildBoar();
                monster.name = "멧돼지";
                monster.hp = 200;
                monster.power = 30;
                monster.exp = 150;
                return monster;
            }
            else if (monsterType == MonsterType.Wolf)
            {
                Monster monster = new WildBoar();
                monster.name = "늑대";
                monster.hp = 150;
                monster.power = 20;
                monster.exp = 125;
                return monster;
            }
            else if (monsterType == MonsterType.Bear)
            {
                Monster monster = new WildBoar();
                monster.name = "곰";
                monster.hp = 500;
                monster.power = 75;
                monster.exp = 400;
                return monster;
            }
            return null;
        }
    }
}
