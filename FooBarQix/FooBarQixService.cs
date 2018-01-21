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
            string computationResult = string.Empty;
            if(number % 3 == 0)
            {
                computationResult = "Foo";
            }
            if(number % 5 == 0)
            {
                computationResult += "Bar";
            }
            if(string.IsNullOrWhiteSpace(computationResult))
            {
                computationResult = number.ToString();
            }
            return computationResult;
        }
    }
}
