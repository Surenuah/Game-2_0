using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Game_2._0
{
    struct Object
    {
        public int x;
        public int y;
        public char c;
        public ConsoleColor color;
    }

    interface Model
    {
        void ShowModel();
    }
    interface Performance
    {
        void ShowDan();
    }

    class Program
    {

        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.Black;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Игрок! Введи своё имя!");
            string name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ВНИМАНИЕ {name} !");
            Console.WriteLine("Испытание начнётся через: ");
            for (int i = 5; i >= 0; i--)
            {
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(i);
                if (i < 1)
                {
                    i = 0;
                    Console.WriteLine("НАЧАЛО!!!");
                }
            }

            Bonus bon = new Bonus(5, 20);
            MyCar crr = new MyCar(5, 25);
            RRoad rdd = new RRoad(crr);
            Control cn = new Control();
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            cn.Perform();
            rdd.Add_obstacles(bon);
            crr.show();
            crr.To_the_left();
            crr.show();
            crr.To_the_right();
            crr.show();

            Console.WriteLine();
            bon.Move();
            bon.show();

        }

    }
}