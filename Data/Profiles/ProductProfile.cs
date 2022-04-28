using AutoMapper;
using Data.Dtos.Product;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewDto>();
            CreateMap<ProductCreateDto, Product>();
        }
    }
}
