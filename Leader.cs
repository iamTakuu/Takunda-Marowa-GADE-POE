using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE
{
    class Leader : Enemy
    {
        public Leader(int x, int y) : base(x, y, 'L', 20, 2)
        {
        }

        public override MovementEnum ReturnMove(MovementEnum move = MovementEnum.NoMovement)
        {
            throw new NotImplementedException();
        }
    }
}
