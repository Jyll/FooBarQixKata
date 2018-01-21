using System.Collections.Generic;

namespace FooBarQix
{
    internal interface IFooBarQixService
    {
        IEnumerable<string> DoFooBarQix(int endIndex = 100);

        string FooBarQixComputation(int index);
    }
}