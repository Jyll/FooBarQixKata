using System;

namespace FooBarQix
{
    public class Program
    {
        static void Main(string[] args)
        {
            IFooBarQixService fooBarQixService = new FooBarQixService();
            var fooBarQixResults = fooBarQixService.DoFooBarQix();

            foreach(var iterationResult in fooBarQixResults)
            {
                if(!string.IsNullOrWhiteSpace(iterationResult))
                {
                    Console.WriteLine(iterationResult);
                }
            }
        }
    }
}
