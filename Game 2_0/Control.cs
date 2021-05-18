using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Game_2._0
{
    public class Control
    {
        static void PrintOnPosition(int x, int y, char c,
      ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(c);
        }
        static void PrintStringOnPosition(int x, int y, string str,
            ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(str);
        }
        public void Perform()
        {
            int speed = 150;
            int acceleration = 1;
            int playfieldWidth = 15;
            int livesCount = 1;
            Console.BufferHeight = Console.WindowHeight = 36;
            Console.BufferWidth = Console.WindowWidth = 55;
            Object userCar = new Object();
            userCar.x = 5;
            userCar.y = Console.WindowHeight - 1;
            userCar.c = '╧';
            userCar.color = ConsoleColor.Yellow;
            Random randomGenerator = new Random();
            List<Object> objects = new List<Object>();
            while (true)
            {
                speed += acceleration;
                if (speed > 300)
                {
                    speed = 300;
                }

                bool hitted = false;
                {
                    int chance = randomGenerator.Next(0, 100);
                    if (chance < 10)
                    {
                        Object newObject = new Object();
                        newObject.color = ConsoleColor.Cyan;
                        newObject.c = 'H';
                        newObject.x = randomGenerator.Next(0, playfieldWidth);
                        newObject.y = 0;
                        objects.Add(newObject);
                    }
                    else if (chance < 20)
                    {
                        Object newObject = new Object();
                        newObject.color = ConsoleColor.Cyan;
                        newObject.c = '*';
                        newObject.x = randomGenerator.Next(0, playfieldWidth);
                        newObject.y = 0;
                        objects.Add(newObject);
                    }
                    else
                    {
                        Object newCar = new Object();
                        newCar.color = ConsoleColor.Green;
                        newCar.x = randomGenerator.Next(0, playfieldWidth);
                        newCar.y = 0;
                        newCar.c = '═';
                        objects.Add(newCar);
                    }
                }

                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        if (userCar.x - 1 >= 0)
                        {
                            userCar.x = userCar.x - 1;
                        }
                    }
                    else if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        if (userCar.x + 1 < playfieldWidth)
                        {
                            userCar.x = userCar.x + 1;
                        }
                    }
                }
                List<Object> newList = new List<Object>();
                for (int i = 0; i < objects.Count; i++)
                {
                    Object oldCar = objects[i];
                    Object newObject = new Object();
                    newObject.x = oldCar.x;
                    newObject.y = oldCar.y + 1;
                    newObject.c = oldCar.c;
                    newObject.color = oldCar.color;
                    if (newObject.c == 'H' && newObject.y == userCar.y && newObject.x == userCar.x)
                    {
                        speed -= 20;
                    }
                    if (newObject.c == '*' && newObject.y == userCar.y && newObject.x == userCar.x)
                    {
                        livesCount++;
                    }
                    if (newObject.c == '═' && newObject.y == userCar.y && newObject.x == userCar.x)
                    {
                        livesCount--;
                        hitted = true;
                        speed += 50;
                        if (speed > 400)
                        {
                            speed = 400;
                        }
                        if (livesCount <= 0)
                        {
                            PrintStringOnPosition(5, 10, "\t\tИСПЫТАНИЕ ПРОВАЛЕНО", ConsoleColor.Red);
                            PrintStringOnPosition(5, 12, "\t\tНАЖМИ [enter] ЧТОБЫ ВЫЙТИ", ConsoleColor.Red);
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
                    }
                    if (newObject.y < Console.WindowHeight)
                    {
                        newList.Add(newObject);
                    }
                }
                objects = newList;
                Console.Clear();
                if (hitted)
                {
                    objects.Clear();
                    PrintOnPosition(userCar.x, userCar.y, 'X', ConsoleColor.Red);
                }
                else
                {
                    PrintOnPosition(userCar.x, userCar.y, userCar.c, userCar.color);
                }
                foreach (Object car in objects)
                {
                    PrintOnPosition(car.x, car.y, car.c, car.color);
                }

                PrintStringOnPosition(20, 33, "ЖИЗНИ: " + livesCount, ConsoleColor.White);
                PrintStringOnPosition(20, 34, "СКОРОСТЬ: " + speed, ConsoleColor.White);
                PrintStringOnPosition(20, 35, "УСКОРЕНИЕ: " + acceleration, ConsoleColor.White);
                Thread.Sleep((int)600 - speed);

            }
        }

    }
}