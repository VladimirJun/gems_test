using CarWash.models;

namespace CarWash;

class Program
{
    static void Main()
    {
        var carWash = new CarWash.service.CarWash(3); // 3 поста

        carWash.AddCar(new Car(CarType.Passenger));
        carWash.AddCar(new Car(CarType.Suv));
        carWash.AddCar(new Car(CarType.Van));
        carWash.AddCar(new Car(CarType.Passenger)); // очередь

        carWash.Simulate(20);

        Console.WriteLine($"Общая выручка: {carWash.GetRevenue()} руб.");
    }
}