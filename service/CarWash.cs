using CarWash.interfaces;
using CarWash.models;

namespace CarWash.service
{
    public class CarWash : ICarWash
    {
        private readonly int _stations;
        private readonly List<Car?> _stationsList;
        private readonly CarQueue _queue;
        private decimal _revenue;

        public CarWash(int stations)
        {
            if (stations < 0)
                throw new ArgumentOutOfRangeException(nameof(stations), "Number of stations cannot be negative");
            _stations = stations;
            _stationsList = new List<Car?>(new Car[stations]);
            _queue = new CarQueue();
            _revenue = 0;
        }

        public void AddCar(Car car)
        {
            for (int i = 0; i < _stations; i++)
            {
                if (_stationsList[i] == null)
                {
                    _stationsList[i] = car;
                    return;
                }
            }

            _queue.Enqueue(car);
        }

        public void Simulate(int minutes)
        {
            for (int t = 0; t < minutes; t++)
            {
                for (int i = 0; i < _stations; i++)
                {
                    if (_stationsList[i] != null)
                    {
                        _stationsList[i]!.RemainingWashTime--;
                        _revenue += 30;

                        if (_stationsList[i]!.RemainingWashTime <= 0)
                        {
                            _stationsList[i] = null;
                        }
                    }
                }

                for (int i = 0; i < _stations; i++)
                {
                    if (_stationsList[i] == null && _queue.Count > 0)
                    {
                        _stationsList[i] = _queue.Dequeue();
                    }
                }
            }
        }

        public decimal GetRevenue() => _revenue;
        public decimal QueueLen() => _queue.Count;
    }
        
}