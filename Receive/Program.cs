using System;
using EasynetQSample.Core;
using EasyNetQ;

namespace Receive
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus=RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Receive<CardPaymentRequestMessage>("my.paymentQueue", message=>HandlePaymentMessage(message));
                Console.WriteLine("listening for messages");
                Console.ReadLine();
            }
        }

        private static void HandlePaymentMessage(CardPaymentRequestMessage message)
        {
            Console.WriteLine($"Payment =< {message.CardNumber},{message.CardHolderName},{message.ExpiryDate},{message.Amount}>");

        }
    }
}
