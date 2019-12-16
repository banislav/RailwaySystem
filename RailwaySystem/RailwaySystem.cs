using System;
using System.Collections.Generic;
using System.Linq;

//TODO: Interfaces
namespace RailwaySystem
{
    public class RailwaySystem
    {
        private readonly List<IStation> _stations;
        private readonly List<ITrain> _trains;
        private readonly List<IRoad> _roads;
        public bool IsCrashed { get; private set; }

        public RailwaySystem(List<ITrain> trains, List<IStation> stations, List<IRoad> roads)
        {
            _stations = stations;
            _trains = trains;
            _roads = roads;
        }

        private static IRoad SearchRoad(IStation firstStation, IStation secondStation)
        {
            return firstStation.RoadList[secondStation] ?? secondStation.RoadList[firstStation];
        }

        public void InitializeTrains()
        {
            foreach (var train in _trains)
            {
                train.DepartureStation = train.Route.Peek();
                train.CurrentRoad = SearchRoad(train.Route.Dequeue(), train.Route.Peek());
                train.ArrivalStation = train.Route.Peek();
            }
        }

        public bool MakeStep()
        {
            foreach (var train in _trains)
            {
                train.DistanceTravelledOnCurrentRoad += train.Speed;
                if (train.DistanceTravelledOnCurrentRoad >= train.CurrentRoad.Length)
                {
                    train.ChangeRoad();
                }

                foreach (var t in _trains)
                {
                    if (Equals(train.CurrentRoad, t.CurrentRoad) &&
                        !t.ArrivalStation.Equals(train.ArrivalStation))
                    {
                        Console.Write(train.ArrivalStation.Name + t.ArrivalStation.Name);
                        IsCrashed = true;
                        return true;
                    }

                    if (Equals(train.CurrentRoad, t.CurrentRoad) &&
                        train.DistanceTravelledOnCurrentRoad >= t.DistanceTravelledOnCurrentRoad &&
                        train.Speed < t.Speed ||
                        train.DistanceTravelledOnCurrentRoad <= t.DistanceTravelledOnCurrentRoad &&
                        t.Speed < train.Speed &&
                        train.ArrivalStation.Equals(t.ArrivalStation))
                    {
                        IsCrashed = true;
                        return true;
                    }
                    
                    if (_trains.All(tr => tr.ReachedFinalDestination))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
    }
}