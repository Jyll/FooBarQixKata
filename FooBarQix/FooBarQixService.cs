using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            StringBuilder computationResult = new StringBuilder( string.Empty );
            string numberAsString = number.ToString();

            if(number % 3 == 0)
            {
                computationResult.Append("Foo");
            }
            if(number % 5 == 0)
            {
                computationResult.Append("Bar");
            }
            if(number % 7 == 0)
            {
                computationResult.Append("Qix");
            }
            for(int i = 0; i < numberAsString.Count( digit => digit == '3'); i++) 
            {
                computationResult.Append("Foo");
            }
            for (int i = 0; i < numberAsString.Count(digit => digit == '5'); i++)
            {
                computationResult.Append("Bar");
            }
            if (string.IsNullOrWhiteSpace(computationResult.ToString()))
            {
                computationResult.Append(numberAsString);
            }
            return computationResult.ToString();
        }
    }
}
