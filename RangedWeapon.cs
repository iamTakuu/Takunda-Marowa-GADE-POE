using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE
{
    [Serializable]
    class RangedWeapon : Weapon
    {
        public RangedWeapon(RangedTypes type, int x=0, int y=0) : base(x, y)
        {
            switch (type)
            {
                case RangedTypes.Rifle:
                    this.WeaponTypeString = "Rifle";
                    this.Durability = 3;
                    this.Range = 4;
                    this.Damage = 5;
                    this.Cost = 7;
                    break;
                case RangedTypes.Longbow:
                    this.WeaponTypeString = "Longbow";
                    this.Durability = 4;
                    this.Range = 2;
                    this.Damage = 4;
                    this.Cost = 6;
                    break;
                default:
                    break;
            }
        }

        public RangedWeapon(RangedTypes type, int durability, int x = 0, int y = 0) : base(x, y)
        {
            switch (type)
            {
                case RangedTypes.Rifle:
                    this.WeaponTypeString = "Rifle";
                    this.Durability = durability;
                    this.Range = 4;
                    this.Damage = 5;
                    this.Cost = 7;
                    break;  
                case RangedTypes.Longbow:
                    this.WeaponTypeString = "Longbow";
                    this.Durability = durability;
                    this.Range = 2;
                    this.Damage = 4;
                    this.Cost = 6;
                    break;
                default:
                    break;
            }
        }
        public override int Range { get { return range; } set { range = value; } }
        public override string ToString()
        {
            throw new NotImplementedException();
        }
        public enum RangedTypes
        {
            Rifle,
            Longbow
        }

    }
    
}
