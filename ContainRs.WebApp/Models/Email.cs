using System.Text.RegularExpressions;

namespace ContainRs.WebApp.Models
{
    public class Email
    {
        private static readonly Regex EmailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public Email(string value)
        {
            if(!EmailRegex.IsMatch(value))
            {
                throw new ArgumentException("Email inválido.");
            }
            Value = value;
        }

        public string Value { get; }
    }
}
