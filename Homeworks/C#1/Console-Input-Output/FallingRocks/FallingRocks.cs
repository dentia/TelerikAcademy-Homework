//Implement the "Falling Rocks" game in the text console.
//A small dwarf stays at the bottom of the screen and can move left and right (by the arrows keys).
//A number of rocks of different sizes and forms constantly fall down and you need to avoid a crash.
//Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, - distributed with appropriate density. The dwarf is (O).
//Ensure a constant game speed by Thread.Sleep(150).
//Implement collision detection and scoring system.

namespace FallingRocks
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    class FallingRocks
    {
        static void Main(string[] args)
        {
            Console.BufferHeight = Console.WindowHeight = 20;
            Console.BufferWidth = Console.WindowWidth = 45;
            Console.BackgroundColor = ConsoleColor.Gray;

            Player player = new Player(Console.WindowWidth / 3, Console.WindowHeight - 1, 
                'O', ConsoleColor.DarkRed);


            GameInfo[] stats = new GameInfo[2];
            stats[0] = new GameInfo((Console.WindowWidth / 3) * 2, 10, "LIVES", 5, ConsoleColor.Black);
            stats[1] = new GameInfo((Console.WindowWidth / 3) * 2, 4, "POINTS", 0, ConsoleColor.Black);

            GameInfo gameOver = new GameInfo(Console.WindowWidth / 2, Console.WindowHeight / 2, "GAME OVER", 0, ConsoleColor.Red);

            List<Rock> rocks = new List<Rock>();

            while (true)
            {
                //Move player
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressed = Console.ReadKey(true);
                    while (Console.KeyAvailable) Console.ReadKey(true);

                    if (pressed.Key == ConsoleKey.LeftArrow)
                    {
                        if (player.X - 1 >= 0)
                            player.X -= 1;
                    }
                    else if (pressed.Key == ConsoleKey.RightArrow)
                    {
                        if (player.X + 1 < (Console.WindowWidth / 3) * 2)
                            player.X += 1;
                    }
                }

                //Create random rock
                Rock newRock = new Rock();
                newRock.SetRandom((Console.WindowWidth / 3) * 2);
                rocks.Add(newRock);
                //Move rocks
                for (int rock = 0; rock < rocks.Count; rock++)
                {
                    rocks[rock].Y += 1;
                    if (rocks[rock].Y >= Console.WindowHeight)
                    {
                        rocks.Remove(rocks[rock]);
                        stats[1].Amount += 1;
                    }

                    //Check if collision
                    if (rocks[rock].X == player.X && rocks[rock].Y == player.Y)
                    {
                        player.Symbol = 'X';
                        Console.Write((char)7);
                        stats[0].Amount -= 1;
                        rock--;
                        if (stats[0].Amount <= 0)
                        {
                            Console.Clear();
                            gameOver.Print();
                            Console.ReadKey();
                            return;
                        }
                    }
                }
                //Clear console
                Console.Clear();
                //Redraw field
                player.Print();
                if (player.Symbol == 'X') player.Symbol = 'O';

                foreach (var rock in rocks)
                {
                    rock.Print();
                }

                foreach (var stat in stats)
                {
                    stat.Print();
                }
                //Draw Info

                Thread.Sleep(220);
            }
        }
    }
}
