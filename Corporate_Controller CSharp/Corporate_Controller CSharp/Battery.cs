using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corporate_Controller_CSharp
{
    public class Battery
    {
        public List<Callbutton> CallButtonList;
        public List<int> ReceptionCallButton;
        public List<Column> ColumnList;
        public List<int> FloorList;
        public int MinFloor;
        public int MaxFloor;
        public int FloorAmount;

        public Battery(int amountOfColumn,int  minFloor , int maxFloor)
        {
            ColumnList = new List<Column>();
            MinFloor = minFloor;
            MaxFloor = maxFloor;
            FloorAmount = (maxFloor + 1) - minFloor;
            CallButtonList = new List<Callbutton>();
            ReceptionCallButton = new List<int>();
            FloorList = new List<int>();

            // Creating the Number of Column Needed for the building
            // The Column generate in this case Five elevator each of them create in the column section 
            for (int i = 1; i < amountOfColumn + 1; i++)
            {
                var column = new Column(i , -6, 59, 5);
                ColumnList.Add(column);
                Console.WriteLine(ColumnList);
                Console.WriteLine(column.Id);
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
                    var NewcallbuttonUp = "Up" + j;
                    CallButtonList.Add(new Callbutton());
                }

                if (j > 0)
                {
                    var NewCallButtonDown = "Down" + j;
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
                Console.WriteLine(FloorList.Count);
            }

            
        }
       
    }
}
