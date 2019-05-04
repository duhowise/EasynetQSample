using System;
using EasynetQSample.Core;
using EasyNetQ;

namespace ReceiveMultiple
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus=RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Receive("my.paymentQueue",x=>x
                    .Add<CardPaymentRequestMessage>(message=>HandleCardPaymentMessage(message))
                    .Add<PurchaseOrder>(message=> HandlePurchaseOrderMessage(message)));
                Console.WriteLine("Listening for messages");
                Console.ReadLine();
            }

            Console.WriteLine("listening for multiple messages");
        }

        private static void HandlePurchaseOrderMessage(PurchaseOrder message)
        {
            Console.WriteLine($"purchase order =< {message.CompanyName},{message.Amount},{message.PaymentDayTerms},{message.PoNumber}>");

        }

        private static void HandleCardPaymentMessage(CardPaymentRequestMessage message)
        {
            Console.WriteLine($"Payment =< {message.CardNumber},{message.CardHolderName},{message.ExpiryDate},{message.Amount}>");

        }
    }
}
