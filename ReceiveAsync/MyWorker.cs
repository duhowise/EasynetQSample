using System;
using EasynetQSample.Core;

namespace ReceiveAsync
{
    public class MyWorker
    {
        public CardPaymentResponseMessage Execute(CardPaymentRequestMessage request)
        {
            var responseMessage=new CardPaymentResponseMessage();
            responseMessage.AuthCode = "1234";
            Console.WriteLine("worker activated to process response");
            return responseMessage;
        }
    }
}