using EasyNetQ;
using System;
using EasynetQSample.Core;

namespace EasynetQSample.Subscriber
{
    class Program
    {
        private static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Subscribe<TextMessage>("test",HandleTextMessage);
                Console.WriteLine("Listening for Messages. Hit <return> to quit");
                Console.ReadLine();
            }
        }

        private static void HandleTextMessage(TextMessage obj)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"got message {obj.Text}");
            Console.ResetColor();
        }
    }

   

    
}

