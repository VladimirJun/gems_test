
using CarWash.models;

namespace CarWashTests;

public class WashPostTests
{
    [Fact]
    public void AssignCar_ShouldOccupyPost()
    {
        var post = new WashPost();
        var car = new Car(CarType.Passenger);

        post.AssignCar(car);

        Assert.False(post.IsFree);
        Assert.Equal(5, post.RemainingTime);
    }

    [Fact]
    public void Tick_ShouldFreePostAfterWash()
    {
        var post = new WashPost();
        post.AssignCar(new Car(CarType.Passenger));

        for (int i = 0; i < 5; i++)
            post.Tick();

        Assert.True(post.IsFree);
    }
}
