using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover
{
    public class Rover
    {
        int PlateauDimensionX = 0;
        int PlateauDimensionY = 0;
        private string ShowResult()
        {
            return MovementAction.X + " " + MovementAction.Y + " " + HeadingAction.CurrentHeading.ToString();
        }

        private void ValidateRoverSetting()
        {
            if (MovementAction.X == null || MovementAction.Y == null)
                InputParser.ShowError(1);
            
            else if (PlateauDimensionX == null || PlateauDimensionY == null)
                InputParser.ShowError(1);

            else if (MovementAction.X > PlateauDimensionX || MovementAction.Y> PlateauDimensionY)
                InputParser.ShowError(2);


        }

        public Rover (string plateauSize, string roverCoordinates)
        {
            var coordinates = InputParser.RoverCoordinatesParser(roverCoordinates);

            if (!string.IsNullOrWhiteSpace(InputParser.error))
                return;

            var dimensions = InputParser.PlateauDimensionsParser(plateauSize);

            if (!string.IsNullOrWhiteSpace(InputParser.error))
                return;

            MovementAction.X = coordinates.Item1;
            MovementAction.Y = coordinates.Item2;
            HeadingAction.CurrentHeading = coordinates.Item3;

            PlateauDimensionX = dimensions.Item1;
            PlateauDimensionY = dimensions.Item2;
    
        }

        public string Move(string movements)
        {
            ValidateRoverSetting();
            string[] movementArray = InputParser.RoverMovementsParser(movements);

            foreach (string movement in movementArray)
            {
                if (movement.Equals(MovementAction.DirectionTypes.L.ToString()))
                    MovementAction.SpinLeft();
                else if (movement.Equals(MovementAction.DirectionTypes.R.ToString()))
                    MovementAction.SpinRight();
                else if (movement.Equals(MovementAction.DirectionTypes.M.ToString()))
                    MovementAction.MoveForward();
                else
                    ; 
            }

            if (MovementAction.X > PlateauDimensionX || MovementAction.Y > PlateauDimensionY)
            {
                return InputParser.ShowError(2);
            }

            return ShowResult();
        }

    }
}

