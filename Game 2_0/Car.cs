using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_2._0
{
    public abstract class Car
    {
        private uint x;
        private uint y;
        public abstract void To_the_left();
        public abstract void Move();
        public abstract void To_the_right();
        public abstract KeyValuePair<uint, uint> kl();
    }
}
