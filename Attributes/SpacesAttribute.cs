using System.ComponentModel.DataAnnotations;

namespace Recruitment.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class SpacesAttribute : ValidationAttribute
    {
        private int _maxSpaces;

        public SpacesAttribute(int maxSpaces)
        {
            _maxSpaces = maxSpaces;
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
}
