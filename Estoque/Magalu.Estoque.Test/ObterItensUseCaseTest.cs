using Moq;
using Magalu.Estoque.Domain;
using Magalu.Estoque.Application.Interfaces;
using Magalu.Estoque.Application.UseCases.ObterItens;
using FluentAssertions;

namespace Magalu.Estoque.Test
{
    public class ObterItensUseCaseTest
    {
        private readonly Mock<IRepository<Item>> _itemRepositoryFake;
        private readonly ObterItensUseCase _sut;
        private readonly ObterItensDto _dto;
        public ObterItensUseCaseTest()
        {
            _itemRepositoryFake = new Mock<IRepository<Item>>();
            _sut = new ObterItensUseCase(_itemRepositoryFake.Object);
            _dto = new ObterItensDto { Take = 2, Skip = 2 };
        }

        internal void Dispose()
        {
            _itemRepositoryFake.Reset();
        }

        [Fact]
        public async Task Deve_Retornar_Um_Item()
        {
            // Arrange
            var itemsFake = new List<Item>
            {
                new() { Id = Guid.NewGuid(), Nome = "Produto A" },
                new() { Id = Guid.NewGuid(), Nome = "Produto B" }
            };
            int pageNumber = 2;
            int pageSize = 2;

            _itemRepositoryFake
                .Setup(repo => repo.GetAll(pageSize, pageNumber))
                    .ReturnsAsync(itemsFake);
            var sut = new ObterItensUseCase(_itemRepositoryFake.Object);
            var dto = new ObterItensDto {Take = pageNumber, Skip = pageSize};

            // Act
            var result = await sut.Handler(dto);

            // Assert
            result.Should().BeEquivalentTo(itemsFake);
            result.Should().BeOfType<List<Item>>();
        }

        [Fact]
        public async Task Deve_Retornar_Uma_Execao_Ao_Receber_Dto_Nulo()
        {
            // Act
            Func<Task> action = async () => await _sut.Handler(null);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(action);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Deve_Verificar_Se_GetAll_Recebeu_Dois_Parametros()
        {   
            // Act
            await _sut.Handler(_dto);
            // Assert
            _itemRepositoryFake.Verify(repo => repo.GetAll(_dto.Skip, _dto.Take), Times.Once);
        }
    }
}
