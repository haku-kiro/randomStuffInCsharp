using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; //this is where parallel sits


namespace daily__day_1_stuff_
{
    class Program
    {
        static void Main(string[] args)
        {
            //test collection
            string[] _arr = new string[] { "one", "two", "three", "four", "five" };


            //A normal foreach loop 
            foreach (string _string in _arr)
            {
                Console.WriteLine($"From the normal foreach loop: {_string}");
            }

            //its parallel equivalent
            Parallel.ForEach(_arr, _string => Console.WriteLine($"From the parallel foreach {_string}"));


            //So now, how would you implement the parallel foreach 



            //mrl
            Console.ReadLine();
        }
    }

    //This could be a fun activity, keep in mind that the parallel for and foreach have multiple overloads that allow for many other things etc etc
    public static class ParallelMethods
    {
        public static void foEach(ICollection<Object> collection, Action action)
        {

        }
    }
}
