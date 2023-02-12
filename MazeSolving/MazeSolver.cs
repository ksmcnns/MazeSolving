using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolving
{
    class MazeSolver
    {
        public int[,] correctPath = new int[150, 2];
        public int[,] path = new int[500, 2];
        int Paths = 0;
        int pathSayac = 0;
        Maze mz = new Maze();
        public void dataDelete()
        {
            for (int i = 0; i < pathSayac; i++)
            {
                correctPath[i, 0] = 0;
                correctPath[i, 1] = 0;
            }
            pathSayac = 0;
            for (int i = 0; i < 500; i++)
            {
                path[i, 0] = 0;
                path[i, 1] = 0;
            }
        }
        public int count(int[,] lab)
        {
            int sayac = 0;
            for (int i = 0; i < 30; i++)
            {
                if (lab[i, 0] == 1)
                {
                    sayac++;
                }
            }
            return sayac;
        }
        public int[] findDoors(int[,] lab)
        {
            int sayac = count(lab);
            int[] enterance = new int[sayac];
            int flag = 0;
            for (int i = 0; i < 30; i++)
            {
                if (lab[i, 0] == 1)
                {
                    enterance[flag] = i;
                    flag++;
                }
            }
            return enterance;
        }
        public bool isValidSpot(int[,] lab, int i, int j)
        {
            lab[i, j] = 2;
            return true;
        }
        public void pathAdd(int i, int j)
        {
            path[pathSayac, 0] = j;
            path[pathSayac, 1] = i;
            pathSayac++;
        }
        public int pathDeleteI()
        {
            int i = path[pathSayac - 1, 1];
            path[pathSayac - 1, 1] = 0;
            return i;
        }
        public void pathWrite(int[,] correctPath)
        {
            for (int i = 0; i < 150; i++)
            {
                if (correctPath[i, 0] == 0 && correctPath[i, 1] == 0 && correctPath[i + 1, 0] == 0)
                {
                    break;
                }
                else
                {
                    Console.SetCursorPosition(65 + Paths * 8, 0);
                    Console.WriteLine("{0}.adım", Paths);
                    Console.SetCursorPosition(65 + Paths * 8, 1 + i);
                    Console.WriteLine("{0},{1}", correctPath[i, 0], correctPath[i, 1]);
                }
            }
        }
        public int pathDeleteJ()
        {
            int j = path[pathSayac - 1, 0];
            path[pathSayac - 1, 0] = 0;
            return j;
        }
        public void explode(int[,] lab, int i, int j)
        {
            if (lab[i, j] == 3)
            {
                Console.Beep();
                Environment.Exit(33);
            }
        }
        public void solveMaze(int[,] lab, int i, int j)
        {
            explode(lab, i, j);
            if (isValidSpot(lab, i, j))
            {
                if (j == 29)
                {
                    pathAdd(i, j);
                    //mz.writer(lab);
                    Paths++;
                    correctPath = path;
                    pathWrite(correctPath);
                    dataDelete();
                    return;
                }
                //right
                if (lab[i, j + 1] == 1 || lab[i, j + 1] == 3)
                {
                    pathAdd(i, j);
                    solveMaze(lab, i, j + 1);
                }

                //up
                else if (i > 0 && (lab[i - 1, j] == 1 || lab[i - 1, j] == 3))
                {
                    pathAdd(i, j);
                    solveMaze(lab, i - 1, j);
                }

                //down
                else if (i < 29 && (lab[i + 1, j] == 1 || lab[i + 1, j] == 3))
                {
                    pathAdd(i, j);
                    solveMaze(lab, i + 1, j);
                }

                //left
                else if (j > 1 && (lab[i, j - 1] == 1 || lab[i, j - 1] == 1))
                {
                    pathAdd(i, j);
                    solveMaze(lab, i, j - 1);
                }
                if (pathSayac != 0 && j != 29)
                {
                    j = pathDeleteJ();
                    i = pathDeleteI();
                    pathSayac--;
                    solveMaze(lab, i, j);
                }
            }
        }
    }
}

