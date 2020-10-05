using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Corporate_Controller_CSharp
{
    class Battery
    {
        public List<Callbutton> CallButtonList;
        public List<int> ReceptionCallButton;
        public List<Column> ColumnList;
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

            // Creating the Number of Column Needed for the building
            // The Column generate in this case Five elevator each of them create in the column section 
            for (int i = 1; i < amountOfColumn + 1; i++)
            {
                ColumnList.Add(new Column(i + 1, -6 , 59, 5));
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

            for (int y = minFloor; y < maxFloor + 1; y++) 
            {
                ReceptionCallButton.Add("b");
                Console.WriteLine(ReceptionCallButton.Count);
            }



        }
    }
}
