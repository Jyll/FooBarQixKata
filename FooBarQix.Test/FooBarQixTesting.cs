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

        [Fact(DisplayName = "When I compute the number 6, I should have Foo")]
        public void WhenIComputeTheNumber6WithFooBarQix_ThenIShouldGetBackFoo()
        {
            // act 
            var actualResult = _fooBarQixService.FooBarQixComputation(6);
            // assert 
            Check.That(actualResult).IsEqualTo("Foo");
        }

        [Fact(DisplayName = "When I compute the number 10, I should have Bar")]
        public void WhenIComputeTheNumber10WithFooBarQix_ThenIShouldGetBackBar()
        {
            // act 
            var actualResult = _fooBarQixService.FooBarQixComputation(10);
            // assert 
            Check.That(actualResult).IsEqualTo("Bar");
        }

        [Fact(DisplayName = "When I compute 14, I should have Qix")]
        public void WhenIComputeTheNumber14WithFooBarQix_ThenIShouldGetBackQix()
        {
            // act
            var actualResult = _fooBarQixService.FooBarQixComputation(14);
            Check.That(actualResult).IsEqualTo("Qix");
        }
    }
}
