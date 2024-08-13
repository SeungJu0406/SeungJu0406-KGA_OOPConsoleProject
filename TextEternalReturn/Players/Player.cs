﻿using System;
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
        public Inventory inventory;
        public int maxHp { get; set; }
        public int curHp { get; set; }
        public int power { get; set; }
        public int exp { get; set; }
        public bool isDie { get; private set; }
        public Action OnLoseHp;
        public Player()
        {
            inventory = new Inventory(this);
            maxHp = 600;
            curHp = 600;
            power = 70;
            exp = 0;
        }
        public void Attack(IHit Ihit)
        {
            Ihit.Hit(power);
        }
        public void Hit(int power)
        {
            curHp -= power;
            if (curHp < 0)
            {
                curHp = 0;
                Die();
            }
        }
        public void Die()
        {
            isDie = true;
        }
        public void GetItem(Item item)
        {
            inventory.GetItem(item);
        }
        public void UseItem(int itemKey)
        {
            inventory.UseItem(itemKey);
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
