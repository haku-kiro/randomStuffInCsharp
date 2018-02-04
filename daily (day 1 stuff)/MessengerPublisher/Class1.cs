using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyMessenger;

namespace MessengerPublisher
{

    class Message : ITinyMessage
    {
        public object Sender { get; set; }
        public int ID { get; set; }
        public string MessageBody { get; set; }
    }

    public class ServiceThing //This should be able to be called (Maybe as nancy mod - or is that where we subscribe?)
    {
        ITinyMessengerHub _hub;

        public ServiceThing(ITinyMessengerHub messengerHub)
        {
            _hub = messengerHub;
        }

        //method to publish:

        

    }
}
