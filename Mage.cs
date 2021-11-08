using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_TASK_2
{
    [Serializable]
    class Mage : Enemy
    {
        public Mage(int x, int y) : base(x, y, 'M', 5, 5)
        {

        }

        public override MovementEnum ReturnMove(MovementEnum move = MovementEnum.NoMovement)
        {
            return MovementEnum.NoMovement;
        }

        public override bool CheckRange(Character target)
        {
            //use for loop outside to grab each item in the game and check for damage stuffs
            if ( (this.Y_ - 1 == target.Y_) && (this.X_ == target.X_) ) //Up
            {
                return true;
            }
            else if ( (this.Y + 1 == target.Y_) && (this.X_ == target.X_)) //Down
            {
                return true;
            }
            else if ((this.X_ - 1 == target.X_) && (this.Y_ == target.Y_)) //Left
            {
                return true;
            }
            else if ( (this.X_ + 1 == target.X_) && (this.Y_ == target.Y_)) //Right
            {
                return true;
            }
            else if ((this.Y_ - 1 == target.Y_) && (this.X_ - 1 == target.X_)) //Up & Left
            {
                return true;
            }
            else if ((this.Y_ - 1 == target.Y_) && (this.X_ + 1 == target.X_)) //Up Right
            {
                return true;
            }
            else if ((this.Y + 1 == target.Y_) && (this.X_ - 1 == target.X_)) //Down Left
            {
                return true;
            }
            else if ((this.Y + 1 == target.Y_) && (this.X_ + 1 == target.X_)) //Down Right
            {
                return true;
            }

            return false;
            //throw new NotImplementedException();
            //if ( Math.Abs(this.Y_ - target.Y_) == 1) //Checks above
            //{
            //    return true;
            //}
            //else if (Math.Abs(target.Y_ - this.Y_) == 1) //Checks below
            //{
            //    return true;
            //}
            //else if (Math.Abs(this.X_ - target.X_) == 1) //Checks left
            //{
            //    return true;
            //}
            //else if (Math.Abs(target.X_ - this.X_) ==1) //Checks right
            //{
            //    return true;
            //}
            //else if ( (Math.Abs(target.Y_ - Y) + Math.Abs(target.X_ - X)) == 2) //Allows for all diagonal
            //{

            //}
        }
        public override string ToString()
        {
            return "Mage " + base.ToString(); //Simply adds the word "Goblin" to the enemy output.
        }
    }
}
