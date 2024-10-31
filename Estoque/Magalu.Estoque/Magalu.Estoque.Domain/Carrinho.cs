namespace Magalu.Estoque.Domain
{
    public class Carrinho : Entity
    {
        public List<Item> Items { get; set; } = [];

        public void AdicionarItem(Item item)
        {
            Items.Add(item);
        }
    }
}
