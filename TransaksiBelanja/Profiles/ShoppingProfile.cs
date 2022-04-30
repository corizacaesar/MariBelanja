using AutoMapper;
using Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransaksiBelanja.Models;

namespace Data.Profiles
{
    public class ShoppingProfile:Profile
    {
        public ShoppingProfile()
        {
            CreateMap<Shopping, ShoppingViewDto>();
            CreateMap<ShoppingCreateDto, Shopping>();
            CreateMap<Shopping, ShoppingPublishDto>();
        }
    }
}
