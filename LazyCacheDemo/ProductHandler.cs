namespace LazyCacheDemo
{
    public class ProductHandler
    {
        public ProductCache productCache = new();
        public Product GetProduct(string id)
        {
            return productCache.CheckCache(id);
        }

        public void InitReset()
        {
            productCache.InitResetCache();
        }
    }
}
