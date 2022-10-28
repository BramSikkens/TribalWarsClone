using System.IO;
using System.Threading.Tasks;
using System.Text.Json;


namespace TribalWarsCloneDomain.utils.JSONWorldSettings
{
    public static class WorldSettingsReader
    {
        public static T Read<T>(string filepath)
        {
            using FileStream stream = File.OpenRead(filepath);
            return  JsonSerializer.Deserialize<T>(stream);
        }
    
    }
}
