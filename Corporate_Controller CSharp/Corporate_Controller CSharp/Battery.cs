using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corporate_Controller_CSharp
{
    public class Battery 
    {
        public List<Callbutton> CallButtonList = new List<Callbutton>();
        public List<int> ReceptionCallButton = new List<int>();
        public static List<Column> ColumnList = new List<Column>();
        public List<int> FloorList = new List<int>();
        public int MinFloor;
        public int MaxFloor;
        public int FloorAmount;

        public Battery(int amountOfColumn,int  minFloor , int maxFloor)
        {
            MinFloor = minFloor;
            MaxFloor = maxFloor;
            FloorAmount = (maxFloor + 1) - minFloor;

            // Creating the Number of Column Needed for the building
            // The Column generate in this case Five elevator each of them create in the column section 
            for (int i = 1; i < amountOfColumn + 1; i++)
            {
                Column column = new Column(i , -6, 59, 5);
                ColumnList.Add(column);
                Console.WriteLine(ColumnList);
            }

            // Creating a series of CallButton for each floor
            // A "Up" Button for each floor under 0
            // A "Down" button for each floor higher than 0
            // No button are created for Ground Floor AKA = 0 because of the console
            // This call buttonList is create in the battery section because We only need 1 button by floor
            for (int j = -6; j < FloorAmount; j++)
            {
                if (j < 0)
                {
                    //var NewcallbuttonUp = "Up" + j;
                    CallButtonList.Add(new Callbutton());
                }

                if (j > 0)
                {
                    //var NewCallButtonDown = "Down" + j;
                    CallButtonList.Add(new Callbutton());
                }

            }

            // Creating a series of button for the Reception 1 For each floor
            // Create a List of floor from 1 to 66

            for (int y = minFloor; y < maxFloor + 1; y++) 
            {
                ReceptionCallButton.Add(y);
            }

            // Creating a list of Floor deserved by the building in a For Loop

            for (int y = minFloor; y < maxFloor + 1; y++)
            {
                FloorList.Add(y);
            }
            ////---------------- SELECT YOUR SEQUENCE -----------------//
            //sequence1();
            //sequence2();
            //sequence3();
            sequence4();
            //---------------------------------------------------------//
        }

        public void sequence1()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("------------------ SEQUENCE 1 ---------------------");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("");
            ColumnList[1].ElevatorList[0].CurrentFloor = 20;
            ColumnList[1].ElevatorList[0].IsStatusIdle = false;
            ColumnList[1].ElevatorList[0].IsDirectionUp = false;
            //--
            ColumnList[1].ElevatorList[1].CurrentFloor = 3;
            ColumnList[1].ElevatorList[1].IsStatusIdle = false;
            ColumnList[1].ElevatorList[1].IsDirectionUp = true;
            //--
            ColumnList[1].ElevatorList[2].CurrentFloor = 13;
            ColumnList[1].ElevatorList[2].IsStatusIdle = false;
            ColumnList[1].ElevatorList[2].IsDirectionUp = false;
            //--
            ColumnList[1].ElevatorList[3].CurrentFloor = 15;
            ColumnList[1].ElevatorList[3].IsStatusIdle = false;
            ColumnList[1].ElevatorList[3].IsDirectionUp = false;
            //--
            ColumnList[1].ElevatorList[4].CurrentFloor = 6;
            ColumnList[1].ElevatorList[4].IsStatusIdle = false;
            ColumnList[1].ElevatorList[4].IsDirectionUp = false;
            //--
            ColumnList[1].UserDirection = "Up";
            ColumnList[1].UserActualFloor = 1;
            ColumnList[1].UserDestination = 20;
            Console.WriteLine("Elevator A is at floor " + ColumnList[1].ElevatorList[0].CurrentFloor);
            Console.WriteLine("Elevator B is at floor " + ColumnList[1].ElevatorList[1].CurrentFloor);
            Console.WriteLine("Elevator C is at floor " + ColumnList[1].ElevatorList[2].CurrentFloor);
            Console.WriteLine("Elevator D is at floor " + ColumnList[1].ElevatorList[3].CurrentFloor);
            Console.WriteLine("Elevator E is at floor " + ColumnList[1].ElevatorList[4].CurrentFloor);
            ColumnList[1].Start();
        }

        public void sequence2()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("------------------ SEQUENCE 2 ---------------------");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("");
            ColumnList[2].ElevatorList[0].CurrentFloor = 1;
            ColumnList[2].ElevatorList[0].IsStatusIdle = true;
            ColumnList[2].ElevatorList[0].IsDirectionUp = null;
            //--
            ColumnList[2].ElevatorList[1].CurrentFloor = 23;
            ColumnList[2].ElevatorList[1].IsStatusIdle = false;
            ColumnList[2].ElevatorList[1].IsDirectionUp = true;
            //--
            ColumnList[2].ElevatorList[2].CurrentFloor = 33;
            ColumnList[2].ElevatorList[2].IsStatusIdle = false;
            ColumnList[2].ElevatorList[2].IsDirectionUp = false;
            //--
            ColumnList[2].ElevatorList[3].CurrentFloor = 40;
            ColumnList[2].ElevatorList[3].IsStatusIdle = false;
            ColumnList[2].ElevatorList[3].IsDirectionUp = false;
            //--
            ColumnList[2].ElevatorList[4].CurrentFloor = 39;
            ColumnList[2].ElevatorList[4].IsStatusIdle = false;
            ColumnList[2].ElevatorList[4].IsDirectionUp = false;
            //--
            ColumnList[2].UserActualFloor = 1;
            ColumnList[2].UserDestination = 36;
            ColumnList[2].UserDirection = "Up";
            Console.WriteLine("Elevator A is at floor " + ColumnList[2].ElevatorList[0].CurrentFloor);
            Console.WriteLine("Elevator B is at floor " + ColumnList[2].ElevatorList[1].CurrentFloor);
            Console.WriteLine("Elevator C is at floor " + ColumnList[2].ElevatorList[2].CurrentFloor);
            Console.WriteLine("Elevator D is at floor " + ColumnList[2].ElevatorList[3].CurrentFloor);
            Console.WriteLine("Elevator E is at floor " + ColumnList[2].ElevatorList[4].CurrentFloor);
            ColumnList[2].Start();
        }

        public void sequence3()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("------------------ SEQUENCE 3 ---------------------");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("");
            ColumnList[3].ElevatorList[0].CurrentFloor = 58;
            ColumnList[3].ElevatorList[0].IsStatusIdle = false;
            ColumnList[3].ElevatorList[0].IsDirectionUp = false;
            //--
            ColumnList[3].ElevatorList[1].CurrentFloor = 50;
            ColumnList[3].ElevatorList[1].IsStatusIdle = false;
            ColumnList[3].ElevatorList[1].IsDirectionUp = true;
            //--
            ColumnList[3].ElevatorList[2].CurrentFloor = 46;
            ColumnList[3].ElevatorList[2].IsStatusIdle = false;
            ColumnList[3].ElevatorList[2].IsDirectionUp = true;
            //--
            ColumnList[3].ElevatorList[3].CurrentFloor = 1;
            ColumnList[3].ElevatorList[3].IsStatusIdle = false;
            ColumnList[3].ElevatorList[3].IsDirectionUp = true;
            //--
            ColumnList[3].ElevatorList[4].CurrentFloor = 60;
            ColumnList[3].ElevatorList[4].IsStatusIdle = false;
            ColumnList[3].ElevatorList[4].IsDirectionUp = false;
            //--
            ColumnList[3].UserActualFloor = 54;
            ColumnList[3].UserDestination = 1;
            ColumnList[3].UserDirection = "Down";
            Console.WriteLine("Elevator A is at floor " + ColumnList[3].ElevatorList[0].CurrentFloor);
            Console.WriteLine("Elevator B is at floor " + ColumnList[3].ElevatorList[1].CurrentFloor);
            Console.WriteLine("Elevator C is at floor " + ColumnList[3].ElevatorList[2].CurrentFloor);
            Console.WriteLine("Elevator D is at floor " + ColumnList[3].ElevatorList[3].CurrentFloor);
            Console.WriteLine("Elevator E is at floor " + ColumnList[3].ElevatorList[4].CurrentFloor);
            ColumnList[3].Start();
        }

        public void sequence4()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("------------------ SEQUENCE 4 ---------------------");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("");
            ColumnList[0].ElevatorList[0].CurrentFloor = -4;
            ColumnList[0].ElevatorList[0].IsStatusIdle = true;
            ColumnList[0].ElevatorList[0].IsDirectionUp = null;
            //--
            ColumnList[0].ElevatorList[1].CurrentFloor = 1;
            ColumnList[0].ElevatorList[1].IsStatusIdle = true;
            ColumnList[0].ElevatorList[1].IsDirectionUp = null;
            //--
            ColumnList[0].ElevatorList[2].CurrentFloor = -3;
            ColumnList[0].ElevatorList[2].IsStatusIdle = false;
            ColumnList[0].ElevatorList[2].IsDirectionUp = false;
            //--
            ColumnList[0].ElevatorList[3].CurrentFloor = -6;
            ColumnList[0].ElevatorList[3].IsStatusIdle = false;
            ColumnList[0].ElevatorList[3].IsDirectionUp = true;
            //--
            ColumnList[0].ElevatorList[4].CurrentFloor = -1;
            ColumnList[0].ElevatorList[4].IsStatusIdle = false;
            ColumnList[0].ElevatorList[4].IsDirectionUp = false;
            //--
            ColumnList[0].UserActualFloor = -3;
            ColumnList[0].UserDestination = 1;
            ColumnList[0].UserDirection = "Up";
            Console.WriteLine("Elevator A is at floor " + ColumnList[0].ElevatorList[0].CurrentFloor);
            Console.WriteLine("Elevator B is at floor " + ColumnList[0].ElevatorList[1].CurrentFloor);
            Console.WriteLine("Elevator C is at floor " + ColumnList[0].ElevatorList[2].CurrentFloor);
            Console.WriteLine("Elevator D is at floor " + ColumnList[0].ElevatorList[3].CurrentFloor);
            Console.WriteLine("Elevator E is at floor " + ColumnList[0].ElevatorList[4].CurrentFloor);
            ColumnList[0].Start();
        }

    }  



}
