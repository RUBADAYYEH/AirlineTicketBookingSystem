using AirportTicketBookingSystem.Domain.StandardMessages;

namespace AirportTicketBookingSystem.Domain.UserManagement
{
    internal class UserValidator : Utilities
    {
        public static bool ValidateUserByUsername(string username)
        {
            if (username == null)
            {
                StandardMessage.FailedLogInMessage();
                return false;
            }
           
            return true;
        }
    }
}
