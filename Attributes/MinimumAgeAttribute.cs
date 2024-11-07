using System.ComponentModel.DataAnnotations;

namespace Recruitment.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class MinimumAgeAttribute : ValidationAttribute
    {
        private int _minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        public override bool IsValid(object value)
        {
            if (value != null && DateTime.TryParse(value.ToString(), out var result))
            {
                return result.AddYears(_minimumAge) < DateTime.Now;
            }

            return false;
        }
    }
}
