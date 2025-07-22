namespace CQRSDEMO.CQRS.Caching
{
    public class CacheConfiguration
    {
        public string CacheKey { get; set; }


    }

    public enum CachePayloadType
    {
        String,
        ByteArray
    }

}
