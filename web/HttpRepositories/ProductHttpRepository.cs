using System;
using System.Net.Http;
using System.Threading.Tasks;
using web.Models;
using web.Helpers;
using System.Text.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore.WebUtilities;

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

        public async Task<Pagination<Product>> GetProducts(ShopParams shopParams)
        {
            var queryStringParam = new Dictionary<string, string>();
            if(shopParams.brandId > 0)
            {
                queryStringParam.Add("brandId", shopParams.brandId.ToString());
            }
            if (shopParams.typeId > 0)
            {
                queryStringParam.Add("typeId", shopParams.typeId.ToString());
            }
            if (!string.IsNullOrEmpty(shopParams.sort))
            {
                queryStringParam.Add("sort", shopParams.sort);
            }
            if(shopParams.pageNumber > 0)
            {
                queryStringParam.Add("pageIndex", shopParams.pageNumber.ToString());
            }
            if(!string.IsNullOrEmpty(shopParams.search))
            {
                queryStringParam.Add("search", shopParams.search);
            }
            var response = await _client.GetAsync(QueryHelpers.AddQueryString($"{apiUrl}/products", queryStringParam));
            //var response = await _client.GetAsync($"{apiUrl}/products");
            var content = await response.Content.ReadAsStringAsync();

            if(!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var products = JsonSerializer.Deserialize<Pagination<Product>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return products;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrands()
        {
            var response = await _client.GetAsync($"{apiUrl}/products/brands");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var brands = JsonSerializer.Deserialize<IReadOnlyList<ProductBrand>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return brands;
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypes()
        {
            var response = await _client.GetAsync($"{apiUrl}/products/types");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var types = JsonSerializer.Deserialize<IReadOnlyList<ProductType>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return types;
        }
    }
}
