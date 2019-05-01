using System;
using EasynetQSample.Core;
using EasyNetQ;

namespace EasynetQSample
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var i = 0; i < 10; i++)
            {
                using (var bus = RabbitHutch.CreateBus("host=localhost"))
                {
                    bus.Publish(new TextMessage
                    {
                        Text = $"{i} Hello world from EsyNetQ"
                    });
                }
            }

            Console.ReadLine();
        }
        
    }
}
