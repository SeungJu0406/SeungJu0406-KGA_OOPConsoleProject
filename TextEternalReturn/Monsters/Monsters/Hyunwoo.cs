using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Items.Foods;

namespace TextEternalReturn.Monsters.Monsters
{
    public class Hyunwoo : Monster
    {
        public Action OnLoseHp;

        public Hyunwoo()
        {
            name = "현우";
            maxHp = 5000;
            curHp = 5000;
            power = 500;
        }
        public Hyunwoo GetHyunwoo()
        {
            return this;
        }
        #region 체력 30% 이하 감지
        /// <summary>
        /// 체력 30% 이하 감지
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
            return curHp < maxHp * 0.3;
        }

        #endregion
    }
}
