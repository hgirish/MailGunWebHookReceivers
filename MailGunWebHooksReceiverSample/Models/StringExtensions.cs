using System.Text.RegularExpressions;

namespace MailGunWebHooksReceiverSample.Models
{
    public static class StringExtensions
    {
        public static string GetSubject(this string input)
        {
           input = input.Replace("\"", "'");
            Regex regex = new Regex("'Subject',[ ]*'(?<subject>.*?)']");
            Match match = regex.Match(input);
            if (match.Success)
            {
                string subject = match.Groups["subject"].Value;
                return subject;
            }
            return "";
        }
    }
}