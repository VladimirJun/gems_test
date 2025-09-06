using CarWash.models;

namespace ConsoleApplication1.tests;


using Xunit;

public class CarTest
{
    [Theory]
    [InlineData(CarType.Passenger, 5)]
    [InlineData(CarType.Suv, 8)]
    [InlineData(CarType.Van, 10)]
    public void Car_ShouldHaveCorrectWashTime(CarType type, int expectedTime)
    {
        var car = new Car(type);
        Assert.Equal(expectedTime, car.WashTime);
    }
}
