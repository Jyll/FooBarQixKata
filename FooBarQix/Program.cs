using FooBarQix.Models;
using System;
using System.Collections.Generic;

namespace FooBarQix
{
    public class Program
    {
        static void Main(string[] args)
        {
            var myElements = new List<FooBarQixElement>()
            {
                new Foo(),
                new Bar(),
                new Qix(),
                new Piou()
            };

            IFooBarQixService fooBarQixService = new FooBarQixService(myElements);
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
