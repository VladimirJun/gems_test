namespace CarWash.models
{
    public class Car
    {
        public CarType Type { get; }
        public int WashDuration { get; } // Сколько минут требуется на мойку

        public Car(CarType type)
        {
            Type = type;
            WashDuration = type switch
            {
                CarType.Passenger => 5,
                CarType.Suv => 8,
                CarType.Van => 10,
                _ => throw new ArgumentOutOfRangeException(nameof(type), "Unknown car type")
            };
        }
    }
}