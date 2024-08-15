using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Items.Foods;
using TextEternalReturn.Items;

namespace TextEternalReturn.Players
{
    public class Player : IAttack, IHit, IDie
    {
        public FoodInventory foodInventory;
        public CraftInventory craftInventory;
        public int level {  get; set; }
        public int maxHp { get; set; }
        public int curHp { get; set; }
        public int power { get; set; }
        public int curExp { get; set; }
        public int maxExp {  get; set; }
        public bool isDie { get; private set; }
        public Action OnLoseHp;
        public Player()
        {
            foodInventory = new FoodInventory(this);
            craftInventory = new CraftInventory(this);
            level = 1;
            maxHp = 600;
            curHp = 600;
            power = 70;
            curExp = 0;
            maxExp = 100;
        }
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
        public void Die()
        {
            isDie = true;
        }
        public void Rest()
        {
            curHp += (maxHp / 2);
            if (curHp > maxHp)
                curHp = maxHp;
        }
        public void GetExp(int exp)
        {
            curExp += exp;
            if (curExp>=maxExp)
            {
                level++;
                maxHp += 50;
                power += 10;
                maxExp += 20;
                curExp = 0;
            }
        }
        public void GetItem(Item item)
        {
            craftInventory.GetItem(item);
        }
        public void GetFood(Food food)
        {
            foodInventory.GetItem(food);
        }
        public void UseItem(int itemKey)
        {
            foodInventory.UseItem(itemKey);
        }
        #region 체력 40% 이하 감지
        /// <summary>
        /// 체력 40% 이하 감지
        /// </summary>
        /// 
        public void CheckLoseHp()
        {
            if (IsLoseHp())
            {
                OnLoseHp?.Invoke();
            }
        }
        private bool IsLoseHp()
        {
            return curHp < maxHp * 0.4;
        }

        #endregion
    }
}
