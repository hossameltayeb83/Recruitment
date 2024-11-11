using Recruitment.Localization;
using System.ComponentModel.DataAnnotations;

namespace Recruitment.Attributes
{
    public class LocalizedCustomValidation
    {
        #region Built-in Attributes

        // Custom StringLength attribute with localization
        public class LocalizedStringLengthAttribute : StringLengthAttribute
        {
            public LocalizedStringLengthAttribute(int maximumLength, string errorMessageKey) : base(maximumLength)
            {
                ErrorMessage = Localizer.GetString(errorMessageKey);
            }
        }

        // Custom Required attribute with localization
        public class LocalizedRequiredAttribute : RequiredAttribute
        {
            public LocalizedRequiredAttribute(string errorMessageKey)
            {
                ErrorMessage = Localizer.GetString(errorMessageKey);
            }
        }

        // Custom RegularExpression attribute with localization
        public class LocalizedRegularExpressionAttribute : RegularExpressionAttribute
        {
            public LocalizedRegularExpressionAttribute(string pattern, string errorMessageKey) : base(pattern)
            {
                ErrorMessage = Localizer.GetString(errorMessageKey);
            }
        }

        #endregion

        #region Custom Attributes

        public class SpacesAttribute : ValidationAttribute
        {
            private readonly int _maxSpaces;

            public SpacesAttribute(int maxSpaces, string errorMessageKey)
            {
                _maxSpaces = maxSpaces;
                ErrorMessage = Localizer.GetString(errorMessageKey);
            }

            public override bool IsValid(object value)
            {
                bool result = true;
                if (value != null)
                {
                    int num = 0;
                    string text = value.ToString();
                    foreach (char c in text)
                    {
                        if (c == ' ')
                        {
                            num++;
                        }
                    }

                    result = num <= _maxSpaces;
                }

                return result;
            }
        }

        public class NotAllowFutureDate : ValidationAttribute
        {
            public NotAllowFutureDate(string errorMessageKey)
            {
                ErrorMessage = Localizer.GetString(errorMessageKey);
            }

            public override bool IsValid(object value)
            {
                return value is DateTime date && date < DateTime.Now;
            }
        }

        public class MinimumAgeAttribute : ValidationAttribute
        {
            private readonly int _minimumAge;

            public MinimumAgeAttribute(int minimumAge, string errorMessageKey)
            {
                _minimumAge = minimumAge;
                ErrorMessage = Localizer.GetString(errorMessageKey);
            }

            public override bool IsValid(object value)
            {
                if (value is DateTime birthDate)
                {
                    return birthDate.AddYears(_minimumAge) <= DateTime.Now;
                }
                return false;
            }
        }

        public class CustomYearRangeAttribute : ValidationAttribute
        {
            private readonly int _minYear;
            private readonly int _maxYear;

            public CustomYearRangeAttribute(int minYear, string errorMessageKey)
            {
                _minYear = minYear;
                _maxYear = DateTime.Now.Year;
                ErrorMessage = Localizer.GetString(errorMessageKey);
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

        #endregion
    }
}
