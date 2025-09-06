#nullable enable
namespace CarWash.models

{
    public class WashPost
    {
        public Car? CurrentCar { get; private set; }
        public int RemainingTime { get; private set; }
        public bool IsFree => CurrentCar == null;

        public void AssignCar(Car car)
        {
            if (!IsFree) throw new InvalidOperationException("Филиал занят!");
            CurrentCar = car;
            RemainingTime = car.WashTime;
        }

        public void Tick()
        {
            if (CurrentCar == null) return;

            RemainingTime--;
            if (RemainingTime <= 0)
            {
                CurrentCar = null;
                RemainingTime = 0;
            }
        }
    }
}