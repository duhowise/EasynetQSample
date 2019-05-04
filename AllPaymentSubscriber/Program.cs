using System;
using EasyNetQ;
using TopicCore;

namespace AllPaymentSubscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Subscribe<IPayment>("accounts", Handler, x => x.WithTopic("payment.*"));
                Console.WriteLine(
                    "listening for (payment.*) messages");
                Console.ReadLine();
            }

            
        }

        private static void Handler(IPayment payment)
        {
            if (payment is PurchaseOrder purchaseOrder)
            {
                Console.WriteLine($"purchase order =< {purchaseOrder.CompanyName},{purchaseOrder.Amount},{purchaseOrder.PaymentDayTerms},{purchaseOrder.PoNumber}>");

            }
            if (payment is CardPayment cardPayment)
            {
                Console.WriteLine($"Payment =< {cardPayment.CardNumber},{cardPayment.CardHolderName},{cardPayment.ExpiryDate},{cardPayment.Amount}>");

            }
        }
    }
}
