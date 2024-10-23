namespace ToDoList.Test;

public class UnitTest1
{
    [Fact]
    public void TestDeleni()
    {
        //Arrange
        var kalkulacka = new Calculator();

        //Act
        var result = kalkulacka.Divide(10, 5);

        //Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void TestDeleniNulou()
    {
        var kalkulacka = new Calculator();

        Assert.Throws<DivideByZeroException>(() => kalkulacka.Divide(10, 0));
    }
}


public class Calculator()
{
    public int Divide(int dividend, int divisor) => dividend / divisor;
}
