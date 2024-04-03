using AirportTicketBookingSystem.CustomAttributes;
using System;
using System.ComponentModel.DataAnnotations;


namespace AirportTicketBookingSystem.Domain.FlightManagement
{
    public record Flight
    {
        [Required(ErrorMessage = "flight id must be entered.")]

        public int FlightId { get; init; }
        public decimal Price { get; set; }

        [Required(ErrorMessage = "flight departure country must be entered.")]
        public required string DepartureCountry { get; init; }
        public required string DestinationCountry { get; init; }

        [DateIsNowOrLater(ErrorMessage = "Invalid Date, should be between current date and later.")]
        [Required(ErrorMessage = " Departure date must be entered.")]
        public required DateTime DepartureDate { get; init; }
        public required string DepartureAirport { get; init; }
        public required string ArrivalAirport { get; set; }
        public required FlightClass FlightClass { get; init; }

        public override string ToString()
        {
            return $"Fight no: {FlightId}: From {DepartureCountry} To {DestinationCountry}: {DepartureDate}: {DepartureAirport}: {ArrivalAirport}: {FlightClass}: {Price}";
        }
        public string SaveToFile()
        {
            return $"{FlightId},{Price},{DepartureCountry},{DestinationCountry},{DepartureDate},{DepartureAirport},{ArrivalAirport},{FlightClass}";
        }


    }

}
