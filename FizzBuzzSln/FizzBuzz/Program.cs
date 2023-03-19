namespace FizzBuzz
{

    public class Program
    {
        public static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine(FizzBuzzHelper.GetFizzBuzz(i));
            }
        }
    }
}