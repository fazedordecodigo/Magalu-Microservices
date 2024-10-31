using Magalu.Carrinho.Application.Interfaces;
using Magalu.Carrinho.Domain;
using Newtonsoft.Json;

namespace Magalu.Infraestructure.Gateways
{
    public class ItemGateway : IItemGateway
    {
        public async Task<Item?> GetItemByIdAsync(Guid id)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"http://estoque:8081/itens/{id}");
            if (!response.IsSuccessStatusCode)
                return null;
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Item>(result);
        }
    }
}
