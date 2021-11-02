using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_TASK_2
{
    class Mage : Enemy
    {
        public Mage(int x, int y) : base(x, y, 'M', 5, 5)
        {

        }

        public override MovementEnum ReturnMove(MovementEnum move = MovementEnum.NoMovement)
        {
            return MovementEnum.NoMovement;
        }

        public override bool CheckRange(Character thisMage)
        {

            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return "Mage " + base.ToString(); //Simply adds the word "Goblin" to the enemy output.
        }
    }
}
