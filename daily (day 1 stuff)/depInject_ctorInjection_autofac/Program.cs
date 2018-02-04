using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac; // to use IoC autofac

namespace depInject_ctorInjection_autofac
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
        //The point of this program is to show off ctor injection

        public IThing _thing = null;

        public OneToRuleThemAll(IThing thingStance)
        {
            _thing = thingStance;
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
            //Now when we want to use an instance of a certain class, we pass it in the ctor

            OneToRuleThemAll _rule = new OneToRuleThemAll(new ClassSomething()); //we pass it the class we want it to use
            _rule.useEm(); //Will now use the ClassSomething implementation

            //if we want to use a different instance we have to create a new instance of the OneToRuleThemAll class.
            OneToRuleThemAll _rule2 = new OneToRuleThemAll(new ClassSomethingElse());
            _rule2.useEm(); //Will now use the ClassSomethingElse implementation

            
            
            //Im assuming this is where the container comes in, like autofac (or tinyIoC, etc)
            //with autofac we dont need to use a method in the Class that calls to run (like we were using the method useEm).
            //we can just run the interface method

            //when you are settting up your builder, make sure that all the types that will be used are registerd
            var builder = new ContainerBuilder();
            builder.RegisterType<ClassSomething>().As<IThing>(); //Changing the type here is what does it
            var container = builder.Build();

            Console.WriteLine("This is the autofac example");
            container.Resolve<IThing>().doSomething(); //This will call the ClassSomething implementation of the doSomething method


            //mrl
            Console.ReadLine();

        }
    }
}
