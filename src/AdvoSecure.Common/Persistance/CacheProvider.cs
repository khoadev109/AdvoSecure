using Microsoft.Extensions.Caching.Memory;

namespace AdvoSecure.Common.Persistance
{
    public class CacheProvider
    {
        private readonly IMemoryCache _memoryCache;

        public CacheProvider(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T? Get<T>(string key)
        {
            if (_memoryCache.TryGetValue(key, out T item))
            {
                return item;
            }

            return default;
        }

        public void Set<T>(string key, T value, MemoryCacheEntryOptions options = null)
        {
            if (options == null)
            {
                options = new MemoryCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(43200),
                    SlidingExpiration = TimeSpan.FromSeconds(43200)
                };
            }

            _memoryCache.Set(key, value, options);
        }

        public void Remove(string key)
        {
            if (!string.IsNullOrWhiteSpace(key))
            {
                _memoryCache.Remove(key);
            }
        }
    }
}
