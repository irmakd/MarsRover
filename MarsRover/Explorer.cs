using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Explorer
    {
        private string plateauSize;
        private string roverCoordinates;
        private string roverMovement;
        public Explorer(string PlateauSize, string RoverCoordinates, string RoverMovement)
        {
            plateauSize = PlateauSize;
            roverCoordinates = RoverCoordinates;
            roverMovement = RoverMovement;
        
        }
        public string Explore(string PlateauSize, string RoverCoordinates, string RoverMovement)
        {
            plateauSize = PlateauSize;
            roverCoordinates = RoverCoordinates;
            roverMovement = RoverMovement;
            return Explore();
        }
        public string Explore()
        {
            Rover rover = new Rover(plateauSize, roverCoordinates);

            if (!string.IsNullOrWhiteSpace(InputParser.error))
                return InputParser.error;

            string result = rover.Move(roverMovement);

            return result;
        }
      
    }
}
