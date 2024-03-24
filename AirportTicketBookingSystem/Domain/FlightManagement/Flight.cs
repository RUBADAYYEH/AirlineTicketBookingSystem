using System;


namespace AirportTicketBookingSystem.Domain.FlightManagement
{
    public class Flight
    {

        public required int FlightId { get; init; }
        public decimal Price { get; set; }
        public required string DepartureCountry { get; init; }
        public required string DestinationCountry { get; init; }
        public required DateTime DepartureDate { get; init; }
        public required string DepartureAirport { get; init; }
        public required string ArrivalAirport { get; set; }
        public required  FlightClass FlightClass { get; init; }

        public override string ToString()
        {
            return $"Fight no: {FlightId}: From {DepartureCountry} To {DestinationCountry}: {DepartureDate}: {DepartureAirport}: {ArrivalAirport}: {FlightClass}: {Price}";
        }
        public string SaveToFile()
        {
            return $"{FlightId};{Price};{DepartureCountry};{DestinationCountry};{DepartureDate};{DepartureAirport};{ArrivalAirport};{FlightClass}";
        }


    }
}
