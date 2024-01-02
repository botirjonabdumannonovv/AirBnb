using AirBnb.ServerApp.Application.Common.Serializers;
using Force.DeepCloner;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AirBnb.ServerApp.Infrastructure.Common.Serializers;

public class JsonSerializationSettingsProvider : IJsonSerializationSettingsProvider
{
    private readonly JsonSerializerSettings _jsonSerializerSettings = new()
    {
        Formatting = Formatting.Indented,
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        NullValueHandling = NullValueHandling.Ignore
    };

    public JsonSerializerSettings Get(bool clone = false)
    {
        return clone ? _jsonSerializerSettings.DeepClone() : _jsonSerializerSettings;
    }
}