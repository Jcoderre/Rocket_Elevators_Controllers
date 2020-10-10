/******************************************************************|
* This Algorithm code is about the Commercial elevator controllers.|
*                                                                  |
*                       --MODERN STYLE--                           |
* _________________________________________________________________|
*           it is based on the fact that we have :                 |
*                                                                  |
*                   -4 column of 3 elevators,                      |
*                  - 60 floors                                     |
*                  - 6 basements                                   |
*__________________________________________________________________|
*           The facts that those object can be moved :             |
*                                                                  |
*                   -Column,                                       |
*                   -Elevator,                                     |
*                   -Call Button(Outside the elevator),            |
*                   -Doors(Elevator Doors),                        |
*                   -Elevator Button(inside the elevator),         |
*                   -Battery ,                                     |
*                   -Floor Display                                 |
*_________________________________________________________________ |
*       Button that can be found outside the elevator :            |
*                                                                  |
*                     -Modern Terminal                             |
*_________________________________________________________________ |
*                                                                  |
*               Algorithm written By : J.Coderre                   |
*               Date of creation : 2020 - 10 - 06                  |
*                                                                  |
******************************************************************/ 

using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading;

namespace Corporate_Controller_CSharp
{
 
    class Program
    {
        static void Main(string[] args)
        {
            Battery battery = new Battery(4, -6, 59); 

        }


    }
}

//###########################################################
//####### SELECT YOUR SEQUENCE IN THE BATTERY SECTION #######
//###########################################################
