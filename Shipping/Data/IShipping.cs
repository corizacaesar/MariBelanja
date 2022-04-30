using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shipping.Models;
using TransaksiBelanja.Models;

namespace Shipping.Data
{
    public interface IShipping : ICrud<Ship>
    {
        bool SaveChange();
        //shopping
        IEnumerable<Shopping> GetAllShopping();
        void CreateShopping(Shopping shopping);
        bool ShoppingExist(int ShoppingId);
        bool ExternalShoppingExist(int externalShoppingId);
    }
}