using LazyCache;
using LazyCache.Providers;

using Microsoft.Extensions.Caching.Memory;

namespace LazyCacheDemo
{
    public class ProductCache
    {
        IAppCache cache = new CachingService();
        public List<Product> dummyData = new();

        // dummy data
        public void InitResetCache()
        {
            cache.CacheProvider.Dispose();
            var provider = new MemoryCacheProvider(new MemoryCache(new MemoryCacheOptions()));
            cache = new CachingService(provider);
            dummyData = new List<Product>();
            dummyData.Add(new Product("product-01", "High Back Leather Chair", 34475.00m));
            dummyData.Add(new Product("product-02", "Mid Back Leather Chair", 24475.00m));
            dummyData.Add(new Product("product-03", "Low Back Leather Chair", 14475.00m));
            dummyData.Add(new Product("product-04", "Visitor Chair", 24400.00m));
            dummyData.Add(new Product("product-05", "Lecture hall chair", 7475.00m));
        }
        public Product CheckCache(string productId)
        {
            Func<Product> loadedProduct = () => LoadProduct(productId);
            Product cachedResult = cache.GetOrAdd(productId, loadedProduct, DateTimeOffset.UtcNow.AddMinutes(15));
            return cachedResult;
        }
        public Product LoadProduct(string productId)
        {
            foreach (Product p in dummyData)
            {
                if (p.Id == productId)
                {
                    return p;
                }
            }
            return null;
        }
    }
}