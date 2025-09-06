using System.Collections.Generic;
using CarWash.models;

namespace CarWash.service
{
    public class CarQueue
    {
        private Queue<Car> _queue = new Queue<Car>();

        public void Enqueue(Car car) => _queue.Enqueue(car);

        public Car? Dequeue() => _queue.Count > 0 ? _queue.Dequeue() : null;

        public int Count => _queue.Count;
    }
}