using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace web.Services
{
    public class ErrorService : IErrorService
    {
        private readonly string apiUrl = "https://localhost:5001/api";
        private readonly HttpClient _httpClient;
        public ErrorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Get404Error()
        {
            var response = await _httpClient.GetAsync($"{apiUrl}/products/42");
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
            if (!response.IsSuccessStatusCode)
            {
                //throw new ApplicationException(content);
            }
        }

        public async Task Get500Error()
        {
            var response = await _httpClient.GetAsync($"{apiUrl}/buggy/servererror");
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
            if (!response.IsSuccessStatusCode)
            {
                //throw new ApplicationException(content);
            }
        }

        public async Task Get400Error()
        {
            var response = await _httpClient.GetAsync($"{apiUrl}/buggy/badrequest");
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
            if (!response.IsSuccessStatusCode)
            {
                //throw new ApplicationException(content);
            }
        }

        public async Task Get400ValidationError()
        {
            var response = await _httpClient.GetAsync($"{apiUrl}/products/fortytwo");
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
            if (!response.IsSuccessStatusCode)
            {
                //throw new ApplicationException(content);
            }
        }
    }
}