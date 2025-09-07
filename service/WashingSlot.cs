using CarWash.models;

namespace CarWash.service
{
    // Слот на мойке: хранит машину и оставшееся время мойки
    public class WashingSlot
    {
        public Car Car { get; }
        public int RemainingTime { get; private set; }

        
        public WashingSlot(Car car)
        {
            Car = car;
            RemainingTime = car.WashDuration;
        }

        public void WorkOneMinute()
        {
            if (RemainingTime > 0)
                RemainingTime--;
        }

        public bool IsFinished => RemainingTime <= 0;
    }
}