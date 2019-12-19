using System.Collections.Generic;

namespace RailwaySystem
{
    public interface ITrain
    {
        int Speed { get; }

        bool ReachedFinalDestination { get; set; }
//        string StartPosition { get; } 
        int DistanceTravelledOnCurrentRoad { get; set; } 
        Queue<IStation> Route { get; set; } 
//        int Direction { get; }
        IStation DepartureStation { get; set; }
        IStation ArrivalStation { get; set; }
        IRoad CurrentRoad { get; set; }
        void ChangeRoad();
    }
}