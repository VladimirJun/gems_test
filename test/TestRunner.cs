namespace CarWash.test
{
    public static class TestRunner
    {
        public static void RunAll()
        {
            var tests = new CarWashTests();

            RunTest(tests.RevenueCalculation_WorksCorrectly, nameof(tests.RevenueCalculation_WorksCorrectly));
            RunTest(tests.QueueProcessing_WorksCorrectly, nameof(tests.QueueProcessing_WorksCorrectly));
            RunTest(tests.AddingCars_Fills_Queue_When_Stations_Full, nameof(tests.AddingCars_Fills_Queue_When_Stations_Full));
            RunTest(tests.ZeroCars_NoRevenue, nameof(tests.ZeroCars_NoRevenue));
            RunTest(tests.NegativeStations_ThrowsException, nameof(tests.NegativeStations_ThrowsException));
            RunTest(tests.CarWithUnknownType_ThrowsException, nameof(tests.CarWithUnknownType_ThrowsException));

        }

        private static void RunTest(Action testMethod, string testName)
        {
            try
            {
                testMethod();
                Console.WriteLine($"{testName}: OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{testName}: FAIL -> {ex.Message}");
            }
        }
    }
}