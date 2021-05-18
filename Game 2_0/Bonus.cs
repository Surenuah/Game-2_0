using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_2._0
{
    class Bonus : Let
    {
        private uint x;
        private uint y;
        public Bonus(uint x, uint y)
        {
            this.x = x;
            this.y = y;
        }
        public override void Move()
        {
            if (y + 1 > 25)
            {
                y = 0;
            }
            else
            {
                y++;
            }
        }
        public override KeyValuePair<uint, uint> kll()
        {
            return new KeyValuePair<uint, uint>(x, y);
        }

        public override void show()
        {
            Console.WriteLine("Координаты препядствия x = " + x + " y = " + y);
        }
    }
}
