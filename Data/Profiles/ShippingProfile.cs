using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data.Dtos.Shipping;
using Domain.Models;

namespace Data.Profiles
{
    public class ShippingProfile:Profile
    {
        public ShippingProfile()
        {
            CreateMap<Shipping, ShippingViewDto>();
            CreateMap<ShippingCreateDto, Shipping>();
        }
    }
}
