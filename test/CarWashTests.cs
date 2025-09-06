using CarWash.models;

namespace CarWash.test
{
    public class CarWashTests
    {
        public void RevenueCalculation_WorksCorrectly()
        {
            var wash = new CarWash.service.CarWash(2);
            wash.AddCar(new Car(CarType.Passenger)); // 5 мин
            wash.AddCar(new Car(CarType.Suv));       // 8 мин
            wash.AddCar(new Car(CarType.Van));       // очередь

            wash.Simulate(10);

            decimal expectedRevenue = (5 + 8 + 5) * 30; // 540

            if (wash.GetRevenue() != expectedRevenue)
                throw new Exception($"RevenueCalculation_WorksCorrectly failed: expected {expectedRevenue}, got {wash.GetRevenue()}");
        }

        public void QueueProcessing_WorksCorrectly()
        {
            var wash = new CarWash.service.CarWash(1);
            wash.AddCar(new Car(CarType.Passenger)); 
            wash.AddCar(new Car(CarType.Suv));       

            wash.Simulate(5);
            wash.Simulate(3);

            if (wash.GetRevenue() != 8 * 30)
                throw new Exception($"QueueProcessing_WorksCorrectly failed: expected {8*30}, got {wash.GetRevenue()}");
        }

        public void AddingCars_Fills_Queue_When_Stations_Full()
        {
            var wash = new CarWash.service.CarWash(2);
            var car1 = new Car(CarType.Passenger);
            var car2 = new Car(CarType.Suv);
            var car3 = new Car(CarType.Van);

            wash.AddCar(car1);
            wash.AddCar(car2);
            wash.AddCar(car3);

            wash.Simulate(1);

            if (wash.GetRevenue() / 30 != 2)
                throw new Exception($"AddingCars_Fills_Queue_When_Stations_Full failed: expected 2, got {wash.GetRevenue()/30}");

            if (wash.QueueLen() != 1)
                throw new Exception($"AddingCars_Fills_Queue_When_Stations_Full failed: expected queue length 1, got {wash.QueueLen()}");
        }

        public void ZeroCars_NoRevenue()
        {
            var wash = new CarWash.service.CarWash(3);
            var len = wash.QueueLen();
            wash.Simulate(10);

            if (wash.GetRevenue() != 0)
                throw new Exception($"ZeroCars_NoRevenue failed: expected 0, got {wash.GetRevenue()}");

            if (len != 0)
                throw new Exception($"ZeroCars_NoRevenue failed: expected queue length 0, got {len}");
        }

        public void NegativeStations_ThrowsException()
        {
            try
            {
                var wash = new CarWash.service.CarWash(-1);
                throw new Exception("NegativeStations_ThrowsException failed: exception not thrown");
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }

        public void CarWithUnknownType_ThrowsException()
        {
            try
            {
                var badCar = new Car((CarType)999);
                throw new Exception("CarWithUnknownType_ThrowsException failed: exception not thrown");
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }
    }
    
}
