using System;
using Nancy;
using TinyMessenger;
using Nancy.TinyIoc; //used for TinyIoCContainer

namespace restApi
{

    class Message : ITinyMessage
    {
        public object Sender { get; set; }
        public int ID { get; set; }
        public string Body { get; set; }
    }

    public class tinyMessengerThing : NancyModule
    {

        private readonly ITinyMessengerHub _messengerHub;
        //could instantiate a logger here, like common.logging 

        public tinyMessengerThing()
        {
            //_messengerHub = TinyIoCContainer.Current.Resolve<ITinyMessengerHub>();

            Get["/test/{id}"] = parameters => doSomethingWithMessage(parameters);
        }

        private object doSomethingWithMessage(dynamic parameters)
        {


            _messengerHub.Publish(new Message()
            {
                Sender = this != null ? "Something" : "Nothing",
                ID = parameters.ID,
                Body = "testing messages"
            });

            return Response.AsJson(new { thing = $"Processing with id : {parameters.ID}", messageBody = parameters.Body }); //the param thing is weird here. It's dynamic meaning we can see what it holds till runtime
        }
    }
}