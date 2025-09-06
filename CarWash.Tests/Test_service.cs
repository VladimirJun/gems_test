using CarWash.models;

namespace CarWash.Tests
{
    public class CarWashTests
    {
        [Fact]
        public void RevenueCalculation_WorksCorrectly()
        {
            var wash = new CarWash.service.CarWash(2);
            wash.AddCar(new Car(CarType.Passenger)); // 5 мин
            wash.AddCar(new Car(CarType.Suv));       // 8 мин
            wash.AddCar(new Car(CarType.Van));       // очередь

            wash.Simulate(10);

            // Passenger отработал все 5 минут
            // Suv отработал все 8 минут
            // Van заехал на 6-й минуте и отработал 5 минут (с 6-й по 10-ю)
            decimal expectedRevenue = (5 + 8 + 5) * 30; // 540

            Assert.Equal(expectedRevenue, wash.GetRevenue());
        }

        [Fact]
        public void QueueProcessing_WorksCorrectly()
        {
            var wash = new CarWash.service.CarWash(1);
            wash.AddCar(new Car(CarType.Passenger)); // 5 мин
            wash.AddCar(new Car(CarType.Suv));   // очередь

            wash.Simulate(5); // первая машина закончилась
            wash.Simulate(3); // вторая машина моется 3 мин

            // Должна быть 8*30 выручка после 8 минут работы одной машины
            Assert.Equal(8 * 30, wash.GetRevenue());
        }

        [Fact]
        public void AddingCars_Fills_Queue_When_Stations_Full()
        {
            var wash = new CarWash.service.CarWash(2);
            var car1 = new Car(CarType.Passenger);
            var car2 = new Car(CarType.Suv);
            var car3 = new Car(CarType.Van);

            wash.AddCar(car1); // на станции 1
            wash.AddCar(car2); // на станции 2
            wash.AddCar(car3); // очередь

            wash.Simulate(1); // 1 минута

            // За 1 минуту проработали две машины на станциях → 2 минуты суммарного времени
            Assert.Equal(2, wash.GetRevenue() / 30); 

            // Проверим, что третья машина все еще в очереди
            Assert.Equal(1, wash.QueueLen()); 
            
        }
        [Fact]
        public void ZeroCars_NoRevenue()
        {
            var wash = new CarWash.service.CarWash(3);
            var len = wash.QueueLen();
            wash.Simulate(10); // нет машин
            Assert.Equal(0, wash.GetRevenue());
            Assert.Equal(0,len);
        }

        [Fact]
        public void NegativeStations_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var wash = new CarWash.service.CarWash(-1);
            });
        }

        [Fact]
        public void CarWithUnknownType_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var badCar = new Car((CarType)999);
            });
        }
    }
}