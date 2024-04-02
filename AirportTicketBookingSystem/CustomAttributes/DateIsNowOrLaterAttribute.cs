using System;
using System.ComponentModel.DataAnnotations;

namespace AirportTicketBookingSystem.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property |
      AttributeTargets.Field, AllowMultiple = false)]
    sealed public class DateIsNowOrLaterAttribute : ValidationAttribute
    {

        public override bool IsValid(object? value)
        {
            DateTime? date = Convert.ToDateTime(value);
            Console.WriteLine(DateTime.Now + ";" + date);
            return date >= DateTime.Now;
        }
    }
}
