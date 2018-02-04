using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace depInject__PropertyInjection
{

    public interface IThing
    {
        void doSomething();
    }

    class ClassSomething : IThing
    {
        public void doSomething()
        {
            Console.WriteLine("This is from ClassSomething");
        }
    }

    class ClassSomethingElse : IThing
    {
        public void doSomething()
        {
            Console.WriteLine("This is from ClassSomethingElse");
        }
    }

    class OneMoreThing : IThing
    {
        public void doSomething()
        {
            Console.WriteLine("This is from OneMoreThing");
        }
    }


    class OneToRuleThemAll
    {
        //The point of this is to show off property injection
        //So we have a thing property
        public IThing _thing { get; set; }

        public OneToRuleThemAll()
        {
            //default ctor
        }

        public void useEm()
        {
            //calls the doSomething method
            //should do a null check here though
            _thing.doSomething();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            //so here is where the dependancy injection occurs:

            //we create an instance of the class: 
            //just using the default ctor
            OneToRuleThemAll _ring = new OneToRuleThemAll();

            //When we want to use one of the defs we set the prop of that class to the 
            _ring._thing = new ClassSomething(); //bec this class does implement the IThing interface we can pass it here
            _ring.useEm(); // we will see the ClassSomething implementation

            //Containers come in as a way to do the above.

            //Another implementation:
            _ring._thing = new OneMoreThing(); 
            _ring.useEm(); //we will see the OneMoreThing implementation

            //mrl
            Console.ReadLine();
        }
    }
}
