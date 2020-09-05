using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class MovementAction
    {
        public enum DirectionTypes
        {
            L, //Left
            R, //Right
            M  //Move forward
        }
        public static int X;
        public static int Y;

        // Moves rover one step forward through the heading direction  
        public static void MoveForward()
        {
            if (HeadingAction.CurrentHeading.Equals(HeadingAction.HeadingTypes.N))
            {
                Y += 1;
            }
            else if (HeadingAction.CurrentHeading.Equals(HeadingAction.HeadingTypes.E))
            {
                X += 1;
            }
            else if (HeadingAction.CurrentHeading.Equals(HeadingAction.HeadingTypes.S))
            {
                Y -= 1;
            }
            else if (HeadingAction.CurrentHeading.Equals(HeadingAction.HeadingTypes.W))
            {
                X -= 1;
            }
        }

        // Rotates heading to left
        public static void SpinLeft()
        {
            HeadingAction.RotateHeading(MovementAction.DirectionTypes.L);
        }

        // Rotates heading to right
        public static void SpinRight()
        {
            HeadingAction.RotateHeading(MovementAction.DirectionTypes.R);
        }
    }
}
