using System;
using System.IO;
using System.Collections.Generic;

namespace ArrayTest
{
    class Program
    {
        public struct Entry
        {
            public string strDirection;
            public int intSteps;

            public Entry(string sVal, int iVal)
            {
                strDirection = sVal;
                intSteps = iVal;
            }
        }

        public struct Coordinate
        {
            public int x;
            public int y;

            public Coordinate(int iX, int iY)
            {
                x = iX;
                y = iY;
            }
        }

        static void Main(string[] args)
        {


            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Source\\repos\\Treasure_Map\\Input_Text.txt");
            StreamReader sr = File.OpenText(path);
            string buffer = sr.ReadLine();
            string pt1 = "";
            string pt2 = "";
            int i = 0;
            int counter = 0;

            List<Entry> coord = new List<Entry>();

            while(buffer != null)
            {
                while (i < buffer.Length)
                {

                    if (buffer[i] == ',')
                    {
                        counter++;
                    }

                    if (counter == 0 && buffer[i] != ',')
                    {
                        pt1 += buffer[i];
                    }

                    if (counter == 1 && buffer[i] != ',')
                    {
                        pt2 += buffer[i];
                    }

                    i++;

                }

                coord.Add(new Entry(pt1, Int32.Parse(pt2)));

                buffer = sr.ReadLine();
                pt1 = "";
                pt2 = "";
                i = 0;
                counter = 0;


            }

            foreach(Entry entry in coord)
            {
                Console.WriteLine(entry.strDirection + ", " +  entry.intSteps);
            }


            //Entry[] myCustomArray = { new Entry("W", 8), new Entry("NW", 2), new Entry("N", 2), new Entry("NE", 2) };

            string[,] playField = {
                { " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ",},
                { " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ",},
                { " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ",},
                { " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ",},
                { " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ",},
                { " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ",},
                { " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ",},
                { " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ",},
                { " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ",},
                { " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ",},
                { " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ",},
                { " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ",},
                { " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ",},
                { " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ",},
                { " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ",},
                { " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ",},
                { " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ",},
                { " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ",},
                { " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ",},
                { " ", " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ",}};

            Coordinate position = new Coordinate(10, 10); ;
            playField[position.x, position.y] = "¤";

            foreach (Entry entry in coord)
            {
                int deltaX = 0;
                int deltaY = 0;
                switch (entry.strDirection)
                {
                    case "N":
                        deltaY = -entry.intSteps;
                        break;
                    case "E":
                        deltaX = entry.intSteps;
                        break;
                    case "S":
                        deltaY = entry.intSteps;
                        break;
                    case "W":
                        deltaX = -entry.intSteps;
                        break;
                    case "NE":
                        deltaY = -entry.intSteps;
                        deltaX = entry.intSteps;
                        break;
                    case "NW":
                        deltaY = -entry.intSteps;
                        deltaX = -entry.intSteps;
                        break;
                    case "SE":
                        deltaY = entry.intSteps;
                        deltaX = entry.intSteps;
                        break;
                    case "SW":
                        deltaY = entry.intSteps;
                        deltaX = -entry.intSteps;
                        break;

                    default: 
                        break;
                }

                while ((deltaX != 0) || (deltaY != 0))
                {
                    if (deltaX != 0)
                    {
                        position.x = deltaX < 0 ? position.x - 1 : position.x + 1;
                        deltaX = deltaX < 0 ? deltaX + 1 : deltaX - 1;
                    }

                    if (deltaY != 0)
                    {
                        position.y = deltaY < 0 ? position.y - 1 : position.y + 1;
                        deltaY = deltaY < 0 ? deltaY + 1 : deltaY - 1;
                    }
                    playField[position.x, position.y] = "*";
                }
            }

            for (int iY = 0; iY < playField.GetLength(0); iY++)
            {
                for (int iX = 0; iX < playField.GetLength(1); iX++)
                {
                    Console.Write(playField[iX, iY]);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}