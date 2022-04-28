using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.DTO;
using Shipping.Model;

namespace Shipping.Profiles
{
    public class ShippingsProfile : Profile
    {
        public ShippingsProfile()
        {
            CreateMap<Shipping, ShippingDTO>();
            CreateMap<ShippingCreateDTO, Shipping>();
        }
    }
}