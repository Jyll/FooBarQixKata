using System.Collections.Generic;

namespace FooBarQix
{
    public interface IFooBarQixService
    {
        IEnumerable<string> DoFooBarQix(int endIndex = 100);

        string Compute(int number);
    }
}