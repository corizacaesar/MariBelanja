using AutoMapper;
using Data.Dtos.Shopping;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Profiles
{
    public class ShoppingProfile:Profile
    {
        public ShoppingProfile()
        {
            CreateMap<Shopping, ShoppingViewDto>();
            CreateMap<ShoppingCreateDto, Shopping>();
        }
    }
}
