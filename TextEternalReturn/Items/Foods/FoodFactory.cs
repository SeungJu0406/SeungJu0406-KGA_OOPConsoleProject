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
                food.Probability = 0;
                return food;
            }
            else if (foodType == FoodType.FishCuttlet)
            {
                Food food = new FishCutlet();
                food.name = "생선까스";
                food.recovery = 600;
                food.id = (int)FoodType.FishCuttlet;
                food.Probability = 0;
                return food;
            }
            else if (foodType == FoodType.Steak)
            {
                Food food = new FishCutlet();
                food.name = "스테이크";
                food.recovery = 550;
                food.id = (int)FoodType.Steak;
                food.Probability = 0;
                return food;
            }
            else if (foodType == FoodType.Salmon)
            {
                Food food = new Salmon();
                food.name = "연어";
                food.recovery = 300;
                food.id = (int)FoodType.Salmon;
                food.Probability = 20;
                return food;
            }
            else if (foodType == FoodType.CodFish)
            {
                Food food = new CodFish();
                food.name = "대구";
                food.recovery = 300;
                food.id = (int)FoodType.CodFish;
                food.Probability = 80;
                return food;
            }
            else if (foodType == FoodType.Meat)
            {
                Food food = new Meat();
                food.name = "고기";
                food.recovery = 300;
                food.id = (int)FoodType.Meat;
                food.Probability = 0;
                return food;
            }
            return null;
        }
    }


}
