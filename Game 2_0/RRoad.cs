using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_2._0
{
    class RRoad : Road
    {
        private Car car;
        private List<Let> lets;
        public RRoad(Car cr)
        {
            lets = new List<Let>();
            car = cr;
        }
        public override void Add_obstacles(Let lt)
        {
            lets.Add(lt);
        }

        public override void move_obstruction()
        {
            for (int i = 0; i < lets.Count; i++)
            {
                lets[i].Move();
            }
        }

        public override void car_move()
        {
            car.Move();
        }
        public override Let there_is_a_collision()
        {
            for (int i = 0; i < lets.Count; i++)
            {
                if (lets[i].kll().Equals(car.kl()))
                {
                    return lets[i];
                }
            }
            return null;
        }
    }

}
