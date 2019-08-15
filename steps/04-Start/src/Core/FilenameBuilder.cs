using System;
using System.Globalization;
using System.Text;

namespace Core
{
    public class FilenameBuilder
    {
        public const string DateFormat = "yyyy-MM-dd-HH-";
        public const string Suffix = ".txt";
        public static char Separator = '-';

        public string BuildFilename(DataContext dataContext)
        {
            var date = dataContext.EventDateUtc.ToString(DateFormat, DateTimeFormatInfo.InvariantInfo);

            return string.Concat(date, dataContext.Title.ToUpper(), Separator, dataContext.Key, Suffix);
        }

        public string BuildFilenameWithStringBuilder(DataContext dataContext)
        {
            var sb = new StringBuilder();

            sb.Append(dataContext.EventDateUtc.ToString(DateFormat, DateTimeFormatInfo.InvariantInfo));
            sb.Append(dataContext.Title.ToUpper()).Append('-');
            sb.Append(dataContext.Key).Append('-');
            sb.Append(Suffix);

            return sb.ToString();
        }
    }

    public class DataContext
    {
        public string Title { get; set; }
        public string Key { get; set; }
        public DateTime EventDateUtc { get; set; }
    }
}
