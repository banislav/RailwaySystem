using System;

namespace RailwaySystem
{
    // ReSharper disable once ClassNeverInstantiated
    // ReSharper disable once ArrangeTypeModifiers
    internal static class Program
    {
        static void Main()
        {
            var config = new Configurator();
            var railwaySystem = config.CreateRailwaySystem();
            var counter = 1;
            railwaySystem.InitializeTrains();
            while (true)
            {
                var result = railwaySystem.MakeStep();

                if (result && railwaySystem.IsCrashed)
                {
                    Console.WriteLine($"Crash on {counter} turn");
                    Console.WriteLine(railwaySystem.GetCrashInfo());
                    break;
                }

                if (result && !railwaySystem.IsCrashed)
                {
                    Console.WriteLine("Ok");
                    break;
                }

                counter++;
            }
        }
    }
}