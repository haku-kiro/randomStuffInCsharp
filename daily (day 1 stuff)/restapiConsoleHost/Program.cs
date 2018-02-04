using System;
//using Nancy; //to create a module
using Nancy.Hosting.Self; //to create a nancy host, install this nugget

/// <summary>
/// For more info, goto : http://engineering.laterooms.com/building-microservices-with-nancy-fx/
/// </summary>
namespace restapiConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //we create a nancy host here:

            //Just as a side note, Nancyfx supports OWIN and traditional IIS based hosting if you dont want to run it off a console app

            using (var host = new NancyHost(new Uri("http://localhost:1234"))) //we create the endpoint, has to run as admin - otherwise it wont be able to reserve the addr
            {
                //just so that the host stays open to requests
                host.Start();
                Console.WriteLine("Running server on: http://localhost:1234");
                Console.ReadLine();
            }

        }
    }
}
