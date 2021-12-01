using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE
{
    class MeleeWeapon : Weapon
    {
        public MeleeWeapon(WeaponType type, int x = 0, int y = 0) : base(x, y)
        {
            switch (type)
            {
                case WeaponType.Dagger:
                    this.WeaponTypeString = "Dagger";
                    this.Durability = 10;
                    this.Damage = 3;
                    this.Cost = 3;
                    break;
                case WeaponType.Longsword:
                    this.WeaponTypeString = "Longsword";
                    this.Durability = 6;
                    this.Damage = 4;
                    this.Cost = 5;
                    break;
                default:
                    break;
            }
        }
        public override int Range { get { return range; } set { range = 1; } }
        //public MeleeWeapon(int x = 0, int y = 0, char symbol = 'W') : base(x, y, symbol)
        //{
        //}

        public override string ToString()
        {
            throw new NotImplementedException();
        }
        public enum WeaponType
        {
            Dagger,
            Longsword
        }
    }
}
