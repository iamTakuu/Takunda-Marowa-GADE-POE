using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_TASK_2
{
    abstract class Item : Tile
    {
        protected Item(int x, int y, char symbol) : base(x, y, symbol)
        {

        }

        public abstract override string ToString();
    
    }
}
