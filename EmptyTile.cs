using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Takunda Marowa 20123325
namespace GADE_TASK_2
{
    /// <summary>
    /// Merely exists to denote an empty tiel boi
    /// </summary>
    [Serializable]
    class EmptyTile : Tile
    {
        public EmptyTile(int x, int y) : base(x, y, '.')
        {

        }

    }
}
