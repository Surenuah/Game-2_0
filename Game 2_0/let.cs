using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_2._0
{
    internal abstract class Let
    {
        private uint x;
        private uint y;
        public abstract void Move();
        public abstract KeyValuePair<uint, uint> kll();
        public abstract void show();
    }
}

