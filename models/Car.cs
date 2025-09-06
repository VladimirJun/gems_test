namespace CarWash.models
{
    public class Car(CarType type)
    {
        public CarType Type { get; } = type;
        public int WashTime { get; } = type switch
        {
            CarType.Passenger => 5,
            CarType.Suv => 8,
            CarType.Van => 10,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}