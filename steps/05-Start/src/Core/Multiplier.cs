namespace Core
{
    public static class Multiplier
    {
        public static void CalculateMultiplesOfTwo(int[] data, int size)
        {
            data[0] = 2;

            for (int i = 2; i < size; ++i)
            {                
                data[i] = i * 2;
            }
        }
    }    
}
