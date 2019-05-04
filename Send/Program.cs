using System;
using EasynetQSample.Core;
using EasyNetQ;

namespace Send
{
    class Program
    {
        static void Main(string[] args)
        {
            var payment = new CardPaymentRequestMessage
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
            };

            using (var bus=RabbitHutch.CreateBus("host=localhost"))
            {
                Console.WriteLine("Publishing messages with send and receive");
                Console.WriteLine();
                bus.Send("my.paymentQueue",payment);
                bus.Send("my.paymentQueue",payment1);
                bus.Send("my.paymentQueue",purchaseOrder);
                bus.Send("my.paymentQueue",order);
                bus.Send("my.paymentQueue",payment3);
                bus.Send("my.paymentQueue",payment2);
            }
        }
    }
}
