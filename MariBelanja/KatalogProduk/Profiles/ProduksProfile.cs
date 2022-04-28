using AutoMapper;
using KatalogProduk.DTO;
using KatalogProduk.Models;

namespace KatalogProduk.Profiles
{
    public class ProduksProfile : Profile
    {
        public ProduksProfile()
        {
            CreateMap<Produk, ProdukDTO>();
            CreateMap<ProdukDTO, Produk>();

        }
    }
}
