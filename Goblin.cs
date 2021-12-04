using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Takunda Marowa 20123325
namespace GADE_POE
{
    [Serializable]
    /// <summary>
    /// A goblin. The Only enemy currently here.
    /// </summary>
    
    class Goblin : Enemy
    {
        public Goblin(int x, int y) : base(x, y, 'G', 10, 1)
        {
            this.weaponInventory = new MeleeWeapon(MeleeWeapon.MeleeType.Dagger);
            Equip(weaponInventory);
        }

        

        public override MovementEnum ReturnMove(MovementEnum move = MovementEnum.NoMovement)
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
            //return equipped+"Goblin " + base.ToString(); //Simply adds the word "Goblin" to the enemy output.
            return base.ToString();
        }
    }
}
