using System;

namespace MazeSolving
{
    class Program
    {
            static void Main(string[] args)
            {
                MazeSolver maze = new MazeSolver();
                Maze lbr = new Maze();
                RWClass rw = new RWClass();
                Bomb bomb = new Bomb();
                int[,] dizi = new int[30, 30];
                Console.WriteLine("Labirent oluşturmak için 'A' tuşuna,");
                Console.WriteLine("Labirent çözmek için 'C' tuşuna basınız");
                ConsoleKeyInfo pressed;
                do
                {
                    pressed = Console.ReadKey();
                    if (pressed.Key == ConsoleKey.A)
                    {
                        lbr.createMazeBoard(dizi);
                        int b = 0;
                        lbr.randomSpace(dizi);
                        for (int i = 0; i < 3; i++, b = b + 10)
                        {
                            Random sayiGen = new Random();
                            int giris = sayiGen.Next(0 + b, 10 + b);
                            dizi = lbr.createMaze(dizi, giris);                        
                        }
                        rw.Write(dizi);
                        continue;
                    }
                    if (pressed.Key == ConsoleKey.C)
                    {
                        dizi = rw.convertMaze(rw.Read());
                        int[] enterance = maze.findDoors(dizi);
                        lbr.writer(dizi);
                        bomb.createBomb(dizi);
                        int sayac = maze.count(dizi);
                        for (int i = 0; i < sayac; i++)
                        {
                            maze.solveMaze(dizi, enterance[i], 0);

                        }
                        Console.SetCursorPosition(0, 32);
                        Console.WriteLine("Labirenti gormek icin  L");
                        Console.WriteLine("Bombaları gormek icin  B");
                        Console.WriteLine("Yolu gormek icin  X tusuna basiniz");
                        do
                        {
                            pressed = Console.ReadKey();
                            if (ConsoleKey.B == pressed.Key)
                            {
                                bomb.showBomb(dizi);
                            }
                            if (ConsoleKey.X == pressed.Key)
                            {
                                lbr.putX(dizi);
                            }
                            if (ConsoleKey.L == pressed.Key)
                            {
                                lbr.refresh(dizi);
                            }
                        } while (pressed.Key != ConsoleKey.Escape);
                    }
                } while (pressed.Key != ConsoleKey.Escape);
                Console.SetCursorPosition(0, 50);
                Console.WriteLine("TEŞEKKÜRLER.");
                Console.ReadLine();
            }
        }
    }

