using Newtonsoft.Json;

namespace AirBnb.ServerApp.Application.Common.Serializers;

public interface IJsonSerializationSettingsProvider
{
    JsonSerializerSettings Get(bool clone = false);
}