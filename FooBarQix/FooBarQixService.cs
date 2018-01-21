using System;
using System.Collections.Generic;
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

            foreach(var digit in numberAsString)
            {
                switch (digit)
                {
                    case '3':
                        computationResult.Append("Foo");
                        break;
                    case '5':
                        computationResult.Append("Bar");
                        break;
                    case '7':
                        computationResult.Append("Qix");
                        break;
                    default:
                        break;
                }
            }

            if (string.IsNullOrWhiteSpace(computationResult.ToString()))
            {
                computationResult.Append(numberAsString);
            }

            return computationResult.ToString();
        }
    }
}
