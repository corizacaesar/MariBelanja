using AutoMapper;

using Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransaksiBelanja.Models;

namespace TransaksiBelanja.ProductProfile
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductCreateDto>();
            CreateMap<ProductCreateDto, Product>();
        }
    }
}
