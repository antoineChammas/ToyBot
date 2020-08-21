using System;

namespace ToyBot
{
    /*
     * This is an interface for all Plan Objects.
     * I consider the Toy Robot to be an object in the plan,
     * future objects like other robots or obstacles can also
     * be considered as plan objects containing the following
     * generic values:
     *   - Tuple<short, short> Position - represents the x,y
     *   position of the plan object... This could be further
     *   expanded if working with N-Dimensional plans.
     *   - short Orientation - represents the current orientation
     *   of the plan object, orientation can only take 3 values
     *   0,1,2,3 representing the 4 orientations currently allowed
     *   being up, right, down, left... This could be further expanded
     *   if working with N-Dimensional plans.
     *   - short PlanId - represents the Id of the plan, this can be used
     *   in the future if we decide to use multiple plans, it is used to
     *   keep track of obstacles in the path of the moving object(s)
     *   - Tuple<short, short> PlanSize - represents the x,y size of the plan
     *   ... This could be further expanded if working with N-Dimensional plans.
    */
    interface IPlanObject
    {
        Tuple<short, short> Position { get; set; }
        short Orientation { get; set; }
        short PlanId { get; set; }
        Tuple<short, short> PlanSize { get; set; }
    }
}