using TextEternalReturn.Items.Foods;
using TextEternalReturn.Monsters.Monsters;

namespace TextEternalReturn.Monsters
{
    public class MonsterFactory
    {
        FoodFactory foodFactory = new FoodFactory();
        Hyunwoo hyunwoo = new Hyunwoo();
        public MonsterFactory() 
        {
            
        }
        public Monster Create(MonsterType monsterType)
        {
            if (monsterType == MonsterType.Chicken)
            {
                Monster monster = new Chicken();
                monster.name = "닭";
                monster.maxHp = 50;
                monster.curHp = 50;
                monster.power = 10;
                monster.exp = 5;
                monster.reward = foodFactory.Create(FoodType.Meat);
                return monster;
            }
            else if (monsterType == MonsterType.WildBoar)
            {
                Monster monster = new WildBoar();
                monster.name = "멧돼지";
                monster.maxHp = 200;
                monster.curHp = 200;
                monster.power = 30;
                monster.exp = 15;
                monster.reward = foodFactory.Create(FoodType.Meat);
                return monster;
            }
            else if (monsterType == MonsterType.Wolf)
            {
                Monster monster = new WildBoar();
                monster.name = "늑대";
                monster.maxHp = 150;
                monster.curHp = 150;
                monster.power = 20;
                monster.exp = 10;
                monster.reward = foodFactory.Create(FoodType.Meat);
                return monster;
            }
            else if (monsterType == MonsterType.Bear)
            {
                Monster monster = new WildBoar();
                monster.name = "곰";
                monster.maxHp = 500;
                monster.curHp = 500;
                monster.power = 75;
                monster.exp = 50;
                monster.reward = foodFactory.Create(FoodType.Meat);
                return monster;
            }
            else if (monsterType == MonsterType.Hyunwoo)
            {
                Monster monster = hyunwoo.GetHyunwoo();
                monster.exp = 0;
                monster.reward = foodFactory.Create(FoodType.Meat);
                return monster;
            }
            return null;
        }
        public Monster CreateRandom()
        {
            int random = Util.GetRandom(0, (int)MonsterType.Hyunwoo - 1);
            return Create((MonsterType)random);
        }
    }
}
