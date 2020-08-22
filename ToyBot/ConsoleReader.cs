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
         *   - PLACE X,Y,F - places robot on table at position (x,y) and orientation F.
         *   - MOVE - moves robot one tile.
         *   - LEFT - rotates robot ccw.
         *   - RIGHT - rotates robot cw.
         *   - REPORT - writes position and orientation to the console.
         *   - HELP - writes a log of possible commands.
         *   - QUIT - quits application.
         */
        public void ToyBotGame1(short mapId, short mapWidth, short mapHeight)
        {
            // Startup Messages
            Console.WriteLine("> Welcome to the ToyBot Program, please type your commands.");
            Console.WriteLine("> If you need any help using the program, type HELP.");
            // Initialising Variables
            bool isRunning = true;
            Tuple<short, short, short, short> interpretedInput;
            string input;
            ToyBotObj tbot = new ToyBotObj(Tuple.Create<short, short>(0, 0),
                                           0,
                                           -1,
                                           Tuple.Create<short,short>(5,5));

            // Until the user didn't Type Quit
            while (isRunning)
            {
                input = Console.ReadLine();
                interpretedInput = InterpretInput(input);
                switch (interpretedInput.Item1)
                {
                    // PLACE X,Y,F
                    case 0:
                        break;
                    // MOVE
                    case 1:
                        break;
                    // LEFT | RIGHT
                    case 2:
                        break;
                    // REPORT
                    case 3:
                        break;
                    // QUIT
                    case 4:
                        break;
                    // HELP
                    case 5:
                        break;
                }
            } 
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
         *   - HELP - returns (5, -1, -1, -1).
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
                        case "help":
                            return Tuple.Create<short, short, short, short>(5, -1, -1, -1);
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
