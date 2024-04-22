using System;
using AirportTicketBookingSystem.Domain.FlightManagement;
namespace AirportTicketBookingSystem.Domain.StandardMessages
{

    public class StandardMessage
    {
       public static void EscapeEventByAnyKeyMessage()
        {
            Console.WriteLine("Press any key to countinue!");
            Console.ResetColor();
            Console.ReadLine();
        }
        public static void WelcomeUserMessage(string username)
        {
            Console.WriteLine($"Welcome {username}!");
            EscapeEventByAnyKeyMessage();
        }
        public static void FailedLogInMessage()
        {
            Console.WriteLine($"Failed to log in!");
            EscapeEventByAnyKeyMessage();
        }
        public static void InvalidInputMessage()
        {
            Console.WriteLine("Invalid Input. Please try again.");
        }
        public static void FlightCancelationMessage(Flight flight)
        {
            Console.WriteLine($"flight booking for {flight} has been caceled!");

        }
        public static void CancellingBookingProcess()
        {
            Console.WriteLine("Cancelling the booking process. Press any Key to Exit");
            Console.ReadLine();
        }
        public static void ListEmptyMessage()
        {
            Console.WriteLine($"The list view you have selected is Empty :(");
        }
        public static void BookingConfirmationMessage(int v)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Flight with id {v} is booked successfully!");

            Console.ResetColor();
        }
        public static string DisplayMessageAndReturnValue(string msg)
        {
            Console.WriteLine(msg);
            string? value = Console.ReadLine();
            return value ?? "";
        }
        public static void Organize()
        {
            Console.WriteLine("********************");
        }

    }
}
