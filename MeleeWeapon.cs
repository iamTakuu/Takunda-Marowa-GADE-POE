using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE
{
    class MeleeWeapon : Weapon
    {
        public override int Range { get { return 1; }}
        public MeleeWeapon(MeleeType type, int x = 0, int y = 0) : base(x, y)
        {
            switch (type)
            {
                case MeleeType.Dagger:
                    this.WeaponTypeString = "Dagger";
                    this.Durability = 10;
                    this.Damage = 3;
                    this.Cost = 3;
                    break;
                case MeleeType.Longsword:
                    this.WeaponTypeString = "Longsword";
                    this.Durability = 6;
                    this.Damage = 4;
                    this.Cost = 5;
                    break;
                default:
                    break;
            }
        }
        //public MeleeWeapon(int x = 0, int y = 0, char symbol = 'W') : base(x, y, symbol)
        //{
        //}

        public override string ToString()
        {
            throw new NotImplementedException();
        }
        public enum MeleeType
        {
            Dagger,
            Longsword
        }
    }
}
