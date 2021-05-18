using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_2._0
{
    internal abstract class Road
    {
        private Car car;
        private List<Let> lets;
        public abstract void Add_obstacles(Let lt);
        public abstract void move_obstruction();
        public abstract void car_move();
        public abstract Let there_is_a_collision();
    }

}
