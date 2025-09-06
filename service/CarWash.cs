
using CarWash.models;

namespace CarWash.service

{
    public class CarWash
    {
        private readonly Queue<Car> _queue = new();
        private readonly List<WashPost> _posts;
        private int _timeElapsed;
        private int _moneyEarned;

        public CarWash(int postCount)
        {
            if (postCount <= 0) throw new ArgumentException("Должен быть хотя бы один филиал");
            _posts = Enumerable.Range(0, postCount).Select(_ => new WashPost()).ToList();
        }

        public void AddCar(Car car) => _queue.Enqueue(car);

        public void Tick()
        {
            _timeElapsed++;

            foreach (var post in _posts)
                post.Tick();

            foreach (var post in _posts.Where(p => p.IsFree))
            {
                if (_queue.Count > 0)
                {
                    var car = _queue.Dequeue();
                    post.AssignCar(car);
                    _moneyEarned += car.WashTime * 30;
                }
            }
        }

        public int GetTotalRevenue() => _moneyEarned;
        public int GetTotalTime() => _timeElapsed;
        public int GetQueueLength() => _queue.Count;
    }
}