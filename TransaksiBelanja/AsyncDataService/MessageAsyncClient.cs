using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
//using DTO
using RabbitMQ.Client;
using Dtos;
using System.Text;

namespace TransaksiBelanja.AsyncDataService
{
    public class MessageAsyncClient : IMessageAsyncClient
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public MessageAsyncClient(IConfiguration configuration)
        {
           _configuration = configuration;
           var factory = new ConnectionFactory
           {
               HostName = _configuration["RabbitMQHost"],
               Port = int.Parse(_configuration["RabbitMQPort"])
           };

           try
           {
               _connection = factory.CreateConnection();
               _channel = _connection.CreateModel();
               _channel.ExchangeDeclare(exchange:"trigger",type:ExchangeType.Fanout);
               _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
               Console.WriteLine("--> Terkoneksi ke Message Bus RabbitMQ");
           }
           catch (Exception ex)
           {
               Console.WriteLine($"-->Gagal mengkoneksi ke Message Bus {ex.Message}");
           }
        }

        private void RabbitMQ_ConnectionShutdown(object? sender, ShutdownEventArgs e)
        {
            Console.WriteLine("-->RabbitMQ Connection Shutdown");
        }

        public void PublishNewShopping(ShoppingPublishDto shoppingDto)
        {
            var message = JsonSerializer.Serialize(shoppingDto);
            if(_connection.IsOpen)
            {
                Console.WriteLine("-->Koneksi ke RabbitMQ berhasil, kirim pesan...");
                SendMessage(message);
            }
            else
            {
                Console.WriteLine("Tidak dapat melakukan koneksi ke RabbitMQ, tidak bisa mengirim pesan");
            }
        }

        public void Dispose()
        {
            Console.WriteLine("Message Bus Disposed");
            if(_channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }
        }

        public void SendMessage(String message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange:"trigger",routingKey:"",basicProperties:null,body:body);
            Console.WriteLine($"--> Pesan Terkirim : {message}");
        }

    }
}