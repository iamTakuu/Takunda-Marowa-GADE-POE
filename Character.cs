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
    /// The Character Class. Used to create enemies and the player.
    /// </summary>
    abstract class Character : Tile
    {
        protected int HP;
        protected int maxHP;
        protected int damage;
        private int goldPurse_;
        private int attackRange = 1;
        protected Weapon weaponInventory = null;

        public Weapon CharWeapon { get { return weaponInventory; } }
        public int GoldPurse
        {
            get
            {
                return goldPurse_;
            }
            set
            {
                goldPurse_ = value;
            }
        }
        /// <summary>
        /// Reperesents the vision for the character:
        /// 0: UP/NORTH Tile;
        /// 1: RGHT/EAST Tile;
        /// 2: DOWN/SOUTH Tile;
        /// 3: LEFT/WEST Tile;
        /// </summary>
        public Tile[] characterVision = new Tile[4];
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        protected Character(int x, int y, char symbol, int startHP, int dmg) : base(x, y, symbol)
        {
            damage = dmg;
            maxHP = startHP;
            HP = maxHP;
        }



        /// <summary>
        /// Deals damage to the "target" character, based on this characters damage variable.
        /// </summary>
        /// <param name="target"></param>
        public virtual void Attack(Character target)
        {
            if (CheckRange(target))
            {
                target.HP -= damage;
                Console.WriteLine("Ouch!");
            }
        }

        /// <summary>
        /// Checks if the character to be looted is dead. If the killer has no weapon, they equip the victims weapon. Always loots the gold.
        /// </summary>
        /// <param name="toBeLooted"></param>
        public void Loot(Character toBeLooted)
        {
            if (toBeLooted.IsDead())
            {
                GoldPurse += toBeLooted.GoldPurse;

                if (this.weaponInventory == null && this.GetType() != typeof(Mage))
                {
                Equip(toBeLooted.weaponInventory);
                }
            }
        }

        /// <summary>
        /// This will allow a character to picup any item it walks through.
        /// </summary>
        /// <param name="i"></param>
        public void Pickup(Item i)
        {
           
            if ( i.GetType() == typeof(Gold) )
            {
                AddGold((Gold)i); //Need to typecast it.
            }else if(i.GetType().BaseType == typeof(Weapon))
            {
                Equip((Weapon)i);
            }
        }

        protected void Equip(Weapon i)
        {
            weaponInventory = i;
            attackRange = weaponInventory.Range;
            damage = weaponInventory.Damage;
            //throw new NotImplementedException();
        }

        /// <summary>
        /// This adds the Gold picked up.
        /// </summary>
        /// <param name="i"></param>
        private void AddGold(Gold i)
        {
            GoldPurse += i.GoldCount_;
            Console.WriteLine("Got the gold baby!");
        }

        /// <summary>
        /// Checks to see if the player is dead. Returns true/false
        /// </summary>
        /// <returns></returns>
        public bool IsDead()
        {
            if (HP <= 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks to see if an enemy is within the player's attack range.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public virtual bool CheckRange(Character target)
        {
            if (DistanceTo(target) <= attackRange) //Barehand range being 1
            {
                return true;
                
            }

            return false;

        }
        /// <summary>
        /// Calculate distance between character and target. Distance is determined by total amount of movements
        /// in the X-axis, and Y-axis. Returning the total distance as an integer
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        private int DistanceTo(Character target)
        {
            int totalDist;
            totalDist = (Math.Abs(target.Y_ - Y_)) + Math.Abs((target.X_ - X_));
            return (totalDist);
        }

        /// <summary>
        /// Takes the movement identifier and changes the Units X and Y coordinates accordingly
        /// </summary>
        /// <param name="move"></param>
        public void Move(MovementEnum move)
        {
            //Append the relevant coordinate based on uuser miove
            switch (move)
            {
                case MovementEnum.NoMovement:
                    Console.WriteLine("No Move");
                    break;
                case MovementEnum.Up:
                    Console.WriteLine("Up");
                    this.Y--;
                    break;
                case MovementEnum.Down:
                    Console.WriteLine("Down");
                    this.Y++;
                    break;
                case MovementEnum.Left:
                    Console.WriteLine("Left");
                    this.X--;
                    break;
                case MovementEnum.Right:
                    Console.WriteLine("Right");
                    this.X++;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Returns appropriate direction to move in.
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        public abstract MovementEnum ReturnMove(MovementEnum move = 0);

        /// <summary>
        /// Used for all Posible Movements
        /// </summary>
        public enum MovementEnum
        {
            NoMovement,
            Up,
            Right,
            Down,
            Left,
        }
        public abstract override string ToString();
        public string ReturnWeapon()
        {
            if (weaponInventory == null)
            {
                return "Bare Hand";
            }
            else
            {
                return weaponInventory.WeaponTypeString;
            }
        }
        public string ReturnRange()
        {
            if (weaponInventory == null)
            {
                return Convert.ToString(attackRange);
            }
            else
            {
                return Convert.ToString(weaponInventory.Range);
            }
        }
        public string ReturnDurability()
        {
            if (weaponInventory == null)
            {
                return "";
            }
            else
            {
                return Convert.ToString(weaponInventory.Durability);
            }
        }
    }

}
