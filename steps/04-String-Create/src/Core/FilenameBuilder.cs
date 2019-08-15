using System;
using System.Globalization;
using System.Text;

namespace Core
{
    public class FilenameBuilder
    {
        public const string DateFormat = "yyyy-MM-dd-HH-";
        public const string Suffix = ".txt";

        private static ReadOnlySpan<char> DateFormatSpan => new[] { 'y', 'y', 'y', 'y', '-', 'M', 'M', '-', 'd', 'd', '-', 'H', 'H', '-' };
        private static ReadOnlySpan<char> SuffixSpan => new[] { '.', 't', 'x', 't' };

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

        public string BuildFilenameWithStringCreate(DataContext dataContext)
        {
            var length = DateFormat.Length +
                         dataContext.Title.Length + 1 + // includes separator
                         dataContext.Key.Length + 
                         Suffix.Length;

            return string.Create(length, dataContext, (span, state) =>
            {
                var position = 0;

                state.EventDateUtc.TryFormat(span, out var bytesWritten, DateFormatSpan, CultureInfo.InvariantCulture);
                position += bytesWritten;

                MemoryExtensions.ToUpperInvariant(state.Title, span.Slice(position));
                position += state.Title.Length;

                span[position++] = Separator;

                state.Key.AsSpan().CopyTo(span.Slice(position));
                position += state.Key.Length;

                SuffixSpan.CopyTo(span.Slice(position));
            });
        }
    }

    public class DataContext
    {
        public string Title { get; set; }
        public string Key { get; set; }
        public DateTime EventDateUtc { get; set; }
    }
}
