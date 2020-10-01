################################
######### Residential ##########
################################
import datetime
import time

### Create a variable to show actual time and date ###
now = datetime.datetime.now()

### Create variable that let the user input is own values ###
User_response = None
User_Destination = None
User_Direction = None
User_Actual_Floor = 0

##### those Values Need to be enter to Create Sequence ###
actual_Floor_Of_Elevators = [2, 6]              ## ENTER VALUES OF WHERE YOUR ELEVATOR ACTUALLY ARE

current_ElevatorFloor = 2

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
   

      ############## REQUEST FLOOR IN ELEVATOR ##########
      def  request_Floor(self, User_Destination):
            self.requestButtonList.append(User_Destination)         
      ############### END REQUEST FLOOR ##################

######################### END CLASS ELEVATOR #################################
      
Elevator1 = Elevator(id)

########################## Class Column ######################        
class Column:   
      def __init__(self, minFloor, maxFloor, Elevator_Amount):
            self.id = id
            self.minFloor = minFloor
            self.maxFloor = maxFloor
            self.Floor_Amount = minFloor - maxFloor
            self.Elevator_Amount = Elevator_Amount
            self.IsStatusIDLE = True          # IDLE, Moving
            self.ElevatorList = []             
            self.callButtonsList = []

      ####### FINDING THE GOOD AMOUNT OF ELEVATOR #######
            for i in range(Elevator_Amount):
                  elevator = Elevator(i + 1)
                  self.ElevatorList.append(elevator)
      ##### END FINDING THE GOOD AMOUT OF ELEVATOR ######

      #### CREATING THE CALLING BUTTON FOR EACH FLOOR ###
            for CallButton in range(self.minFloor, self.maxFloor + 1, 1):
                  if CallButton != self.maxFloor:
                        self.NewCallButtonUp = "Up" + str(CallButton)
                        self.callButtonsList.append("NewCallButtonUp")
                  if CallButton > self.minFloor:
                        self.NewCallButtonDown = "Down" + str(CallButton)
                        self.callButtonsList.append("NewCallButtonDown")
      ############## END CREATING CALLING BUTTON ########
  
      ############## FIND THE BEST ELEVATOR #############
      def Best_Elevator(self, User_Actual_Floor , User_Direction):
            chosenElevator = None
            bestScore = 10
            for elevator in self.ElevatorList:
                if User_Direction == "Up":
                    if elevator.IsDirectionUp == True:                   
                        if bestScore > 1:
                            elevator.elevatorQueue.append(User_Actual_Floor)
                            chosenElevator = elevator
                            print("An elevator as been found1")
                            bestScore = 1
                    elif elevator.IsDirectionUp == False:
                        if bestScore > 1:
                            elevator.elevatorQueue.append(User_Actual_Floor)
                            chosenElevator = elevator
                            print("An elevator as been found2")
                            bestScore = 8
                    elif  elevator.IsStatusIDLE == True:
                        if bestScore > 1:
                            elevator.elevatorQueue.append(User_Actual_Floor)
                            chosenElevator = elevator
                            print("An elevator as been found3")
                            bestScore = 2
                if User_Direction == "Down":
                    if elevator.IsDirectionUp == True:                   
                        if bestScore > 1:
                            elevator.elevatorQueue.append(User_Actual_Floor)
                            chosenElevator = elevator
                            print("An elevator as been found4")
                            bestScore = 8
                    elif elevator.IsDirectionUp == False:
                        if bestScore > 1:
                            elevator.elevatorQueue.append(User_Actual_Floor)
                            chosenElevator = elevator
                            print("An elevator as been found5")
                            bestScore = 1
                    elif  elevator.IsStatusIDLE == True:
                        if bestScore > 1:
                            elevator.elevatorQueue.append(User_Actual_Floor)
                            chosenElevator = elevator
                            print("An elevator as been found6")
                            bestScore = 2
            return chosenElevator
      ############## END FIND THE BEST ELEVATOR #########  

      ################### MOVE ##########################
      def moveUp(self, User_Actual_Floor, current_ElevatorFloor):
            while int(User_Actual_Floor) > current_ElevatorFloor:
                  current_ElevatorFloor += 1
                  print(current_ElevatorFloor)
                  Elevator1.IsDirectionUp = True
                  if int(User_Actual_Floor) == current_ElevatorFloor:
                        print("The elevator is here")
      def moveDown(self, User_Actual_Floor, current_ElevatorFloor):
            while int(User_Actual_Floor) < current_ElevatorFloor:
                  current_ElevatorFloor -= 1
                  print(current_ElevatorFloor)
                  Elevator1.IsDirectionUp = not Elevator1.IsDirectionUp
                  if int(User_Actual_Floor) == current_ElevatorFloor:
                        print("The elevator is here")
      ######################## END MOVE ################
  
      ############# REQUEST ELEVATOR  ##################
      def request_Elevator(self, User_Actual_Floor, User_Direction):
            Elevator1.elevatorQueue.append(User_Actual_Floor)
            if User_Direction == "Up":
                  Elevator1.IsDirectionUp = True
                  Column1.Best_Elevator(User_Actual_Floor , User_Direction)
            elif User_Direction == "Down":
                  Elevator1.IsDirectionUp = not Elevator1.IsDirectionUp 
                  Column1.Best_Elevator(User_Actual_Floor , User_Direction)
      ############## END REQUEST ELEVATOR ############### 

############################# END Class Column ################################

Column1 = Column(1, 10, 2)

print(Column1.ElevatorList[0].id)   # ID = 1
print(Column1.ElevatorList[1].id)   # ID = 2

#################### COLUMN INTERFACE  #################
print("Welcome !")
print("Are you at the Ground floor ?")
while User_response not in {"yes","yes", "Yes", "y", 'Y', "YES", "YEs", "yeS", "yES", "no", "No", "NO", "nO", "N", "n"}:
      User_response = input("Please enter yes or no: ")
      time.sleep(1)
      if User_response in ("yes","yes", "Yes", "y", 'Y', "YES", "YEs", "yeS", "yES"):
            print("Perfect !") 
            print("An elevator is on the way") 
            print("Have a wonderful day !")
            User_Direction = 'Up'
            User_Actual_Floor = "1"         
      elif User_response in ("no", "No", "NO", "nO", "N", "n"):
            print("Where are you ?")
            while  User_Actual_Floor not in {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"}: 
                  User_Actual_Floor = input("Floor: ")
                  if User_Actual_Floor == "1":
                        print("Perfect !") 
                        print("An elevator is on the way") 
                        print("Have a wonderful day !")
                        User_Direction = 'Up'
                        User_Actual_Floor = "1"
                  elif User_Actual_Floor == "10":
                        print("Perfect !") 
                        print("An elevator is on the way") 
                        print("Have a wonderful day !")
                        User_Direction = 'Down'
                  elif User_Actual_Floor == "2" or "3" or "4" or "5" or "6" or "7" or "8" or "9":
                        print("Which way are you going ?")
                        while User_Direction not in {"Up", "UP", "uP", "up", "down", "Down", "DOwn", "DOWn", "DOWN", "dOWN", "doWN", "dowN"}:
                              User_Direction = input("Down or Up: ")
                              if User_Direction in ("Up", "UP", "uP", "up"):
                                    print("Perfect !") 
                                    print("An elevator is on the way") 
                                    print("Have a wonderful day !")
                                    User_Direction = 'Up'
                              elif User_Direction in ("down", "Down", "DOwn", "DOWn", "DOWN", "dOWN", "doWN", "dowN"):
                                    print("Perfect !") 
                                    print("An elevator is on the way") 
                                    print("Have a wonderful day !")
                                    User_Direction = 'Down'
                  else:
                        print("Enter a valid answer")
                        User_Direction = None

################# END COLUMN INTERFACE  ################  

# # For each variable in the array
# Find the absolute value of the difference between array values and the user actual floor
# If less then our best elevator choice then this variable is choosen      
best_Elevator_Choice = float("inf")
for i in actual_Floor_Of_Elevators:
      if abs(i - int(User_Actual_Floor)) < best_Elevator_Choice:
            find_Best_Elevator = i
            best_Elevator_Choice = abs(i - int(User_Actual_Floor))


Column1.request_Elevator(User_Actual_Floor, User_Direction) 
Column1.moveUp(User_Actual_Floor, current_ElevatorFloor)
Column1.moveDown(User_Actual_Floor, current_ElevatorFloor)


print(Elevator1.elevatorQueue)
print(current_ElevatorFloor)
print(User_Direction)

print(find_Best_Elevator)

#def sequence1():




"""
############### ELEVATOR INTERFACE #################

time.sleep(2)
print("Welcome in our elevator !")
print ("Today we are : ")
print (now.strftime("%A the %d of %B local time: %I:%M %p"))
time.sleep(1)
print("Actualy you are at floor " + User_Actual_Floor )
print("Which floor are you heading ?")
while User_Destination not in {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"}:
      User_Destination = input("Please select a floor: ")
      if User_Destination == User_Actual_Floor:
            print("You're already there !")
            print("Please select a valid floor")
            User_Destination = None
            time.sleep(2)
      elif User_Destination in ("1", "2", "3", "4", "5", "6", "7", "8", "9", "10"):
            if int(User_Destination) > int(User_Actual_Floor):
                  User_Direction = 'Up'
            elif int(User_Destination) < int(User_Actual_Floor):
                  User_Direction = "Down"
      else:
            print("Enter a valid answer")
            User_Destination = None

############## END COLUMN INTERFACE #################
"""

"""      
--------------------------------------------------- TEST ------------------------------------------

SET Column1 to INSTANTIATE Column WITH 1, 1, 10, 2

'SCENARIO 1'
CALL request_Floor WITH 3, Up      ELEVATOR A IDLE FLOOR 2  || ELEVATOR B IDLE Floor 6
CALL request_Elevator WITH 7    
'SCENARIO 2'
CALL request_Floor WITH 1, Up
CALL request_Elevator WITH 6

CALL request_Floor WITH 3, Up
CALL request_Elevator WITH 5

CALL request_Floor WITH 9, Down
CALL request_Elevator WITH 2
'SCENARIO 3'
CALL request_Floor WITH 3, Down         ELEVATOR A IDLE F10 ||
CALL request_Elevator WITH 2

CALL request_Floor WITH 10, Down
CALL request_Elevator WITH 3

--------------------------------------------------END test--------------------------------------------
"""