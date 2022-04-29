using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.DTO;
using Shipping.Models;

namespace Shipping.Profiles
{
    public class ShippingsProfile : Profile
    {
        public ShippingsProfile()
        {
            CreateMap<Ship, ShippingDTO>();
            CreateMap<ShippingCreateDTO, Ship>();
        }
    }
}