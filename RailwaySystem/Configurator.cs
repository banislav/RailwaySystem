using Newtonsoft.Json;
using System.IO;

namespace RailwaySystem
{
    public class Configurator
    {
        public RailwaySystem CreateRailwaySystem()
        {
            //var railwaySystemRaw = new RailwaySystemRaw();
            var json = File.ReadAllText("/home/danya-lapin/sandbox/RailwaySystem/RailwaySystem/RailwaySystemConfiguration.json");
            var railwaySystemRaw = JsonConvert.DeserializeObject<RailwaySystemRaw>(json);
            return railwaySystemRaw.ConvertToRailwaySystem();
        }
    }
}