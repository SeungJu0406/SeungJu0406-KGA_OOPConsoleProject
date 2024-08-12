using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Items.Foods.;
using TextEternalReturn.Items.Foods.Foods;


namespace TextEternalReturn.Items.Foods
{
    public class FoodFactory
    {
        public Item Create(FoodType foodType)
        {
            if (foodType == FoodType.SalmonSteak)
            {
                Item food = new SalmonSteak();
                food.name = "연어 스테이크";
                food.recovery = 840;
                return food;
            }
            else if (foodType == FoodType.FishCuttlet)
            {
                Item food = new FishCutlet();
                food.name = "생선까스";
                food.recovery = 600;
                return food;
            }
            else if (foodType == FoodType.Steak)
            {
                Item food = new FishCutlet();
                food.name = "스테이크";
                food.recovery = 550;
                return food;
            }
            else if (foodType == FoodType.Salmon)
            {
                Item food = new Salmon();
                food.name = "연어";
                food.recovery = 300;
                return food;
            }
            else if (foodType == FoodType.CodFish)
            {
                Item food = new CodFish();
                food.name = "대구";
                food.recovery = 300;
                return food;
            }
            else if (foodType == FoodType.Meat)
            {
                Item food = new Meat();
                food.name = "고기";
                food.recovery = 300;
                return food;
            }
            return null;
        }
    }


}
