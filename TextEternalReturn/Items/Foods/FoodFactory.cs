using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Items.Foods;
using TextEternalReturn.Items.Foods.Foods;


namespace TextEternalReturn.Items.Foods
{
    public class FoodFactory
    {
        public Food Create(FoodType foodType)
        {
            if (foodType == FoodType.SalmonSteak)
            {
                Food food = new SalmonSteak();
                food.name = "연어 스테이크";
                food.recovery = 840;
                food.id = (int)FoodType.SalmonSteak;
                return food;
            }
            else if (foodType == FoodType.FishCuttlet)
            {
                Food food = new FishCutlet();
                food.name = "생선까스";
                food.recovery = 600;
                return food;
            }
            else if (foodType == FoodType.Steak)
            {
                Food food = new FishCutlet();
                food.name = "스테이크";
                food.recovery = 550;
                return food;
            }
            else if (foodType == FoodType.Salmon)
            {
                Food food = new Salmon();
                food.name = "연어";
                food.recovery = 300;
                return food;
            }
            else if (foodType == FoodType.CodFish)
            {
                Food food = new CodFish();
                food.name = "대구";
                food.recovery = 300;
                return food;
            }
            else if (foodType == FoodType.Meat)
            {
                Food food = new Meat();
                food.name = "고기";
                food.recovery = 300;
                return food;
            }
            return null;
        }
    }


}
