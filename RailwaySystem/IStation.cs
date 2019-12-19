using System;
using System.Collections.Generic;

namespace RailwaySystem
{
    public interface IStation : IEquatable<IStation>
    {
        string Name { get; }
        Dictionary<IStation,IRoad> RoadList { get; }
        new bool Equals(IStation other);
    }
}