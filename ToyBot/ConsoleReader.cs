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
         *   - PLACE X,Y,F - places robot on table at position (X,Y) and orientation F.
         *   - MOVE - moves robot one tile.
         *   - LEFT - rotates robot ccw.
         *   - RIGHT - rotates robot cw.
         *   - AUTOREPORT - reports position and orientation automatically after PLACE, MOVE, LEFT and RIGHT.
         *   - REPORT - writes position and orientation to the console.
         *   - HELP - writes a log of possible commands.
         *   - QUIT - quits application.
         */
        public void ToyBotGame1(short planId, short planWidth, short planHeight)
        {
            // Startup Messages
            Console.WriteLine("> Welcome to the ToyBot Program, please type your commands.");
            Console.WriteLine("> If you need any help using the program, type HELP.");
            // Initialising Variables
            bool isRunning = true;
            bool autoReport = false;
            Tuple<short, short, short, short> interpretedInput;
            string input;
            ToyBotObj tbot = new ToyBotObj(Tuple.Create<short, short>(0, 0),
                                           0,
                                           -1,
                                           Tuple.Create<short,short>(planWidth, planHeight));

            // Until the user didn't Type Quit
            while (isRunning)
            {
                Console.Write(">> ");
                input = Console.ReadLine();
                interpretedInput = InterpretInput(input);
                switch (interpretedInput.Item1)
                {
                    // Error in Action
                    case -2:
                        Console.WriteLine("> Your action has an error in it," +
                                           " please type HELP in order to consult our list of valid actions.");
                        break;
                    // Unrecognised Action
                    case -1:
                        Console.WriteLine("> Your action is unrecognised," +
                                           " please type HELP in order to consult our list of valid actions.");
                        break;
                    // PLACE X,Y,F
                    case 0:
                        if (Enumerable.Range(0, tbot.PlanSize.Item1).Contains(interpretedInput.Item2) &
                            Enumerable.Range(0, tbot.PlanSize.Item2).Contains(interpretedInput.Item3)) 
                        {
                            tbot.Position = Tuple.Create<short, short>(interpretedInput.Item2, interpretedInput.Item3);
                            tbot.Orientation = interpretedInput.Item4;
                            tbot.PlanId = planId;
                            if (autoReport)
                            {
                                tbot.Report();
                            }
                        }
                        else
                        {
                            Console.WriteLine("> Invalid placement, please give placement values:" +
                                              "\n   - Between 0 and " + (tbot.PlanSize.Item1 - 1).ToString() + " for X." +
                                              "\n   - Between 0 and " + (tbot.PlanSize.Item2 - 1).ToString() + " for Y.");
                        }
                        break;
                    // MOVE
                    case 1:
                        if (tbot.PlanId != -1)
                        {
                            tbot.Move();
                            if (autoReport)
                            {
                                tbot.Report();
                            }
                        }
                        else
                        {
                            Console.WriteLine("> ToyBot isn't on the table yet! Please use the PLACE X,Y,F command first!");
                        }
                        break;
                    // LEFT | RIGHT
                    case 2:
                        if (tbot.PlanId != -1)
                        {
                            tbot.Rotate(interpretedInput.Item4);
                            if (autoReport)
                            {
                                tbot.Report();
                            }
                        }
                        else
                        {
                            Console.WriteLine("> ToyBot isn't on the table yet! Please use the PLACE X,Y,F command first!");
                        }
                        break;
                    // REPORT
                    case 3:
                        if (tbot.PlanId != -1)
                        {
                            tbot.Report();
                        }
                        else
                        {
                            Console.WriteLine("> ToyBot isn't on the table yet! Please use the PLACE X,Y,F command first!");
                        }
                        break;
                    // QUIT
                    case 4:
                        isRunning = false;
                        Console.WriteLine("> Thank you for using ToyBot!");
                        Console.ReadLine();
                        break;
                    // HELP
                    case 5:
                        Console.WriteLine("> These are the actions you can make:" +
                                          "\n  - PLACE X,Y,F - places robot on table at position (X,Y) and orientation F (North,East,West,South)." +
                                          "\n  - MOVE - moves robot one tile." +
                                          "\n  - LEFT - rotates robot ccw." +
                                          "\n  - RIGHT - rotates robot cw." +
                                          "\n  - AUTOREPORT - reports position and orientation automatically after PLACE, MOVE, LEFT and RIGHT." +
                                          "\n  - REPORT - writes position and orientation to the console." +
                                          "\n  - HELP - writes a log of possible commands." +
                                          "\n  - QUIT - quits application.");
                        break;
                    // AUTOREPORT
                    case 6:
                        if (autoReport)
                        {
                            Console.WriteLine("> AutoReport Disabled.");
                            autoReport = false;
                        }
                        else
                        {
                            Console.WriteLine("> AutoReport Enabled.");
                            autoReport = true;
                        }
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
         *   - AUTOREPORT - reports position and orientation automatically after PLACE, MOVE, LEFT and RIGHT.
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
                        case "autoreport":
                            return Tuple.Create<short, short, short, short>(6, -1, -1, -1);
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
                                        return Tuple.Create<short, short, short, short>(-2, -1, -1, -1);
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
