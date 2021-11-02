using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Takunda Marowa 20123325
namespace GADE_TASK_2
{
    abstract class Tile
    {
        protected int X;
        protected int Y;
        protected char Symbol;

        
        //Constructor
        public Tile(int x, int y, char symbol)
        {
            this.X = x;
            this.Y = y;
            this.Symbol = symbol;

        }
        /// <summary>
        /// Public Access of X
        /// </summary>
        public int X_
        {
            get { return X; }
            set { X = value; }
        }
        /// <summary>
        /// Public Access of Y
        /// </summary>
        public int Y_
        {
            get { return Y; }
            set { Y = value; }
        }

        public char Symbol_
        {
            get { return Symbol; }
            set { Symbol = value; }
        }

        public enum TileType
        {
            Hero,
            Enemy,
            Gold,
            Weapon
        }



        
    }
}
