using System;
using Xunit;
using NFluent;

namespace FooBarQix.Test
{
    public class FooBarQixTesting
    {
        private readonly IFooBarQixService _fooBarQixService; 

        public FooBarQixTesting()
        {
            _fooBarQixService = new FooBarQixService();
        }

        [Fact(DisplayName = "When I compute the number six, I should have Foo")]
        public void WhenIComputeTheNumber6WithFooBarQix_ThenIShouldGetBackFoo()
        {
            // act 
            var actualResult = _fooBarQixService.FooBarQixComputation(6);
            // assert 
            Check.That(actualResult).IsEqualTo("Foo");
        }
    }
}
