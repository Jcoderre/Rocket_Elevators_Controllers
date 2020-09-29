################################
######### Residential ##########
################################
import datetime
import time

now = datetime.datetime.now()
User_response = None
User_Destination = None
User_Direction = None
User_Actual_Floor = None



class CallButton:
      def __init__(self, User_Actual_Floor, User_Direction):
            self.Direction = []
            self.Floor = []

class Elevator:
      def __init__(self, id):
            self.id = id
            self.elevatorQueue = []         # Array of the Elevator Queue
            self.requestButtonList = []     # Array of Requested Buttons
            self.IsStatusIDLE = True        # Boolean ->  IDLE, Moving 
            self.IsDirectionUp = bool       # Boolean ->  Up, Down
            self.IsDoorsClose = True        # Bollean ->  Close or Open
            self.currentFloor = 1           # Actual floor of the elevator          
            self.Maxweight = 2500           # Maximum Weight
            self.ActualWeight = 0           # Actual Weight

            ## MOVE ##
            if self.elevatorQueue == +1 :
                  self.IsDirectionUp = True
            if self.elevatorQueue == -1 :
                  self.IsDirectionUp = not self.IsDirectionUp
            ## END MOVE ##

      ## ELEVATOR DOORS STATUS ##
      def Open_Door(self):
            self.IsDoorsClose = not self.IsDoorsClose

      def Close_Door(self):
            self.IsDoorsClose = True
      ## END ELEVATOR DOORS STATUS ##

      ## ELEVATOR STATUS ##
      def IDLE_Status(self):
            self.IsStatusIDLE = True 

      def Moving_Status(self):
            self.IsStatusIDLE = not self.IsStatusIDLE     
      ## END ELEVATOR STATUS ##  
         
Elevator1 = Elevator(id)


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

            ## FINDING THE GOOD AMOUNT OF ELEVATOR ##
            for i in range(Elevator_Amount):
                  elevator = Elevator(i)
                  self.ElevatorList.append(elevator)
            ## END FINDING THE GOOD AMOUT OF ELEVATOR ##

            ## CREATING THE CALLING BUTTON FOR EACH FLOOR ##
            for CallButton in range(self.minFloor, self.maxFloor + 1, 1):
                  if CallButton != self.maxFloor:
                        self.NewCallButtonUp = "Up" + str(CallButton)
                        self.callButtonsList.append("NewCallButtonUp")
                  if CallButton > self.minFloor:
                        self.NewCallButtonDown = "Down" + str(CallButton)
                        self.callButtonsList.append("NewCallButtonDown")
            ## END CREATING CALLING BUTTON ##


      def IDLE_Status(self):
            self.IsStatusIDLE = True 

      def Moving_Status(self):
            self.IsStatusIDLE = False     


Column1 = Column(1, 10, 2)
print(Column1.ElevatorList)

print(Column1.IsStatusIDLE)


######## COLUMN INTERFACE  #########

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

print(User_Direction)
print(User_Actual_Floor)


############# REQUEST ELEVATOR ON COLUMN #########
def request_Elevator(User_Actual_Floor, User_Direction):
      Elevator1.elevatorQueue.append(User_Actual_Floor)
      if User_Direction == "up" or "Up":
            Elevator1.IsDirectionUp = True
      else:
            Elevator1.IsDirectionUp = not Elevator1.IsDirectionUp
############## END REQUEST ELEVATOR ###############

print(Elevator1.elevatorQueue)

############## FIND THE BEST ELEVATOR #############
def Best_Elevator(User_Actual_Floor , User_Direction):
      while Elevator1 == "undefined":
            for elevatorSelector in range(Column1.Elevator_Amount):
                  if Elevator1.IsDirectionUp == True:
                        if Elevator1.IsStatusIDLE == True:
                              if Elevator1.currentFloor == "closest":
                                    Elevator1.elevatorQueue.append = elevatorSelector
                                    return elevatorSelector
                        if Elevator1.IsStatusIDLE == False:
                              if Elevator1.IsDirectionUp == True:
                                    if request_Floor > Elevator1.currentFloor:
                                          Elevator1.elevatorQueue.append = elevatorSelector
                                          return elevatorSelector
                                    elif request_Floor < Elevator1.currentFloor:
                                          break
                              elif Elevator1.IsDirectionUp == False:
                                    break
                  elif Elevator1.IsDirectionUp == False:
                        if Elevator1.IsStatusIDLE == True:
                              if Elevator1.currentFloor == "closest":
                                    Elevator1.elevatorQueue.append = elevatorSelector
                                    return elevatorSelector
                              else:
                                    break
                        if Elevator1.IsStatusIDLE == False:
                              if Elevator1.IsDirectionUp == True:
                                    break
                              elif Elevator1.IsDirectionUp == False:
                                    if request_Floor < Elevator1.currentFloor:
                                          Elevator1.elevatorQueue.append = elevatorSelector
                                          return elevatorSelector
                                    elif request_Floor > Elevator1.currentFloor:
                                          break                                 
############## END FIND THE BEST ELEVATOR #########   

print(request_Elevator(User_Actual_Floor, User_Direction))
print(Best_Elevator(User_Actual_Floor , User_Direction))

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

############## REQUEST FLOOR IN ELEVATOR ##########
def  request_Floor(User_Destination, User_Direction):
      Elevator1.requestButtonList.append(User_Destination)
      if User_Direction == "up" or "Up":
            Elevator1.IsDirectionUp = True
      else:
            Elevator1.IsDirectionUp = not Elevator1.IsDirectionUp
############### END REQUEST FLOOR ##################

print(request_Floor(User_Destination, User_Direction))


Best_Elevator(User_Actual_Floor , User_Direction)
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