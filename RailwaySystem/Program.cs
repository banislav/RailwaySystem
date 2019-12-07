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
                if (result)
                {
                    Console.Write("Crash, {0}", counter);
                    break;
                }

                counter++;
            }
        }
    }
}