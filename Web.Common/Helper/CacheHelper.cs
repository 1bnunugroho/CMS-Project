using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Web.Common.Helper
{
    public class InMemoryCache : ICacheService
    {
        public T GET<T>(string cacheKey) where T : class
        {
            T item = MemoryCache.Default.Get(cacheKey) as T;

            return item;
        }

        public T SET<T>(string cacheKey, Func<T> getItemCallback) where T : class
        {
            T item = MemoryCache.Default.Get(cacheKey) as T;
            int minutCache = SiteSettings.MinuteCache;
            if (item == null)
            {
                item = getItemCallback();
                MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(1440));//Satu Hari
            }
            return item;
        }

        public void REMOVE(string cacheKey)
        {
            MemoryCache.Default.Remove(cacheKey);
        }
    }

    interface ICacheService
    {
        T GET<T>(string cacheKey) where T : class;
        T SET<T>(string cacheKey, Func<T> getItemCallback) where T : class;
    }
}
