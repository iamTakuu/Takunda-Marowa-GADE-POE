using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE
{
    [Serializable]
    class Shop
    {
        private Weapon[] weaponsArray = new Weapon[3];
        private Random random;
        private Character buyer = null;

        public Shop(Character buyingChar)
        {
            buyer = buyingChar;
            //Weapon[] weaponsArray = new Weapon[3];
            random = new Random();
            for (int i = 0; i < weaponsArray.Length; i++)
            {
                
                weaponsArray[i] = RandomWeapon(); //Uses 1 or 0 to determine if weapon is ranged or melee
            }       
        }

        private Weapon RandomWeapon()
        {
            //Used to identify if a Melee or Ranged Weapon is made.
            int typeID = random.Next(0, 2);
            switch (typeID)
            {
                case 0: //Melee
                    return new MeleeWeapon( (MeleeWeapon.MeleeType)random.Next(0, 2) );
                case 1:
                    return new RangedWeapon( (RangedWeapon.RangedTypes)random.Next(0, 2) ) ;
                default:
                    return null;
                    
            }  
        }
        /// <summary>
        /// Returns true if the buyer can afford the item picked fromt the shop.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool CanBuy(int num)
        {
            if (buyer.GoldPurse >= weaponsArray[num].Cost)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Decreases gold count and lets the player Pick Up the object.
        /// </summary>
        /// <param name="num"></param>
        public void Buy(int num)
        {
            if (CanBuy(num))
            {
            buyer.GoldPurse -= weaponsArray[num].Cost;
            buyer.Pickup(weaponsArray[num]);
            weaponsArray[num] = RandomWeapon();

            }
        }
        public string DisplayWeapon(int num)
        {
            string output = string.Format("Buy weapon: {0}, for {1} Gold", weaponsArray[num].WeaponTypeString, weaponsArray[num].Cost);
            return output;
        }
    }
}
