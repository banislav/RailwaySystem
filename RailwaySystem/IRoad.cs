namespace RailwaySystem
{
    public interface IRoad
    {
        int Length { get;}
        IStation DepartureStation { get; set; }
        IStation ArrivalStation { get; set; }
    }
}