using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE
{
    [Serializable]
    class Mage : Enemy
    {
        public Mage(int x, int y) : base(x, y, 'M', 5, 5)
        {
            GoldPurse = 3;
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
            
        }
        public override string ToString()
        {
            //string equipped;
            //if (weaponInventory == null)
            //{
            //    equipped = "Barehanded: ";
            //}
            //else
            //{
            //    equipped = weaponInventory.WeaponTypeString;
            //}
            //return equipped+"Mage " + base.ToString(); //Simply adds the word "Goblin" to the enemy output.
            return base.ToString();
        }
    }
}
