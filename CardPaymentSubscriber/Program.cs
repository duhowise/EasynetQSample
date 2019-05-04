using System;
using EasyNetQ;
using TopicCore;

namespace CardPaymentSubscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Subscribe<IPayment>("cardPayment", Handler, x => x.WithTopic("payment.card"));
                Console.WriteLine(
                    "listening for (payment.card) messages");
                Console.ReadLine();
            }

           
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
