using System;

namespace RailwaySystem
{
    class Program
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
                    Console.WriteLine("Crash, {0}", counter);
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