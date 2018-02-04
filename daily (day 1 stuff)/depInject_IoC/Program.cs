using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace depInject_IoC
{



    interface ISon
    {
        //son must be able to help the father
        void Help(string message);
    }

    class OldestSon : ISon
    {
        public void Help(string message)
        {
            throw new NotImplementedException();
        }
    }

    class YoungestSon : ISon
    {
        public void Help(string message)
        {
            throw new NotImplementedException();
        }
    }

    class Father
    {
        private ISon _son;
        public Father(ISon selectedSon) //ctor injection
        {
            _son = selectedSon;
        }

        public void Notify(string message)
        {
           
            _son.Help(message);
        }

    }



    class Program
    {



        static void Main(string[] args)
        {

            OldestSon oldSon = new OldestSon();
            Father dad = new Father(oldSon); //we can pass it the class that implements the son interface
            dad.Notify("Test message");


        }
    }
}
