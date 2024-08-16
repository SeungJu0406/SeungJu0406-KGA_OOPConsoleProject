using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEternalReturn.Players;
using TextEternalReturn.Items.Foods;

namespace TextEternalReturn
{
    public interface IAttack
    {
        void Attack(IHit Ihit);
    }
    public interface IHit
    {
        void Hit(int power);
    }
    public interface IDie
    {
        void Die();
    }
}
