using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ToyBot
{
    public class ConsoleReader
    {
        /*
         * Game Playing Function.
         * Writes to the console and takes user input to move/rotate the robot.
         * Here are the possible commands:
         *   
         */
        public void ToyBotGame1()
        {

        }

        /*
         * This function interprets the input of the console by cleaning it and splitting it,
         * if the amount of split strings is either 2 or 1, it will process them further, if
         * it isn't, it will stop.
         * The return type is a quadruple with the first element being what the action is
         * the second element being a change in x, the third a change in y, and the fourth
         * a change in the orientation. This can be changed later if working with N-dimensions.
         * The recognised actions (case insensitive) are:
         *   - PLACE X,Y,F - returns (0, X, Y, F).
         *   - MOVE - returns (1, -1, -1, -1).
         *   - LEFT - returns (2, -1, -1, -1).
         *   - RIGHT - returns (2, -1, -1, 1).
         *   - REPORT - returns (3, -1, -1, -1).
         *   - QUIT - returns (4, -1, -1, -1).
         * An unrecognised action is returned as (-1, -1, -1, -1).
         */
        public Tuple<short, short, short, short> InterpretInput(string consoleInput)
        {
            // turn more than one space in the string into one space, remove edge spaces and split the string
            // using spaces.
            string[] splitInput = Regex.Replace(consoleInput, @"\s+", " ").ToLower().Trim().Split(' ');
            switch (splitInput.Length)
            {
                case 1:
                    switch (splitInput[0])
                    {
                        case "move":
                            return Tuple.Create<short, short, short, short>(1, -1, -1, -1);
                        case "left":
                            return Tuple.Create<short, short, short, short>(2, -1, -1, -1);
                        case "right":
                            return Tuple.Create<short, short, short, short>(2, -1, -1, 1);
                        case "report":
                            return Tuple.Create<short, short, short, short>(3, -1, -1, -1);
                        case "quit":
                            return Tuple.Create<short, short, short, short>(4, -1, -1, -1);
                    }
                    break;
                case 2:
                    switch (splitInput[0])
                    {
                        case "place":
                            string[] splitValues = splitInput[1].Split(',');
                            if (splitValues.Length == 3)
                            {
                                short orientation = FindOrientation(splitValues[2]);
                                if (!short.TryParse(splitValues[0], out short value_result) | !short.TryParse(splitValues[1], out short value_result1) | orientation == -1)
                                {
                                        return Tuple.Create<short, short, short, short>(-1, -1, -1, -1);
                                }
                                return Tuple.Create<short, short, short, short>(0,
                                                                                short.Parse(splitValues[0]),
                                                                                short.Parse(splitValues[1]),
                                                                                orientation);
                            }
                            break;
                    }
                    break;
            }
            return Tuple.Create<short, short, short, short>(-1, -1, -1, -1);
        }

        /*
         * Converts textual orientation to numerical:
         *   North - 0.
         *   East - 1.
         *   South - 2.
         *   West - 3.
         * Considers input to be cleaned to lower casing.
         * If input is wrong, return -1
         */
        public short FindOrientation(string stringOrientation)
        {
            switch (stringOrientation)
            {
                case "north":
                    return 0;
                case "east":
                    return 1;
                case "south":
                    return 2;
                case "west":
                    return 3;
            }
            return -1;
        }
    }
}
