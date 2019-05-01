using System;
using EasynetQSample.Core;
using EasyNetQ;

namespace PolyMorphicPublish
{
    class Program
    {
        private static void Main(string[] args)
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
            };var payment = new CardPaymentRequestMessage
            {
                CardNumber = "1258965231789",
                CardHolderName = "Some Wise",
                ExpiryDate = "12/05",
                Amount = 485.9m,
            };
            var payment1 = new CardPaymentRequestMessage
            {
                CardNumber = "1252585231789",
                CardHolderName = "Someone Wise",
                ExpiryDate = "12/25",
                Amount = 50.9m,
            };
            var payment2 = new CardPaymentRequestMessage
            {
                CardNumber = "1258966325789",
                CardHolderName = "Duhp Wise",
                ExpiryDate = "12/15",
                Amount = 4520m,
            };
            var payment3 = new CardPaymentRequestMessage
            {
                CardNumber = "7458965231789",
                CardHolderName = "Some Wise",
                ExpiryDate = "12/13",
                Amount = 123.9m,
            };
            var payment4 = new CardPaymentRequestMessage
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
                    Console.WriteLine("Publishing Message with polymorphic publish and subscribe");
                    Console.WriteLine("---polymorphic Message");
                    bus.Publish<IPayment>(order);
                    bus.Publish<IPayment>(purchaseOrder);
                    bus.Publish<IPayment>(payment);
                    bus.Publish<IPayment>(payment1);
                    bus.Publish<IPayment>(payment2);
                    bus.Publish<IPayment>(payment3);
                    bus.Publish<IPayment>(payment4);
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
