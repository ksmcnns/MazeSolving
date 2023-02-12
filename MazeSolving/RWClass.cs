using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolving
{
    class RWClass
    {
        string FileWay = "";
        public string[,] Read()
        {
            Console.WriteLine();
            Console.WriteLine("Enter a path to solve a maze!");
            string fileWay = Console.ReadLine();
            FileWay = fileWay;
            StreamReader streamReader = new StreamReader(fileWay);
            string[] text = streamReader.ReadToEnd().Split('\n');
            string[,] maze = new string[30, 30];
            string[] textUp = new string[10];
            char[] deliminates = { ' ', ',', '\r', '{', '}' };
            for (int i = 0; i < 30; i++)
            {
                textUp = text[i].Split(deliminates, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < 30; j++)
                {
                    maze[i, j] = textUp[j];
                }
            }
            streamReader.Close();
            return maze;
        }
        public int[,] convertMaze(string[,] maze)
        {
            int[,] newMaze = new int[30, 30];
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    newMaze[i, j] = Convert.ToInt32(maze[i, j]);
                }
            }
            return newMaze;
        }
        public void Write(int[,] lab)
        {
            string fileWay = FileWay;
            StreamWriter streamWriter = new StreamWriter(fileWay);
            streamWriter.Write("{");
            for (int i = 0; i < 30; i++)
            {
                streamWriter.Write("{");
                for (int j = 0; j < 30; j++)
                {
                    streamWriter.Write(lab[i, j]);
                    if (j != 29)
                    {
                        streamWriter.Write(",");
                    }
                }
                streamWriter.Write("}");
                if (i != 29)
                {
                    streamWriter.Write(",");
                    streamWriter.Write("\n");
                }
            }
            streamWriter.Write("}");
            streamWriter.Close();
        }
    }
}

