using System;
using EasynetQSample.Core;
using EasyNetQ;

namespace TopicPublish
{
    class Program
    {
        static void Main(string[] args)
        {
            var purchaseOrder = new PurchaseOrder
            {
                PoNumber = "1258965231789",
                CompanyName = "Some Wise",
                PaymentDayTerms = 5,
                Amount = 485.9m,
            };
            var order = new PurchaseOrder()
            {
                PoNumber = "1258965231789",
                CompanyName = "Some Wise",
                PaymentDayTerms = 54,
                Amount = 485.9m,
            }; var payment = new CardPayment
            {
                CardNumber = "1258965231789",
                CardHolderName = "Some Wise",
                ExpiryDate = "12/05",
                Amount = 485.9m,
            };
            var payment1 = new CardPayment
            {
                CardNumber = "1252585231789",
                CardHolderName = "Someone Wise",
                ExpiryDate = "12/25",
                Amount = 50.9m,
            };
            var payment2 = new CardPayment
            {
                CardNumber = "1258966325789",
                CardHolderName = "Duhp Wise",
                ExpiryDate = "12/15",
                Amount = 4520m,
            };
            var payment3 = new CardPayment
            {
                CardNumber = "7458965231789",
                CardHolderName = "Some Wise",
                ExpiryDate = "12/13",
                Amount = 123.9m,
            };
            var payment4 = new CardPayment
            {
                CardNumber = "12589633231789",
                CardHolderName = "Wise D",
                ExpiryDate = "12/26",
                Amount = 8563.9m,
            };

            try
            {
                using (var bus = RabbitHutch.CreateBus("host=localhost"))
                {
                    Console.WriteLine("Publishing Message with topic based polymorphic publish and subscribe");
                    Console.WriteLine("---polymorphic Message");
                    bus.Publish<IPayment>(order,"payment.purchaseOrder");
                    bus.Publish<IPayment>(purchaseOrder, "payment.purchaseOrder");
                    bus.Publish<IPayment>(payment, "payment.cardPayment");
                    bus.Publish<IPayment>(payment1, "payment.cardPayment");
                    bus.Publish<IPayment>(payment2, "payment.cardPayment");
                    bus.Publish<IPayment>(payment3, "payment.cardPayment");
                    bus.Publish<IPayment>(payment4, "payment.cardPayment");
                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
