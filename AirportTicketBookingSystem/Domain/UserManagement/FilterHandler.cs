﻿using AirportTicketBookingSystem.Domain.FlightManagement;
using AirportTicketBookingSystem.Domain.StandardMessages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBookingSystem.Domain.UserManagement
{
    public class FilterHandler
    {
        public static List<Flight> HandleFilteringOnPrice(decimal price, List<Flight> filteredList)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine($"you have selected a maximum price {price}!");
            filteredList = Filter.FilterBasedOnPrice(filteredList, price);
            StandardMessage.EscapeEventByAnyKeyMessage();
            return filteredList;
        }
        public static List<Flight> HandleFilteringOnClass(FlightClass flightClass, List<Flight> filteredList)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"you have selected a Flight Class {flightClass}!");
            filteredList = Filter.FilterBasedOnClass(filteredList, flightClass);
            return filteredList;
        }

        public static List<Flight> HandleFilteringOnDestinationAirport(string destinationAirport, List<Flight> filteredList)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (destinationAirport != "")
                Console.WriteLine($"you have selected a destination Airport {destinationAirport}!");
            filteredList = Filter.FilterBasedOnDepartureAirport(filteredList, destinationAirport);

            return filteredList;
        }

        public static List<Flight> HandleFilteringOnDepartureCountry(string departureLocation, List<Flight> filteredList)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (departureLocation != "")
                Console.WriteLine($"you have selected a departure location {departureLocation}!");
            filteredList = Filter.FilterBasedOnDepartureLocation(filteredList, departureLocation);

            return filteredList;
        }
        public static List<Flight> HandleFilteringOnDestinationCountry(string destinationLocation, List<Flight> filteredList)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (destinationLocation != "")
                Console.WriteLine($"you have selected a destination location {destinationLocation}!");
            filteredList = Filter.FilterBasedOnDestinationLocation(filteredList, destinationLocation);

            return filteredList;
        }
        public static List<Flight> HandleFilteringBasedOnDate(string departureDate, List<Flight> filteredList)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (departureDate != "")
            {

                if (DateTime.TryParseExact(departureDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDepartureDate))
                {

                    Console.WriteLine($"you have selected a departure date {parsedDepartureDate}!");
                    filteredList = Filter.FilterBasedOnDepartureDate(filteredList, departureDate);
                    StandardMessage.EscapeEventByAnyKeyMessage();
                }
                else
                {
                    Console.WriteLine("Invalid date format entered.");
                }
            }
            return filteredList;
        }
        public static List<Flight> HandleFilteringOnDepartureAirport(string departureAirport, List<Flight> filteredList)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (departureAirport != "")
                Console.WriteLine($"you have selected a departure Airport {departureAirport}!");
            filteredList = Filter.FilterBasedOnDepartureAirport(filteredList, departureAirport);

            return filteredList;
        }

    }
}