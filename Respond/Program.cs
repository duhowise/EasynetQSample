using System;
using EasynetQSample.Core;
using EasyNetQ;

namespace Respond
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus=RabbitHutch.CreateBus("host=localhost") )
            {
                bus.Respond<CardPaymentRequestMessage, CardPaymentResponseMessage>(Responder);
                Console.WriteLine("listening for messages");
                Console.ReadLine();
            }
        }

        private static CardPaymentResponseMessage Responder(CardPaymentRequestMessage request)
        {
            return new CardPaymentResponseMessage {AuthCode = "1234"};
        }
    }
}
