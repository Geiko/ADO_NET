using System.Text.RegularExpressions;

namespace ADO.NET22
{
    /// <summary>
    /// It represents extension method.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// It validates e-mail string. 
        /// </summary>
        /// <param name="input">It is a string to validate.</param>
        /// <returns></returns>
        public static bool IsValidEmail(this string input)
        {
            Regex regEx = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            return regEx.IsMatch(input);
        }
    }
}
