using Microsoft.Extensions.Caching.Distributed;

namespace Vermilion.Application.Common.CachingExtensions
{
    public static class CacheOptions
    {
        public static DistributedCacheEntryOptions DefaultExpiration =>
            new() { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30) };
    }
}
