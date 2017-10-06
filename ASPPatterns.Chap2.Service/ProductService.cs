using System.Collections.Generic;
using System.Web;

namespace ASPPatterns.Chap2.Service
{
    public class ProductService
    {
        private IProductRepository _productRepository;
        private ICacheStorage _cacheStorage;

        public ProductService(IProductRepository productRepository, ICacheStorage cacheStorage)
        {
            _productRepository = productRepository;
            _cacheStorage = cacheStorage;
        }

        public IList<Product> GetAllProductsIn(int categoryId)
        {
            IList<Product> products;
            string storageKey = $"products_in_category_id_{categoryId}";

            //products = (List<Product>)HttpContext.Current.Cache.Get(storageKey);
            products = _cacheStorage.Retrieve<List<Product>>(storageKey);

            if (products == null)
            {
                products = _productRepository.GetAllProductsIn(categoryId);
                //HttpContext.Current.Cache.Insert(storageKey, products);
                _cacheStorage.Store(storageKey, products);
            }
            return products;
        }
    }
}
