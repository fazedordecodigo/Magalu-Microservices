namespace Magalu.Estoque.Domain
{
    public class CachedAttribute(bool useCache) : Attribute
    {
        public bool UseCache { get; } = useCache;
    }
}
