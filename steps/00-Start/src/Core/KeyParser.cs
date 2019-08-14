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
    }
}