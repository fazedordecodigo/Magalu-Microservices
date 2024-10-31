namespace Magalu.Carrinho.Domain
{
    public class CarrinhoCompras : Entity
    {
        public List<Item> Items { get; set; } = [];

        public void AdicionarItem(Item item)
        {
            Items.Add(item);
        }
    }
}
