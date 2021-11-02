using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Takunda Marowa 20123325
namespace GADE_TASK_2
{
    /// <summary>
    /// The GameEngine. Runs most of the game's logic, Passing all info to the form.
    /// </summary>
    class GameEngine
    {
        private Map gameMap = new Map(10, 15, 10, 15, 4);
        
        public Map GameMap
        {
            get { return gameMap; }
        }

       /// <summary>
       /// Validates an input direction, then moves according to said valid direction, clearing the player's previous postion.
       /// </summary>
       /// <param name="direction"></param>
       /// <returns></returns>
        public bool MovePlayer(Character.MovementEnum direction)
        {
            
            switch (direction)
            {
                case Character.MovementEnum.NoMovement:
                    return false;
                case Character.MovementEnum.Up:
                    if (GameMap.hero.ReturnMove(direction) == Character.MovementEnum.Up)
                    {
                        GameMap.ClearHero();
                        GameMap.hero.Move(Character.MovementEnum.Up);
                        return true;                   

                    }
                    else return false;
                    
                case Character.MovementEnum.Right:
                    if (GameMap.hero.ReturnMove(direction) == Character.MovementEnum.Right)
                    {
                        GameMap.ClearHero();
                        GameMap.hero.Move(Character.MovementEnum.Right);
                        return true;                       
                        
                    }
                    else return false;
                    

                case Character.MovementEnum.Down:
                    if (GameMap.hero.ReturnMove(direction) == Character.MovementEnum.Down)
                    {
                        GameMap.ClearHero();
                        GameMap.hero.Move(Character.MovementEnum.Down);
                        return true;                       
                        
                    }
                    else return false;
                    
                case Character.MovementEnum.Left:
                    if (GameMap.hero.ReturnMove(direction) == Character.MovementEnum.Left)
                    {

                        GameMap.ClearHero();
                        GameMap.hero.Move(Character.MovementEnum.Left);
                        return true;                       
                        
                    }
                    else return false;
                    
                 
                    
            }
            return false;
            
        }

        
        /// <summary>
        /// Updates game state.
        /// </summary>
        public void UpdateEngine()
        {
            GameMap.RemoveDead();
            GameMap.UpdateMap();
        }
        
        public override string ToString()
        {
            return GameMap.DrawMap();
        }

    }
}
