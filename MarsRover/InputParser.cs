using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace MarsRover
{
    class InputParser
    {
        private static readonly string seperator = " ";
        public static string error = "";
        public static Tuple<int, int> PlateauDimensionsParser(string dimensions)
        {

            string[] dimensionsArray = dimensions.Split(seperator);

            if (dimensionsArray.Length != 2)
            {
                ShowError(3); 
                return null;
            }
            else
            {
                int positionX = Convert.ToInt32(dimensionsArray[0]);
                int positionY = Convert.ToInt32(dimensionsArray[1]);
                return Tuple.Create(positionX, positionY);

            }
        }
        public static Tuple<int,int, HeadingAction.HeadingTypes> RoverCoordinatesParser(string coordinates)
        {
            string[] coordinatesArray = coordinates.Split(seperator);

            if (coordinatesArray.Length != 3)
            {
                ShowError(4);
                return null;
            }

            int positionX = Convert.ToInt32(coordinatesArray[0]);
            int positionY = Convert.ToInt32(coordinatesArray[1]);

            string roverHeading = coordinatesArray[2];

            HeadingAction.HeadingTypes heading = HeadingAction.HeadingTypes.N;
            Enum.TryParse(roverHeading, out heading);

            return Tuple.Create(positionX, positionY, heading);
   
        }
        public static string[] RoverMovementsParser(string movements)
        {
            string movementsInputCheck = movements.Replace("L", "").Replace("R", "").Replace("M", "").Trim();
            if (movementsInputCheck.Length > 0)
                ShowError(5);

            return movements.ToCharArray().Select(a => a.ToString()).ToArray();
        }

        public static string ShowError(int errorCode)
        {
            if (errorCode.Equals(1))
                error = "There is an error in your input data. Please check your inputs and try again.";
            else if (errorCode.Equals(2))
                error = "Movement is outside of the boundaries of the plateau.";
            else if (errorCode.Equals(3))
                error = "Initial plateau coordinates are invalid.";
            else if (errorCode.Equals(4))
                error = "Initial rover coordinates are invalid.";
            else if (errorCode.Equals(5))
                error = "Rover movement data is invalid.";
            else
                error = "Unexpected error occured.";

            return error;
        }

    }
}
