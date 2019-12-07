using System;

namespace RailwaySystem
{
    public class Road : IRoad, IEquatable<IRoad>
    {
        public int Length{ get; }
        public IStation DepartureStation { get; set; }
        public IStation ArrivalStation { get; set; }

        public Road(int length)
        {
            Length = length;
        }

        public bool Equals(IRoad other)
        {
            return other != null && Length == other.Length;
        }
    }
}