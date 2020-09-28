#########residential##########
import datetime


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
        
      def IDLE_Status(self):
            self.IsStatusIDLE = True 

      def Moving_Status(self):
            self.IsStatusIDLE = False     

      def Elevator_Number(self, Elevator_Amount):
            for elevator in range(Elevator_Amount):
                  self.ElevatorList.append(elevator)
                  print(self.ElevatorList)

      def CallButtonList(self, Floor_Amount):
            for CallButton in range(self.minFloor, self.maxFloor + 1, 1):
                  if CallButton != self.maxFloor:
                        self.NewCallButtonUp = "Up" + CallButton
                        self.callButtonsList.append("NewCallButtonUp")
                  if CallButton > self.minFloor:
                        self.NewCallButtonDown = "Down" + CallButton
                        self.callButtonsList.append("NewCallButtonDown")
                  

class Elevator:
      def __init__(self):
            self.id = id
            self.elevatorQueue: []          #
            self.requestButtonList: []      #
            self.IsStatusIDLE = True        # IDLE, Moving True or False
            self.Direction = []             # Up, Down
            self.currentFloor = 1           # Actual floor of the elevator
            self.IsDoorsClose = True        # Bolleean
            self.Maxweight = 2500           # Maximum Weight
            self.ActualWeight = 0           # Actual Weight
        
            ## ELEVATOR DOORS STATUS ##
      def Open_Door(self):
            self.IsDoorsClose = False

      def Close_Door(self):
            self.IsDoorsClose = True
            ## END ELEVATOR DOORS STATUS##

            ## ELEVATOR STATUS ##
      def IDLE_Status(self):
            self.IsStatusIDLE = True 

      def Moving_Status(self):
            self.IsStatusIDLE = False     
            ## END ELEVATOR STATUS ##

            ## MOVE ##
      def Elevator_Move(self):
            if self.elevatorQueue == 0 :
                  self.Direction = 'Up'
            if self.elevatorQueue == 1 :
                  self.Direction = "Down"
            ## END MOVE ##

            ## DOORS OPEN WHEN ON FLOOR ##

            ## END DOOR OPEN WHEN ON FLOOR ##


class CallButton:
      def __init__(self, Direction, Floor):
            self.Direction = []
            self.Floor = []


Column1 = Column(1, 10, 2)

## WORDS OF WELCOME ##

def Welcome():
      print ("Welcome to Rocket Elevator")


## SHOW ACTUAL TIME ##

def DateNow():
      now = datetime.datetime.now()
      print ("Today we are the : ")
      print (now.strftime("%Y-%m-%d"))
      print ("Local Time : ")
      print (now.strftime("%H:%M:%S"))


## FIND THE BEST ELEVATOR ##

print(Column1.minFloor)
print(Column1.maxFloor)
print(Column1.Elevator_Amount)
print(Column1.callButtonsList)
  

