using System;
using EasynetQSample.Core;
using EasyNetQ;

namespace Request
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
            using (var bus=RabbitHutch.CreateBus("host=localhost"))
            {
                Console.WriteLine("publishing messages with request and response");
                Console.WriteLine();
                var response = bus.Request<CardPaymentRequestMessage, CardPaymentResponseMessage>(payment);
                Console.WriteLine(response.AuthCode);
                Console.WriteLine("response received");
                Console.ReadLine();
            }

        }
    }
}
