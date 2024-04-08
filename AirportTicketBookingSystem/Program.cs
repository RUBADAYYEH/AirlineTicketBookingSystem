
namespace AirportTicketBookingSystem
{
    internal class Program
    {
        static void Main()
        {

            Utilities.InitializeFlights();
            Utilities.InitializeUsers();
            Utilities.LoadBookedTickets();

            Utilities.LogIn();
        }
    }
}
