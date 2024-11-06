namespace Magalu.Estoque.Domain
{
    [Cached(true)]
    public class Item : Entity
    {
        public string Nome { get; set; } = string.Empty;
    }
}
