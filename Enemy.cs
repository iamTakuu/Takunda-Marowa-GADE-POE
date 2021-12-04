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
    /// All enemies are derived from this class.
    /// </summary>
    abstract class Enemy : Character
    {
        //protected int randomObj;
        protected Random randObj = new Random();

        

        public Enemy(int x, int y, char symbol, int startHP, int dmg) : base(x, y, symbol, startHP, dmg)//Q2.4...Note: "So the enemy class should be able to pass HP to the character class so long as the character class's constructor has a parameter to receive HP"
        {

        }

        public override string ToString()
        {

            //string equipped;
            if (weaponInventory == null)
            {
                return "Bare Handed: " + this.GetType().Name + " at [" + X + ", " + Y + "] (" + damage + " DMG) (HP: " + HP+"/"+maxHP+")";
            }
            else
            {
                return "Equipped: " + this.GetType().Name + " at [" + X + ", " + Y + "] (" + damage + " DMG) (HP: " + HP + "/" + maxHP + ") with " + this.weaponInventory.WeaponTypeString;
                //equipped = weaponInventory.WeaponTypeString;
            }
            
            //return ("at [" + X + ", " + Y + "] (" + damage + " DMG) HP: "+HP);

        }

    }
}
