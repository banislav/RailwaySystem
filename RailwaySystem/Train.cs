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
        }

        public Train(int speed)
        {
            Speed = speed;
            DistanceTravelledOnCurrentRoad = 0;
        }

        public int Speed { get; } 

        public int DistanceTravelledOnCurrentRoad { get; set; } 

        public Queue<IStation> Route { get; set; }
        public IStation DepartureStation { get; set; }
        public IStation ArrivalStation { get; set; }

        public IRoad CurrentRoad { get; set; }

        public void ChangeRoad()
        {
            DistanceTravelledOnCurrentRoad = DistanceTravelledOnCurrentRoad - CurrentRoad.Length;
            DepartureStation = ArrivalStation;
            Route.TryDequeue(out _);

            if (Route.TryPeek(out var arrivalStation))
            {
                ArrivalStation = arrivalStation;
            }
//            //TODO: Hashmap or dictionary
//            CurrentRoad = DepartureStation.RoadList[ArrivalStation];
            CurrentRoad = DepartureStation.RoadList.ContainsKey(ArrivalStation) ? DepartureStation.RoadList[ArrivalStation] : 
                ArrivalStation.RoadList[DepartureStation];
//            foreach (var road in ArrivalStation.RoadList)
//            {
//                foreach (var road1 in DepartureStation.RoadList)
//                {
//                    if (road1.Equals(road))
//                    {
//                        CurrentRoad = road;
//                    }
//                }
//            }

        }
    }
}