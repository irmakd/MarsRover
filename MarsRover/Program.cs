using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please specify the plateau size on X and Y coordinates, splitting with space:");
            string inputPlateauSize = Console.ReadLine().ToUpper(); 
            //inputPlateauSize = "5 5";

            List<string> resultList = new List<string>();
            for (int i = 1; i<3; i++)
            {
                Console.WriteLine(string.Format("Please specify the Rover #{0}'s coordinates and heading, splitted via space:", i));
                string roverCoordinates = Console.ReadLine().ToUpper(); 
                //roverCoordinates = "1 2 N";

                Console.WriteLine(string.Format("Please specify the Rover #{0}'s movements:", i));
                string roverMovements = Console.ReadLine().ToUpper(); 
                //roverMovements = "LMLMLMLMM";

                Explorer explorer = new Explorer(inputPlateauSize, roverCoordinates, roverMovements);
                var result = explorer.Explore();
                resultList.Add(result);
            }

            foreach(string item in resultList)
            {
                Console.WriteLine(item);
            }

            Console.Read();

        }
         
    }
}
