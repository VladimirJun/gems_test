using CarWash.models;

namespace CarWash.interfaces;

public interface ICarWash
{
    void AddCar(Car car);
    void Simulate(int minutes);
    decimal GetRevenue();
}