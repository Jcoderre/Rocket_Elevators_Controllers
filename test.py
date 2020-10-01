################################
######### Residential ##########
################################
import datetime
import time



minimum = float("inf")
setted_list = [2, 6]
value_chosen = 3
for i in setted_list:
    if abs(i - value_chosen) < minimum:
        final_value = i
        minimum = abs(i - value_chosen)


print(final_value)



    

"""

def Best_Elevator(user, User_Actual_Floor , User_Direction):
            chosenElevator = None
            bestScore = 10
            for elevator in self.ElevatorList:
                if User_Direction == "Up" or "UP" or "uP" or "up":
                    if elevator.IsDirectionUp == True:                   
                        if bestScore > 1:
                            elevator.elevatorQueue.append = User_Actual_Floor
                            chosenElevator = elevator
                            bestScore = 1
                    elif elevator.IsDirectionUp == False:
                        if bestScore > 1:
                            elevator.elevatorQueue.append = User_Actual_Floor
                            chosenElevator = elevator
                            bestScore = 8
                    elif  elevator.IsStatusIDLE == True:
                        if bestScore > 1:
                            elevator.elevatorQueue.append = User_Actual_Floor
                            chosenElevator = elevator
                            bestScore = 2
                if User_Direction == "down" or "Down" or "DOwn" or "DOWn" or "DOWN" or "dOWN" or "doWN" or "dowN":
                    if elevator.IsDirectionUp == True:                   
                        if bestScore > 1:
                            elevator.elevatorQueue.append = User_Actual_Floor
                            chosenElevator = elevator
                            bestScore = 8
                    elif elevator.IsDirectionUp == False:
                        if bestScore > 1:
                            elevator.elevatorQueue.append = User_Actual_Floor
                            chosenElevator = elevator
                            bestScore = 1
                    elif  elevator.IsStatusIDLE == True:
                        if bestScore > 1:
                            elevator.elevatorQueue.append = User_Actual_Floor
                            chosenElevator = elevator
                            bestScore = 2
            return chosenElevator
"""


best_Elevator_Choice = float("inf")
actual_Floor_Of_Elevator = [2, 6]
actual_Floor = 3
for i in actual_Floor_Of_Elevator:
    if abs(i - actual_Floor) < best_Elevator_Choice:
        find_Best_Elevator = i
        best_Elevator_Choice = abs(i - actual_Floor)


print(find_Best_Elevator)
