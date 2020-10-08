using System;
using System.Collections.Generic;

/* using System.Linq;
using System.Net.Http.Headers;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using static Corporate_Controller_CSharp.Battery; */

namespace Corporate_Controller_CSharp
{

    public class Column
    {
        public int Id;
        public int MinFloor;
        public int MaxFloor;
        public int FloorAmount;
        public List<Elevator> ElevatorList = new List<Elevator>();
        public bool IsStatusIdle = true;
        public Elevator ChosenElevator;
        public string UserDirection = "Up";
        public int UserDestination = 14;
        public int UserActualFloor = 3;
        public int groundFloorLevel = 1;


        public Column(int id, int minFloor, int maxFloor, int elevatorAmountPerColumn)
        {
            Id = id;
            MinFloor = minFloor;
            MaxFloor = maxFloor;
            FloorAmount = (maxFloor + 1) - minFloor;




            // List of elevator for each column
            // FOR the number of elevator per column increment by 1 
            // Default value 1 to skip an elevator assign with 0
            for (int i = 1; i < elevatorAmountPerColumn + 1; i++)
            {
                Elevator elevator = new Elevator(i);
                ElevatorList.Add(elevator);
                Console.WriteLine(ElevatorList);
            }

            
        }

        public void Best_Elevator(int UserActualFloor, string UserDirection)
        {
            var bestScore = 10;
            foreach (Elevator elevator in ElevatorList)
            {
                if (UserDirection == "Up")
                {
                    if (elevator.IsDirectionUp == true && UserActualFloor >= elevator.CurrentFloor)
                    {
                        if (bestScore > 1)
                        {
                            ChosenElevator = elevator;
                            bestScore = 1;
                        }
                    }
                    else if (elevator.IsDirectionUp == false)
                    {
                        if (bestScore > 7)
                        {
                            ChosenElevator = elevator;
                            bestScore = 8;
                        }
                    }
                    else if (elevator.IsStatusIdle == true)
                    {
                        if (bestScore > 1)
                        {
                            ChosenElevator = elevator;
                            bestScore = 2;
                        }
                    }
                }
                else if (UserDirection == "Down")
                {
                    if (elevator.IsDirectionUp == true)
                    {
                        if (bestScore > 8)
                        {
                            ChosenElevator = elevator;
                            bestScore = 8;
                        }
                    }
                    else if (elevator.IsDirectionUp == false && UserActualFloor <= elevator.CurrentFloor)
                    {
                        if (bestScore > 1)
                        {
                            ChosenElevator = elevator;
                            bestScore = 1;
                        }
                    }
                    else if (elevator.IsStatusIdle == true)
                    {
                        if (bestScore > 1)
                        {
                            ChosenElevator = elevator;
                            bestScore = 2;
                        }
                    }
                }
            }
        }



        public void MoveUp(int UserActualFloor)
        {
            while (UserActualFloor > ChosenElevator.CurrentFloor)
            {
                ChosenElevator.CurrentFloor += 1;
                ChosenElevator.IsStatusIdle = false;
                Console.WriteLine("The elevator is at floor: " + ChosenElevator.CurrentFloor);
                ChosenElevator.IsDirectionUp = true;
                if (UserActualFloor == ChosenElevator.CurrentFloor)
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine("Arrived at destination");
                    Console.WriteLine("");
                    Console.WriteLine("Open Door");
                    DoorOpening();
                    Console.WriteLine("Close Door");
                    DoorClosing();

                }
            }
        }

        public void MoveDown(int UserActualFloor)
        {
            while (UserActualFloor < ChosenElevator.CurrentFloor )
            {
                ChosenElevator.CurrentFloor -= 1;
                ChosenElevator.IsStatusIdle = false;
                Console.WriteLine("The elevator is at floor: " + ChosenElevator.CurrentFloor);
                ChosenElevator.IsDirectionUp = false;
                if (UserActualFloor == ChosenElevator.CurrentFloor)
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine("Arrived at destination");
                    Console.WriteLine("");
                    Console.WriteLine("Open Door");
                    DoorOpening();
                    Console.WriteLine("Close Door");
                    DoorClosing();

                }
            }
        }

        public void ElevatorMoveUp(int UserDestination)
        {
            while (UserDestination > ChosenElevator.CurrentFloor)
            {
                ChosenElevator.CurrentFloor += 1;
                ChosenElevator.IsStatusIdle = false;
                Console.WriteLine("The elevator is at floor: " + ChosenElevator.CurrentFloor);
                ChosenElevator.IsDirectionUp = true;
                if (UserDestination == ChosenElevator.CurrentFloor)
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine("Arrived at destination");
                    Console.WriteLine("");
                    Console.WriteLine("Open Door");
                    DoorOpening();
                    Console.WriteLine("Close Door");
                    DoorClosing();

                }
            }
        }

        public void ElevatorMoveDown(int UserDestination)
        {
            while (UserDestination < ChosenElevator.CurrentFloor)
            {
                ChosenElevator.CurrentFloor -= 1;
                ChosenElevator.IsStatusIdle = false;
                Console.WriteLine("The elevator is at floor: " + ChosenElevator.CurrentFloor);
                ChosenElevator.IsDirectionUp = false;
                if (UserDestination == ChosenElevator.CurrentFloor)
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine("Arrived at destination");
                    Console.WriteLine("");
                    Console.WriteLine("Open Door");
                    DoorOpening();
                    Console.WriteLine("Close Door");
                    DoorClosing();

                }
            }
        }

        //This method represents an elevator request on a floor or basement.

        public void RequestElevator(int UserActualFloor)
        {
            ChosenElevator.ElevatorQueue.Add(UserActualFloor);
            if (UserActualFloor > ChosenElevator.CurrentFloor)
            {
                ChosenElevator.IsDoorsClose = true;
                ChosenElevator.IsDirectionUp = true;
                MoveUp(UserActualFloor);
            }
            else if (UserActualFloor < ChosenElevator.CurrentFloor)
            {
                ChosenElevator.IsDoorsClose = true;
                ChosenElevator.IsDirectionUp = true;
                MoveDown(UserActualFloor);
            }
        }

        //This method will be used for the requests made on the first floor.

        public void AssignElevator(int UserDestination)
        {
            
            ChosenElevator.DestinationList.Add(UserDestination);
            if (UserDestination > groundFloorLevel)
            {
                UserDirection = "Up";
                ChosenElevator.IsDoorsClose = true;
                ChosenElevator.IsDirectionUp = true;
                ElevatorMoveUp(UserDestination);
            }
            else if (UserDestination < groundFloorLevel)
            {
                UserDirection = "Down";
                ChosenElevator.IsDoorsClose = true;
                ChosenElevator.IsDirectionUp = true;
                ElevatorMoveDown(UserDestination);
            }
        }

        public void DoorClosing()
        {
            Console.WriteLine("");
            Console.WriteLine("_____  _____");
            Console.WriteLine("|<--|  |-->|");
            Console.WriteLine("|<--|  |-->|");
            Console.WriteLine("|<--|  |-->|");
            Console.WriteLine("|<--|  |-->|");
            Console.WriteLine("|<--|  |-->|");
            Console.WriteLine("|<--|  |-->|");
            Console.WriteLine("|<--|  |-->|");
            Console.WriteLine("|___|  |___|");
            Console.WriteLine("");
        }

        public void DoorOpening()
        {
            Console.WriteLine("");
            Console.WriteLine("_____  _____");
            Console.WriteLine("|-->|  |<--|");
            Console.WriteLine("|-->|  |<--|");
            Console.WriteLine("|-->|  |<--|");
            Console.WriteLine("|-->|  |<--|");
            Console.WriteLine("|-->|  |<--|");
            Console.WriteLine("|-->|  |<--|");
            Console.WriteLine("|-->|  |<--|");
            Console.WriteLine("|___|  |___|");
            Console.WriteLine("");
        }


        public void Start()
        {
            Console.WriteLine("");
            Console.WriteLine("Hello world");
            Console.WriteLine("");
            Best_Elevator(UserActualFloor, UserDirection);
            // If the user is at the GroundFloor  use AssignElevator function
            // If user is at an other

            
            if (UserActualFloor == 1 && ChosenElevator.CurrentFloor == 1) {
                AssignElevator(UserDestination);
            }
            else {
                RequestElevator(UserActualFloor);
            }
        }

       

        
     
    }


} 
