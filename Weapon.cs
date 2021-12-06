using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE
{
    [Serializable]
    abstract class Weapon : Item
    {
        private protected int damage;
        private protected int range;
        private protected int durability;
        private protected int cost;
        private protected string weaponType;
        public int Damage { get { return damage; } set { damage = value; } }
        public virtual int Range { get { return range; } set { range = value; } }
        public int Durability { get { return durability; } set { durability = value; } }
        public int Cost { get { return cost; } set { cost = value; } }
        public string WeaponTypeString { get { return weaponType; } set { weaponType = value; } } 


        public Weapon(int x= 0, int y= 0,char symbol = 'W') : base(x, y,symbol)
        {

        }

        
    }
}
