using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Items;
using TextEternalReturn.Items.Foods;

namespace TextEternalReturn.Monsters
{
    public class Monster : IAttack, IHit, IDie
    {
        public string name { get; set; }
        public int maxHp { get; set; }
        public int curHp { get; set; }
        public int power { get; set; }
        public Food reward { get; set; }
        public int exp { get; set; }
        public bool isDie { get; private set; }
        public void Attack(IHit Ihit)
        {
            Ihit.Hit(power);
        }
        public void Hit(int power)
        {
            curHp -= power;
            if (curHp <= 0) 
            {
                curHp = 0;
                Die();
            }
        }
        public virtual void Die()
        {
            isDie = true;
        }
    }
}
