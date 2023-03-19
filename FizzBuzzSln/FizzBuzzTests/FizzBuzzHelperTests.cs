using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzz.Tests
{
    [TestClass()]
    public class FizzBuzzHelper_GetFizzBuzzShould
    {
        [TestMethod]
        public void Return1_When1()
        {
            //Given --> initialisation de l'état
            int input = 1;

            //When --> Action
            string actual = FizzBuzzHelper.GetFizzBuzz(input);

            //Then --> assertion
            Assert.AreEqual("1", actual);
        }

        [TestMethod]
        [DataRow(2,"2")]
        [DataRow(4,"4")]
        [DataRow(13,"13")]
        [DataRow(19, "19")]
        [DataRow(31, "31")]
        [DataRow(92, "92")]
        public void ReturnNumber_WhenNotModulo3Or5(int input, string expextedOutput)
        {
            //Given --> initialisation de l'état

            //When --> Action
            string actual = FizzBuzzHelper.GetFizzBuzz(input);

            //Then --> assertion
            Assert.AreEqual(expextedOutput, actual);
        }

        [TestMethod]
        public void ReturnFizz_When3()
        {
            //Given --> initialisation de l'état
            int input = 3;

            //When --> Action
            string actual = FizzBuzzHelper.GetFizzBuzz(input);

            //Then --> assertion
            Assert.AreEqual("Fizz", actual);
        }

        [TestMethod]
        [DataRow(6, "Fizz")]
        [DataRow(12, "Fizz")]
        [DataRow(21, "Fizz")]
        [DataRow(57, "Fizz")]
        [DataRow(84, "Fizz")]
        public void ReturnFizz_WhenModulo3(int input, string expextedOutput)
        {
            //Given --> initialisation de l'état

            //When --> Action
            string actual = FizzBuzzHelper.GetFizzBuzz(input);

            //Then --> assertion
            Assert.AreEqual(expextedOutput, actual);
        }

        [TestMethod]
        public void ReturnBuzz_When5()
        {
            //Given --> initialisation de l'état
            int input = 5;

            //When --> Action
            string actual = FizzBuzzHelper.GetFizzBuzz(input);

            //Then --> assertion
            Assert.AreEqual("Buzz", actual);
        }

        [TestMethod]
        [DataRow(10, "Buzz")]
        [DataRow(40, "Buzz")]
        [DataRow(55, "Buzz")]
        [DataRow(70, "Buzz")]
        [DataRow(95, "Buzz")]
        public void ReturnBuzz_WhenModulo5(int input, string expextedOutput)
        {
            //Given --> initialisation de l'état

            //When --> Action
            string actual = FizzBuzzHelper.GetFizzBuzz(input);

            //Then --> assertion
            Assert.AreEqual(expextedOutput, actual);
        }

        [TestMethod]
        public void ReturnFizzBuzz_When15()
        {
            //Given --> initialisation de l'état
            int input = 15;

            //When --> Action
            string actual = FizzBuzzHelper.GetFizzBuzz(input);

            //Then --> assertion
            Assert.AreEqual("FizzBuzz", actual);
        }

        [TestMethod]
        [DataRow(15, "FizzBuzz")]
        [DataRow(30, "FizzBuzz")]
        [DataRow(45, "FizzBuzz")]
        [DataRow(60, "FizzBuzz")]
        [DataRow(75, "FizzBuzz")]
        public void ReturnFizzBuzz_WhenModulo3And5(int input, string expextedOutput)
        {
            //Given --> initialisation de l'état

            //When --> Action
            string actual = FizzBuzzHelper.GetFizzBuzz(input);

            //Then --> assertion
            Assert.AreEqual(expextedOutput, actual);
        }
    }
}