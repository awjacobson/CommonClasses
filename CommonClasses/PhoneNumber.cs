using System;
using System.Text.RegularExpressions;

namespace CommonClasses
{
    public class PhoneNumber
    {
        /// <summary>
        /// Country Code
        /// </summary>
        /// <remarks>
        /// The "+1", or country code is the first thing you dial to reach a phone line anywhere
        /// else in the country. It is usually not required when dialing between phone numbers
        /// that are registered in the same geographic region—that is, two numbers that have the
        /// same area code. 
        /// </remarks>
        public int? CountryCode { get; set; }

        /// <summary>
        /// Area Code
        /// </summary>
        /// <remarks>
        /// Area codes bring a call to the larger geographic region which may contain multiple
        /// towns; at the same time, large cities generally have multiple area codes.
        /// 
        /// There are two basic types of area codes: Local and Toll Free.Toll free area codes are
        /// 800, 844, 855, 866, 877, and 888; local area codes are all the other ones.
        /// 
        /// Then of course, there is the 900 area code which represents a "toll" number, or
        /// "pay-per-call", which many of us remember as the rather conspicuous area code.
        /// </remarks>
        public int? AreaCode { get; set; }

        /// <summary>
        /// Prefix
        /// </summary>
        /// <remarks>
        /// After the area code, you have the prefix. The prefix expectedly provides a more
        /// narrowed location of a telephone number, signifying a specific location such as a
        /// town.
        /// 
        /// The area code generally does not need to be dialed when calling another number with
        /// the same prefix.
        /// </remarks>
        public int? Prefix { get; set; }

        /// <summary>
        /// Line Number
        /// </summary>
        /// <remarks>
        /// The line number is the final and most specific code of the phone number. This code
        /// provides an exact address for connecting the call with a specific phone line. 
        /// </remarks>
        public int? LineNumber { get; set; }

        /// <summary>
        /// Converts the string representation of the phone number to its PhoneNumber equivalent.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static PhoneNumber Parse(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentNullException(nameof(text));

            var patterns = new[]
            {
                @"^(?<country>\d{1})\s?\((?<area>\d{3})\)\s?(?<prefix>\d{3})[\s,\-](?<line>\d{4})$", // 1 (573) 634-5000
                @"^(?<country>\d{1}) (?<area>\d{3}) (?<prefix>\d{3})[\s,\-](?<line>\d{4})$", // 1 573 634 5000
                @"^\((?<area>\d{3})\)\s?(?<prefix>\d{3})[\s,\-](?<line>\d{4})$", // (573) 634-5000
                @"^(?<area>\d{3}) (?<prefix>\d{3}) (?<line>\d{4})$", // 573 634 5000
                @"^(?<area>\d{3})\-(?<prefix>\d{3})\-(?<line>\d{4})$", // 573-634-5000
                @"^(?<area>\d{3})(?<prefix>\d{3})(?<line>\d{4})$" // 5736345000
            };

            Match match = null;
            foreach (var pattern in patterns)
            {
                match = new Regex(pattern).Match(text.Trim());
                if (match.Success)
                {
                    Group countryGroup = match.Groups["country"];
                    int? country = countryGroup.Success ? int.Parse(countryGroup.Value) : (int?)null;
                    int? area = int.Parse(match.Groups["area"].Value);
                    int? prefix = int.Parse(match.Groups["prefix"].Value);
                    int? line = int.Parse(match.Groups["line"].Value);
                    return new PhoneNumber
                    {
                        CountryCode = country,
                        AreaCode = area,
                        Prefix = prefix,
                        LineNumber = line
                    };
                }
            }
            return null;
        }

        public override string ToString()
        {
            return $"({AreaCode.Value.ToString("D3")}) {Prefix.Value.ToString("D3")}-{LineNumber.Value.ToString("D4")}";
        }
    }
}
