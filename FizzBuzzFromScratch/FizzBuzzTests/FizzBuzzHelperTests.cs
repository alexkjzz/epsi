using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzz.Tests
{
    [TestClass()]
    public class FizzBuzzHelper_GetFizzBuzzShould
    {
        [TestMethod]
        public void ReturnX_WhenX()
        {
            //Given --> initialisation de l'état
            int input = X;

            //When --> Action
            string actual = FizzBuzzHelper.GetFizzBuzz(input);

            //Then --> assertion
            Assert.AreEqual("X", actual);
        }

    }
}