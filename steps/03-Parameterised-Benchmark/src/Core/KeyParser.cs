using System;
using System.Linq;

namespace Core
{
    public class KeyParser
    {
        public int GetDelimiterCount(string input)
        {
            var count = input.Count(x => x == ':');

            return count;
        }

        public int GetDelimiterCountSpanBased(ReadOnlySpan<char> input)
        {
            var count = 0;
            var position = 0;

            int index;
            while ((index = input.Slice(position).IndexOf(':')) > -1)
            {
                count++;
                position += index + 1;
            }

            return count;
        }
    }
}