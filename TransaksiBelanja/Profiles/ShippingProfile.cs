using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dtos;
using TransaksiBelanja.Models;

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
