using Newtonsoft.Json;
using System.IO;

namespace RailwaySystem
{
    public class Configurator
    {
        private string Path { get; }
        public Configurator(string path = "../../../RailwaySystemConfiguration.json")
        {
            Path = path;
        }

        public RailwaySystem CreateRailwaySystem()
        {
            var json = File.ReadAllText(Path);
            var railwaySystemRaw = JsonConvert.DeserializeObject<RailwaySystemRaw>(json);
            return railwaySystemRaw.ConvertToRailwaySystem();
        }
        public RailwaySystem CreateRailwaySystem(out RailwaySystemRaw railwaySystemRaw)
        {
            var json = File.ReadAllText(Path);
            railwaySystemRaw = JsonConvert.DeserializeObject<RailwaySystemRaw>(json);
            return railwaySystemRaw.ConvertToRailwaySystem();
        }
    }
}