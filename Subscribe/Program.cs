using System;
using System.Threading.Tasks;
using EasynetQSample.Core;
using EasyNetQ;

namespace Subscribe
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus=RabbitHutch.CreateBus("host=localhost") )
            {
                //bus.Subscribe<CardPaymentRequestMessage>("cardPayment",HandleCardPaymentMessage);

                Console.WriteLine("listening for messages");

                bus.SubscribeAsync<CardPaymentRequestMessage>("cardPayment",message=>Task.Factory.StartNew(() =>
                {
                    Console.WriteLine($"Payment=< {message.CardNumber},{message.CardHolderName},{message.ExpiryDate},{message.Amount}>");

                }).ContinueWith(task =>
                {
                    if (task.IsCompleted&& !task.IsFaulted)
                    {
                        Console.WriteLine("finished processing all messages");
                    }
                    else
                    {
                        throw new EasyNetQException();
                    }
                }));
                Console.ReadLine();
            }
        }

        //private static void HandleCardPaymentMessage(CardPaymentRequestMessage payment)
        //{
        //    Console.WriteLine($"Payment=< {payment.CardNumber},{payment.CardHolderName},{payment.ExpiryDate},{payment.Amount}>");
        //}
    }
}
