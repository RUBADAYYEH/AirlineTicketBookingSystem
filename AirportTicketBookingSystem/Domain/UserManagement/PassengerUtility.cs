using AirportTicketBookingSystem.Domain.FlightManagement;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;


namespace AirportTicketBookingSystem.Domain.UserManagement
{
    public class PassengerUtility : Utilities
    {
        public static void Initialize()
        {
            ShowAllActionsToPassenger();

        }
        public static void ShowAllActionsToPassenger()
        {
            Console.ResetColor();
            Console.Clear();
            Organize();
            Console.WriteLine("* PASSENGER PANEL *");
            Console.WriteLine("* Select an Action *");
            Organize();
            Console.WriteLine("1: Book a flight");
            Console.WriteLine("2: Search for available flights");
            Console.WriteLine("3: Manage bookings");
            Console.WriteLine("4: Save and Exit.");
            Console.WriteLine("0: Close application");
            Console.WriteLine("Your selection: ");
            string? userSelection = Console.ReadLine();
            if (userSelection != null)
            {
                switch (userSelection)
                {
                    case "1":
                        ShowBookFlightList();
                        ShowAllActionsToPassenger();
                        break;
                    case "2":
                        SearchOnFlightsToBook();
                        ShowAllActionsToPassenger();

                        break;
                    case "3":
                        PassengerManagesBooking();
                        ShowAllActionsToPassenger();
                        break;
                    case "4":
                        WriteBookingToBookedFlightsFile();
                        WriteflightsToFlightsFile();
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            }

        }

        private static void PassengerManagesBooking()
        {
            Console.WriteLine("* Manage Booking *");
            Console.WriteLine("* Select an Action *");
            Organize();
            Console.WriteLine("1: View personal booking");
            Console.WriteLine("2: Cancel a booking");
            Console.WriteLine("0: exit");
            string? userSelection = Console.ReadLine();
            if (userSelection != null)
            {
                switch (userSelection)
                {
                    case "1":
                        ViewPersonalBookingList();
                        break;
                    case "2":
                        PassengerCancelsBooking();
                        break;
                    case "0":
                        break;
                    default:
                        break;


                }
            }
        }

        private static void PassengerCancelsBooking()
        {
            ViewPersonalBookingList();
            Console.WriteLine("Enter the id of the flight you want to cancel: ");
            bool success = int.TryParse(Console.ReadLine(), out int id);
            if (!success)
            {
                Console.WriteLine("Invalid input");
                return;
            }
            var flight = bookedFlights.First(f => f.FlightId == id);
            bookedFlights.Remove(flight);
            flights.Add(flight);
            Console.WriteLine($"flight booking for {flight} has been caceled!");
            Console.WriteLine("Press any key to go back to main menu");
            Console.ReadLine();

        }

        private static void ViewPersonalBookingList()
        {
            Console.WriteLine("* YOUR BOOKING LIST ");
            if (bookedFlights.Count > 0)
            {
                foreach (var b in bookedFlights)
                {
                    Console.WriteLine(b.ToString());
                }
            }
            else
            {
                Console.WriteLine("YOU HAVENT BOOKED YET!");
            }
        }

        public static void ShowBookFlightList()
        {
            Console.ResetColor();
            Console.Clear();
            Organize();
            Console.WriteLine("* Help us find your flight *");
            Organize();
            Console.WriteLine("1: Search for available flights");
            Console.WriteLine("0: Close application");
            Console.WriteLine("Your selection: ");
            string? userSelection = Console.ReadLine();
            if (userSelection != null)
            {
                switch (userSelection)
                {
                    case "1":
                        SearchOnFlightsToBook();
                        break;
                    case "0":
                        ShowAllActionsToPassenger();
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }


            }


        }
        public static void SearchOnFlightsToBook()
        {
            List<Flight> filteredList = new List<Flight>(flights);
            Console.ResetColor();
            Console.Clear();
            string? userSelection;
            do
            {
                Console.ResetColor();
                Console.Clear();
                Organize();
                Console.WriteLine("* Help us find your flight / you can add more than one parameter *");
                Organize();
                Console.WriteLine("1: Choose Departure Location");
                Console.WriteLine("2: Choose Destination Location");
                Console.WriteLine("3: Choose Departure Date");
                Console.WriteLine("4: Choose Departure Airport");
                Console.WriteLine("5: Choose Destination Airport");
                Console.WriteLine("6: filter by price");
                Console.WriteLine("0: Finish filtering");
                Console.WriteLine("Your selection: ");
                string? departureLocation;
                string? destinationLocation;
                string? departureDate;
                string? departureAirport;
                string? destinationAirport;
                userSelection = Console.ReadLine();
                if (userSelection != null)
                {
                    switch (userSelection)
                    {
                        case "1":
                            departureLocation = DisplayMessageAndReturnValue("Enter your departure Location: ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            if (departureLocation != "")
                                Console.WriteLine($"you have selected a departure location {departureLocation}!");
                            filteredList = FilterBasedOnDepartureLocation(filteredList, departureLocation);
                            Console.WriteLine("Press any key to proceed!");
                            Console.ReadLine();

                            break;
                        case "2":
                            destinationLocation = DisplayMessageAndReturnValue("Enter your destination Location: ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            if (destinationLocation != "")
                                Console.WriteLine($"you have selected a destination location {destinationLocation}!");
                            filteredList = FilterBasedOnDestinationLocation(filteredList, destinationLocation);
                            Console.WriteLine("Press any key to proceed!");
                            Console.ReadLine();

                            break;
                        case "3":
                            departureDate = DisplayMessageAndReturnValue("Enter your desired date: (IN THE FORMAT DD/MM/YYYY) ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            if (departureDate != "")
                            {
                                DateTime parsedDepartureDate;
                                if (DateTime.TryParseExact(departureDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDepartureDate))
                                {

                                    Console.WriteLine($"you have selected a departure date {departureDate}!");
                                    filteredList = FilterBasedOnDepartureDate(filteredList, departureDate);
                                    Console.WriteLine("Press any key to proceed!");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.WriteLine("Invalid date format entered.");
                                }
                            }

                            break;
                        case "4":
                            departureAirport = DisplayMessageAndReturnValue("Enter your departure Airport: ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            if (departureAirport != "")
                                Console.WriteLine($"you have selected a departure Airport {departureAirport}!");
                            filteredList = FilterBasedOnDepartureAirport(filteredList, departureAirport);
                            Console.WriteLine("Press any key to proceed!");
                            Console.ReadLine();

                            break;
                        case "5":
                            destinationAirport = DisplayMessageAndReturnValue("Enter your destination Airport: ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            if (destinationAirport != "")
                                Console.WriteLine($"you have selected a destination Airport {destinationAirport}!");
                            filteredList = FilterBasedOnDepartureAirport(filteredList, destinationAirport);
                            Console.WriteLine("Press any key to proceed!");

                            Console.ReadLine();

                            break;
                        case "6":

                            break;
                        case "0":
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid selection. Please try again.");
                            break;
                    }




                }
            } while (userSelection != "0");
            if (filteredList.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Available Flights: ");
                foreach (var item in filteredList)
                {
                    Console.WriteLine(item);
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Select the ID of the flight you want to book: (Select -1 if you want to cancel booking process)");
                Console.ResetColor();
                bool success = int.TryParse(Console.ReadLine() ?? "-1", out int userInput);
                if (success && userInput != -1)
                {
                    BookFlightWithID(userInput);
                }
                else
                {
                    Console.WriteLine("Cancelling the booking process. Press any Key to Exit");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Available Flights At The Moment! ");
            }
            Console.ResetColor();
            Console.WriteLine("Press any key to go back to main menu");
            Console.ReadLine();


        }

        public static void BookFlightWithID(int v)
        {
            bookedFlights.Add(flights.First(f => f.FlightId == v));
            flights.Remove(flights.First(f => f.FlightId == v));
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Flight with id {v} is booked successfully!");

            Console.ResetColor();
        }

        private static void WriteBookingToBookedFlightsFile()
        {
            string directory = @"C:\Users\Lenovo\source\repos\AirportTicketBookingSystemProject\AirportTicketBookingSystem\Data\";
            string FileName = "booked.txt";
            using StreamWriter writer = new($"{directory}{FileName}");
            StringBuilder sb = new();
            foreach (var i in bookedFlights)
            {
                sb.AppendLine(i.SaveToFile());
            }
            writer.WriteLine(sb.ToString());
            Console.WriteLine("Exported status to booked.txt file. Press to exit.");
            Console.ReadLine();
        }
        private static void WriteflightsToFlightsFile()
        {
            string directory = @"C:\Users\Lenovo\source\repos\AirportTicketBookingSystemProject\AirportTicketBookingSystem\Data\";
            string FileName = "flights.txt";
            using StreamWriter writer = new($"{directory}{FileName}");
            StringBuilder sb = new();

            foreach (var i in flights)
            {
                sb.AppendLine(i.SaveToFile());
            }
            writer.WriteLine(sb.ToString());

            Console.WriteLine("Exported status to flights.txt file. Press to exit.");
            Console.ReadLine();

        }

        public static string DisplayMessageAndReturnValue(string msg)
        {
            Console.WriteLine(msg);
            string? value = Console.ReadLine();
            return value ?? "";
        }
        public static List<Flight> FilterBasedOnDepartureLocation(List<Flight> flights, string location)
        {
            return flights.Where(flight => flight.DepartureCountry == location).ToList();

        }
        public static List<Flight> FilterBasedOnDepartureDate(List<Flight> flights, string departureDate)
        {
            if (!DateTime.TryParseExact(departureDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDepartureDate))
            {
                return [];
            }
            return flights.Where(flight => flight.DepartureDate.Date == parsedDepartureDate.Date).ToList();

        }
        public static List<Flight> FilterBasedOnDepartureAirport(List<Flight> flights, string location)
        {
            return flights.Where(flight => flight.ArrivalAirport == location).ToList();

        }
        public static List<Flight> FilterBasedOnDestinationLocation(List<Flight> flights, string location)
        {
            return flights.Where(flight => flight.DestinationCountry == location).ToList();

        }
        public static List<Flight> FilterBasedOnDestinationAirport(List<Flight> flights, string location)
        {
            return flights.Where(flight => flight.ArrivalAirport == location).ToList();

        }
        public static void Organize()
        {
            Console.WriteLine("********************");
        }



    }
}
