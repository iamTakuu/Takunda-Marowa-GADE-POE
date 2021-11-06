using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Takunda Marowa 20123325
namespace GADE_TASK_2
{
    class Map
    {
        public Tile[,] tileArray2D;
        private char[,] MapArray; //Will be used in ToString();
        public Hero hero;
        public Enemy[] enemiesArray;
        public Item[] itemsArray;
        public EmptyTile emptyTile = new EmptyTile(0,0);
        public Obstacle wall = new Obstacle(0, 0);
        public Goblin dobby = new Goblin(0, 0);
        private int height;
        private int width;
        private Random rand = new Random();


        public Map(int minHeight, int maxHeight, int minWidth, int maxWidth, int enemyCount, int goldCount)
        {
            this.height = rand.Next(minHeight, maxHeight);
            this.width = rand.Next(minWidth, maxWidth);
            
            
            tileArray2D = new Tile[width, height];
            MakeEmptyTiles();
            AddBorder();
            MapArray = new char[width, height];
            
            enemiesArray = new Enemy[enemyCount];
            itemsArray = new Item[goldCount];

            hero = (Hero)Create(Tile.TileType.Hero); //Basically promising that I'll send back a Hero

            //This stores the created hero into the tile array
            tileArray2D[hero.X_, hero.Y_] = hero;
          
            //Looping through the enemy array and creating Goblins
            for (int i = 0; i < enemiesArray.Length; i++)
            {
                enemiesArray[i] = (Enemy)Create(Tile.TileType.Enemy); //Typecasting
                tileArray2D[enemiesArray[i].X_, enemiesArray[i].Y_] = enemiesArray[i]; //Adding the created enemy to the Tile Array
            }

            for (int i = 0; i < itemsArray.Length; i++)
            {
                itemsArray[i] = (Item)Create(Tile.TileType.Gold);
                tileArray2D[itemsArray[i].X_, itemsArray[i].Y_] = itemsArray[i];
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
                tileArray2D[enemiesArray[i].X_, enemiesArray[i].Y_] = enemiesArray[i]; //Adding the created enemies to the Tile Array               

            }
            for (int i = 0; i < itemsArray.Length; i++)
            {
                
                tileArray2D[itemsArray[i].X_, itemsArray[i].Y_] = itemsArray[i]; //Adding the created Items to the Tile Array     
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
                    else if (tileArray2D[x,y].GetType().BaseType == typeof(Enemy))
                    {
                        MapArray[x, y] = tileArray2D[x, y].Symbol_;
                    }
                    else if (tileArray2D[x, y].GetType() == typeof(Gold))
                    {
                        MapArray[x, y] = tileArray2D[x, y].Symbol_;
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
            int enemyID = 0;
            switch (type)
            {
                case Tile.TileType.Hero:
                    do
                    {
                        x = rand.Next(0, width);
                        y = rand.Next(0, height);
                    } while (CheckCoord(x, y));
            
                    return new Hero(x, y, 10);

                case Tile.TileType.Gold:
                    do
                    {
                        x = rand.Next(0, width);
                        y = rand.Next(0, height);
                    } while (CheckCoord(x, y));

                    return new Gold(x, y);

                case Tile.TileType.Enemy:
                    do
                    {
                        x = rand.Next(0, width);
                        y = rand.Next(0, height);
                    } while (CheckCoord(x, y));

                    //Allows random generation of Goblin or Mage
                    enemyID = rand.Next(1, 3);
                    if (enemyID == 1)
                    {
                        return new Goblin(x, y);
                    }
                    else
                    {
                        return new Mage(x, y);
                    }
                    

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

        /// <summary>
        /// Returns an Item from the X and Y coordinates given.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Item GetItemAtPosition(int x, int y)
        {
            Item tempItem;
            for (int i = 0; i < itemsArray.Length; i++)
            {
                if ( (itemsArray[i].X_ == x) && (itemsArray[i].Y_ == y) )
                {
                    tempItem = itemsArray[i];
                    itemsArray[i] = null; //adds a null object into the array
                    itemsArray = itemsArray.Where(z => z != null).ToArray();
                    return tempItem;
                }
            }
                
               
            return null;
               
        }
    }
}
