################################
######### Residential ##########
################################
import datetime


class CallButton:
      def __init__(self, Direction, Floor):
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
Elevator1 = Elevator(id)

## REQUEST ELEVATOR ##
def request_Elevator(Floor, Direction):
      Elevator1.elevatorQueue.append(Floor)
      if Direction == "up" or "Up":
            Elevator1.IsDirectionUp = True
      else:
            Elevator1.IsDirectionUp = not Elevator1.IsDirectionUp
## END REQUEST ELEVATOR ##

## REQUEST FLOOR ##
def  request_Floor(Floor, Direction):
      Elevator1.requestButtonList.append(Floor)
      if Direction == "up" or "Up":
            Elevator1.IsDirectionUp = True
      else:
            Elevator1.IsDirectionUp = not Elevator1.IsDirectionUp

## END REQUEST FLOOR ##

## FIND THE BEST ELEVATOR ##
def Best_Elevator(Floor, Direction):
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
## END FIND THE BEST ELEVATOR ##      
      
request_Elevator(1, "down")
request_Floor(4, "up")
Best_Elevator(5, "down")