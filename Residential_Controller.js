//##############################################################
//######### RESIDENTIAL CONTROLLER JAVASCRIPT VERSION ##########
//##############################################################

// FIND OUR ACTUAL TIME AND DATE
var now = new Date();

// CREATING A FUNCTION THAT SLOW THE CONSOLE PROCESS
function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}


//########################### CLASS CALL BUTTON ############################
class callButton {
    constructor(User_Actual_Floor, User_Direction) {
        this.Direction = []
        this.Floor = []   
    }
}
//################## END CLASS CALL BUTTON ##################################

//#################### CLASS ELEVATOR #######################################
class Elevator {    
    constructor(id) {
        this.id = id
        this.elevatorQueue = []         // Unordered set of floor request
        this.requestButtonList = []     // Array of Requested Buttons
        this.IsStatusIDLE = true        // Boolean ->  IDLE, Moving 
        this.IsDirectionUp = Boolean       // Boolean ->  Up, Down
        this.IsDoorsClose = true        // Bollean ->  Close or Open
        this.currentFloor = 1           // Actual floor of the elevator          
        this.Maxweight = 2500           // Maximum Weight
        this.ActualWeight = 0           // Actual Weight
        this.User_response = null
        this.User_Destination = null
        this.User_Direction = null
        this.User_Actual_Floor = 0
    }
}
      

//######################### END CLASS ELEVATOR #################################

//########################## Class Column ######################################
class Column {
    constructor (minFloor, maxFloor, Elevator_Amount) {
        this.minFloor = minFloor                            // Minimum amount of floor
        this.maxFloor = maxFloor                            // Maximum amount of floor
        this.Floor_Amount = minFloor - maxFloor             // Calculate the good number of floor
        this.Elevator_Amount = Elevator_Amount              // Number of elevator needed
        this.IsStatusIDLE = true                            // IDLE, Moving
        this.ElevatorList = []                              // An Elevator list        
        this.callButtonsList = []                           // A list of all call button (Up and down) on column
        this.chosenElevator = null                          // The best elevator that will be send to user
        this.User_response = ""
        this.User_Destination = 0
        this.User_Direction = ""
        this.User_Actual_Floor = 0


        //####### FINDING THE GOOD AMOUNT OF ELEVATOR #######
        for (var i = 0; i < this.Elevator_Amount; i++) {
            var elevator = new Elevator(i + 1)
            this.ElevatorList.push(elevator)
        }        
        //##### END FINDING THE GOOD AMOUT OF ELEVATOR ######

        //#### CREATING THE CALLING BUTTON FOR EACH FLOOR ###
            for (var i = this.minFloor; i <= this.maxFloor; i++) {
                if (i != this.maxFloor) {
                    this.NewCallButtonUp = "Up" + i
                    this.callButtonsList.push("NewCallButtonUp")
                }
                if (i > this.minFloor) {
                    this.NewCallButtonDown = "Down" + i
                    this.callButtonsList.push("NewCallButtonDown")
                }    
            }
         //############## END CREATING CALLING BUTTON ########
    }
    //############## FIND THE BEST ELEVATOR #############
    Best_Elevator(User_Actual_Floor , User_Direction, find_Closest_Elevator) {
        var bestScore = 10
        for (var elevator of this.ElevatorList) {
            if (User_Direction == "Up") {
                if (elevator.IsDirectionUp == true && User_Actual_Floor >= elevator.currentFloor) {
                    if (bestScore > 1) {
                        this.chosenElevator = elevator
                        bestScore = 1
                    }                                
                } else if (elevator.IsDirectionUp == false) {
                    if (bestScore > 8) {
                        this.chosenElevator = elevator
                        bestScore = 8
                    }
                } else if  (elevator.IsStatusIDLE == true) {
                    if (find_Closest_Elevator == column1.ElevatorList[0].currentFloor) {
                        if (bestScore > 2) {
                            this.chosenElevator = elevator
                            bestScore = 2
                        }
                    } else if (find_Closest_Elevator == column1.ElevatorList[1].currentFloor) {
                        if (bestScore > 2) {
                            this.chosenElevator = elevator
                            bestScore = 1 
                        }     
                    }            
                }                
            }                         
            if (User_Direction == "Down") {
                if (elevator.IsDirectionUp == false) {                   
                    if (bestScore > 8) {
                        this.chosenElevator = elevator
                        bestScore = 8
                    }    
                } else if (elevator.IsDirectionUp == true && User_Actual_Floor <= elevator.currentFloor) {
                    if (bestScore > 1) {
                        this.chosenElevator = elevator
                        bestScore = 1
                    }    
                } else if (elevator.IsStatusIDLE == true) {
                    if (find_Closest_Elevator == column1.ElevatorList[0].currentFloor) {
                        if (bestScore > 2) {
                            this.chosenElevator = elevator
                            bestScore = 2
                        }    
                    } else if (find_Closest_Elevator == column1.ElevatorList[1].currentFloor) {
                        if (bestScore > 1) {
                            this.chosenElevator = elevator
                            bestScore = 2
                        }          
                    }            
                }                
            }                    
        }
    }                            
    //############## END FIND THE BEST ELEVATOR #########  
    
    //################### MOVE ##########################
    moveUp(User_Actual_Floor) {
        while (parseInt(User_Actual_Floor) > this.chosenElevator.currentFloor) {
            sleep(400);
            this.chosenElevator.currentFloor += 1
            this.chosenElevator.IsStatusIDLE = false
            console.log("The elevator is at floor " + this.chosenElevator.currentFloor)
            this.chosenElevator.IsDirectionUp = true
            if (parseInt(User_Actual_Floor) == this.chosenElevator.currentFloor) {
                console.log("----------------------")
                console.log("The elevator is here")
                sleep(1000);
                console.log("")
                console.log("Open Door")
                sleep(1000);
                doorOpening()
                console.log("Close Door")            
                doorClosing()
            }    
        }
    }
    moveDown(User_Actual_Floor) {
        while (parseInt(User_Actual_Floor) < this.chosenElevator.currentFloor) {
            this.chosenElevator.currentFloor -= 1
            this.chosenElevator.IsStatusIDLE = false
            console.log("The elevator is at floor " + this.chosenElevator.currentFloor)
            this.chosenElevator.IsDirectionUp = false
            if (parseInt(User_Actual_Floor) == this.chosenElevator.currentFloor) {
                console.log("----------------------")
                console.log("The elevator is here")
                sleep(1000);
                console.log("")
                console.log("Open Door")
                sleep(1000);
                doorOpening()
                console.log("Close Door")
                doorClosing()
            }    
        }            
    }                
    //######################## END MOVE ################
    
    //################## MOVE WHILE INSIDE ################
    moveElevatorUp(User_Destination) {
        while (parseInt(User_Destination) > this.chosenElevator.currentFloor) {
            sleep(400);
            this.chosenElevator.currentFloor += 1
            this.chosenElevator.IsStatusIDLE = false
            console.log("The elevator is at floor " + this.chosenElevator.currentFloor)
            this.chosenElevator.IsDirectionUp = true
            if (parseInt(User_Destination) == this.chosenElevator.currentFloor) {
                console.log("----------------------")
                console.log("Arrived at destination")
                sleep(1000);
                console.log("")
                console.log("Open Door")
                doorOpening()
                console.log("Close Door")
                doorClosing()
            }
        }
    }
    moveElevatorDown(User_Destination) {
        while (parseInt(User_Destination) < this.chosenElevator.currentFloor) {
            sleep(400);
            this.chosenElevator.currentFloor -= 1
            this.chosenElevator.IsStatusIDLE = false
            console.log("The elevator is at floor " + this.chosenElevator.currentFloor)
            this.chosenElevator.IsDirectionUp = true
            if (parseInt(User_Destination) == this.chosenElevator.currentFloor) {
                console.log("----------------------")
                console.log("Arrived at destination")
                sleep(1000);
                console.log("")
                console.log("Open Door")
                doorOpening()
                console.log("Close Door")
                doorClosing()
            }    
        }        
    }

    //################## END WHILE INSIDE #################

    //############# REQUEST ELEVATOR  ##################
    request_Elevator(User_Actual_Floor) {
        this.chosenElevator.elevatorQueue.push(User_Actual_Floor)
        if (parseInt(User_Actual_Floor) > this.chosenElevator.currentFloor) {
            this.chosenElevator.IsDirectionUp = true
            this.moveUp(User_Actual_Floor)
        } else if (parseInt(User_Actual_Floor) < this.chosenElevator.currentFloor) {
            this.chosenElevator.IsDirectionUp = false
            this.moveDown(User_Actual_Floor)
        }
    }        
    //############## END REQUEST ELEVATOR ############### 

    //############## REQUEST FLOOR of ELEVATOR ##########
    request_Floor(User_Direction, User_Destination) {
        this.chosenElevator.requestButtonList.push(User_Destination) 
        if (User_Direction  == 'Up') {
            this.moveElevatorUp(User_Destination)
        } else if (User_Direction == "Down") {
            this.moveElevatorDown(User_Destination) 
        }    
    }        
    //############### END REQUEST FLOOR ##################

} 
//######################## END CLASS COLUMN #######################################

column1 = new Column(1, 10, 2);
var find_Closest_Elevator;

//################ FUNCTION THAT START THE SCENARIO ######################
function start() {
    console.log("Elevator A is at " + column1.ElevatorList[0].currentFloor)
    console.log("Elevator B is at " + column1.ElevatorList[1].currentFloor)
    console.log("")
    actual_Floor_Of_Elevators = [column1.ElevatorList[0].currentFloor, column1.ElevatorList[1].currentFloor]
    //# # For each variable in the array
    //# Find the absolute value of the difference between array values and the user actual floor
    //# If less then our best elevator choice then this variable is choosen
    find_Closest_Elevator = actual_Floor_Of_Elevators.reduce(function(prev, curr) {
    return (Math.abs(curr - column1.User_Actual_Floor) < Math.abs(prev - column1.User_Actual_Floor) ? curr : prev);
    }); 

    column1.Best_Elevator(column1.User_Actual_Floor , column1.User_Direction, find_Closest_Elevator)
    column1.request_Elevator(column1.User_Actual_Floor)
    column1.request_Floor(column1.User_Direction, column1.User_Destination)
}   

//################ END FUNCTION THAT START THE SCENARIO ######################

function doorOpening() {
    console.log("")
    console.log("_____  _____")
    console.log("|<--|  |-->|")
    console.log("|<--|  |-->|")
    console.log("|<--|  |-->|")
    console.log("|<--|  |-->|")
    console.log("|<--|  |-->|")
    console.log("|<--|  |-->|")
    console.log("|<--|  |-->|")
    console.log("|___|  |___|")
    console.log("")
}


function doorClosing() {
    console.log("")
    console.log("_____  _____")
    console.log("|-->|  |<--|")
    console.log("|-->|  |<--|")
    console.log("|-->|  |<--|")
    console.log("|-->|  |<--|")
    console.log("|-->|  |<--|")
    console.log("|-->|  |<--|")
    console.log("|-->|  |<--|")
    console.log("|___|  |___|")
    console.log("")
}


//#####################################################################
//########################### SEQUENCE 1 ##############################
//#####################################################################
function sequence1() {
    console.log("")
    console.log("")
    console.log("---------------------------------------------------")
    console.log("------------------ SEQUENCE 1 ---------------------")
    console.log("---------------------------------------------------")
    console.log("")  
    column1.User_response = "no"
    column1.User_Destination = 7
    column1.User_Direction = "Up"
    column1.User_Actual_Floor = 3
    column1.ElevatorList[0].currentFloor = 2        // ENTER VALUES OF WHERE YOUR ELEVATOR ACTUALLY ARE
    column1.ElevatorList[1].currentFloor = 6
    column1.ElevatorList[1].IsStatusIDLE = true      // OBVIOUS TRUE OR FALSE 
    start()
    column1.Best_Elevator(3 , "Up", find_Closest_Elevator)
    column1.request_Elevator(3)
    column1.request_Floor("Up", 7)
}      
//#####################################################################

//#####################################################################
//########################### SEQUENCE 2 ##############################
//#####################################################################
function sequence2() {
    console.log("")
    console.log("")
    console.log("---------------------------------------------------")
    console.log("------------------ SEQUENCE 2 ---------------------")
    console.log("---------------------------------------------------")
    console.log("")
    column1.User_response = "yes"
    column1.User_Destination = 6
    column1.User_Direction = "Up"
    column1.User_Actual_Floor = 1
    column1.ElevatorList[0].currentFloor = 10        // ENTER VALUES OF WHERE YOUR ELEVATOR ACTUALLY ARE
    column1.ElevatorList[1].currentFloor = 3
    column1.ElevatorList[1].IsStatusIDLE = true      // OBVIOUS TRUE OR FALSE
    start() 
    column1.Best_Elevator(1 , "Up", find_Closest_Elevator)
    column1.request_Elevator(1)
    column1.request_Floor("Up", 6)
    sequence2_2()
    sequence2_3()
}
//#####################################################################

//#####################################################################
//########################## SEQUECE 2.2 ##############################
//#####################################################################
function sequence2_2() {
    console.log("")
    console.log("")
    console.log("---------------------------------------------------")
    console.log("------------------ SEQUENCE 2.2 -------------------")
    console.log("---------------------------------------------------")
    console.log("")
    column1.User_response = "no"
    column1.User_Destination = 5
    column1.User_Direction = "Up"
    column1.User_Actual_Floor = 3
    column1.ElevatorList[0].currentFloor = 10        // ENTER VALUES OF WHERE YOUR ELEVATOR ACTUALLY ARE
    column1.ElevatorList[1].currentFloor = 6
    column1.ElevatorList[1].IsStatusIDLE = true      // OBVIOUS TRUE OR FALSE 
    start()
    column1.Best_Elevator(3 , "Up", find_Closest_Elevator)
    column1.request_Elevator(3)
    column1.request_Floor("Up", 5)
}
//#####################################################################

//#####################################################################
//########################## SEQUECE 2.3 ##############################
//#####################################################################
function sequence2_3() {
    console.log("")
    console.log("")
    console.log("---------------------------------------------------")
    console.log("------------------ SEQUENCE 2.3 -------------------")
    console.log("---------------------------------------------------")
    console.log("")
    column1.User_response = "no"
    column1.User_Destination = 2
    column1.User_Direction = "Down"
    column1.User_Actual_Floor = 9
    column1.ElevatorList[0].currentFloor = 10        // ENTER VALUES OF WHERE YOUR ELEVATOR ACTUALLY ARE
    column1.ElevatorList[1].currentFloor = 5
    column1.ElevatorList[1].IsStatusIDLE = false      // OBVIOUS TRUE OR FALSE
    start()
    column1.Best_Elevator(9 , "Down", find_Closest_Elevator)
    column1.request_Elevator(9)
    column1.request_Floor("Down", 2)
}
//#####################################################################

//#####################################################################
//########################## SEQUECE 3 ################################
//#####################################################################
function sequence3() {
    console.log("")
    console.log("")
    console.log("---------------------------------------------------")
    console.log("------------------ SEQUENCE 3 ---------------------")
    console.log("---------------------------------------------------")
    console.log("")
    column1.User_response = "no"
    column1.User_Destination = 2
    column1.User_Direction = "Down"
    column1.User_Actual_Floor = 3
    column1.ElevatorList[0].currentFloor = 10        // ENTER VALUES OF WHERE YOUR ELEVATOR ACTUALLY ARE
    column1.ElevatorList[1].currentFloor = 3
    column1.ElevatorList[1].IsStatusIDLE = false      // OBVIOUS TRUE OR FALSE 
    start()
    column1.Best_Elevator(3 , "Down", find_Closest_Elevator)
    column1.request_Elevator(3)
    column1.request_Floor("Down", 2)
    sequence3_1()
}
//#####################################################################

//#####################################################################
//########################## SEQUECE 3.1 ##############################
//#####################################################################
function sequence3_1() {
    console.log("")
    console.log("")
    console.log("---------------------------------------------------")
    console.log("------------------ SEQUENCE 3.1 -------------------")
    console.log("---------------------------------------------------")
    console.log("")
    column1.User_response = "no"
    column1.User_Destination = 3
    column1.User_Direction = "Down"
    column1.User_Actual_Floor = 10
    column1.ElevatorList[0].currentFloor = 2        // ENTER VALUES OF WHERE YOUR ELEVATOR ACTUALLY ARE
    column1.ElevatorList[1].currentFloor = 6
    column1.ElevatorList[1].IsStatusIDLE = true      // OBVIOUS TRUE OR FALSE 
    start()
    column1.Best_Elevator(10 , "Down", find_Closest_Elevator)
    column1.request_Elevator(10)
    column1.request_Floor("Down", 3)
}
//#####################################################################

//#################### CHOOSE YOUR SEQUENCE ###########################
//sequence1()
//sequence2()
sequence3()
//################## END OF SEQUENCE CHOOSE ###########################


/*     
--------------------------------------------------- TEST ------------------------------------------

SET column1 to INSTANTIATE Column WITH 1, 1, 10, 2

'SCENARIO 1'
CALL request_Floor WITH 3, Up      ELEVATOR A IDLE FLOOR 2  || ELEVATOR B IDLE Floor 6
CALL request_Elevator WITH 7    
'SCENARIO 2'
CALL request_Floor WITH 1, Up      ELEVATOR A IDLE FLOOR 10   || ELEVATOR B IDLE FLOOR 3
CALL request_Elevator WITH 6

CALL request_Floor WITH 3, Up      ELEVATOR A IDLE FLOOR 10  || ELEVATOR B IDLE FLOOR 6
CALL request_Elevator WITH 5

CALL request_Floor WITH 9, Down     ELEVATOR A IDLE FLOOR 10  || ELEVATOR B MOVE TO FLOOR 5
CALL request_Elevator WITH 2
'SCENARIO 3'
CALL request_Floor WITH 3, Down         ELEVATOR A IDLE FLOOR 10 || ELEVATOR B MOVING TO FLOOR 6
CALL request_Elevator WITH 2

CALL request_Floor WITH 10, Down          ELEVATOR A  IDLE FLOOR 2  || ELEVATOR IDLE FLOOR 6
CALL request_Elevator WITH 3

--------------------------------------------------END test--------------------------------------------
*/