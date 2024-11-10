using System.ComponentModel.DataAnnotations;

namespace Recruitment.Attributes
{
    public class CustomYearRangeAttribute: ValidationAttribute
    {
        private readonly int _minYear;
        private readonly int _maxYear;

        public CustomYearRangeAttribute(int minYear)
        {
            _minYear = minYear;
            _maxYear = DateTime.Now.Year;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"{name} must be between {_minYear} and {_maxYear}.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (int.TryParse(value.ToString(), out int graduationYear))
            {
                if (graduationYear < _minYear || graduationYear > _maxYear)
                {
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
            }
            else
            {
                return new ValidationResult("Invalid Graduation Year.");
            }

            return ValidationResult.Success;
        }
    }
}
