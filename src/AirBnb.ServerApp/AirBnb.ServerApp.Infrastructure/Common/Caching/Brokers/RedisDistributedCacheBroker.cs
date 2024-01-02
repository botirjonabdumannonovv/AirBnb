using AirBnb.ServerApp.Application.Common.Serializers;
using AirBnb.ServerApp.Infrastructure.Common.Caching.Settings;
using AirBnb.ServerApp.Persistence.Caching.Brokers;
using AirBnb.ServerApp.Persistence.Caching.Models;
using AutoMapper;
using Force.DeepCloner;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace AirBnb.ServerApp.Infrastructure.Common.Caching.Brokers;

/// <summary>
/// Provides functionality of Redis cache broker for distributed caching
/// </summary>
public class RedisDistributedCacheBroker(
    IMapper mapper,
    IJsonSerializationSettingsProvider jsonSerializationSettingsProvider,
    IOptions<CacheSettings> cacheSettings,
    IDistributedCache distributedCache
) : ICacheBroker
{
    private readonly CacheEntryOptions _entryOptions = new()
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(cacheSettings.Value.AbsoluteExpirationInSeconds),
        SlidingExpiration = TimeSpan.FromSeconds(cacheSettings.Value.SlidingExpirationInSeconds)
    };

    public async ValueTask<T?> GetAsync<T>(string key)
    {
        var value = await distributedCache.GetStringAsync(key);

        return value is not null ? JsonConvert.DeserializeObject<T>(value) : default;
    }

    public async ValueTask<T?> GetOrSetAsync<T>(string key, Func<Task<T>> valueFactory, CacheEntryOptions? entryOptions = default)
    {
        var cachedValue = await distributedCache.GetStringAsync(key);
        if (cachedValue is not null) return JsonConvert.DeserializeObject<T>(cachedValue);

        var value = await valueFactory();
        await SetAsync(key, await valueFactory(), entryOptions);

        return value;
    }

    public async ValueTask<(bool Result, T? Value)> TryGetAsync<T>(string key, CancellationToken cancellationToken = default)
    {
        var foundEntry = await distributedCache.GetStringAsync(key, token: cancellationToken);

        return foundEntry is not null
            ? (true, JsonConvert.DeserializeObject<T>(foundEntry, jsonSerializationSettingsProvider.Get()))
            : (false, default);
    }

    public async ValueTask SetAsync<T>(string key, T value, CacheEntryOptions? entryOptions = default, CancellationToken cancellationToken = default)
    {
        await distributedCache.SetStringAsync(
            key,
            JsonConvert.SerializeObject(value, jsonSerializationSettingsProvider.Get()),
            mapper.Map<DistributedCacheEntryOptions>(GetCacheEntryOptions(entryOptions)),
            cancellationToken
        );
    }

    public IQueryCacheBroker GetCacheResolver(CacheEntryOptions? entryOptions = default)
    {
        return new QueryCacheBroker(GetCacheEntryOptions(entryOptions), this);
    }

    /// <summary>
    /// Gets the cache entry options based on given entry options or default options.
    /// </summary>
    /// <param name="entryOptions">Given cache entry options.</param>
    /// <returns>The distributed cache entry options.</returns>
    private CacheEntryOptions GetCacheEntryOptions(CacheEntryOptions? entryOptions)
    {
        if (!entryOptions.HasValue ||
            (!entryOptions.Value.AbsoluteExpirationRelativeToNow.HasValue && !entryOptions.Value.SlidingExpiration.HasValue))
            return _entryOptions;

        var currentEntryOptions = _entryOptions.DeepClone();

        currentEntryOptions.AbsoluteExpirationRelativeToNow = entryOptions.Value.AbsoluteExpirationRelativeToNow;
        currentEntryOptions.SlidingExpiration = entryOptions.Value.SlidingExpiration;

        return currentEntryOptions;
    }
}