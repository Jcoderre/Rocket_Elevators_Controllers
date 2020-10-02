##########################################################
######### RESIDENTIAL CONTROLLER RUBY VERSION ############
##########################################################


### Create a variable to show actual time and date ###
now = datetime.datetime.now()

### Create variable that let the user input is own values ###
User_response = None
User_Destination = None
User_Direction = None
User_Actual_Floor = 0

########################### CLASS CALL BUTTON ############################
class CallButton:
      def initialize(User_Actual_Floor, User_Direction)
            @Direction = []
            @Floor = []
      end
end

################## END CLASS CALL BUTTON ##################################

//#################### CLASS ELEVATOR #######################################
class Elevator:    
      def  initialize(id) 
            @id = id
            @elevatorQueue = []         # Unordered set of floor request
            @requestButtonList = []     # Array of Requested Buttons
            @IsStatusIDLE = true        # Boolean ->  IDLE, Moving 
            @IsDirectionUp = nil        # Boolean ->  Up, Down
            @IsDoorsClose = true        # Bollean ->  Close or Open
            @currentFloor = 1           # Actual floor of the elevator          
            @Maxweight = 2500           # Maximum Weight
            @ActualWeight = 0           # Actual Weight
      end
end
      

//######################### END CLASS ELEVATOR #################################


//########################## Class Column ######################################
class Column {
      def initialize(minFloor, maxFloor, Elevator_Amount)
            @minFloor = minFloor                            # Minimum amount of floor
            @maxFloor = maxFloor                            # Maximum amount of floor
            @Floor_Amount = minFloor - maxFloor             # Calculate the good number of floor
            @Elevator_Amount = Elevator_Amount              # Number of elevator needed
            @IsStatusIDLE = true                            # IDLE, Moving
            @ElevatorList = []                              # An Elevator list        
            @callButtonsList = []                           # A list of all call button (Up and down) on column
            @chosenElevator = nil                           # The best elevator that will be send to user


            //####### FINDING THE GOOD AMOUNT OF ELEVATOR #######
            for (var i = 0; i < Elevator_Amount; i++) {
                  var elevator = new Elevator(i + 1)
                  @ElevatorList.push(elevator)
            end        
            //##### END FINDING THE GOOD AMOUT OF ELEVATOR ######
      end
end

for i in 1..2
      if i < Elevator_Amount then
            elevator = Elevator new 
      end
end