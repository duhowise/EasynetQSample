using System;
using EasynetQSample.Core;
using EasyNetQ;

namespace Publish
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
            var payment4 = new CardPaymentRequestMessage
            {
                CardNumber = "12589633231789",
                CardHolderName = "Wise D",
                ExpiryDate = "12/26",
                Amount = 8563.9m,
            };


            //using (var bus=RabbitHutch.CreateBus("host=localhost"))
            //{
            //    Console.WriteLine("Publishing Message with publish and subscribe");
            //    bus.Publish(payment);
            //    bus.Publish(payment1);
            //    bus.Publish(payment2);
            //    bus.Publish(payment3);
            //    bus.Publish(payment4);
            //    Console.ReadLine();

            //}
            using (var bus = RabbitHutch.CreateBus("host=localhost;publisherConfirms=true;timeout=10"))
            {
                Console.WriteLine("Publishing Message with publish and subscribe");
                Publish(bus, payment);
                Publish(bus, payment1);
                Publish(bus, payment2);
                Publish(bus, payment3);
                Publish(bus, payment4);
                Console.ReadLine();
            }
        }

        public static void Publish(IBus bus, CardPaymentRequestMessage payment)
        {
            bus.PublishAsync(payment).ContinueWith(task =>
            {
                if (task.IsCompleted && !task.IsFaulted)
                {
                    Console.WriteLine("Task complete and not faulted");
                }
                else
                {
                    Console.WriteLine("\n\n");
                    Console.WriteLine(task.Exception);
                    Console.WriteLine("\n\n");
                }
            });
        }
    }
}
