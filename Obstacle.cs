using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Takunda Marowa 20123325
namespace GADE_TASK_2
{
    //A subcalss of tile. Used to make boarders
    class Obstacle : Tile
    {
        //Constructor
        public Obstacle(int x, int y) : base(x, y, 'X') //It'll pass x and y to the BASE CONSTRUCTOR
        {

        }

    }
}
