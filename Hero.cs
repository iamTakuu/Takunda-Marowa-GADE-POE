using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Takunda Marowa 20123325
namespace GADE_POE
{
    [Serializable]
    class Hero : Character
    {
        public Hero(int x, int y, int startHP) : base(x, y, 'H', startHP, 2)
        {
        }

        /// <summary>
        /// Takes a Direction Input, If Valid, returns said Direction. Else No movement is returned.
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        public override MovementEnum ReturnMove(MovementEnum move)
        {
            switch (move)
            {
                case MovementEnum.NoMovement:
                    return MovementEnum.NoMovement;
                case MovementEnum.Up:
                    if (characterVision[0].GetType() != typeof(Obstacle) && characterVision[0].GetType().BaseType != typeof(Enemy))
                    {
                        return MovementEnum.Up;
                    }
                    else return MovementEnum.NoMovement;

                case MovementEnum.Right:
                    if (characterVision[1].GetType() != typeof(Obstacle) && characterVision[1].GetType().BaseType != typeof(Enemy))
                    {
                        return MovementEnum.Right;
                    }
                    else return MovementEnum.NoMovement;
                case MovementEnum.Down:
                    if (characterVision[2].GetType() != typeof(Obstacle) && characterVision[2].GetType().BaseType != typeof(Enemy))
                    {
                        return MovementEnum.Down;
                    }
                    else return MovementEnum.NoMovement;
                case MovementEnum.Left:
                    if (characterVision[3].GetType() != typeof(Obstacle) && characterVision[3].GetType().BaseType != typeof(Enemy))
                    {
                        return MovementEnum.Left;
                    }
                    else return MovementEnum.NoMovement;


            }
            return MovementEnum.NoMovement;

        }

        public override string ToString()
        {
            string outputString;
            outputString = "Player stats:" + "\nHP: " + this.HP + "/" + this.maxHP + "\nCurrent Weapon: "+ReturnWeapon()+"\nWeapon Range: "+ReturnRange()+"\nDamage: " +this.damage+ "\nDurability: "+ReturnDurability()+"\n [" +X+ "," +Y+ "]" +"\nGold Count: "+this.GoldPurse;
            return outputString;
        }
    }
}
