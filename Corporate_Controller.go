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

//##############################################################
//######### CORPORATE CONTROLLER GOLANG VERSION ################
//##############################################################

package main

import (
	"fmt"
)

//------------------------------ CALLBUTTON ------------------------------------ //
// TYPE of the object CallButton
type CallButton struct {
	callButtonDirection []int
	callButtonFloor 	[]int
}

//------------------------------ END CALLBUTTON ------------------------------------ //

//------------------------------ ELEVATOR ------------------------------------ //
// TYPE of the object Elevator
type Elevator struct {
	id 				int
	elevatorQueue 	[]int
	destinationList []int
	isStatusIdle    bool 
	isDirectionUp   bool
	currentFloor 	int
	maxWeight 		int
	actualWeight 	int

}

//------------------------------ END ELEVATOR ------------------------------------ //

//------------------------------ COLUMN ------------------------------------ //
// TYPE of the object Column
type Column struct {
	id 			 int
	minFloor	 int
	maxFloor 	 int
	floorAmount  int
	isStatusIdle bool
	elevatorList []Elevator
	chosenElevator Elevator
	userDirection string
	userDestination int
	userActualFloor int
	groundFloorLevel int
}

func (c *Column) createElevator(elevatorAmountPerColumn int){
	for i := 1; i < elevatorAmountPerColumn; i++ {
		c.elevatorList = append(c.elevatorList, Elevator{i+1, []int{}, []int{}, true, true, 1, 2500, 0})
	}
}
/*
// Basically a FOREACH LOOP
func (c *Column) BestElevator(userActualFloor int, UserDirection string) {
	bestScore := 10
	for Elevator, elevator := range c.elevatorList {	// For each Elevator in Elevator list loop inside the function
		if UserDirection == "Up" {
			if Elevator.isDirectionUp == true && userActualFloor >= Elevator.currentFloor {
				if bestScore > 1 {
					chosenElevator := elevator
					bestScore = 1
				}			
			} else if Elevator.isDirectionUp == false {
				if bestScore > 8 {
					chosenElevator := elevator
					bestScore = 8
				}
			} else if Elevator.isStatusIdle == true {
				if bestScore > 1 {
					chosenElevator := elevator
					bestScore = 2
				}
			}
		} else if UserDirection == "Down" {
			if Elevator.isDirectionUp == true{
				if bestScore > 8 {
					chosenElevator := elevator
					bestScore = 8
				}			
			} else if Elevator.isDirectionUp == false && userActualFloor >= Elevator.currentFloor{
				if bestScore > 1 {
					chosenElevator := elevator
					bestScore = 1
				}
			} else if Elevator.isStatusIdle == true {
				if bestScore > 1 {
					chosenElevator := elevator
					bestScore = 2
				}
			}
		}
	}
}
*/
//Basically a WHILE LOOP
func (c *Column) moveUp(){
	for  c.userActualFloor > c.chosenElevator.currentFloor {
		c.chosenElevator.currentFloor += 1
		c.chosenElevator.isStatusIdle = false
		c.chosenElevator.isDirectionUp = true
		//fmt.Println("The elevator is at floor: " + c.chosenElevator.currentFloor)
	}
	fmt.Println("----------------------")
	fmt.Println("Arrived at destination")
	fmt.Println("")
	fmt.Println("Open Door")
	DoorOpening();
	fmt.Println("Close Door")
}

func (c *Column) moveDown(){
	for  c.userActualFloor > c.chosenElevator.currentFloor {
		c.chosenElevator.currentFloor -= 1
		c.chosenElevator.isStatusIdle = false
		c.chosenElevator.isDirectionUp = false
		//fmt.Println("The elevator is at floor: " + c.chosenElevator.currentFloor)
	}
	fmt.Println("----------------------")
	fmt.Println("Arrived at destination")  
	fmt.Println("")
	fmt.Println("Open Door")
	DoorOpening();
	fmt.Println("Close Door")
}


//------------------------------ END COLUMN ------------------------------------ //

//------------------------------ Battery ------------------------------------ //
// TYPE of the object Battery
type Battery struct {
	minFloor 			int
	maxFloor 			int
	floorAmount 		int
	callButtonList  	[]CallButton
	columnList 			[]Column
	floorList 			[]int
	receptionCallbutton []int

	
}
/*
func (b *Battery) createColumn(amountOfColumn int){
	for i := 0; i < amountOfColumn +1 ; i++ {
		b.columnList = append(b.columnList, Column{i+1, -6, 59, 66, true, []Elevator{}})
	}
}

func (b *Battery) createCallbutton(){
	for j := -6; j < b.floorAmount; j++ {
		if j > 0 {
			callButtonList := append(CallButton)
		}
		if j < 0 {
			callButtonList := append(CallButton)
		} 
	}
}
*/
//------------------------------ END Battery ------------------------------------ //


func  DoorClosing() {
        
fmt.Println("");
fmt.Println("_____  _____");
fmt.Println("|<--|  |-->|");
fmt.Println("|<--|  |-->|");
fmt.Println("|<--|  |-->|");
fmt.Println("|<--|  |-->|");
fmt.Println("|<--|  |-->|");
fmt.Println("|<--|  |-->|");
fmt.Println("|<--|  |-->|");
fmt.Println("|___|  |___|");
fmt.Println("");
}

func DoorOpening() {
		
fmt.Println("");
fmt.Println("_____  _____");
fmt.Println("|-->|  |<--|");
fmt.Println("|-->|  |<--|");
fmt.Println("|-->|  |<--|");
fmt.Println("|-->|  |<--|");
fmt.Println("|-->|  |<--|");
fmt.Println("|-->|  |<--|");
fmt.Println("|-->|  |<--|");
fmt.Println("|___|  |___|");
fmt.Println("");
}


func main() {
	fmt.Println("Hello World")

}