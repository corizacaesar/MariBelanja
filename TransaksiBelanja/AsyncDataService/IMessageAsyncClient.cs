using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using DTO

namespace TransaksiBelanja.AsyncDataService
{
    public interface IMessageAsyncClient
    {
        void PublishNewShopping(ShoppingDto shoppingDto);
    }
}