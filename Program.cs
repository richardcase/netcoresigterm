using System;
using System.Runtime.Loader;
using System.IO;
using System.Threading;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AssemblyLoadContext.Default.Unloading += UnloadOnSigTerm;

            Log("Testing SIGTERM.");
            while(true)
            {
                Log("Sleeping for 1 seconds");
                Thread.Sleep(1000);
            }
        }

        public static void UnloadOnSigTerm(AssemblyLoadContext context)
        {
            Log("In unload. Sleeping 10 seconds before shutting down");
            Thread.Sleep(10000);
            Log("Finished sleeping exiting UnloadOnSIgTerm");
        }

        private static void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
