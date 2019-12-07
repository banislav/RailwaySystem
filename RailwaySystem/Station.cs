using System.Collections.Generic;

namespace RailwaySystem
{
    public class Station : IStation
    {
        public string Name { get; }
        public Dictionary<IStation,IRoad> RoadList { get; }

        public Station(string name, Dictionary<IStation,IRoad> roadList)
        {
            Name = name;
            RoadList = roadList;
        }

        public Station(string name)
        {
            Name = name;
        }

        public bool Equals(IStation other)
        {
            return Name == other?.Name;
        }
    }
}