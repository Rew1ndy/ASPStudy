using System.ComponentModel.DataAnnotations;

namespace Lab10.Models
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var date = (DateTime)value;

            if (date <= DateTime.Now)
            {
                return new ValidationResult("Дата консультації має бути в майбутньому.");
            }
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                return new ValidationResult("Консультації не проводяться на вихідних.");
            }

            return ValidationResult.Success;
        }
    }

}
