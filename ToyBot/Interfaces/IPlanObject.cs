using System;

namespace ToyBot

/*
 * This is an interface for all Plan Objects.
 * I consider the Toy Robot to be an object in the plan,
 * future objects like other robots or obstacles can also
 * be considered as plan objects containing the following
 * generic values:
 *   - Tuple<short, short> position - represents the x,y
 *   position of the plan object... This could be further
 *   expanded if working with N-Dimensional plans.
 *   - short orientation - represents the current orientation
 *   of the plan object, orientation can only take 3 values
 *   0,1,2,3 representing the 4 orientations currently allowed
 *   being up, right, down, left... This could be further expanded
 *   if working with N-Dimensional plans.
 *   - short planId - represents the Id of the plan, this can be used
 *   in the future if we decide to use multiple plans, it is used to
 *   keep track of obstacles in the path of the moving object(s)
 *   - Tuple<short, short> planSize - represents the x,y size of the plan
 *   ... This could be further expanded if working with N-Dimensional plans.
*/

interface IPlanObject
{
    private Tuple<short, short> position { get; set; };
    private short orientation { get; set; };
    private short planId { get; set; };
    private Tuple<short, short> planSize { get; set; }
}