using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.DTO;
using Shipping.Models;
using TransaksiBelanja.Models;

namespace Shipping.Profiles
{
    public class ShippingsProfile : Profile
    {
        public ShippingsProfile()
        {
            CreateMap<Shopping,ShoppingViewDto>();
            CreateMap<ShoppingCreateDto,Shopping>().ForMember(dest=>dest.ExternalID, opt=>opt.MapFrom(src=>src.Id));

            CreateMap<Ship, ShippingDTO>();
            CreateMap<ShippingCreateDTO, Ship>();
        }
    }
}