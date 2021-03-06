﻿using System;
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
    // Creating Column
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
        // THE BEST ELEVATOR IS DEFINE BY CHOOSING IF YOUR ELEVATOR GOES UP OR DOWN
        // THAN MAKE A SELECT OF BOOLEAN STATEMENT WHERE IF YOUR ELEVATOR GOES UP OR DOWN
        // OR IF THE ELEVATOR IS IDLE THAN WITH THE SCORE HE WAS GIVEN BY DOES CONDITION THE BEST ELEVATOR IS CHOSEN
        // CALLED IN THE START FUNCTION
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


        // (MOVEUP) AND (MOVEDOWN) ARE CALLED IN (REQUESTELEVATOR) FUNCTION
        public void MoveUp(int UserActualFloor)
        {
            while (UserActualFloor > ChosenElevator.CurrentFloor)       // WHILE THE FLOOR OF THE USER IS BIGGER THAN THAN THE ELEVATOR CURRENT FLOOR
            {
                ChosenElevator.CurrentFloor += 1;                       // INCREMENT BY ONE 
                ChosenElevator.IsStatusIdle = false;                    // PUT ELEVATOR STATUS TO MOVING
                Console.WriteLine("The elevator is at floor: " + ChosenElevator.CurrentFloor);
                ChosenElevator.IsDirectionUp = true;                    // PUT ELEVATOR MOVING  STATUS TO UP
                if (UserActualFloor == ChosenElevator.CurrentFloor)     // IF THE THE ACTUAL FLOOR OF USER IS EQUAL TO ELEVATOR FLOOR STOP LOOPING
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
            while (UserActualFloor < ChosenElevator.CurrentFloor)       // WHILE THE FLOOR OF THE USER IS SMALLER THAN THAN THE ELEVATOR CURRENT FLOOR
            {
                 ChosenElevator.CurrentFloor -= 1;                      // DECREMENT BY ONE     
                ChosenElevator.IsStatusIdle = false;                    // PUT ELEVATOR STATUS TO MOVING
                Console.WriteLine("The elevator is at floor: " + ChosenElevator.CurrentFloor);
                ChosenElevator.IsDirectionUp = false;                   // PUT ELEVATOR MOVING  STATUS TO DOWN
                if (UserActualFloor == ChosenElevator.CurrentFloor)     // IF THE THE ACTUAL FLOOR OF USER IS EQUAL TO ELEVATOR FLOOR STOP LOOPING
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

        // (ELEVATORMOVEUP) AND (ELEVATORMOVEDOWN) ARE CALLED IN THE (ASSIGNELEVATOR) FUNCTION
        public void ElevatorMoveUp(int UserDestination)
        {
            while (UserDestination > ChosenElevator.CurrentFloor)       // WHILE THE FLOOR OF THE USER IS BIGGER THAN THAN THE ELEVATOR CURRENT FLOOR
            {
                ChosenElevator.CurrentFloor += 1;                       // INCREMENT BY ONE 
                ChosenElevator.IsStatusIdle = false;                    // PUT ELEVATOR STATUS TO MOVING
                Console.WriteLine("The elevator is at floor: " + ChosenElevator.CurrentFloor);
                ChosenElevator.IsDirectionUp = true;                    // PUT ELEVATOR MOVING  STATUS TO UP
                if (ChosenElevator.CurrentFloor == -1)                  
                {
                    ChosenElevator.CurrentFloor = 0;
                }
                if (UserDestination == ChosenElevator.CurrentFloor)       // IF THE THE ACTUAL FLOOR OF USER IS EQUAL TO ELEVATOR FLOOR STOP LOOPING  
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
            while (UserDestination < ChosenElevator.CurrentFloor)           // WHILE THE FLOOR OF THE USER IS BIGGER THAN THAN THE ELEVATOR CURRENT FLOOR
            {
                ChosenElevator.CurrentFloor -= 1;                           // DECREMENT BY ONE     
                ChosenElevator.IsStatusIdle = false;                        // PUT ELEVATOR STATUS TO MOVING
                Console.WriteLine("The elevator is at floor: " + ChosenElevator.CurrentFloor);
                ChosenElevator.IsDirectionUp = false;                       // PUT ELEVATOR MOVING  STATUS TO DOWN
                if (ChosenElevator.CurrentFloor == 1)                       // IF THE THE ACTUAL FLOOR OF USER IS EQUAL TO ELEVATOR FLOOR STOP LOOPING
                {
                    ChosenElevator.CurrentFloor = 0;
                }
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
        // CALLED IN FUNCTION START
        public void RequestElevator(int UserActualFloor)
        {
            ChosenElevator.ElevatorQueue.Add(UserActualFloor);      //  ADD FLOOR OF USER TO THE QUEUE OF ELEVATOR
            if (UserActualFloor > ChosenElevator.CurrentFloor)      // IF USER FLOOR BIGGER THAN CURRENT FLOOR OF ELEVATOR DO THIS..
            {
                ChosenElevator.IsDoorsClose = true;                 // SET DOOR TO CLOSE
                ChosenElevator.IsDirectionUp = true;                // SET DIRECTION TO UP
                MoveUp(UserActualFloor);                            // START FUNCTION MOVE UP
            }
            else if (UserActualFloor < ChosenElevator.CurrentFloor) // IF USER FLOOR SMALLER THAN CURRENT FLOOR OF ELEVATOR 
            {
                ChosenElevator.IsDoorsClose = true;                 // SET DOOR TO CLOSE
                ChosenElevator.IsDirectionUp = false;               // SET DIRECTION TO DOWN
                MoveDown(UserActualFloor);                          // START FUNCTION MOVE DOWN
            }
        }

        //This method will be used for the requests made on the first floor.
        // CALLED IN FUNCTION START
        public void AssignElevator(int UserDestination)
        {
            ChosenElevator.DestinationList.Add(UserDestination);        //  ADD FLOOR OF USER TO THE QUEUE OF ELEVATOR
            if (UserDirection == "Up")                                  // IF USER DIRECTION IS UP DO THIS ..
            {
                ChosenElevator.IsDoorsClose = true;                     // SET DOOR CLOSE
                ChosenElevator.IsDirectionUp = true;                    // SET DIRECTION TO UP
                ElevatorMoveUp(UserDestination);                        // START FUNCTION ELEVATOR MOVE UP
            }
            else if (UserDirection == "Down")                           // IF USER DIRECTION IS DOWN DO THIS ..
            {
                ChosenElevator.IsDoorsClose = true;                     // SET DOOR TO CLOSE
                ChosenElevator.IsDirectionUp = false;                   // SET DIRECTION TO DOWN
                ElevatorMoveDown(UserDestination);                      // START FUNCTION MOVE DOWN
            }
        }
        // SHOW OFF FUNCTION TO DISPLAY OPEN DOORS OR CLOSING DOORS OF ELEVATOR
        // CALLED IN FUNCTION ASSIGN ELEVATOR  AND   REQUEST ELEVATOR
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
            Console.WriteLine("Welcome to Rocket Elevator Co.");
            Console.WriteLine("");
            Best_Elevator(UserActualFloor, UserDirection);
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("The elevator selected is: elevator:" + ChosenElevator.Id);
            Console.WriteLine("---------------------------------------------------");
            // If the user is at the GroundFloor  use AssignElevator function
            // If user is at an other floor use Request Elevator
            RequestElevator(UserActualFloor);
            AssignElevator(UserDestination);
            
        }

       

        
     
    }


} 
