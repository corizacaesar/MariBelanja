using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shipping.Model;
//using TransaksiBelanja.Models;

namespace Shipping.Data
{
    public interface IShipping : ICrud<Shipping>
    {
        //shopping
        //IEnumerable<TransaksiBelanja> GetAll();
        //void CreateShopping(Shopping shopping);
        //bool ShoppingExist(int shoppingId);
        //bool ExternalShoppingExist(int externalShoppingId);
    }
}