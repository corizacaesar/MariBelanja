using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using AutoMapper;
using Shipping.Data;
using Shipping.DTO;
using TransaksiBelanja.Models;

namespace Shipping.EventProcessing
{
   public class EventProcessor : IEventProcessor
   {
        
       private readonly IMapper _mapper;
       private readonly IServiceScopeFactory _scopeFactory;

       public EventProcessor(IMapper mapper, IServiceScopeFactory scopeFactory)
       {
           _mapper = mapper;
           _scopeFactory = scopeFactory;
       }
        
       public void ProcessEvent(string message)
       {
           var eventType = DetermineEvent(message);
           switch(eventType)
           {
               case EventType.ShoppingPublish:
                   AddShopping(message);
                   break;
               default:
                   break;
           }
       }

        private void AddShopping(string shoppingPublishMessage)
       {
           using(var scope = _scopeFactory.CreateScope())
           {
               var repo = scope.ServiceProvider.GetRequiredService<IShipping>();
               var shoppingPublishDto = JsonSerializer.Deserialize<ShoppingCreateDto>(shoppingPublishMessage);
               try
               {
                   var shopping = _mapper.Map<Shopping>(shoppingPublishDto);
                   if(!repo.ExternalShoppingExist(shopping.ExternalID))
                   {
                       repo.CreateShopping(shopping);
                       repo.SaveChange();
                       Console.WriteLine("--> Menambahkan Shopping Baru - Shipping");
                   }
                   else
                   {
                       Console.WriteLine("--> Shopping sudah ada di Shipping");
                   }
               }
               catch (Exception ex)
               {
                   Console.WriteLine($"--> Tidak dapat menambahkan shopping {ex.Message}");
               }
           }
       }

       private EventType DetermineEvent(string notificationMessage)
       {
           Console.WriteLine("--> Menentukan Event");
           var eventType = JsonSerializer.Deserialize<GenericEventDTO>(notificationMessage);
           switch(eventType.Event)
           {
               case "Shopping_Publish":
                   Console.WriteLine("-->Platform shopping event detected..");
                   return EventType.ShoppingPublish;
               default:
                   Console.WriteLine("--> Cant determined this event...");
                   return EventType.Undetermined;
           }
       }
   }

   enum EventType
   {
       ShoppingPublish,
       Undetermined
   }
}