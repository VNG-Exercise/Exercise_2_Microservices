using CartService.Helpers;
using CartService.Models.Dtos;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace CartService.Infrastructure.Communications.Http.ProductService
{
    public class ProductClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ProductClient> _logger;
        private readonly string _baseUri;

        public ProductClient(
            HttpClient httpClient,
            ILogger<ProductClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            _baseUri = AppUtils.GetConfig("ProductService:BaseUri");
        }

        public async Task<ProductModel?> GetProductAsync(long Id)
        {
            var (_, response) = await SendRequestAsync<BaseResponse<ProductModel>>("GET", $"/api/v1/product/{Id}", null);

            if (response is null)
                return null;

            _logger.LogInformation($"ProductClient -> GetProductAsync: Call api from ProductService status is {response.Code} and message is {response.Message}");

            return response.Data;
        }

        private async Task<(bool, T?)> SendRequestAsync<T>(
            string method,
            string endpoint,
            object? data)
        {
            var baseUri = new Uri(_baseUri);

            var requestUri = new Uri(baseUri, endpoint);

            var dataJsonText = JsonConvert.SerializeObject(data);

            var requestBody = data != null
                ? new StringContent(dataJsonText, Encoding.UTF8, "application/json")
                : new StringContent(string.Empty);

            try
            {
                HttpResponseMessage response = method switch
                {
                    "POST" => await _httpClient.PostAsync(requestUri, requestBody),
                    "PUT" => await _httpClient.PostAsync(requestUri, requestBody),
                    "DELETE" => await _httpClient.DeleteAsync(requestUri),
                    _ => await _httpClient.GetAsync(requestUri),
                };
                var responseBody = await response.Content.ReadAsStringAsync();

                _logger.LogInformation($"requestUri={requestUri}, data={responseBody}");

                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
                    return (true, JsonConvert.DeserializeObject<T>(responseBody));

                _logger.LogError($"Error : {responseBody}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
            }

            return (false, default);
        }
    }
}
