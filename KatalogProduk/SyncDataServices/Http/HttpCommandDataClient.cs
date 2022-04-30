using KatalogProduk.DTO;
using KatalogProduk.Models;
using System.Text;
using System.Text.Json;

namespace KatalogProduk.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public HttpCommandDataClient(HttpClient httpClient,IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task SendProdukToTransaksiBelanja(Produk pro)
        {
            var httpContent = new StringContent(JsonSerializer.Serialize(pro), Encoding.UTF8, "apllication/json");
         

            var response = await _httpClient.PostAsync($"{_configuration["TransaksiBelanjaService"]}",
                httpContent);
            Console.WriteLine(httpContent);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync POST ke TransaksiBelanja berhasil dikirimkan");
            }
            else
            {
                Console.WriteLine("--> Sync POST ke TransaksiBelanja gagal dikirimkan");
            }
        }
    }
}