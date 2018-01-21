using System;
using System.Collections.Generic;

namespace FooBarQix
{
    public class FooBarQixService : IFooBarQixService
    {
        public IEnumerable<string> DoFooBarQix(int endIndex = 100)
        {
            throw new NotImplementedException();
        }

        public string FooBarQixComputation(int number)
        {
            return number % 6 == 0 ? "Foo" : number.ToString();
        }
    }
}
