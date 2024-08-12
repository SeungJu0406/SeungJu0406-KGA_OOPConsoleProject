using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEternalReturn.Items.Foods
{
    // 아이템 팩토리 이용
    public abstract class Food : Item
    {      
        public int recovery { get; set; }
        public Food()
        {

        }
    }
}
