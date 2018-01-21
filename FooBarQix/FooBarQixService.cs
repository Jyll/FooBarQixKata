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
            if(number % 7 == 0)
            {
                computationResult += "Qix";
            }
            if (number.ToString().Contains("3"))
            {
                computationResult += "Foo";
            }
            if(string.IsNullOrWhiteSpace(computationResult))
            {
                computationResult = number.ToString();
            }
            return computationResult;
        }
    }
}
