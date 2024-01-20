using System.ComponentModel.DataAnnotations;

namespace WebAPIDemo.Models.Validations
{
    public class Shirt_EnsureCorrectSizingAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var shirt = validationContext.ObjectInstance as Shirt;

            if (shirt != null && !string.IsNullOrWhiteSpace(shirt.Gender))          //why we use IsNullOrWhiteSpace here is that there will be null values in inputs. To overcome the null problem, we use this function.
            {
                if (shirt.Gender.Equals("men", StringComparison.OrdinalIgnoreCase) && shirt.Size < 8) 
                {
                    return new ValidationResult("For men's shirts, the size has to be greater or equal to 8.");
                }
                else if (shirt.Gender.Equals("women", StringComparison.OrdinalIgnoreCase) && shirt.Size < 6) 
                {
                    return new ValidationResult("For women's shirts, the size has to be greater or equal to 6.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
