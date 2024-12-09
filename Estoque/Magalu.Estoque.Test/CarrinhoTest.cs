using Magalu.Estoque.Domain;
using FluentAssertions;

namespace Magalu.Estoque.Test
{
    public class CarrinhoTest
    {
        [Fact]
        public void Deve_Retornar_Um_Item_Quando_Lista_De_Itens_Conter_Um_Item()
        {
            // AAA

            // Arrange
            var carrinho = new Carrinho();
            var item = new Item { Nome = "Item 1" };

            // Act

            carrinho.AdicionarItem(item);

            // Assert
            carrinho.Items.Should().HaveCount(1);
            carrinho.Items[0].Nome.Should().StartWith("It").And.EndWith("1").And.Contain("m").And.HaveLength(6);
        }
    }
}