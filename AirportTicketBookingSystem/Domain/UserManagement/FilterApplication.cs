using AirportTicketBookingSystem.Domain.FlightManagement;
using AirportTicketBookingSystem.Domain.StandardMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBookingSystem.Domain.UserManagement
{
    internal class FilterApplication:Utilities
    {
        public static List<Flight> FilterBookingList( List <Flight> filteredList)
        {
           
            Console.ResetColor();
            Console.Clear();
            string? userSelection;
            do
            {
                PrintSearchTemplateList();

                string? departureLocation;
                string? destinationLocation;
                string? departureDate;
                string? departureAirport;
                string? destinationAirport;
                decimal price;
                FlightClass flightClass;

                userSelection = Console.ReadLine();

                if (userSelection != null)
                {
                    switch (userSelection)
                    {
                        case "1":
                            departureLocation = StandardMessage.DisplayMessageAndReturnValue("Enter your departure Location: ");
                            filteredList = FilterHandler.HandleFilteringOnDepartureCountry(departureLocation, filteredList);
                            StandardMessage.EscapeEventByAnyKeyMessage();
                            break;
                        case "2":
                            destinationLocation = StandardMessage.DisplayMessageAndReturnValue("Enter your destination Location: ");
                            filteredList = FilterHandler.HandleFilteringOnDestinationCountry(destinationLocation, filteredList);
                            StandardMessage.EscapeEventByAnyKeyMessage();
                            break;
                        case "3":
                            departureDate = StandardMessage.DisplayMessageAndReturnValue("Enter your desired date: (IN THE FORMAT DD/MM/YYYY) ");
                            filteredList = FilterHandler.HandleFilteringBasedOnDate(departureDate, filteredList);
                            StandardMessage.EscapeEventByAnyKeyMessage();
                            break;
                        case "4":
                            departureAirport = StandardMessage.DisplayMessageAndReturnValue("Enter your departure Airport: ");
                            filteredList = FilterHandler.HandleFilteringOnDepartureAirport(departureAirport, filteredList);
                            StandardMessage.EscapeEventByAnyKeyMessage();
                            break;
                        case "5":
                            destinationAirport = StandardMessage.DisplayMessageAndReturnValue("Enter your destination Airport: ");
                            filteredList = FilterHandler.HandleFilteringOnDestinationAirport(destinationAirport, filteredList);
                            StandardMessage.EscapeEventByAnyKeyMessage();
                            break;
                        case "6":
                            bool success = Decimal.TryParse(StandardMessage.DisplayMessageAndReturnValue("Enter a maximum price: "), out price);
                            if (success)
                            {
                                filteredList = FilterHandler.HandleFilteringOnPrice(price, filteredList);
                                StandardMessage.EscapeEventByAnyKeyMessage();
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                StandardMessage.InvalidInputMessage();
                                Console.ResetColor();
                                StandardMessage.EscapeEventByAnyKeyMessage();
                            }

                            break;
                        case "7":
                            success = FlightClass.TryParse(StandardMessage.DisplayMessageAndReturnValue("Enter a maximum price: "), out flightClass);
                            if (success)
                            {
                                filteredList = FilterHandler.HandleFilteringOnClass(flightClass, filteredList);
                                StandardMessage.EscapeEventByAnyKeyMessage();
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                StandardMessage.InvalidInputMessage();
                                Console.ResetColor();
                                StandardMessage.EscapeEventByAnyKeyMessage();
                            }
                            break;

                        case "0":
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            StandardMessage.InvalidInputMessage();
                            break;
                    }
                }
            } while (userSelection != "0");

            return filteredList;

        }
        public static void PrintSearchTemplateList()
        {
            Console.ResetColor();
            Console.Clear();
            StandardMessage.Organize();
            Console.WriteLine("* Filter the flights booking list / you can add more than one parameter *");
            StandardMessage.Organize();
            Console.WriteLine("1: Choose Departure Location");
            Console.WriteLine("2: Choose Destination Location");
            Console.WriteLine("3: Choose Departure Date");
            Console.WriteLine("4: Choose Departure Airport");
            Console.WriteLine("5: Choose Destination Airport");
            Console.WriteLine("6: Filter by price");
            Console.WriteLine("7: Filter by Flight Class");
            Console.WriteLine("0: Finish filtering");
            Console.WriteLine("Your selection: ");
        }
    }
}
