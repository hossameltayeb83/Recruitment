using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography;

namespace Recruitment.Extensions
{
    public static class StringExtensions
    {
        public static string Sha256Hex(this string value)
        {
            using (var sha256Hash = SHA256.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                var data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                var sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data
                // and format each one as a hexadecimal string.
                for (var i = 0; i < data.Length; i++) sBuilder.Append(data[i].ToString("x2"));

                return sBuilder.ToString();
            }
        }

        public static decimal? ToId(this string value)
        {
            return !value.IsEmpty() ? value.Replace("O", ".", StringComparison.InvariantCulture).ToDecimal() : null;
            //return BytesToDecimal(Convert.FromBase64String(value));
        }

        private static decimal BytesToDecimal(byte[] bytes)
        {
            //check that it is even possible to convert the array
            if (bytes.Length != 16)
                throw new Exception("A decimal must be created from exactly 16 bytes");
            //make an array to convert back to int32's
            var bits = new int[4];
            for (var i = 0; i <= 15; i += 4)
                //convert every 4 bytes into an int32
                bits[i / 4] = BitConverter.ToInt32(bytes, i);
            //Use the decimal's new constructor to
            //create an instance of decimal
            return new decimal(bits);
        }

        public static string Repeat(string str, int length)
        {
            var sb = new StringBuilder(str.Length * length);
            for (var i = 0; i < length; i++)
                sb.Append(str);
            return sb.ToString();
        }

        public static bool IsEmpty(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }


        public static string EmptyTo(this string value, string to)
        {
            if (value.IsEmpty()) return to;
            return value;
        }

        public static int? ToInt(this string value)
        {
            int? result = null;
            if (!string.IsNullOrEmpty(value))
            {
                var accepted = int.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var parsed);
                if (accepted)
                    result = parsed;
            }

            return result;
        }

        public static decimal? ToDecimal(this string value)
        {
            decimal? result = null;
            if (!string.IsNullOrEmpty(value))
            {
                var accepted = decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var parsed);
                if (accepted)
                    result = parsed;
            }

            return result;
        }

        public static DateTimeOffset? ToDate(this string value)
        {
            DateTimeOffset? result = null;
            if (!string.IsNullOrEmpty(value))
            {
                var accepted = DateTimeOffset.TryParse(value, CultureInfo.InvariantCulture, default, out var parsed);
                if (accepted)
                    result = parsed;
            }

            return result;
        }

        public static string RemoveTashkeel(this string value)
        {
            string formattedString = value.Replace("أ", "ا").Replace("إ", "ا").Replace("آ", "ا")
                                          .Replace("ى", "ي").Replace("~", "").Replace("ؤ", "و");
            formattedString = Regex.Replace(formattedString, @"\s+", " ");
            formattedString = Regex.Replace(formattedString, @"ه(?:\s+|$)", "ة ");
            return formattedString;
        }
    }
}
