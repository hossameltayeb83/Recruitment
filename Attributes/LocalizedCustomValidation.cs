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
            private readonly string _errorMessageKey;

            public LocalizedStringLengthAttribute(int maximumLength, string errorMessageKey) : base(maximumLength)
            {
                _errorMessageKey = errorMessageKey;
            }

            public override string FormatErrorMessage(string name)
            {
                var localizedErrorMessage = Localizer.GetString(_errorMessageKey);
                return string.IsNullOrEmpty(localizedErrorMessage) ? base.FormatErrorMessage(name) : localizedErrorMessage;
            }
        }


        // Custom Required attribute with localization
        public class LocalizedRequiredAttribute : RequiredAttribute
        {
            private readonly string _errorMessageKey;
            public LocalizedRequiredAttribute(string errorMessageKey)
            {
                _errorMessageKey = errorMessageKey;
            }

            public override string FormatErrorMessage(string name)
            {
                var localizedErrorMessage = Localizer.GetString(_errorMessageKey);
                return string.IsNullOrEmpty(localizedErrorMessage) ? base.FormatErrorMessage(name) : localizedErrorMessage;
            }
        }

        // Custom RegularExpression attribute with localization
        public class LocalizedRegularExpressionAttribute : RegularExpressionAttribute
        {
            private readonly string _errorMessageKey;

            public LocalizedRegularExpressionAttribute(string pattern, string errorMessageKey) : base(pattern)
            {
                _errorMessageKey = errorMessageKey;
            }

            public override string FormatErrorMessage(string name)
            {
                var localizedErrorMessage = Localizer.GetString(_errorMessageKey);
                return string.IsNullOrEmpty(localizedErrorMessage) ? base.FormatErrorMessage(name) : localizedErrorMessage;
            }
        }

        #endregion

        #region Custom Attributes

        public class SpacesAttribute : ValidationAttribute
        {
            private readonly int _maxSpaces;
            private readonly string _errorMessageKey;

            public SpacesAttribute(int maxSpaces, string errorMessageKey)
            {
                _maxSpaces = maxSpaces;
                _errorMessageKey = errorMessageKey;
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

            public override string FormatErrorMessage(string name)
            {
                var localizedErrorMessage = Localizer.GetString(_errorMessageKey);
                return string.IsNullOrEmpty(localizedErrorMessage) ? base.FormatErrorMessage(name) : localizedErrorMessage;
            }
        }

        public class NotAllowFutureDate : ValidationAttribute
        {
            private readonly string _errorMessageKey;

            public NotAllowFutureDate(string errorMessageKey)
            {
                _errorMessageKey = errorMessageKey;
            }

            public override bool IsValid(object value)
            {
                return value is DateTime date && date < DateTime.Now;
            }

            public override string FormatErrorMessage(string name)
            {
                var localizedErrorMessage = Localizer.GetString(_errorMessageKey);
                return string.IsNullOrEmpty(localizedErrorMessage) ? base.FormatErrorMessage(name) : localizedErrorMessage;
            }
        }
        public class ValidOption : ValidationAttribute
        {
            public ValidOption(string errorMessageKey)
            {
                ErrorMessage = Localizer.GetString(errorMessageKey);
            }

            public override bool IsValid(object value)
            {
                decimal? choice = value as decimal?;
                return choice is not null && choice !=0;
            }
        }

        public class MinimumAgeAttribute : ValidationAttribute
        {
            private readonly int _minimumAge;
            private readonly string _errorMessageKey;

            public MinimumAgeAttribute(int minimumAge, string errorMessageKey)
            {
                _minimumAge = minimumAge;
                _errorMessageKey = errorMessageKey;
            }

            public override bool IsValid(object value)
            {
                if (value is DateTime birthDate)
                {
                    return birthDate.AddYears(_minimumAge) <= DateTime.Now;
                }
                return false;
            }

            public override string FormatErrorMessage(string name)
            {
                var localizedErrorMessage = Localizer.GetString(_errorMessageKey);
                return string.IsNullOrEmpty(localizedErrorMessage) ? base.FormatErrorMessage(name) : localizedErrorMessage;
            }
        }

        public class CustomYearRangeAttribute : ValidationAttribute
        {
            private readonly int _minYear;
            private readonly int _maxYear;
            private readonly string _errorMessageKey;

            public CustomYearRangeAttribute(int minYear, string errorMessageKey)
            {
                _minYear = minYear;
                _maxYear = DateTime.Now.Year;
                _errorMessageKey = errorMessageKey;
            }

            public override string FormatErrorMessage(string name)
            {
                var localizedErrorMessage = Localizer.GetString(_errorMessageKey);
                return string.IsNullOrEmpty(localizedErrorMessage) ? base.FormatErrorMessage(name) : localizedErrorMessage;
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
