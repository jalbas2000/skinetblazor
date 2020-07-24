using System;
using System.Net.Http;
using System.Threading.Tasks;
using web.Models;
using web.Helpers;
using System.Text.Json;

namespace web.HttpRepositories
{
    public class ProductHttpRepository : IProductHttpRepository
    {
        private readonly HttpClient _client;
        private readonly string apiUrl = "https://localhost:5001/api";

        public ProductHttpRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<Pagination<ProductToReturnDto>> GetProducts()
        {
            var response = await _client.GetAsync($"{apiUrl}/products?pageSize=50");
            var content = await response.Content.ReadAsStringAsync();

            if(!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var products = JsonSerializer.Deserialize<Pagination<ProductToReturnDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return products;
        }
    }
}
