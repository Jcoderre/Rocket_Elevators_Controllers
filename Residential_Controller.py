##########################################################
######### RESIDENTIAL CONTROLLER PYTHON VERSION ##########
##########################################################
import datetime
import time

### Create a variable to show actual time and date ###
now = datetime.datetime.now()


########################### CLASS CALL BUTTON ############################
class CallButton:
      def __init__(self, User_Actual_Floor, User_Direction):
            self.Direction = []
            self.Floor = []
################## END CLASS CALL BUTTON ##################################

#################### CLASS ELEVATOR #######################################
class Elevator:    
      def __init__(self, id):
            self.id = id
            self.elevatorQueue = []         # Unordered set of floor request
            self.requestButtonList = []     # Array of Requested Buttons
            self.IsStatusIDLE = True        # Boolean ->  IDLE, Moving 
            self.IsDirectionUp = bool       # Boolean ->  Up, Down
            self.IsDoorsClose = True        # Bollean ->  Close or Open
            self.currentFloor = 1           # Actual floor of the elevator          
            self.Maxweight = 2500           # Maximum Weight
            self.ActualWeight = 0           # Actual Weight
   
######################### END CLASS ELEVATOR #################################

########################## Class Column ######################        
class Column:   
      def __init__(self, minFloor, maxFloor, Elevator_Amount):
            self.minFloor = minFloor
            self.maxFloor = maxFloor
            self.Floor_Amount = (maxFloor + 1) - minFloor 
            self.floorAmountList = []
            self.Elevator_Amount = Elevator_Amount
            self.IsStatusIDLE = True          # IDLE, Moving
            self.ElevatorList = []             
            self.callButtonsList = []
            self.chosenElevator = None
            self.User_response = ""
            self.User_Destination = 0
            self.User_Direction = ""
            self.User_Actual_Floor = 0
      ###### CREATING A LIST OF FLOOR IN BUILDING ######

            for j in range(self.minFloor, self.maxFloor + 1, 1):
                  self.floorAmountList.append(j)

      ########## END OF LIST OF FLOOR IN BUILDING #######

      ####### FINDING THE GOOD AMOUNT OF ELEVATOR #######
            for i in range(Elevator_Amount):
                  elevator = Elevator(i + 1)
                  self.ElevatorList.append(elevator)
      ##### END FINDING THE GOOD AMOUT OF ELEVATOR ######

      #### CREATING THE CALLING BUTTON FOR EACH FLOOR ###
            for CallButton in range(self.minFloor, self.maxFloor, 1):
                  if CallButton != self.maxFloor:
                        self.NewCallButtonUp = "Up" + str(CallButton)
                        self.callButtonsList.append("NewCallButtonUp")
                  if CallButton > self.minFloor:
                        self.NewCallButtonDown = "Down" + str(CallButton)
                        self.callButtonsList.append("NewCallButtonDown")
      ############## END CREATING CALLING BUTTON ########
  
      ############## FIND THE BEST ELEVATOR #############
      def Best_Elevator(self, User_Actual_Floor , User_Direction, find_Best_Elevator):
            bestScore = 10
            for elevator in self.ElevatorList:     
                  if User_Direction == "up":
                        if elevator.IsDirectionUp == True and User_Actual_Floor >= elevator.currentFloor:
                              if bestScore > 1:
                                    self.chosenElevator = elevator
                                    bestScore = 1
                        elif elevator.IsDirectionUp == False:
                              if bestScore > 8:
                                    self.chosenElevator = elevator
                                    bestScore = 8
                        elif  elevator.IsStatusIDLE == True:
                              if find_Best_Elevator == column1.ElevatorList[0].currentFloor:
                                    if bestScore > 2:
                                          self.chosenElevator = elevator
                                          bestScore = 2
                              elif find_Best_Elevator == column1.ElevatorList[1].currentFloor:
                                    if bestScore > 1:
                                          self.chosenElevator = elevator
                                          bestScore = 2               
                  if User_Direction == "down":
                        if elevator.IsDirectionUp == False:                   
                              if bestScore > 8:
                                    self.chosenElevator = elevator
                                    bestScore = 8
                        elif elevator.IsDirectionUp == True and User_Actual_Floor <= elevator.currentFloor:
                              if bestScore > 1:
                                    self.chosenElevator = elevator
                                    bestScore = 1
                        elif  elevator.IsStatusIDLE == True:
                              if find_Best_Elevator == column1.ElevatorList[0].currentFloor:
                                    if bestScore > 2:
                                          self.chosenElevator = elevator
                                          bestScore = 2
                              elif find_Best_Elevator == column1.ElevatorList[1].currentFloor:
                                    if bestScore > 1:
                                          self.chosenElevator = elevator
                                          bestScore = 2 
      ############## END FIND THE BEST ELEVATOR #########  

      ################### MOVE ##########################
      def moveUp(self, User_Actual_Floor):
            while int(User_Actual_Floor) > self.chosenElevator.currentFloor:
                  time.sleep(0.4)
                  self.chosenElevator.currentFloor += 1
                  self.chosenElevator.IsStatusIDLE = False
                  print("The elevator is at floor " + str(self.chosenElevator.currentFloor))
                  self.chosenElevator.IsDirectionUp = True
                  if int(User_Actual_Floor) == self.chosenElevator.currentFloor:
                        print("--------------------")
                        print("The elevator is here")
                        time.sleep(1)
                        print("")
                        print("Open Door")
                        doorOpening()
                        time.sleep(1)
                        print("")
                        print("Close Door")
                        doorClosing()
                        time.sleep(1)

      def moveDown(self, User_Actual_Floor):
            while int(User_Actual_Floor) < self.chosenElevator.currentFloor:
                  time.sleep(0.4)
                  self.chosenElevator.currentFloor -= 1
                  self.chosenElevator.IsStatusIDLE = False
                  print("The elevator is at floor " + str(self.chosenElevator.currentFloor))
                  self.chosenElevator.IsDirectionUp = False
                  if int(User_Actual_Floor) == self.chosenElevator.currentFloor:
                        print("--------------------")
                        print("The elevator is here")
                        time.sleep(1)
                        print("")
                        print("Open Door")
                        doorOpening()
                        time.sleep(1)
                        print("")
                        print("Close Door")
                        doorClosing()
                        time.sleep(1)
      ######################## END MOVE ################
  
      ############# REQUEST ELEVATOR  ##################
      def request_Elevator(self, User_Actual_Floor):
            self.chosenElevator.elevatorQueue.append(User_Actual_Floor)
            if int(User_Actual_Floor) > self.chosenElevator.currentFloor:
                  self.chosenElevator.IsDirectionUp = True
                  self.moveUp(User_Actual_Floor)
            elif int(User_Actual_Floor) < self.chosenElevator.currentFloor:
                  self.chosenElevator.IsDirectionUp = False
                  self.moveDown(User_Actual_Floor)
      ############## END REQUEST ELEVATOR ############### 

      ############## REQUEST FLOOR IN ELEVATOR ##########
      def  request_Floor(self, User_Direction, User_Destination):
            self.chosenElevator.requestButtonList.append(User_Destination) 
            if User_Direction  == 'up':
                  self.moveElevatorUp(User_Destination)
            elif User_Direction == "down":
                  self.moveElevatorDown(User_Destination)      
      ############### END REQUEST FLOOR ##################

      ################## MOVE WHILE INSIDE ################
      def moveElevatorUp(self, User_Destination):
            while int(User_Destination) > self.chosenElevator.currentFloor:
                  time.sleep(0.4)
                  self.chosenElevator.currentFloor += 1
                  self.chosenElevator.IsStatusIDLE = False
                  print("The elevator is at floor " + str(self.chosenElevator.currentFloor))
                  self.chosenElevator.IsDirectionUp = True
                  if int(User_Destination) == self.chosenElevator.currentFloor :
                        print("----------------------")
                        print("Arrived at destination")
                        time.sleep(1)
                        print("")
                        print("Open Door")
                        doorOpening()
                        time.sleep(1)

      def moveElevatorDown(self, User_Destination):
            while int(User_Destination) < self.chosenElevator.currentFloor:
                  time.sleep(0.4)
                  self.chosenElevator.currentFloor -= 1
                  self.chosenElevator.IsStatusIDLE = False
                  print("The elevator is at floor " + str(self.chosenElevator.currentFloor))
                  self.chosenElevator.IsDirectionUp = True
                  if int(User_Destination) == self.chosenElevator.currentFloor :
                        print("----------------------")
                        print("Arrived at destination")
                        time.sleep(1)
                        print("")
                        print("Open Door")
                        doorOpening()
                        time.sleep(1)
      ################## END WHILE INSIDE #################

      #################### COLUMN INTERFACE  #################
      def column_user_Interface (self, User_response, User_Direction, User_Actual_Floor):
            print("Welcome !")
            print("Are you at the Ground floor ?")
            while self.User_response not in {"yes", "y", "no", "n"}:
                  self.User_response = input("Please enter yes or no: ")
                  time.sleep(1)
                  self.User_response = self.User_response.lower()
                  if self.User_response in ("yes", "y"):
                        print("Perfect !") 
                        print("An elevator is on the way") 
                        print("Have a wonderful day !")
                        print("----------------------")
                        time.sleep(1)
                        self.User_Direction = 'up'
                        self.User_Actual_Floor = 1
                  elif self.User_response in {"no", "n"}:
                        print("Where are you ?")
                        while  int(self.User_Actual_Floor) not in self.floorAmountList: 
                              self.User_Actual_Floor = input("Floor: ")
                              if self.User_Actual_Floor == str(self.minFloor):
                                    print("Perfect !") 
                                    print("An elevator is on the way") 
                                    print("Have a wonderful day !")
                                    print("----------------------")
                                    time.sleep(1)
                                    self.User_Direction = 'up'
                                    self.User_Actual_Floor = "1"
                              elif User_Actual_Floor == str(self.maxFloor):
                                    print("Perfect !") 
                                    print("An elevator is on the way") 
                                    print("Have a wonderful day !")
                                    print("----------------------")
                                    time.sleep(1)
                                    self.User_Direction = 'down'
                              elif self.User_Actual_Floor in str(self.floorAmountList):
                                    print("Which way are you going ?")
                                    while self.User_Direction not in {"up", "down"}:
                                          self.User_Direction = input("Down or Up: ")
                                          self.User_Direction = self.User_Direction.lower()
                                          if User_Direction in ("up"):
                                                print("Perfect !") 
                                                print("An elevator is on the way") 
                                                print("Have a wonderful day !")
                                                print("----------------------")
                                                time.sleep(1)
                                                self.User_Direction = 'up'
                                          elif User_Direction in ("down"):
                                                print("Perfect !") 
                                                print("An elevator is on the way") 
                                                print("Have a wonderful day !")
                                                print("----------------------")
                                                time.sleep(1)
                                                self.User_Direction = 'down'                                  
                              else:
                                    print("Enter a valid answer")
                                    self.User_Direction = None

      ################# END COLUMN INTERFACE  ################  

      ### VALUES BY THE USER MUST BE ENTER TO LET THE ALGORITHM RUN ####
      ############### ELEVATOR INTERFACE #################
      def elevator_User_Interface(self, User_Destination, User_Direction, User_Actual_Floor):
            time.sleep(2)
            print("Welcome in our elevator !")
            print ("Today we are : ")
            print (now.strftime("%A the %d of %B local time: %I:%M %p"))
            time.sleep(1)
            print("Actualy you are at floor " + str(self.User_Actual_Floor))
            time.sleep(1)
            print("Which floor are you heading ?")
            while int(self.User_Destination) not in self.floorAmountList:
                  self.User_Destination = input("Please select a floor: ")
                  print("----------------------")
                  if self.User_Destination == self.User_Actual_Floor:
                        print("You're already there !")
                        print("Please select a valid floor")
                        self.User_Destination = None
                        time.sleep(2)
                  elif int(self.User_Destination) in self.floorAmountList:
                        if int(self.User_Destination) > int(self.User_Actual_Floor):
                              self.User_Direction = 'up'
                        elif int(User_Destination) < int(self.User_Actual_Floor):
                              self.User_Direction = "down"
                  else:
                        print("Enter a valid answer")
                        self.User_Destination = None

      ############# END ELEVATOR INTERFACE #################

############################# END Class Column ################################

column1 = Column(1, 10, 2)          ### CREATING YOUR COLUMN

################ FUNCTION THAT START THE SCENARIO ######################

def start():
      print("Elevator A is at " + str(column1.ElevatorList[0].currentFloor))
      print("Elevator B is at " + str(column1.ElevatorList[1].currentFloor))
      print("This is the list of all floor available in the building: " + str(column1.floorAmountList))
      print("")
      column1.column_user_Interface (column1.User_response, column1.User_Direction, column1.User_Actual_Floor)
      actual_Floor_Of_Elevators = [column1.ElevatorList[0].currentFloor, column1.ElevatorList[1].currentFloor]
      # # For each variable in the array
      # Find the absolute value of the difference between array values and the user actual floor
      # If less then our best elevator choice then this variable is choosen
      best_Elevator_Choice = float("inf")
      for i in actual_Floor_Of_Elevators:
            if abs(i - int(column1.User_Actual_Floor)) < best_Elevator_Choice:
                  find_Best_Elevator = i
                  best_Elevator_Choice = abs(i - int(column1.User_Actual_Floor)) 

      column1.Best_Elevator(column1.User_Actual_Floor , column1.User_Direction, find_Best_Elevator)
      column1.request_Elevator(column1.User_Actual_Floor)
      print("The chosen Elevator to send is elevator {}".format(column1.chosenElevator.id))
      column1.elevator_User_Interface(column1.User_response, column1.User_Direction, column1.User_Actual_Floor)
      column1.request_Floor(column1.User_Direction, column1.User_Destination)

################ END FUNCTION THAT START THE SCENARIO ######################

def doorOpening():
      print("")
      print("_____  _____")
      print("|<--|  |-->|")
      print("|<--|  |-->|")
      print("|<--|  |-->|")
      print("|<--|  |-->|")
      print("|<--|  |-->|")
      print("|<--|  |-->|")
      print("|<--|  |-->|")
      print("|___|  |___|")
      print("")

def doorClosing():
      print("")
      print("_____  _____")
      print("|-->|  |<--|")
      print("|-->|  |<--|")
      print("|-->|  |<--|")
      print("|-->|  |<--|")
      print("|-->|  |<--|")
      print("|-->|  |<--|")
      print("|-->|  |<--|")
      print("|___|  |___|")
      print("")





#####################################################################
########################### SEQUENCE 1 ##############################
#####################################################################
def sequence1():
      print("")
      print("")
      print("------------------ SEQUENCE 1 ---------------------")
      print("-- THOSE ANSWER ARE MANUALLY PUT FOR YOU TO TEST --")
      print("---------------------------------------------------")
      time.sleep(2)
      column1.ElevatorList[0].currentFloor = 2        ## ENTER VALUES OF WHERE YOUR ELEVATOR ACTUALLY ARE
      column1.ElevatorList[1].currentFloor = 6
      column1.ElevatorList[1].IsStatusIDLE = True      ## OBVIOUS TRUE OR FALSE
      start()
#####################################################################

#####################################################################
########################### SEQUENCE 2.1 ############################
#####################################################################
def sequence2():
      print("")
      print("")
      print("-------------------- SEQUENCE 2 ------------------------")
      print("-- THOSE ANSWER ARE AUTOMATICALLY PUT FOR CONVENIENCE --")
      print("--------------------------------------------------------")
      time.sleep(2)
      column1.User_response = "yes"
      column1.User_Destination = 6
      column1.User_Direction = "up"
      column1.User_Actual_Floor = 1
      column1.ElevatorList[0].currentFloor = 10        ## ENTER VALUES OF WHERE YOUR ELEVATOR ACTUALLY ARE
      column1.ElevatorList[1].currentFloor = 3
      column1.ElevatorList[1].IsStatusIDLE = True      ## OBVIOUS TRUE OR FALSE
      start()
      sequence2_2()
      sequence2_3()
#####################################################################

#####################################################################
########################## SEQUECE 2.2 ##############################
#####################################################################
def sequence2_2():
      print("")
      print("")
      print("-------------------- SEQUENCE 2.2 ----------------------")
      print("-- THOSE ANSWER ARE AUTOMATICALLY PUT FOR CONVENIENCE --")
      print("--------------------------------------------------------")
      time.sleep(2)
      column1.User_response = "no"
      column1.User_Destination = 5
      column1.User_Direction = "up"
      column1.User_Actual_Floor = 3
      column1.ElevatorList[0].currentFloor = 10        ## ENTER VALUES OF WHERE YOUR ELEVATOR ACTUALLY ARE
      column1.ElevatorList[1].currentFloor = 6
      column1.ElevatorList[1].IsStatusIDLE = True      ## OBVIOUS TRUE OR FALSE
      start()
#####################################################################

#####################################################################
########################## SEQUECE 2.3 ##############################
#####################################################################
def sequence2_3():
      print("")
      print("")
      print("-------------------- SEQUENCE 2.3 ----------------------")
      print("-- THOSE ANSWER ARE AUTOMATICALLY PUT FOR CONVENIENCE --")
      print("--------------------------------------------------------")
      time.sleep(2)
      column1.User_response = "no"
      column1.User_Destination = 2
      column1.User_Direction = "down"
      column1.User_Actual_Floor = 9
      column1.ElevatorList[0].currentFloor = 10        ## ENTER VALUES OF WHERE YOUR ELEVATOR ACTUALLY ARE
      column1.ElevatorList[1].currentFloor = 5
      column1.ElevatorList[1].IsStatusIDLE = False      ## OBVIOUS TRUE OR FALSE
      start()
#####################################################################

#####################################################################
########################## SEQUECE 3 ################################
#####################################################################
def sequence3():
      print("")
      print("")
      print("-------------------- SEQUENCE 3 ------------------------")
      print("-- THOSE ANSWER ARE AUTOMATICALLY PUT FOR CONVENIENCE --")
      print("--------------------------------------------------------")
      time.sleep(2)
      column1.User_response = "no"
      column1.User_Destination = 2
      column1.User_Direction = "down"
      column1.User_Actual_Floor = 3
      column1.ElevatorList[0].currentFloor = 10        ## ENTER VALUES OF WHERE YOUR ELEVATOR ACTUALLY ARE
      column1.ElevatorList[1].currentFloor = 3
      column1.ElevatorList[1].IsStatusIDLE = False      ## OBVIOUS TRUE OR FALSE
      start()
      sequence3_1()
#####################################################################

#####################################################################
########################## SEQUECE 3.1 ##############################
#####################################################################
def sequence3_1():
      print("")
      print("")
      print("-------------------- SEQUENCE 3.1 ----------------------")
      print("-- THOSE ANSWER ARE AUTOMATICALLY PUT FOR CONVENIENCE --")
      print("--------------------------------------------------------")
      time.sleep(2)
      column1.User_response = "no"
      column1.User_Destination = 3
      column1.User_Direction = "down"
      column1.User_Actual_Floor = 10
      column1.ElevatorList[0].currentFloor = 2        ## ENTER VALUES OF WHERE YOUR ELEVATOR ACTUALLY ARE
      column1.ElevatorList[1].currentFloor = 6
      column1.ElevatorList[1].IsStatusIDLE = True      ## OBVIOUS TRUE OR FALSE
      start()
#####################################################################

#################### CHOOSE YOUR SEQUENCE ###########################
#sequence1()
#sequence2()
#sequence3()
################## END OF SEQUENCE CHOOSE ###########################


"""      
--------------------------------------------------- TEST ------------------------------------------

'SCENARIO 1'
CALL request_Floor WITH 3, Up      ELEVATOR A IDLE FLOOR 2  || ELEVATOR B IDLE Floor 6
CALL request_Elevator WITH 7    
'SCENARIO 2'
CALL request_Floor WITH 1, Up      ELEVATOR A IDLE FLOOR 10 || ELEVATOR B IDLE FLOOR 3
CALL request_Elevator WITH 6

CALL request_Floor WITH 3, Up      ELEVATOR A IDLE FLOOR 10 || ELEVATOR B IDLE FLOOR 6
CALL request_Elevator WITH 5

CALL request_Floor WITH 9, Down    ELEVATOR A IDLE FLOOR 10 || ELEVATOR B MOVE FLOOR 5
CALL request_Elevator WITH 2
'SCENARIO 3'
CALL request_Floor WITH 3, Down    ELEVATOR A IDLE FLOOR 10 || ELEVATOR B MOVE FLOOR 6
CALL request_Elevator WITH 2

CALL request_Floor WITH 10, Down   ELEVATOR A  IDLE FLOOR 2 || ELEVATOR B IDLE FLOOR 6
CALL request_Elevator WITH 3

--------------------------------------------------END test--------------------------------------------
"""