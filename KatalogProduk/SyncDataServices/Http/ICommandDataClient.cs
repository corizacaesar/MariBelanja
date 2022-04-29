using KatalogProduk.DTO;
using KatalogProduk.Models;

namespace KatalogProduk.SyncDataServices.Http
{
    public interface ICommandDataClient
    {
        Task SendProdukToTransaksiBelanja(Produk produk);
    }
}