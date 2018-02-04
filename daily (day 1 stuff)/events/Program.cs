using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace events
{
    public delegate void SomethingContainer(string thing); //delegate sig


    class Events
    {
        //This is how you define an event, you set it to a delegate
        public event SomethingContainer eventContainer = delegate { }; // I think if you add this you can call the event without a null check (correct)

        public void testMethod(string testParam)
        {
            Console.WriteLine($"testMethod: {testParam}");
        }

        public void CallEvent(string value)
        {
            if (eventContainer != null)
            {
                //this check is pointless, I have assigned an empty delegate to the event which means that it will always run without fail
                eventContainer(value); 
            }
            //eventContainer?.Invoke(value); //this is also a way to null check
        }

    }



    class Program
    {

        public delegate void test();  //you can create a delegate in a class as well

        static void doSomething(string some)
        {
            Console.WriteLine($"doSomething method : {some}");
        }

        static void Main(string[] args)
        {
            //to use the delegate:
            //create an instance
            SomethingContainer _contain;  //= new SomethingContainer(<method that matches the sig>); //if you want to pass a method

            _contain = doSomething; //Add a method to the delegate

            _contain.Invoke("param"); //This runs all the methods inside of the delegate


            //using the events:
            Events x = new Events();
            x.eventContainer += x.testMethod;

            x.CallEvent("test");


            //mrl
            Console.ReadLine();
        }
    }
}
