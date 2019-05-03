using System;
using EasynetQSample.Core;
using EasyNetQ;

namespace RequestAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            var payment = new CardPaymentRequestMessage
            {
                Amount = 99.00m,
                CardHolderName = "Sample Card Holder",
                CardNumber = "1234589652369",
                ExpiryDate = "12/12"
            };
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                Console.WriteLine("publishing messages with request and response");
                Console.WriteLine();
                var task = bus.RequestAsync<CardPaymentRequestMessage, CardPaymentResponseMessage>(payment);
              
                task.ContinueWith(response => { Console.WriteLine($"Got response {response.Result.AuthCode}");});

                Console.ReadLine();
            }
        }
    }
}
