using System;
using EasynetQSample.Core;
using EasyNetQ;

namespace CardPaymentSubscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Subscribe<IPayment>("cardPaymentId", Handler, x => x.WithTopic("payment.cardPayment"));
            }

            Console.WriteLine(
                "listening for (payment.cardPayment) messages");
            Console.ReadLine();
        }

        private static void Handler(IPayment payment)
        {
            if (payment is CardPayment cardPayment)
            {
                    Console.WriteLine($"Payment =< {cardPayment.CardNumber},{cardPayment.CardHolderName},{cardPayment.ExpiryDate},{cardPayment.Amount}>");

            }
        }
    }
}
