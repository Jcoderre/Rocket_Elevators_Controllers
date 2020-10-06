using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
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
                var elevator = new Elevator(i + 1);
                ElevatorList.Add(elevator);
                Console.WriteLine(ElevatorList);
            }


        }

        public void Best_Elevator(int UserActualFloor, string UserDirection, int find_Best_Elevator)
        {
            var bestScore = 10;
            for (elevator in ElevatorList)
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
                    else if (elevatorIsDirectionUp == false)
                    {
                        if (bestScore > 8)
                        {
                            ChosenElevator = elevator;
                            bestScore = 8;
                        }
                    }
                    else if (IsStatusIdle == true)
                    {
                        if (find_Closest_Elevator == ElevatorList[0].currentFloor)
                        {
                            if (bestScore > 2)
                            {
                                ChosenElevator = elevator;
                                bestScore = 2;
                            }
                        }
                        else if (find_Closest_Elevator == ElevatorList[1].currentFloor)
                        {
                            if (bestScore > 1)
                            {
                                ChosenElevator = elevator;
                                bestScore = 2;
                            }
                        }
                    }
                } else if (UserDirection == "Down")
                {
                    if (elevator.IsDirectionUp == true && UserActualFloor >= elevator.CurrentFloor)
                    {
                        if (bestScore > 1)
                        {
                            ChosenElevator = elevator;
                            bestScore = 1;
                        }
                    }
                    else if (elevatorIsDirectionUp == false)
                    {
                        if (bestScore > 8)
                        {
                            ChosenElevator = elevator;
                            bestScore = 8;
                        }
                    }
                    else if (IsStatusIdle == true)
                    {
                        if (find_Closest_Elevator == ElevatorList[0].currentFloor)
                        {
                            if (bestScore > 2)
                            {
                                ChosenElevator = elevator;
                                bestScore = 2;
                            }
                        }
                        else if (find_Closest_Elevator == ElevatorList[1].currentFloor)
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
        }


        public void MoveUp(int UserActualFloor, int UserDestination)
        {
            while (UserActualFloor > ChosenElevator.currentFloor || UserDestination < ChosenElevator.currentFloor)
            {
                ChosenElevator.currentFloor += 1;
                ChosenElevator.IsStatusIdle = false;
                Console.WriteLine("The elevator is at floor: " + ChosenElevator.currentFloor);
                ChosenElevator.IsDirectionUp = true;
                if (UserDestination == chosenElevator.currentFloor || UserDestination == ChosenElevator.currentFloor)
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

        public void MoveDown(int UserActualFloor, int UserDestination)
        {
            while (UserActualFloor < ChosenElevator.currentFloor || UserDestination < ChosenElevator.currentFloor)
            {
                ChosenElevator.currentFloor -= 1;
                ChosenElevator.IsStatusIdle = false;
                Console.WriteLine("The elevator is at floor: " + ChosenElevator.currentFloor);
                ChosenElevator.IsDirectionUp = false;
                if (UserDestination == chosenElevator.currentFloor || UserDestination == ChosenElevator.currentFloor)
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

        public void RequestElevator(int UserActualFloor)
        {
            ChosenElevator.elevatorQueue.Add(UserActualFloor);
            if (UserActualFloor > ChosenElevator.CurrentFloor)
            {
                ChosenElevator.IsDirectionUp = true;
                MoveUp(UserActualFloor, UserDestination);
            } else if (UserActualFloor < ChosenElevator.CurrentFloor)
            {

            }
        }

        public void AssignElevator(int UserDestination)
        {
            ChosenElevator.requestButtonList.Add(UserDestination);
            if (UserDirection == "Up")
            {
                MoveUp(UserActualFloor, UserDestination);
            } else if (UserDirection == "Down")
            {
                MoveDown(UserActualFloor,UserDestination);
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





    }


   

}
