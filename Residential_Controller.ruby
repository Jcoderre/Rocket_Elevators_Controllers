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
      def __init__(self, User_Actual_Floor, User_Direction):
            self.Direction = []
            self.Floor = []
################## END CLASS CALL BUTTON ##################################