using System.Collections.Generic;

namespace RailwaySystem
{
    public class Train : ITrain
    {
        public Train(int speed, Queue<IStation> route)
        {
            Speed = speed;
            Route = route;
            DistanceTravelledOnCurrentRoad = 0;
            ReachedFinalDestination = false;
        }

        public int Speed { get; }
        
        public bool ReachedFinalDestination { get; set; }

        public int DistanceTravelledOnCurrentRoad { get; set; } 

        public Queue<IStation> Route { get; set; }
        public IStation DepartureStation { get; set; }
        public IStation ArrivalStation { get; set; }

        public IRoad CurrentRoad { get; set; }

        public void ChangeRoad()
        {
            DistanceTravelledOnCurrentRoad = DistanceTravelledOnCurrentRoad - CurrentRoad.Length;
            DepartureStation = ArrivalStation;
            
            if (!Route.TryDequeue(out _))
            {
                ReachedFinalDestination = true;
                return;
            }

            if (Route.TryPeek(out var arrivalStation))
            {
                ArrivalStation = arrivalStation;
            }
            else
            {
                ReachedFinalDestination = true;
                return;
            }
            CurrentRoad = DepartureStation.RoadList.ContainsKey(ArrivalStation) ? DepartureStation.RoadList[ArrivalStation] : 
                ArrivalStation.RoadList[DepartureStation];
        }
    }
}