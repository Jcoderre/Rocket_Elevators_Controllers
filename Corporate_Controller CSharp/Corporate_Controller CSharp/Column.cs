using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

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
        public string UserResponse;
        public string UserDirection;
        public int UserDestination = 34;
        public int UserActualFloor = 5;
        public int FindBestElevator = 2;


        public Column(int id, int minFloor, int maxFloor, int elevatorAmountPerColumn )
        {
            Id = id;
            MinFloor = minFloor;
            MaxFloor = maxFloor;
            FloorAmount = (maxFloor + 1) - minFloor;


            //ChosenElevator = chosenElevator;

            //List of elevator for each column
            // FOR the number of elevator per column increment by 1 
            // Default value 1 to skip an elevator assign with 0
            for (int i = 1; i < elevatorAmountPerColumn + 1; i++)
            {
                Elevator elevator = new Elevator(i);
                ElevatorList.Add(elevator);
                Console.WriteLine(ElevatorList);
                Console.WriteLine(elevator.Id);
            }
            Start();
        }
        /*  
                   public void Best_Elevator(int UserActualFloor, string UserDirection, int FindBestElevator)
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
                                   if (bestScore > 8)
                                   {
                                       ChosenElevator = elevator;
                                       bestScore = 8;
                                   }
                               }
                               else if (elevator.IsStatusIdle == true)
                               {
                                   if (find_Closest_Elevator == ElevatorList[1].CurrentFloor)
                                   {
                                       if (bestScore > 2)
                                       {
                                           ChosenElevator = elevator;
                                           bestScore = 2;
                                       }
                                   }
                                   else if (find_Closest_Elevator == ElevatorList[1].CurrentFloor)
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
                               else if (elevator.IsDirectionUp == false)
                               {
                                   if (bestScore > 8)
                                   {
                                       ChosenElevator = elevator;
                                       bestScore = 8;
                                   }
                               }
                               else if (elevator.IsStatusIdle == true)
                               {
                                   if (find_Closest_Elevator == ElevatorList[0].CurrentFloor)
                                   {
                                       if (bestScore > 2)
                                       {
                                           ChosenElevator = elevator;
                                           bestScore = 2;
                                       }
                                   }
                                   else if (find_Closest_Elevator == ElevatorList[1].CurrentFloor)
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

   */

        public void MoveUp(int UserActualFloor, int UserDestination)
                {
                    ChosenElevator = ElevatorList[1];
                while (UserActualFloor > ChosenElevator.CurrentFloor || UserDestination < ChosenElevator.CurrentFloor)
                    {
                        ChosenElevator.CurrentFloor += 1;
                        ChosenElevator.IsStatusIdle = false;
                        Console.WriteLine("The elevator is at floor: " + ChosenElevator.CurrentFloor);
                        ChosenElevator.IsDirectionUp = true;
                        if (UserDestination == ChosenElevator.CurrentFloor || UserDestination == ChosenElevator.CurrentFloor)
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
                    ChosenElevator = ElevatorList[1];
                    while (UserActualFloor < ChosenElevator.CurrentFloor || UserDestination < ChosenElevator.CurrentFloor)
                    {
                        ChosenElevator.CurrentFloor -= 1;
                        ChosenElevator.IsStatusIdle = false;
                        Console.WriteLine("The elevator is at floor: " + ChosenElevator.CurrentFloor);
                        ChosenElevator.IsDirectionUp = false;
                        if (UserDestination == ChosenElevator.CurrentFloor || UserDestination == ChosenElevator.CurrentFloor)
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


                public void RequestElevator(int UserActualFloor, int UserDestination)
                {
                    //Best_Elevator(int UserActualFloor, string UserDirection, int FindBestElevator);
                    //ChosenElevator.ElevatorQueue.Add(UserActualFloor);
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
                    ChosenElevator.RequestButtonList.Add(UserDestination);
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


    public void Start()
    {
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("------------------ SEQUENCE 1 ---------------------");
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("");
        MoveUp(UserActualFloor, UserDestination);
    }

    

    }


   

} 
