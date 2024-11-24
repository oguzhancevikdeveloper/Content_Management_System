using Microsoft.Extensions.Caching.Memory;

namespace CMS.Shared.Helper.Cache;

public class CacheHelper
{
    private readonly IMemoryCache _memoryCache;
    private readonly TimeSpan _cacheExpirationTime = TimeSpan.FromMinutes(15);

    public CacheHelper(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public void Set<T>(string key, T value)
    {
        _memoryCache.Set(key, value, _cacheExpirationTime);
    }

    public T Get<T>(string key)
    {
        if (_memoryCache.TryGetValue(key, out T value)) return value;

        return default;
    }
    public bool Exists(string key)
    {
        return _memoryCache.TryGetValue(key, out _);
    }

    public void Remove(string key)
    {
        _memoryCache.Remove(key);
    }
}