using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ToyBot
{
    public class ToyBotObj : IPlanObject
    {

        private Tuple<short,short> _position;
        private short _orientation;
        private short _planId;
        private Tuple<short, short> _planSize;

        // ToyBot Constructor
        public ToyBotObj(Tuple<short, short> position, short orientation, short planId, Tuple<short, short> planSize)
        {
            _position = position;
            _orientation = (short)(orientation % 4);
            _planId = planId;
            _planSize = planSize;
        }

        // Value Initialisation
        public Tuple<short, short> Position { get => _position; set => _position = value; }
        public short Orientation { get => _orientation; set => _orientation = GeneralUtilities.Mod(value, 4); }
        public short PlanId { get => _planId; set => _planId = value; }
        public Tuple<short, short> PlanSize { get => _planSize; set => _planSize = value; }

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
            bool exceeds = true;
            switch (Orientation)
            {
                // North
                case 0:
                    if (_position.Item2 < _planSize.Item2 - 1)
                    {
                        _position = Tuple.Create<short, short>(_position.Item1, (short)(_position.Item2 + 1));
                        exceeds = false;
                    }
                    break;
                // East
                case 1:
                    if (_position.Item1 < _planSize.Item1 - 1)
                    {
                        _position = Tuple.Create<short, short>((short)(_position.Item1 + 1), _position.Item2);
                        exceeds = false;
                    }
                    break;
                // South
                case 2:
                    if (_position.Item2 > 0)
                    {
                        _position = Tuple.Create<short, short>(_position.Item1, (short)(_position.Item2 - 1));
                        exceeds = false;
                    }
                    break;
                // West
                case 3:
                    if (_position.Item1 > 0)
                    {
                        _position = Tuple.Create<short, short>((short)(_position.Item1 - 1), _position.Item2);
                        exceeds = false;
                    }
                    break;
            }
            if (exceeds)
            {
                Console.WriteLine("> Can't move further, please change the orientation.");
            }
        }

        /*
         * Report prints to the console the current position of the Robot
         * as well as its current orientation translated to North, East,
         * South, West.
         */
        public void Report()
        {
            Console.WriteLine("> Position: " + _position.ToString());
            Console.WriteLine("> Orientation: " + FindOrientation(_orientation));
        }

        /*
         * Rotates Toy Robot by a certain rotation value r. (-r for ccw and +r for cw)
         */
        public void Rotate(short r)
        {
            _orientation = GeneralUtilities.Mod((short)(_orientation + r), 4);
        }

        /*
         * Used to translate numerical orientation into string.
         */
        public string FindOrientation(short orientation)
        {
            switch (orientation)
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
