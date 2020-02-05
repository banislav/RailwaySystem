using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyModel.Resolution;
using Newtonsoft.Json;
using RailwaySystem;
using Xunit;
using Xunit.Abstractions;

namespace RailwaySystemTest
{
    public class RailwaySystemUnitTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public RailwaySystemUnitTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void ConfiguratorTest()
        {
            try
            {
                var configurator = new Configurator("../../../TestConfiguration1.json");
                var railwaySystem = configurator.CreateRailwaySystem();
            }
            catch (Exception exception)
            {
                _testOutputHelper.WriteLine(exception.ToString());
                Assert.True(false);
            }
        }

        [Fact]
        public void ConvertStationTest()
        {
            var stations = new List<IStation>();
            var configurator = new Configurator("../../../TestConfiguration2.json");
            configurator.CreateRailwaySystem(out var railwaySystemRaw);
            railwaySystemRaw.ConvertStations(stations);
            Assert.True(stations.Count >= 1);
        }

        [Fact]
        public void ConvertRoadTest()
        {
            var stations = new List<IStation>();
            var roads = new List<IRoad>();
            var configurator = new Configurator("../../../TestConfiguration1.json");
            configurator.CreateRailwaySystem(out var railwaySystemRaw);
            railwaySystemRaw.ConvertStations(stations);
            railwaySystemRaw.ConvertRoads(stations, roads);
            Assert.True(roads.Count >= 1);
        }

        [Fact]
        public void ConvertTrainTest()
        {
            var stations = new List<IStation>();
            var roads = new List<IRoad>();
            var trains = new List<ITrain>();
            
            var configurator = new Configurator("../../../TestConfiguration2.json");
            configurator.CreateRailwaySystem(out var railwaySystemRaw);
            stations = railwaySystemRaw.ConvertStations(stations);
            roads = railwaySystemRaw.ConvertRoads(stations, roads);
            trains = railwaySystemRaw.ConvertTrains(stations, trains);
            Assert.True(trains.Count >= 1);
        }

        [Fact]
        public void CreateRailwaySystemTest()
        {
            var stations = new List<IStation>();
            var roads = new List<IRoad>();
            var trains = new List<ITrain>();
            
            var configurator = new Configurator("../../../TestConfiguration1.json");
            var railwaySystem = configurator.CreateRailwaySystem(out var railwaySystemRaw);
            railwaySystemRaw.ConvertStations(stations);
            railwaySystemRaw.ConvertRoads(stations, roads);
            railwaySystemRaw.ConvertTrains(stations, trains);
            Assert.NotNull(railwaySystem);
        }
    }
}