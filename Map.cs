using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Takunda Marowa 20123325
namespace GADE_TASK_1v2
{
    class Map
    {
        public Tile[,] tileArray2D;
        private char[,] MapArray; //Will be used in ToString();
        public Hero hero;
        public Enemy[] enemiesArray;
        public EmptyTile emptyTile = new EmptyTile(0,0);
        public Obstacle wall = new Obstacle(0, 0);
        public Goblin dobby = new Goblin(0, 0);
        private int height;
        private int width;
        private Random rand = new Random();


        public Map(int minHeight, int maxHeight, int minWidth, int maxWidth, int enemyCount)
        {
            this.height = rand.Next(minHeight, maxHeight);
            this.width = rand.Next(minWidth, maxWidth);
            
            
            tileArray2D = new Tile[width, height];
            MakeEmptyTiles();
            AddBorder();
            MapArray = new char[width, height];
            
            enemiesArray = new Enemy[enemyCount];
            //Enemy[] enemiesArray = new Enemy[enemyCount];

            hero = (Hero)Create(Tile.TileType.Hero); //Basically promising that I'll send back a Hero

            //This stores the created hero into the tile array
            tileArray2D[hero.X_, hero.Y_] = hero;
          
            //Looping through the enemy array and creating Goblins
            for (int i = 0; i < enemiesArray.Length; i++)
            {
                enemiesArray[i] = (Enemy)Create(Tile.TileType.Enemy); //Typecasting
                tileArray2D[enemiesArray[i].X_, enemiesArray[i].Y_] = enemiesArray[i]; //Adding the created goblin to the Tile Array

            }
            
            
            UpdateVision();
            
        }
        /// <summary>
        /// Replaces the Player's previous position with an empty tile
        /// </summary>
        public void ClearHero()
        {
            tileArray2D[hero.X_, hero.Y_] = emptyTile;
            UpdateHeroVision();
        }

        /// <summary>
        /// Used to update the game after each action
        /// </summary>
        public void UpdateMap()
        {
            
            UpdateHeroVision();
            MakeEmptyTiles();
            AddBorder();
            tileArray2D[hero.X_, hero.Y_] = hero;
            

            for (int i = 0; i < enemiesArray.Length; i++)
            {
                tileArray2D[enemiesArray[i].X_, enemiesArray[i].Y_] = enemiesArray[i]; //Adding the created goblin to the Tile Array               

            }


            DrawMap();

        }
        /// <summary>
        /// Attempts to Replace a dead enemy with an empty tile.
        /// </summary>
        public void RemoveDead()
        {
            for (int i = 0; i < enemiesArray.Length; i++)
            {
                if (enemiesArray[i].IsDead())
                {
                    tileArray2D[enemiesArray[i].X_, enemiesArray[i].Y_] = emptyTile;
                    enemiesArray[i] = null; //adds a null object into the array
                }
            }
                enemiesArray = enemiesArray.Where(z => z != null).ToArray(); //Coppies the array, without the Null Object. Found at: https://stackoverflow.com/questions/28193564/c-sharp-remove-null-values-from-object-array
            

            UpdateVision();
           

        }

        /// <summary>
        /// ONLY updates the Player's Vision. Used after Movements
        /// </summary>
        private void UpdateHeroVision()
        {
            for (int i = 0; i < 4; i++) //loop through all 4 directions
            {
                //Stores all tiles around current tile
                switch (i)
                {
                    case 0: //UP

                        hero.characterVision[i] = tileArray2D[hero.X_, hero.Y_ - 1];

                        break;
                    case 1: //RIGHT
                        hero.characterVision[i] = tileArray2D[hero.X_ + 1, hero.Y_];

                        break;
                    case 2: //DOWN
                        hero.characterVision[i] = tileArray2D[hero.X_, hero.Y_ + 1];

                        break;
                    case 3: //LEFT
                        hero.characterVision[i] = tileArray2D[hero.X_ - 1, hero.Y_];
                        break;
                }
            }
        }

        /// <summary>
        /// Creates all the Empty Tiles, before anything else is added.
        /// </summary>
        public void MakeEmptyTiles()
        {
            for (int y = 0; y < tileArray2D.GetLength(1); y++)
            {
                for (int x = 0; x < tileArray2D.GetLength(0); x++)
                {
                    
                    tileArray2D[x, y] = new EmptyTile(x, y);
                }
            }
        }

        
        /// <summary>
        /// Adds the border for the game
        /// </summary>
        private void AddBorder()
        {
            for (int y = 0; y < tileArray2D.GetLength(1); y++)
            {
                
                    for (int x = 0; x < tileArray2D.GetLength(0); x++)
                    {
                        if ((y == 0 || y == tileArray2D.GetLength(1) - 1) || (x == 0||x==tileArray2D.GetLength(0)-1))
                        //This is to check if it the first or last row
                        {
                            tileArray2D[x, y] = new Obstacle(x, y);
                        }
                    }
                
            }
        }

        
        /// <summary>
        /// This will output the 2D Tile Array to a 2D Character Array,
        /// which is then returned as a single String
        /// </summary>
        /// <returns></returns>
        public string DrawMap()
        {
            //tileArray2D[hero.X_, hero.Y_] = hero;
            for (int y = 0; y < tileArray2D.GetLength(1); y++)
            {
                for (int x = 0; x < tileArray2D.GetLength(0); x++)
                {
                    
                    if (tileArray2D[x, y].GetType() == typeof(Hero))
                    {
                        MapArray[x,y] = hero.Symbol_;
                    }
                    else if (tileArray2D[x,y].GetType() == typeof(Goblin))
                    {
                        MapArray[x,y] = dobby.Symbol_;
                    }
                    else if (tileArray2D[x,y].GetType() == typeof(Obstacle))
                    {
                        MapArray[x,y] = wall.Symbol_;
                    }
                    else
                    {
                        MapArray[x,y] = emptyTile.Symbol_;
                    }
                }
            }


            string rowString = "";

            
            for (int y = 0; y < MapArray.GetLength(1); y++)
            {
                for (int x = 0; x < MapArray.GetLength(0); x++)
                {
                    if (y == 0)
                    {
                        rowString += Convert.ToString(MapArray[x, y]);
                    }
                    else
                    {

                        rowString += Convert.ToString(MapArray[x, y]);

                    }
                }
                rowString += "\n";
            }

            return rowString;
            
        }

        /// <summary>
        /// Updates the vision for Every Character on the map.
        /// </summary>
        public void UpdateVision()
        {
            for (int i = 0; i < 4; i++) //loop through all 4 directions
            {
                //Stores all tiles around current tile
                switch (i)
                {
                    case 0: //UP
                        
                        hero.characterVision[i] = tileArray2D[hero.X_, hero.Y_ - 1];
                        
                        break;
                    case 1: //RIGHT
                        hero.characterVision[i] = tileArray2D[hero.X_ + 1, hero.Y_];
                        
                        break;
                    case 2: //DOWN
                        hero.characterVision[i] = tileArray2D[hero.X_, hero.Y_ + 1];
                        
                        break;
                    case 3: //LEFT
                        hero.characterVision[i] = tileArray2D[hero.X_ - 1, hero.Y_];
                        break;
                }
            }
            //Loops through each enemy, in each direction
            for (int j = 0; j < enemiesArray.Length; j++)
            {
                for (int x = 0; x < 4; x++)
                {
                    switch (x)
                    {
                        case 0: //UP
                            enemiesArray[j].characterVision[x] = tileArray2D[enemiesArray[j].X_, enemiesArray[j].Y_ - 1 ];
                            break;
                        case 1: //RIGHT
                            enemiesArray[j].characterVision[x] = tileArray2D[enemiesArray[j].X_ + 1, enemiesArray[j].Y_];
                            break;
                        case 2: //DOWN
                            enemiesArray[j].characterVision[x] = tileArray2D[enemiesArray[j].X_, enemiesArray[j].Y_ + 1];
                            break;
                        case 3: //LEFT
                            enemiesArray[j].characterVision[x] = tileArray2D[enemiesArray[j].X_ - 1, enemiesArray[j].Y_];
                            break;
                    }
                }
            }
        }


        /// <summary>
        /// Creates an object of the apropriate Tile based on the enum tileType that is passed.
        /// It will return a Tile. Typecasting is required.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private Tile Create(Tile.TileType type)
        {
            int x = 0;
            int y = 0;
            switch (type)
            {
                case Tile.TileType.Hero:
                    do
                    {
                        x = rand.Next(0, width);
                        y = rand.Next(0, height);
                    } while (CheckCoord(x, y));
            
                    return new Hero(x, y, 10);

                case Tile.TileType.Enemy:
                    do
                    {
                        x = rand.Next(0, width);
                        y = rand.Next(0, height);
                    } while (CheckCoord(x, y));

                    return new Goblin(x, y);

                default:
                    return new Hero(-1, -1, -1); //Invalid argunment (temporary)
            }

        }
        /// <summary>
        /// Checks if the coordinate is occupied by a Character, or Obstacle
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="tileArray2D"></param>
        /// <returns></returns>
        private bool CheckCoord(int x, int y)
        {
            if (tileArray2D[x, y].GetType() != typeof(EmptyTile))
            {
                return true;
            } 
            else return false;
            
        }
    }
}
