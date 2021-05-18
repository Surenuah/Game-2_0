using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_2._0
{
    public class MyCar : Car
    {
        static int PLAY_FIELD_WIDHT = 30;
        private uint x;
        private uint y;
        public MyCar(uint x, uint y)
        {
            this.x = x;
            this.y = y;
        }
        public override void To_the_left() { x--; }
        public override void To_the_right() { x++; }
        public override void Move()
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (x - 1 > 0)
                    {
                        To_the_left();
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (x + 1 <= PLAY_FIELD_WIDHT)
                    {
                        To_the_right();
                    }
                }
            }
        }
        public override KeyValuePair<uint, uint> kl()
        {
            return new KeyValuePair<uint, uint>(x, y);
        }
        public void show()
        {
            Console.WriteLine("Координаты Машины x = " + x + " y = " + y);
        }
    }
    public interface controller
    {
        void Move();
    }
}
