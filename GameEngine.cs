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
        private Map gameMap = new Map(10, 15, 10, 15, 4, 3);
        
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
                        if (GameMap.hero.characterVision[0].GetType().BaseType == typeof(Item))
                        {
                            GameMap.hero.Pickup(GameMap.GetItemAtPosition(GameMap.hero.characterVision[0].X_, GameMap.hero.characterVision[0].Y_));
                        }
                        GameMap.ClearHero();
                        GameMap.hero.Move(Character.MovementEnum.Up);
                        //MoveEnemies();
                        return true;                   

                    }
                    else return false;
                    
                case Character.MovementEnum.Right:
                    if (GameMap.hero.ReturnMove(direction) == Character.MovementEnum.Right)
                    {
                        if (GameMap.hero.characterVision[1].GetType().BaseType == typeof(Item))
                        {
                            GameMap.hero.Pickup(GameMap.GetItemAtPosition(GameMap.hero.characterVision[1].X_, GameMap.hero.characterVision[1].Y_));
                        }
                        GameMap.ClearHero();
                        GameMap.hero.Move(Character.MovementEnum.Right);
                        //MoveEnemies();
                        return true;                       
                        
                    }
                    else return false;
                    

                case Character.MovementEnum.Down:
                    if (GameMap.hero.ReturnMove(direction) == Character.MovementEnum.Down)
                    {
                        if (GameMap.hero.characterVision[2].GetType().BaseType == typeof(Item))
                        {
                            GameMap.hero.Pickup(GameMap.GetItemAtPosition(GameMap.hero.characterVision[2].X_, GameMap.hero.characterVision[2].Y_));
                        }
                        GameMap.ClearHero();
                        GameMap.hero.Move(Character.MovementEnum.Down);
                        //MoveEnemies();
                        return true;                       
                        
                    }
                    else return false;
                    
                case Character.MovementEnum.Left:
                    if (GameMap.hero.ReturnMove(direction) == Character.MovementEnum.Left)
                    {
                        if (GameMap.hero.characterVision[3].GetType().BaseType == typeof(Item))
                        {
                            GameMap.hero.Pickup(GameMap.GetItemAtPosition(GameMap.hero.characterVision[3].X_, GameMap.hero.characterVision[3].Y_));
                        }
                        GameMap.ClearHero();
                        GameMap.hero.Move(Character.MovementEnum.Left);
                        //MoveEnemies();
                        return true;                       
                        
                    }
                    else return false;
                    
                 
                    
            }
            return false;
            
        }

        public void MoveEnemies()
        {
            for (int i = 0; i < GameMap.enemiesArray.Length; i++)
            {
                if (GameMap.enemiesArray[i].GetType() == typeof(Goblin))
                {
                    GameMap.enemiesArray[i].Move(GameMap.enemiesArray[i].ReturnMove());
                }
            }
            GameMap.UpdateMap();
            UpdateEngine();
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
