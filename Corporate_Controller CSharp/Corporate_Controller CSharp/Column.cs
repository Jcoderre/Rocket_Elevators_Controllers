using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace Corporate_Controller_CSharp
{
    class Column
    {
        public int Id;
        public int MinFloor;
        public int MaxFloor;
        public int FloorAmount;
        public List<Elevator> ElevatorList;
        public bool IsStatusIdle;
        public int ChosenElevator;
        public string UserResponse;
        public string UserDirection;
        public int UserDestination;
        public int UserActualFloor;

        public Column(int id, int minFloor, int maxFloor, int elevatorAmountPerColumn)
        {
            Id = id;
            MinFloor = minFloor;
            MaxFloor = maxFloor;
            FloorAmount = (maxFloor + 1) - minFloor;
            ElevatorList = new List<Elevator>();
            IsStatusIdle = true;
            //ChosenElevator = chosenElevator;

            //List of elevator for each column
            // FOR the number of elevator per column increment by 1 
            // Default value 1 to skip an elevator assign with 0
            for (int i = 1; i < elevatorAmountPerColumn + 1; i++)
            {
                ElevatorList.Add(new Elevator(i+1));
                Console.WriteLine(ElevatorList);
            }

            

        }
    }

}
