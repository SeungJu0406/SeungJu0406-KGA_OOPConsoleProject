using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEternalReturn.Foods
{
    // 아이템 팩토리 이용
    public abstract class Food
    {
        public string name { get; set; }
        public int recovery { get; set; }
        public Food()
        {

        }
    }
}
