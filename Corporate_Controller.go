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
	isDoorClose     bool
	currentFloor 	int
	maxWeight 		int
	actualWeight 	int

}

func (e *Elevatpr) changeElevatorValues(_currentFloor int, _isStatusIdle bool, _isDirectionUp bool){
	e.currentFloor = _currentFloor
	e.isStatusIdle = _isStatusIdle
	e.isDirectionUp = _isDirectionUp


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
func (c *Column) moveUp(userActualFloor) {
	for  c.userActualFloor > c.chosenElevator.currentFloor {
		c.chosenElevator.currentFloor++
		c.chosenElevator.isStatusIdle = false
		c.chosenElevator.isDirectionUp = true
		//fmt.Println("The elevator is at floor: " + c.chosenElevator.currentFloor)
		if c.userActualFloor ==  c.chosenElevator.currentFloor {
			fmt.Println("----------------------")
			fmt.Println("Arrived at destination")
			fmt.Println("")
			fmt.Println("Open Door")
			DoorOpening();
			fmt.Println("Close Door")
		}
	}

}

func (c *Column) moveDown(userActualFloor) {
	for  c.userActualFloor > c.chosenElevator.currentFloor {
		c.chosenElevator.currentFloor--
		c.chosenElevator.isStatusIdle = false
		c.chosenElevator.isDirectionUp = false
		//fmt.Println("The elevator is at floor: " + chosenElevator.currentFloor)
		if c.userActualFloor ==  c.chosenElevator.currentFloor {
			fmt.Println("----------------------")
			fmt.Println("Arrived at destination")  
			fmt.Println("")
			fmt.Println("Open Door")
			DoorOpening();
			fmt.Println("Close Door")
		}
	}

}

func (c *Column) elevatorMoveUp(userDestination) {
	for  c.userDestination > c.chosenElevator.currentFloor {
		c.chosenElevator.currentFloor++
		c.chosenElevator.isStatusIdle = false
		c.chosenElevator.isDirectionUp = true
		//fmt.Println("The elevator is at floor: " + c.chosenElevator.currentFloor)
		if c.userDestination ==  c.chosenElevator.currentFloor {
			fmt.Println("----------------------")
			fmt.Println("Arrived at destination")
			fmt.Println("")
			fmt.Println("Open Door")
			DoorOpening();
			fmt.Println("Close Door")
		}
	}

}

func (c *Column) elevatorMoveDown(UserDestination) {
	for  c.userDestination > c.chosenElevator.currentFloor {
		c.chosenElevator.currentFloor--
		c.chosenElevator.isStatusIdle = false
		c.chosenElevator.isDirectionUp = false
		//fmt.Println("The elevator is at floor: " + chosenElevator.currentFloor)
		if c.userDestination ==  c.chosenElevator.currentFloor {
			fmt.Println("----------------------")
			fmt.Println("Arrived at destination")  
			fmt.Println("")
			fmt.Println("Open Door")
			DoorOpening();
			fmt.Println("Close Door")
		}
	}

}

func (c *Column) requestElevator(userActualFloor) {
	c.chosenElevator.elevatorQueue = append(UserActualFloor)
	if c.userActualFloor > c.chosenElevator.currentFloor {
		c.chosenElevator.isDoorClose = true
		c.chosenElevator.isDirectionUp = true
		moveUp(UserActualFloor)
	} else if c.userActualFloor < c.chosenElevator.currentFloor {
		c.chosenElevator.isDoorClose = true
		c.chosenElevator.isDirectionUp = true
		elevatorMoveUp(userDestination)
	}
}

func (c *Column) assignElevator(userDestination) {
	c.chosenElevator.destinationList = append(userDestination)
	if c.userDestination > c.groundFloorLevel {
		c.chosenElevator.isDoorClose = true
		c.chosenElevator.isDirectionUp = true
		moveUp(UserActualFloor)
	} else if c.userDestination < c.groundFloorLevel {
		c.chosenElevator.isDoorClose = true
		c.chosenElevator.isDirectionUp = true
		elevatorMoveDown(UserDestination)
	}
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

func (b *Battery) createColumn(amountOfColumn int){
	for i := 0; i < amountOfColumn +1 ; i++ {
		b.columnList = append(b.columnList, Column{i+1, -6, 59, 66, true, []Elevator{}})
	}
}
/*
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

// Print Display of Door Closing
func  DoorClosing(){
        
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

// Print Display of Door Opening 
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

func start() {

}

/*
func sequence1() {
	fmt.Println("");
	fmt.Println("");
	fmt.Println("---------------------------------------------------");
	fmt.Println("------------------ SEQUENCE 1 ---------------------");
	fmt.Println("---------------------------------------------------");
	fmt.Println("");
	b.columnList[1].elevatorList[0].changeElevatorValues(20, false, false)
	//--
	b.columnList[1].elevatorList[1].changeElevatorValues(3, false, true)
	//--
	b.columnList[1].ElevatorList[2].changeElevatorValues(13, false, false)
	//--
	b.columnList[1].ElevatorList[3].changeElevatorValues(15, false, false)
	//--
	b.columnList[1].ElevatorList[4].changeElevatorValues(6, false, false)
	//--
	b.columnList[1].UserDirection = "Up";
	b.columnList[1].UserActualFloor = 1;
	b.columnList[1].UserDestination = 20;
	start()
}

func sequence2() {
	fmt.Println("");
	fmt.Println("");
	fmt.Println("---------------------------------------------------");
	fmt.Println("------------------ SEQUENCE 2 ---------------------");
	fmt.Println("---------------------------------------------------");
	fmt.Println("");
	b.columnList[2].ElevatorList[0].changeElevatorValues(1, true, null)
	//--
	b.columnList[2].ElevatorList[1].changeElevatorValues(23, false, true)
	//--
	b.columnList[2].ElevatorList[2].changeElevatorValues(33, false, false)
	//--
	b.columnList[2].ElevatorList[3].changeElevatorValues(40, false, false)
	//--
	b.columnList[2].ElevatorList[4].changeElevatorValues(39, false, false)
	//--
	b.columnList[2].UserActualFloor = 1;
	b.columnList[2].UserDestination = 36;
	b.columnList[2].UserDirection = "Up";
	start()
}

func sequence3() {
	fmt.Println("");
	fmt.Println("");
	fmt.Println("---------------------------------------------------");
	fmt.Println("------------------ SEQUENCE 3 ---------------------");
	fmt.Println("---------------------------------------------------");
	fmt.Println("");
	b.columnList[3].ElevatorList[0].changeElevatorValues(58, false, false)
	//--
	b.columnList[3].ElevatorList[1].changeElevatorValues(50, false, true)
	//--
	b.columnList[3].ElevatorList[2].changeElevatorValues(46, false, true)
	//--
	b.columnList[3].ElevatorList[3].changeElevatorValues(1, false, true)
	//--
	b.columnList[3].ElevatorList[4].changeElevatorValues(60, false, false)
	//--
	b.columnList[3].UserActualFloor = 54;
	b.columnList[3].UserDestination = 1;
	b.columnList[3].UserDirection = "Down";
	start()
}

func sequence4() {
	fmt.Println("");
	fmt.Println("");
	fmt.Println("---------------------------------------------------");
	fmt.Println("------------------ SEQUENCE 4 ---------------------");
	fmt.Println("---------------------------------------------------");
	fmt.Println("");
	b.columnList[0].ElevatorList[0].changeElevatorValues(-4, true, null)
	//--
	b.columnList[0].ElevatorList[1].changeElevatorValues(1, true, null)
	//--
	b.columnList[0].ElevatorList[2].changeElevatorValues(-3, false, false)
	//--
	b.columnList[0].ElevatorList[3].changeElevatorValues(-6, false, true)
	//--
	b.columnList[0].ElevatorList[4].changeElevatorValues(-1, false, false) 
	//--
	b.columnList[0].UserActualFloor = -3;
	b.columnList[0].UserDestination = 1;
	b.columnList[0].UserDirection = "Up";
	start()
}
*/


func main() {
	fmt.Println("Hello World")

	//sequence1()
	//sequence2()
	//sequence3()
	//sequence4()
}