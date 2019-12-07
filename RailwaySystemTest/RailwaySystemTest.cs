using Xunit;

namespace RailwaySystemTest
{
    public class RailwaySystemUnitTest
    {
        [Fact]
        public void Test()
        {
            object lol = null;
            var kek = lol?.ToString();
            int a = 5;
        }
//        [Fact]
//        public void SearchRoadTest()
//        {
//            var road1 = new Road(1);
//            var road2 = new Road(25);
//            var road3 = new Road(17);
//            var road4 = new Road(15);
//            
//            var station1 = new Station("1", new List<Road>{road1, road4});
//            var station2 = new Station("2", new List<Road>{road1, road2});
//            var station3 = new Station("3", new List<Road>{road2, road3});
//            var station4 = new Station("4", new List<Road>{road3, road4});
//            
//            var trainsList1 = new Queue<IStation>();
//            trainsList1.Enqueue(station1);
//            trainsList1.Enqueue(station2);
//            trainsList1.Enqueue(station3);
//            trainsList1.Enqueue(station4);
//            
//            var trainsList2 = new Queue<IStation>();
//            trainsList2.Enqueue(station4);
//            trainsList2.Enqueue(station3);
//            trainsList2.Enqueue(station2);
//            trainsList2.Enqueue(station1);
//
//            var stationList = new List<Station> {station1, station2, station3, station4};
//            var trainList = new List<Train>
//            {
//                new Train(20, trainsList1),
//                new Train(17, trainsList2)
//            };
//            var railwaySystem = new RailwaySystem.RailwaySystem(trainList, stationList);
//
//            var result = railwaySystem.SearchRoad("2", "3");
//            Assert.Equal(road2, result);
//        }
//
//
//        [Fact]
//        public void NullTest()
//        {
//            var road1 = new Road(1);
//            var road4 = new Road(15);
//            
//            var station1 = new Station("1", new List<Road>{road1, road4});
//            Assert.False(station1.Equals(null));
//        }
//
//        [Fact]
//        public void ChangeRoadTest()
//        {
//            var road1 = new Road(1);
//            var road2 = new Road(25);
//            var road3 = new Road(17);
//            var road4 = new Road(15);
//            
//            var station1 = new Station("1", new List<Road>{road1, road4});
//            var station2 = new Station("2", new List<Road>{road1, road2});
//            var station3 = new Station("3", new List<Road>{road2, road3});
//            var station4 = new Station("4", new List<Road>{road3, road4});
//            
//            var trainsList1 = new Queue<IStation>();
//            trainsList1.Enqueue(station1);
//            trainsList1.Enqueue(station2);
//            trainsList1.Enqueue(station3);
//            trainsList1.Enqueue(station4);
//            
//            var trainsList2 = new Queue<IStation>();
//            trainsList2.Enqueue(station4);
//            trainsList2.Enqueue(station3);
//            trainsList2.Enqueue(station2);
//            trainsList2.Enqueue(station1);
//
//            var stationList = new List<Station> {station1, station2, station3, station4}; 
//            var trainList = new List<Train>
//            {
//                new Train(20, trainsList1),
//                new Train(17, trainsList2)
//            };
//            var railwaySystem = new RailwaySystem.RailwaySystem(trainList, stationList);
//
//            trainList[0].ChangeRoad();
//            Assert.Equal(road1, trainList[0].CurrentRoad);
//        }
    }
}