namespace Core
{
    public static class Multiplier
    {
        public static void PopulateMultiplesOfTwo(int[] data)
        {
            PopulateMultiplesOfTwo(data, data.Length);
        }

        public static void PopulateMultiplesOfTwo(int[] data, int size)
        {
            data[0] = 2;

            for (var i = 1; i < size; ++i)
            {
                data[i] = (i + 1) * 2;
            }
        }
    }
}
