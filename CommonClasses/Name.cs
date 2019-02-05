using System.Text;

namespace CommonClasses
{
    public class Name
    {
        public string First { get; set; }
        public string Middle { get; set; }
        public string Last { get; set; }

        public string Format(Formats? format = Formats.FirstLast)
        {
            return format == Formats.LastFirst
                ? FormatLastFirst()
                : FormatFirstLast();
        }

        protected string FormatFirstLast()
        {
            var sb = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(First))
            {
                sb.Append(First);
                sb.Append(" ");
            }

            if (!string.IsNullOrWhiteSpace(Middle))
            {
                sb.Append(Middle);
                sb.Append(" ");
            }

            if (!string.IsNullOrWhiteSpace(Last))
            {
                sb.Append(Last);
                sb.Append(" ");
            }

            return sb.ToString().TrimEnd(' ');
        }

        protected string FormatLastFirst()
        {
            var sb = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(Last))
            {
                sb.Append(Last);
                sb.Append(", ");
            }

            if (!string.IsNullOrWhiteSpace(First))
            {
                sb.Append(First);
                sb.Append(" ");
            }

            if (!string.IsNullOrWhiteSpace(Middle))
            {
                sb.Append(Middle);
                sb.Append(" ");
            }

            return sb.ToString().TrimEnd(' ', ',');
        }

        public enum Formats
        {
            FirstLast,
            LastFirst
        }
    }
}