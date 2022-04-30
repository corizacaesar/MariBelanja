﻿using TransaksiBelanja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransaksiBelanja.Data
{
    public interface IShopping:ICrud<Shopping>
    {
        void CreateShopping(Shopping shopping);
        bool SaveChanges();
    }
}
