namespace CQRSDEMO.CQRS.Caching
{
    public interface IResultCachable
    {
        bool UseResultCaching();

        CacheConfiguration GetCacheConfiguration();

    }
}
