﻿using System;
using EasyNetQ;
using TopicCore;

namespace PurchaseOrderReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Subscribe<IPayment>(nameof(PurchaseOrder), Handler, x => x.WithTopic("payment.purchaseOrder"));
                Console.WriteLine("listening for (payment.purchaseOrder) messages");
                Console.ReadLine();
            }


        }

        private static void Handler(IPayment payment)
        {
            if (payment is PurchaseOrder purchaseOrder)
            {
                Console.WriteLine($"purchase order =< {purchaseOrder.CompanyName},{purchaseOrder.Amount},{purchaseOrder.PaymentDayTerms},{purchaseOrder.PoNumber}>");

            }
        }
    }
}
