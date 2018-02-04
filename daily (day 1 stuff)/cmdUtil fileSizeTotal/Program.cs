using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;


/// <summary>
/// This is to show off the parallel.for
/// 
/// 
/// This example is a simple cmd util that calculates the total size of files in a dir. It expects a single dir path as an argument
/// and it returns the number of files and the total size
/// </summary>
namespace cmdUtil_fileSizeTotal
{
    class Program
    {
        static void Main() //'string[] args' taken out here
        {
            long totalSize = 0; // the total size of the files 

            string[] args = Environment.GetCommandLineArgs(); //gets the arguments from the cmd line, normally done in the main as a param
            if (args.Length == 1)
            {
                Console.WriteLine("There are no cmd line args."); //hmm
                Console.ReadLine(); //just so the user knows whats going on
                return;
            }

            if (!Directory.Exists(args[1]))
            {
                //assuming the first arg is a dir path
                Console.WriteLine("The dir does not exist");
                Console.ReadLine(); //just so the user knows whats going on
                return;
            }

            //after the checks

            //get the files
            string[] files = Directory.GetFiles(args[1]);

            //use parallel.for to go over files 
            Parallel.For(0, files.Length,
                index =>
                {
                    FileInfo fi = new FileInfo(files[index]); //get the files info
                    long size = fi.Length;
                    Interlocked.Add(ref totalSize, size); //interlock is used to provide atomic operations for vars shared by multiple threads
                });

            Console.WriteLine($"Directory: {args[1]}");
            Console.WriteLine($"{files.Length:NO} files, {totalSize:NO} bytes");


            //mrl
            Console.ReadLine();
        }
    }
}
