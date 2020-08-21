using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ToyBot
{
    class ToyBot : IPlanObject
    {

        private Tuple<short,short> position;
        private short orientation;
        private short planId;
        private Tuple<short, short> planSize;

        // ToyBot Constructor
        public ToyBot(Tuple<short, short> given_position, short given_orientation, short given_planId, Tuple<short, short> given_planSize)
        {
            position = given_position;
            orientation = given_orientation;
            planId = given_planId;
            planSize = given_planSize;
        }

        // Value Initialisation
        public Tuple<short, short> Position { get => position; set => position = value; }
        public short Orientation { get => orientation; set => orientation = (short)(value % 4); }
        public short PlanId { get => planId; set => planId = value; }
        public Tuple<short, short> PlanSize { get => planSize; set => planSize = value; }

        /*
         * Move is a function that updates the position by one step
         * based on the ToyBot's orientation:
         *   - 0 - The Robot is facing north, adds 1 to the second member
         *   of the position pair.
         *   - 1 - The Robot is facing east, adds 1 to the first member
         *   of the position pair.
         *   - 2 - The Robot is facing south, removes 1 to the second member
         *   of the position pair.
         *   - 3 - The Robot is facing west, removes 1 to the first member
         *   of the position pair.
         * Move takes into consideration the edges of the plan being (0,0)
         * and (x,y) for x,y being the first and second value of PlanSize.
         */
        public void Move() 
        {
            switch (Orientation)
            {
                // North
                case 0:
                    if (position.Item2 < planSize.Item2)
                    {
                        position = Tuple.Create<short, short>(position.Item1, (short)(position.Item2 + 1));
                    }
                    break;
                // East
                case 1:
                    if (position.Item1 < planSize.Item1)
                    {
                        position = Tuple.Create<short, short>((short)(position.Item1 + 1), position.Item2);
                    }
                    break;
                // South
                case 2:
                    if (position.Item2 > 0)
                    {
                        position = Tuple.Create<short, short>(position.Item1, (short)(position.Item2 - 1));
                    }
                    break;
                // West
                case 3:
                    if (position.Item1 > 0)
                    {
                        position = Tuple.Create<short, short>((short)(position.Item1 - 1), position.Item2);
                    }
                    break;
            }
        }

        /*
         * Report prints to the console the current position of the Robot
         * as well as its current orientation translated to North, East,
         * South, West.
         */
        public void Report()
        {
            Console.WriteLine("Position: " + position.ToString());
            Console.WriteLine("Orientation: " + FindOrientation(orientation));
        }

        /*
         * Rotates Toy Robot by a certain rotation value r. (-r for ccw and +r for cw)
         */
        public void Rotate(short r)
        {
            orientation = (short)(orientation + r);
        }

        /*
         * Used to translate numerical orientation into string.
         */
        private string FindOrientation(short orient)
        {
            switch (orient)
            {
                case 0:
                    return "North";
                case 1:
                    return "East";
                case 2:
                    return "South";
                case 3:
                    return "West";
            }
            return "Unspecified";
        }

    }
}
