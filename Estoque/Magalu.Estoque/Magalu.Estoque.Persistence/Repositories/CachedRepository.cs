using Magalu.Estoque.Application.Interfaces;
using Magalu.Estoque.Domain;
using Magalu.Estoque.Persistence.Contexts;
using System.Reflection;

namespace Magalu.Estoque.Persistence.Repositories
{
    public class CachedRepository<T> : IRepository<T>
    {
        private readonly bool _useCache;
        private readonly IRepository<T> _innerRepository;
        private readonly RedisContext _redisContext;
        private readonly HashSet<string> _methodsNotCached;

        public CachedRepository(IRepository<T> innerRepository, RedisContext redisContext)
        {
            _innerRepository = innerRepository;
            _redisContext = redisContext;
            _useCache = Attribute.IsDefined(typeof(T), typeof(CachedAttribute));
            _methodsNotCached = new HashSet<string>();

            foreach (var method in _innerRepository.GetType().GetMethods())
            {
                var attr = method.GetCustomAttribute<CachedAttribute>();
                if (attr != null && !attr.UseCache)
                {
                    _methodsNotCached.Add(method.Name);
                }
            }
        }

        private bool ShouldUseCache(string methodName)
        {
            return _useCache && !_methodsNotCached.Contains(methodName);
        }

        public async Task<IEnumerable<T>> GetAll(int skip, int take)
        {
            var key = $"{typeof(T).Name}:All";
            if (ShouldUseCache(nameof(GetAll)))
            {
                var cached = await _redisContext.GetAsync<IEnumerable<T>>(key);
                if (cached is not null)
                {
                    return cached;
                }
            }
            var dbValues = await _innerRepository.GetAll(skip, take);
            if (ShouldUseCache(nameof(GetAll)) && dbValues is not null)
            {
                await _redisContext.SetAsync(key, dbValues);
            }
            return dbValues;
        }
    }
}

