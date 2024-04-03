using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace AirportTicketBookingSystem.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property |
      AttributeTargets.Field, AllowMultiple = false)]
    public class DateIsNowOrLaterAttribute : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DateTime? date = Convert.ToDateTime(value);
            Console.WriteLine(DateTime.Now + ";" + date);
            return date >= DateTime.Now ? ValidationResult.Success : new ValidationResult($"{validationContext.MemberName} should be now or in the future.");
        }
    }
}
