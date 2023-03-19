namespace FizzBuzz
{
    public class FizzBuzzHelper
    {
        public static string GetFizzBuzz(int i)
        {
            //Pouvez vous faire mieux ?

            int[] fizzBuzzInt = new int[] { 15, 30, 45, 60, 75, 90 };
            if (fizzBuzzInt.Contains(i))
            {
                return "FizzBuzz";
            }

            int[] buzzInt = new int[] { 5, 10, 20, 25, 35, 40, 50, 55, 65, 70, 80, 85, 95, 100 };
            if (buzzInt.Contains(i))
            {
                return "Buzz";
            }

            int[] fizzInt = new int[] { 3, 6, 9, 12, 18, 21, 24, 27, 33, 36, 39, 42, 48, 51, 54, 57, 63, 66, 69, 72, 78, 81, 84, 87, 93, 96, 99 };
            if (fizzInt.Contains(i))
            {
                return "Fizz";
            }

            return i.ToString();

        }
    }
}