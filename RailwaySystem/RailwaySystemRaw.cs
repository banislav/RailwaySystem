using System;
using System.Collections.Generic;

namespace RailwaySystem
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class RailwaySystemRaw
    {
        // ReSharper disable MemberCanBePrivate.Global
        // ReSharper disable CollectionNeverUpdated.Global
        // ReSharper disable UnusedAutoPropertyAccessor.Global
        public List<TrainRaw> Trains { get; set; }
        public List<string> Stations { get; set; }
        public List<RoadRaw> Roads { get; set; }
        // ReSharper restore UnusedAutoPropertyAccessor.Global
        // ReSharper restore CollectionNeverUpdated.Global
        // ReSharper restore MemberCanBePrivate.Global


//        public RailwaySystemRaw()
//        {
//            
//        }

        public RailwaySystem ConvertToRailwaySystem()
        {
            var trainsTemp = new List<ITrain>();
            var stationsTemp = new List<IStation>();
            var roadsTemp = new List<IRoad>();

            stationsTemp = ConvertStations(stationsTemp);
            roadsTemp = ConvertRoads(stationsTemp, roadsTemp);
            trainsTemp = ConvertTrains(stationsTemp, trainsTemp);

            var railwaySystem = new RailwaySystem(trainsTemp, stationsTemp, roadsTemp);
            return railwaySystem;
        }
        //TODO: use ConvertRoads to create RoadList for each station
        private List<IStation> ConvertStations(List<IStation> stationsTemp)
        {
            foreach (var stationName in Stations)
            {
                var station = new Station(stationName, new Dictionary<IStation, IRoad>());
                stationsTemp.Add(station);
            }
            return stationsTemp;
        }

        private List<IRoad> ConvertRoads(IReadOnlyCollection<IStation> stationsTemp, List<IRoad> roadsTemp)
        {
            foreach (var roadRaw in Roads)
            {
                var road = new Road(roadRaw.Length);
                foreach (var station in stationsTemp)
                {
                    if (station.Name.Equals(roadRaw.ArrivalStation))
                    {
                        road.ArrivalStation = station;
//                        if(station.RoadList.ContainsValue(road))
//                        {
//                            station.RoadList.Add(road.DepartureStation, road);
//                        }
                    }

                    if (station.Name.Equals(roadRaw.DepartureStation))
                    {
                        road.DepartureStation = station;
//                        if (road.ArrivalStation != null) 
//                        {
//                            station.RoadList.Add(road.ArrivalStation, road);
//                        }
                    }
                }

                if (road.ArrivalStation != null && road.DepartureStation != null)
                {
                    road.ArrivalStation.RoadList[road.DepartureStation] = road;
                    road.DepartureStation.RoadList[road.ArrivalStation] = road;
                    roadsTemp.Add(road);    
                }
                
            }
            return roadsTemp;
        }

        private List<ITrain> ConvertTrains(IReadOnlyCollection<IStation> stationsTemp, List<ITrain> trainsTemp)
        {
            foreach (var trainRaw in Trains)
            {
                var train = new Train(trainRaw.Speed, new Queue<IStation>());
                foreach (var stationName in trainRaw.Route)
                {
                    foreach (var station in stationsTemp)
                    {
                        if (stationName.Equals(station.Name))
                        {
                            train.Route.Enqueue(station);
                        }
                    }
                }

                trainsTemp.Add(train);
            }
            return trainsTemp;
        }
        
    }
}