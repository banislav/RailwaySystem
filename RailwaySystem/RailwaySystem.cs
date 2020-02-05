using System;
using System.Collections.Generic;
using System.Linq;

namespace RailwaySystem
{
    public class RailwaySystem
    {
        // ReSharper disable NotAccessedField.Local
        private readonly List<IStation> _stations;
        private readonly List<ITrain> _trains;
        private readonly List<IRoad> _roads;
        // ReSharper restore NotAccessedField.Local
        public bool IsCrashed { get; private set; }

        private IRoad _crashRoad;

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

        public string GetCrashInfo()
        {
            return IsCrashed
                ? $"Crashed between {_crashRoad.DepartureStation.Name} and {_crashRoad.ArrivalStation.Name} stations"
                : "";
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

        private bool IsTrainsCrashed(ITrain train1, ITrain train2)
        {
            if (train1.Equals(train2))
            {
                return false;
            }
            if (!train1.CurrentRoad.Equals(train2.CurrentRoad)) 
            {
                return false;
            }

            if (!train1.ArrivalStation.Equals(train2.ArrivalStation))
            {
                return true;
            }

            if (train1.DistanceTravelledOnCurrentRoad == train2.DistanceTravelledOnCurrentRoad)
            {
                return true;
            }

            ITrain leftTrain, rightTrain;
            if (train1.DistanceTravelledOnCurrentRoad > train2.DistanceTravelledOnCurrentRoad)
            {
                leftTrain = train2;
                rightTrain = train1;
            }
            else
            {
                leftTrain = train1;
                rightTrain = train2;
            }

            var oncomingSpeed = leftTrain.Speed - rightTrain.Speed;
            if (oncomingSpeed <= 0)
            {
                return false;
            }

            var turnsLeftOnCurrentRoad = (double) leftTrain.DistanceTravelledOnCurrentRoad / leftTrain.Speed;
            var distanceBetweenTrains =
                rightTrain.DistanceTravelledOnCurrentRoad - leftTrain.DistanceTravelledOnCurrentRoad;
            var turnsToCrash = (double) distanceBetweenTrains / oncomingSpeed;

            return turnsLeftOnCurrentRoad >= turnsToCrash;
        }

        private bool CrashCheck(ITrain train1, ITrain train2)
        {
            if (!IsTrainsCrashed(train1, train2))
            {
                return false;
            }
            
            _crashRoad = train1.CurrentRoad;
            IsCrashed = true;
            return true;

        }
        
        public bool MakeStep()
        {
            foreach (var train1 in _trains)
            {
                train1.DistanceTravelledOnCurrentRoad += train1.Speed;
                if (train1.DistanceTravelledOnCurrentRoad >= train1.CurrentRoad.Length)
                {
                    train1.ChangeRoad();
                }
                
                if (_trains.Any(train2 => CrashCheck(train1, train2) || _trains.All(train => train.ReachedFinalDestination)))
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}