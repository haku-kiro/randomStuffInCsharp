using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    //we make the class sealed, cannot be inherited from
    public sealed class SingletonClass
    {
        //we create a private static type of the singleton class
        private static SingletonClass instance = null; 

        //we create a property that holds a single static instance of the class
        public static SingletonClass SingleInstance
        {
            //this is where we access the singleton object (only once)
            get
            {
                instance = instance ??  new SingletonClass();
                return instance;
            }
        }

        //we make the ctor private
        private SingletonClass() {}

        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            //SingletonClass s = new SingletonClass(); //the class is inaccessable due to protection level
            //to access out singleton object, we use the public accessor:
            SingletonClass s = SingletonClass.SingleInstance;
            s.PrintDetails("This is the first message");

            //mrl
            Console.ReadLine();
        }
    }
}
