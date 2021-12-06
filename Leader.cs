using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE
{
    [Serializable]
    class Leader : Enemy
    {
        private Tile target;
        private Tile LeaderTarget { get { return (target); } set { target = value; } }
        
        public Leader(int x, int y, Hero hero) : base(x, y, 'L', 20, 2)
        {
            LeaderTarget = hero;
            GoldPurse = 2;
            weaponInventory = new MeleeWeapon(MeleeWeapon.MeleeType.Longsword);
        }

        public override MovementEnum ReturnMove(MovementEnum move = MovementEnum.NoMovement)
        {
            switch (MoveTowards())
            {
                case MovementEnum.NoMovement:
                    return (MovementEnum)0;
                    
                case MovementEnum.Up:
                    return (MovementEnum)1;
                    
                case MovementEnum.Right:
                    return (MovementEnum)2;
                 
                case MovementEnum.Down:
                    return (MovementEnum)3;
                    
                case MovementEnum.Left:
                    return (MovementEnum)4;
                    
                default:
                    break;
            }
            
            throw new NotImplementedException();
        }

        private MovementEnum MoveTowards()
        {
            //int xDist = X_ - LeaderTarget.X_;
            //int yDist = Y_ - LeaderTarget.Y_;
            int xDist = LeaderTarget.X_ - X_;
            int yDist = LeaderTarget.Y_ - Y_;

           
            //Consider when X and Y are 0
            if (LeaderTarget.X_ == X_)
            {
                if (LeaderTarget.Y_ < this.Y_) //Target is above
                {
                    //Move up
                    if (characterVision[0].GetType() != typeof(Obstacle) && characterVision[0].GetType().BaseType != typeof(Enemy) && characterVision[0].GetType() != typeof(Hero)) // If the chosen direction is occupied
                    {
                        return MovementEnum.Up;
                    }
                    else
                    {
                        return (RandomDirection());
                    }
                }
                else
                {
                    //Move Down
                    if (characterVision[2].GetType() != typeof(Obstacle) && characterVision[2].GetType().BaseType != typeof(Enemy) && characterVision[2].GetType() != typeof(Hero)) // If the chosen direction is occupied
                    {

                        return MovementEnum.Down;

                    }
                    else
                    {
                        return (RandomDirection());
                    }
                }
            }
            if (LeaderTarget.Y_ == Y_) //Same Line
            {
                if (LeaderTarget.X_ > this.X_)
                {
                    //Move right
                    if (characterVision[1].GetType() != typeof(Obstacle) && characterVision[1].GetType().BaseType != typeof(Enemy) && characterVision[1].GetType() != typeof(Hero)) // If the chosen direction is occupied
                    {
                        return MovementEnum.Right;
                    }
                    else
                    {
                        return (RandomDirection());
                    }
                }
                else
                {
                    //Move left
                    if (characterVision[3].GetType() != typeof(Obstacle) && characterVision[1].GetType().BaseType != typeof(Enemy) && characterVision[3].GetType() != typeof(Hero)) // If the chosen direction is occupied
                    {
                        return MovementEnum.Left;
                    }
                    else
                    {
                        return (RandomDirection());
                    }
                }

            }

            
            if (Math.Abs(yDist) < Math.Abs(xDist)) //Vertical Distance shorter than Horizontal
            {
                if (yDist < 0) //Target is above
                {
                    //Move up
                    if (characterVision[0].GetType() != typeof(Obstacle) && characterVision[0].GetType().BaseType != typeof(Enemy) && characterVision[0].GetType() != typeof(Hero) ) // If the chosen direction is occupied
                    {
                        return MovementEnum.Up;
                    }
                    else
                    {
                        return (RandomDirection());
                    }
                }
                else
                {
                    //Move Down
                    if (characterVision[2].GetType() != typeof(Obstacle) && characterVision[2].GetType().BaseType != typeof(Enemy) && characterVision[2].GetType() != typeof(Hero)) // If the chosen direction is occupied
                    {

                        return MovementEnum.Down;

                    }
                    else
                    {
                        return (RandomDirection());
                    }
                }
            }
            else if (Math.Abs(xDist) < Math.Abs(yDist)) //Horizontal Distance shorter
            {
                if (xDist < 0) //Target is right
                {
                    //Move right
                    if (characterVision[1].GetType() != typeof(Obstacle) && characterVision[1].GetType().BaseType != typeof(Enemy) && characterVision[1].GetType() != typeof(Hero)) // If the chosen direction is occupied
                    {
                        return MovementEnum.Right;
                    }
                    else
                    {
                        return (RandomDirection());
                    }
                }
                else
                {
                    //Move left
                    if (characterVision[3].GetType() != typeof(Obstacle) && characterVision[3].GetType().BaseType != typeof(Enemy) && characterVision[3].GetType() != typeof(Hero)) // If the chosen direction is occupied
                    {
                        return MovementEnum.Left;
                    }
                    else
                    {
                        return (RandomDirection());
                    }
                }
            }
            return MovementEnum.NoMovement;
        }

        private MovementEnum RandomDirection()
        {
            int direction = 0;
            do
            {
                direction = randObj.Next(0, 4);
            } while (characterVision[direction].GetType() != typeof(EmptyTile));

            switch (direction) //A switch statement that returns the appropriate random direction available
            {
                case 0: //UP
                    return MovementEnum.Up;

                case 1: //RIGHT
                    return MovementEnum.Right;

                case 2: //DOWN
                    return MovementEnum.Down;

                case 3: //LEFT
                    return MovementEnum.Left;
                default: //If no movement occurs
                    return MovementEnum.NoMovement;
            }
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
            //return equipped + "Leader " + base.ToString(); //Simply adds the word "Leader" to the enemy output.
            return base.ToString();
        }
    }
}
