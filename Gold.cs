using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_TASK_2
{
    [Serializable]
    class Gold : Item
    {
        private int goldCount;
        private Random rand = new Random();
        public int GoldCount_
        {
            get { return goldCount; }
            set { goldCount = value; }
        }
        public Gold(int x, int y) : base(x, y, '$')
        {
            GoldCount_ = rand.Next(1, 6); //Generating a gold value between 1 and 5 (inclusive)
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
