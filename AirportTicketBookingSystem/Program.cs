
namespace AirportTicketBookingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Utilities.InitializeFlightsAndUsers();
          
            Utilities.LogIn();
        }
    }
}
