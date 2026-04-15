using System.ComponentModel.DataAnnotations;

namespace WebAPP.Model.Validations
{
    public class Shirt_EnsureCorrectSizingAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var shirt = validationContext.ObjectInstance as Shirt;
            
            if(shirt != null && !string.IsNullOrWhiteSpace(shirt.Gender))
            {
                if (shirt.Gender.Equals("men", StringComparison.OrdinalIgnoreCase) && shirt.Size < 8)
                {
                    return new ValidationResult("For Men,Men's shirt size must be at least 8");
                }
                else if(shirt.Gender.Equals("women", StringComparison.OrdinalIgnoreCase) && shirt.Size < 6)
                {
                    return new ValidationResult("For Women,Women's shirt size must be at least 6");
                }
            }
            return ValidationResult.Success;
        }

    }
}
