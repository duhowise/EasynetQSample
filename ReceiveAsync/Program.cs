using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using EasynetQSample.Core;
using EasyNetQ;

namespace ReceiveAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            var workers = new BlockingCollection<MyWorker>();
            for (int i = 0; i < 10; i++)
            {
                workers.Add(new MyWorker());
            }


            using (var bus=RabbitHutch.CreateBus("host=localhost"))
            {
                bus.RespondAsync<CardPaymentRequestMessage, CardPaymentResponseMessage>(message =>
                    Task.Factory.StartNew(() =>
                    {
                        var worker = workers.Take();
                        try
                        {
                            return worker.Execute(message);
                        }
                        finally
                        {
                            workers.Add(worker);
                        }
                    }));
                Console.WriteLine("Listening for messages");
                Console.ReadLine();

            }
        }
    }
}
