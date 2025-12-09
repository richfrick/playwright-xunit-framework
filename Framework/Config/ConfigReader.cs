using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Framework.Config;

namespace Framework.Driver.Config;

public static class ConfigReader
{
    public static TestSettings readerConfig()
    {
        var configFile =
            File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/appsettings.json");

        var jsonSerializerSettings = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };
        
        jsonSerializerSettings.Converters.Add(new JsonStringEnumConverter());

        return JsonSerializer.Deserialize<TestSettings>(configFile, jsonSerializerSettings);
    }
}