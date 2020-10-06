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
        public List<int> ElevatorQueue;
        public List<int> RequestButtonList;
        public bool IsStatusIdle;
        public bool? IsDirectionUp;
        public bool IsDoorsClose;
        public int CurrentFloor;
        public int MaxWeight;
        public int ActualWeight;


        public Elevator(int id)
        {
            Id = id;
            ElevatorQueue = new List<int>();         // Unordered set of floor request
            RequestButtonList = new List<int>();     // Array of Requested Buttons
            IsStatusIdle = true;                     // Boolean ->  IDLE, Moving 
            IsDirectionUp = null;                    // Boolean ->  Up, Down
            IsDoorsClose = true;                     // Boolean ->  Close or Open
            CurrentFloor = 1;                        // Actual floor of the elevator          
            MaxWeight = 2500;                        // Maximum Weight
            ActualWeight = 0;                        // Actual Weight

        
        }


    }
}
