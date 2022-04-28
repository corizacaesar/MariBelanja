using KatalogProduk.DTO;

namespace KatalogProduk.SyncDataServices.Http
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(ProdukDTO produk);
    }
}