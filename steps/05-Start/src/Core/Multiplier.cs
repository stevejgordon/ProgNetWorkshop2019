namespace Core
{
    public static class Multiplier
    {
        public static void PopulateMultiplesOfTwo(int[] data)
        {
            data[0] = 2;

            for (var i = 2; i < data.Length; ++i)
            {                
                data[i] = i * 2;
            }
        }
    }    
}
