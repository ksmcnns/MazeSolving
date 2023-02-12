using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolving
{
    class Bomb
    {
        public void createBomb(int[,] lab)
        {
            Random sayiGen = new Random();
            int totalBomb = 1;
            while (0 < totalBomb)
            {
                int iplace = sayiGen.Next(1, 30);
                int jplace = sayiGen.Next(1, 30);
                if (lab[iplace, jplace] == 1)
                {
                    //3 is bomb
                    lab[iplace, jplace] = 3;
                    totalBomb--;
                }
            }
        }
        public void showBomb(int[,] lab)
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (lab[i, j] == 3)
                    {
                        Console.SetCursorPosition(j * 2, i);
                        Console.WriteLine("B");
                    }
                }
            }
        }
    }
}

