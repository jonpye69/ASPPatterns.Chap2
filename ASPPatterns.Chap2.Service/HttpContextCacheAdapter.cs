using System.Web;

namespace ASPPatterns.Chap2.Service
{
    /// <summary>
    /// Implements the adapter pattern - used to let classes with incompatible interfaces work with one another
    /// </summary>
    public class HttpContextCacheAdapter : ICacheStorage
    {
        public void Remove(string key)
        {
            HttpContext.Current.Cache.Remove(key);
        }
        public void Store(string key, object data)
        {
            HttpContext.Current.Cache.Insert(key, data);
        }
        public T Retrieve<T>(string key)
        {
            T itemStored = (T)HttpContext.Current.Cache.Get(key);
            if (itemStored == null)
                itemStored = default(T);
            return itemStored;
        }
    }
}
