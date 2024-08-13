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
                food.priority = (int)FoodType.SalmonSteak;
                return food;
            }
            else if (foodType == FoodType.FishCuttlet)
            {
                Food food = new FishCutlet();
                food.name = "생선까스";
                food.recovery = 600;
                food.priority = (int)FoodType.FishCuttlet;
                return food;
            }
            else if (foodType == FoodType.Steak)
            {
                Food food = new FishCutlet();
                food.name = "스테이크";
                food.recovery = 550;
                food.priority = (int)FoodType.Steak;
                return food;
            }
            else if (foodType == FoodType.Salmon)
            {
                Food food = new Salmon();
                food.name = "연어";
                food.recovery = 300;
                food.priority = (int)FoodType.Salmon;
                return food;
            }
            else if (foodType == FoodType.CodFish)
            {
                Food food = new CodFish();
                food.name = "대구";
                food.recovery = 300;
                food.priority = (int)FoodType.CodFish;
                return food;
            }
            else if (foodType == FoodType.Meat)
            {
                Food food = new Meat();
                food.name = "고기";
                food.recovery = 300;
                food.priority = (int)FoodType.Meat;
                return food;
            }
            return null;
        }
    }


}
