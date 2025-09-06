
namespace CarWash.models
{
    public class Car
    {
        public CarType Type { get; }
        public int RemainingWashTime { get; set; }

        public Car(CarType type)
        {
            Type = type;
            RemainingWashTime = type switch
            {
                CarType.Passenger => 5,
                CarType.Suv => 8,
                CarType.Van => 10,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}