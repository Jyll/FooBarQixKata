using System;
using System.Collections.Generic;
using System.Text;

namespace FooBarQix
{
    public class FooBarQixService : IFooBarQixService
    {
        private const string NegativeNumberExceptionMessage = "Negative numbers are not allowed in this method.";

        public const string Foo = "Foo";
        public const int FooDigit = 3;
        public const char FooChar = '3';

        public const string Bar = "Bar";
        public const int BarDigit = 5;
        public const char BarChar = '5';

        public const string Qix = "Qix";
        public const int QixDigit = 7;
        public const char QixChar = '7';

        public IEnumerable<string> DoFooBarQix(int endIndex = 100)
        {
            if(endIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(endIndex), "EndIndex must be superior or equal to 1");
            }

            var fooBarQixList = new List<string>(endIndex);

            for( int i = 1; i <= endIndex; i++)
            {
                fooBarQixList.Add(Compute(i));
            }

            return fooBarQixList;
        }

        public virtual string Compute(int number)
        {
            if(number < 0)
            {
                throw new InvalidOperationException(NegativeNumberExceptionMessage);
            }

            StringBuilder computationResult = new StringBuilder( string.Empty );
            string numberAsString = number.ToString();

            if(number % FooDigit == 0)
            {
                computationResult.Append(Foo);
            }
            if(number % BarDigit == 0)
            {
                computationResult.Append(Bar);
            }
            if(number % QixDigit == 0)
            {
                computationResult.Append(Qix);
            }

            foreach(var digit in numberAsString)
            {
                switch (digit)
                {
                    case FooChar:
                        computationResult.Append(Foo);
                        break;
                    case BarChar:
                        computationResult.Append(Bar);
                        break;
                    case QixChar:
                        computationResult.Append(Qix);
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
