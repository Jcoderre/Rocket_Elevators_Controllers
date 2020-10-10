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

// CallButton ...
type CallButton struct {
	callButtonDirection []int
	callButtonFloor     []int
}

//------------------------------ END CALLBUTTON ------------------------------------ //

// Elevator ...
type Elevator struct {
	id              int
	elevatorQueue   []int
	destinationList []int
	isStatusIdle    bool
	isDirectionUp   string
	isDoorClose     bool
	currentFloor    int
	maxWeight       int
	actualWeight    int
}

func (e *Elevator) changeElevatorValues(_currentFloor int, _isStatusIdle bool, _isDirectionUp string) {
	e.currentFloor = _currentFloor
	e.isStatusIdle = _isStatusIdle
	e.isDirectionUp = _isDirectionUp
}

//------------------------------ END ELEVATOR ------------------------------------ //

// Column ...
type Column struct {
	id               int
	minFloor         int
	maxFloor         int
	floorAmount      int
	isStatusIdle     bool
	elevatorList     []Elevator
	chosenElevator   Elevator
	userDirection    string
	userDestination  int
	userActualFloor  int
	groundFloorLevel int
}

func (c *Column) changeUserValues(_userDirection string, _userActualFloor int, _userDestination int) {
	c.userDirection = _userDirection
	c.userActualFloor = _userActualFloor
	c.userDestination = _userDestination
}

func (c *Column) createElevator(elevatorAmountPerColumn int) {
	for i := 0; i < elevatorAmountPerColumn; i++ {
		c.elevatorList = append(c.elevatorList, Elevator{i + 1, []int{}, []int{}, true, "", true, 1, 2500, 0})
	}
}

// BestElevator ...
// Basically a FOREACH LOOP
func (c *Column) BestElevator(userActualFloor int, UserDirection string) {
	bestScore := 10
	for _, elevator := range c.elevatorList { // For each Elevator in Elevator list loop inside the function
		if UserDirection == "Up" {
			if elevator.isDirectionUp == "Up" && userActualFloor >= elevator.currentFloor {
				if bestScore > 1 {
					c.chosenElevator = elevator
					bestScore = 1
				}
			} else if elevator.isDirectionUp == "Down" {
				if bestScore > 7 {
					c.chosenElevator = elevator
					bestScore = 8
				}
			} else if elevator.isStatusIdle == true {
				if bestScore > 1 {
					c.chosenElevator = elevator
					bestScore = 2
				}
			}
		} else if UserDirection == "Down" {
			if elevator.isDirectionUp == "Up" {
				if bestScore > 8 {
					c.chosenElevator = elevator
					bestScore = 8
				}
			} else if elevator.isDirectionUp == "Down" && userActualFloor <= elevator.currentFloor {
				if bestScore > 1 {
					c.chosenElevator = elevator
					bestScore = 1
				}
			} else if elevator.isStatusIdle == true {
				if bestScore > 1 {
					c.chosenElevator = elevator
					bestScore = 2
				}
			}
		}
	}
}

//Basically a WHILE LOOP
func (c *Column) moveUp(userActualFloor int) {
	for c.userActualFloor > c.chosenElevator.currentFloor {
		c.chosenElevator.currentFloor++
		c.chosenElevator.isStatusIdle = false
		c.chosenElevator.isDirectionUp = "Up"
		fmt.Println("The elevator is at floor: ", c.chosenElevator.currentFloor)
		if c.userActualFloor == c.chosenElevator.currentFloor {
			fmt.Println("----------------------")
			fmt.Println("Arrived at destination")
			fmt.Println("")
			fmt.Println("Open Door")
			DoorOpening()
			fmt.Println("Close Door")
			DoorClosing()
		}
	}
}

func (c *Column) moveDown(userActualFloor int) {
	for c.userActualFloor < c.chosenElevator.currentFloor {
		c.chosenElevator.currentFloor--
		c.chosenElevator.isStatusIdle = false
		c.chosenElevator.isDirectionUp = "Down"
		fmt.Println("The elevator is at floor: ", c.chosenElevator.currentFloor)
		if c.userActualFloor == c.chosenElevator.currentFloor {
			fmt.Println("----------------------")
			fmt.Println("Arrived at destination")
			fmt.Println("")
			fmt.Println("Open Door")
			DoorOpening()
			fmt.Println("Close Door")
			DoorClosing()
		}
	}
}

func (c *Column) elevatorMoveUp(userDestination int) {
	for c.userDestination > c.chosenElevator.currentFloor {
		c.chosenElevator.currentFloor++
		c.chosenElevator.isStatusIdle = false
		c.chosenElevator.isDirectionUp = "Up"
		fmt.Println("The elevator is at floor: ", c.chosenElevator.currentFloor)
		if c.userDestination == c.chosenElevator.currentFloor {
			fmt.Println("----------------------")
			fmt.Println("Arrived at destination")
			fmt.Println("")
			fmt.Println("Open Door")
			DoorOpening()
			fmt.Println("Close Door")
			DoorClosing()
		}
	}
}

func (c *Column) elevatorMoveDown(UserDestination int) {
	for c.userDestination < c.chosenElevator.currentFloor {
		c.chosenElevator.currentFloor--
		c.chosenElevator.isStatusIdle = false
		c.chosenElevator.isDirectionUp = "Down"
		fmt.Println("The elevator is at floor: ", c.chosenElevator.currentFloor)
		if c.userDestination == c.chosenElevator.currentFloor {
			fmt.Println("----------------------")
			fmt.Println("Arrived at destination")
			fmt.Println("")
			fmt.Println("Open Door")
			DoorOpening()
			fmt.Println("Close Door")
			DoorClosing()
		}
	}
}

func (c *Column) requestElevator(userActualFloor int) {
	c.chosenElevator.elevatorQueue = append(c.chosenElevator.elevatorQueue, userActualFloor)
	if c.userActualFloor > c.chosenElevator.currentFloor {
		c.chosenElevator.isDoorClose = true
		c.chosenElevator.isDirectionUp = "Up"
		c.moveUp(userActualFloor)
	} else if c.userActualFloor < c.chosenElevator.currentFloor {
		c.chosenElevator.isDoorClose = true
		c.chosenElevator.isDirectionUp = "Down"
		c.moveDown(userActualFloor)
	}
}

func (c *Column) assignElevator(userDestination int) {
	c.chosenElevator.destinationList = append(c.chosenElevator.destinationList, userDestination)
	if c.userDestination > c.groundFloorLevel {
		c.chosenElevator.isDoorClose = true
		c.chosenElevator.isDirectionUp = "Up"
		c.elevatorMoveUp(userDestination)
	} else if c.userDestination < c.groundFloorLevel {
		c.chosenElevator.isDoorClose = true
		c.chosenElevator.isDirectionUp = "Down"
		c.elevatorMoveDown(userDestination)
	}
}

//------------------------------ END COLUMN ------------------------------------ //

// Battery ...
// TYPE of the object Battery
type Battery struct {
	minFloor       int
	maxFloor       int
	floorAmount    int
	callButtonList []CallButton
	columnList     []Column
}

func (b *Battery) createBattery(amountOfColumn int, minFloor int, maxFloor int) {
	for i := 0; i < amountOfColumn+1; i++ {
		b.columnList = append(b.columnList, Column{i + 1, -6, 59, 66, true, []Elevator{}, Elevator{}, "", 0, 0, 0})
		b.columnList[i].createElevator(5)
	}
}

// DoorClosing ...
func DoorClosing() {

	fmt.Println("")
	fmt.Println("_____  _____")
	fmt.Println("|<--|  |-->|")
	fmt.Println("|<--|  |-->|")
	fmt.Println("|<--|  |-->|")
	fmt.Println("|<--|  |-->|")
	fmt.Println("|<--|  |-->|")
	fmt.Println("|<--|  |-->|")
	fmt.Println("|<--|  |-->|")
	fmt.Println("|___|  |___|")
	fmt.Println("")
}

// DoorOpening ...
func DoorOpening() {

	fmt.Println("")
	fmt.Println("_____  _____")
	fmt.Println("|-->|  |<--|")
	fmt.Println("|-->|  |<--|")
	fmt.Println("|-->|  |<--|")
	fmt.Println("|-->|  |<--|")
	fmt.Println("|-->|  |<--|")
	fmt.Println("|-->|  |<--|")
	fmt.Println("|-->|  |<--|")
	fmt.Println("|___|  |___|")
	fmt.Println("")
}

// Start ...
func (c *Column) Start() {
	fmt.Println("")
	fmt.Println("Welcome to Rocket Elevator Co.")
	fmt.Println("")
	c.BestElevator(c.userActualFloor, c.userDirection)
	fmt.Println("---------------------------------------------------")
	fmt.Println("The elevator selected is: elevator:", c.chosenElevator.id)
	fmt.Println("---------------------------------------------------")
	// If the user is at the GroundFloor  use AssignElevator function
	// If user is at an other
	if c.userActualFloor == 1 && c.chosenElevator.currentFloor == 1 {
		c.assignElevator(c.userDestination)
	} else {
		c.requestElevator(c.userActualFloor)
	}

}

func main() {
	battery := Battery{-6, 59, 66, []CallButton{}, []Column{}}
	battery.createBattery(4, -6, 59)

	//###################### SECTION SCENARIO PICK THE ONE OF YOUR CHOICE ###################
	//################################### SEQUENCE 1 ########################################

	fmt.Println("")
	fmt.Println("")
	fmt.Println("---------------------------------------------------")
	fmt.Println("------------------ SEQUENCE 1 ---------------------")
	fmt.Println("---------------------------------------------------")
	fmt.Println("")
	battery.columnList[1].elevatorList[0].changeElevatorValues(20, false, "Down")
	//--
	battery.columnList[1].elevatorList[1].changeElevatorValues(3, false, "Up")
	//--
	battery.columnList[1].elevatorList[2].changeElevatorValues(13, false, "Down")
	//--
	battery.columnList[1].elevatorList[3].changeElevatorValues(15, false, "Down")
	//--
	battery.columnList[1].elevatorList[4].changeElevatorValues(6, false, "Down")
	//--
	battery.columnList[1].changeUserValues("Up", 1, 20)
	battery.columnList[1].Start()

	//################################### SEQUENCE 2 ########################################

	fmt.Println("")
	fmt.Println("")
	fmt.Println("---------------------------------------------------")
	fmt.Println("------------------ SEQUENCE 2 ---------------------")
	fmt.Println("---------------------------------------------------")
	fmt.Println("")
	battery.columnList[2].elevatorList[0].changeElevatorValues(1, true, "")
	//--
	battery.columnList[2].elevatorList[1].changeElevatorValues(23, false, "Up")
	//--
	battery.columnList[2].elevatorList[2].changeElevatorValues(33, false, "Down")
	//--
	battery.columnList[2].elevatorList[3].changeElevatorValues(40, false, "Down")
	//--
	battery.columnList[2].elevatorList[4].changeElevatorValues(39, false, "Down")
	//--
	battery.columnList[2].changeUserValues("Up", 1, 36)
	battery.columnList[2].Start()

	//################################### SEQUENCE 3 ########################################

	fmt.Println("")
	fmt.Println("")
	fmt.Println("---------------------------------------------------")
	fmt.Println("------------------ SEQUENCE 3 ---------------------")
	fmt.Println("---------------------------------------------------")
	fmt.Println("")
	battery.columnList[3].elevatorList[0].changeElevatorValues(58, false, "Down")
	//--
	battery.columnList[3].elevatorList[1].changeElevatorValues(50, false, "Up")
	//--
	battery.columnList[3].elevatorList[2].changeElevatorValues(46, false, "Up")
	//--
	battery.columnList[3].elevatorList[3].changeElevatorValues(1, false, "Up")
	//--
	battery.columnList[3].elevatorList[4].changeElevatorValues(60, false, "Down")
	//--
	battery.columnList[3].changeUserValues("Down", 54, 1)
	battery.columnList[3].Start()

	//################################### SEQUENCE 4 ########################################

	fmt.Println("")
	fmt.Println("")
	fmt.Println("---------------------------------------------------")
	fmt.Println("------------------ SEQUENCE 4 ---------------------")
	fmt.Println("---------------------------------------------------")
	fmt.Println("")
	battery.columnList[0].elevatorList[0].changeElevatorValues(-4, true, "")
	//--
	battery.columnList[0].elevatorList[1].changeElevatorValues(1, true, "")
	//--
	battery.columnList[0].elevatorList[2].changeElevatorValues(-3, false, "Down")
	//--
	battery.columnList[0].elevatorList[3].changeElevatorValues(-6, false, "Up")
	//--
	battery.columnList[0].elevatorList[4].changeElevatorValues(-1, false, "Down")
	//--
	battery.columnList[0].changeUserValues("Up", -3, 1)
	battery.columnList[0].Start()

}
