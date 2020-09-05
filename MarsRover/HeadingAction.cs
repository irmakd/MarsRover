using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace MarsRover
{
    public class HeadingAction
    {
        private static readonly List<HeadingAction.HeadingTypes> headingList =
        new List<HeadingTypes>() {
                        HeadingTypes.N
                        , HeadingTypes.E
                        , HeadingTypes.S
                        , HeadingTypes.W
        };

        public enum HeadingTypes
        {
            N, //North
            E, //East
            S, //South
            W  //West
        }

        public static HeadingTypes CurrentHeading;

 
        public static void RotateHeading(MovementAction.DirectionTypes directionType)
        {
            int indexToAdd = 0;

            if (directionType.Equals(MovementAction.DirectionTypes.L))
            {
                indexToAdd = -1;
            }
            else if (directionType.Equals(MovementAction.DirectionTypes.R))
            {
                indexToAdd = 1;
            }

            //we took mode of index, because it is actually a circular array:
            int currentHeadingIndex = headingList.IndexOf(CurrentHeading);
            int nextHeadingIndex = ((currentHeadingIndex + indexToAdd) + 4) % 4;

            HeadingTypes nextHeading = headingList.ElementAt(nextHeadingIndex);

            CurrentHeading = nextHeading;
        }
    }
}
