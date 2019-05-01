using System;
using EasynetQSample.Core;
using EasyNetQ;

namespace PolyMorphicSubscribe
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus=RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Subscribe<IPayment>("", message => HandleMessage(message));
                Console.WriteLine("listening for messages");
                Console.WriteLine("");
                Console.ReadLine();
            }
        }

        private static void HandleMessage(IPayment message)
        {
            var cardPayment = message as CardPaymentRequestMessage;
            var purchaseOrder= message as PurchaseOrder;

            if (cardPayment!=null)
            {
                    Console.WriteLine($"Payment =< {cardPayment.CardNumber},{cardPayment.CardHolderName},{cardPayment.ExpiryDate},{message.Amount}>");

            }else if (purchaseOrder != null)
            {
                    Console.WriteLine($"purchase order =< {purchaseOrder.CompanyName},{purchaseOrder.Amount},{purchaseOrder.PaymentDayTerms},{purchaseOrder.PoNumber}>");

            }
            else
            {

                Console.WriteLine("invalid message");
            }
        }
    }
}
