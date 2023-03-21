using Exception;

namespace ExceptionTests;

[TestClass]
public class GetElements_Should
{
    [TestMethod]
    [ExpectedException(typeof(GrosDoigtsException))]
    public void ThrowGrosDoigtsException_WhenIndex11()
    {
        //Given
        int index = 11;
        Worker worker = new Worker();

        //When
        worker.GetElement(index);

        //Then
        //-> ExpectedException
        Assert.Fail("Si mon code passe ici, c'est un problème");
    }
}