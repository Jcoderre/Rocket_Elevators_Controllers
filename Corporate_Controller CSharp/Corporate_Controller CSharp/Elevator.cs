//##############################################################
//######### CORPORATE CONTROLLER CSHARP VERSION ################
//##############################################################

using System;
using System.Collections.Generic;

namespace Corporate_Controller_CSharp
{
    public class Elevator
    {
        public int Id;
        public List<int> ElevatorQueue = new List<int>();       // Unordered set of floor request
        public List<int> DestinationList = new List<int>();   // Array of Requested Buttons
        public bool IsStatusIdle = true;                        // Boolean ->  IDLE, Moving
        public bool? IsDirectionUp = null;                      // Boolean ->  Up, Down
        public bool IsDoorsClose = true;                        // Boolean ->  Close or Open
        public int CurrentFloor = 1;                            // Actual floor of the elevato
        public int MaxWeight = 2500;                            // Maximum Weight
        public int ActualWeight = 0;                            // Actual Weight


        public Elevator(int id)
        {
            Id = id;
        }

   
    }
}
