using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolving
{
    class Maze
    {
        public void createMazeBoard(int[,] lab)
        {
            for (int i = 0; i < 30; i++)
                for (int j = 0; j < 30; j++)
                    lab[i, j] = 0;
        }
        public int[,] createMaze(int[,] lab, int i)
        {
            Random sayiGen = new Random();
            int j = 1;
            int direction_info;
            lab[i, 0] = 1;
            lab[i, 1] = 1;

            while (j != 29)
            {
                direction_info = sayiGen.Next(0, 3);
                if (i < 30 && i > 0 && direction_info == 0)
                {
                    //up
                    lab[i - 1, j] = 1;
                    i--;
                }
                else if (j >= 0 && j < 29 && direction_info == 1)
                {
                    //right
                    lab[i, j + 1] = 1;
                    j++;
                }
                else if (i >= 0 && i < 29 && direction_info == 2)
                {
                    //down
                    lab[i + 1, j] = 1;
                    i++;
                }
            }
            return lab;
        }
        public void randomSpace(int[,] lab)
        {
            Random sayiGen = new Random();

            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 29; j++)
                {
                    int random = sayiGen.Next(0, 4);
                    if (random == 0 || random == 1)
                    {
                        lab[i, j] = 1;
                    }
                    else
                    {
                        lab[i, j] = 0;
                    }
                }
            }
        }
        public void writer(int[,] lab)
        {
            int h = 0;
            for (int k = 0; k < 30; k++)
            {
                h = 0;
                for (int l = 0; l < 30; l++)
                {
                    Console.SetCursorPosition(l + h, k);
                    h = h + 1;
                    Console.Write("{0} ", lab[k, l]);
                }
                Console.WriteLine("");
            }
        }
        public void putX(int[,] lab)
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (lab[i, j] == 2)
                    {
                        Console.SetCursorPosition(j * 2, i);
                        Console.WriteLine("X");
                    }
                }
            }
        }
        public void refresh(int[,] lab)
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (lab[i, j] == 2)
                    {
                        Console.SetCursorPosition(j * 2, i);
                        Console.WriteLine(1);
                    }
                    if (lab[i, j] == 3)
                    {
                        Console.SetCursorPosition(j * 2, i);
                        Console.WriteLine(0);
                    }
                }
            }
        }
    }
}

