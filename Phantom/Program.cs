using System;
using System.Net;
using Phantom.Network;


namespace Phantom
{
    class Program
    {

        private static readonly PhantomLogger log = new PhantomLogger(LoggerModule.Core); 

        static void Main(string[] args)
        {
            log.Info("Phantom getting started...");

            AsynchronousSocketListener.StartListening();

            Console.ReadKey();
        }
    }
}
